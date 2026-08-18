/** @typedef {import('../../core/compiledExcel').CompiledExcelParamList} CompiledExcelParamList */
/** @typedef {import('../../core/compiledExcel').CompiledExcelSet} CompiledExcelSet */

const toolBox = require('../../../toolBox');
const codeGenCommon = require('../../helpers/codeGenCommon');

const TAB1 = `  `;
const TAB2 = TAB1.repeat(2);
const TAB3 = TAB1.repeat(3);
const TAB4 = TAB1.repeat(4);
const TAB5 = TAB1.repeat(5);

const PARAMETER_TYPES = [
  `Monitoring`,
  `Setting`,
  `Command`,
];

function generateFaraabinStructStart (structName) {
  let outputString = ``;

  outputString += toolBox.concatStringRows(
    `typedef_struct_(${structName}) {`,
  );

  return outputString;
}

function generateFaraabinStructEnd (structName) {
  let outputString = ``;

  outputString += toolBox.concatStringRows(
    `}typedef_struct_end_(${structName});`,
    ``,
  );

  return outputString;
}

function generateFaraabinStructMember (type, name, arraySize) {
  let outputString = ``;

  if(arraySize !== 1) {
    outputString += `  sma_(`;
  } else {
    outputString += `  sm_(`;
  }

  if(codeGenCommon.dataTypeIsEnum(type)) {
    type = type + `_t`;
  }

  outputString += codeGenCommon.excelDataTypeToC(type);
  outputString +=  `, ${name}`;

  if(arraySize !== 1) {
    outputString +=  `, ${arraySize});`;
  } else {
    outputString +=  `);`;
  }

  outputString += `\r\n`;

  return outputString;
}

function generateFaraabinStructMembers (objectRows) {
  let outputString = ``;

  if(objectRows.length === 0) {
    outputString += toolBox.concatStringRows(`  uint8_t __dummy;`);
  }

  objectRows.forEach((row) => {
    if(!row.DataType.value) {
      return;
    }

    if(codeGenCommon.parameterListRowIsReserved(row)) {
      return;
    }
    
    outputString += generateFaraabinStructMember(
      row.DataType.value,
      row.Name.value,
      row.ArraySize.value,
    );
  });

  return outputString;
}

function generateFaraabinStruct (structName, objectRows) {
  let outputString = ``;

  outputString += generateFaraabinStructStart(structName);
  outputString += generateFaraabinStructMembers(objectRows);
  outputString += generateFaraabinStructEnd(structName)

  return outputString;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateParameterIdTypefGroup (model) {
  let output = ``;
  
  let typedefName = `eParameterId_t`;

  output += toolBox.concatStringRows(
    `/**`,
    `* @brief `,
    `* `,
    `*/`,
    `typedef uint16_t ${typedefName};`,
    ``,
  );
  
  let firstVirtualParameterIdSeen = false;

  model.eForgedParameterIdSheet.forEach((parameterId) => {
    if(!firstVirtualParameterIdSeen) {
      if(parameterId.isVirtualParameterId) {
        firstVirtualParameterIdSeen = true;
        output += `/* \\/ eVirtualParameterId \\/ */`;
        output += `\r\n`;
      }
    }

    output += `#define `;
    output += `PARAMETER_ID_${parameterId.NameUpperSnakeCase.toUpperCase()}  `;
    output += ` `.repeat(model.parameterIdNameUpperSnakeCaseMaxLength - parameterId.NameUpperSnakeCase.length);
    output += `((${typedefName})${parameterId.Value.value})`;
    output += `\r\n`;
  });
  output += toolBox.concatStringRows(``);

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateTypedefSheetTypes (model) {
  let outputString = ``;

  model.enumSheetNames.forEach((sheetName) => {
    if(sheetName === `eParameterId`) {
      return;
    }
    
    if(codeGenCommon.enumTypeIsFromHeaderFiles(model, sheetName)) {
      return;
    }

    let typedefMacrosPrefix = ``;

    outputString += codeGenCommon.generateTypedefGroupFromEnumSheet(
      model.EnumTypeSheets[sheetName],
      {
        typedefName: sheetName + `_t`,
        typedefMacrosPrefix,
      },
    );

    outputString += `\r\n`;
  });

  model.structSheetNames.forEach((sheetName) => {
    if(codeGenCommon.structTypeIsFromHeaderFiles(model, sheetName)) {
      return;
    }

    outputString += generateFaraabinStruct(
      sheetName,
      model.StructTypeSheets[sheetName]
    );
  });

  return outputString
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateParameterListStructTypeHFileHeader (model) {
  let output = ``;
  let fileName = codeGenCommon.generateDeviceIdFileName(
    model.DeviceId,
    `parameter_list_`,
  );

  output += toolBox.concatStringRows(
    `/* Define to prevent recursive inclusion -------------------------------------*/`,
    `#if(!defined(CG_${fileName.toUpperCase()}_TYPE_H) || defined(TYPE_DICT))`,
    ``,
    `#ifdef __cplusplus`,
    `extern "C" {`,
    `#endif`,
    ``,
  )

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateParameterListStructTypeHFileInclude (model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Includes ------------------------------------------------------------------*/`,
    `#include "faraabin.h"`,
    `#include "faraabin_fobject_vartype_cg.h"`,
    `#include "parameter_list_dependencies.h"`,
    ``,
  )

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateParameterListStructTypeHFileExportedConstants (model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Exported constants --------------------------------------------------------*/`,
  )

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateParameterListStructTypeHFileExportedDefines (model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Exported defines ----------------------------------------------------------*/`,
  )
  
  let enumMemberQtyMaxMacroLength = Math.max(
    ...Object.keys(model.enumSheetProperties).map((enumName) => enumName.length)
  ) + `_MEMBER_QTY`.length;

  Object.keys(model.enumSheetProperties).forEach(enumName => {
    let enumSheetProperties = model.enumSheetProperties[enumName];
    let macroName = enumName + `_MEMBER_QTY`;

    output += `#define `;
    output +=  macroName;
    output += ` `.repeat(2 + enumMemberQtyMaxMacroLength - macroName.length);
    output += `${enumSheetProperties.memberQty}`;
    output += `\r\n`;
  });
  
  output += `\r\n`;

  let paramListStructTypeSizeDefinitionsMaxLength = Math.max(
    ...model.structSheetNames.map((structSheetName) => structSheetName.length)
  );

  model.structSheetNames.forEach((structSheetName) => {
    let macroName = `${structSheetName}_MODBUS_SIZE`;

    output += `#define `;
    output +=  macroName;
    output += ` `.repeat(2 + paramListStructTypeSizeDefinitionsMaxLength - structSheetName.length);
    output += model.dataTypeSizes[structSheetName];
    output += `\r\n`;
  });
  
  output += `\r\n`;

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateParameterListStructTypeHFileExportedMacro (model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Exported macro ------------------------------------------------------------*/`,
  )

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateParameterListStructTypeHFileExportedTypes (model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Exported types (enum, struct, union,...)-----------------------------------*/`,
  );

  output += generateParameterIdTypefGroup(model);
  output += generateTypedefSheetTypes(model);

  model.groupNames.forEach((groupName) => {
    let targetParamListGroup = model.paramListGroupedByGroup[groupName];

    Object.keys(targetParamListGroup).forEach(parameterType => {
      let parameterSubgroup = targetParamListGroup[parameterType];
      let structName = `sParametersValue_${groupName}_${parameterType}`;

      output += generateFaraabinStruct(structName, parameterSubgroup);
    });

    output += generateFaraabinStructStart(`sParametersValue_${groupName}`);

    Object.keys(targetParamListGroup).forEach(parameterType => {
      let structName = `sParametersValue_${groupName}_${parameterType}`;

      output += generateFaraabinStructMember(
        structName,
        `${parameterType}`,
        1
      );
    });

    output += generateFaraabinStructEnd(`sParametersValue_${groupName}`);
  });

  /* sParametersValue Struct Typedef */
  output += generateFaraabinStructStart(`sParametersValue`);

  model.groupNames.forEach((typeName) => {
    output += generateFaraabinStructMember(
      `sParametersValue_${typeName}`,
      `${typeName}`,
      1
    );
  });

  output += generateFaraabinStructEnd(`sParametersValue`);

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateParameterListStructTypeHFileFooter (model) {
  let output = ``;
  let fileName = codeGenCommon.generateDeviceIdFileName(
    model.DeviceId,
    `parameter_list_`,
  );

  output += toolBox.concatStringRows(
    ``,
    `#if(!defined(TYPE_DICT))`,
    `  #define CG_${fileName.toUpperCase()}_TYPE_H`,
    ``,
    `#ifdef __cplusplus`,
    `}`,
    `#endif`,
    ``,
    `#endif /* TYPE_DICT */`,
    `#endif /* CG_${fileName.toUpperCase()}_TYPE_H */`,
    ``,
    `/************************ © COPYRIGHT FaraabinCo *****END OF FILE****/`,
    ``,
  )

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateParameterListStructTypeHFileExportedFunctionPrototypes (model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Exported functions prototypes ---------------------------------------------*/`,
  )

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateParameterListStructTypeHFileExternFunctions (model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Extern functions ----------------------------------------------------------*/`,
  )

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateParameterListStructTypeHFileExternObjectOrVariable (model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Extern Object or Variable -------------------------------------------------*/`,
  )

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
module.exports = function generateParameterListStructTypeHFile(model) {
  let output = ``;
  let fileName = codeGenCommon.generateDeviceIdFileName(
    model.DeviceId,
    `parameter_list_`,
  );
  
  output += generateParameterListStructTypeHFileHeader(model);
  output += generateParameterListStructTypeHFileInclude(model);
  output += generateParameterListStructTypeHFileExportedConstants(model);
  output += generateParameterListStructTypeHFileExportedDefines(model);
  output += generateParameterListStructTypeHFileExportedMacro(model);
  output += generateParameterListStructTypeHFileExportedTypes(model);
  output += generateParameterListStructTypeHFileExportedFunctionPrototypes(model);
  output += generateParameterListStructTypeHFileExternFunctions(model);
  output += generateParameterListStructTypeHFileExternObjectOrVariable(model);
  output += generateParameterListStructTypeHFileFooter(model);

  return {
    fileName: `cg_${fileName}_type.h`,
    fileContent: output,
    fileType: `H`
  };
}

