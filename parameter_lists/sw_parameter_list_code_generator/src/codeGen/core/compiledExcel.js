'use strict';

const appConfig = require('../../appConfig');
const toolBox = require('../../toolBox');
const codeGenCommon = require('../helpers/codeGenCommon');

class CompiledExcel {
  /** @type {string} */
  fileName;

  /** @type {object} */
  excel;
  excelOriginal;

  compileRuleCheckTytpedefSheetRowNamesAreValidCIdentifier (sheetObj, sheetName, extraOptions={}) {
    sheetObj.forEach((row) => {
      if(codeGenCommon.isValidCIdentifierSyntax(row.Name.value)) {
        return;
      }

      this.reportCompileError({
        type: `Enumerator Name Is Not Valid C Identifier`,
        sheetName,
        sheetRow: row,
        extraOptions
      });
    });
  }

  compileRuleCheckWorkbookContainsSheet(sheetObj, sheetName, options={}) {
    if(!sheetObj) {
      this.reportCompileError({
        type: `Sheet Not Found`,
        sheetName: sheetName,
        extraOptions: options
      });
    }
  }

  compileRuleCheckSheetContainsColumns(sheetObj, sheetName, columnNames) {
    if(sheetObj.length === 0) {
      return;
    }

    let missingColumns = [];

    columnNames.forEach((columnName) => {
      if(!sheetObj[0].hasOwnProperty(columnName.split(` `).join(``))) {
        missingColumns.push(columnName);
      }
    });

    if(missingColumns.length !== 0) {
      this.reportCompileError({
        type: `Sheet Column Not Found`,
        sheetName,
        missingColumns,
        expectedColumns: columnNames
      });
    }
  }

  compileConvertNumberColumnsToNumbers(sheetObj, columnNames) {
    sheetObj.forEach((row) => {
      columnNames.forEach((columnName) => {
        columnName = columnName.split(` `).join(``);

        if(!isNaN(row[columnName].value) && (row[columnName].value !== null)) {
          row[columnName].value = Number(row[columnName].value);
        }
      });
    });
  }
  
  compileRuleCheckSheetContainsRows(sheetObj, sheetName, columnRowPairs=[]) {
    if(sheetObj.length === 0) {
      return;
    }

    columnRowPairs.forEach((pair) => {
      let {
        colName = null,
        cellValue = null
      } = pair;

      let targetRow = sheetObj.find((row) => {
        return (row[colName].value === cellValue);
      });

      if(!targetRow) {
        this.reportCompileError({
          type: `Sheet Row Not Found`,
          sheetName,
          colName,
          cellValue,
        });
      }
    });
  }

  compileRuleCheckSheetRowParameterTypesAreValid(sheetObj, sheetName) {
    sheetObj.forEach((row) => {
      if(this.ParameterTypeNames.includes(row.ParameterType.value)) {
        return;
      }

      if(codeGenCommon.parameterListRowIsReserved(row)) {
        return;
      }

      this.reportCompileError({
        type: `ParameterType Not Valid`,
        sheetName,
        sheetRow: row,
      });
    });
  }

  compileRuleCheckSheetRowDataTypesAreValid(sheetObj, sheetName) {
    sheetObj.forEach((row) => {
      if(this.typedefSheetNames.includes(row.DataType.value)) {
        return;
      }
      
      console.log(row);

      this.reportCompileError({
        type: `DataType Not Valid`,
        sheetName,
        sheetRow: row,
      });
    });
  }

  compileRuleCheckColumnValuesStartWithCapitalLetter (sheetObj, sheetName, columnName) {
    sheetObj.forEach((row) => {
      if(/^[A-Z]/.test(row[columnName].value)) {
        return;
      }

      this.reportCompileError({
        type: `Parameter Name Must Start With Capital Letter`,
        sheetName,
        sheetRow: row,
        columnName
      });
    });
  }

  compileRuleCheckColumnValuesAreValidCIdentifier (sheetObj, sheetName, columnName) {
    sheetObj.forEach((row) => {
      if(codeGenCommon.isValidCIdentifierSyntax(row[columnName].value)) {
        return;
      }

      this.reportCompileError({
        type: `Parameter Name Is Not Valid C Identifier`,
        sheetName,
        sheetRow: row,
      });
    });
  }

  #rowFieldValueIsValidNumber(rowCell) {
    if(rowCell.value === null) {
      return false;
    }
    
    if(isNaN(rowCell.value)) {
      return false;
    }

    return true;
  }

  compileRuleCheckSheetRowArraySizesAreValid(sheetObj, sheetName) {
    sheetObj.forEach((row) => {
      if(!this.#rowFieldValueIsValidNumber(row.ArraySize)) {
        this.reportCompileError({
          type: `ArraySize Not A Number`,
          sheetName,
          sheetRow: row,
        });
      }

      if(!/^[1-9]\d*$/.test(row.ArraySize.value)) {
        this.reportCompileError({
          type: `ArraySize Not A Positive Integer Number`,
          sheetName,
          sheetRow: row,
        });
      }
    });
  }

  compileRuleCheckParamsIgnoredByModbusDontHaveModbusAddrConstraint() {
    this.ParameterListSheet.forEach((row) => {
      if(!codeGenCommon.paramIsIgnoredByModbus(row)) {
        return;
      }
      
      if(!isNaN(row.ModbusAddrConstraint.value) && row.ModbusAddrConstraint.value !== null) {
        this.reportCompileError({
          type: `Params Ignored By Modbus Dont Have Modbus Addr Constraint`,
          sheetName: `ParameterList`,
          sheetRow: row,
        });
      }
    });
  }

  compileRuleCheckSheetRowIdAreValid(sheetObj, sheetName) {
    sheetObj.forEach((row) => {
      if(this.#rowFieldValueIsValidNumber(row.ID)) {
        return;
      }

      this.reportCompileError({
        type: `ID Not A Number`,
        sheetName,
        sheetRow: row,
      });
    });
  }

  compileRuleCheckSheetRowValuesAreValidNumbers(sheetObj, sheetName) {
    sheetObj.forEach((row) => {
      if(this.#rowFieldValueIsValidNumber(row.Value)) {
        return;
      }

      this.reportCompileError({
        type: `Value Not A Number`,
        sheetName,
        sheetRow: row,
      });
    });
  }

  compileRuleCheckSheetRowIdOrderings(sheetObj, sheetName) {
    let prevRowId = null;

    sheetObj.forEach((row) => {
      let rowId = row.ID.value;

      if(rowId) {
        if(rowId !== prevRowId + 1) {
          this.reportCompileError({
            type: `Wrong ID Order`,
            sheetName,
            sheetRow: row,
            expectedId: prevRowId + 1
          });
        }

        prevRowId = rowId;
      }
    });
  }

  compileRuleCheckSheetRowModbusAddrOrderings(sheetObj, sheetName) {
    let prevRow = null;

    sheetObj
      .filter((row) => !codeGenCommon.paramIsIgnoredByModbus(row))
      .forEach((row) => {
        let rowModbusAddr = row.ModbusAddr.value;
        let rowModbusAddrExpected = null;

        if(prevRow) {
          rowModbusAddrExpected =
            Number(prevRow.ModbusAddr.value)
            + codeGenCommon.getModbusParamTotalSize(this, prevRow);
        }

        if(rowModbusAddr) {
          if((rowModbusAddr !== rowModbusAddrExpected) && prevRow) {
            console.log(`prevRow`, prevRow);
            console.log(`row`, row);

            this.reportCompileError({
              type: `Wrong Modbus Addr Order`,
              sheetName,
              sheetRow: row,
              sheetRowFormer: prevRow,
              rowModbusAddrExpected,
            });
          }

          prevRow = row;
        }
      });
  }

  compileRuleCheckSheetRowAddrOrderings(sheetObj, sheetName) {
    let prevRow = null;

    sheetObj.forEach((row) => {
      let rowAddr = row.Addr.value;
      let rowAddrExpected = null;

      if(prevRow) {
        rowAddrExpected =
          Number(prevRow.Addr.value)
          + codeGenCommon.getModbusParamTotalSize(this, prevRow);
      }

      if(rowAddr) {
        if((rowAddr !== rowAddrExpected) && prevRow) {
          this.reportCompileError({
            type: `Wrong Addr Order`,
            sheetName,
            sheetRow: row,
            sheetRowFormer: prevRow,
            rowAddrExpected,
          });
        }

        prevRow = row;
      }
    });
  }

  compileRuleCheckAllStructsDependenciesExist() {
    this.structSheetNames.forEach((structSheetName) => {
      let missingStructDependencies = codeGenCommon.getAllMissingStructDependencies(this, structSheetName);

      missingStructDependencies.forEach((missingDependency) => {
        this.reportCompileError({
          type: `Struct Type Dependencies Not Found`,
          sheetName: structSheetName,
          missingDependency
        });
      });
    });
  }

  compileRuleCheckSheetObjectsContainsColumns(sheetObjs, columnNames) {
    let sheetNames = Object.keys(sheetObjs);

    sheetNames.forEach((sheetName) => {
      this.compileRuleCheckSheetContainsColumns(
        sheetObjs[sheetName],
        sheetName,
        columnNames
      )
    });
  }

  reportCompileError(error) {
    let message = ``;
    let prevLineLengthMax = 0;
    let {
      extraOptions={},
    } = error;

    let {
      fileName=null,
    } = extraOptions;

    if(!fileName) {
      fileName = this.fileName;
    }

    function appendMessageLine (messageLine) {
      message += message ? `\r\n` : ``;
      message += messageLine;

      if(prevLineLengthMax < messageLine.length) {
        prevLineLengthMax = messageLine.length;
      }
    }

    function appendMessageLineSeparator (lineWidth=null) {
      lineWidth = lineWidth ? lineWidth : prevLineLengthMax - 1;

      let messageLine = `♦` + `─`.repeat(lineWidth - 1) + `♦`;
      prevLineLengthMax = 0;
      
      message += message ? `\r\n` : ``;
      message += messageLine;
    }

    appendMessageLine(` `);
    appendMessageLine(`Error in "${fileName}"`);
    appendMessageLineSeparator();

    switch(error.type) {
      case `Sheet Not Found`: {
        appendMessageLine(`No "${error.sheetName}" Sheet" found`);
      }
      break

      case `Sheet Column Not Found`: {
        appendMessageLine(`Sheet "${error.sheetName}" is missing the following required columns:`);
        
        error.missingColumns.forEach((missingColumn) => {
          appendMessageLine(`  - ${missingColumn}`);
        });
        appendMessageLineSeparator();

        appendMessageLine(`Expected columns in this sheet:`);
        
        error.expectedColumns.forEach((expectedColumns) => {
          appendMessageLine(`  - ${expectedColumns}`);
        });
      }
      break;

      case `Sheet Row Not Found`: {
        appendMessageLine(`Sheet "${error.sheetName}" is missing a required row`);
        appendMessageLineSeparator();

        appendMessageLine(`Expected a row with the following property`);
        appendMessageLine(`"${error.colName}": "${error.cellValue}"`);
      }
      break;

      case `ParameterType Not Valid`: {
        let rowNum = codeGenCommon.getRowNumber(error.sheetRow.ParameterType);
        let cellValue = error.sheetRow.ParameterType.value;
        let cellAddr = error.sheetRow.ParameterType.cell;

        appendMessageLine(
          `Sheet "${error.sheetName}"`
          + ` Row "${rowNum}"`
        );
        appendMessageLineSeparator();
        
        appendMessageLine(
          `Invalid ParameterType "${cellValue}" at cell "${cellAddr}"`
        );
        appendMessageLineSeparator();
        
        appendMessageLine(`Allowed parameter types:`);
        for(let i = 0; i < this.ParameterTypeNames.length; i++) {
          appendMessageLine(`  - ${this.ParameterTypeNames[i]}`);
        }
      }
      break;

      case `DataType Not Valid`: {
        let dataType = error.sheetRow.DataType.value;
        let cellAddr = error.sheetRow.DataType.cell;
        let paramRow = error.sheetRow;
        let paramName = paramRow.Name.value;

        if(codeGenCommon.structTypeIsFromHeaderFiles(this, error.sheetName)) {
          let {
            fileName,
            filePath,
          } = this.findUserInputTypedefOriginHeaderFiles(error.sheetName)[0].headerFile;

          filePath = codeGenCommon.getHeaderFilePathFromRoot(filePath);
          
          appendMessageLine(`File "${filePath}"`);
          appendMessageLineSeparator();
          
          appendMessageLine(`Typedef struct "${error.sheetName}"`);
          appendMessageLineSeparator();

          appendMessageLine(`Field "${paramName}" has unknwon type "${dataType}"`);
        } else {
          let rowNum = codeGenCommon.getRowNumber(paramRow.DataType);

          appendMessageLine(
            `Sheet "${error.sheetName}"`
            + ` Row "${rowNum}"`
          );
          appendMessageLineSeparator();
          
          appendMessageLine(
            `Invalid DataType "${dataType}" at cell "${cellAddr}"`
          );
          appendMessageLineSeparator();
          
          appendMessageLine(`Allowed DataTypes:`);
          this.typedefSheetNames.forEach((dataType) => {
            appendMessageLine(`  - ${dataType}`);
          });
        }
      }
      break;

      case `ArraySize Not A Number`: {
        let rowNum = codeGenCommon.getRowNumber(error.sheetRow.ArraySize);
        let cellValue = error.sheetRow.ArraySize.value;
        let cellAddr = error.sheetRow.ArraySize.cell;

        appendMessageLine(
          `Sheet "${error.sheetName}"`
          + ` Row "${rowNum}"`
        );
        appendMessageLineSeparator();
        
        appendMessageLine(
          `Array size "${cellValue}" at cell "${cellAddr}" is not a number"`
        );
      }
      break;

      case `ArraySize Not A Positive Integer Number`: {
        let rowNum = codeGenCommon.getRowNumber(error.sheetRow.ArraySize);
        let cellValue = error.sheetRow.ArraySize.value;
        let cellAddr = error.sheetRow.ArraySize.cell;

        appendMessageLine(
          `Sheet "${error.sheetName}"`
          + ` Row "${rowNum}"`
        );
        appendMessageLineSeparator();
        
        appendMessageLine(
          `Array size "${cellValue}" at cell "${cellAddr}" is not a positive integer number"`
        );
      }
      break;

      case `Addr Not A Number`: {
        let rowNum = codeGenCommon.getRowNumber(error.sheetRow.Name);
        let cellValue = error.sheetRow.Addr.value;
        let cellAddr = error.sheetRow.Addr.cell;

        appendMessageLine(
          `Sheet "${error.sheetName}"`
          + ` Row "${rowNum}"`
        );
        appendMessageLineSeparator();
        
        appendMessageLine(
          `Addr "${cellValue}" at cell "${cellAddr}" is not a number"`
        );
      }
      break;

      case `ID Not A Number`: {
        let rowNum = codeGenCommon.getRowNumber(error.sheetRow.ID);
        let cellValue = error.sheetRow.ID.value;
        let cellAddr = error.sheetRow.ID.cell;

        appendMessageLine(
          `Sheet "${error.sheetName}"`
          + ` Row "${rowNum}"`
        );
        appendMessageLineSeparator();
        
        appendMessageLine(
          `ID "${cellValue}" at cell "${cellAddr}" is not a number"`
        );
      }
      break;

      case `Params Ignored By Modbus Dont Have Modbus Addr Constraint`: {
        let rowNum = codeGenCommon.getRowNumber(error.sheetRow.ModbusAddrConstraint);
        let cellAddr = error.sheetRow.ModbusAddrConstraint.cell;
        let paramDataType = error.sheetRow.DataType.value;

        appendMessageLine(
          `Sheet "${error.sheetName}"`
          + ` Row "${rowNum}"`
        );
        appendMessageLineSeparator();
        
        appendMessageLine(`"${paramDataType}" parameters have no modbus address`);
        appendMessageLine(`so they can't have "Modbus Addr Constraint"`);
      }
      break;

      case `WordSize Not A Number`: {
        let rowNum = codeGenCommon.getRowNumber(error.sheetRow.WordSize);
        let cellValue = error.sheetRow.WordSize.value;
        let cellAddr = error.sheetRow.WordSize.cell;

        appendMessageLine(
          `Sheet "${error.sheetName}"`
          + ` Row "${rowNum}"`
        );
        appendMessageLineSeparator();
        
        appendMessageLine(
          `WordSize "${cellValue}" at cell "${cellAddr}" is not a number"`
        );
      }
      break;

      case `Value Not A Number`: {
        let rowNum = codeGenCommon.getRowNumber(error.sheetRow.Value);
        let cellValue = error.sheetRow.Value.value;
        let cellAddr = error.sheetRow.Value.cell;

        appendMessageLine(
          `Sheet "${error.sheetName}"`
          + ` Row "${rowNum}"`
        );
        appendMessageLineSeparator();
        
        appendMessageLine(
          `Value "${cellValue}" at cell "${cellAddr}" is not a number"`
        );
      }
      break;

      case `WordSize Doesnt Match Its Type`: {
        let rowNum = codeGenCommon.getRowNumber(error.sheetRow.DataType);
        let dataTypeCellValue = error.sheetRow.DataType.value;
        let dataTypeCellAddr = error.sheetRow.DataType.cell;
        let wordSizeCellValue = error.sheetRow.WordSize.value;
        let wordSizeCellAddr = error.sheetRow.WordSize.cell;
        let varTypeSheetVarTypeSizeCellValue = error.structVarTypeSizeRow.Addr.value;
        let varTypeSheetVarTypeSizeCellAddr = error.structVarTypeSizeRow.Addr.cell;

        appendMessageLine(
          `Sheet "${error.sheetName}"`
          + ` Row "${rowNum}"`
        );
        appendMessageLineSeparator();
        
        appendMessageLine(
          `WordSize of non-primitive type "${dataTypeCellValue}" at cell "${dataTypeCellAddr}" does not match its VarTypeSize defined in sheet "${dataTypeCellValue}"`
        );
        appendMessageLineSeparator(50);
        appendMessageLine(
          `"VarTypeSize" in Sheet "${dataTypeCellValue}" Cell(${varTypeSheetVarTypeSizeCellAddr}) = "${varTypeSheetVarTypeSizeCellValue}"`
        );
        appendMessageLineSeparator(50);
        appendMessageLine(
          `"WorSize" of "DataType" "${dataTypeCellValue}" in Sheet "DataType" Row(${rowNum}) = "${wordSizeCellValue}"`
        );
      }
      break;

      case `Wrong ID Order`: {
        let rowNum = codeGenCommon.getRowNumber(error.sheetRow.ID);
        let cellValue = error.sheetRow.ID.value;
        let cellAddr = error.sheetRow.ID.cell;
        let expectedId = error.expectedId;

        appendMessageLine(
          `Sheet "${error.sheetName}"`
          + ` Row "${rowNum}"`
        );
        appendMessageLineSeparator();
        
        appendMessageLine(`ID ordering violated at cell "${cellAddr}"`);
        appendMessageLineSeparator();
        appendMessageLine(`Row ID = ${cellValue}, Expected row ID = "${expectedId}"`);
      }
      break;

      case `Struct Sheet Contain VarTypeSize Named Row`: {
        let {
          sheetName,
          sheetRow,
        } = error;
        
        let rowNum = codeGenCommon.getRowNumber(sheetRow.Name);
        
        appendMessageLine(
          `Sheet "${sheetName},"`
          + ` Row "${rowNum}"`
        );
        appendMessageLineSeparator();
        
        appendMessageLine(
          `"VarTypeSize" is a reserved keyword in this software and cannot be used as a property name`
        );
      }
      break;

      case `Wrong Modbus Addr Order`: {
        console.log(error);
        let rowNum = codeGenCommon.getRowNumber(error.sheetRow.ModbusAddr);
        let cellValue = error.sheetRow.ModbusAddr.value;
        let cellAddr = error.sheetRow.ModbusAddr.cell;

        appendMessageLine(
          `Sheet "${error.sheetName}"`
          + ` Row "${rowNum}"`
        );
        appendMessageLineSeparator();
        
        appendMessageLine(`Modbus Addr ordering violated at cell "${cellAddr}"`);
        appendMessageLineSeparator();
        appendMessageLine(`Modbus Addr = ${cellValue}`);
        appendMessageLine(`Expected row Modbus Addr = "${error.rowModbusAddrExpected}"`);
      }
      break;

      case `Wrong Addr Order`: {
        let rowNum = codeGenCommon.getRowNumber(error.sheetRow.Addr);
        let cellValue = error.sheetRow.Addr.value;
        let cellAddr = error.sheetRow.Addr.cell;

        appendMessageLine(
          `Sheet "${error.sheetName}"`
          + ` Row "${rowNum}"`
        );
        appendMessageLineSeparator();
        
        appendMessageLine(`Addr ordering violated at cell "${cellAddr}"`);
        appendMessageLineSeparator();
        appendMessageLine(`Addr = ${cellValue}`);
        appendMessageLine(`Expected row Addr = "${error.rowAddrExpected}"`);
      }
      break;

      case `Enumerator Name Is Not Valid C Identifier`: {
        let {
          sheetName,
          sheetRow,
        } = error;

        let rowName = error.sheetRow.Name.value;
        let rowNum = codeGenCommon.getRowNumber(sheetRow.Name);
        let rowNameIsEmpty = rowName.length === 0;

        appendMessageLine(
          `Sheet "${sheetName}"`
          + ` Row "${rowNum}"`
        );
        appendMessageLineSeparator();
        
        if(rowNameIsEmpty) {
          appendMessageLine(`Enumerator "Name" is empty`);
        } else {
          appendMessageLine(`Enumerator "${rowName}" is not a valid C Indentifier`);
        }
      }
      break;

      case `Modbus Addr Constraint Can't Be Met`: {
        let {
          type,
          sheetName,
          sheetSheetRow,
          sheetRow,
          paramModbusAddrConstraint,
          mbAddrConstraintDiff,
          modbusAddrCalced,
        } = error;

        let rowNum = codeGenCommon.getRowNumber(sheetRow.Name);

        appendMessageLine(
          `Sheet "${sheetName}",`
          + ` Row "${rowNum}"`
        );
        appendMessageLineSeparator();

        appendMessageLine(
          `"Modbus Addr Constraint" of "${paramModbusAddrConstraint}" cannot be met`
        );

        appendMessageLine(
          `Calculated "Modbus Addr" for this parameter is "${modbusAddrCalced}"`
        );

        appendMessageLine(
          `Only "Modbus Addr Constraint" values of "${modbusAddrCalced}" or greater are valid`
        );
      }
      break;
      
      case `Parameter Name Is Not Valid C Identifier`: {
        let rowNum = codeGenCommon.getRowNumber(error.sheetRow.Name);
        let cellValue = error.sheetRow.Name.value;
        let cellAddr = error.sheetRow.Name.cell;
        let nameIsEmpty = false;

        if(cellValue === null) {
          cellValue = ``;
        }

        cellValue = String(cellValue);
        
        if(cellValue.trim().length === 0) {
          nameIsEmpty = true;
        }

        appendMessageLine(
          `Sheet "${error.sheetName}"`
          + ` Row "${rowNum}"`
          + ` Cell "${cellAddr}"`
        );
        appendMessageLineSeparator();
        
        if(nameIsEmpty) {
          appendMessageLine(`Parameter "Name" is empty`);
        } else {
          appendMessageLine(`Parameter Name "${cellValue}" is not a valid C Indentifier`);
        }
      }
      break;
      
      case `Parameter Name Must Start With Capital Letter`: {
        let rowNum = codeGenCommon.getRowNumber(error.sheetRow.Name);
        let cellValue = error.sheetRow[error.columnName].value;
        let cellAddr = error.sheetRow[error.columnName].cell;
        let possibleCorrectName = cellValue[0].toUpperCase() + cellValue.slice(1)

        appendMessageLine(
          `Sheet "${error.sheetName}"`
          + ` Row "${rowNum}"`
          + ` Cell "${cellAddr}"`
        );
        appendMessageLineSeparator();
        
        appendMessageLine(`Parameter "${error.columnName}"s must start with capital letter`);
        appendMessageLineSeparator();
        appendMessageLine(`"${cellValue}" does not start with a capital letter !`);
        appendMessageLine(`Did u mean "${possibleCorrectName}" ?`);
      }
      break;

      case `Struct Type Dependencies Not Found`: {
        appendMessageLine(
          `Sheet "${error.sheetName}"`
        );
        appendMessageLineSeparator();

        appendMessageLine(`Struct "${error.sheetName}" depends on struct "${error.missingDependency}"`);
        appendMessageLine(`Struct "${error.missingDependency}" sheet is missing`);
      }
      break;

      case `Duplicate Type Found In Header Files`: {
        let {
          duplicateType,
          originHeaderFiles,
        } = error;

        appendMessageLine(`User-defined type "${duplicateType}" is defined multiple times in the following files 👇`);
        
        originHeaderFiles.forEach((file) => {
          let headerFilePath = codeGenCommon.getHeaderFilePathFromRoot(file.headerFile.filePath);
          
          appendMessageLine(`---`);
          appendMessageLine(`${headerFilePath}`);
        });
      }
      break;

      case `Type Defined Both In Excel & Header Files`: {
        let {
          excelFileName,
          userType,
          originHeaderFile,
        } = error;

        appendMessageLine(`User-defined type “${userType}” is defined in both the “Parameter List” Excel file and the user “Header Files” 👇`);
        
        let headerFilePath = originHeaderFile.headerFile.filePath;

        headerFilePath = headerFilePath.split(appConfig.defs.userInputsRootFolderName)[1];
        headerFilePath = appConfig.defs.userInputsRootFolderName + headerFilePath;
        
        appendMessageLine(`---`);
        appendMessageLine(`${headerFilePath}`);

        appendMessageLine(`---`);
        appendMessageLine(`${excelFileName}.xlsx`);
      }
      break;

      case `Dependency Loop Found In Struct Type`: {
        appendMessageLine(
          `Sheet "${error.structName}"`
        );
        appendMessageLineSeparator();
        
        appendMessageLine(`The following dependency loop found in struct type "structName" :`);
        appendMessageLine(``);

        [
          ...error.dependancyLoopMap,
          error.structName
        ].forEach((dependency, index) => {
          let preText = ``;

          if(index > 1) {
            preText += `   `.repeat(index - 1);
          }

          if(index > 0) {
            preText += `└─ `;
          }

          appendMessageLine(`${preText}${dependency}`);
        });
      }
      break;

      default: {
        console.error(`Unknown "error.type : ${error.type}"`);
      }
      break;
    }

    appendMessageLine(` `);

    toolBox.printErrorBanner(message);
    throw new Error(`Don't display this error`);
  }


  /** --- Static Excel loader --- */
  openExcelFile(filePath, trimKeysAndValues = true) {
    // let workbook = excel.openExcelWorkbook(filePath);
    let workbook = personalExcelApi.openExcelWorkbookWithCells(filePath, { trim: true });
    let fileName = filePath.match(/[^\\\/]+\.xlsx$/)[0].split('.xlsx')[0];
    workbook = toolBox.cleanKeysDeep(workbook);

    if (trimKeysAndValues) {
      Object.keys(workbook).forEach((key) => {
        workbook[key].forEach((row) => toolBox.trimObjectKeysAndValues(row));
      });
    }

    this.excel = { workbook, fileName };
    this.excelOriginal = toolBox.deepClone(this.excel);

    return this.excel;
  }
}
class CompiledExcelDeviceId extends CompiledExcel {
  /** @type {Array<Object>} */
  DeviceIdSheet = [];
  DeviceIdSheetFilteredEmptyRows = [];
  
  /** @type {number} */
  deviceIdsNameUpperSnakeCaseMaxLength
  
  /** @type {string} */
  outputsVersion = null;
  appVersion = null;

  /**
   * @param {string} excelFilePath
   * @param {Object} historyObj
   */
  constructor(
    excelFilePath,
    historyObj=null,
  ) {
    super();

    const excel = this.openExcelFile(excelFilePath);
    this.excelHash = personalHashApi.createHash(JSON.stringify(excel), true);

    if(appConfig.developer.forceGenereateNewVersions) {
      this.excelUpdated = true;
    }

    if(historyObj) {
      let outputFilesNeedUpdate = false;
      
      this.outputsVersion = historyObj.outputsVersion;

      if(historyObj.excelHash !== this.excelHash) {
        outputFilesNeedUpdate = true;
      }

      if(historyObj.appVersion !== appConfig.app.VERSION) {
        outputFilesNeedUpdate = true;
      }

      if(outputFilesNeedUpdate) {
        this.excelUpdated = true;

        if(!appConfig.developer.autoVersionIncrementDisabled) {
          this.outputsVersion = String(Number(historyObj.outputsVersion) + 1).padStart(5, '0');
        }
      }
    } else {
      this.excelUpdated = true;
      this.outputsVersion = String(0).padStart(5, '0');
    }

    this.fileName = excel.fileName;

    toolBox.printGenericBanner(this.fileName, {generateOutlines: true});
    
    this.DeviceIdSheet = excel.workbook.DeviceId;
    this.compileRuleCheckWorkbookContainsSheet(this.DeviceIdSheet, `DeviceId`);
    this.compileRuleCheckSheetContainsColumns(
      this.DeviceIdSheet,
      `DeviceId`,
      [`Group`, `Name`, `Device Id`, `Decription`]
    );
  
    this.eVirtualParameterIdSheet = excel.workbook.eVirtualParameterId;
    this.compileRuleCheckWorkbookContainsSheet(
      this.eVirtualParameterIdSheet,
      `eVirtualParameterId`,
      { fileName: `device_id.xlsx` }
    );
    this.compileRuleCheckSheetContainsColumns(
      this.eVirtualParameterIdSheet,
      `eVirtualParameterId`,
      [
        `Name`,
        `Value`,
        `Description`,
      ]
    );
    
    this.compileRuleCheckTytpedefSheetRowNamesAreValidCIdentifier(
      this.eVirtualParameterIdSheet,
      `eVirtualParameterId`,
      { fileName: `device_id.xlsx` }
    );

    this.#compile();
  }

  #compile () {
    this.#compileDeviceIdSheetFilteredEmptyRows();

    this.#compileParameterListAddNameUpperSnakeCases();
  }

  #compileDeviceIdSheetFilteredEmptyRows () {
    this.DeviceIdSheetFilteredEmptyRows = this.DeviceIdSheet
      .filter(row => row.Name.value !== null);
  }

  #compileParameterListAddNameUpperSnakeCases () {
    this.DeviceIdSheetFilteredEmptyRows.forEach((row) => {
      if(row.Name.value) {
        row.NameUpperSnakeCase = row.Name.value.toUpperCase();
      }
    });

    this.deviceIdsNameUpperSnakeCaseMaxLength = Math.max(
      ...(this.DeviceIdSheetFilteredEmptyRows.map((row) => row.NameUpperSnakeCase.length))
    );
  }
}

class CompiledUserHeaderFile  {
  /** @type {Object} */
  headerFile = null;
  headerFileOriginal = null;

  /** @type {Array<Object>} */
  extractTypedefs = [];
  extractedEnums = [];
  extractedStructs = [];
  extractedDefinedEnums = [];
  extractedFaraabinStructs = [];

  constructor(
    headerFilePath
  ) {
    this.openHeaderFile(headerFilePath);

    if(false) {
      console.warn(`-----------------------------------------`);
      console.log(`headerFile name`, this.headerFile.fileName);
    }

    toolBox.printGenericBanner(this.headerFile.fileName, {generateOutlines: true});

    this.#compile();
  }

  #compile () {
    this.#compileStructTypedefsExtraction();
  }

  #compileStructTypedefsExtraction () {
    this.extractedStructs = this.#extractStructs(this.headerFile.fileContentClean);
    if(false) { console.log(`extractedStructs`, this.extractedStructs); }

    this.extractedEnums = this.#extractEnums(this.headerFile.fileContentClean);
    if(false) { console.log(`extractedEnums`, this.extractedEnums); }

    this.extractedDefinedEnums = this.#extractDefinedEnums(this.headerFile.fileContentClean);
    if(false) { console.log(`extractedDefinedEnums`, this.extractedDefinedEnums); }

    this.extractedFaraabinStructs = this.#extractFaraabinStructs(this.headerFile.fileContentClean);
    if(false) { console.log(`extractedFaraabinStructs`, this.extractedFaraabinStructs); }

    this.extractTypedefs = [
      ...Object.keys(this.extractedStructs),
      ...Object.keys(this.extractedEnums),
      ...Object.keys(this.extractedDefinedEnums),
      ...Object.keys(this.extractedFaraabinStructs),
    ];

    if(false) { console.log(`extractTypedefs`, this.extractTypedefs); }
  }

  #extractStructs(content) {
    const structs = {};

    const structRegex =
      /typedef\s+struct\s*(?:\w+)?\s*\{([\s\S]*?)\}\s*(\w+)\s*;|struct\s+(\w+)\s*\{([\s\S]*?)\}\s*;/g;

    let match;

    while ((match = structRegex.exec(content)) !== null) {
      const body = match[1] || match[4];
      const structName = match[2] || match[3];

      const fields = [];

      const fieldRegex =
        /^\s*([\w\s\*]+?)\s+(\w+)(?:\[(\d+)\])?\s*;/gm;

      let fieldMatch;

      while ((fieldMatch = fieldRegex.exec(body)) !== null) {
        fields.push({
          type: fieldMatch[1].trim(),
          name: fieldMatch[2],
          arraySize: fieldMatch[3]
            ? parseInt(fieldMatch[3], 10)
            : 1
        });
      }

      structs[structName] = fields;
    }

    return structs;
  }

  #extractFaraabinStructs(content) {
    const structs = {};

    // Match the outer structure: typedef_struct_(Name) { body }typedef_struct_end_(Name);
    const structRegex = /typedef_struct_\((\w+)\)\s*\{([\s\S]*?)\}\s*typedef_struct_end_\(\1\)\s*;/g;

    let match;
    while ((match = structRegex.exec(content)) !== null) {
      const structName = match[1];
      const body = match[2];
      const fields = [];

      // Regex for single members: sm_(type, name);
      const smRegex = /sm_\(\s*(\w+)\s*,\s*(\w+)\s*\)\s*;/g;
      let smMatch;
      while ((smMatch = smRegex.exec(body)) !== null) {
        fields.push({
          type: smMatch[1],
          name: smMatch[2],
          arraySize: 1
        });
      }

      // Regex for array members: sma_(type, name, size);
      const smaRegex = /sma_\(\s*(\w+)\s*,\s*(\w+)\s*,\s*(\d+)\s*\)\s*;/g;
      let smaMatch;
      while ((smaMatch = smaRegex.exec(body)) !== null) {
        fields.push({
          type: smaMatch[1],
          name: smaMatch[2],
          arraySize: parseInt(smaMatch[3], 10)
        });
      }

      // Note: If the order of fields in the struct matters, 
      // we should use a single regex to parse both sm_ and sma_ in one pass.
      // Let's refine the field parsing to preserve order:
      
      const orderedFields = [];
      const fieldRegex = /(sm|sma)_\(([^)]+)\)\s*;/g;
      let fMatch;
      while ((fMatch = fieldRegex.exec(body)) !== null) {
        const macro = fMatch[1]; // 'sm' or 'sma'
        const args = fMatch[2].split(',').map(s => s.trim());
        
        if (macro === 'sm') {
          orderedFields.push({ type: args[0], name: args[1], arraySize: 1 });
        } else {
          orderedFields.push({ type: args[0], name: args[1], arraySize: parseInt(args[2], 10) });
        }
      }

      structs[structName] = orderedFields;
    }

    return structs;
  }


  #extractEnums(content) {
    const enums = {};

    const enumRegex = /typedef\s+enum(?:\s+\w+)?\s*\{([\s\S]*?)\}\s*(\w+)\s*;|enum\s+(\w+)\s*\{([\s\S]*?)\}\s*;/g;

    let match;

    while ((match = enumRegex.exec(content)) !== null) {
      const body = match[1] || match[4];
      const enumName = match[2] || match[3];

      const values = [];
      const entries = body
        .split(",")
        .map(e => e.trim())
        .filter(Boolean);

      let currentValue = 0;

      for (const entry of entries) {
        const parts = entry.split("=").map(p => p.trim());
        const name = parts[0];

        if (parts.length > 1) {
          const parsedValue = Number(parts[1]);
          if (!Number.isNaN(parsedValue)) {
            currentValue = parsedValue;
          }
        }

        values.push({
          name,
          value: currentValue
        });

        currentValue++;
      }

      enums[enumName] = values;
    }

    return enums;
  }

  #extractDefinedEnums(content) {
    const result = {};

    // Find typedef aliases
    const typedefRegex =
      /typedef\s+([\w\s\*]+)\s+(\w+)\s*;/g;

    let typedefMatch;

    while ((typedefMatch = typedefRegex.exec(content)) !== null) {
      const typedefName = typedefMatch[2];

      // Find matching defines using this typedef
      const defineRegex = new RegExp(
        `#define\\s+(\\w+)\\s+\\(\\(${typedefName}\\)([^\\)]+)\\)`,
        "g"
      );

      let defineMatch;
      const values = [];

      while ((defineMatch = defineRegex.exec(content)) !== null) {
        values.push({
          name: defineMatch[1],
          value: Number(defineMatch[2].trim())
        });
      }

      if (values.length > 0) {
        result[typedefName] = values;
      }
    }

    return result;
  }

  #removeBlockCommentsAndLineCommentsFromFileContent(content) {
    return content
      .replace(/\/\*[\s\S]*?\*\//g, "")
      .replace(/\/\/.*$/gm, "");
  }

  openHeaderFile(filePath) {
    let fileContent = personalFileApi.readFileAsString(filePath);
    let fileContentClean = this.#removeBlockCommentsAndLineCommentsFromFileContent(fileContent);
    let fileName = personalFileApi.extractFileNameFromFullPath(filePath);

    this.headerFile = {
      fileName,
      filePath,
      fileContent,
      fileContentClean
    };
    this.headerFileOriginal = toolBox.deepClone(this.headerFile);
  }
}

class CompiledExcelParamList extends CompiledExcel {
  /** @type {string} */
  excelHash = null;
  
  /** @type {boolean} */
  excelUpdated = false;

  /** @type {string} */
  outputsVersion = null;
  appVersion = null;

  /** @type {Array<Object>} */
  InfoSheet = [];

  /** @type {Array<Object>} */
  DefaultUnitSheet = [];

  /** @type {Array<Object>} */
  ParameterListSheet = [];
  
  /** @type {Array<Object>} */
  forgedDataTypeSheet = [];

  // /** @type {Array<Object>} */
  // DataListSheet = [];

  /** @type {Array<string>} */
  ParameterTypes = [
    `MONITORING`,
    `COMMAND`,
    `SETTING`,
  ];
  ParameterTypeNames = [
    `MONITORING (R)`,
    `COMMAND (W)`,
    `SETTING (R/W)`,
  ];
  
  /** @type {Object} */
  StructTypeSheets = {};
  
  /** @type {Object} */
  EnumTypeSheets = {};
  forgedEnumTypeSheets = {};
  
  /** @type {Array<Object>} */
  eForgedParameterIdSheet = [];
  eVirtualParameterIdSheet = null;
  
  /** @type {Array<Object>} */
  parsedParameterList = [];
  parsedParameterListFlat = [];
  parsedParameterListFlatFilteredReserves = [];
  
  /** @type {Array<Object>} */
  parameterListFilteredReserves = [];
  
  /** @type {Object.<string, number>} */
  dataTypeSizes = {};

  /** @type {Object} */
  paramListGroupedByGroup =  {};

  /** @type {Array<string>} */
  structSheetNames = [];
  enumSheetNames = [];
  typedefSheetNames = [];
  parsedTypedefs = {};
  headerFilesStructNames = [];
  headerFilesEnumNames = [];
  headerFilesTypedefNames = [];
  groupNames = [];

  /** @type {Object} */
  enumSheetProperties = {};
  
  /** @type {number} */
  parameterListNameUpperSnakeCaseMaxLength = 0;
  parameterIdNameUpperSnakeCaseMaxLength = 0;
  parsedParameterListFlatNameUpperSnakeCaseMaxLength = 0;
  infoNameUpperSnakeCaseMaxLength = 0;

  /** @type {Array<CompiledUserHeaderFile>} */
  compiledUserHeaderFiles = [];
  
  /** @type {number} */
  parameterTypesMaxLength = Math.max(
    ...this.ParameterTypes.map((parameterType) => parameterType.length)
  );

  /**
   * @param {string} excelFilePath
   * @param {Object} historyObj
   * @param {CompiledExcelDeviceId} compiledExcelDeviceId
   * @param {Array<CompiledUserHeaderFile>} compiledUserHeaderFiles
   */
  constructor(
    excelFilePath,
    historyObj=null,
    compiledExcelDeviceId=null,
    compiledUserHeaderFiles=[]
  ) {
    super();

    const excel = this.openExcelFile(excelFilePath);
    this.excelHash = personalHashApi.createHash(JSON.stringify(excel), true);

    if(appConfig.developer.forceGenereateNewVersions) {
      this.excelUpdated = true;
    }

    if(historyObj) {
      let outputFilesNeedUpdate = false;
      
      this.outputsVersion = historyObj.outputsVersion;

      if(historyObj.excelHash !== this.excelHash) {
        outputFilesNeedUpdate = true;
      }

      if(historyObj.appVersion !== appConfig.app.VERSION) {
        outputFilesNeedUpdate = true;
      }

      if(compiledExcelDeviceId.excelUpdated) {
        outputFilesNeedUpdate = true;
      }

      if(outputFilesNeedUpdate) {
        this.excelUpdated = true;

        if(!appConfig.developer.autoVersionIncrementDisabled) {
          this.outputsVersion = String(Number(historyObj.outputsVersion) + 1).padStart(5, '0');
        }
      }
    } else {
      this.excelUpdated = true;
      this.outputsVersion = String(0).padStart(5, '0');
    }

    this.fileName = excel.fileName;

    toolBox.printGenericBanner(this.fileName, {generateOutlines: true});
    
    this.InfoSheet = excel.workbook.Info;
    this.compileRuleCheckWorkbookContainsSheet(this.InfoSheet, `Info`);
    this.compileRuleCheckSheetContainsColumns(
      this.InfoSheet,
      `Info`,
      [`Name`, `Value`, `Decription`]
    );
    
    this.ParameterListSheet = excel.workbook.ParameterList;
    this.compileRuleCheckWorkbookContainsSheet(this.ParameterListSheet, `ParameterList`);
    this.compileRuleCheckSheetContainsColumns(
      this.ParameterListSheet,
      `ParameterList`,
      [
        `Group`,
        `Name`,
        `Parameter Type`,
        `Tag1`,
        `Tag2`,
        `Tag3`,
        `Tag4`,
        `Tag5`,
        `Data Type`,
        `Array Size`,
        `Default Value`,
        `Modbus Addr Constraint`,
        `Description`
      ]
    );
    this.compileRuleCheckSheetContainsRows(
      this.ParameterListSheet,
      `ParameterList`,
      [
        {colName: `Name`, cellValue: `DeviceId`},
      ]
    );
    this.compileConvertNumberColumnsToNumbers(
      this.ParameterListSheet,
      [
        `Array Size`,
        `Modbus Addr Constraint`,
      ]
    );
    
    this.compileRuleCheckColumnValuesAreValidCIdentifier(
      this.ParameterListSheet,
      `ParameterList`,
      `Name`
    );
    
    this.compileRuleCheckColumnValuesStartWithCapitalLetter(
      this.ParameterListSheet,
      `ParameterList`,
      `Name`
    );

    if(false) {
      window.ParameterListSheetUnwrapped = codeGenCommon.unwrapCellValues(this.ParameterListSheet);
      console.log(`window.ParameterListSheet 👇👇👇`);
      console.table(window.ParameterListSheetUnwrapped);
    }

    if(false) {
      this.eVirtualParameterIdSheet = compiledExcelDeviceId.excel.workbook.eVirtualParameterId;
      this.compileRuleCheckWorkbookContainsSheet(
        this.eVirtualParameterIdSheet,
        `eVirtualParameterId`,
        { fileName: `device_id.xlsx` }
      );
      this.compileRuleCheckSheetContainsColumns(
        this.eVirtualParameterIdSheet,
        `eVirtualParameterId`,
        [
          `Name`,
          `Value`,
          `Description`,
        ]
      );
      
      this.compileRuleCheckTytpedefSheetRowNamesAreValidCIdentifier(
        this.eVirtualParameterIdSheet,
        `eVirtualParameterId`,
        { fileName: `device_id.xlsx` }
      );
    } else {
      this.eVirtualParameterIdSheet = compiledExcelDeviceId.eVirtualParameterIdSheet;
    }

    this.StructTypeSheets = toolBox.filterObjectByRegexNonMutating(excel.workbook, /^s/);
    this.EnumTypeSheets = toolBox.filterObjectByRegexNonMutating(excel.workbook, /^[e][A-Z]/);

    if(false) {
      this.compileRuleCheckWorkbookContainsSheet(this.StructTypeSheets.sDownStreamStatistics, `sDownStreamStatistics`);
      this.compileRuleCheckWorkbookContainsSheet(this.StructTypeSheets.sDownStreamSetting, `sDownStreamSetting`);
    }

    Object.keys(this.StructTypeSheets).forEach((sheetName) => {
      let sheet = this.StructTypeSheets[sheetName];
      
      this.compileRuleCheckSheetContainsColumns(
        sheet,
        sheetName,
        [`Name `, `Data Type`, `Array Size`, `Default Value`, `Description`]
      );

      this.compileRuleCheckColumnValuesAreValidCIdentifier(
        sheet,
        sheetName,
        `Name`
      );
      
      this.compileRuleCheckColumnValuesStartWithCapitalLetter(
        sheet,
        sheetName,
        `Name`
      );
      
      this.compileConvertNumberColumnsToNumbers(
        sheet,
        [
          `Array Size`,
        ]
      );
    });

    Object.keys(this.EnumTypeSheets).forEach((sheetName) => {
      let sheet = this.EnumTypeSheets[sheetName];
      
      this.compileRuleCheckSheetContainsColumns(
        sheet,
        sheetName,
        [`Name `, `Value`, `Description`]
      );

      this.compileRuleCheckColumnValuesAreValidCIdentifier(
        sheet,
        sheetName,
        `Name`
      );
    });

    if(compiledUserHeaderFiles.length !== 0) {
      this.compiledUserHeaderFiles = compiledUserHeaderFiles;
      this.#compileRuleCheckNoDuplicateTypedefsInHeaders();
      this.#compileRuleCheckNoDuplicateTypedefsInExcelsAndHeaders();
    }
    
    this.#compile();
  }

  #compileParameterListAddNameUpperSnakeCases () {
    this.ParameterListSheet.forEach((param) => {
      if(param.Name.value) {
        param.NameUpperSnakeCase = toolBox.camelToUpperSnake(param.Name.value);
      }
    });

    this.parameterListNameUpperSnakeCaseMaxLength = Math.max(
      ...(this.ParameterListSheet.map((param) => param.NameUpperSnakeCase.length))
    );
  }

  #compileDataListAddNameUpperSnakeCases () {
    if(false) {
      this.DataListSheet.forEach((dataListItem) => {
        if(dataListItem.ParameterType.value) {
          dataListItem.ParameterTypeNameUpperSnakeCase = toolBox.camelToUpperSnake(dataListItem.ParameterType.value);
          
          let match = dataListItem.ParameterTypeNameUpperSnakeCase.match(/^([^(]+)/);
          dataListItem.ParameterTypeNameUpperSnakeCase =
            match ? match[1].slice(0, -1) : dataListItem.ParameterTypeNameUpperSnakeCase;
        }
      });

      console.log(this.DataListSheet);

      this.parameterTypesMaxLength = Math.max(
        ...(this.DataListSheet.map((parameterId) => {
          if(!parameterId.ParameterTypeNameUpperSnakeCase) {
            return 0;
          }

          return parameterId.ParameterTypeNameUpperSnakeCase.length
        }))
      );
    }
  }

  #compileParameterListFilteredReserves () {
    this.parameterListFilteredReserves = this.ParameterListSheet
      .filter((param) => param.ParameterType.value);
  }

  #compileParameterListFilteredEmptyRows () {
    if(false) {
      this.parameterListFilteredEmptyRows = this.ParameterListSheet
        .filter((param) => {
          if(param.Name.value == null) {
            return false;
          }

          if(isNaN(parseInt(param.ID.value))) {
            return false;
          }

          return true;
        });
    } else {
      this.parameterListFilteredEmptyRows = this.ParameterListSheet
        .filter((param) => {
          if(param.DataType.value === null) {
            return false;
          }

          if(codeGenCommon.parameterListRowIsReserved(param)) {
            return false;
          }

          return true;
        });
    }
  }

  #compileForgedEnumTypeSheetParameterMbAddr () {
    this.forgedEnumTypeSheets.eParameterMbAddr = [];
    
    this.parsedParameterListFlat
      .filter((row) => !codeGenCommon.paramIsIgnoredByModbus(row))
      .forEach((flatParam) => {
        if(false) {
          if(codeGenCommon.parameterListRowIsReserved(flatParam)) {
            return;
          }
        }

        for (let i = 0; i < flatParam.WordSize.value; i++) {
          let prefix = `PARAMETER_MB_ADDR_`;

          let memberName = ``;
          memberName += flatParam.NameUpperSnakeCase;
          memberName += flatParam.WordSize.value > 1 ? `_${i}` : ``;

          memberName = prefix + memberName;

          this.forgedEnumTypeSheets.eParameterMbAddr.push({
            Name: { value: memberName },
            Value: { value: flatParam.ModbusAddr.value + i },
            Description: { value: `` },
          });
        }
      });
  }

  #compileInfoSheetAddNameUpperSnakeCases () {
    this.InfoSheet.forEach((row) => {
      if(row.Name.value) {
        row.NameUpperSnakeCase = toolBox.camelToUpperSnake(row.Name.value);
      }
    });

    this.infoNameUpperSnakeCaseMaxLength = Math.max(
      ...(this.InfoSheet.map((row) => row.NameUpperSnakeCase.length))
    );
  }

  #compileParamListGroupedByGroup () {
    for(let i = 0; i < this.parameterListFilteredReserves.length; i++) {
      let param = this.parameterListFilteredReserves[i];
      
      let paramGroupName = param.Group.value;
      let parameterTypeName = codeGenCommon.getModbusParameterListParameterTypeName(param);

      if(paramGroupName) {
        if(!this.paramListGroupedByGroup.hasOwnProperty(paramGroupName)) {
          this.paramListGroupedByGroup[paramGroupName] = {};
        }
        
        if(!this.paramListGroupedByGroup[paramGroupName].hasOwnProperty(parameterTypeName)) {
          this.paramListGroupedByGroup[paramGroupName][parameterTypeName] = [];
        }
        this.paramListGroupedByGroup[paramGroupName][parameterTypeName].push(param);
      }
    }
  }

  findUserInputTypedefOriginHeaderFiles (typedefName) {
    return this.compiledUserHeaderFiles.filter((headerFile) => {
      return headerFile.extractTypedefs.includes(typedefName);
    });
  }

  #compileRuleCheckNoDuplicateTypedefsInHeaders () {
    let typedefNames = [];

    this.compiledUserHeaderFiles.forEach((headerFile) => {
      typedefNames.push(...headerFile.extractTypedefs);
    });

    let duplicates = toolBox.findDuplicates(typedefNames)

    duplicates.forEach((duplicateType) => {
      let originHeaderFiles = this.findUserInputTypedefOriginHeaderFiles(duplicateType);

      this.reportCompileError({
        type: `Duplicate Type Found In Header Files`,
        duplicateType,
        originHeaderFiles,
      });
    });
  }

  #compileRuleCheckNoDuplicateTypedefsInExcelsAndHeaders () {
    let typedefNames = [];

    this.compiledUserHeaderFiles.forEach((headerFile) => {
      typedefNames.push(...headerFile.extractTypedefs);
    });

    [
      ...Object.keys(this.StructTypeSheets),
      ...Object.keys(this.EnumTypeSheets),
    ].forEach((excelType) => {
      if(typedefNames.includes(excelType)) {
        let originHeaderFile = this.findUserInputTypedefOriginHeaderFiles(excelType)[0];

        this.reportCompileError({
          type: `Type Defined Both In Excel & Header Files`,
          excelFileName: this.fileName,
          userType: excelType,
          originHeaderFile,
        });
      }
    })
  }

  #compileForgedTypedefSheetsFromHeaderFiles () {
    function forgeAndAddStructSheet (
      compiledUserHeaderFile,
      extractedStructName,
      extractedStruct
    ) {
      let forgedStructSheet = extractedStruct.map((field) => {
        return {
          Name: { value: field.name, cell: null},
          DataType: { value: codeGenCommon.cDataTypeToExcel(field.type), cell: null},
          ArraySize: { value: field.arraySize, cell: null},
          DefaultValue: { value: 0, cell: null},
          Description: { value: null, cell: null},
        }
      });

      compiledUserHeaderFile.forgedStructSheets[extractedStructName]
        = toolBox.deepClone(forgedStructSheet);
    }

    function forgeAndAddEnumSheet (
      compiledUserHeaderFile,
      extractedEnumName,
      extractedEnum
    ) {
      let forgedEnumSheet = extractedEnum.map((field) => {
        return {
          Name: { value: field.name, cell: null},
          Value: { value: field.value, cell: null},
          Description: { value: null, cell: null},
        }
      });

      compiledUserHeaderFile.forgedEnumSheets[extractedEnumName]
        = toolBox.deepClone(forgedEnumSheet);
    }

    this.compiledUserHeaderFiles.forEach((compiledUserHeaderFile) => {
      compiledUserHeaderFile.forgedStructSheets = {};
      compiledUserHeaderFile.forgedEnumSheets = {};

      Object.keys(compiledUserHeaderFile.extractedStructs).forEach((extractedStructName) => {
        let extractedStruct = compiledUserHeaderFile.extractedStructs[extractedStructName];

        forgeAndAddStructSheet(
          compiledUserHeaderFile,
          extractedStructName,
          extractedStruct,
        );
      });

      Object.keys(compiledUserHeaderFile.extractedFaraabinStructs).forEach((extractedFaraabinStructName) => {
        let extractedFaraabinStruct = compiledUserHeaderFile.extractedFaraabinStructs[extractedFaraabinStructName];

        forgeAndAddStructSheet(
          compiledUserHeaderFile,
          extractedFaraabinStructName,
          extractedFaraabinStruct,
        );
      });

      Object.keys(compiledUserHeaderFile.extractedEnums).forEach((extractedEnumName) => {
        let extractedEnum = compiledUserHeaderFile.extractedEnums[extractedEnumName];

        forgeAndAddEnumSheet(
          compiledUserHeaderFile,
          extractedEnumName,
          extractedEnum,
        );
      });

      Object.keys(compiledUserHeaderFile.extractedDefinedEnums).forEach((extractedFaraabinEnumName) => {
        let extractedFaraabinEnum = compiledUserHeaderFile.extractedDefinedEnums[extractedFaraabinEnumName];

        forgeAndAddEnumSheet(
          compiledUserHeaderFile,
          extractedFaraabinEnumName,
          extractedFaraabinEnum,
        );
      });

      this.headerFilesStructNames.push(...Object.keys(compiledUserHeaderFile.forgedStructSheets));
      this.headerFilesEnumNames.push(...Object.keys(compiledUserHeaderFile.forgedEnumSheets));
      this.headerFilesTypedefNames.push(
        ...Object.keys(compiledUserHeaderFile.forgedStructSheets),
        ...Object.keys(compiledUserHeaderFile.forgedEnumSheets)
      );
    });
  }

  #addForgedTypedefSheetsFromHeaderFilesToExcelSheets () {
    this.compiledUserHeaderFiles.forEach((compiledUserHeaderFile) => {
      compiledUserHeaderFile.forgedStructSheets
      compiledUserHeaderFile.forgedEnumSheets

      Object.assign(
        this.StructTypeSheets,
        compiledUserHeaderFile.forgedStructSheets
      );

      Object.assign(
        this.EnumTypeSheets,
        compiledUserHeaderFile.forgedEnumSheets
      );
    });
  }

  #compileTypedefSheetNames () {
    this.structSheetNames = Object.keys(this.StructTypeSheets);
    this.enumSheetNames = Object.keys(this.EnumTypeSheets);

    this.enumSheetNames.push(`eParameterId`);

    this.typedefSheetNames = [
      ...codeGenCommon.getExcelPrimitiveTypes(),
      ...this.enumSheetNames,
      ...this.structSheetNames,
    ];

    this.compileRuleCheckSheetObjectsContainsColumns(
      this.StructTypeSheets,
      [`Name`, `Data Type`, `Array Size`, `Default Value`, `Description`]
    );
  
    this.compileRuleCheckSheetObjectsContainsColumns(
      this.EnumTypeSheets,
      [`Name`, `Value`, `Description`]
    );

    this.compileRuleCheckAllStructsDependenciesExist();

    if(false) {
      this.structSheetNames.forEach((sheetName) => {
        console.log(
          sheetName,
          codeGenCommon.getTypeDependancyListDeep(this, sheetName),
          codeGenCommon.typeAIsDependentOnTypeB(this, sheetName, `test_header_file_1_tTestStruct1`)
        );
      });
    }

    if(true) {
      function topologicalSort(types, isDependent) {
        const sorted = [];
        const visited = new Set();

        function visit(type) {
          if (visited.has(type)) {
            return;
          }

          visited.add(type);

          for (const otherType of types) {
            if ((type !== otherType) && isDependent(type, otherType)) {
              visit(otherType);
            }
          }

          sorted.push(type);
        }

        for (const type of types) {
          visit(type);
        }

        return sorted;
      }

      this.structSheetNames = topologicalSort(
        this.structSheetNames,
        (a, b) => codeGenCommon.typeAIsDependentOnTypeB(this, a, b)
      );
    } else {
      this.structSheetNames.sort((type1, type2) => {
        let result = 0;

        if(codeGenCommon.typeAIsDependentOnTypeB(this, type1, type2)) { result =  1; }
        if(codeGenCommon.typeAIsDependentOnTypeB(this, type2, type1)) { result = -1; }

        if(true) {
          if(result === 1) {
            console.log(`☀️☀️☀️☀️ ${type1} is dependent on ${type2}`);
          } else if(result === -1) {
            console.log(`☀️☀️☀️☀️ ${type2} is dependent on ${type1}`);
          } else {
            if((type1 === `sDownStreamSetting`) || (type2 === `sDownStreamSetting`)) {
              console.log(`🌚🌚🌚🌚 ${type2} is not dependent on ${type1}`);
            }
          }
        }

        return result;
      });
    }

    this.enumSheetNames.forEach((enumSheetName) => {
      if(enumSheetName === `eParameterId`) {
        return;
      }

      let enumSheet = this.EnumTypeSheets[enumSheetName];
      let enumMaxValue = codeGenCommon.getEnumSheetMaxValue(enumSheet);
      let memberQty = codeGenCommon.getEnumSheetMemberQty(enumSheet);

      this.enumSheetProperties[enumSheetName] = {
        enumMaxValue,
        memberQty
      }
    });
  }

  #compileParameterModbussAddresses () {
    let prevRow = null;
    let forgedReservedParameterRows = [];
    let reserveRowCount = 0;

    this.ParameterListSheet.forEach((row, index) => {
      if(codeGenCommon.paramIsIgnoredByModbus(row)) {
        row.ModbusAddr = { value: null };
        return;
      }

      let modbusAddrCalced = 0;
      let paramModbusAddrConstraint = row.ModbusAddrConstraint.value;

      if(prevRow) {
        modbusAddrCalced =
          Number(prevRow.ModbusAddr.value)
          + codeGenCommon.getModbusParamTotalSize(this, prevRow);
      }

      if(!isNaN(paramModbusAddrConstraint) && (paramModbusAddrConstraint !== null)) {
        let mbAddrConstraintDiff = paramModbusAddrConstraint - modbusAddrCalced;

        if(mbAddrConstraintDiff < 0) {
          this.reportCompileError({
            type: `Modbus Addr Constraint Can't Be Met`,
            sheetName: `ParameterList`,
            sheetSheetRow: prevRow,
            sheetRow: row,
            paramModbusAddrConstraint,
            mbAddrConstraintDiff,
            modbusAddrCalced,

          });
        } else if(mbAddrConstraintDiff > 0) {
          if(false) {
            if(isNaN(modbusAddrCalced) ) {
              console.log(`🔽🔽🔽🔽🔽🔽🔽🔽🔽🔽🔽🔽🔽🔽🔽🔽🔽🔽🔽`);

              console.log(`prevRow.DataType.value`, prevRow.DataType.value);
              console.log(`this.dataTypeSizes`, this.dataTypeSizes);
              console.log(`this.dataTypeSizes[prevRow.DataType.value]`, this.dataTypeSizes[prevRow.DataType.value]);

              console.log(`-----------------------------------------------`);
              console.log(`prevRow`, prevRow);
              console.log(`codeGenCommon.getModbusParamTotalSize(this, prevRow)`, codeGenCommon.getModbusParamTotalSize(this, prevRow));
              console.log(`Number(prevRow.ModbusAddr.value)`, Number(prevRow.ModbusAddr.value));
              console.log(`modbusAddrCalced`, modbusAddrCalced);
              console.log(`paramModbusAddrConstraint`, paramModbusAddrConstraint);

              console.log(`🔼🔼🔼🔼🔼🔼🔼🔼🔼🔼🔼🔼🔼🔼🔼🔼🔼🔼🔼`);
            }
          }
          
          let forgedReservedParameterRow = codeGenCommon.createParamRowCopy(row, true);

          forgedReservedParameterRow.Name.value = `___________CodeGen_ForgedVar_Reserve${reserveRowCount}`;
          forgedReservedParameterRow.ArraySize.value = mbAddrConstraintDiff;
          forgedReservedParameterRow.DataType.value = `U16`;
          forgedReservedParameterRow.DefaultValue.value = 0;
          forgedReservedParameterRow.ModbusAddr = { value: modbusAddrCalced };
          forgedReservedParameterRow.ParameterType = { value: `MONITORING` };

          forgedReservedParameterRows.push({ rowObj: forgedReservedParameterRow, reserveRowNum: index });
          reserveRowCount++;

          modbusAddrCalced = paramModbusAddrConstraint;
        }
      }

      row.ModbusAddr = { value: modbusAddrCalced };

      prevRow = row;
    });

    forgedReservedParameterRows.forEach((row, index) => {
      this.ParameterListSheet.splice(
        row.reserveRowNum + index,
        0,
        row.rowObj
      );
    });
  }

  #compileParameterIds () {
    let currentId = 0;

    this.ParameterListSheet.forEach((row) => {
      if(codeGenCommon.parameterListRowIsReserved(row)) {
        row.ID = { value: null };
      } else if(codeGenCommon.paramIsIgnoredByModbus(row)) {
        row.ID = { value: null };
      } else {
        row.ID = { value: currentId };
        currentId++;
      }
    });
  }

  #compileForgeParameterIdSheet () {
    this.parsedParameterListFlatFilteredReserves
      .filter((row) => !codeGenCommon.paramIsIgnoredByModbus(row))
      .forEach((flatParam, index) => {
        this.eForgedParameterIdSheet.push({
          Name:               { value: flatParam.NameUpperSnakeCase, cell: null },
          Value:              { value: index,                        cell: null },
          Type:               { value: flatParam.DataType.value,     cell: null },
          Size:               { value: flatParam.WordSize.value,     cell: null },
          Description:        { value: null,                         cell: null },

          NameUpperSnakeCase: flatParam.NameUpperSnakeCase,
        });
      });

    this.eVirtualParameterIdSheet.forEach((row) => {
      row.isVirtualParameterId = true;

      if(row.Name.value) {
        row.NameUpperSnakeCase = toolBox.camelToUpperSnake(row.Name.value);
      }
    })

    this.eForgedParameterIdSheet.push(...this.eVirtualParameterIdSheet);

    this.parameterIdNameUpperSnakeCaseMaxLength = Math.max(
      ...(this.eForgedParameterIdSheet.map((parameterId) => parameterId.NameUpperSnakeCase.length))
    );

    this.forgedEnumTypeSheets.eParameterId = this.eForgedParameterIdSheet;
  }

  #compileForgeDataTypeSheet () {
    codeGenCommon.getExcelPrimitiveTypes().forEach((primitiveType) => {
      this.forgedDataTypeSheet.push({
        DataType: {value: primitiveType},
        WordSize: {value: codeGenCommon.getPrimitiveTypeWordSize(primitiveType)}
      });

      this.dataTypeSizes[primitiveType] = codeGenCommon.getPrimitiveTypeWordSize(primitiveType);
    });

    this.enumSheetNames.forEach((enumTypeName) => {
      this.forgedDataTypeSheet.push({
        DataType: {value: enumTypeName},
        WordSize: {value: 1}
      });

      this.dataTypeSizes[enumTypeName] = 1;
    });

    const calcAndAddStructSheetAddrColumn = (structTypeName) => {
      let sheetObj = this.StructTypeSheets[structTypeName];
      let prevRow = null;

      sheetObj.push({
        Name: { value: `VarTypeSize` },
        DataType: { value: null },
        ArraySize: { value: null },
        DefaultValue: { value: null },
        Description: { value: null },
      });

      sheetObj.forEach((row) => {
        let rowAddrCalced = 0;

        if(prevRow) {
          rowAddrCalced =
            Number(prevRow.Addr.value)
            + codeGenCommon.getModbusParamTotalSize(this, prevRow);
        }

        row.Addr = { value: rowAddrCalced };

        prevRow = row;
      });
    }
    

    const addStructTypeSizeToDataTypeSizes = (structTypeName) => {
      this.dataTypeSizes[structTypeName] =
        codeGenCommon.extractStructTypeSheetVarTypeSize(this, structTypeName);
    }

    const addStructTypeForgedDataTypeSheet = (structTypeName) => {
      this.forgedDataTypeSheet.push({
        DataType: {value: structTypeName},
        WordSize: {value: codeGenCommon.extractStructTypeSheetVarTypeSize(this, structTypeName)}
      });
    }

    this.structSheetNames.forEach((sheetName) => {
      /* Add `Addr Column` To `Struct Sheet` *********************************/
      calcAndAddStructSheetAddrColumn(sheetName);

      /* Add `Struct Type Size` To `dataTypeSizes` *********************************/
      addStructTypeSizeToDataTypeSizes(sheetName);
      
      /* Add `Struct Type` To `forgedDataTypeSheet` End   ↑ *********************************/
      addStructTypeForgedDataTypeSheet(sheetName);
    });

    if(false) {
      window.forgedDataTypeSheet1 = codeGenCommon.unwrapCellValues(this.forgedDataTypeSheet);
      console.log(`window.forgedDataTypeSheet 👇👇👇`);
      console.log(window.forgedDataTypeSheet1);
    
      console.log(`this.StructTypeSheets 👇👇👇`);
      console.log(this.StructTypeSheets);

      console.log(`this.dataTypeSizes 👇👇👇`);
      console.log(this.dataTypeSizes);
    }
  }

  #compileExtractAllGroupNames() {
    let groupNamesSet = new Set();

    this.ParameterListSheet.forEach((row) => {
      groupNamesSet.add(row.Group.value)
    });

    this.groupNames = [...groupNamesSet];
  }

  #compileAddWordSizeToParameterList () {
    this.ParameterListSheet.forEach((param) => {
      param.dataTypeWordSize = this.dataTypeSizes[param.DataType.value];
      param.WordSize = {value: param.dataTypeWordSize * param.ArraySize.value};
    });
  }

  #compileParameterListParseTypes () {
    const resolveType = (dataType) => {
      let result;

      if (!dataType) return null;

      // Primitive type
      if (!this.StructTypeSheets[dataType]) {
        result = {
          DataType: dataType,
          dataTypeWordSize: this.dataTypeSizes[dataType],
          ModbusAddr: 0, // Always start at 0 relative to parent
        };
      } else {
        // Complex type
        result = this.StructTypeSheets[dataType]
          .filter((row) => !codeGenCommon.structSheetRowIsVarTypeSize(row))
          .map(field => {
          return {
            Name: field.Name.value,
            DataType: field.DataType.value,
            ArraySize: field.ArraySize.value,
            // ModbusAddr: Number(field.ModbusAddr.value) || 0, // relative to structure start
            ModbusAddr: Number(field.Addr.value), // relative to structure start
            dataTypeWordSize: this.dataTypeSizes[field.DataType.value],
            Description: field.Description.value || "",
            Structure: this.StructTypeSheets[field.DataType.value] ?
              resolveType(field.DataType.value) : null,
          };
        });
      }

      return result;
    }
    
    this.ParameterListSheet.forEach((param) => {
      param.ArraySize.value = Number(param.ArraySize.value) || 1;
      param.ModbusAddr.value = Number(param.ModbusAddr.value) || 0;
      param.Description.value = param.Description.value || '';
      param.ParameterType.value = param.ParameterType.value || null;

      if(param.ID.value === 0) {
        param.ID.value = Number(param.ID.value);
      } else {
        param.ID.value = Number(param.ID.value) || null;
      }

      param.Structure = resolveType(param.DataType.value);
    });
  }

  #compileParsedTypedefs () {
    let EnumTypeSheets = this.EnumTypeSheets;
    let dataTypeSizes = this.dataTypeSizes;

    function parseDataType (dataField) {
      let result = {};

      result.WordSize = {
        value: parseInt(dataTypeSizes[dataField.DataType.value])
      };

      result.dataTypeIsStruct = codeGenCommon.dataTypeIsStruct(dataField.DataType.value);
      result.dataTypeIsEnum = codeGenCommon.dataTypeIsEnum(dataField.DataType.value);

      result.DataType = dataField.DataType.value;
      
      result.DefaultValue = {
        value: codeGenCommon.getParameterDefaultValue(dataField) || 0,
      };

      if(dataField.ArraySize && !isNaN(dataField.ArraySize.value)) {
        result.ArraySize = dataField.ArraySize;
      } else {
        result.ArraySize = {value: 1};
      }
      result.WordSize.value *= result.ArraySize.value;

      if(result.dataTypeIsEnum) {
        result.enumerators = [];
        EnumTypeSheets[dataField.DataType.value].forEach((enumerator) => {
          if(enumerator.Value.value !== null) {
            result.enumerators.push(
              {
                enumeratorName: enumerator.Name,
                enumeratorValue: enumerator.Value,
              }
            );
          }
        });
      } else if(result.dataTypeIsStruct) {
        result.fields = [];
        StructTypeSheets[dataField.DataType.value].forEach((field) => {
          if(field.DataType !== null) {
            result.fields.push(
              {
                fieldName: field.Name,
                fieldObj: parseDataType(field),
              }
            );
          }
        });
      }

      return result;
    }

    this.forgedDataTypeSheet.forEach((row) => {
      if(row.DataType.value) {
        return;
      }

      this.parsedTypedefs[row.DataType.value] = parseDataType(row);
    });

    if(false) {
      window.parsedTypedefs1 = codeGenCommon.unwrapCellValues(this.parsedTypedefs);
      console.log(`window.parsedTypedefs1 👇👇👇`);
      console.log(window.parsedTypedefs1);
    }
  }

  #compileParsedParameterList () {
    this.parsedParameterList = this.#parseParameterList();

    if(false) {
      window.parsed1 = this.parsedParameterList.map(codeGenCommon.unwrapCellValues);
      console.log(`window.parsed1 👇👇👇`);
      console.log(window.parsed1);
    }
  }

  #compileParsedParameterListFlat () {
    this.parsedParameterListFlat = this.#parseParameterListFlat(this.parsedParameterList);

    this.parsedParameterListFlat.forEach((flatParam) => {
      flatParam.NameUpperSnakeCase = toolBox.camelToUpperSnake(flatParam.Name.value)
    });

    this.parsedParameterListFlatNameUpperSnakeCaseMaxLength = Math.max(
      ...(this.parsedParameterListFlat.map((flatParam) => flatParam.NameUpperSnakeCase.length))
    );

    this.parsedParameterListFlatFilteredReserves = this.parsedParameterListFlat.filter((row) => {
      return !codeGenCommon.parameterListRowIsReserved(row)
    });

    if(false) {
      window.flat1 = this.parsedParameterListFlat.map(codeGenCommon.unwrapCellValues);
      console.log(`window.flat1 👇👇👇`);
      console.log(window.flat1);
    }
  }

  #compileRuleCheckAllEnumSheetRowNamesAreValidCIdentifier () {
    Object.keys(this.EnumTypeSheets).forEach((sheetName) => {
      let sheetObj = this.EnumTypeSheets[sheetName];

      if(sheetName === `eParameterId`) {
        return;
      }

      this.compileRuleCheckTytpedefSheetRowNamesAreValidCIdentifier(sheetObj, sheetName);
    });
  }

  #compileRuleCheckAllStructSheetRowNamesAreValidCIdentifier () {
    Object.keys(this.StructTypeSheets).forEach((sheetName) => {
      let sheetObj = this.StructTypeSheets[sheetName];

      this.compileRuleCheckTytpedefSheetRowNamesAreValidCIdentifier(
        sheetObj.filter((row) => !codeGenCommon.structSheetRowIsVarTypeSize(row)),
        sheetName
      );
    });
  }

  #compileRuleCheckAllStructSheetRowNamesAreNotReservedExcelNames () {
    Object.keys(this.StructTypeSheets).forEach((sheetName) => {
      let sheetObj = this.StructTypeSheets[sheetName];

      sheetObj.forEach((row) => {
        if(row.Name.value === `VarTypeSize`) {
          this.reportCompileError({
            type: `Struct Sheet Contain VarTypeSize Named Row`,
            sheetName,
            sheetRow: row,
          });
        }
      });
    });
  }
  
  #compileRuleCheckAllEnumSheetRowValuesAreValidNumbers () {
    Object.keys(this.EnumTypeSheets).forEach((sheetName) => {
      let sheetObj = this.EnumTypeSheets[sheetName];

      this.compileRuleCheckSheetRowValuesAreValidNumbers(sheetObj, sheetName);
    });
  }

  #compileRuleCheckAllStructSheetRowArraySizesAreValidNumbers () {
    Object.keys(this.StructTypeSheets).forEach((sheetName) => {
      let sheetObj = this.StructTypeSheets[sheetName];

      this.compileRuleCheckSheetRowArraySizesAreValid(
        sheetObj.filter((row) => !codeGenCommon.structSheetRowIsVarTypeSize(row)),
        sheetName
      );
    });
  }

  #compileRuleCheckAllStructSheetRowDataTypesAreValid () {
    Object.keys(this.StructTypeSheets).forEach((sheetName) => {
      let sheetObj = this.StructTypeSheets[sheetName];

      this.compileRuleCheckSheetRowDataTypesAreValid(
        sheetObj.filter((row) => !codeGenCommon.structSheetRowIsVarTypeSize(row)),
        sheetName
      );
    });
  }

  #compileRuleCheckStructSheetsLoopDependencies () {
    this.structSheetNames.forEach((structName) => {
      let dependancyLoopMap = codeGenCommon.findDependencyLoop(this, structName);

      if(dependancyLoopMap) {
        this.reportCompileError({
          type: `Dependency Loop Found In Struct Type`,
          structName,
          dependancyLoopMap,
        });
      }
    });
  }

  #compileRuleCheckAllStructSheetRowAddrOrderings () {
    Object.keys(this.StructTypeSheets).forEach((sheetName) => {
      let sheetObj = this.StructTypeSheets[sheetName];

      this.compileRuleCheckSheetRowAddrOrderings(
        sheetObj.filter((row) => !codeGenCommon.structSheetRowIsVarTypeSize(row)),
        sheetName
      );
    });
  }

  /** Private method to compile all sheets into sets/arrays */
  #compile() {
    this.#compileForgedTypedefSheetsFromHeaderFiles();
    this.#addForgedTypedefSheetsFromHeaderFilesToExcelSheets();
    this.#compileTypedefSheetNames();
    this.#compileExtractAllGroupNames();
    
    this.compileRuleCheckSheetRowParameterTypesAreValid(this.ParameterListSheet, `ParameterList`);
    this.compileRuleCheckSheetRowDataTypesAreValid(this.ParameterListSheet, `ParameterList`);
    this.compileRuleCheckSheetRowArraySizesAreValid(this.ParameterListSheet, `ParameterList`);
    this.compileRuleCheckParamsIgnoredByModbusDontHaveModbusAddrConstraint();
    
    this.#compileRuleCheckAllEnumSheetRowNamesAreValidCIdentifier();
    this.#compileRuleCheckAllEnumSheetRowValuesAreValidNumbers();
    this.#compileRuleCheckAllStructSheetRowNamesAreNotReservedExcelNames();
    this.#compileRuleCheckAllStructSheetRowNamesAreValidCIdentifier();
    this.#compileRuleCheckAllStructSheetRowArraySizesAreValidNumbers();
    this.#compileRuleCheckAllStructSheetRowDataTypesAreValid();
    this.#compileRuleCheckStructSheetsLoopDependencies();

    this.#compileForgeDataTypeSheet();
    this.#compileParameterIds();
    this.#compileParameterModbussAddresses();

    /* I need to delete these since it does not make sence to check something
     * the software is generating itself, but I leave them be for now. maybe
     * they catch a few bugs.
     */
    this.compileRuleCheckSheetRowIdAreValid(this.parameterListFilteredReserves, `ParameterList`);
    this.compileRuleCheckSheetRowIdOrderings(this.ParameterListSheet, `ParameterList`);
    this.compileRuleCheckSheetRowModbusAddrOrderings(this.ParameterListSheet, `ParameterList`);
    this.#compileRuleCheckAllStructSheetRowAddrOrderings();

    this.#compileParsedTypedefs();
    
    this.#compileAddWordSizeToParameterList();
    this.#compileParameterListParseTypes();
    this.#compileParameterListAddNameUpperSnakeCases();
    if(false) { this.#compileDataListAddNameUpperSnakeCases(); }
    this.#compileExtractedDeviceId();
    
    this.#compileParameterListFilteredReserves();
    this.#compileParameterListFilteredEmptyRows();
    this.#compileParamListGroupedByGroup();
    this.#compileParsedParameterList();
    this.#compileParsedParameterListFlat();

    this.#compileForgeParameterIdSheet();
    this.#compileForgedEnumTypeSheetParameterMbAddr();
    this.#compileInfoSheetAddNameUpperSnakeCases();
  }

  #compileExtractedDeviceId () {
    let deviceIdRow = this.ParameterListSheet.find((paramter) => paramter.Name.value === `DeviceId`);

    this.DeviceId = codeGenCommon.getParameterDefaultValue(deviceIdRow);
  }

  #parseParameterList () {
    const getWordSize = (dataType) => {
      return this.dataTypeSizes[dataType];
    }

    const resolveType = (dataType) => {
      if (!dataType) {
        return null;
      }

      // Non-Struct type
      if (!codeGenCommon.dataTypeIsStruct(dataType)) {
        return {
          DataType: {value: dataType},
          WordSize: {value: getWordSize(dataType)},
          ModbusAddr: {value: 0}, // Always start at 0 relative to parent
        };
      }

      // Complex type
      return this.StructTypeSheets[dataType]
        .filter((row) => !codeGenCommon.structSheetRowIsVarTypeSize(row))
        .map(field => {
          let resultObj = {
            Name: field.Name,
            DataType: field.DataType,
            ArraySize: field.ArraySize,
            ID: {value: field.ID || 0},
            ModbusAddr: {value: Number(field.Addr.value) || 0}, // relative to structure start
            WordSize: {value: getWordSize(field.DataType.value)},
            Description: field.Description,
            Structure: this.StructTypeSheets[field.DataType.value] ?
                          resolveType(field.DataType.value) : null,
          };

          return resultObj;
        });
    }

    const parameters = this.ParameterListSheet.map(row => {
      return {
        ...row,
        Structure: resolveType(row.DataType.value),
      };
    });

    return parameters;
  }

  #parseParameterListFlat(
    parameters,
    prefix = "",
    baseModbusAddr = 0,
    meta = {}
  ) {
    const flatList = [];

    for (const param of parameters) {
      let {
        Name,
        DataType,
        ModbusAddr,
        WordSize,
        ArraySize = 1,
        Description,
        Structure,
        ParameterType,
        ID,
        Group,
        Tag1,
        Tag2,
        Tag3,
        Tag4,
        Tag5,
      } = param;

      const isStruct = Array.isArray(Structure);

      for (let i = 0; i < ArraySize.value; i++) {
        const elementBaseModbusAddr =
            baseModbusAddr
          + ModbusAddr.value
          + i * this.dataTypeSizes[DataType.value];

        const indexedName =
          ArraySize.value > 1
            ? `${prefix ? prefix + "." : ""}${Name.value}[${i}]`
            : `${prefix ? prefix + "." : ""}${Name.value}`;

        let propagatedMeta = {
          ParameterType: {value: null},
          ID: {value: null},
          Group: {value: null},
          Tag1: {value: null},
          Tag2: {value: null},
          Tag3: {value: null},
          Tag4: {value: null},
          Tag5: {value: null},
        };

        if(ParameterType && ParameterType.value) {
          propagatedMeta.ParameterType = ParameterType;
        } else if(meta.ParameterType && meta.ParameterType.value) {
          propagatedMeta.ParameterType = meta.ParameterType;
        }

        if(ID && Number(ID.value)) {
          propagatedMeta.ID = ID;
        } else if(meta.ID && Number(meta.ID.value)) {
          propagatedMeta.ID = meta.ID;
        }

        [
          Tag1,
          Tag2,
          Tag3,
          Tag4,
          Tag5,
        ].forEach((tagVar, index) => {
          let tagKey = `Tag${index + 1}`;

          if(tagVar && (tagVar.value !== null)) {
            propagatedMeta[tagKey] = tagVar;
          } else if(meta[tagKey] && (meta[tagKey] !== null)) {
            propagatedMeta[tagKey] = meta[tagKey];
          }
        });

        if(Group && (Group.value !== null)) {
          propagatedMeta.Group = Group;
        } else if(meta.Group && (meta.Group !== null)) {
          propagatedMeta.Group = meta.Group;
        }

        if(!(meta.ID && Number(meta.ID.value)) && (ID.value === 0)) {
          propagatedMeta.ID.value = 0;
        }

        if (isStruct) {
          const subFlat = this.#parseParameterListFlat(
            /* parameters */     Structure,
            /* prefix */         indexedName,
            /* baseModbusAddr */ elementBaseModbusAddr,
            /* meta */           propagatedMeta
          );
          flatList.push(...subFlat);
        } else {
          let result = {
            Name: {value: indexedName},
            DataType,
            Tag1,
            Tag2,
            Tag3,
            Tag4,
            Tag5,
            ModbusAddr: {value: elementBaseModbusAddr},
            WordSize: {value: this.dataTypeSizes[DataType.value]},
            ArraySize: {value: 1},
            Description: {value: Description.value || ""},
            ...propagatedMeta,
          };

          flatList.push(result);
        }
      }
    }

    return flatList;
  }
}

class CompiledExcelSet {
  /** @type {Array<CompiledUserHeaderFile>} */
  CompiledUserHeaderFiles = [];

  /** @type {Array<CompiledExcelParamList>} */
  CompiledExcelParamLists = [];

  /** @type {CompiledExcelDeviceId} */
  CompiledExcelDeviceIds = [];

  /** @type {object} */
  codeGenMetaDataOld = {};
  codeGenMetaDataNew = {};

  constructor(folderPath) {
    let userInputFilePaths = this.getAllUserInputFilePaths(
      personalFileApi.joinPaths(folderPath, appConfig.defs.userInputsRootFolderName)
    );
    let modbusDeviceIdFileNames = this.getAllDeviceIdExcelFileNames(folderPath);
    let modbusParameterListFileNames = this.getAllParameterListExcelFileNames(folderPath);

    if(modbusParameterListFileNames.length === 0) {
      if(false) {
        toolBox.printGenericBanner(
          `No "parameter_list File" found in this directory`,
          { generateOutlines: true, textColor: `red` },
        );
      } else {
        toolBox.printErrorBanner(`No "parameter_list File" found in this directory`);
      }
      throw new Error(`Don't display this error`);
    }

    if(modbusDeviceIdFileNames.length === 0) {
      toolBox.printGenericBanner(
        `No "device_id File" found in this directory`,
        { generateOutlines: true, textColor: `red` },
      );
      throw new Error(`Don't display this error`);
    }

    this.codeGenMetaDataOld = personalFileApi.readAndParseJsonFile(
      personalFileApi.joinPaths(folderPath, `codegen_output`, `MetaData`, `metaData.json`)
    );

    if(this.codeGenMetaDataOld === null) {
      this.codeGenMetaDataOld = {};
    }

    userInputFilePaths.forEach((filePath) => {
      let compiledUserHeaderFile = new CompiledUserHeaderFile(filePath);

      this.CompiledUserHeaderFiles.push(compiledUserHeaderFile);
    });

    modbusDeviceIdFileNames.forEach((fileName, index) => {
      if(index !== 0) {
        return;
      }

      let path = folderPath + `\\` + fileName;
      let historyObj = this.codeGenMetaDataOld[fileName];

      let compiledExcelParamList = new CompiledExcelDeviceId(
        path,
        historyObj
      );

      this.CompiledExcelDeviceIds.push(compiledExcelParamList);

      historyObj = {
        excelHash:      compiledExcelParamList.excelHash,
        outputsVersion: compiledExcelParamList.outputsVersion,
        appVersion:     appConfig.app.VERSION,
      };

      this.codeGenMetaDataNew[fileName] = historyObj;
    });

    modbusParameterListFileNames.forEach((fileName) => {
      if(appConfig.developer.onlyProcessOneDeviceExcel.enable) {
        if(fileName !== appConfig.developer.onlyProcessOneDeviceExcel.fileName) {
          return;
        }
      }
      
      let path = folderPath + `\\` + fileName;
      let historyObj = this.codeGenMetaDataOld[fileName];
      
      let compiledExcelParamList = new CompiledExcelParamList(
        path,
        historyObj,
        this.CompiledExcelDeviceIds[0],
        this.CompiledUserHeaderFiles
      );

      historyObj = {
        excelHash:      compiledExcelParamList.excelHash,
        outputsVersion: compiledExcelParamList.outputsVersion,
        appVersion:     appConfig.app.VERSION,
      };

      this.CompiledExcelParamLists.push(compiledExcelParamList);
      this.codeGenMetaDataNew[fileName] = historyObj;
    });
  }

  getAllParameterListExcelFileNames(folderPath) {
    let modbusParameterListFileName = null;
    let RegEx = /(?<!~\$)parameter_list_.*\.xlsx$/;
    
    modbusParameterListFileName = personalFileApi.listFiles(folderPath);

    modbusParameterListFileName = modbusParameterListFileName
      .filter(fileName => RegEx.test(fileName));

    return modbusParameterListFileName;
  }

  getAllDeviceIdExcelFileNames(folderPath) {
    let modbusDeviceIdFileNames = null;
    let RegEx = /^device_id\.xlsx$/;
    
    modbusDeviceIdFileNames = personalFileApi.listFiles(folderPath);

    modbusDeviceIdFileNames = modbusDeviceIdFileNames
      .filter(fileName => RegEx.test(fileName));

    return modbusDeviceIdFileNames;
  }

  getAllUserInputFilePaths(folderPath) {
    if(!personalFileApi.systemPathExists(folderPath)) {
      return [];
    }

    let userInputFileNames = null;
    let RegEx = /\.h$/;
    
    userInputFileNames = personalFileApi.findFilesWithExtension(folderPath, '.h');

    userInputFileNames = userInputFileNames
      .filter(fileName => RegEx.test(fileName));

    return userInputFileNames;
  }
}

module.exports = {
  CompiledExcelParamList,
  CompiledExcelDeviceId,
  CompiledExcelSet,
};

