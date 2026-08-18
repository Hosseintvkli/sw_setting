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
 * @param {object} codeGenMetaData
 */
module.exports = function generateCodeGenMetaDataJsonFile(
  codeGenMetaData
) {
  let output = ``;
  let fileName = ``;

  fileName += `metaData.json`

  output = JSON.stringify(codeGenMetaData, null, 2);

  return {
    fileName: fileName,
    fileContent: output,
    fileType: `MetaData`
  };
}

