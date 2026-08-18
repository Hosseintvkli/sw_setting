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

function generateExcelSheetContentTxt (sheetName, sheetObj) {
  let output = ``;

  output += codeGenCommon.generateObjectCommentTable(
    sheetName,
    codeGenCommon.unwrapCellValues(sheetObj)
  );

  return output;
}

/**
 * @param {CompiledExcelSet} excelSet
 */
module.exports = function generateExcelsContentTxtFiles(
  excelSet,
  outputsVersion=null
) {
  let outputFiles = {};

  [
    ...excelSet.CompiledExcelDeviceIds,
    ...excelSet.CompiledExcelParamLists,
  ].forEach((excelObj) => {
    if(!excelObj.excelUpdated) {
      return;
    }

    outputFiles[excelObj.excelOriginal.fileName] = [];

    Object.keys(excelObj.excelOriginal.workbook).forEach((sheetName) => {
      let sheetObj = excelObj.excelOriginal.workbook[sheetName];

      let sheetContentTxt = generateExcelSheetContentTxt(sheetName, sheetObj);

      outputFiles[excelObj.excelOriginal.fileName].push({
        fileName: excelObj.excelOriginal.fileName + ` - ` + sheetName + `.txt`,
        fileContent: sheetContentTxt,
        fileType: `TXT`
      });
    });
  });

  return outputFiles;
}

