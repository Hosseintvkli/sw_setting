'use strict';
const toolBox = require('./toolBox');

const XLSX = require("xlsx");
const { ipcRenderer } = require('electron');

function normalizeCellValue(value) {
  if (typeof value === "string") return value.trim();
  return value;
}

function normalizeHeader(header) {
  return header.toString().trim();
}

function sanitizeValue(val) {
  if (val === undefined || val === null) return "";   // empty cell
  if (typeof val === "number" && !isFinite(val)) return ""; // avoid NaN/Infinity
  if (typeof val === "object") return JSON.stringify(val); // flatten objects
  return val;
}

function exportObjToExcel (filePath, data) {
  const safeData = data.map(row =>
    Object.fromEntries(
      Object.entries(row).map(([k, v]) => [k, sanitizeValue(v)])
    )
  );

  // Convert the array of objects to a worksheet
  const worksheet = XLSX.utils.json_to_sheet(safeData);

  // Create a new workbook and append the worksheet
  const workbook = XLSX.utils.book_new();
  XLSX.utils.book_append_sheet(workbook, worksheet, "Sheet1");

  // Write the workbook to a file
  XLSX.writeFile(workbook, filePath, { bookType: "xlsx" });
}

async function selectFolder () {
  return await ipcRenderer.invoke('dialog:openDirectory');
}

async function selectExcelToOpen () {
  return await ipcRenderer.invoke('dialog:selectExcelToOpen');
}

function sheetToJson (sheet, options) {
  return XLSX.utils.sheet_to_json(sheet, options);
}

function openExcelWorkbook (filePath) {
  const workbook = XLSX.readFile(filePath);
  const result = {};

  workbook.SheetNames.forEach(sheetName => {
    const worksheet = workbook.Sheets[sheetName];
    // Convert each sheet to JSON (array of objects)
    result[sheetName] = XLSX.utils.sheet_to_json(worksheet, { defval: null });
  });

  return result;
}

function openExcelWorkbookWithCells (filePath) {
  const workbook = XLSX.readFile(filePath);
  const result = {};

  workbook.SheetNames.forEach(sheetName => {
    const worksheet = workbook.Sheets[sheetName];
    // Convert each sheet to JSON (array of objects)
    let sheetJson = sheetToJsonWithCells(worksheet);

    if(sheetJson) {
      result[sheetName] = sheetJson;
    }
  });

  return result;
}

async function selectAndOpenExcelWorkbook () {
  let filePath = await selectExcelToOpen();
  if(!filePath) {
    return null;
  }

  return openExcelWorkbook(filePath);
}

async function selectExcelToSave () {
  return await ipcRenderer.invoke('dialog:selectExcelToSave');
}

function getExeFilePath (name) {
  return ipcRenderer.invoke('getExeFilePath', name);
}

function getExeFilePathLooped (name) {
  return ipcRenderer.invoke('getExeFilePathLooped', name);
}

function getExeFilePathConst () {
  return ipcRenderer.invoke('getExeFilePathConst');
}

function saveWorkbook(workbook, filePath) {
  try {
    XLSX.writeFile(workbook, filePath); // Write the workbook to the specified file
    console.log(`Workbook saved to ${filePath}`);
  } catch (error) {
    console.error(`Failed to save workbook: ${error.message}`);
  }
}

function sheetToJsonWithCells(sheet) {
  if(!sheet["!ref"]) {
    return null;
  }

  let range = XLSX.utils.decode_range(sheet["!ref"]);
  let headers = {};
  let rows = [];

  // --- Read header row (keys) ---
  for (let C = range.s.c; C <= range.e.c; C++) {
    const cellAddr = XLSX.utils.encode_cell({ r: range.s.r, c: C });
    const cell = sheet[cellAddr];

    if (cell?.v !== undefined && cell.v !== null) {
      headers[C] = normalizeHeader(cell.v);
    }
  }

  // --- Read data rows ---
  for (let R = range.s.r + 1; R <= range.e.r; R++) {
    const row = {};
    let hasData = false;

    for (let C = range.s.c; C <= range.e.c; C++) {
      const header = headers[C];
      if (!header) continue;

      const addr = XLSX.utils.encode_cell({ r: R, c: C });
      const cell = sheet[addr];

      const rawValue = cell?.v ?? null;
      const value = normalizeCellValue(rawValue);

      row[header] = {
        value,
        cell: addr
      };

      if (rawValue !== null && rawValue !== undefined && rawValue !== "")
        hasData = true;
    }

    if (hasData) rows.push(row);
  }

  rows = toolBox.cleanKeysDeep(rows);

  return rows;
}

module.exports = {
  getExeFilePath,
  getExeFilePathLooped,
  getExeFilePathConst,
  selectFolder,
  selectExcelToOpen,
  selectExcelToSave,
  selectAndOpenExcelWorkbook,
  openExcelWorkbook,
  openExcelWorkbookWithCells,
  saveWorkbook,
  exportObjToExcel,
  sheetToJson,
}

