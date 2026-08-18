/** @typedef {import('../../core/compiledExcel').CompiledExcelParamList} CompiledExcelParamList */
/** @typedef {import('../../core/compiledExcel').CompiledExcelDeviceId} CompiledExcelDeviceId */
/** @typedef {import('../../core/compiledExcel').CompiledExcelSet} CompiledExcelSet */

const toolBox = require('../../../toolBox');
const codeGenCommon = require('../../helpers/codeGenCommon');

const TAB1 = `  `;
const TAB2 = TAB1.repeat(2);
const TAB3 = TAB1.repeat(3);
const TAB4 = TAB1.repeat(4);
const TAB5 = TAB1.repeat(5);

/**
 * @param {CompiledExcelDeviceId} model
 */
function generateModbusDatabaseHFileHeader(model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Define to prevent recursive inclusion -------------------------------------*/`,
    `#ifndef CG_DATABASE_H`,
    `#define CG_DATABASE_H`,
    ``,
    `#ifdef __cplusplus`,
    `extern "C" {`,
    `#endif`,
    ``,
  );
  
  return output;
}

/**
 * @param {CompiledExcelDeviceId} model
 */
function generateModbusDatabaseHFileInclude(model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Includes ------------------------------------------------------------------*/`,
    `#include "nstdtype.h"`,
    ``,
  );
  
  return output;
}

/**
 * @param {CompiledExcelDeviceId} model
 */
function generateModbusDatabaseHFileExportedConstants(model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Exported constants --------------------------------------------------------*/`,
  );
  
  return output;
}

/**
 * @param {CompiledExcelDeviceId} model
 */
function generateModbusDatabaseHFileExportedDefines(model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Exported defines ----------------------------------------------------------*/`,
    `/**`,
    ` * @brief `,
    ` * `,
    ` */`,
    `typedef uint16_t device_id_t;`,
    ``,
  );

  const appendRowToOutput = (stringRow) => {
    output += stringRow;
    output += '\n';
  }

  model.DeviceIdSheetFilteredEmptyRows.forEach((row) => {
    let aligmentSpaces =
        model.deviceIdsNameUpperSnakeCaseMaxLength
      - row.NameUpperSnakeCase.length;

    let rowString = ``;

    rowString += `#define `;
    rowString += `DEVICE_ID_${row.NameUpperSnakeCase}  `;
    rowString += " ".repeat(aligmentSpaces);

    if(row.ID) {
      rowString += `((device_id_t)${row.ID.value})`;
    } else {
      rowString += `((device_id_t)${row.DeviceId.value})`;
    }

    appendRowToOutput(rowString)
  })

  appendRowToOutput(``)

  return output;
}

/**
 * @param {CompiledExcelDeviceId} model
 */
function generateModbusDatabaseHFileExportedMacro(model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Exported macro ------------------------------------------------------------*/`,
  );
  
  return output;
}

/**
 * @param {CompiledExcelDeviceId} model
 */
function generateModbusDatabaseHFileExportedTypes(model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Exported types (enum, struct, union,...)-----------------------------------*/`,
  );
  
  return output;
}

/**
 * @param {CompiledExcelDeviceId} model
 */
function generateModbusDatabaseHFileExportedFunctionPrototypes(model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Exported functions prototypes ---------------------------------------------*/`,
  );
  
  return output;
}

/**
 * @param {CompiledExcelDeviceId} model
 */
function generateModbusDatabaseHFileExternFunctions(model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Extern functions ----------------------------------------------------------*/`,
  );
  
  return output;
}

/**
 * @param {CompiledExcelDeviceId} model
 */
function generateModbusDatabaseHFileExternObjectOrVariable(model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `/* Extern Object or Variable -------------------------------------------------*/`,
  );
  
  return output;
}

/**
 * @param {CompiledExcelDeviceId} model
 */
function generateModbusDatabaseHFileFooter(model) {
  let output = ``;

  output += toolBox.concatStringRows(
    ``,
    `#ifdef __cplusplus`,
    `}`,
    `#endif`,
    ``,
    `#endif /* CG_DATABASE_H */`,
    ``,
    `/************************ © COPYRIGHT FaraabinCo *****END OF FILE****/`,
    ``,
  );
  
  return output;
}

/**
 * @param {CompiledExcelDeviceId} model
 */
module.exports = function generateModbusDatabaseHFile(model) {
  let output = ``;
  
  output += generateModbusDatabaseHFileHeader(model);
  output += generateModbusDatabaseHFileInclude(model);
  output += generateModbusDatabaseHFileExportedConstants(model);
  output += generateModbusDatabaseHFileExportedDefines(model);
  output += generateModbusDatabaseHFileExportedMacro(model);
  output += generateModbusDatabaseHFileExportedTypes(model);
  output += generateModbusDatabaseHFileExportedFunctionPrototypes(model);
  output += generateModbusDatabaseHFileExternFunctions(model);
  output += generateModbusDatabaseHFileExternObjectOrVariable(model);
  output += generateModbusDatabaseHFileFooter(model);

  return {
    fileName: `cg_database.h`,
    fileContent: output,
    fileType: `H`
  };
}

