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
module.exports = function generateParameterListFlatJson(
  model,
  outputsVersion=null
) {
  let output = ``;
  let fileName = ``;
  let outputObject;

  function outputObjMapFunction (param, index) {
    let dataType = param.DataType.value;
    
    if(codeGenCommon.dataTypeIsEnum(param.DataType.value)) {
      dataType = codeGenCommon.generateCsClassName(model, outputsVersion);
      dataType += `+`;
      dataType += param.DataType.value;
    }
    
    return {
      Name: param.Name.value,
      ModbusSize: param.ArraySize.value * param.WordSize.value,
      ParameterID: index,
      ModbusAddr: param.ModbusAddr.value,
      DataType: dataType,
      ParameterType: param.ParameterType.value,
      Description: param.Description.value,
      Tag1: param.Tag1.value === null ? "" : param.Tag1.value,
      Tag2: param.Tag2.value === null ? "" : param.Tag2.value,
      Tag3: param.Tag3.value === null ? "" : param.Tag3.value,
      Tag4: param.Tag4.value === null ? "" : param.Tag4.value,
      Tag5: param.Tag5.value === null ? "" : param.Tag5.value,
    }
  }

  outputObject = model.parsedParameterListFlatFilteredReserves
    .filter((row) => !codeGenCommon.paramIsIgnoredByModbus(row))
    .map(outputObjMapFunction)

  fileName += codeGenCommon.generateDeviceIdFileName(
    model.DeviceId,
    `cg_parameter_list_`,
    `_parameter_list.json`,
    outputsVersion
  );

  output += JSON.stringify(outputObject, null, 2);

  return {
    fileName: fileName,
    fileContent: output,
    fileType: `JSON`
  };
}

