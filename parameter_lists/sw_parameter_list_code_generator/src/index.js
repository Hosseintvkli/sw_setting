'use strict';

const appConfig = require('./appConfig');
const toolBox = require('./toolBox');
const windowZoom = require('./windowZoom');
const codeGen = require('./codeGen/codeGen');
const appVersionDisplay = require('./appVersionDisplay');

/* Export variables for debugging Begin ↓ *********************/
window.toolBox = toolBox;
window.windowZoom = windowZoom;
window.codeGen = codeGen;
/* Export variables for debugging End   ↑ *********************/

let isFirstExcelSheetContentTxtFile = true;

function generateCodeGenOutputs (inputDirectoryPath, outputDirectoryPath) {
  let codeGenOutput;
  
  outputDirectoryPath = personalFileApi.joinPaths(outputDirectoryPath, `codegen_output`);

  let outputDirectoryPathTxt = null;
  let outputDirectoryPathC = null;
  let outputDirectoryPathJson = null;
  let outputDirectoryPathCs = null;
  let outputDirectoryPathMetaData = personalFileApi.joinPaths(
    outputDirectoryPath,
    `MetaData`
  );

  outputDirectoryPathTxt  = personalFileApi.createSubFolder(outputDirectoryPath, `TXT`);
  outputDirectoryPathC    = personalFileApi.createSubFolder(outputDirectoryPath, `C`);
  outputDirectoryPathJson = personalFileApi.createSubFolder(outputDirectoryPath, `JSON`);
  outputDirectoryPathCs   = personalFileApi.createSubFolder(outputDirectoryPath, `CS`);

  if(!personalFileApi.subFolderExists(outputDirectoryPath, `MetaData`)) {
    outputDirectoryPathMetaData = personalFileApi.createSubFolder(
      outputDirectoryPath,
      `MetaData`
    );
  }

  let generateFiles = {
    pathGrouped: {},

    versioned : {
      txt: [],
      c: [],
      json: [],
      cs: [],
      metaData: [],
    },

    unversioned : {
      txt: [],
      c: [],
      json: [],
      cs: [],
      metaData: [],
    }
  };
  
  function generateOutputFile (file, options={}) {
    const {
      deviceId=null,
      version=null,
      dontCreateUnversionedSubfolder=null,
      pathGroupedMdFilePath=null,
      isExcelSheetContentTxtFile=null,
      excelFileName=null,
    } = options

    const KNOWN_FILE_TYPES = [
      'TXT',
      'C',
      'H',
      'JSON',
      'C#',
      `METADATA`,
    ];

    const { fileName, fileContent, fileType } = file;
    const fileTypeUpperCase = fileType.toUpperCase();

    let fileFullPath = ``;
    let deviceFolderName = `parameter_list_${deviceId}`
    let deviceFolderNameVersioned = `parameter_list_${deviceId}_${version}`

    if(!KNOWN_FILE_TYPES.includes(fileTypeUpperCase)) {
      throw new Error(`Unknown file type "${fileTypeUpperCase}"`);
    }
    
    switch(fileTypeUpperCase) {
      case 'TXT':      { if(!outputDirectoryPathTxt)      { return; } } break;
      case 'C':
      case 'H':        { if(!outputDirectoryPathC)        { return; } } break;
      case 'JSON':     { if(!outputDirectoryPathJson)     { return; } } break;
      case 'C#':       { if(!outputDirectoryPathCs)       { return; } } break;
      case `METADATA`: { if(!outputDirectoryPathMetaData) { return; } } break;
    }

    switch(fileTypeUpperCase) {
      case 'TXT':      { fileFullPath += outputDirectoryPathTxt;      } break;
      case 'C':        { fileFullPath += outputDirectoryPathC;        } break;
      case 'H':        { fileFullPath += outputDirectoryPathC;        } break;
      case 'JSON':     { fileFullPath += outputDirectoryPathJson;     } break;
      case 'C#':       { fileFullPath += outputDirectoryPathCs;       } break;
      case `METADATA`: { fileFullPath += outputDirectoryPathMetaData; } break;
    }

    if(pathGroupedMdFilePath) {
      fileFullPath = pathGroupedMdFilePath;
    } else {
      switch(fileTypeUpperCase) {
        case 'TXT':
        case 'C#': {
          if(isExcelSheetContentTxtFile) {
            fileFullPath = personalFileApi.createSubFolder(fileFullPath, `excels`);
            fileFullPath = personalFileApi.createSubFolder(fileFullPath, excelFileName);
          } else {
            fileFullPath = personalFileApi.createSubFolder(fileFullPath, deviceFolderName);
            
            if(!version) {
              fileFullPath = personalFileApi.createSubFolder(fileFullPath, `unversioned`);
            } else {
              fileFullPath = personalFileApi.createSubFolder(fileFullPath, deviceFolderNameVersioned);
            }
          }
        }
        break;

        case 'JSON': {
          if(deviceId) {
            fileFullPath = personalFileApi.createSubFolder(fileFullPath, deviceFolderName);
          }
          
          if(!version) {
            if(!dontCreateUnversionedSubfolder) {
              fileFullPath = personalFileApi.createSubFolder(fileFullPath, `unversioned`);
            }
          } else {
            fileFullPath = personalFileApi.createSubFolder(fileFullPath, deviceFolderNameVersioned);
          }
        }
        break;
        
        case 'C':
        case 'H': {
          if(deviceId) {
            fileFullPath = personalFileApi.createSubFolder(fileFullPath, deviceFolderName);
          }
        }
        break;

        case `METADATA`: {
          /* Do nothing */
        }
        break;
      }

      if(!generateFiles.pathGrouped[fileFullPath]) {
        generateFiles.pathGrouped[fileFullPath] = {
          txt: [],
          c: [],
          json: [],
          cs: [],
        };
      }

      switch(fileTypeUpperCase) {
        case 'TXT':  { generateFiles.pathGrouped[fileFullPath].txt.push(file); } break;
        case 'C':    { generateFiles.pathGrouped[fileFullPath].c.push(file); } break;
        case 'H':    { generateFiles.pathGrouped[fileFullPath].c.push(file); } break;
        case 'JSON': { generateFiles.pathGrouped[fileFullPath].json.push(file); } break;
        case 'C#':   { generateFiles.pathGrouped[fileFullPath].cs.push(file); } break;
      }
    }

    fileFullPath += `\\` + fileName;

    if(!appConfig.developer.doNotGenerateOutputFiles) {
      personalFileApi.writeStringToFile(fileFullPath, fileContent);
    }

    // console.log(`Generate file ${fileFullPath}`);
    // console.log(`File: ${personalFileApi.lastPathPartsFs(fileFullPath, 1)}`);
  }

  let compiledExcelSet;

  try {
    compiledExcelSet = new codeGen.CompiledExcelSet(inputDirectoryPath);

    codeGenOutput = codeGen.generateCodeGenMetaDataJsonFile(
      compiledExcelSet.codeGenMetaDataNew
    );
    generateOutputFile(codeGenOutput);
  } catch (error) {
    if(error.message === `Don't display this error`) {
      return;
    } else {
      throw error;
    }
  }

  window.compiledExcelSet = compiledExcelSet;

  codeGenOutput = codeGen.generateExcelsContentTxtFiles(compiledExcelSet);
  Object.keys(codeGenOutput).forEach((excelFileName) => {
    let excelSheetContentTxtFiles = codeGenOutput[excelFileName];

    let fileFullPath = outputDirectoryPathTxt;

    fileFullPath = personalFileApi.createSubFolder(fileFullPath, `excels`);
    fileFullPath = personalFileApi.createSubFolder(fileFullPath, excelFileName);

    personalFileApi.clearFolder(fileFullPath);

    excelSheetContentTxtFiles.forEach((file) => {
      generateOutputFile(file, { isExcelSheetContentTxtFile: true, excelFileName });
    });
  });

  [
    true, /* => unversioned */
    false /* => versioned */
  ].forEach((unversioned) => {
    for(let i = 0; i < compiledExcelSet.CompiledExcelParamLists.length; i++) {
      let compiledExcelParamList = compiledExcelSet.CompiledExcelParamLists[i];

      if(true) {
        if(!compiledExcelParamList.excelUpdated) {
          continue;
        }
      } else {
        if(!compiledExcelParamList.excelUpdated && !unversioned) {
          continue;
        }
      }

      let outputsVersionControlled = null;
      let deviceId = compiledExcelParamList.DeviceId;
      deviceId = String(deviceId).padStart(5, `0`);

      if(!unversioned) {
        outputsVersionControlled = compiledExcelParamList.outputsVersion;
      }

      [
        codeGen.generateParameterListHumanReadableTxtFile,
        codeGen.generateParameterListInfoJson,
        codeGen.generateParameterListFlatJson,
        codeGen.generateParameterListCsFile,
      ].forEach((func) => {
        codeGenOutput = func(compiledExcelParamList, outputsVersionControlled);
        generateOutputFile(codeGenOutput, { deviceId: deviceId, version: outputsVersionControlled });
      });

      [
        codeGen.generateModbusParameterListCFile,
        codeGen.generateParameterListStructTypeHFile,
        codeGen.generateModbusParameterListHFile,
      ].forEach((func) => {
        codeGenOutput = func(compiledExcelParamList, compiledExcelParamList.outputsVersion);
        generateOutputFile(codeGenOutput, { deviceId: deviceId, version: outputsVersionControlled });
      });
    }
  });

  [
    true, /* => unversioned */
    false /* => versioned */
  ].forEach((unversioned) => {
    for(let i = 0; i < compiledExcelSet.CompiledExcelDeviceIds.length; i++) {
      let compiledExcelDeviceId = compiledExcelSet.CompiledExcelDeviceIds[i];

      if(true) {
        if(!compiledExcelDeviceId.excelUpdated) {
          continue;
        }
      } else {
        if(!compiledExcelDeviceId.excelUpdated && !unversioned) {
          continue;
        }
      }

      let outputsVersionControlled = null;

      if(!unversioned) {
        outputsVersionControlled = compiledExcelDeviceId.outputsVersion;
      }

      codeGenOutput = codeGen.generateModbusDatabaseHFile(compiledExcelDeviceId);
      generateOutputFile(codeGenOutput);

      codeGenOutput = codeGen.generateModbusDatabaseDeviceIdJsonFile(compiledExcelDeviceId);
      generateOutputFile(codeGenOutput, {dontCreateUnversionedSubfolder: true});

      codeGenOutput = codeGen.generateModbusDatabaseVirtualParametersIdJsonFile(compiledExcelDeviceId);
      generateOutputFile(codeGenOutput, {dontCreateUnversionedSubfolder: true});
    }
  });

  Object.keys(generateFiles.pathGrouped).forEach((path) => {
    let pathGroup = generateFiles.pathGrouped[path];
    codeGen.generateReadMeFiles(pathGroup);

    if(path.includes(`MetaData`)) {
      return;
    }

    [`c`, `cs`, `json`, `txt`].forEach((format) => {
      if(pathGroup[format].length === 0) {
        return;
      }

      generateOutputFile(pathGroup[format].readMeFile, { pathGroupedMdFilePath: path })
    });
  });

  toolBox.printGenericBanner(
    `CODE GENERATION DONE!`,
    {
      generateOutlines: true,
      backgroundColor: `green`,
      textColor: `white`,
    },
  );
}

function printDeveloperCoditionFlags () {
  if(appConfig.developer.onlyProcessOneDeviceExcel.enable) {
    toolBox.printGenericBanner(
      `Only processing the "${appConfig.developer.onlyProcessOneDeviceExcel.fileName}" param list (for testing)`,
      { generateOutlines: true, textColor: `yellow` },
    );
  }

  if(appConfig.developer.autoVersionIncrementDisabled) {
    toolBox.printGenericBanner(
      `Not incrementing output versions (for testing)`,
      { generateOutlines: true, textColor: `yellow` },
    );
  }

  if(appConfig.developer.doNotGenerateOutputFiles) {
    toolBox.printGenericBanner(
      `Disabling Output File Generation for Development`,
      { generateOutlines: true, textColor: `yellow` },
    );
  }
}

async function appInit() {
  windowZoom.init('Faraabin Modbus Parameters Code Gen');
  appVersionDisplay.init();

  printDeveloperCoditionFlags();

  if(await toolBox.isRunningOnDeveloperPc()) {
    let testCase = appConfig.developer.autoTestCase;
    let inputFolderPath  = `D:\\Work\\Faraabin\\sw_modbus_ext_code_generator\\Software\\Adib\\CodeGenTests V2\\Test Case ${testCase}`;
    let outputFolderPath = `D:\\Work\\Faraabin\\sw_modbus_ext_code_generator\\Software\\Adib\\CodeGenTests V2\\Test Case ${testCase}`;

    generateCodeGenOutputs(inputFolderPath, outputFolderPath);
  }

  document.querySelector(`.file-picker .pickBtn`).addEventListener('click', async () => {
    let folderPath = await personalExcelApi.selectFolder();

    if(!folderPath) {
      return;
    }

    document.querySelector(`.file-picker input`).value = folderPath;
  })

  document.querySelector(`.file-picker .generateBtn`).addEventListener('click', () => {
    console.clear();

    let folderPath = document.querySelector(`.file-picker input`).value;

    if(
      (!folderPath)
      || (!personalFileApi.systemPathExists(folderPath))
    ) {
      toolBox.printErrorBanner(`Inavlid input folder path`);
      return;
    }

    generateCodeGenOutputs(folderPath, folderPath);
  })
}

setTimeout(appInit, 200);

