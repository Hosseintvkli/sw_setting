/** @typedef {import('../../core/compiledExcel').CompiledExcelParamList} CompiledExcelParamList */
/** @typedef {import('../../core/compiledExcel').CompiledExcelDeviceId} CompiledExcelDeviceId */
/** @typedef {import('../../core/compiledExcel').CompiledExcelSet} CompiledExcelSet */

const { mode } = require('crypto-js');
const toolBox = require('../../../toolBox');
const codeGenCommon = require('../../helpers/codeGenCommon');

const TAB1 = `    `;
const TAB2 = TAB1.repeat(2);
const TAB3 = TAB1.repeat(3);
const TAB4 = TAB1.repeat(4);
const TAB5 = TAB1.repeat(5);
const TAB6 = TAB1.repeat(6);

function paramIsSettingOrMonitoringInfo (param) {
  if(codeGenCommon.modbusParameterListParameterRowIsSetting(param)) {
    return true;
  } else if(codeGenCommon.modbusParameterListParameterRowIsMonitoring(param)) {
    if(param.Group.value === `Info`) {
      return true;
    }
  }

  return false;
}

function generateModbusWriteFunctionCallPrimitive (
  type,
  name,
  arraySize,
  modbusAddr=`ModbusBaseAddr`,
  addrOffset=0
) {
  let modifiedName = name ? name[0].toLowerCase() + name.slice(1) : name;
  let isArray = arraySize !== 1;
  let isEnum = codeGenCommon.dataTypeIsEnum(type);

  if(isEnum) {
    type = `U16`;
  }

  let output = ``;
  
  output += `MainForm.modbusExt.ModbusWrite(`;
  output += `${modbusAddr}`;
  output += `, ${addrOffset}`;
  output += `, ${modifiedName}`;
  output += `, typeof(${codeGenCommon.excelDataTypeToCs(type)})`;
  output += `, ${arraySize})`;

  return output;
}

function generateModbusWriteFunctionCallStruct (
  type,
  name,
  arraySize,
  modbusAddr=`ModbusBaseAddr`,
  addrOffset=0,
  tabsString=``
) {
  let modifiedName = name ? name[0].toLowerCase() + name.slice(1) : name;
  let isArray = arraySize !== 1;

  let output = ``;

  if(isArray) {
    output += tabsString + `for (int i = 0; i < ${arraySize}; i++)\r\n`;
    output += tabsString + `{\r\n`;
    output += tabsString + TAB1;
    output += `${modifiedName}[i].ModbusWriteAll();\r\n`;
    output += tabsString + `}\r\n`;
  } else {
    output += tabsString + `_status &= `;
    output += `${modifiedName}.ModbusWriteAll();\r\n`;
  }

  return output;
}

function generateModbusReadFunctionCall (
  type,
  name,
  arraySize,
  modbusAddr=`ModbusBaseAddr`,
  addrOffset=0,
  tabsString=``
) {
  let modifiedName = name ? name[0].toLowerCase() + name.slice(1) : name;
  let isArray = arraySize !== 1;
  let isEnum = codeGenCommon.dataTypeIsEnum(type);

  if(isEnum) {
    type = `U16`;
  }

  let output = ``;

  if(codeGenCommon.dataTypeIsStruct(type)) {
    if(isArray) {
      output += tabsString + `for (int i = 0; i < ${arraySize}; i++)\r\n`;
      output += tabsString + `{\r\n`;
      output += tabsString + TAB1;
      output += `${modifiedName}[i].ModbusReadAll();\r\n`;
      output += tabsString + `}\r\n`;
    } else {
      output += tabsString;
      output += `${modifiedName}.ModbusReadAll();\r\n`;
    }
  } else {
    output += tabsString;
    output += `${modifiedName} = `;
    output += `MainForm.modbusExt.ModbusRead(`
    output += `${modbusAddr}`;
    output += `, ${addrOffset}`;
    output += `, typeof(${codeGenCommon.excelDataTypeToCs(type)})`;
    output += `, ${arraySize});`;
    output += `\r\n`;
  }

  return output;
}

function generateModbusButtonClickFunc (
  name,
  modbusAddr
) {
  let string = ``;

  string += toolBox.concatStringRows(
    TAB2 + `public void ${name}_Button_Click(object sender, EventArgs e)`,
    TAB2 + `{`,
    TAB2 + `    // Handle the button click`,
    TAB2 + `    MainForm.modbusExt.SetWaitCursor(true);`,
    TAB2 + ``,
    TAB2 + `    MainForm.modbusExt.ModbusWrite(${modbusAddr}, 0, (ushort)0xFFFF, typeof(UInt16), 1);`,
    TAB2 + ``,
    TAB2 + `    byte cnt = 0;`,
    TAB2 + `    while (true)`,
    TAB2 + `    {`,
    TAB2 + `        ushort result = MainForm.modbusExt.ModbusRead(${modbusAddr}, 0, typeof(UInt16), 1);`,
    TAB2 + ``,
    TAB2 + `        if (result != 0xFFFF)`,
    TAB2 + `        {`,
    TAB2 + `            if (result == 0)`,
    TAB2 + `            {`,
    TAB2 + `                MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);`,
    TAB2 + `            }`,
    TAB2 + `            else`,
    TAB2 + `            {`,
    TAB2 + `                MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);`,
    TAB2 + `            }`,
    TAB2 + `            break;`,
    TAB2 + `        }`,
    TAB2 + ``,
    TAB2 + `        Thread.Sleep(500);`,
    TAB2 + ``,
    TAB2 + `        if (cnt++ > 20)`,
    TAB2 + `        {`,
    TAB2 + `            MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);`,
    TAB2 + `            break;`,
    TAB2 + `        }`,
    TAB2 + `    }`,
    TAB2 + `    MainForm.modbusExt.SetWaitCursor(false);`,
    TAB2 + `}`,
  );

  return string;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateParameterListCsFileHeader (model, outputsVersion=null) {
  let output = ``;

  output += toolBox.concatStringRows(
    `using System;`,
    `using System.ComponentModel;`,
    `using System.Drawing;`,
    `using System.Windows.Forms;`,
    `using System.Collections.Generic;`,
    `using System.Linq;`,
    `using System.Text;`,
    `using System.Threading;`,
    `using System.Threading.Tasks;`,
    ``,
    `/*`,
    `╔${`═`.repeat(model.fileName.length + 2)}╗`,
    `║ ${model.fileName} ║`,
    `╚${`═`.repeat(model.fileName.length + 2)}╝`,
    `*/`,
    ``,
    `namespace ACCUNAV_IMU_Setting`,
    `{`,
    `    [DefaultProperty("SerialNo")]`,
    `    public class ${codeGenCommon.generateCsClassName(model, outputsVersion)} : IParameterListDevice`,
    `    {`,
  );

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateParameterListCsFileDeviceClassFields (model) {
  let output = ``;

  function generateClassField (paramaeter) {
    let type = paramaeter.DataType.value;
    let name = paramaeter.Name.value;
    let isEnum = codeGenCommon.dataTypeIsEnum(type);
    let arraySize = paramaeter.ArraySize.value;
    
    let rowString = ``;
    let isArray = arraySize !== 1;

    let modifiedName = name ? name[0].toLowerCase() + name.slice(1) : name;

    if(isEnum) {
      type = `U16`;
    }

    rowString += `public `;
    rowString += codeGenCommon.excelDataTypeToCs(type);
    rowString += isArray ? `[]` : ``;
    rowString += ` ${modifiedName};`;

    return rowString;
  }

  output += toolBox.concatStringRows(
    TAB2 + `private bool readedOnce;`,
    ``,
  );

  model.parameterListFilteredEmptyRows
    .filter((row) => !codeGenCommon.paramIsIgnoredByModbus(row))
    .forEach((row) => {
    if(paramIsSettingOrMonitoringInfo(row)) {
      output += TAB2 + generateClassField(row) + `\r\n`;
    }
  });

  output += `\r\n`;

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateParameterListCsFileDeviceClassConstructor (
  model,
  outputsVersion=null
) {
  let output = ``;
  let prevFieldHadForLoopInit = false;

  const generateClassConstructorFieldInit = (
    paramaeter,
  ) => {
    let type = paramaeter.DataType.value;
    if(codeGenCommon.dataTypeIsEnum(type)) {
      type = `U16`;
    }
    let typeCs = codeGenCommon.excelDataTypeToCs(type);
    let name = paramaeter.Name.value;
    let arraySize = paramaeter.ArraySize.value;
    let modbusAddr = paramaeter.ModbusAddr.value;
    let defaultValue = codeGenCommon.getParameterDefaultValue(paramaeter);
    let dataTypeSize = model.dataTypeSizes[type];
    let thisFieldHasForLoopInit = false;

    let rowString = ``;
    let isArray = arraySize !== 1;
    let modifiedName = name ? name[0].toLowerCase() + name.slice(1) : name;

    if(isNaN(defaultValue) || !defaultValue) {
      defaultValue = 0;
    }

    if(isArray) {
      if(!codeGenCommon.dataTypeIsStruct(type)) {
        rowString += TAB3;
        rowString += `${modifiedName} = new ${typeCs}[${arraySize}];`;
      } else {
        if(!prevFieldHadForLoopInit) {
          rowString += `\r\n`
        }
        rowString += TAB3;
        rowString += `${modifiedName} = new ${type}[${arraySize}];`;
        rowString += `\r\n`
        rowString += toolBox.concatStringRows(
          TAB3 + `for (UInt16 i = 0; i < ${arraySize}; i++)`,
          TAB3 + `{`,
          TAB4 + `${modifiedName}[i] = new ${type}((UInt16)(${modbusAddr} + (${dataTypeSize} * i)));`,
          TAB3 + `}`,
        );

        thisFieldHasForLoopInit = true;
      }
    } else {
      rowString += TAB3 + `${modifiedName} = `;
      if(!codeGenCommon.dataTypeIsStruct(type)) {
        rowString += `${defaultValue};`;
      } else {
        rowString += `new ${type}((UInt16)(${modbusAddr}));`;
      }
    }

    prevFieldHadForLoopInit = thisFieldHasForLoopInit;

    rowString += `\r\n`
    
    return rowString;
  }

  output += toolBox.concatStringRows(
    TAB2 + `public ${codeGenCommon.generateCsClassName(model, outputsVersion)}()`,
    TAB2 + `{`,
    TAB3 + `readedOnce = false;`,
    TAB2 + ``,
  );

  model.parameterListFilteredEmptyRows
    .filter((row) => !codeGenCommon.paramIsIgnoredByModbus(row))
    .forEach((row) => {
    if(paramIsSettingOrMonitoringInfo(row)) {
      output += generateClassConstructorFieldInit(row);
    }
  });

  output += toolBox.concatStringRows(
    TAB2 + `}`,
    ``,
  )

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateParameterListCsFileDeviceClassFieldsSetterGetters (model) {
  let output = ``;
  
  function generateClassFieldSetGet (
    type,
    name,
    arraySize,
    parameterType,
    group,
    description,
    defaultValue=null,
    modbusAddr
  ) {
    let sectionString = ``;
    let isArray = arraySize !== 1;
    let isEnum = codeGenCommon.dataTypeIsEnum(type);
    let modifiedName = name ? name[0].toLowerCase() + name.slice(1) : name;
    let isReadOnly = codeGenCommon.modbusParameterListParameterRowIsMonitoring({ParameterType: {value: parameterType}});
    const resultAddReturn = () => { sectionString += `\r\n`; }

    if(!codeGenCommon.modbusParameterListParameterRowIsSetting({ParameterType: {value: parameterType}})) {
      return ``;
    }
    
    /*
    ╔═════════════════════════════════════════════════════════════════════════════════════════╗
    ║ Guide ----------------------------------------------------------------------------------║
    ╠═════════════════════════════════════════════════════════════════════════════════════════╣
    ║ [Category("Monitoring"), ReadOnly(true), DefaultValue(0), Description("MFH Device ID")] ║
    ╚═════════════════════════════════════════════════════════════════════════════════════════╝
    */

    sectionString += TAB2;
    sectionString += `[`;

    sectionString += `Category("${group}"), `;

    sectionString += `ReadOnly(${isReadOnly})`;

    if(!isArray && codeGenCommon.excelDataTypeIsPrimitive(type)) {
      if(isNaN(defaultValue)) {
        defaultValue = 0;
      }
      
      sectionString += `, `;
      sectionString += `DefaultValue(${defaultValue})`;
    }

    sectionString += `, `;
    sectionString += `Description("${description || ``}")`;
    sectionString += `]`;
    resultAddReturn();

    sectionString += TAB2;
    sectionString += `public `;
    sectionString += codeGenCommon.excelDataTypeToCs(type) + (isArray ? `[]` : ``);
    sectionString += ` ${name}`;
    resultAddReturn();

    sectionString += TAB2;
    sectionString += `{`;
    resultAddReturn();
    
    if(!isEnum) {
      sectionString += TAB3;
      sectionString += `get { return ${modifiedName}; }`;
      resultAddReturn();

      sectionString += toolBox.concatStringRows(
        TAB3 + `set`,
        TAB3 + `{`,
        TAB4 + `if(${generateModbusWriteFunctionCallPrimitive(type, `value`, arraySize, modbusAddr)})`,
        TAB4 + `{`,
        TAB5 + `${modifiedName} = value;`,
      );

      if(modifiedName === `serialNo`) {
        sectionString += toolBox.concatStringRows(
          TAB5 + `MainForm.modbusExt.RefreshDeviceSerialNoInfo(serialNo);`,
        );
      }

      sectionString += toolBox.concatStringRows(
        TAB4 + `}`,
        TAB3 + `}`,
      );
    } else {
      if(isArray) {
        sectionString += toolBox.concatStringRows(
          TAB3 + `get`,
          TAB3 + `{`,
          TAB4 + `${type}[] propView = new ${type}[${arraySize}];`,
          TAB4 + `for (UInt16 i = 0; i < ${arraySize}; i++)`,
          TAB4 + `{`,
          TAB5 + `propView[i] = (${type})${modifiedName}[i];`,
          TAB4 + `}`,
          TAB4 + `return propView;`,
          TAB3 + `}`,
        );

        sectionString += toolBox.concatStringRows(
          TAB3 + `set`,
          TAB3 + `{`,
          TAB4 + `UInt16[] propViewOut = new UInt16[${arraySize}];`,
          TAB4 + `for (UInt16 i = 0; i < ${arraySize}; i++)`,
          TAB4 + `{`,
          TAB5 + `propViewOut[i] = (UInt16)value[i];`,
          TAB4 + `}`,
          ``,
          TAB4 + `if(${generateModbusWriteFunctionCallPrimitive(`ushort`, `propViewOut`, arraySize, modbusAddr)})`,
          TAB4 + `{`,
          TAB5 + `${modifiedName} = propViewOut;`,
          TAB4 + `}`,
          TAB3 + `}`,
        );
      } else {
        sectionString += toolBox.concatStringRows(
          TAB3 + `get`,
          TAB3 + `{`,
          TAB4 + `return (${type})${modifiedName};`,
          TAB3 + `}`,
        );

        sectionString += toolBox.concatStringRows(
          TAB3 + `set`,
          TAB3 + `{`,
          TAB4 + `if(${generateModbusWriteFunctionCallPrimitive(`ushort`, `(UInt16)value`, arraySize, modbusAddr)})`,
          TAB4 + `{`,
          TAB5 + `${modifiedName} = (UInt16)value;`,
          TAB4 + `}`,
          TAB3 + `}`,
        );
      }
    }
    
    sectionString += toolBox.concatStringRows(
      TAB2 + `}`,
      ``,
    );

    return sectionString;
  }

  model.parameterListFilteredEmptyRows
    .filter((row) => !codeGenCommon.paramIsIgnoredByModbus(row))
    .forEach((row) => {
    if(paramIsSettingOrMonitoringInfo(row)) {
      output += generateClassFieldSetGet(
        row.DataType.value,
        row.Name.value,
        row.ArraySize.value,
        row.ParameterType.value,
        row.Group.value,
        row.Description.value,
        codeGenCommon.getParameterDefaultValue(row),
        row.ModbusAddr.value
      );
    }
  });

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateParameterListCsFileFooter (model) {
  let output = ``;

  output += toolBox.concatStringRows(
    `    }`,
    `}`,
  );

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateParameterListCsFileDeviceClassModbusWriteAll (model) {
  let output = ``;
  let lastOneWasForLoop = false;
  
  output += toolBox.concatStringRows(
    TAB2 + `public bool ModbusWriteAll()`,
    TAB2 + `{`,
    TAB3 + `bool _status = true;`,
    TAB2 + ``,
  );

  model.parameterListFilteredEmptyRows
    .filter((row) => !codeGenCommon.paramIsIgnoredByModbus(row))
    .forEach((row) => {
    if(!codeGenCommon.modbusParameterListParameterRowIsSetting(row)) {
      return;
    }

    let isArray = row.ArraySize.value !== 1;
    let isStruct = codeGenCommon.dataTypeIsStruct(row.DataType.value);
    let thisOneIsForLoop = isArray && isStruct;

    if(thisOneIsForLoop || lastOneWasForLoop) {
      output += `\r\n`;
    }

    lastOneWasForLoop = thisOneIsForLoop;

    if(codeGenCommon.dataTypeIsStruct(row.DataType.value)) {
      output += generateModbusWriteFunctionCallStruct(
        row.DataType.value,
        row.Name.value,
        row.ArraySize.value,
        row.ModbusAddr.value,
        0,
        TAB3
      );
    } else {
      output += TAB3 + `_status &= `;

      output += generateModbusWriteFunctionCallPrimitive(
        row.DataType.value,
        row.Name.value,
        row.ArraySize.value,
        row.ModbusAddr.value
      );

      output += `;\r\n`;
    }
  });

  output += toolBox.concatStringRows(
    TAB3 + ``,
    TAB3 + `if (!_status)`,
    TAB3 + `{`,
    TAB4 + `MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);`,
    TAB3 + `}`,
    TAB3 + `return _status;`,
    TAB2 + `}`,
    ``,
  );

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateParameterListCsFileDeviceClassModbusReadAll (model) {
  let output = ``;
  let lastOneWasForLoop = false;
  
  output += toolBox.concatStringRows(
    TAB2 + `public void ModbusReadAll()`,
    TAB2 + `{`,
    TAB3 + `if (readedOnce){return;} else`,
    TAB3 + `{`,
  );

  model.parameterListFilteredEmptyRows
    .filter((row) => !codeGenCommon.paramIsIgnoredByModbus(row))
    .forEach((row) => {
    if(codeGenCommon.modbusParameterListParameterRowIsCommand(row)) {
      return;
    }
    
    if(paramIsSettingOrMonitoringInfo(row)) {
      let isArray = row.ArraySize.value !== 1;
      let isStruct = codeGenCommon.dataTypeIsStruct(row.DataType.value);
      let thisOneIsForLoop = isArray && isStruct;

      if(thisOneIsForLoop || lastOneWasForLoop) {
        output += `\r\n`;
      }

      lastOneWasForLoop = thisOneIsForLoop;
      
      output += generateModbusReadFunctionCall(
        row.DataType.value,
        row.Name.value,
        row.ArraySize.value,
        row.ModbusAddr.value,
        0,
        TAB4
      );
    }
  });
  
  output += toolBox.concatStringRows(
    TAB3 + ``,
    TAB4 + `readedOnce = true;`,
    TAB3 + `}`,
    TAB2 + `}`,
    ``,
  );

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateParameterListCsFileDeviceClassResetReadFlag (model) {
  let output = ``;

  output += toolBox.concatStringRows(
    TAB2 + `public void ResetReadFlag()`,
    TAB2 + `{`,
    TAB3 + `readedOnce = false;`,
    TAB2 + `}`,
    ``,
  );

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateParameterListCsFileDeviceClassReloadButtonClickFunction (model) {
  let output = ``;

  output += toolBox.concatStringRows(
    TAB2 + `public void Reload_Button_Click(object sender, EventArgs e)`,
    TAB2 + `{`,
    TAB3 + `// Handle the button click`,
    TAB3 + `MainForm.modbusExt.SetWaitCursor(true);`,
    TAB3 + ``,
    TAB3 + `readedOnce = false;`,
    TAB3 + `ModbusReadAll();`,
    TAB3 + `MainForm.modbusExt.RefreshDevicePropertyGrid();`,
    TAB3 + ``,
    TAB3 + `MainForm.modbusExt.SetWaitCursor(false);`,
    TAB2 + `}`,
    ``,
  );

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateParameterListCsFileDeviceClassButtonClickFunctions (model) {
  let output = ``;

  model.parameterListFilteredEmptyRows
    .filter((row) => !codeGenCommon.paramIsIgnoredByModbus(row))
    .forEach((row) => {
    if(!codeGenCommon.modbusParameterListParameterRowIsCommand(row)) {
      return;
    }
    
    output += generateModbusButtonClickFunc(
      row.Name.value,
      row.ModbusAddr.value
    );

    output += `\r\n`;
  });

  return output;
}

function generateParameterListCsFileDeviceStructClassHeader (structName) {
  let output = ``;

  output += toolBox.concatStringRows(
    TAB2 + `[TypeConverter(typeof(ExpandableObjectConverter))]`,
    TAB2 + `public class ${structName}`,
    TAB2 + `{`,
  );

  return output;
}

function generateParameterListCsFileDeviceStructClassFields (sheet) {
  let output = ``;

  function generateStructMember (type, modifiedName, arraySize, isPublic=true) {
    let string = TAB3;
    let isArray = arraySize !== 1;
    let isEnum = codeGenCommon.dataTypeIsEnum(type);

    string += isPublic ? `public ` : `private `;
    
    if(isEnum) {
      type = `U16`;
    }

    string += codeGenCommon.excelDataTypeToCs(type);
    string += isArray ? `[]` : ``;
    string += ` ${modifiedName};`;
    string += `\r\n`;

    return string;
  }
  
  sheet
    .filter((row) => !codeGenCommon.paramIsIgnoredByModbus(row))
    .forEach((row) => {
    if(!row.DataType.value) {
      return;
    }

    if(codeGenCommon.parameterListRowIsReserved(row)) {
      return;
    }

    let modifiedName = toolBox.lowerCaseFirstLetter(row.Name.value);

    output += generateStructMember(
      row.DataType.value,
      modifiedName,
      row.ArraySize.value,
    );
  });

  output += `\r\n`;

  output += generateStructMember(
    `U16`,
    `ModbusBaseAddr`,
    1,
    false
  );

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateParameterListCsFileDeviceStructClassConstructor (model, sheetName, sheet) {
  let output = ``;
  let lastFieldWasNonPrimitiveArray = false

  function generateStructureConstructorMemeber (
    type,
    name,
    arraySize,
    defaultValue=null,
    modbusAddr=null
  ) {
    let string = ``;
    let isArray = arraySize !== 1;
    let thisFieldIsNonPrimitiveArray = false;
    
    if(codeGenCommon.dataTypeIsEnum(type)) {
      type = `U16`;
    }

    if(isArray) {
      if(codeGenCommon.excelDataTypeIsPrimitive(type)) {
        string += TAB4;
        string += `${name} = new ${codeGenCommon.excelDataTypeToCs(type)}[${arraySize}];`;
      } else {
        thisFieldIsNonPrimitiveArray = true;

        if(!lastFieldWasNonPrimitiveArray) {
          string += `\r\n`
        }
        string += TAB4;
        string += `${name} = new ${type}[${arraySize}];`;
        string += `\r\n`
        string += toolBox.concatStringRows(
          TAB4 + `for (UInt16 i = 0; i < ${arraySize}; i++)`,
          TAB4 + `{`,
          TAB5 + `${name}[i] = new ${type}((UInt16)(${modbusAddr} + (${model.dataTypeSizes[type]} * i)));`,
          TAB4 + `}`,
        );
      }
    } else {
      string += TAB4;

      if(!codeGenCommon.dataTypeIsStruct(type)) {
        if(true) {
          string += `${name} = ${defaultValue};`;
        } else {
          if(defaultValue === `ModbusBaseAddr`) {
            string += `${name} = ModbusBaseAddr;`;
          } else {
            string += `${name} = 0;`;
          }
        }
      } else {
        string += `${name} = new ${type}((UInt16)(${modbusAddr}));`;
      }
    }

    lastFieldWasNonPrimitiveArray = thisFieldIsNonPrimitiveArray;

    string += `\r\n`;

    return string;
  }

  output += toolBox.concatStringRows(
    TAB3 + ``,
    TAB3 + `public ${sheetName}(UInt16 ObjectModbusBaseAddr)`,
    TAB3 + `{`,
  );
  
  output += generateStructureConstructorMemeber(
    `U16`,
    `ModbusBaseAddr`,
    1,
    `ObjectModbusBaseAddr`,
  );

  output += `\r\n`;
  
  sheet
    .filter((row) => !codeGenCommon.paramIsIgnoredByModbus(row))
    .forEach((row) => {
    if(!(row.DataType.value)) {
      return;
    }

    if(codeGenCommon.parameterListRowIsReserved(row)) {
      return;
    }

    let modifiedName = toolBox.lowerCaseFirstLetter(row.Name.value);

    output += generateStructureConstructorMemeber(
      row.DataType.value,
      modifiedName,
      row.ArraySize.value,
      0, // row.DefaultValue.value ? row.DefaultValue.value : 0,
      `ModbusBaseAddr + ${row.Addr.value}`
    );
  });
  
  output += toolBox.concatStringRows(
    TAB3 + `}`,
    ``,
  );

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateParameterListCsFileDeviceStructClassFieldsSetterGetters (sheet) {
  let output = ``;

  function generateStructMemberSetGet (type, name, arraySize, addrOffset) {
    let string = ``;
    const resultAddReturn = () => { string += `\r\n`; }

    let isArray = arraySize !== 1;
    let isEnum = codeGenCommon.dataTypeIsEnum(type);
    let modifiedName = name ? name[0].toLowerCase() + name.slice(1) : name;

    string += TAB3 + `public `;
    string += codeGenCommon.excelDataTypeToCs(type);
    string += isArray ? `[]` : ``;
    string += ` ${name}`;
    resultAddReturn();
    
    string += TAB3 + `{`;
    resultAddReturn();
    
    if(!isEnum) {
      string += TAB4 + `get { return ${modifiedName}; }`;
      resultAddReturn();
      
      string += toolBox.concatStringRows(
        TAB4 + `set`,
        TAB4 + `{`,
        TAB5 + `if(${generateModbusWriteFunctionCallPrimitive(type, `value`, arraySize, `ModbusBaseAddr`, addrOffset)})`,
        TAB5 + `{`,
        TAB6 + `${modifiedName} = value;`,
        TAB5 + `}`,
        TAB4 + `}`,
      );
    } else {
      if(isArray) {
        string += toolBox.concatStringRows(
          TAB4 + `get`,
          TAB4 + `{`,
          TAB5 + `${type}[] propView = new ${type}[${arraySize}];`,
          TAB5 + `for (UInt16 i = 0; i < ${arraySize}; i++)`,
          TAB5 + `{`,
          TAB6 + `propView[i] = (${type})${modifiedName}[i];`,
          TAB5 + `}`,
          TAB5 + `return propView;`,
          TAB4 + `}`,
        );

        string += toolBox.concatStringRows(
          TAB4 + `set`,
          TAB4 + `{`,
          TAB5 + `UInt16[] propViewOut = new UInt16[${arraySize}];`,
          TAB5 + `for (UInt16 i = 0; i < ${arraySize}; i++)`,
          TAB5 + `{`,
          TAB6 + `propViewOut[i] = (UInt16)value[i];`,
          TAB5 + `}`,
          ``,
          TAB5 + `if(${generateModbusWriteFunctionCallPrimitive(`ushort`, `propViewOut`, arraySize, `ModbusBaseAddr`, addrOffset)})`,
          TAB5 + `{`,
          TAB6 + `${modifiedName} = propViewOut;`,
          TAB5 + `}`,
          TAB4 + `}`,
        );
      } else {
        string += toolBox.concatStringRows(
          TAB4 + `get`,
          TAB4 + `{`,
          TAB5 + `return (${type})${modifiedName};`,
          TAB4 + `}`,
        );

        string += toolBox.concatStringRows(
          TAB4 + `set`,
          TAB4 + `{`,
          TAB5 + `if(${generateModbusWriteFunctionCallPrimitive(`ushort`, `(UInt16)value`, arraySize, `ModbusBaseAddr`, addrOffset)})`,
          TAB5 + `{`,
          TAB6 + `${modifiedName} = (UInt16)value;`,
          TAB5 + `}`,
          TAB4 + `}`,
        );
      }
    }
    
    string += toolBox.concatStringRows(
      TAB3 + `}`,
    );

    return string;
  }

  sheet
    .filter((row) => !codeGenCommon.paramIsIgnoredByModbus(row))
    .forEach((row) => {
    if(!row.DataType.value) {
      return;
    }

    if(codeGenCommon.parameterListRowIsReserved(row)) {
      return;
    }

    output += generateStructMemberSetGet(
      row.DataType.value,
      row.Name.value,
      row.ArraySize.value,
      row.Addr.value,
    );

    output += `\r\n`;
  });

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateParameterListCsFileDeviceStructClassWriteAll (sheet) {
  let output = ``;
  let lastOneWasForLoop = false;
  
  output += toolBox.concatStringRows(
    TAB3 + `public bool ModbusWriteAll()`,
    TAB3 + `{`,
    TAB4 + `bool _status = true;`,
    TAB3 + ``,
  );

  sheet
    .filter((row) => !codeGenCommon.paramIsIgnoredByModbus(row))
    .forEach((row) => {
    if(!row.DataType.value) {
      return;
    }

    if(codeGenCommon.parameterListRowIsReserved(row)) {
      return;
    }

    let modifiedName = toolBox.lowerCaseFirstLetter(row.Name.value);
    let isArray = row.ArraySize.value !== 1;
    let isStruct = codeGenCommon.dataTypeIsStruct(row.DataType.value);
    let thisOneIsForLoop = isArray && isStruct;

    if(thisOneIsForLoop || lastOneWasForLoop) {
      output += `\r\n`;
    }

    lastOneWasForLoop = thisOneIsForLoop;

    if(codeGenCommon.dataTypeIsStruct(row.DataType.value)) {
      output += generateModbusWriteFunctionCallStruct(
        row.DataType.value,  /* type */
        modifiedName,        /* modifiedName */
        row.ArraySize.value, /* arraySize */
        `ModbusBaseAddr`,
        row.Addr.value,      /* addrOffset */
        TAB4
      );
    } else {
      output += TAB4 + `_status &=  `;
      output += generateModbusWriteFunctionCallPrimitive(
        row.DataType.value,  /* type */
        modifiedName,        /* modifiedName */
        row.ArraySize.value, /* arraySize */
        `ModbusBaseAddr`,
        row.Addr.value,      /* addrOffset */
      );

      output += `;\r\n`;
    }
  });

  output += toolBox.concatStringRows(
    TAB4 + ``,
    TAB4 + `if (!_status)`,
    TAB4 + `{`,
    TAB5 + `MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);`,
    TAB4 + `}`,
    TAB4 + `return _status;`,
    TAB3 + `}`,
    ``,
  );

  return output;
}

function generateParameterListCsFileDeviceStructClassReadAll (sheet) {
  let output = ``;
  let lastOneWasForLoop = false;
  
  output += toolBox.concatStringRows(
    TAB3 + `public void ModbusReadAll()`,
    TAB3 + `{`,
  );

  sheet
    .filter((row) => !codeGenCommon.paramIsIgnoredByModbus(row))
    .forEach((row) => {
    if(!row.DataType.value) {
      return;
    }

    if(codeGenCommon.parameterListRowIsReserved(row)) {
      return;
    }

    let modifiedName = toolBox.lowerCaseFirstLetter(row.Name.value);

    let isArray = row.ArraySize.value !== 1;
    let isStruct = codeGenCommon.dataTypeIsStruct(row.DataType.value);
    let thisOneIsForLoop = isArray && isStruct;

    if(thisOneIsForLoop || lastOneWasForLoop) {
      output += `\r\n`;
    }

    lastOneWasForLoop = thisOneIsForLoop;

    output += generateModbusReadFunctionCall(
      row.DataType.value,  /* type */
      modifiedName,        /* modifiedName */
      row.ArraySize.value, /* arraySize */
      `ModbusBaseAddr`,    /* modbusAddr */
      row.Addr.value,      /* addrOffset */
      TAB4
    );
  });

  output += toolBox.concatStringRows(
    TAB3 + `}`,
  );

  return output;
}

function generateParameterListCsFileDeviceStructClassFooter (structName) {
  let output = ``;

  output += toolBox.concatStringRows(
    TAB2 + `}`,
    ``,
  );

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateParameterListCsFileDeviceStructClasses (model) {
  let output = ``;

  Object.keys(model.StructTypeSheets).forEach((sheetName) => {
    let sheet = model.StructTypeSheets[sheetName];

    output += generateParameterListCsFileDeviceStructClassHeader(sheetName);
    output += generateParameterListCsFileDeviceStructClassFields(sheet);

    output += `\r\n`;
    output += TAB3;
    output += `public static UInt16 ModbusSize = ${model.dataTypeSizes[sheetName]};`;
    output += ` // VarTypeSize in excel`;
    output += `\r\n`;
    
    output += generateParameterListCsFileDeviceStructClassConstructor(model, sheetName, sheet);
    output += generateParameterListCsFileDeviceStructClassFieldsSetterGetters(sheet);
    output += generateParameterListCsFileDeviceStructClassWriteAll(sheet);
    output += generateParameterListCsFileDeviceStructClassReadAll(sheet);
    output += generateParameterListCsFileDeviceStructClassFooter(sheetName);
  });

  return output;
}

function generateParameterListCsFileDeviceEnumTypeHeader (sheetName) {
  let output = ``;

  output += toolBox.concatStringRows(
    TAB2 + `public enum ${sheetName} : ushort`,
    TAB2 + `{`,
  );

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateParameterListCsFileDeviceEnumTypeItems (model, sheetName, sheet) {
  let output = ``;

  let targetRows = sheet.filter((row) => !row.isVirtualParameterId);

  targetRows.forEach((row, index) => {
    let name = row.Name.value;
    let value = row.Value.value;
    let description = row.Description.value;

    let isLast = index === (targetRows.length - 1);

    name = name.replace(/[.\[\]]+/g, `_`);
    name = name.replace("__CODE_GEN_FORGED_VAR_", "_");

    output += TAB3 + `${name} = ${value}`;
    if(!isLast) {
      output += `,`;
    }

    if(description) {
      output += ` /* ${description} */`;
    }

    output += `\r\n`;
  });

  return output;
}

function generateParameterListCsFileDeviceEnumTypeFooter () {
  let output = ``;
  
  output += toolBox.concatStringRows(
    TAB2 + `}`,
  );

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
function generateParameterListCsFileDeviceEnumTypes (model) {
  let output = ``;

  let enumSheetNames = Object.keys(model.EnumTypeSheets);
  let forgedEnumSheetNames = Object.keys(model.forgedEnumTypeSheets);

  [
    ...enumSheetNames,
    ...forgedEnumSheetNames
  ].forEach((sheetName, index) => {
    let sheet = model.EnumTypeSheets[sheetName] || model.forgedEnumTypeSheets[sheetName];

    let isLast = index === enumSheetNames.length + forgedEnumSheetNames.length - 1;
    let extraRow = [];

    if(sheetName === `eParameterId`) {
      extraRow.push(
        {
          Name        : { value: `NONE` },
          Value       : { value: 65535 },
          Description : { value: null },
        }
      );
    }

    output += generateParameterListCsFileDeviceEnumTypeHeader(sheetName);
    output += generateParameterListCsFileDeviceEnumTypeItems(model, sheetName, [...sheet, ...extraRow]);
    output += generateParameterListCsFileDeviceEnumTypeFooter();

    if(!isLast) {
      output += `\r\n`;
    }
  });

  return output;
}

/**
 * @param {CompiledExcelParamList} model
 */
module.exports = function generateParameterListCsFile(model, outputsVersion=null) {
  let output = ``;
  let fileName = ``;

  output += generateParameterListCsFileHeader(model, outputsVersion);
  output += generateParameterListCsFileDeviceClassFields(model, outputsVersion);
  output += generateParameterListCsFileDeviceClassConstructor(model, outputsVersion);
  output += generateParameterListCsFileDeviceClassFieldsSetterGetters(model, outputsVersion);
  output += generateParameterListCsFileDeviceClassModbusWriteAll(model, outputsVersion);
  output += generateParameterListCsFileDeviceClassModbusReadAll(model, outputsVersion);
  output += generateParameterListCsFileDeviceClassResetReadFlag(model, outputsVersion);
  output += generateParameterListCsFileDeviceClassReloadButtonClickFunction(model, outputsVersion);
  output += generateParameterListCsFileDeviceClassButtonClickFunctions(model, outputsVersion);
  output += generateParameterListCsFileDeviceStructClasses(model, outputsVersion);
  output += generateParameterListCsFileDeviceEnumTypes(model, outputsVersion);
  output += generateParameterListCsFileFooter(model, outputsVersion);
  output += `\r\n`;

  fileName += codeGenCommon.generateDeviceIdFileName(
    model.DeviceId,
    `cg_parameter_list_`,
    `.cs`,
    outputsVersion
  );

  return {
    fileName: fileName,
    fileContent: output,
    fileType: `C#`
  };
}

