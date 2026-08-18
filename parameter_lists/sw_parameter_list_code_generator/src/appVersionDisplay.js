'use strict';

const toolBox = require('./toolBox')
const appConfig = require('./appConfig')

function init () {
  document.title += ` ${appConfig.app.VERSION}`;
}

module.exports = {
  init
}