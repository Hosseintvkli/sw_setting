'use strict';

function randomRange(min, max) {
	return Math.floor(Math.random() * (max - min + 1)) + min;
}

function mapValue(inValue, inMin, inMax, outMin, outMax) {
  return (inValue - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
}

function constrainValue(inValue, min, max) {
  if(inValue < min) {
    return min;
  }
  
  if(inValue > max) {
    return max;
  }
  
  return inValue;
}

function toHexString(byteArray, separator='') {
  return Array.from(byteArray, (byte) => {
    return ('0' + (byte & 0xFF).toString(16)).slice(-2).toUpperCase();
  }).join(separator)
}

function fromHexString(hexString, separator='') {
  hexString = hexString.split(separator).join('');
  
  return ([...Uint8Array.from(
    hexString.match(/.{1,2}/g).map((byte) => parseInt(byte, 16))
  )]);
}

function array4ToFloat32(array4, littleEndian=true) {
  if(!littleEndian) {
    array4.reverse();
  }

  let uint8Array = new Uint8Array(array4);
  let result = (new Float32Array(uint8Array.buffer))[0];

  return result;
}

function array8ToFloat64(array8, littleEndian=true) {
  if(!littleEndian) {
    array8.reverse();
  }

  let uint8Array = new Uint8Array(array8);
  let result = (new Float64Array(uint8Array.buffer))[0];

  return result;
}

function float32ToArray4(float32, littleEndian=true) {
  let float32Buffer = new Float32Array([float32]);
  let resultArray = (new Uint8Array(float32Buffer.buffer));

  if(!littleEndian) {
    resultArray.reverse();
  }

  return [...resultArray];
}

function float64ToArray8(float64, littleEndian=true) {
  let float64Buffer = new Float64Array([float64]);
  let resultArray = (new Uint8Array(float64Buffer.buffer));

  if(!littleEndian) {
    resultArray.reverse();
  }

  return [...resultArray];
}

// function arrayToInt(arr, signed=false, littleEndian=true) {
//   let size = arr.length;
//   let uint8Array = new Uint8Array(arr);
//   let result;

//   if(!littleEndian) {
//     uint8Array.reverse();
//   }
  
//   if(signed) {
//     if(size <= 1) {
//       result = (new Int8Array(uint8Array.buffer))[0];
//     } else if(size <= 2) {
//       result = (new Int16Array(uint8Array.buffer))[0];
//     } else if(size <= 4) {
//       result = (new Int32Array(uint8Array.buffer))[0];
//     } else if(size <= 8) {
//       throw new Error(`"intToArray: size = ${size}", is not supported`);
//     }
//   } else {
//     if(size <= 1) {
//       result = (new Uint8Array(uint8Array.buffer))[0];
//     } else if(size <= 2) {
//       result = (new Uint16Array(uint8Array.buffer))[0];
//     } else if(size <= 4) {
//       result = (new Uint32Array(uint8Array.buffer))[0];
//     } else if(size <= 8) {
//       throw new Error(`"intToArray: size = ${size}", is not supported`);
//     }
//   }

//   return result;
// }

function arrayToInt(arr, signed = false, littleEndian = true) {
  const size = arr.length;
  if (size < 1 || size > 8) {
    throw new Error(`arrayToInt: size = ${size} is not supported (1–8 only)`);
  }

  const uint8Array = new Uint8Array(arr);
  if (!littleEndian) uint8Array.reverse();

  // Use DataView for 1–4 bytes
  if (size <= 4) {
    const view = new DataView(uint8Array.buffer);
    switch (size) {
      case 1: return signed ? view.getInt8(0) : view.getUint8(0);
      case 2: return signed ? view.getInt16(0, true) : view.getUint16(0, true);
      case 4: return signed ? view.getInt32(0, true) : view.getUint32(0, true);
    }
  }

  // Handle 5–8 bytes with BigInt
  let result = 0n;
  for (let i = 0; i < size; i++) {
    result |= BigInt(uint8Array[i]) << BigInt(8 * i);
  }

  if (signed) {
    const signBit = 1n << (BigInt(size) * 8n - 1n);
    if (result & signBit) {
      // Convert from two's complement
      const mask = (1n << (BigInt(size) * 8n));
      result = result - mask;
    }
  }

  return result;
}

// function intToArray(num, size, signed=false, littleEndian=true) {
//   let refArray;
//   let result;
  
//   if(signed) {
//     if(size <= 1) {
//       refArray = new Int8Array([num]);
//     } else if(size <= 2) {
//       refArray = new Int16Array([num]);
//     } else if(size <= 4) {
//       refArray = new Int32Array([num]);
//     } else if(size <= 8) {
//       throw new Error(`"intToArray: size = ${size}", is not supported`);
//     }
//   } else {
//     if(size <= 1) {
//       refArray = new Uint8Array([num]);
//     } else if(size <= 2) {
//       refArray = new Uint16Array([num]);
//     } else if(size <= 4) {
//       refArray = new Uint32Array([num]);
//     } else if(size <= 8) {
//       throw new Error(`"intToArray: size = ${size}", is not supported`);
//     }
//   }

//   result = new Uint8Array(refArray.buffer);

//   if(!littleEndian) {
//     result.reverse();
//   }

//   return [...result];
// }

function intToArray(num, size, signed = false, littleEndian = true) {
  if (size < 1 || size > 8) {
    throw new Error(`intToArray: size = ${size} is not supported (1–8 only)`);
  }

  // Use BigInt for safety if size > 4
  const bigNum = BigInt(num);
  const buffer = new ArrayBuffer(size);
  const view = new DataView(buffer);

  switch (size) {
    case 1:
      signed ? view.setInt8(0, Number(bigNum)) : view.setUint8(0, Number(bigNum));
      break;
    case 2:
      signed ? view.setInt16(0, Number(bigNum), littleEndian) : view.setUint16(0, Number(bigNum), littleEndian);
      break;
    case 4:
      signed ? view.setInt32(0, Number(bigNum), littleEndian) : view.setUint32(0, Number(bigNum), littleEndian);
      break;
    default:
      // Handle 5–8 bytes manually via masking & shifting
      for (let i = 0; i < size; i++) {
        const shift = littleEndian ? i : size - 1 - i;
        const byte = Number((bigNum >> BigInt(8 * shift)) & 0xFFn);
        view.setUint8(i, byte);
      }
      break;
  }

  return Array.from(new Uint8Array(buffer));
}

function byteArrayToNum(byteArray, type='uint32', littleEndian=true) {
  type = type.toLowerCase();
  let result = null;

  switch(type) {
    case 'uint64':
      result = arrayToInt(byteArray, false, littleEndian);
      break;

    case 'int64':
      result = arrayToInt(byteArray, true, littleEndian);
      break;
    
    case 'uint32':
      result = arrayToInt(byteArray, false, littleEndian);
      break;

    case 'int32':
      result = arrayToInt(byteArray, true, littleEndian);
      break;
      
    case 'uint16':
      result = arrayToInt(byteArray, false, littleEndian);
      break;

    case 'int16':
      result = arrayToInt(byteArray, true, littleEndian);
      break;
    
    case 'uint8':
      result = arrayToInt(byteArray, false, littleEndian);
      break;

    case 'int8':
      result = arrayToInt(byteArray, true, littleEndian);
      break;

    case 'float32':
    case 'float':
      result = array4ToFloat32(byteArray, littleEndian);
      break;

    default: throw new Error(`type "${type}" is unknown.`);
  }

  return result;
}

function numToByteArray(num, type='uint32', littleEndian=true) {
  type = type.toLowerCase();
  let result = null;

  switch(type) {
    case 'uint64':
      result = intToArray(num, 8, false, littleEndian);
      break;

    case 'int64':
      result = intToArray(num, 8, true, littleEndian);
      break;
      
    case 'uint32':
      result = intToArray(num, 4, false, littleEndian);
      break;

    case 'int32':
      result = intToArray(num, 4, true, littleEndian);
      break;
      
    case 'uint16':
      result = intToArray(num, 2, false, littleEndian);
      break;

    case 'int16':
      result = intToArray(num, 2, true, littleEndian);
      break;
      
    case 'uint8':
      result = intToArray(num, 1, false, littleEndian);
      break;

    case 'int8':
      result = intToArray(num, 1, true, littleEndian);
      break;

    case 'float32':
    case 'float':
      result = float32ToArray4(num, littleEndian);
      break;

    default: throw new Error(`type "${type}" is unknown.`);
  }

  return result;
}

function asciiArrayUtf8Decode (array) {
  const uint8Array = new Uint8Array(array);

  const decoder = new TextDecoder('utf-8');
  const decodedString = decoder.decode(uint8Array);

  return decodedString;
}

function asciiArrayToString(array) {
  // array.splice(array.indexOf(0));
  // return String.fromCharCode(...array);
  return String.fromCharCode.apply(String, array)
}

function stringToAsciiArray(str) {
  return str
    .split('')
    .map(char => char.charCodeAt(0));
}

function round(num, decimals=null) {
  if(decimals === null) {
    return Math.round(num);
  }

  return parseFloat(num.toFixed(decimals));
}

function getTick() {
  return (new Date().getTime());
}

function threadTimerFactoryFunc() {
  let newThread = {
    interval: 0,
    
    timePassed() {
      return (this.interval <= getTick())
    },
    
    setNextInterval(nextInterval) {
      this.interval = getTick() + nextInterval;
    },
  }

  return newThread;
}

function arraysAreEqual(...arrays) {
  if(arrays.length < 2) {
    return true;
  }

  const arrToJSON = (arr) => JSON.stringify(arr);

  let firstArrayString = arrToJSON(arrays[0]);

  let falseResult = arrays.some((array) => {
    return firstArrayString !== arrToJSON(array);
  })

  return falseResult ? false : true;
}

function sequenceDetectorFactoryFunc (sequenceArray) {
  let newOnject = {
    index: 0,
    sequenceArray: [...sequenceArray],

    reset() {
      this.index = 0;
    },

    currentlyExpectingValue() {
      return this.sequenceArray[this.index];
    },

    checkForSequence(newValue) {
      let result = 0;

      if(newValue === this.currentlyExpectingValue()) {
        this.index++;
      } else {
        this.reset();
        if(newValue === this.currentlyExpectingValue()) {
          this.index++;
        }
      }

      if(this.index === this.sequenceArray.length) {
        this.reset();
        result = 1;
      }

      return result;
    }
  };

  return newOnject;
}

function numArrayMajorityElement (array) {
  let arrClone = [...array];
  let majorityCount = -Infinity;
  let majorityCountTemp = -Infinity;
  let majorityElement = -Infinity;
  let majorityElementTemp = -Infinity;

  arrClone.sort(function(a, b) {
    return a - b;
  });

  for(let i = 0; i < arrClone.length; i++) {
    if(arrClone[i] !== majorityElementTemp) {
      majorityElementTemp = arrClone[i];
      majorityCountTemp = 1;
    } else {
      majorityCountTemp++;
      if(majorityCountTemp > majorityCount) {
        majorityCount = majorityCountTemp;
        majorityElement = majorityElementTemp;
      }
    }
  }

  if(majorityCount === -Infinity) {
    majorityElement = majorityElementTemp;
    majorityCount = majorityCountTemp;
  }

  return {
    majorityElement,
    majorityCount
  }
}

function numArrMean (arr) {
  let sum = 0;
  arr.forEach((num) => {
    sum += num
  });

  return (sum / arr.length);
}

function repopulateSelectInput (
  domElementSelector,
  newOptions
) {
  const select = document.querySelector(domElementSelector)

  // console.log('newOptions');
  // console.log(newOptions);

  select.options.length = 0;

  newOptions.forEach((option) => {
    select.options[select.options.length] = new Option(
      option.text,
      option.value,
      option.selected,
      option.selected
    );
  })
}

function byteToBinaryString (byteValue) {
  let result = new Array(8).fill(0);
  let index = 7;
  while(byteValue) {
    result[index] = byteValue & 0x01;
    index--;
    byteValue >>= 1;
  }

  return result.join('');
}

function reverseString (str) {
  return [...str].reverse().join('');
}

function numberWithCommas(x) {
  return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}

async function asyncDelay (delayTime) {
  return new Promise(resolve => setTimeout(resolve, delayTime));
}

function copyToClipboard(text) {
  navigator.clipboard.writeText(text).then(() => {
      // console.log("Text copied to clipboard");
  }).catch((err) => {
      console.error("Failed to copy text: ", err);
  });
}

function deepClone(obj) {
  return JSON.parse(JSON.stringify(obj));
}

/* Backward compatibility */
let deepCopy = deepClone;

function getFieldNameByValue(obj, targetValue) {
  for (const [key, value] of Object.entries(obj)) {
    if (value === targetValue) {
      return key;
    }
  }
  return null; // Return null if no matching value is found
}

function deepCompareArrays(...arrays) {
  let prevArrayJson = JSON.stringify(arrays[0]);
  let currentArrayJson = null;

  for(let i = 1; i < arrays.length; i++) {
    currentArrayJson = JSON.stringify(arrays[i]);

    if(prevArrayJson !== currentArrayJson) {
      return false;
    }

    prevArrayJson = currentArrayJson;
  }

  return true;
}

function isHex(str) {
  return /^[0-9a-fA-F]+$/.test(str);
}

function camelToSnake(str) {
  return str
    // Replace spaces with underscores
    .replace(/[\s+\[\]\.]/g, '_')
    // Insert underscores between lowercase-uppercase boundaries (camelCase)
    .replace(/([a-z0-9])([A-Z])/g, '$1_$2')
    // Replace multiple underscores with a single one (in case of mixed formats)
    .replace(/__+/g, '_')
    .replace(/_$/g, '')
    .toLowerCase();
}

function camelToUpperSnake(str) {
  return camelToSnake(str).toUpperCase();
}

function filterObjectByRegexMutating(obj, regex) {
  for (const key in obj) {
    if (!regex.test(key)) {
      delete obj[key];
    }
  }
  return obj;
}

function filterObjectByRegexNonMutating(obj, regex) {
  let result = {};

  for (const key in obj) {
    if (regex.test(key)) {
      result[key] = obj[key];
    }
  }

  return result;
}

function trimObjectKeys(obj) {
  for (const key in obj) {
    if (obj.hasOwnProperty(key)) {
      const trimmedKey = key.trim();
      if (trimmedKey !== key) {
        obj[trimmedKey] = obj[key];
        delete obj[key];
      }
    }
  }
  return obj;
}

function trimObjectKeysAndValues(obj) {
  for (const key in obj) {
    if (obj.hasOwnProperty(key)) {
      const trimmedKey = key.trim();
      let value = obj[key];

      // Trim string values
      if (typeof value === 'string') {
        value = value.trim();
      }

      // If key changed, delete old key and assign trimmed key
      if (trimmedKey !== key) {
        delete obj[key];
      }
      obj[trimmedKey] = value;
    }
  }
  return obj;
}

function cleanKeysDeep(obj) {
  if (Array.isArray(obj)) {
    return obj.map(cleanKeysDeep);
  } else if (obj && typeof obj === 'object') {
    return Object.fromEntries(
      Object.entries(obj).map(([key, value]) => [
        key.replace(/[\r\n\s]+/g, '').trim(),
        cleanKeysDeep(value)
      ])
    );
  }
  return obj;
}

function createBoxComment (contentString, indentionSpaces=0) {
  let indentStr = ` `.repeat(indentionSpaces);
  let result = ``;
  let lineLength = + contentString.length + 4;

  const breakRow = () => { result += `\r\n`; }

  result += indentStr + `/*`;
  breakRow();
  result += indentStr + `╔` + `═`.repeat(lineLength - 2) + `╗`;
  breakRow();
  
  result += indentStr + `║ ` + contentString + ` ║`;
  breakRow();
  
  result += indentStr + `╚` + `═`.repeat(lineLength - 2) + `╝`;
  breakRow();
  result += indentStr + `*/`;
  breakRow();

  return result;
}

function concatStringRows (...stringRows) {
  let outputString = '';

  stringRows.forEach((stringRow) => {
    outputString += stringRow;
    outputString += '\r\n';
  });

  return outputString;
}

async function isRunningOnDeveloperPc () {
  let appIsPackaged = await personalElectronApi.isPackaged();
  let pcName = await personalElectronApi.getPcName();

  return !appIsPackaged && (pcName === 'Dante')
}

function printErrorBanner (message) {
  printGenericBanner(
    message,
    {
      textColor: `#FF616E`,
      backgroundColor: `#282C34`,
      padding: `0px 10px`,
      fontWeight: `bold`
    }
  );
}

function printWarningBanner (message) {
  printGenericBanner(
    message,
    {
      textColor: `#F0A45D`,
      backgroundColor: `#282C34`,
      padding: `0px 10px`,
      fontWeight: `bold`
    }
  );
}

function printGenericBanner (
  message,
  options = {}
) {
  const {
    generateOutlines=false,
    textColor=`white`,
    backgroundColor=`#282C34`,
    padding=`0px 6px`,
    margin=`0px`,
    fontSize=`1.1rem`,
    fontWeight=`normal`,
    borderRadius=`0`,
  } = options;

  let style = ``;
  let errorString = ``;
  let messageLines = message.split(`\r\n`);
  let bannerLenth = Math.max(...messageLines.map(line => line.length))

  if(generateOutlines) {
    function appendBannerLine (lineString) {
      let spaces = ` `.repeat(bannerLenth - lineString.length);
      errorString += `║ ${lineString}${spaces} ║\r\n`
    }
    
    errorString += `╔${'═'.repeat(bannerLenth + 2)}╗\r\n`

    messageLines.forEach((messageLine) => {
      appendBannerLine(messageLine);
    });

    errorString += `╚${'═'.repeat(bannerLenth + 2)}╝`
  } else {
    function appendBannerLine (lineString, applyNewLineAfter=true) {
      let spaces = ` `.repeat(bannerLenth - lineString.length);

      errorString += `${lineString}${spaces}`;
      errorString += applyNewLineAfter ? `\r\n` : ``;
    }
    
    messageLines.forEach((messageLine, index) => {
      let isLast = index === messageLines.length - 1;

      appendBannerLine(messageLine, !isLast);
    });
  }

  style += `color: ${textColor};`
  style += `background-color: ${backgroundColor};`
  style += `padding: ${padding};`
  style += `margin: ${margin};`
  style += `font-size: ${fontSize};`
  style += `font-weight: ${fontWeight};`
  style += `border-radius: ${borderRadius};`
  style += `line-height: 1.5rem;`

  console.log(`%c${errorString}`, style);
}

function startsWithCapital(str) {
  return /^[A-Z]/.test(str);
}

function lowerCaseFirstLetter (str) {
  if(!str) {
    return ;
  }

  return str[0].toLowerCase() + str.slice(1);
}

function containsDuplicates(arr) {
  return arr.length !== new Set(arr).size;
}

function findDuplicates(arr) {
  const seen = new Set();
  const duplicates = new Set();

  for (const item of arr) {
    if (seen.has(item)) {
      duplicates.add(item);
    } else {
      seen.add(item);
    }
  }

  return [...duplicates];
}

module.exports = {
  findDuplicates,
  containsDuplicates,
  lowerCaseFirstLetter,
  startsWithCapital,
  printErrorBanner,
  printWarningBanner,
  printGenericBanner,
  concatStringRows,
  isRunningOnDeveloperPc,
  isHex,
  deepCopy,
  arraysAreEqual,
  randomRange,
  mapValue,
  constrainValue,
  toHexString,
  fromHexString,
  deepClone,
  array4ToFloat32,
  array8ToFloat64,
  float32ToArray4,
  float64ToArray8,
  arrayToInt,
  intToArray,
  byteArrayToNum,
  numToByteArray,
  asciiArrayUtf8Decode,
  asciiArrayToString,
  stringToAsciiArray,
  round,
  getTick,
  threadTimerFactoryFunc,
  sequenceDetectorFactoryFunc,
  numArrayMajorityElement,
  numArrMean,
  repopulateSelectInput,
  byteToBinaryString,
  reverseString,
  numberWithCommas,
  asyncDelay,
  copyToClipboard,
  getFieldNameByValue,
  deepCompareArrays,
  camelToSnake,
  camelToUpperSnake,
  filterObjectByRegexMutating,
  filterObjectByRegexNonMutating,
  trimObjectKeys,
  trimObjectKeysAndValues,
  cleanKeysDeep,
  createBoxComment,
};

