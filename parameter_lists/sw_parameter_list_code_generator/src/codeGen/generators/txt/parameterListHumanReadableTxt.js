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
module.exports = function generateParameterListHumanReadableTxtFile(
  model,
  outputsVersion=null
) {
  let output = ``;
  let fileName = ``;
  
  fileName += codeGenCommon.generateDeviceIdFileName(
    model.DeviceId,
    `cg_parameter_list_`,
    `_human_readable.txt`,
    outputsVersion
  );

  let targetParamListObj = toolBox.deepClone(model.parsedParameterListFlatFilteredReserves);

  targetParamListObj = targetParamListObj.filter((row) => !codeGenCommon.paramIsIgnoredByModbus(row))
  
  targetParamListObj = targetParamListObj.map((param, index) => {
    let paramClone = toolBox.deepClone(param);

    delete paramClone.Name;
    delete paramClone.ID;

    return ({
      Name: param.Name,
      ParameterID: index,
      ...paramClone,
    });
  });

  targetParamListObj = codeGenCommon.unwrapCellValues(targetParamListObj);

  output += codeGenCommon.generateObjectCommentTable(
    model.fileName,
    targetParamListObj
  );

  return {
    fileName: fileName,
    fileContent: output,
    fileType: `TXT`
  };
}

