const path = require('path');
const { contextBridge } = require('electron');
const personalWebFrame = require('./src/personalWebFrame')
const personalExcelApi = require('./src/personalExcelApi')
const personalFileApi = require('./src/personalFileApi')
const personalHashApi = require('./src/personalHashApi')
const personalElectronApi = require('./src/personalElectronApi')

contextBridge.exposeInMainWorld('pathAPI', {
  join: path.join,
  __dirname: __dirname
})

contextBridge.exposeInMainWorld('personalWebFrameApi', { ...personalWebFrame });
contextBridge.exposeInMainWorld('personalExcelApi',    { ...personalExcelApi });
contextBridge.exposeInMainWorld('personalFileApi',     { ...personalFileApi });
contextBridge.exposeInMainWorld('personalElectronApi', { ...personalElectronApi });
contextBridge.exposeInMainWorld('personalHashApi',     { ...personalHashApi });

window.addEventListener('DOMContentLoaded', () => {

});
