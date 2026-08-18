'use strict';

const fs = require('fs');
const path = require("path");
const { ipcRenderer } = require('electron');

async function readBinaryFileFromPath (filePath) {
  let buffer = fs.readFileSync(filePath);
  let byteArray = new Uint8Array(buffer);

  return byteArray;
}

async function selectBinaryFileToOpen () {
  return await ipcRenderer.invoke('dialog:selectBinaryFileToOpen');
}

async function selectAndReadBinaryFile () {
  let filePath = await selectBinaryFileToOpen();

  return await readBinaryFileFromPath(filePath);
}

function writeStringToFile (fileName, string, format="utf8") {
  fs.writeFileSync(fileName, string, format);
}

function listFiles(dirPath) {
  return fs.readdirSync(dirPath).filter(file =>
    fs.statSync(path.join(dirPath, file)).isFile()
  );
}

function pathExists (dirPath) {
  if (fs.existsSync(dirPath)) {
    return true;
  } else {
    return false;
  }
}

function createSubFolder (dirPath, subfolderName) {
  // Define subfolderName name
  const subfolderPath = path.join(dirPath, subfolderName);

  // Create the folder if it doesn't exist
  if (!fs.existsSync(subfolderPath)) {
    fs.mkdirSync(subfolderPath, { recursive: true });
  }

  return subfolderPath;
}

function folderExists (folderPath) {
  return fs.existsSync(folderPath);
}

function subFolderExists (dirPath, subfolderName) {
  return folderExists(path.join(dirPath, subfolderName));
}

function joinPaths (...inputPaths) {
  let jointPath = null;

  inputPaths.forEach((inputPath, index) => {
    if(index === 0) {
      jointPath = inputPath;
    } else {
      jointPath = path.join(jointPath, inputPath)
    }
  });

  return jointPath;
}

function extractFileNameFromFullPath (fileFullPath) {
  return path.basename(fileFullPath);
}

function extractDirectoryName (fileFullPath) {
  return path.dirname(fileFullPath);
}

function readAndParseJsonFile (filePath) {
  if(!pathExists(filePath)) {
    return null;
  }

  let data = fs.readFileSync(filePath, 'utf8');
  let json = JSON.parse(data);

  return json;
}

function lastPathPartsFs(p, depth) {
  const parts = p.split(path.sep).filter(Boolean);
  return parts.slice(-depth).join(path.sep);
}

function clearFolder(dir) {
  if (!fs.existsSync(dir)) return;

  for (const file of fs.readdirSync(dir)) {
    fs.rmSync(path.join(dir, file), { recursive: true, force: true });
  }
}

function systemPathExists(path) {
  if (fs.existsSync(path)) {
    return true;
  }

  return false;
}

function findFilesWithExtension(folderPath, extension) {
  const ext = extension.startsWith(".") ? extension : "." + extension;
  const regex = new RegExp(ext.replace(".", "\\.") + "$");

  let results = [];
  const entries = fs.readdirSync(folderPath, { withFileTypes: true });

  for (const entry of entries) {
    const fullPath = path.join(folderPath, entry.name);

    if (entry.isDirectory()) {
      results = results.concat(findFilesWithExtension(fullPath, extension));
    } else if (regex.test(entry.name)) {
      results.push(fullPath);
    }
  }

  return results;
}

function readFileAsString(filePath) {
  return fs.readFileSync(filePath, "utf8");
}

module.exports = {
  readFileAsString,
  findFilesWithExtension,
  clearFolder,
  systemPathExists,
  readBinaryFileFromPath,
  selectBinaryFileToOpen,
  selectAndReadBinaryFile,
  writeStringToFile,
  listFiles,
  pathExists,
  createSubFolder,
  folderExists,
  subFolderExists,
  extractFileNameFromFullPath,
  joinPaths,
  extractDirectoryName,
  readAndParseJsonFile,
  lastPathPartsFs,
}

