'use strict';

module.exports = {
  app: {
    DEFAULT_ZOOM_FACTOR: 1,
    ZOOM_STEP: 0.05,
    VERSION: `3.0.11`,
  },

  general: {
    DEFAULT_WINDOW_WIDTH: 800,
    DEFAULT_WINDOW_HEIGHT: 550,
  },

  defs: {
    userInputsRootFolderName: `user_inputs`,
  },

  developer: {
    doNotGenerateOutputFiles: false,
    onlyProcessOneDeviceExcel: {
      enable: false,
      fileName: `parameter_list_rasta.xlsx`,
    },
    autoVersionIncrementDisabled: false,
    forceGenereateNewVersions: false,
    // autoTestCase: `4\\files`,
    autoTestCase: `4`,
  }
}

