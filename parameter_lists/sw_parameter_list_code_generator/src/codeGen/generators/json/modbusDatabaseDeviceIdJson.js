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
module.exports = function generateModbusDatabaseDeviceIdJsonFile(model) {
  let output = ``;
  let fileName = ``;
  let outputObject;

  outputObject = codeGenCommon.unwrapCellValues(model.DeviceIdSheet);

  outputObject = outputObject.map((row) => {
    let newRow = {};

    Object.keys(row).forEach((field) => {
      switch(field) {
        case `Group`       : { newRow[field] = codeGenCommon.convNumStringToNum(row[field], {expectedType: `string`}); } break;
        case `Name`        : { newRow[field] = codeGenCommon.convNumStringToNum(row[field], {expectedType: `string`}); } break;
        case `ID`          : { newRow[field] = codeGenCommon.convNumStringToNum(row[field], {expectedType: `number`}); } break;
        case `DeviceId`    : { newRow[field] = codeGenCommon.convNumStringToNum(row[field], {expectedType: `number`}); } break;
        case `Description` :
        case `Decription`  : { newRow[field] = codeGenCommon.convNumStringToNum(row[field], {expectedType: `string`}); } break;
        // default            : { newRow[field] = codeGenCommon.convNumStringToNum(row[field], {expectedType: `string`}); } break;
        default: break;
      }
    });

    return newRow;
  });

  fileName += `cg_database_deviceid.json`;

  output += JSON.stringify(outputObject, null, 2);

  return {
    fileName: fileName,
    fileContent: output,
    fileType: `JSON`
  };
}

