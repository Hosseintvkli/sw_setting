/** @typedef {import('../../core/compiledExcel').CompiledExcelParamList} CompiledExcelParamList */
/** @typedef {import('../../core/compiledExcel').CompiledExcelSet} CompiledExcelSet */

const toolBox = require('../../../toolBox');
const codeGenCommon = require('../../helpers/codeGenCommon');

const TAB1 = `  `;
const TAB2 = TAB1.repeat(2);
const TAB3 = TAB1.repeat(3);
const TAB4 = TAB1.repeat(4);
const TAB5 = TAB1.repeat(5);

/**
 * @param {CompiledExcelParamList} model
 */
function generateModbusParameterListHFileHeader(model) {
  let output = ``;
  let fileName = codeGenCommon.generateDeviceIdFileName(
    model.DeviceId,
    `parameter_list_`,
  );

  output += toolBox.concatStringRows(
    `/* Define to prevent recursive inclusion -------------------------------------*/`,
    `#ifndef CG_${fileName.toUpperCase()}_H`,
    `#define CG_${fileName.toUpperCase()}_H`,
    ``,
    `#ifdef __cplusplus`,
    `extern "C" {`,
    `#endif`,
    ``,
  );
  
  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateModbusParameterListHFileInclude(model) {
  let output = ``;
  let fileName = codeGenCommon.generateDeviceIdFileName(
    model.DeviceId,
    `parameter_list_`,
  );

  output += toolBox.concatStringRows(
    `/* Includes ------------------------------------------------------------------*/`,
    `#include "nstdtype.h"`,
    ``,
    `#include "cg_database.h"`,
    `#include "cg_${fileName}_type.h"`,
    ``,
    `#include "modbus_slave_ex.h"`,
    ``,
  );
  
  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateModbusParameterListHFileExportedConstants(model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Exported constants --------------------------------------------------------*/`,
  );
  
  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateModbusParameterListHFileExportedDefines(model, outputsVersion=null) {
  let output = ``;
  let typedefName = ``;

  let lastNonEmptyRow = model.parameterListFilteredEmptyRows.at(-1);

  const MODBUS_SLAVE_MEMORY_MAP_HOLDING_REGISTER_QTY =
      lastNonEmptyRow.ModbusAddr.value
    + lastNonEmptyRow.ArraySize.value * model.dataTypeSizes[lastNonEmptyRow.DataType.value];
    

  const PARAMETERS_QTY =
    model.eForgedParameterIdSheet.filter((parameterId) => {
      return !parameterId.isVirtualParameterId;
    }).length;

  output += toolBox.concatStringRows(
    `/* Exported defines ----------------------------------------------------------*/`,
  );

  output += toolBox.concatStringRows(
    `/**`,
    `* @brief `,
    `* `,
    `*/`,
    `#define PARAMETER_LIST_VERSION      ${Number(outputsVersion)}`,
    `#define PARAMETER_LIST_VERSION_STR  "${outputsVersion}"`,
    ``,
  );
  
  output += toolBox.concatStringRows(
    `/**`,
    `* @brief `,
    `* `,
    `*/`,
    `#define MODBUS_SLAVE_MEMORY_MAP_HOLDING_REGISTER_QTY  ${MODBUS_SLAVE_MEMORY_MAP_HOLDING_REGISTER_QTY}`,
    ``,
  );

  output += toolBox.concatStringRows(
    `/**`,
    `* @brief `,
    `* `,
    `*/`,
    `#define PARAMETERS_QTY  ${PARAMETERS_QTY}`,
    ``,
  );

  typedefName = `parameter_list_info_t`;
  
  output += toolBox.concatStringRows(
    `/**`,
    `* @brief `,
    `* `,
    `*/`,
    `typedef uint16_t ${typedefName};`,
    ``,
  );

  model.InfoSheet.forEach((row) => {
    let defName = `PARAMETER_LIST_INFO_${row.NameUpperSnakeCase}`;

    output += `#define `;
    output += defName;
    
    output += ` `.repeat(
        model.infoNameUpperSnakeCaseMaxLength
      + `PARAMETER_LIST_INFO_`.length
      + 2
      - defName.length
    );

    output += `(${row.Value.value})`;

    output += `\r\n`;
  });
  
  output += `\r\n`;

  typedefName = `parameter_mb_addr_t`;

  output += toolBox.concatStringRows(
    `/**`,
    `* @brief `,
    `* `,
    `*/`,
    `typedef uint16_t ${typedefName};`,
    ``,
  );

  model.parsedParameterListFlat
    .filter((row) => !codeGenCommon.paramIsIgnoredByModbus(row))
    .forEach((flatParam) => {
    if(codeGenCommon.parameterListRowIsReserved(flatParam)) {
      return;
    }
    
    for (let i = 0; i < flatParam.WordSize.value; i++) {
      let prefix = `#define PARAMETER_MB_ADDR_`;

      let defName = ``;
      defName += flatParam.NameUpperSnakeCase;
      defName += flatParam.WordSize.value > 1 ? `_${i}` : ``;

      output += prefix;
      output += defName;

      output += ` `.repeat(
          model.parsedParameterListFlatNameUpperSnakeCaseMaxLength
        + 4
        - defName.length
      );

      output += `((${typedefName})${flatParam.ModbusAddr.value + i})`;

      output += `\r\n`;
    }
  });

  output += `\r\n`;

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateModbusParameterListHFileExportedMacro(model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Exported macro ------------------------------------------------------------*/`,
  );
  
  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateModbusParameterListHFileExportedTypes(model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Exported types (enum, struct, union,...)-----------------------------------*/`,
  );
  
  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateModbusParameterListHFileExportedFunctionPrototypes(model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Exported functions prototypes ---------------------------------------------*/`,
  );
  
  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateModbusParameterListHFileExternFunctions(model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Extern functions ----------------------------------------------------------*/`,
    `void fCgParameterList_Init(void);`,
    `uint8_t fCgParameterList_RestoreDefaultValue(void);`,
    ``,
  );
  
  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateModbusParameterListHFileExternObjectOrVariable(model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Extern Object or Variable -------------------------------------------------*/`,
    `extern sParametersValue ParametersValue;`,
    `extern const sParameterSpec ParametersSpec[];`,
    `extern const sModbusSlaveMemoryMapItem ParametersModbusSlaveMemoryMap[MODBUS_SLAVE_MEMORY_MAP_HOLDING_REGISTER_QTY];`,
    ``,
  );
  
  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateModbusParameterListHFileFooter(model) {
  let output = ``;
  let fileName = codeGenCommon.generateDeviceIdFileName(
    model.DeviceId,
    `parameter_list_`,
  );

  output += toolBox.concatStringRows(
    `#ifdef __cplusplus`,
    `}`,
    `#endif`,
    ``,
    `#endif /* CG_${fileName.toUpperCase()}_H */`,
    ``,
    `/************************ © COPYRIGHT FaraabinCo *****END OF FILE****/`,
    ``,
  );
  
  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
module.exports = function generateModbusParameterListHFile(model, outputsVersion=null) {
  let output = ``;
  let fileName = codeGenCommon.generateDeviceIdFileName(
    model.DeviceId,
    `parameter_list_`,
  );

  output += generateModbusParameterListHFileHeader(model);
  output += generateModbusParameterListHFileInclude(model);
  output += generateModbusParameterListHFileExportedConstants(model);
  output += generateModbusParameterListHFileExportedDefines(model, outputsVersion);
  output += generateModbusParameterListHFileExportedMacro(model);
  output += generateModbusParameterListHFileExportedTypes(model);
  output += generateModbusParameterListHFileExportedFunctionPrototypes(model);
  output += generateModbusParameterListHFileExternFunctions(model);
  output += generateModbusParameterListHFileExternObjectOrVariable(model);
  output += generateModbusParameterListHFileFooter(model);

  return {
    fileName: `cg_${fileName}.h`,
    fileContent: output,
    fileType: `H`
  };
}

