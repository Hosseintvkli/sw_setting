// main.js

// Modules to control application life and create native browser window
const { app, BrowserWindow, Menu, dialog, ipcMain } = require('electron')
const path = require('path')
const electron = require('electron')
const os = require('os');

const constExePath = app.getAppPath('exe');

process.env['ELECTRON_DISABLE_SECURITY_WARNINGS'] = true;

// Enable live reload for all the files inside your project directory
require('electron-reload')(__dirname);

// Enable live reload for Electron too
// require('electron-reload')(__dirname, {
//   // Note that the path to electron may vary according to the main file
//   electron: require(`${__dirname}/node_modules/electron`)
// });

let mainWindow;

const createWindow = () => {
  // Create the browser window.
  mainWindow = new BrowserWindow({
    // transparent: true,
    // frame: false,
    autoHideMenuBar: true,
    width: 800,
    height: 550,
    icon: path.join(__dirname, "./public/Faraabin.ico"), // or .ico on Windows
    webPreferences: {
      preload: path.join(__dirname, 'preload.js'),
    }
  });

  ipcMain.handle('isPackaged', (event, name) => {
    return app.isPackaged;
  });

  ipcMain.handle('getPcName', (event, name) => {
    return os.hostname();
  });

  // ipcMain.handle('getExeFilePath', async (name) => {
  ipcMain.handle('getExeFilePath', (event, name) => {
    return app.getAppPath(name);
  });
  
  ipcMain.handle('getExeFilePathLooped', (event, name) => {
    return name;
  });
  
  ipcMain.handle('getExeFilePathConst', (event) => {
    return constExePath;
  });

  ipcMain.handle('dialog:openDirectory', async () => {
    const { canceled, filePaths } = await dialog.showOpenDialog(mainWindow, {
      properties: ['openDirectory']
    })
    if (canceled) {
      return
    } else {
      return filePaths[0]
    }
  });

  ipcMain.handle('dialog:selectExcelToOpen', async () => {
    const { canceled, filePaths } = await dialog.showOpenDialog(mainWindow, {
      properties: ['openFile'],
      filters: [
        { name: "All Files", extensions: ["xlsx"] },
      ]
    })
    if (canceled) {
      return
    } else {
      return filePaths[0]
    }
  });

  ipcMain.handle('dialog:selectExcelToSave', async () => {
    const { canceled, filePath } = await dialog.showSaveDialog(mainWindow, {
      filters: [
        { name: "All Files", extensions: ["xlsx", "xls"]},
      ]
    })
    if (canceled) {
      return
    } else {
      return filePath
    }
  })

  ipcMain.handle('dialog:selectBinaryFileToOpen', async () => {
    const { canceled, filePaths } = await dialog.showOpenDialog(mainWindow, {
      properties: ['openFile'],
      filters: [
        { name: "All Files", extensions: ["bin"] },
      ]
    })
    if (canceled) {
      return
    } else {
      return filePaths[0]
    }
  });

  // and load the index.html of the app.
  mainWindow.loadFile('./dist/index.html');
  // Open the DevTools.
  mainWindow.webContents.openDevTools();

  // Make navigation menu bar
  // Menu.setApplicationMenu(Menu.buildFromTemplate([

  // ]));
}

// This method will be called when Electron has finished
// initialization and is ready to create browser windows.
// Some APIs can only be used after this event occurs.
app.whenReady().then(() => {
  createWindow()

  app.on('activate', () => {
    // On macOS it's common to re-create a window in the app when the
    // dock icon is clicked and there are no other windows open.
    if (BrowserWindow.getAllWindows().length === 0) createWindow()
  })
})

// Quit when all windows are closed, except on macOS. There, it's common
// for applications and their menu bar to stay active until the user quits
// explicitly with Cmd + Q.
app.on('window-all-closed', () => {
  if (process.platform !== 'darwin') app.quit()
})

app.allowRendererProcessReuse = false;

// In this file you can include the rest of your app's specific main process
// code. You can also put them in separate files and require them here.