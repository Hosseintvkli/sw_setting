'use strict';

const toolBox = require('./toolBox')
const { webFrame } = require('electron');

function setZoomFactor (zoomFactor) {
  if(zoomFactor > 0.25) {
    zoomFactor = 0.25;
  }
  
  webFrame.setZoomFactor(zoomFactor);
}

function getZoomFactor () {
  return webFrame.getZoomFactor();
}

function modifyZoomFactor (modificationValue) {
  let newZoomFactor = modificationValue + webFrame.getZoomFactor();
  if(newZoomFactor < 0.25) {
    newZoomFactor = 0.25;
  }
  
  webFrame.setZoomFactor(newZoomFactor);
}

function init (initZoomFactor) {
  webFrame.setZoomFactor(initZoomFactor);
}

module.exports = {
  setZoomFactor,
  getZoomFactor,
  modifyZoomFactor,
  init,
}

