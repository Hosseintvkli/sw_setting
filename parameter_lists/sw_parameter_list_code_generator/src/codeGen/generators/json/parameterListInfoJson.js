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
 * @param {CompiledExcelParamList} model
 */
module.exports = function generateParameterListInfoJson(
  model,
  outputsVersion=null
) {
  let output = ``;
  let fileName = ``;
  let infoObj = {};

  fileName += codeGenCommon.generateDeviceIdFileName(
    model.DeviceId,
    `cg_parameter_list_`,
    `_info.json`,
    outputsVersion
  );

  model.InfoSheet.forEach((row) => {
    if(!row.Value || !row.Name) {
      return;
    }

    let value = row.Value.value;

    if(!isNaN(value)) {
      value = Number(value);
    }

    infoObj[row.Name.value] = value;
  })

  output = JSON.stringify(infoObj, null, 2)

  return {
    fileName: fileName,
    fileContent: output,
    fileType: `JSON`
  };
}

