'use strict';

const { ipcRenderer } = require('electron');

async function isPackaged () {
  return await ipcRenderer.invoke('isPackaged');
}

async function getPcName () {
  return await ipcRenderer.invoke('getPcName');
}

module.exports = {
  isPackaged,
  getPcName,
}

