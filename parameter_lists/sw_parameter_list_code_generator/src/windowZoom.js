'use strict';

const appConfig = require('./appConfig')

let ctrlKeyIsPressed = false;
let localStorageName = null;

function getLocallyStoredZoomFactor () {
  let locallyStoredData = localStorage.getItem(localStorageName);
  // console.log('locallyStoredData', locallyStoredData);

  if(locallyStoredData) {
    try {
      locallyStoredData = JSON.parse(locallyStoredData);
      return locallyStoredData.value;
    } catch (error) {
      localStorage.removeItem(localStorageName);
      return appConfig.app.DEFAULT_ZOOM_FACTOR;
    }
  } else {
    // console.log('No local storage data for user zoom factor');
    return appConfig.app.DEFAULT_ZOOM_FACTOR;
  }
}

function saveCurrentZoomFactor () {
  let currentZoomFactor = personalWebFrameApi.getZoomFactor();
  localStorage.setItem(localStorageName, JSON.stringify({
    value: currentZoomFactor,
  }));
}

function windowCrop() {
  window.resizeTo(
    appConfig.general.DEFAULT_WINDOW_WIDTH
      * personalWebFrameApi.getZoomFactor(),
    appConfig.general.DEFAULT_WINDOW_HEIGHT
      * personalWebFrameApi.getZoomFactor()
  );
}

function init(appName) {
  if(appName) {
    localStorageName = 'Dante__' + appName;
  } else {
    throw new Error('Bad app name');
  }

  personalWebFrameApi.init(getLocallyStoredZoomFactor());

  window.addEventListener('keydown', (event) => {
    if (event.key === 'Control') {
      ctrlKeyIsPressed = true;
    }
  });

  window.addEventListener('keyup', (event) => {
    if (event.key === 'Control') {
      ctrlKeyIsPressed = false;
    }
  });

  window.addEventListener('wheel', (event) => {
    if (ctrlKeyIsPressed) {
      if (event.deltaY > 0) {
        personalWebFrameApi.modifyZoomFactor(-1 * appConfig.app.ZOOM_STEP);
      } else {
        personalWebFrameApi.modifyZoomFactor(+1 * appConfig.app.ZOOM_STEP);
      }

      saveCurrentZoomFactor();
    }
  });

  // window.addEventListener('mouseup', (event) => {
  //   /* If middle mouse button is pressed */
  //   if((event.button === 1) && (ctrlKeyIsPressed)) {
  //     event.preventDefault();
  //     windowCrop();
  //   }
  // });
}


module.exports = {
  init,
  windowCrop,
}
