'use strict';

const codeGenCommon = require('./helpers/codeGenCommon');

const {
  CompiledExcelParamList,
  CompiledExcelDeviceId,
  CompiledExcelSet
} = require('./core/compiledExcel');

/**
 * @typedef {import('./core/compiledExcel').CompiledExcelParamList} CompiledExcelParamList
 * @typedef {import('./core/compiledExcel').CompiledExcelDeviceId} CompiledExcelDeviceId
 * @typedef {import('./core/compiledExcel').CompiledExcelSet} CompiledExcelSet
 */

module.exports = {
  CompiledExcelParamList,
  CompiledExcelDeviceId,
  CompiledExcelSet,
  generateParameterListStructTypeHFile               : require('./generators/c/parameterListStructTypeH'),
  generateModbusParameterListHFile                   : require('./generators/c/modbusParameterListH'),
  generateModbusParameterListCFile                   : require('./generators/c/modbusParameterListC'),
  generateModbusDatabaseHFile                        : require('./generators/c/modbusDatabaseH'),
  generateModbusDatabaseDeviceIdJsonFile             : require('./generators/json/modbusDatabaseDeviceIdJson'),
  generateModbusDatabaseVirtualParametersIdJsonFile  : require('./generators/json/modbusDatabaseVirtualParametersIdJson'),
  generateParameterListHumanReadableTxtFile          : require('./generators/txt/parameterListHumanReadableTxt'),
  generateExcelsContentTxtFiles                      : require('./generators/txt/excelContentTxt'),
  generateParameterListInfoJson                      : require('./generators/json/parameterListInfoJson'),
  generateParameterListFlatJson                      : require('./generators/json/parameterListFlatJson'),
  generateParameterListCsFile                        : require('./generators/cs/modbusParameterListCs'),
  generateReadMeFiles                                : codeGenCommon.generateReadMeFiles,
  generateCodeGenMetaDataJsonFile                    : require('./generators/metaData/metaDataJson'),
};
