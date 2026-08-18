/** @typedef {import('../../core/compiledExcel').CompiledExcelParamList} CompiledExcelParamList */
/** @typedef {import('../../core/compiledExcel').CompiledExcelSet} CompiledExcelSet */

const { mode } = require('crypto-js');
const toolBox = require('../../../toolBox');
const codeGenCommon = require('../../helpers/codeGenCommon');

const TAB1 = `  `;
const TAB2 = TAB1.repeat(2);
const TAB3 = TAB1.repeat(3);
const TAB4 = TAB1.repeat(4);
const TAB5 = TAB1.repeat(5);

const SKIP_THIS_FOR_NOW = false;

const PARAM_TYPES = [
  `Monitoring`,
  `Setting`,
  `Command`,
];

/**
 * @param {CompiledExcelParamList} model
 */
function generatemodbusParmeterListCFileHeader(model) {
  let output = ``;

  output += toolBox.concatStringRows(
  );
  
  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generatemodbusParmeterListCFileInclude(model) {
  let output = ``;
  let fileName = codeGenCommon.generateDeviceIdFileName(
    model.DeviceId,
    `parameter_list_`,
  );

  output += toolBox.concatStringRows(
    `/* Includes ------------------------------------------------------------------*/`,
    `#include "cg_${fileName}.h"`,
    ``,
    `#include <string.h>`,
    ``,
  );
  
  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generatemodbusParmeterListCFilePritvateDefines(model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Private define ------------------------------------------------------------*/`,
  );

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generatemodbusParmeterListCFilePrivateMacro(model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Private macro -------------------------------------------------------------*/`,
  );
  
  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generatemodbusParmeterListCFilePrivateTypedef(model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Private typedef -----------------------------------------------------------*/`,
  );
  
  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generatemodbusParmeterListCFilePrivateVariables(model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Private variables ---------------------------------------------------------*/`,
  );
  
  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generatemodbusParmeterListCFilePrivateFunctionPrototypes(model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Private function prototypes -----------------------------------------------*/`,
  );
  
  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generatemodbusParmeterListCFileVariableParameters(model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `const sParameterSpec ParametersSpec[] = {`,
  );

  let targetList = model.parsedParameterListFlat.filter((row) => !codeGenCommon.paramIsIgnoredByModbus(row));

  targetList.forEach((row, index) => {
    if(codeGenCommon.parameterListRowIsReserved(row)) {
      return;
    }

    let isLast = index === (targetList.length - 1);
    let parameterTypeName = `PARAMETER_TYPE_`;

    parameterTypeName += codeGenCommon.getModbusParameterListParameterTypeName(row).toUpperCase();

    let valueSize = model.dataTypeSizes[row.DataType.value] * 2;
    let parameterValueName = ``;

    parameterValueName += row.Group.value;
    parameterValueName += `.` + codeGenCommon.getModbusParameterListParameterTypeName(row);
    parameterValueName += `.` + row.Name.value;

    output += TAB1 + `{ /* ${row.Name.value} */\r\n`;
    
    if(SKIP_THIS_FOR_NOW) {
      output += TAB2 + `/* .pName = "${row.Name.value}", */\r\n`
    }
    output += TAB2 + `.Type = ${parameterTypeName},\r\n`

    for(let i = 1; i < 6; i++) {
      if(row[`Tag${i}`].value !== null) {
        output += TAB2 + `.Tag${i} = ${row[`Tag${i}`].value},\r\n`
      } else {
        if(SKIP_THIS_FOR_NOW) {
          output += TAB2 + `/* .Tag${i} = */\r\n`
        }
      }
    }

    output += TAB2 + `.ValueSize = ${valueSize},\r\n`
    output += TAB2 + `.pValue = &(ParametersValue.${parameterValueName}),\r\n`
    output += TAB2 + `.ModbusAddr = ${row.ModbusAddr.value}\r\n`

    if(isLast) { /* Last Object */
      output += TAB1 + `  }\r\n`
    } else {
      output += TAB1 + `  },\r\n`
    }
  });

  output += toolBox.concatStringRows(
    `};`,
  );

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generatemodbusParmeterListCFileVariableModbusSlaveMemoryMapItems(model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `const sModbusSlaveMemoryMapItem ParametersModbusSlaveMemoryMap[MODBUS_SLAVE_MEMORY_MAP_HOLDING_REGISTER_QTY] = {`,
  );
  
  let targetList = model.parsedParameterListFlat.filter((flatParam) => {
    return !codeGenCommon.paramIsIgnoredByModbus(flatParam)
  });

  targetList.forEach((flatParam, index) => {
    const isReserved = codeGenCommon.parameterListRowIsReserved(flatParam);
    const isLastFlatParam = index === (targetList.length - 1);

    for (let i = 0; i < flatParam.WordSize.value; i++) {
      let isLastArrayParamAarrayElement = i === flatParam.WordSize.value - 1;
      let numStr = `${flatParam.ModbusAddr.value + i}`;
      numStr += ` `.repeat(6 - numStr.length);
      
      let fieldValues = {
        pValue: ``,
        AccessType: ``,
        ParameterId: `PARAMETER_ID_${flatParam.NameUpperSnakeCase.toUpperCase()}`,
        ParameterType: null,
        extraComment: ``,
      };

      if(isReserved) {
        fieldValues.ParameterId = 65535;
      }

      output += `  /* ${numStr} */ { `;

      if(isReserved) {
        let flatParamName = codeGenCommon.removeCodegenMarkerFromParameterName(flatParam.Name.value);

        fieldValues.pValue = `NULL`;
        fieldValues.AccessType = `eMBSEX_MM_ACCESS_TYPE_RW`;
        fieldValues.extraComment = ` /* ${flatParamName.split(`[`)[0]} */`;
      } else {
        fieldValues.pValue += `&(((uint16_t*)&(`;
        fieldValues.pValue += `ParametersValue`;
        fieldValues.pValue += `.${flatParam.Group.value}`;
        fieldValues.pValue += `.${codeGenCommon.getModbusParameterListParameterTypeName(flatParam)}`;
        fieldValues.pValue += `.${flatParam.Name.value}))[${i}])`;

        if(codeGenCommon.modbusParameterListParameterRowIsSetting(flatParam)) {
          fieldValues.AccessType = `eMBSEX_MM_ACCESS_TYPE_RW`;
        } else if (codeGenCommon.modbusParameterListParameterRowIsCommand(flatParam)) {
          fieldValues.AccessType = `eMBSEX_MM_ACCESS_TYPE_RW`;
        } else if (codeGenCommon.modbusParameterListParameterRowIsMonitoring(flatParam)) {
          fieldValues.AccessType = `eMBSEX_MM_ACCESS_TYPE_R`;
        }
      }

      output += `.pValue = ${fieldValues.pValue}`;
      output += `, .AccessType = ${fieldValues.AccessType}`;
      output += `, .ParameterId = ${fieldValues.ParameterId}`;
      if(fieldValues.ParameterType) {
        output += `, .ParameterType = ${fieldValues.ParameterType}`;
      }
      output += `${fieldValues.extraComment}`;

      output += ` }`;
      if(isLastFlatParam && isLastArrayParamAarrayElement) {
        /* Do nothing */
      } else {
        output += `,`;
      }
      output += `\r\n`;
    }
  });

  output += toolBox.concatStringRows(
    `};`,
  );

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generatemodbusParmeterListCFileVariables(model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Variables -----------------------------------------------------------------*/`,
    `sParametersValue ParametersValue;`,
    ``,
  );

  output += generatemodbusParmeterListCFileVariableParameters(model);
  output += toolBox.concatStringRows(``);
  output += generatemodbusParmeterListCFileVariableModbusSlaveMemoryMapItems(model);
  output += toolBox.concatStringRows(``);

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generatemodbusParmeterListCFileExportedFunctions(model) {
  let output = ``;
  let lastElementWasArray = false;
  let forLoopDepth = 0;
  let interatorName = 0;

  output += toolBox.concatStringRows(
    `/*`,
    `╔═════════════════════════════════════════════════════════════════════════════════╗`,
    `║                          ##### Exported Functions #####                         ║`,
    `╚═════════════════════════════════════════════════════════════════════════════════╝*/`,
    `void fCgParameterList_Init(void) {`,
    `}`,
    ``,
    `uint8_t fCgParameterList_RestoreDefaultValue(void) {`,
  );

  function updateForLoopDepth (depthDiff) {
    forLoopDepth += depthDiff;
    interatorName = `i${forLoopDepth - 1}`;
  }
  
  const appendRowsToOutput = (...stringRows) => {
    stringRows.forEach((stringRow) => {
      output += stringRow;
      output += '\r\n';
    });
  }

  const parameterIsArray = (parameter) => {
    return parameter.ArraySize.value !== 1;
  }

  const parameterTypeIsEnum = (parameter) => {
    return codeGenCommon.dataTypeIsEnum(parameter.DataType.value)
  }

  const parameterTypeIsStruct = (parameter) => {
    return codeGenCommon.dataTypeIsStruct(parameter.DataType.value)
  }

  function handleNewLineAfterForLoopBlock () {
    if(lastElementWasArray) {
      appendRowsToOutput(``);
    }
  }

  function generatePrimitiveParamInitValue (parameter, fieldName, isArrayElement=false, extraTabs=0) {
    handleNewLineAfterForLoopBlock();

    if(isArrayElement) {
      fieldName +=  `.` + parameter.Name.value + `[${interatorName}]`;
    } else {
      fieldName +=  `.` + parameter.Name.value;
    }

    let paramDefaultValue = codeGenCommon.getParameterDefaultValue(parameter);
    
    appendRowsToOutput(
      `  `.repeat(extraTabs + 1) + `${fieldName} = ${paramDefaultValue}` + `;`,
    );

    lastElementWasArray = false;
  }

  function generateStructParamInitValue (
    parameter,
    fieldName,
    isArrayElement=false,
    extraTabs=0)
  {
    handleNewLineAfterForLoopBlock();

    if(isArrayElement) {
      fieldName +=  `.` + parameter.Name.value + `[${interatorName}]`;
    } else {
      fieldName +=  `.` + parameter.Name.value;
    }
    
    let typeObj = model.StructTypeSheets[parameter.DataType.value];

    typeObj.forEach((field) => {
      if(codeGenCommon.structSheetRowIsVarTypeSize(field)) {
        return;
      }
      
      generateParamInitValue(
        field,
        fieldName,
        extraTabs
      );
    });
    
    lastElementWasArray = false;
  }

  function generateEnumParamInitValue (
    parameter,
    fieldName,
    isArrayElement=false,
    extraTabs=0
  ) {
    handleNewLineAfterForLoopBlock();

    if(isArrayElement) {
      fieldName +=  `.` + parameter.Name.value + `[${interatorName}]`;
    } else {
      fieldName +=  `.` + parameter.Name.value;
    }
    
    let defaultValue = codeGenCommon.getParameterDefaultValue(parameter);
    let typeCastStr = parameter.DataType.value + `_t`;
    
    appendRowsToOutput(
      `  `.repeat(extraTabs + 1) + `${fieldName} = (${typeCastStr})${defaultValue}`+ `;`
        + ` // TEST: This is an enum`,
    );
    
    lastElementWasArray = false;
  }

  function generateArrayParamInitValue (
    parameter,
    fieldName,
    isArrayElement=false,
    extraTabs=0
  ) {
    lastElementWasArray = false;

    updateForLoopDepth(1);
    appendRowsToOutput(
      ``,
      `  `.repeat(extraTabs + 1) + `for(uint32_t ${interatorName} = 0; ${interatorName} < ${parameter.ArraySize.value}; ${interatorName}++) {`,
    );

    if(parameterTypeIsStruct(parameter)) {
      generateStructParamInitValue(parameter, fieldName, true, extraTabs + 1);
    } else if(parameterTypeIsEnum(parameter)) {
      generateEnumParamInitValue(parameter, fieldName, true, extraTabs + 1);
    } else {
      generatePrimitiveParamInitValue(parameter, fieldName, true, extraTabs + 1);
    }
    
    updateForLoopDepth(-1);
    appendRowsToOutput(
      `  `.repeat(extraTabs + 1) + `}`,
    );

    lastElementWasArray = true;
  }

  function generateParamInitValue (parameter, fieldName, extraTabs=0) {
    if(parameterIsArray(parameter)) {
      generateArrayParamInitValue(parameter, fieldName, false, extraTabs);
    } else if(parameterTypeIsStruct(parameter)) {
      generateStructParamInitValue(parameter, fieldName, false, extraTabs);
    } else if(parameterTypeIsEnum(parameter)) {
      generateEnumParamInitValue(parameter, fieldName, false, extraTabs);
    } else {
      generatePrimitiveParamInitValue(parameter, fieldName, false, extraTabs);
    }
  }

  function generateStructVarFieldInitValuesOutput (
    structName,
    parameterType,
    parameterSubType,
  ) {
    let targetParameterList = model.paramListGroupedByGroup[parameterType];

    if(!targetParameterList) {
      return;
    }

    if(targetParameterList.length === 0) {
      return;
    }

    targetParameterList = targetParameterList[parameterSubType];

    if(!targetParameterList || !targetParameterList.length) {
      return;
    }

    targetParameterList.forEach((parameter) => {
      if(codeGenCommon.parameterListRowIsReserved(parameter)) {
        return;
      }
      
      let fieldName = `ParametersValue.` + structName;

      generateParamInitValue(parameter, fieldName);
    })
  }

  model.groupNames.forEach((parameterType) => {
    PARAM_TYPES.forEach((paramType) => {
      generateStructVarFieldInitValuesOutput(
        `${parameterType}.${paramType}`,
        `${parameterType}`,
        paramType
      );
    });
  });
  
  output += toolBox.concatStringRows(
    ``,
    `  return 0;`,
    `}`,
    ``,
  );

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generatemodbusParmeterListCFilePrivateFunctions(model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/*`,
    `╔═════════════════════════════════════════════════════════════════════════════════╗`,
    `║                            ##### Private Functions #####                        ║`,
    `╚═════════════════════════════════════════════════════════════════════════════════╝*/`,
    ``,
  );

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generatemodbusParmeterListCFileFooter(model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/************************ © COPYRIGHT FaraabinCo *****END OF FILE****/`,
    ``,
  );

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
module.exports = function generatemodbusParmeterListCFile(model) {
  let output = ``;
  
  output += generatemodbusParmeterListCFileHeader(model);
  output += generatemodbusParmeterListCFileInclude(model);
  output += generatemodbusParmeterListCFilePritvateDefines(model);
  output += generatemodbusParmeterListCFilePrivateMacro(model);
  output += generatemodbusParmeterListCFilePrivateTypedef(model);
  output += generatemodbusParmeterListCFilePrivateVariables(model);
  output += generatemodbusParmeterListCFilePrivateFunctionPrototypes(model);
  output += generatemodbusParmeterListCFileVariables(model);
  output += generatemodbusParmeterListCFileExportedFunctions(model);
  output += generatemodbusParmeterListCFilePrivateFunctions(model);
  output += generatemodbusParmeterListCFileFooter(model);

  let fileName = codeGenCommon.generateDeviceIdFileName(
    model.DeviceId,
    `parameter_list_`,
  );

  return {
    fileName: `cg_${fileName}.c`,
    fileContent: output,
    fileType: `H`
  };
}

