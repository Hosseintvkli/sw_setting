/** @typedef {import('../core/compiledExcel').CompiledExcelParamList} CompiledExcelParamList */
/** @typedef {import('../core/compiledExcel').CompiledExcelSet} CompiledExcelSet */

const toolBox = require('../../toolBox');
const appConfig = require('../../appConfig');
const { mode } = require('crypto-js');

const TAB1 = `  `;
const TAB2 = TAB1.repeat(2);
const TAB3 = TAB1.repeat(3);
const TAB4 = TAB1.repeat(4);
const TAB5 = TAB1.repeat(5);

const ExcelPrimitiveTypesModbusIgnored = [
  `BOOL`,
  `U8`,
  `I8`,
];

const ExcelPrimitiveTypes = [
  `BOOL`,
  `U8`,
  `I8`,
  `U16`,
  `I16`,
  `U32`,
  `I32`,
  `U64`,
  `I64`,
  `F32`,
  `F64`,
];

function dataTypeIsEnum (dataTypeName) {
  return /^[e][A-Z1-9]/.test(dataTypeName);
}

function dataTypeIsStruct (dataTypeName) {
  return /^[s][A-Z1-9]/.test(dataTypeName);
}

function modbusParameterListParameterRowIsMonitoring (row) {
  return RegExp(`MONITORING`).test(row.ParameterType.value);
}

function modbusParameterListParameterRowIsCommand (row) {
  return RegExp(`COMMAND`).test(row.ParameterType.value);
}

function modbusParameterListParameterRowIsSetting (row) {
  return RegExp(`SETTING`).test(row.ParameterType.value);
}

function getModbusParameterListParameterTypeName (parameterRow) {
  if(modbusParameterListParameterRowIsMonitoring(parameterRow)) { return `Monitoring`; }
  if(modbusParameterListParameterRowIsCommand(parameterRow))    { return `Command`; }
  if(modbusParameterListParameterRowIsSetting(parameterRow))    { return `Setting`; }

  return null;
}

function excelDataTypeToC(dataTypeName) {
  let result = ``;

  switch(dataTypeName) {
    case `BOOL`: { result = `bool`;       } break;
    case `U8`:   { result = `uint8_t`;    } break;
    case `I8`:   { result = `int8_t`;     } break;
    case `U16`:  { result = `uint16_t`;   } break;
    case `I16`:  { result = `int16_t`;    } break;
    case `U32`:  { result = `uint32_t`;   } break;
    case `I32`:  { result = `int32_t`;    } break;
    case `U64`:  { result = `uint64_t`;   } break;
    case `I64`:  { result = `int64_t`;    } break;
    case `F32`:  { result = `float32_t`;  } break;
    case `F64`:  { result = `float64_t`;  } break;
    default:     { result = dataTypeName; } break;
  }

  return result;
}

function cDataTypeToExcel(dataTypeName) {
  let result = ``;

  switch(dataTypeName) {
    case `bool`      : { result = `BOOL`; } break;
    case `uint8_t`   : { result = `U8`  ; } break;
    case `int8_t`    : { result = `I8`  ; } break;
    case `uint16_t`  : { result = `U16` ; } break;
    case `int16_t`   : { result = `I16` ; } break;
    case `uint32_t`  : { result = `U32` ; } break;
    case `int32_t`   : { result = `I32` ; } break;
    case `uint64_t`  : { result = `U64` ; } break;
    case `int64_t`   : { result = `I64` ; } break;
    case `float`     : { result = `F32` ; } break;
    case `float32_t` : { result = `F32` ; } break;
    case `double`    : { result = `F64` ; } break;
    case `float64_t` : { result = `F64` ; } break;
    default:     { result = dataTypeName; } break;
  }

  return result;
}

function excelDataTypeToCs(dataTypeName) {
  let result = ``;

  switch(dataTypeName) {
    case `BOOL`: { result = `bool`; } break;
    case `U8`:   { result = `Byte`; } break;
    case `I8`:   { result = `SByte`; } break;
    case `U16`:  { result = `UInt16`; } break;
    case `I16`:  { result = `Int16`; } break;
    case `U32`:  { result = `UInt32`; } break;
    case `I32`:  { result = `Int32`; } break;
    case `U64`:  { result = `UInt64`; } break;
    case `I64`:  { result = `Int64`; } break;
    case `F32`:  { result = `Single`; } break;
    case `F64`:  { result = `Double`; } break;
    case `Null`: { result = `Nullable`; } break;
    default:     { result = dataTypeName; } break;
  }

  return result;
}

function excelDataTypeIsPrimitive (dataTypeName) {
  return ExcelPrimitiveTypes.includes(dataTypeName);
}

function getExcelPrimitiveTypes () {
  return ExcelPrimitiveTypes;
}

function getPrimitiveTypeWordSize (primitiveTypeName) {
  let result = 0;

  switch(primitiveTypeName) {
    case `BOOL`: { result =  8 / 16; } break;
    case `U8`:   { result =  8 / 16; } break;
    case `I8`:   { result =  8 / 16; } break;
    case `U16`:  { result = 16 / 16; } break;
    case `I16`:  { result = 16 / 16; } break;
    case `U32`:  { result = 32 / 16; } break;
    case `I32`:  { result = 32 / 16; } break;
    case `U64`:  { result = 64 / 16; } break;
    case `I64`:  { result = 64 / 16; } break;
    case `F32`:  { result = 32 / 16; } break;
    case `F64`:  { result = 64 / 16; } break;

    default: {
      break;
    }
  }

  return result;
}

/**
 * @param {CompiledExcelParamList} model
 */
function getTypeDependancyList (model, typeSheetName) {
  if(!model.StructTypeSheets[typeSheetName]) {
    return [];
  }
  
  return model.StructTypeSheets[typeSheetName]
    .map((row) => row.DataType.value)
    .filter((dataType) => dataType !== null)
    .filter((dataType) => !excelDataTypeIsPrimitive(dataType))
}

/**
 * @param {CompiledExcelParamList} model
 */
function getTypeDependancyListDeep (model, typeSheetName, handledTypes=null) {
  if(!handledTypes) {
    handledTypes = new Set();
  }

  let myDependancyList = getTypeDependancyList(model, typeSheetName);
  handledTypes.add(typeSheetName);

  myDependancyList.forEach((dependency) => {
    if(!dataTypeIsStruct(dependency)) {
      return;
    }

    if(handledTypes.has(dependency)) {
      return;
    }

    let indirectTypesDependancyListDeep = getTypeDependancyListDeep(
      model, dependency, handledTypes
    );

    myDependancyList.push(...indirectTypesDependancyListDeep);
  });

  return [...(new Set(myDependancyList))];
}

/**
 * @param {CompiledExcelParamList} model
 */
function findDependencyLoop(model, rootType) {
  const visited = new Set();     // All nodes reached
  const stack = new Set();       // Nodes in the current recursion path
  const path = [];               // Ordered list of current recursion path

  function dfs(type) {
    visited.add(type);
    stack.add(type);
    path.push(type);

    const deps = getTypeDependancyList(model, type) || [];

    for (const dep of deps) {
      if (!dataTypeIsStruct(dep)) {
        continue; // skip primitives
      }

      // Case 1: Found a cycle
      if (stack.has(dep)) {
        // slice the cycle part of path
        const cycleStartIndex = path.indexOf(dep);
        return path.slice(cycleStartIndex); // cycle path
      }

      // Case 2: Not visited → go deeper
      if (!visited.has(dep)) {
        const cycle = dfs(dep);
        if (cycle) return cycle;
      }
    }

    // backtrack
    stack.delete(type);
    path.pop();
    return null;
  }

  return dfs(rootType);
}

/**
 * @param {CompiledExcelParamList} model
 */
function typeAIsDependentOnTypeB (model, typeA, typeB) {
  let myDependancyList = getTypeDependancyListDeep(model, typeA);

  if(myDependancyList.includes(typeB)) {
    return true;
  }

  return false;
}

function getEnumSheetMaxValue (enumSheet) {
  return Math.max(
    ...enumSheet.map((obj) => obj.Value.value)
  );
}

function getEnumSheetMemberQty (enumSheet) {
  return enumSheet.filter((row) => {
    return true /* Not filtering any row for now */
  }).length;
}

function getUserParameterListVersion () {
  let inputObj = document.querySelector(`.value-input-container .value-input input`);
  
  return inputObj.value;
}

function getParameterDefaultValue(parameter) {
  let paramDefaultValue = null;

  if(parameter.hasOwnProperty(`Dafault Value`)) {
    paramDefaultValue = parameter[`Dafault Value`].value;
  } else if(parameter.hasOwnProperty(`DafaultValue`)) {
    paramDefaultValue = parameter[`DafaultValue`].value;
  } else if(parameter.hasOwnProperty(`Default Value`)) {
    paramDefaultValue = parameter[`Default Value`].value;
  } else if(parameter.hasOwnProperty(`DefaultValue`)) {
    paramDefaultValue = parameter[`DefaultValue`].value;
  }

  return paramDefaultValue;
}

function generateDeviceIdFileName (deviceId, nameStart=``, nameEnd=``, outputsVersion=null) {
  let fileDeviceIdAndVersionName = ``;

  fileDeviceIdAndVersionName += String(deviceId).padStart(5, '0');

  if(outputsVersion !== null) {
    fileDeviceIdAndVersionName += `_`;
    fileDeviceIdAndVersionName += outputsVersion;
  }

  return nameStart + fileDeviceIdAndVersionName + nameEnd;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateCsClassName (model, outputsVersion) {
  return generateDeviceIdFileName(
    model.DeviceId,
    `Parameters_DeviceID_`,
    ``,
    outputsVersion
  );
}

function generateObjectCommentTable(tableName, data) {
  if(data.length === 0) {
    return ``;
  }

  let output = ``;
  let headers = Object.keys(data[0]);
  let columns = [];

  // YOUR CODE (unchanged)
  headers.forEach((header) => {
    let columnDataArray = data.map(obj => obj[header]);
    let columnWidth =
      Math.max(header.length, ...columnDataArray.map((columnData) => {
        return `${columnData}`.length
      }));

    columns.push({
      columnWidth: columnWidth,
      columnHeader: header,
      columnDataArray: columnDataArray
    });
  });

  // ------------------------------
  // THE REST OF THE TABLE BUILDER
  // ------------------------------

  // total width calculation (columns + borders + separators)
  const totalInsideWidth =
    columns.reduce((sum, col) => sum + col.columnWidth + 4, 0) +
    (columns.length - 1); // separators

  const topBorder =
    "╔" + "═".repeat(totalInsideWidth) + "╗";

  const bottomBorder =
    "╚" + "═".repeat(totalInsideWidth) + "╝";

  const titleLine =
    "║ " +
    tableName +
    " " +
    "-".repeat(totalInsideWidth - tableName.length - 3) +
    " " +
    "║";

  const headerSeparator =
    "╠" +
    columns.map(col => "═".repeat(col.columnWidth + 4)).join("╦") +
    "╣";

  const headerBottomSeparator =
    "╠" +
    columns.map(col => "═".repeat(col.columnWidth + 4)).join("╩") +
    "╣";

  // Header row with ▼ icons
  const headerRow =
    "║ " +
    columns
      .map(col => {
        let text = col.columnHeader;
        
        if(text === null) {
          text = `-`;
        }
        if(/^__EMPTY(?:_\d+)?$/.test(text)) {
          text = `-`;
        }

        text += " ▼";
        text = text.padEnd(col.columnWidth + 2)
        
        return text;
      }
      )
      .join(" ║ ") +
    " ║";

  const firstRowSeparator =
    "╟" +
    columns.map(col => "─".repeat(col.columnWidth + 4)).join("┬") +
    "╢";

  const rowSeparator =
    "╟" +
    columns.map(col => "─".repeat(col.columnWidth + 4)).join("┼") +
    "╢";

  const lastRowSeparator =
    "╟" +
    columns.map(col => "─".repeat(col.columnWidth + 4)).join("┴") +
    "╢";

  // Build rows
  const rows = [];
  const rowCount = data.length;

  for (let rowIndex = 0; rowIndex < rowCount; rowIndex++) {
    const rowLine =
      "║ " +
      columns
        .map(col => {
          let rowText = col.columnDataArray[rowIndex];
          if(rowText === null) {
            rowText = `-`;
          }
          if(/^__EMPTY(?:_\d+)?$/.test(rowText)) {
            rowText = `-`;
          }

          return `${rowText}`.padEnd(col.columnWidth + 2);
        })
        .join(" │ ") +
      " ║";

    const isLast = rowIndex === rowCount - 1;
    const isFirst = rowIndex === 0;

    if(isFirst) {
      rows.push(firstRowSeparator);
    }
    rows.push(rowLine);
    rows.push(isLast ? lastRowSeparator : rowSeparator);
  }

  // Final output assembly
  output += topBorder + "\r\n";
  output += titleLine + "\r\n";
  output += headerSeparator + "\r\n";
  output += headerRow + "\r\n";
  output += headerBottomSeparator + "\r\n";
  output += rows.join("\r\n") + "\r\n";
  output += bottomBorder;
  output += "\r\n";

  return output;
}

function unwrapCellValues(node) {
  // If object has a `.value`, unwrap it
  if (node && typeof node === "object" && "value" in node) {
    return unwrapCellValues(node.value);
  }

  // If it's an array, recurse into elements
  if (Array.isArray(node)) {
    return node.map(unwrapCellValues);
  }

  // If it's a plain object, recurse into keys
  if (node && typeof node === "object") {
    const result = {};
    for (const key in node) {
      result[key] = unwrapCellValues(node[key]);
    }
    return result;
  }

  // Primitive
  return node;
}

function convNumStringToNum (string, options={expectedType:null}) {
  if(string === null) {
    switch(options.expectedType) {
      case `string`: {
        return ``;
      }
      break;

      case `number`: {
        return 0;
      }
      break;

      default: {
        return string;
      }
      break;
    }
  }

  if(!isNaN(string)) {
    return Number(string);
  }

  return string;
}

function generateReadMeFiles (generateFiles) {
  let outputString = ``;
  
  const appendRowsToOutput = (...stringRows) => {
    stringRows.forEach((stringRow) => {
      outputString += stringRow;
      outputString += '\n';
    });
  }
  
  const now = new Date();

  const year = now.getFullYear();
  const month = String(now.getMonth() + 1).padStart(2, '0'); // Months are 0-indexed
  const day = String(now.getDate()).padStart(2, '0');

  const hours = String(now.getHours()).padStart(2, '0');
  const minutes = String(now.getMinutes()).padStart(2, '0');
  const seconds = String(now.getSeconds()).padStart(2, '0');

  const formattedDateTime = `${year}-${month}-${day} - ${hours}:${minutes}:${seconds}`;

  function createMdFileString (fileType) {
    outputString = ``;

    appendRowsToOutput (
      `# sw_modbus_ext_code_generator`,
      ``,
      `## Software Version`,
      ``,
      `- **Generator Version:** ${appConfig.app.VERSION}  `,
      ``,
      // `## Input`,
      // ``,
      // `- Source Excel files: "input.xlsx"  `,
      ``,
      `## Outputs`,
      ``,
      `The application generates the following files:`,
      ``,
    );
    
    appendRowsToOutput (
      `### ${fileType.toUpperCase()} Files`,
      `| File Name | Description |`,
      `|-----------|-------------|`,
    );
    generateFiles[fileType].forEach((file) => {
      appendRowsToOutput (
        `| ${file.fileName} | - |`,
      );
    });

    appendRowsToOutput (
      `## Notes`,
      ``,
      `- The outputs are generated based on the version **${appConfig.app.VERSION}** of this software.  `,
      ``,
      `---`,
      ``,
      `*Generated on: ${formattedDateTime}*  `,
    );
    
    return outputString;
  }

  generateFiles.txt.readMeFile = {
    fileName: `README.md`,
    fileContent: createMdFileString(`txt`),
    fileType: `TXT`
  };

  generateFiles.c.readMeFile = {
    fileName: `README.md`,
    fileContent: createMdFileString(`c`),
    fileType: `C`
  };

  generateFiles.json.readMeFile = {
    fileName: `README.md`,
    fileContent: createMdFileString(`json`),
    fileType: `JSON`
  };

  generateFiles.cs.readMeFile = {
    fileName: `README.md`,
    fileContent: createMdFileString(`cs`),
    fileType: `C#`
  };
}

function createParamRowCopy (rowObj, clearFieldValues=false) {
  let copy = toolBox.deepClone(rowObj);

  if(clearFieldValues) {
    Object.keys(copy).forEach((key) => {
      copy[key] = {
        value: null,
        cell: null
      }
    });
  }

  return copy;
}

function getRowNumber(rowParam) {
  return Number(rowParam.cell.match(/\d+$/)[0]);
}

function parameterListRowIsReserved(row) {
  return row.Name.value.startsWith(`___________CodeGen_ForgedVar_Reserve`);
}

function removeCodegenMarkerFromParameterName(name) {
  return name.split(`___________CodeGen_ForgedVar_`)[1];
}

function structSheetRowIsVarTypeSize(row) {
  return row.Name.value.startsWith(`VarTypeSize`);
}

function dataTypeIsIgnoredInModbus (dataType) {
  return ExcelPrimitiveTypesModbusIgnored.includes(dataType);
}

/**
 * @param {CompiledExcelParamList} model
 */
function getModbusParamTotalSize(model, row) {
  if(dataTypeIsIgnoredInModbus(row.DataType.value)) {
    return 0;
  }
  
  let result = 0;
  let rowDataTypeSize = model.dataTypeSizes[row.DataType.value];

  result = rowDataTypeSize * Number(row.ArraySize.value);

  return result;
}

function isValidCIdentifierSyntax(name) {
  if (typeof name !== "string" || name.length === 0) return false;

  // Must start with letter or underscore,
  // followed by letters, digits, or underscores
  const identifierRegex = /^[A-Za-z_][A-Za-z0-9_]*$/;
  return identifierRegex.test(name);
}

/**
 * @param {CompiledExcelParamList} model
 */
function extractStructTypeSheetVarTypeSize(model, structTypeSheet) {
  return model.StructTypeSheets[structTypeSheet].at(-1).Addr.value;
}

function isCReservedKeyword(name) {
  const cKeywords = new Set([
    "auto","break","case","char","const","continue","default","do","double",
    "else","enum","extern","float","for","goto","if","inline","int","long",
    "register","restrict","return","short","signed","sizeof","static","struct",
    "switch","typedef","union","unsigned","void","volatile","while",
    "_Alignas","_Alignof","_Atomic","_Bool","_Complex","_Generic",
    "_Imaginary","_Noreturn","_Static_assert","_Thread_local"
  ]);

  return cKeywords.has(name);
}

function generateTypedefGroupFromEnumSheet (enumSheetObj, options={}) {
  let output = ``;
  let typeCastStr = ``;

  let {
    typedefName = null,
    typedefMacrosPrefix = ``,
  } = options;

  let maxEnumeratorNameLength = Math.max(
    ...enumSheetObj.map((row) => row.Name.value.length)
  );

  output += toolBox.concatStringRows(
    `/**`,
    `* @brief`,
    `* `,
    `*/`,
  );

  if(typedefName) {
    output += toolBox.concatStringRows(
      `typedef uint16_t ${typedefName};`,
    );
  }

  output += toolBox.concatStringRows(``);

  enumSheetObj.forEach((row) => {
    
    output += `#define `;
    output += typedefMacrosPrefix;
    output += row.Name.value;

    output += ` `.repeat(
        maxEnumeratorNameLength
      + 2
      - row.Name.value.length
    );

    if(typedefName) {
      typeCastStr = `(${typedefName})`;
    }

    output += `(${typeCastStr}${row.Value.value})`;

    output += `\r\n`;
  });

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function allStructDependenciesExist (model, structName) {
  let structSheet = model[structName];

  for(let i = 0; i < structSheet.length; i++) {
    let row = structSheet[i];
    
    if(excelDataTypeIsPrimitive(row.DataType.value)) {
      continue;
    }

    if(!model.hasOwnProperty(row.DataType.value)) {
      return false;
    }
  }

  return true;
}

/**
 * @param {CompiledExcelParamList} model
 */
function getAllMissingStructDependencies (model, structName) {
  let dependencies = getTypeDependancyList(model, structName);
  return (dependencies
    .filter((dependency) => {
      if(!model.StructTypeSheets.hasOwnProperty(dependency)) {
        return false;
      }
      
      if(!model.EnumTypeSheets.hasOwnProperty(dependency)) {
        return false;
      }

      return true;
    })
  );
}

function paramIsIgnoredByModbus (param) {
  return dataTypeIsIgnoredInModbus(param.DataType.value);
}


/**
 * @param {CompiledExcelParamList} model
 */
function structTypeIsFromHeaderFiles (model, typeName) {
  return model.headerFilesStructNames.includes(typeName);
}

/**
 * @param {CompiledExcelParamList} model
 */
function enumTypeIsFromHeaderFiles (model, typeName) {
  return model.headerFilesEnumNames.includes(typeName);
}

/**
 * @param {CompiledExcelParamList} model
 */
function typeIsFromHeaderFiles (model, typeName) {
  return model.headerFilesTypedefNames.includes(typeName);
}

function getHeaderFilePathFromRoot (fullFilePath) {
  let headerFilePath = fullFilePath;

  headerFilePath = headerFilePath.split(appConfig.defs.userInputsRootFolderName)[1];
  headerFilePath = appConfig.defs.userInputsRootFolderName + headerFilePath;

  return headerFilePath;
}

module.exports = {
  getHeaderFilePathFromRoot,
  structTypeIsFromHeaderFiles,
  enumTypeIsFromHeaderFiles,
  typeIsFromHeaderFiles,
  getAllMissingStructDependencies,
  structSheetRowIsVarTypeSize,
  dataTypeIsIgnoredInModbus,
  paramIsIgnoredByModbus,
  allStructDependenciesExist,
  isValidCIdentifierSyntax,
  extractStructTypeSheetVarTypeSize,
  isCReservedKeyword,
  getModbusParamTotalSize,
  parameterListRowIsReserved,
  removeCodegenMarkerFromParameterName,
  getRowNumber,
  dataTypeIsEnum,
  dataTypeIsStruct,
  getModbusParameterListParameterTypeName,
  modbusParameterListParameterRowIsMonitoring,
  modbusParameterListParameterRowIsCommand,
  modbusParameterListParameterRowIsSetting,
  excelDataTypeToC,
  cDataTypeToExcel,
  excelDataTypeToCs,
  getTypeDependancyList,
  getTypeDependancyListDeep,
  findDependencyLoop,
  typeAIsDependentOnTypeB,
  excelDataTypeIsPrimitive,
  getExcelPrimitiveTypes,
  getPrimitiveTypeWordSize,
  getEnumSheetMaxValue,
  getEnumSheetMemberQty,
  getUserParameterListVersion,
  getParameterDefaultValue,
  generateDeviceIdFileName,
  generateCsClassName,
  generateObjectCommentTable,
  unwrapCellValues,
  convNumStringToNum,
  generateReadMeFiles,
  generateTypedefGroupFromEnumSheet,
  createParamRowCopy,
}

