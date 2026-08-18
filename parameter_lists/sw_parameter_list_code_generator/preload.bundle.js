/******/ (() => { // webpackBootstrap
/******/ 	var __webpack_modules__ = ({

/***/ "./node_modules/@serialport/binding-mock/dist/index.js":
/*!*************************************************************!*\
  !*** ./node_modules/@serialport/binding-mock/dist/index.js ***!
  \*************************************************************/
/***/ ((__unused_webpack_module, exports, __webpack_require__) => {

"use strict";


Object.defineProperty(exports, "__esModule", ({ value: true }));

var debugFactory = __webpack_require__(/*! debug */ "./node_modules/debug/src/index.js");

function _interopDefaultLegacy (e) { return e && typeof e === 'object' && 'default' in e ? e : { 'default': e }; }

var debugFactory__default = /*#__PURE__*/_interopDefaultLegacy(debugFactory);

const debug = debugFactory__default["default"]('serialport/binding-mock');
let ports = {};
let serialNumber = 0;
function resolveNextTick() {
    return new Promise(resolve => process.nextTick(() => resolve()));
}
class CanceledError extends Error {
    constructor(message) {
        super(message);
        this.canceled = true;
    }
}
const MockBinding = {
    reset() {
        ports = {};
        serialNumber = 0;
    },
    // Create a mock port
    createPort(path, options = {}) {
        serialNumber++;
        const optWithDefaults = Object.assign({ echo: false, record: false, manufacturer: 'The J5 Robotics Company', vendorId: undefined, productId: undefined, maxReadSize: 1024 }, options);
        ports[path] = {
            data: Buffer.alloc(0),
            echo: optWithDefaults.echo,
            record: optWithDefaults.record,
            readyData: optWithDefaults.readyData,
            maxReadSize: optWithDefaults.maxReadSize,
            info: {
                path,
                manufacturer: optWithDefaults.manufacturer,
                serialNumber: `${serialNumber}`,
                pnpId: undefined,
                locationId: undefined,
                vendorId: optWithDefaults.vendorId,
                productId: optWithDefaults.productId,
            },
        };
        debug(serialNumber, 'created port', JSON.stringify({ path, opt: options }));
    },
    async list() {
        debug(null, 'list');
        return Object.values(ports).map(port => port.info);
    },
    async open(options) {
        var _a;
        if (!options || typeof options !== 'object' || Array.isArray(options)) {
            throw new TypeError('"options" is not an object');
        }
        if (!options.path) {
            throw new TypeError('"path" is not a valid port');
        }
        if (!options.baudRate) {
            throw new TypeError('"baudRate" is not a valid baudRate');
        }
        const openOptions = Object.assign({ dataBits: 8, lock: true, stopBits: 1, parity: 'none', rtscts: false, xon: false, xoff: false, xany: false, hupcl: true }, options);
        const { path } = openOptions;
        debug(null, `open: opening path ${path}`);
        const port = ports[path];
        await resolveNextTick();
        if (!port) {
            throw new Error(`Port does not exist - please call MockBinding.createPort('${path}') first`);
        }
        const serialNumber = port.info.serialNumber;
        if ((_a = port.openOpt) === null || _a === void 0 ? void 0 : _a.lock) {
            debug(serialNumber, 'open: Port is locked cannot open');
            throw new Error('Port is locked cannot open');
        }
        debug(serialNumber, `open: opened path ${path}`);
        port.openOpt = Object.assign({}, openOptions);
        return new MockPortBinding(port, openOptions);
    },
};
/**
 * Mock bindings for pretend serialport access
 */
class MockPortBinding {
    constructor(port, openOptions) {
        this.port = port;
        this.openOptions = openOptions;
        this.pendingRead = null;
        this.isOpen = true;
        this.lastWrite = null;
        this.recording = Buffer.alloc(0);
        this.writeOperation = null; // in flight promise or null
        this.serialNumber = port.info.serialNumber;
        if (port.readyData) {
            const data = port.readyData;
            process.nextTick(() => {
                if (this.isOpen) {
                    debug(this.serialNumber, 'emitting ready data');
                    this.emitData(data);
                }
            });
        }
    }
    // Emit data on a mock port
    emitData(data) {
        if (!this.isOpen || !this.port) {
            throw new Error('Port must be open to pretend to receive data');
        }
        const bufferData = Buffer.isBuffer(data) ? data : Buffer.from(data);
        debug(this.serialNumber, 'emitting data - pending read:', Boolean(this.pendingRead));
        this.port.data = Buffer.concat([this.port.data, bufferData]);
        if (this.pendingRead) {
            process.nextTick(this.pendingRead);
            this.pendingRead = null;
        }
    }
    async close() {
        debug(this.serialNumber, 'close');
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        const port = this.port;
        if (!port) {
            throw new Error('already closed');
        }
        port.openOpt = undefined;
        // reset data on close
        port.data = Buffer.alloc(0);
        debug(this.serialNumber, 'port is closed');
        this.serialNumber = undefined;
        this.isOpen = false;
        if (this.pendingRead) {
            this.pendingRead(new CanceledError('port is closed'));
        }
    }
    async read(buffer, offset, length) {
        if (!Buffer.isBuffer(buffer)) {
            throw new TypeError('"buffer" is not a Buffer');
        }
        if (typeof offset !== 'number' || isNaN(offset)) {
            throw new TypeError(`"offset" is not an integer got "${isNaN(offset) ? 'NaN' : typeof offset}"`);
        }
        if (typeof length !== 'number' || isNaN(length)) {
            throw new TypeError(`"length" is not an integer got "${isNaN(length) ? 'NaN' : typeof length}"`);
        }
        if (buffer.length < offset + length) {
            throw new Error('buffer is too small');
        }
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        debug(this.serialNumber, 'read', length, 'bytes');
        await resolveNextTick();
        if (!this.isOpen || !this.port) {
            throw new CanceledError('Read canceled');
        }
        if (this.port.data.length <= 0) {
            return new Promise((resolve, reject) => {
                this.pendingRead = err => {
                    if (err) {
                        return reject(err);
                    }
                    this.read(buffer, offset, length).then(resolve, reject);
                };
            });
        }
        const lengthToRead = this.port.maxReadSize > length ? length : this.port.maxReadSize;
        const data = this.port.data.slice(0, lengthToRead);
        const bytesRead = data.copy(buffer, offset);
        this.port.data = this.port.data.slice(lengthToRead);
        debug(this.serialNumber, 'read', bytesRead, 'bytes');
        return { bytesRead, buffer };
    }
    async write(buffer) {
        if (!Buffer.isBuffer(buffer)) {
            throw new TypeError('"buffer" is not a Buffer');
        }
        if (!this.isOpen || !this.port) {
            debug('write', 'error port is not open');
            throw new Error('Port is not open');
        }
        debug(this.serialNumber, 'write', buffer.length, 'bytes');
        if (this.writeOperation) {
            throw new Error('Overlapping writes are not supported and should be queued by the serialport object');
        }
        this.writeOperation = (async () => {
            await resolveNextTick();
            if (!this.isOpen || !this.port) {
                throw new Error('Write canceled');
            }
            const data = (this.lastWrite = Buffer.from(buffer)); // copy
            if (this.port.record) {
                this.recording = Buffer.concat([this.recording, data]);
            }
            if (this.port.echo) {
                process.nextTick(() => {
                    if (this.isOpen) {
                        this.emitData(data);
                    }
                });
            }
            this.writeOperation = null;
            debug(this.serialNumber, 'writing finished');
        })();
        return this.writeOperation;
    }
    async update(options) {
        if (typeof options !== 'object') {
            throw TypeError('"options" is not an object');
        }
        if (typeof options.baudRate !== 'number') {
            throw new TypeError('"options.baudRate" is not a number');
        }
        debug(this.serialNumber, 'update');
        if (!this.isOpen || !this.port) {
            throw new Error('Port is not open');
        }
        await resolveNextTick();
        if (this.port.openOpt) {
            this.port.openOpt.baudRate = options.baudRate;
        }
    }
    async set(options) {
        if (typeof options !== 'object') {
            throw new TypeError('"options" is not an object');
        }
        debug(this.serialNumber, 'set');
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        await resolveNextTick();
    }
    async get() {
        debug(this.serialNumber, 'get');
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        await resolveNextTick();
        return {
            cts: true,
            dsr: false,
            dcd: false,
        };
    }
    async getBaudRate() {
        var _a;
        debug(this.serialNumber, 'getBaudRate');
        if (!this.isOpen || !this.port) {
            throw new Error('Port is not open');
        }
        await resolveNextTick();
        if (!((_a = this.port.openOpt) === null || _a === void 0 ? void 0 : _a.baudRate)) {
            throw new Error('Internal Error');
        }
        return {
            baudRate: this.port.openOpt.baudRate,
        };
    }
    async flush() {
        debug(this.serialNumber, 'flush');
        if (!this.isOpen || !this.port) {
            throw new Error('Port is not open');
        }
        await resolveNextTick();
        this.port.data = Buffer.alloc(0);
    }
    async drain() {
        debug(this.serialNumber, 'drain');
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        await this.writeOperation;
        await resolveNextTick();
    }
}

exports.CanceledError = CanceledError;
exports.MockBinding = MockBinding;
exports.MockPortBinding = MockPortBinding;


/***/ }),

/***/ "./node_modules/@serialport/bindings-cpp/dist/darwin.js":
/*!**************************************************************!*\
  !*** ./node_modules/@serialport/bindings-cpp/dist/darwin.js ***!
  \**************************************************************/
/***/ (function(__unused_webpack_module, exports, __webpack_require__) {

"use strict";

var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", ({ value: true }));
exports.DarwinPortBinding = exports.DarwinBinding = void 0;
const debug_1 = __importDefault(__webpack_require__(/*! debug */ "./node_modules/debug/src/index.js"));
const load_bindings_1 = __webpack_require__(/*! ./load-bindings */ "./node_modules/@serialport/bindings-cpp/dist/load-bindings.js");
const poller_1 = __webpack_require__(/*! ./poller */ "./node_modules/@serialport/bindings-cpp/dist/poller.js");
const unix_read_1 = __webpack_require__(/*! ./unix-read */ "./node_modules/@serialport/bindings-cpp/dist/unix-read.js");
const unix_write_1 = __webpack_require__(/*! ./unix-write */ "./node_modules/@serialport/bindings-cpp/dist/unix-write.js");
const debug = (0, debug_1.default)('serialport/bindings-cpp');
exports.DarwinBinding = {
    list() {
        debug('list');
        return (0, load_bindings_1.asyncList)();
    },
    async open(options) {
        if (!options || typeof options !== 'object' || Array.isArray(options)) {
            throw new TypeError('"options" is not an object');
        }
        if (!options.path) {
            throw new TypeError('"path" is not a valid port');
        }
        if (!options.baudRate) {
            throw new TypeError('"baudRate" is not a valid baudRate');
        }
        debug('open');
        const openOptions = Object.assign({ vmin: 1, vtime: 0, dataBits: 8, lock: true, stopBits: 1, parity: 'none', rtscts: false, xon: false, xoff: false, xany: false, hupcl: true }, options);
        const fd = await (0, load_bindings_1.asyncOpen)(openOptions.path, openOptions);
        return new DarwinPortBinding(fd, openOptions);
    },
};
/**
 * The Darwin binding layer for OSX
 */
class DarwinPortBinding {
    constructor(fd, options) {
        this.fd = fd;
        this.openOptions = options;
        this.poller = new poller_1.Poller(fd);
        this.writeOperation = null;
    }
    get isOpen() {
        return this.fd !== null;
    }
    async close() {
        debug('close');
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        const fd = this.fd;
        this.poller.stop();
        this.poller.destroy();
        this.fd = null;
        await (0, load_bindings_1.asyncClose)(fd);
    }
    async read(buffer, offset, length) {
        if (!Buffer.isBuffer(buffer)) {
            throw new TypeError('"buffer" is not a Buffer');
        }
        if (typeof offset !== 'number' || isNaN(offset)) {
            throw new TypeError(`"offset" is not an integer got "${isNaN(offset) ? 'NaN' : typeof offset}"`);
        }
        if (typeof length !== 'number' || isNaN(length)) {
            throw new TypeError(`"length" is not an integer got "${isNaN(length) ? 'NaN' : typeof length}"`);
        }
        debug('read');
        if (buffer.length < offset + length) {
            throw new Error('buffer is too small');
        }
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        return (0, unix_read_1.unixRead)({ binding: this, buffer, offset, length });
    }
    async write(buffer) {
        if (!Buffer.isBuffer(buffer)) {
            throw new TypeError('"buffer" is not a Buffer');
        }
        debug('write', buffer.length, 'bytes');
        if (!this.isOpen) {
            debug('write', 'error port is not open');
            throw new Error('Port is not open');
        }
        this.writeOperation = (async () => {
            if (buffer.length === 0) {
                return;
            }
            await (0, unix_write_1.unixWrite)({ binding: this, buffer });
            this.writeOperation = null;
        })();
        return this.writeOperation;
    }
    async update(options) {
        if (!options || typeof options !== 'object' || Array.isArray(options)) {
            throw TypeError('"options" is not an object');
        }
        if (typeof options.baudRate !== 'number') {
            throw new TypeError('"options.baudRate" is not a number');
        }
        debug('update');
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        await (0, load_bindings_1.asyncUpdate)(this.fd, options);
    }
    async set(options) {
        if (!options || typeof options !== 'object' || Array.isArray(options)) {
            throw new TypeError('"options" is not an object');
        }
        debug('set', options);
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        await (0, load_bindings_1.asyncSet)(this.fd, options);
    }
    async get() {
        debug('get');
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        return (0, load_bindings_1.asyncGet)(this.fd);
    }
    async getBaudRate() {
        debug('getBaudRate');
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        throw new Error('getBaudRate is not implemented on darwin');
    }
    async flush() {
        debug('flush');
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        await (0, load_bindings_1.asyncFlush)(this.fd);
    }
    async drain() {
        debug('drain');
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        await this.writeOperation;
        await (0, load_bindings_1.asyncDrain)(this.fd);
    }
}
exports.DarwinPortBinding = DarwinPortBinding;


/***/ }),

/***/ "./node_modules/@serialport/bindings-cpp/dist/errors.js":
/*!**************************************************************!*\
  !*** ./node_modules/@serialport/bindings-cpp/dist/errors.js ***!
  \**************************************************************/
/***/ ((__unused_webpack_module, exports) => {

"use strict";

Object.defineProperty(exports, "__esModule", ({ value: true }));
exports.BindingsError = void 0;
class BindingsError extends Error {
    constructor(message, { canceled = false } = {}) {
        super(message);
        this.canceled = canceled;
    }
}
exports.BindingsError = BindingsError;


/***/ }),

/***/ "./node_modules/@serialport/bindings-cpp/dist/index.js":
/*!*************************************************************!*\
  !*** ./node_modules/@serialport/bindings-cpp/dist/index.js ***!
  \*************************************************************/
/***/ (function(__unused_webpack_module, exports, __webpack_require__) {

"use strict";

var __createBinding = (this && this.__createBinding) || (Object.create ? (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    Object.defineProperty(o, k2, { enumerable: true, get: function() { return m[k]; } });
}) : (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    o[k2] = m[k];
}));
var __exportStar = (this && this.__exportStar) || function(m, exports) {
    for (var p in m) if (p !== "default" && !Object.prototype.hasOwnProperty.call(exports, p)) __createBinding(exports, m, p);
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", ({ value: true }));
exports.autoDetect = void 0;
/* eslint-disable @typescript-eslint/no-var-requires */
const debug_1 = __importDefault(__webpack_require__(/*! debug */ "./node_modules/debug/src/index.js"));
const darwin_1 = __webpack_require__(/*! ./darwin */ "./node_modules/@serialport/bindings-cpp/dist/darwin.js");
const linux_1 = __webpack_require__(/*! ./linux */ "./node_modules/@serialport/bindings-cpp/dist/linux.js");
const win32_1 = __webpack_require__(/*! ./win32 */ "./node_modules/@serialport/bindings-cpp/dist/win32.js");
const debug = (0, debug_1.default)('serialport/bindings-cpp');
__exportStar(__webpack_require__(/*! @serialport/bindings-interface */ "./node_modules/@serialport/bindings-interface/dist/index.js"), exports);
__exportStar(__webpack_require__(/*! ./darwin */ "./node_modules/@serialport/bindings-cpp/dist/darwin.js"), exports);
__exportStar(__webpack_require__(/*! ./linux */ "./node_modules/@serialport/bindings-cpp/dist/linux.js"), exports);
__exportStar(__webpack_require__(/*! ./win32 */ "./node_modules/@serialport/bindings-cpp/dist/win32.js"), exports);
__exportStar(__webpack_require__(/*! ./errors */ "./node_modules/@serialport/bindings-cpp/dist/errors.js"), exports);
/**
 * This is an auto detected binding for your current platform
 */
function autoDetect() {
    switch (process.platform) {
        case 'win32':
            debug('loading WindowsBinding');
            return win32_1.WindowsBinding;
        case 'darwin':
            debug('loading DarwinBinding');
            return darwin_1.DarwinBinding;
        default:
            debug('loading LinuxBinding');
            return linux_1.LinuxBinding;
    }
}
exports.autoDetect = autoDetect;


/***/ }),

/***/ "./node_modules/@serialport/bindings-cpp/dist/linux-list.js":
/*!******************************************************************!*\
  !*** ./node_modules/@serialport/bindings-cpp/dist/linux-list.js ***!
  \******************************************************************/
/***/ ((__unused_webpack_module, exports, __webpack_require__) => {

"use strict";

Object.defineProperty(exports, "__esModule", ({ value: true }));
exports.linuxList = void 0;
const child_process_1 = __webpack_require__(/*! child_process */ "child_process");
const parser_readline_1 = __webpack_require__(/*! @serialport/parser-readline */ "./node_modules/@serialport/parser-readline/dist/index.js");
// get only serial port names
function checkPathOfDevice(path) {
    return /(tty(S|WCH|ACM|USB|AMA|MFD|O|XRUSB)|rfcomm)/.test(path) && path;
}
function propName(name) {
    return {
        DEVNAME: 'path',
        ID_VENDOR_ENC: 'manufacturer',
        ID_SERIAL_SHORT: 'serialNumber',
        ID_VENDOR_ID: 'vendorId',
        ID_MODEL_ID: 'productId',
        DEVLINKS: 'pnpId',
    }[name.toUpperCase()];
}
function decodeHexEscape(str) {
    return str.replace(/\\x([a-fA-F0-9]{2})/g, (a, b) => {
        return String.fromCharCode(parseInt(b, 16));
    });
}
function propVal(name, val) {
    if (name === 'pnpId') {
        const match = val.match(/\/by-id\/([^\s]+)/);
        return (match === null || match === void 0 ? void 0 : match[1]) || undefined;
    }
    if (name === 'manufacturer') {
        return decodeHexEscape(val);
    }
    if (/^0x/.test(val)) {
        return val.substr(2);
    }
    return val;
}
function linuxList(spawnCmd = child_process_1.spawn) {
    const ports = [];
    const udevadm = spawnCmd('udevadm', ['info', '-e']);
    const lines = udevadm.stdout.pipe(new parser_readline_1.ReadlineParser());
    let skipPort = false;
    let port = {
        path: '',
        manufacturer: undefined,
        serialNumber: undefined,
        pnpId: undefined,
        locationId: undefined,
        vendorId: undefined,
        productId: undefined,
    };
    lines.on('data', (line) => {
        const lineType = line.slice(0, 1);
        const data = line.slice(3);
        // new port entry
        if (lineType === 'P') {
            port = {
                path: '',
                manufacturer: undefined,
                serialNumber: undefined,
                pnpId: undefined,
                locationId: undefined,
                vendorId: undefined,
                productId: undefined,
            };
            skipPort = false;
            return;
        }
        if (skipPort) {
            return;
        }
        // Check dev name and save port if it matches flag to skip the rest of the data if not
        if (lineType === 'N') {
            if (checkPathOfDevice(data)) {
                ports.push(port);
            }
            else {
                skipPort = true;
            }
            return;
        }
        // parse data about each port
        if (lineType === 'E') {
            const keyValue = data.match(/^(.+)=(.*)/);
            if (!keyValue) {
                return;
            }
            const key = propName(keyValue[1]);
            if (!key) {
                return;
            }
            port[key] = propVal(key, keyValue[2]);
        }
    });
    return new Promise((resolve, reject) => {
        udevadm.on('close', (code) => {
            if (code) {
                reject(new Error(`Error listing ports udevadm exited with error code: ${code}`));
            }
        });
        udevadm.on('error', reject);
        lines.on('error', reject);
        lines.on('finish', () => resolve(ports));
    });
}
exports.linuxList = linuxList;


/***/ }),

/***/ "./node_modules/@serialport/bindings-cpp/dist/linux.js":
/*!*************************************************************!*\
  !*** ./node_modules/@serialport/bindings-cpp/dist/linux.js ***!
  \*************************************************************/
/***/ (function(__unused_webpack_module, exports, __webpack_require__) {

"use strict";

var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", ({ value: true }));
exports.LinuxPortBinding = exports.LinuxBinding = void 0;
const debug_1 = __importDefault(__webpack_require__(/*! debug */ "./node_modules/debug/src/index.js"));
const linux_list_1 = __webpack_require__(/*! ./linux-list */ "./node_modules/@serialport/bindings-cpp/dist/linux-list.js");
const poller_1 = __webpack_require__(/*! ./poller */ "./node_modules/@serialport/bindings-cpp/dist/poller.js");
const unix_read_1 = __webpack_require__(/*! ./unix-read */ "./node_modules/@serialport/bindings-cpp/dist/unix-read.js");
const unix_write_1 = __webpack_require__(/*! ./unix-write */ "./node_modules/@serialport/bindings-cpp/dist/unix-write.js");
const load_bindings_1 = __webpack_require__(/*! ./load-bindings */ "./node_modules/@serialport/bindings-cpp/dist/load-bindings.js");
const debug = (0, debug_1.default)('serialport/bindings-cpp');
exports.LinuxBinding = {
    list() {
        debug('list');
        return (0, linux_list_1.linuxList)();
    },
    async open(options) {
        if (!options || typeof options !== 'object' || Array.isArray(options)) {
            throw new TypeError('"options" is not an object');
        }
        if (!options.path) {
            throw new TypeError('"path" is not a valid port');
        }
        if (!options.baudRate) {
            throw new TypeError('"baudRate" is not a valid baudRate');
        }
        debug('open');
        const openOptions = Object.assign({ vmin: 1, vtime: 0, dataBits: 8, lock: true, stopBits: 1, parity: 'none', rtscts: false, xon: false, xoff: false, xany: false, hupcl: true }, options);
        const fd = await (0, load_bindings_1.asyncOpen)(openOptions.path, openOptions);
        this.fd = fd;
        return new LinuxPortBinding(fd, openOptions);
    },
};
/**
 * The linux binding layer
 */
class LinuxPortBinding {
    constructor(fd, openOptions) {
        this.fd = fd;
        this.openOptions = openOptions;
        this.poller = new poller_1.Poller(fd);
        this.writeOperation = null;
    }
    get isOpen() {
        return this.fd !== null;
    }
    async close() {
        debug('close');
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        const fd = this.fd;
        this.poller.stop();
        this.poller.destroy();
        this.fd = null;
        await (0, load_bindings_1.asyncClose)(fd);
    }
    async read(buffer, offset, length) {
        if (!Buffer.isBuffer(buffer)) {
            throw new TypeError('"buffer" is not a Buffer');
        }
        if (typeof offset !== 'number' || isNaN(offset)) {
            throw new TypeError(`"offset" is not an integer got "${isNaN(offset) ? 'NaN' : typeof offset}"`);
        }
        if (typeof length !== 'number' || isNaN(length)) {
            throw new TypeError(`"length" is not an integer got "${isNaN(length) ? 'NaN' : typeof length}"`);
        }
        debug('read');
        if (buffer.length < offset + length) {
            throw new Error('buffer is too small');
        }
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        return (0, unix_read_1.unixRead)({ binding: this, buffer, offset, length });
    }
    async write(buffer) {
        if (!Buffer.isBuffer(buffer)) {
            throw new TypeError('"buffer" is not a Buffer');
        }
        debug('write', buffer.length, 'bytes');
        if (!this.isOpen) {
            debug('write', 'error port is not open');
            throw new Error('Port is not open');
        }
        this.writeOperation = (async () => {
            if (buffer.length === 0) {
                return;
            }
            await (0, unix_write_1.unixWrite)({ binding: this, buffer });
            this.writeOperation = null;
        })();
        return this.writeOperation;
    }
    async update(options) {
        if (!options || typeof options !== 'object' || Array.isArray(options)) {
            throw TypeError('"options" is not an object');
        }
        if (typeof options.baudRate !== 'number') {
            throw new TypeError('"options.baudRate" is not a number');
        }
        debug('update');
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        await (0, load_bindings_1.asyncUpdate)(this.fd, options);
    }
    async set(options) {
        if (!options || typeof options !== 'object' || Array.isArray(options)) {
            throw new TypeError('"options" is not an object');
        }
        debug('set');
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        await (0, load_bindings_1.asyncSet)(this.fd, options);
    }
    async get() {
        debug('get');
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        return (0, load_bindings_1.asyncGet)(this.fd);
    }
    async getBaudRate() {
        debug('getBaudRate');
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        return (0, load_bindings_1.asyncGetBaudRate)(this.fd);
    }
    async flush() {
        debug('flush');
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        await (0, load_bindings_1.asyncFlush)(this.fd);
    }
    async drain() {
        debug('drain');
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        await this.writeOperation;
        await (0, load_bindings_1.asyncDrain)(this.fd);
    }
}
exports.LinuxPortBinding = LinuxPortBinding;


/***/ }),

/***/ "./node_modules/@serialport/bindings-cpp/dist/load-bindings.js":
/*!*********************************************************************!*\
  !*** ./node_modules/@serialport/bindings-cpp/dist/load-bindings.js ***!
  \*********************************************************************/
/***/ (function(__unused_webpack_module, exports, __webpack_require__) {

"use strict";

var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", ({ value: true }));
exports.asyncWrite = exports.asyncRead = exports.asyncUpdate = exports.asyncSet = exports.asyncOpen = exports.asyncList = exports.asyncGetBaudRate = exports.asyncGet = exports.asyncFlush = exports.asyncDrain = exports.asyncClose = void 0;
const node_gyp_build_1 = __importDefault(__webpack_require__(/*! node-gyp-build */ "./node_modules/node-gyp-build/index.js"));
const util_1 = __webpack_require__(/*! util */ "util");
const path_1 = __webpack_require__(/*! path */ "path");
const binding = (0, node_gyp_build_1.default)((0, path_1.join)(__dirname, '../'));
exports.asyncClose = binding.close ? (0, util_1.promisify)(binding.close) : async () => { throw new Error('"binding.close" Method not implemented'); };
exports.asyncDrain = binding.drain ? (0, util_1.promisify)(binding.drain) : async () => { throw new Error('"binding.drain" Method not implemented'); };
exports.asyncFlush = binding.flush ? (0, util_1.promisify)(binding.flush) : async () => { throw new Error('"binding.flush" Method not implemented'); };
exports.asyncGet = binding.get ? (0, util_1.promisify)(binding.get) : async () => { throw new Error('"binding.get" Method not implemented'); };
exports.asyncGetBaudRate = binding.getBaudRate ? (0, util_1.promisify)(binding.getBaudRate) : async () => { throw new Error('"binding.getBaudRate" Method not implemented'); };
exports.asyncList = binding.list ? (0, util_1.promisify)(binding.list) : async () => { throw new Error('"binding.list" Method not implemented'); };
exports.asyncOpen = binding.open ? (0, util_1.promisify)(binding.open) : async () => { throw new Error('"binding.open" Method not implemented'); };
exports.asyncSet = binding.set ? (0, util_1.promisify)(binding.set) : async () => { throw new Error('"binding.set" Method not implemented'); };
exports.asyncUpdate = binding.update ? (0, util_1.promisify)(binding.update) : async () => { throw new Error('"binding.update" Method not implemented'); };
exports.asyncRead = binding.read ? (0, util_1.promisify)(binding.read) : async () => { throw new Error('"binding.read" Method not implemented'); };
exports.asyncWrite = binding.read ? (0, util_1.promisify)(binding.write) : async () => { throw new Error('"binding.write" Method not implemented'); };


/***/ }),

/***/ "./node_modules/@serialport/bindings-cpp/dist/poller.js":
/*!**************************************************************!*\
  !*** ./node_modules/@serialport/bindings-cpp/dist/poller.js ***!
  \**************************************************************/
/***/ (function(__unused_webpack_module, exports, __webpack_require__) {

"use strict";

var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", ({ value: true }));
exports.Poller = exports.EVENTS = void 0;
const debug_1 = __importDefault(__webpack_require__(/*! debug */ "./node_modules/debug/src/index.js"));
const events_1 = __webpack_require__(/*! events */ "events");
const path_1 = __webpack_require__(/*! path */ "path");
const node_gyp_build_1 = __importDefault(__webpack_require__(/*! node-gyp-build */ "./node_modules/node-gyp-build/index.js"));
const errors_1 = __webpack_require__(/*! ./errors */ "./node_modules/@serialport/bindings-cpp/dist/errors.js");
const { Poller: PollerBindings } = (0, node_gyp_build_1.default)((0, path_1.join)(__dirname, '../'));
const logger = (0, debug_1.default)('serialport/bindings-cpp/poller');
exports.EVENTS = {
    UV_READABLE: 0b0001,
    UV_WRITABLE: 0b0010,
    UV_DISCONNECT: 0b0100,
};
function handleEvent(error, eventFlag) {
    if (error) {
        logger('error', error);
        this.emit('readable', error);
        this.emit('writable', error);
        this.emit('disconnect', error);
        return;
    }
    if (eventFlag & exports.EVENTS.UV_READABLE) {
        logger('received "readable"');
        this.emit('readable', null);
    }
    if (eventFlag & exports.EVENTS.UV_WRITABLE) {
        logger('received "writable"');
        this.emit('writable', null);
    }
    if (eventFlag & exports.EVENTS.UV_DISCONNECT) {
        logger('received "disconnect"');
        this.emit('disconnect', null);
    }
}
/**
 * Polls unix systems for readable or writable states of a file or serialport
 */
class Poller extends events_1.EventEmitter {
    constructor(fd, FDPoller = PollerBindings) {
        logger('Creating poller');
        super();
        this.poller = new FDPoller(fd, handleEvent.bind(this));
    }
    /**
     * Wait for the next event to occur
     * @param {string} event ('readable'|'writable'|'disconnect')
     * @returns {Poller} returns itself
     */
    once(event, callback) {
        switch (event) {
            case 'readable':
                this.poll(exports.EVENTS.UV_READABLE);
                break;
            case 'writable':
                this.poll(exports.EVENTS.UV_WRITABLE);
                break;
            case 'disconnect':
                this.poll(exports.EVENTS.UV_DISCONNECT);
                break;
        }
        return super.once(event, callback);
    }
    /**
     * Ask the bindings to listen for an event, it is recommend to use `.once()` for easy use
     * @param {EVENTS} eventFlag polls for an event or group of events based upon a flag.
     */
    poll(eventFlag = 0) {
        if (eventFlag & exports.EVENTS.UV_READABLE) {
            logger('Polling for "readable"');
        }
        if (eventFlag & exports.EVENTS.UV_WRITABLE) {
            logger('Polling for "writable"');
        }
        if (eventFlag & exports.EVENTS.UV_DISCONNECT) {
            logger('Polling for "disconnect"');
        }
        this.poller.poll(eventFlag);
    }
    /**
     * Stop listening for events and cancel all outstanding listening with an error
     */
    stop() {
        logger('Stopping poller');
        this.poller.stop();
        this.emitCanceled();
    }
    destroy() {
        logger('Destroying poller');
        this.poller.destroy();
        this.emitCanceled();
    }
    emitCanceled() {
        const err = new errors_1.BindingsError('Canceled', { canceled: true });
        this.emit('readable', err);
        this.emit('writable', err);
        this.emit('disconnect', err);
    }
}
exports.Poller = Poller;


/***/ }),

/***/ "./node_modules/@serialport/bindings-cpp/dist/unix-read.js":
/*!*****************************************************************!*\
  !*** ./node_modules/@serialport/bindings-cpp/dist/unix-read.js ***!
  \*****************************************************************/
/***/ (function(__unused_webpack_module, exports, __webpack_require__) {

"use strict";

var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", ({ value: true }));
exports.unixRead = void 0;
const util_1 = __webpack_require__(/*! util */ "util");
const fs_1 = __webpack_require__(/*! fs */ "fs");
const errors_1 = __webpack_require__(/*! ./errors */ "./node_modules/@serialport/bindings-cpp/dist/errors.js");
const debug_1 = __importDefault(__webpack_require__(/*! debug */ "./node_modules/debug/src/index.js"));
const logger = (0, debug_1.default)('serialport/bindings-cpp/unixRead');
const readAsync = (0, util_1.promisify)(fs_1.read);
const readable = (binding) => {
    return new Promise((resolve, reject) => {
        if (!binding.poller) {
            throw new Error('No poller on bindings');
        }
        binding.poller.once('readable', err => (err ? reject(err) : resolve()));
    });
};
const unixRead = async ({ binding, buffer, offset, length, fsReadAsync = readAsync, }) => {
    logger('Starting read');
    if (!binding.isOpen || !binding.fd) {
        throw new errors_1.BindingsError('Port is not open', { canceled: true });
    }
    try {
        const { bytesRead } = await fsReadAsync(binding.fd, buffer, offset, length, null);
        if (bytesRead === 0) {
            return (0, exports.unixRead)({ binding, buffer, offset, length, fsReadAsync });
        }
        logger('Finished read', bytesRead, 'bytes');
        return { bytesRead, buffer };
    }
    catch (err) {
        logger('read error', err);
        if (err.code === 'EAGAIN' || err.code === 'EWOULDBLOCK' || err.code === 'EINTR') {
            if (!binding.isOpen) {
                throw new errors_1.BindingsError('Port is not open', { canceled: true });
            }
            logger('waiting for readable because of code:', err.code);
            await readable(binding);
            return (0, exports.unixRead)({ binding, buffer, offset, length, fsReadAsync });
        }
        const disconnectError = err.code === 'EBADF' || // Bad file number means we got closed
            err.code === 'ENXIO' || // No such device or address probably usb disconnect
            err.code === 'UNKNOWN' ||
            err.errno === -1; // generic error
        if (disconnectError) {
            err.disconnect = true;
            logger('disconnecting', err);
        }
        throw err;
    }
};
exports.unixRead = unixRead;


/***/ }),

/***/ "./node_modules/@serialport/bindings-cpp/dist/unix-write.js":
/*!******************************************************************!*\
  !*** ./node_modules/@serialport/bindings-cpp/dist/unix-write.js ***!
  \******************************************************************/
/***/ (function(__unused_webpack_module, exports, __webpack_require__) {

"use strict";

var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", ({ value: true }));
exports.unixWrite = void 0;
const fs_1 = __webpack_require__(/*! fs */ "fs");
const debug_1 = __importDefault(__webpack_require__(/*! debug */ "./node_modules/debug/src/index.js"));
const util_1 = __webpack_require__(/*! util */ "util");
const logger = (0, debug_1.default)('serialport/bindings-cpp/unixWrite');
const writeAsync = (0, util_1.promisify)(fs_1.write);
const writable = (binding) => {
    return new Promise((resolve, reject) => {
        binding.poller.once('writable', err => (err ? reject(err) : resolve()));
    });
};
const unixWrite = async ({ binding, buffer, offset = 0, fsWriteAsync = writeAsync }) => {
    const bytesToWrite = buffer.length - offset;
    logger('Starting write', buffer.length, 'bytes offset', offset, 'bytesToWrite', bytesToWrite);
    if (!binding.isOpen || !binding.fd) {
        throw new Error('Port is not open');
    }
    try {
        const { bytesWritten } = await fsWriteAsync(binding.fd, buffer, offset, bytesToWrite);
        logger('write returned: wrote', bytesWritten, 'bytes');
        if (bytesWritten + offset < buffer.length) {
            if (!binding.isOpen) {
                throw new Error('Port is not open');
            }
            return (0, exports.unixWrite)({ binding, buffer, offset: bytesWritten + offset, fsWriteAsync });
        }
        logger('Finished writing', bytesWritten + offset, 'bytes');
    }
    catch (err) {
        logger('write errored', err);
        if (err.code === 'EAGAIN' || err.code === 'EWOULDBLOCK' || err.code === 'EINTR') {
            if (!binding.isOpen) {
                throw new Error('Port is not open');
            }
            logger('waiting for writable because of code:', err.code);
            await writable(binding);
            return (0, exports.unixWrite)({ binding, buffer, offset, fsWriteAsync });
        }
        const disconnectError = err.code === 'EBADF' || // Bad file number means we got closed
            err.code === 'ENXIO' || // No such device or address probably usb disconnect
            err.code === 'UNKNOWN' ||
            err.errno === -1; // generic error
        if (disconnectError) {
            err.disconnect = true;
            logger('disconnecting', err);
        }
        logger('error', err);
        throw err;
    }
};
exports.unixWrite = unixWrite;


/***/ }),

/***/ "./node_modules/@serialport/bindings-cpp/dist/win32-sn-parser.js":
/*!***********************************************************************!*\
  !*** ./node_modules/@serialport/bindings-cpp/dist/win32-sn-parser.js ***!
  \***********************************************************************/
/***/ ((__unused_webpack_module, exports) => {

"use strict";

Object.defineProperty(exports, "__esModule", ({ value: true }));
exports.serialNumParser = void 0;
const PARSERS = [/USB\\(?:.+)\\(.+)/, /FTDIBUS\\(?:.+)\+(.+?)A?\\.+/];
const serialNumParser = (pnpId) => {
    if (!pnpId) {
        return null;
    }
    for (const parser of PARSERS) {
        const sn = pnpId.match(parser);
        if (sn) {
            return sn[1];
        }
    }
    return null;
};
exports.serialNumParser = serialNumParser;


/***/ }),

/***/ "./node_modules/@serialport/bindings-cpp/dist/win32.js":
/*!*************************************************************!*\
  !*** ./node_modules/@serialport/bindings-cpp/dist/win32.js ***!
  \*************************************************************/
/***/ (function(__unused_webpack_module, exports, __webpack_require__) {

"use strict";

var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", ({ value: true }));
exports.WindowsPortBinding = exports.WindowsBinding = void 0;
const debug_1 = __importDefault(__webpack_require__(/*! debug */ "./node_modules/debug/src/index.js"));
const _1 = __webpack_require__(/*! . */ "./node_modules/@serialport/bindings-cpp/dist/index.js");
const load_bindings_1 = __webpack_require__(/*! ./load-bindings */ "./node_modules/@serialport/bindings-cpp/dist/load-bindings.js");
const win32_sn_parser_1 = __webpack_require__(/*! ./win32-sn-parser */ "./node_modules/@serialport/bindings-cpp/dist/win32-sn-parser.js");
const debug = (0, debug_1.default)('serialport/bindings-cpp');
exports.WindowsBinding = {
    async list() {
        const ports = await (0, load_bindings_1.asyncList)();
        // Grab the serial number from the pnp id
        return ports.map(port => {
            if (port.pnpId && !port.serialNumber) {
                const serialNumber = (0, win32_sn_parser_1.serialNumParser)(port.pnpId);
                if (serialNumber) {
                    return Object.assign(Object.assign({}, port), { serialNumber });
                }
            }
            return port;
        });
    },
    async open(options) {
        if (!options || typeof options !== 'object' || Array.isArray(options)) {
            throw new TypeError('"options" is not an object');
        }
        if (!options.path) {
            throw new TypeError('"path" is not a valid port');
        }
        if (!options.baudRate) {
            throw new TypeError('"baudRate" is not a valid baudRate');
        }
        debug('open');
        const openOptions = Object.assign({ dataBits: 8, lock: true, stopBits: 1, parity: 'none', rtscts: false, rtsMode: 'handshake', xon: false, xoff: false, xany: false, hupcl: true }, options);
        const fd = await (0, load_bindings_1.asyncOpen)(openOptions.path, openOptions);
        return new WindowsPortBinding(fd, openOptions);
    },
};
/**
 * The Windows binding layer
 */
class WindowsPortBinding {
    constructor(fd, options) {
        this.fd = fd;
        this.openOptions = options;
        this.writeOperation = null;
    }
    get isOpen() {
        return this.fd !== null;
    }
    async close() {
        debug('close');
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        const fd = this.fd;
        this.fd = null;
        await (0, load_bindings_1.asyncClose)(fd);
    }
    async read(buffer, offset, length) {
        if (!Buffer.isBuffer(buffer)) {
            throw new TypeError('"buffer" is not a Buffer');
        }
        if (typeof offset !== 'number' || isNaN(offset)) {
            throw new TypeError(`"offset" is not an integer got "${isNaN(offset) ? 'NaN' : typeof offset}"`);
        }
        if (typeof length !== 'number' || isNaN(length)) {
            throw new TypeError(`"length" is not an integer got "${isNaN(length) ? 'NaN' : typeof length}"`);
        }
        debug('read');
        if (buffer.length < offset + length) {
            throw new Error('buffer is too small');
        }
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        try {
            const bytesRead = await (0, load_bindings_1.asyncRead)(this.fd, buffer, offset, length);
            return { bytesRead, buffer };
        }
        catch (err) {
            if (!this.isOpen) {
                throw new _1.BindingsError(err.message, { canceled: true });
            }
            throw err;
        }
    }
    async write(buffer) {
        if (!Buffer.isBuffer(buffer)) {
            throw new TypeError('"buffer" is not a Buffer');
        }
        debug('write', buffer.length, 'bytes');
        if (!this.isOpen) {
            debug('write', 'error port is not open');
            throw new Error('Port is not open');
        }
        this.writeOperation = (async () => {
            if (buffer.length === 0) {
                return;
            }
            await (0, load_bindings_1.asyncWrite)(this.fd, buffer);
            this.writeOperation = null;
        })();
        return this.writeOperation;
    }
    async update(options) {
        if (!options || typeof options !== 'object' || Array.isArray(options)) {
            throw TypeError('"options" is not an object');
        }
        if (typeof options.baudRate !== 'number') {
            throw new TypeError('"options.baudRate" is not a number');
        }
        debug('update');
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        await (0, load_bindings_1.asyncUpdate)(this.fd, options);
    }
    async set(options) {
        if (!options || typeof options !== 'object' || Array.isArray(options)) {
            throw new TypeError('"options" is not an object');
        }
        debug('set', options);
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        await (0, load_bindings_1.asyncSet)(this.fd, options);
    }
    async get() {
        debug('get');
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        return (0, load_bindings_1.asyncGet)(this.fd);
    }
    async getBaudRate() {
        debug('getBaudRate');
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        return (0, load_bindings_1.asyncGetBaudRate)(this.fd);
    }
    async flush() {
        debug('flush');
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        await (0, load_bindings_1.asyncFlush)(this.fd);
    }
    async drain() {
        debug('drain');
        if (!this.isOpen) {
            throw new Error('Port is not open');
        }
        await this.writeOperation;
        await (0, load_bindings_1.asyncDrain)(this.fd);
    }
}
exports.WindowsPortBinding = WindowsPortBinding;


/***/ }),

/***/ "./node_modules/@serialport/bindings-interface/dist/index.js":
/*!*******************************************************************!*\
  !*** ./node_modules/@serialport/bindings-interface/dist/index.js ***!
  \*******************************************************************/
/***/ (() => {

"use strict";




/***/ }),

/***/ "./node_modules/@serialport/parser-byte-length/dist/index.js":
/*!*******************************************************************!*\
  !*** ./node_modules/@serialport/parser-byte-length/dist/index.js ***!
  \*******************************************************************/
/***/ ((__unused_webpack_module, exports, __webpack_require__) => {

"use strict";

Object.defineProperty(exports, "__esModule", ({ value: true }));
exports.ByteLengthParser = void 0;
const stream_1 = __webpack_require__(/*! stream */ "stream");
/**
 * Emit data every number of bytes
 *
 * A transform stream that emits data as a buffer after a specific number of bytes are received. Runs in O(n) time.
 */
class ByteLengthParser extends stream_1.Transform {
    constructor(options) {
        super(options);
        if (typeof options.length !== 'number') {
            throw new TypeError('"length" is not a number');
        }
        if (options.length < 1) {
            throw new TypeError('"length" is not greater than 0');
        }
        this.length = options.length;
        this.position = 0;
        this.buffer = Buffer.alloc(this.length);
    }
    _transform(chunk, _encoding, cb) {
        let cursor = 0;
        while (cursor < chunk.length) {
            this.buffer[this.position] = chunk[cursor];
            cursor++;
            this.position++;
            if (this.position === this.length) {
                this.push(this.buffer);
                this.buffer = Buffer.alloc(this.length);
                this.position = 0;
            }
        }
        cb();
    }
    _flush(cb) {
        this.push(this.buffer.slice(0, this.position));
        this.buffer = Buffer.alloc(this.length);
        cb();
    }
}
exports.ByteLengthParser = ByteLengthParser;


/***/ }),

/***/ "./node_modules/@serialport/parser-cctalk/dist/index.js":
/*!**************************************************************!*\
  !*** ./node_modules/@serialport/parser-cctalk/dist/index.js ***!
  \**************************************************************/
/***/ ((__unused_webpack_module, exports, __webpack_require__) => {

"use strict";

Object.defineProperty(exports, "__esModule", ({ value: true }));
exports.CCTalkParser = void 0;
const stream_1 = __webpack_require__(/*! stream */ "stream");
/**
 * Parse the CCTalk protocol
 * @extends Transform
 *
 * A transform stream that emits CCTalk packets as they are received.
 */
class CCTalkParser extends stream_1.Transform {
    constructor(maxDelayBetweenBytesMs = 50) {
        super();
        this.array = [];
        this.cursor = 0;
        this.lastByteFetchTime = 0;
        this.maxDelayBetweenBytesMs = maxDelayBetweenBytesMs;
    }
    _transform(buffer, encoding, cb) {
        if (this.maxDelayBetweenBytesMs > 0) {
            const now = Date.now();
            if (now - this.lastByteFetchTime > this.maxDelayBetweenBytesMs) {
                this.array = [];
                this.cursor = 0;
            }
            this.lastByteFetchTime = now;
        }
        this.cursor += buffer.length;
        // TODO: Better Faster es7 no supported by node 4
        // ES7 allows directly push [...buffer]
        // this.array = this.array.concat(Array.from(buffer)) //Slower ?!?
        Array.from(buffer).map(byte => this.array.push(byte));
        while (this.cursor > 1 && this.cursor >= this.array[1] + 5) {
            // full frame accumulated
            // copy command from the array
            const FullMsgLength = this.array[1] + 5;
            const frame = Buffer.from(this.array.slice(0, FullMsgLength));
            // Preserve Extra Data
            this.array = this.array.slice(frame.length, this.array.length);
            this.cursor -= FullMsgLength;
            this.push(frame);
        }
        cb();
    }
}
exports.CCTalkParser = CCTalkParser;


/***/ }),

/***/ "./node_modules/@serialport/parser-delimiter/dist/index.js":
/*!*****************************************************************!*\
  !*** ./node_modules/@serialport/parser-delimiter/dist/index.js ***!
  \*****************************************************************/
/***/ ((__unused_webpack_module, exports, __webpack_require__) => {

"use strict";

Object.defineProperty(exports, "__esModule", ({ value: true }));
exports.DelimiterParser = void 0;
const stream_1 = __webpack_require__(/*! stream */ "stream");
/**
 * A transform stream that emits data each time a byte sequence is received.
 * @extends Transform
 *
 * To use the `Delimiter` parser, provide a delimiter as a string, buffer, or array of bytes. Runs in O(n) time.
 */
class DelimiterParser extends stream_1.Transform {
    constructor({ delimiter, includeDelimiter = false, ...options }) {
        super(options);
        if (delimiter === undefined) {
            throw new TypeError('"delimiter" is not a bufferable object');
        }
        if (delimiter.length === 0) {
            throw new TypeError('"delimiter" has a 0 or undefined length');
        }
        this.includeDelimiter = includeDelimiter;
        this.delimiter = Buffer.from(delimiter);
        this.buffer = Buffer.alloc(0);
    }
    _transform(chunk, encoding, cb) {
        let data = Buffer.concat([this.buffer, chunk]);
        let position;
        while ((position = data.indexOf(this.delimiter)) !== -1) {
            this.push(data.slice(0, position + (this.includeDelimiter ? this.delimiter.length : 0)));
            data = data.slice(position + this.delimiter.length);
        }
        this.buffer = data;
        cb();
    }
    _flush(cb) {
        this.push(this.buffer);
        this.buffer = Buffer.alloc(0);
        cb();
    }
}
exports.DelimiterParser = DelimiterParser;


/***/ }),

/***/ "./node_modules/@serialport/parser-inter-byte-timeout/dist/index.js":
/*!**************************************************************************!*\
  !*** ./node_modules/@serialport/parser-inter-byte-timeout/dist/index.js ***!
  \**************************************************************************/
/***/ ((__unused_webpack_module, exports, __webpack_require__) => {

"use strict";

Object.defineProperty(exports, "__esModule", ({ value: true }));
exports.InterByteTimeoutParser = void 0;
const stream_1 = __webpack_require__(/*! stream */ "stream");
/**
 * A transform stream that buffers data and emits it after not receiving any bytes for the specified amount of time or hitting a max buffer size.
 */
class InterByteTimeoutParser extends stream_1.Transform {
    constructor({ maxBufferSize = 65536, interval, ...transformOptions }) {
        super(transformOptions);
        if (!interval) {
            throw new TypeError('"interval" is required');
        }
        if (typeof interval !== 'number' || Number.isNaN(interval)) {
            throw new TypeError('"interval" is not a number');
        }
        if (interval < 1) {
            throw new TypeError('"interval" is not greater than 0');
        }
        if (typeof maxBufferSize !== 'number' || Number.isNaN(maxBufferSize)) {
            throw new TypeError('"maxBufferSize" is not a number');
        }
        if (maxBufferSize < 1) {
            throw new TypeError('"maxBufferSize" is not greater than 0');
        }
        this.maxBufferSize = maxBufferSize;
        this.currentPacket = [];
        this.interval = interval;
    }
    _transform(chunk, encoding, cb) {
        if (this.intervalID) {
            clearTimeout(this.intervalID);
        }
        for (let offset = 0; offset < chunk.length; offset++) {
            this.currentPacket.push(chunk[offset]);
            if (this.currentPacket.length >= this.maxBufferSize) {
                this.emitPacket();
            }
        }
        this.intervalID = setTimeout(this.emitPacket.bind(this), this.interval);
        cb();
    }
    emitPacket() {
        if (this.intervalID) {
            clearTimeout(this.intervalID);
        }
        if (this.currentPacket.length > 0) {
            this.push(Buffer.from(this.currentPacket));
        }
        this.currentPacket = [];
    }
    _flush(cb) {
        this.emitPacket();
        cb();
    }
}
exports.InterByteTimeoutParser = InterByteTimeoutParser;


/***/ }),

/***/ "./node_modules/@serialport/parser-packet-length/dist/index.js":
/*!*********************************************************************!*\
  !*** ./node_modules/@serialport/parser-packet-length/dist/index.js ***!
  \*********************************************************************/
/***/ ((__unused_webpack_module, exports, __webpack_require__) => {

"use strict";

Object.defineProperty(exports, "__esModule", ({ value: true }));
exports.PacketLengthParser = void 0;
const stream_1 = __webpack_require__(/*! stream */ "stream");
/**
 * A transform stream that decodes packets with a delimiter and length of payload
 * specified within the data stream.
 * @extends Transform
 * @summary Decodes packets of the general form:
 *       [delimiter][len][payload0] ... [payload0 + len]
 *
 * The length field can be up to 4 bytes and can be at any offset within the packet
 *       [delimiter][header0][header1][len0][len1[payload0] ... [payload0 + len]
 *
 * The offset and number of bytes of the length field need to be provided in options
 * if not 1 byte immediately following the delimiter.
 */
class PacketLengthParser extends stream_1.Transform {
    constructor(options = {}) {
        super(options);
        const { delimiter = 0xaa, packetOverhead = 2, lengthBytes = 1, lengthOffset = 1, maxLen = 0xff } = options;
        this.opts = {
            delimiter,
            packetOverhead,
            lengthBytes,
            lengthOffset,
            maxLen,
        };
        this.buffer = Buffer.alloc(0);
        this.start = false;
    }
    _transform(chunk, encoding, cb) {
        for (let ndx = 0; ndx < chunk.length; ndx++) {
            const byte = chunk[ndx];
            if (byte === this.opts.delimiter) {
                this.start = true;
            }
            if (true === this.start) {
                this.buffer = Buffer.concat([this.buffer, Buffer.from([byte])]);
                if (this.buffer.length >= this.opts.lengthOffset + this.opts.lengthBytes) {
                    const len = this.buffer.readUIntLE(this.opts.lengthOffset, this.opts.lengthBytes);
                    if (this.buffer.length == len + this.opts.packetOverhead || len > this.opts.maxLen) {
                        this.push(this.buffer);
                        this.buffer = Buffer.alloc(0);
                        this.start = false;
                    }
                }
            }
        }
        cb();
    }
    _flush(cb) {
        this.push(this.buffer);
        this.buffer = Buffer.alloc(0);
        cb();
    }
}
exports.PacketLengthParser = PacketLengthParser;


/***/ }),

/***/ "./node_modules/@serialport/parser-readline/dist/index.js":
/*!****************************************************************!*\
  !*** ./node_modules/@serialport/parser-readline/dist/index.js ***!
  \****************************************************************/
/***/ ((__unused_webpack_module, exports, __webpack_require__) => {

"use strict";

Object.defineProperty(exports, "__esModule", ({ value: true }));
exports.ReadlineParser = void 0;
const parser_delimiter_1 = __webpack_require__(/*! @serialport/parser-delimiter */ "./node_modules/@serialport/parser-delimiter/dist/index.js");
/**
 *  A transform stream that emits data after a newline delimiter is received.
 * @summary To use the `Readline` parser, provide a delimiter (defaults to `\n`). Data is emitted as string controllable by the `encoding` option (defaults to `utf8`).
 */
class ReadlineParser extends parser_delimiter_1.DelimiterParser {
    constructor(options) {
        const opts = {
            delimiter: Buffer.from('\n', 'utf8'),
            encoding: 'utf8',
            ...options,
        };
        if (typeof opts.delimiter === 'string') {
            opts.delimiter = Buffer.from(opts.delimiter, opts.encoding);
        }
        super(opts);
    }
}
exports.ReadlineParser = ReadlineParser;


/***/ }),

/***/ "./node_modules/@serialport/parser-ready/dist/index.js":
/*!*************************************************************!*\
  !*** ./node_modules/@serialport/parser-ready/dist/index.js ***!
  \*************************************************************/
/***/ ((__unused_webpack_module, exports, __webpack_require__) => {

"use strict";

Object.defineProperty(exports, "__esModule", ({ value: true }));
exports.ReadyParser = void 0;
const stream_1 = __webpack_require__(/*! stream */ "stream");
/**
 * A transform stream that waits for a sequence of "ready" bytes before emitting a ready event and emitting data events
 *
 * To use the `Ready` parser provide a byte start sequence. After the bytes have been received a ready event is fired and data events are passed through.
 */
class ReadyParser extends stream_1.Transform {
    constructor({ delimiter, ...options }) {
        if (delimiter === undefined) {
            throw new TypeError('"delimiter" is not a bufferable object');
        }
        if (delimiter.length === 0) {
            throw new TypeError('"delimiter" has a 0 or undefined length');
        }
        super(options);
        this.delimiter = Buffer.from(delimiter);
        this.readOffset = 0;
        this.ready = false;
    }
    _transform(chunk, encoding, cb) {
        if (this.ready) {
            this.push(chunk);
            return cb();
        }
        const delimiter = this.delimiter;
        let chunkOffset = 0;
        while (this.readOffset < delimiter.length && chunkOffset < chunk.length) {
            if (delimiter[this.readOffset] === chunk[chunkOffset]) {
                this.readOffset++;
            }
            else {
                this.readOffset = 0;
            }
            chunkOffset++;
        }
        if (this.readOffset === delimiter.length) {
            this.ready = true;
            this.emit('ready');
            const chunkRest = chunk.slice(chunkOffset);
            if (chunkRest.length > 0) {
                this.push(chunkRest);
            }
        }
        cb();
    }
}
exports.ReadyParser = ReadyParser;


/***/ }),

/***/ "./node_modules/@serialport/parser-regex/dist/index.js":
/*!*************************************************************!*\
  !*** ./node_modules/@serialport/parser-regex/dist/index.js ***!
  \*************************************************************/
/***/ ((__unused_webpack_module, exports, __webpack_require__) => {

"use strict";

Object.defineProperty(exports, "__esModule", ({ value: true }));
exports.RegexParser = void 0;
const stream_1 = __webpack_require__(/*! stream */ "stream");
/**
 * A transform stream that uses a regular expression to split the incoming text upon.
 *
 * To use the `Regex` parser provide a regular expression to split the incoming text upon. Data is emitted as string controllable by the `encoding` option (defaults to `utf8`).
 */
class RegexParser extends stream_1.Transform {
    constructor({ regex, ...options }) {
        const opts = {
            encoding: 'utf8',
            ...options,
        };
        if (regex === undefined) {
            throw new TypeError('"options.regex" must be a regular expression pattern or object');
        }
        if (!(regex instanceof RegExp)) {
            regex = new RegExp(regex.toString());
        }
        super(opts);
        this.regex = regex;
        this.data = '';
    }
    _transform(chunk, encoding, cb) {
        const data = this.data + chunk;
        const parts = data.split(this.regex);
        this.data = parts.pop() || '';
        parts.forEach(part => {
            this.push(part);
        });
        cb();
    }
    _flush(cb) {
        this.push(this.data);
        this.data = '';
        cb();
    }
}
exports.RegexParser = RegexParser;


/***/ }),

/***/ "./node_modules/@serialport/parser-slip-encoder/dist/decoder.js":
/*!**********************************************************************!*\
  !*** ./node_modules/@serialport/parser-slip-encoder/dist/decoder.js ***!
  \**********************************************************************/
/***/ ((__unused_webpack_module, exports, __webpack_require__) => {

"use strict";

Object.defineProperty(exports, "__esModule", ({ value: true }));
exports.SlipDecoder = void 0;
const stream_1 = __webpack_require__(/*! stream */ "stream");
/**
 * A transform stream that decodes slip encoded data.
 * @extends Transform
 *
 * Runs in O(n) time, stripping out slip encoding and emitting decoded data. Optionally custom slip escape and delimiters can be provided.
 */
class SlipDecoder extends stream_1.Transform {
    constructor(options = {}) {
        super(options);
        const { START, ESC = 0xdb, END = 0xc0, ESC_START, ESC_END = 0xdc, ESC_ESC = 0xdd } = options;
        this.opts = {
            START,
            ESC,
            END,
            ESC_START,
            ESC_END,
            ESC_ESC,
        };
        this.buffer = Buffer.alloc(0);
        this.escape = false;
        this.start = false;
    }
    _transform(chunk, encoding, cb) {
        for (let ndx = 0; ndx < chunk.length; ndx++) {
            let byte = chunk[ndx];
            if (byte === this.opts.START) {
                this.start = true;
                continue;
            }
            else if (undefined == this.opts.START) {
                this.start = true;
            }
            if (this.escape) {
                if (byte === this.opts.ESC_START && this.opts.START) {
                    byte = this.opts.START;
                }
                else if (byte === this.opts.ESC_ESC) {
                    byte = this.opts.ESC;
                }
                else if (byte === this.opts.ESC_END) {
                    byte = this.opts.END;
                }
                else {
                    this.escape = false;
                    this.push(this.buffer);
                    this.buffer = Buffer.alloc(0);
                }
            }
            else {
                if (byte === this.opts.ESC) {
                    this.escape = true;
                    continue;
                }
                if (byte === this.opts.END) {
                    this.push(this.buffer);
                    this.buffer = Buffer.alloc(0);
                    this.escape = false;
                    this.start = false;
                    continue;
                }
            }
            this.escape = false;
            if (this.start) {
                this.buffer = Buffer.concat([this.buffer, Buffer.from([byte])]);
            }
        }
        cb();
    }
    _flush(cb) {
        this.push(this.buffer);
        this.buffer = Buffer.alloc(0);
        cb();
    }
}
exports.SlipDecoder = SlipDecoder;


/***/ }),

/***/ "./node_modules/@serialport/parser-slip-encoder/dist/encoder.js":
/*!**********************************************************************!*\
  !*** ./node_modules/@serialport/parser-slip-encoder/dist/encoder.js ***!
  \**********************************************************************/
/***/ ((__unused_webpack_module, exports, __webpack_require__) => {

"use strict";

Object.defineProperty(exports, "__esModule", ({ value: true }));
exports.SlipEncoder = void 0;
const stream_1 = __webpack_require__(/*! stream */ "stream");
/**
 * A transform stream that emits SLIP-encoded data for each incoming packet.
 *
 * Runs in O(n) time, adding a 0xC0 character at the end of each
 * received packet and escaping characters, according to RFC 1055.
 */
class SlipEncoder extends stream_1.Transform {
    constructor(options = {}) {
        super(options);
        const { START, ESC = 0xdb, END = 0xc0, ESC_START, ESC_END = 0xdc, ESC_ESC = 0xdd, bluetoothQuirk = false } = options;
        this.opts = {
            START,
            ESC,
            END,
            ESC_START,
            ESC_END,
            ESC_ESC,
            bluetoothQuirk,
        };
    }
    _transform(chunk, encoding, cb) {
        const chunkLength = chunk.length;
        if (this.opts.bluetoothQuirk && chunkLength === 0) {
            // Edge case: push no data. Bluetooth-quirky SLIP parsers don't like
            // lots of 0xC0s together.
            return cb();
        }
        // Allocate memory for the worst-case scenario: all bytes are escaped,
        // plus start and end separators.
        const encoded = Buffer.alloc(chunkLength * 2 + 2);
        let j = 0;
        if (this.opts.bluetoothQuirk == true) {
            encoded[j++] = this.opts.END;
        }
        if (this.opts.START !== undefined) {
            encoded[j++] = this.opts.START;
        }
        for (let i = 0; i < chunkLength; i++) {
            let byte = chunk[i];
            if (byte === this.opts.START && this.opts.ESC_START) {
                encoded[j++] = this.opts.ESC;
                byte = this.opts.ESC_START;
            }
            else if (byte === this.opts.END) {
                encoded[j++] = this.opts.ESC;
                byte = this.opts.ESC_END;
            }
            else if (byte === this.opts.ESC) {
                encoded[j++] = this.opts.ESC;
                byte = this.opts.ESC_ESC;
            }
            encoded[j++] = byte;
        }
        encoded[j++] = this.opts.END;
        cb(null, encoded.slice(0, j));
    }
}
exports.SlipEncoder = SlipEncoder;


/***/ }),

/***/ "./node_modules/@serialport/parser-slip-encoder/dist/index.js":
/*!********************************************************************!*\
  !*** ./node_modules/@serialport/parser-slip-encoder/dist/index.js ***!
  \********************************************************************/
/***/ (function(__unused_webpack_module, exports, __webpack_require__) {

"use strict";

var __createBinding = (this && this.__createBinding) || (Object.create ? (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    Object.defineProperty(o, k2, { enumerable: true, get: function() { return m[k]; } });
}) : (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    o[k2] = m[k];
}));
var __exportStar = (this && this.__exportStar) || function(m, exports) {
    for (var p in m) if (p !== "default" && !Object.prototype.hasOwnProperty.call(exports, p)) __createBinding(exports, m, p);
};
Object.defineProperty(exports, "__esModule", ({ value: true }));
__exportStar(__webpack_require__(/*! ./decoder */ "./node_modules/@serialport/parser-slip-encoder/dist/decoder.js"), exports);
__exportStar(__webpack_require__(/*! ./encoder */ "./node_modules/@serialport/parser-slip-encoder/dist/encoder.js"), exports);


/***/ }),

/***/ "./node_modules/@serialport/parser-spacepacket/dist/index.js":
/*!*******************************************************************!*\
  !*** ./node_modules/@serialport/parser-spacepacket/dist/index.js ***!
  \*******************************************************************/
/***/ ((__unused_webpack_module, exports, __webpack_require__) => {

"use strict";

Object.defineProperty(exports, "__esModule", ({ value: true }));
exports.SpacePacketParser = void 0;
const stream_1 = __webpack_require__(/*! stream */ "stream");
const utils_1 = __webpack_require__(/*! ./utils */ "./node_modules/@serialport/parser-spacepacket/dist/utils.js");
/**
 * A Transform stream that accepts a stream of octet data and converts it into an object
 * representation of a CCSDS Space Packet. See https://public.ccsds.org/Pubs/133x0b2e1.pdf for a
 * description of the Space Packet format.
 */
class SpacePacketParser extends stream_1.Transform {
    /**
     * A Transform stream that accepts a stream of octet data and emits object representations of
     * CCSDS Space Packets once a packet has been completely received.
     * @param {Object} [options] Configuration options for the stream
     * @param {Number} options.timeCodeFieldLength The length of the time code field within the data
     * @param {Number} options.ancillaryDataFieldLength The length of the ancillary data field within the data
     */
    constructor(options = {}) {
        super({ ...options, objectMode: true });
        // Set the constants for this Space Packet Connection; these will help us parse incoming data
        // fields:
        this.timeCodeFieldLength = options.timeCodeFieldLength || 0;
        this.ancillaryDataFieldLength = options.ancillaryDataFieldLength || 0;
        this.dataSlice = this.timeCodeFieldLength + this.ancillaryDataFieldLength;
        // These are stateful based on the current packet being received:
        this.dataBuffer = Buffer.alloc(0);
        this.headerBuffer = Buffer.alloc(0);
        this.dataLength = 0;
        this.expectingHeader = true;
    }
    /**
     * Bundle the header, secondary header if present, and the data into a JavaScript object to emit.
     * If more data has been received past the current packet, begin the process of parsing the next
     * packet(s).
     */
    pushCompletedPacket() {
        if (!this.header) {
            throw new Error('Missing header');
        }
        const timeCode = Buffer.from(this.dataBuffer.slice(0, this.timeCodeFieldLength));
        const ancillaryData = Buffer.from(this.dataBuffer.slice(this.timeCodeFieldLength, this.timeCodeFieldLength + this.ancillaryDataFieldLength));
        const data = Buffer.from(this.dataBuffer.slice(this.dataSlice, this.dataLength));
        const completedPacket = {
            header: { ...this.header },
            data: data.toString(),
        };
        if (timeCode.length > 0 || ancillaryData.length > 0) {
            completedPacket.secondaryHeader = {};
            if (timeCode.length) {
                completedPacket.secondaryHeader.timeCode = timeCode.toString();
            }
            if (ancillaryData.length) {
                completedPacket.secondaryHeader.ancillaryData = ancillaryData.toString();
            }
        }
        this.push(completedPacket);
        // If there is an overflow (i.e. we have more data than the packet we just pushed) begin parsing
        // the next packet.
        const nextChunk = Buffer.from(this.dataBuffer.slice(this.dataLength));
        if (nextChunk.length >= utils_1.HEADER_LENGTH) {
            this.extractHeader(nextChunk);
        }
        else {
            this.headerBuffer = nextChunk;
            this.dataBuffer = Buffer.alloc(0);
            this.expectingHeader = true;
            this.dataLength = 0;
            this.header = undefined;
        }
    }
    /**
     * Build the Stream's headerBuffer property from the received Buffer chunk; extract data from it
     * if it's complete. If there's more to the chunk than just the header, initiate handling the
     * packet data.
     * @param chunk -  Build the Stream's headerBuffer property from
     */
    extractHeader(chunk) {
        const headerAsBuffer = Buffer.concat([this.headerBuffer, chunk]);
        const startOfDataBuffer = headerAsBuffer.slice(utils_1.HEADER_LENGTH);
        if (headerAsBuffer.length >= utils_1.HEADER_LENGTH) {
            this.header = (0, utils_1.convertHeaderBufferToObj)(headerAsBuffer);
            this.dataLength = this.header.dataLength;
            this.headerBuffer = Buffer.alloc(0);
            this.expectingHeader = false;
        }
        else {
            this.headerBuffer = headerAsBuffer;
        }
        if (startOfDataBuffer.length > 0) {
            this.dataBuffer = Buffer.from(startOfDataBuffer);
            if (this.dataBuffer.length >= this.dataLength) {
                this.pushCompletedPacket();
            }
        }
    }
    _transform(chunk, encoding, cb) {
        if (this.expectingHeader) {
            this.extractHeader(chunk);
        }
        else {
            this.dataBuffer = Buffer.concat([this.dataBuffer, chunk]);
            if (this.dataBuffer.length >= this.dataLength) {
                this.pushCompletedPacket();
            }
        }
        cb();
    }
    _flush(cb) {
        const remaining = Buffer.concat([this.headerBuffer, this.dataBuffer]);
        const remainingArray = Array.from(remaining);
        this.push(remainingArray);
        cb();
    }
}
exports.SpacePacketParser = SpacePacketParser;


/***/ }),

/***/ "./node_modules/@serialport/parser-spacepacket/dist/utils.js":
/*!*******************************************************************!*\
  !*** ./node_modules/@serialport/parser-spacepacket/dist/utils.js ***!
  \*******************************************************************/
/***/ ((__unused_webpack_module, exports) => {

"use strict";

Object.defineProperty(exports, "__esModule", ({ value: true }));
exports.convertHeaderBufferToObj = exports.HEADER_LENGTH = void 0;
exports.HEADER_LENGTH = 6;
/**
 * For numbers less than 255, will ensure that their string representation is at least 8 characters long.
 */
const toOctetStr = (num) => {
    let str = Number(num).toString(2);
    while (str.length < 8) {
        str = `0${str}`;
    }
    return str;
};
/**
 * Converts a Buffer of any length to an Object representation of a Space Packet header, provided
 * the received data is in the correct format.
 * @param buf - The buffer containing the Space Packet Header Data
 */
const convertHeaderBufferToObj = (buf) => {
    const headerStr = Array.from(buf.slice(0, exports.HEADER_LENGTH)).reduce((accum, curr) => `${accum}${toOctetStr(curr)}`, '');
    const isVersion1 = headerStr.slice(0, 3) === '000';
    const versionNumber = isVersion1 ? 1 : 'UNKNOWN_VERSION';
    const type = Number(headerStr[3]);
    const secondaryHeader = Number(headerStr[4]);
    const apid = parseInt(headerStr.slice(5, 16), 2);
    const sequenceFlags = parseInt(headerStr.slice(16, 18), 2);
    const packetName = parseInt(headerStr.slice(18, 32), 2);
    const dataLength = parseInt(headerStr.slice(-16), 2) + 1;
    return {
        versionNumber,
        identification: {
            apid,
            secondaryHeader,
            type,
        },
        sequenceControl: {
            packetName,
            sequenceFlags,
        },
        dataLength,
    };
};
exports.convertHeaderBufferToObj = convertHeaderBufferToObj;


/***/ }),

/***/ "./node_modules/@serialport/stream/dist/index.js":
/*!*******************************************************!*\
  !*** ./node_modules/@serialport/stream/dist/index.js ***!
  \*******************************************************/
/***/ (function(__unused_webpack_module, exports, __webpack_require__) {

"use strict";

var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", ({ value: true }));
exports.SerialPortStream = exports.DisconnectedError = void 0;
const stream_1 = __webpack_require__(/*! stream */ "stream");
const debug_1 = __importDefault(__webpack_require__(/*! debug */ "./node_modules/debug/src/index.js"));
const debug = (0, debug_1.default)('serialport/stream');
class DisconnectedError extends Error {
    constructor(message) {
        super(message);
        this.disconnected = true;
    }
}
exports.DisconnectedError = DisconnectedError;
const defaultSetFlags = {
    brk: false,
    cts: false,
    dtr: true,
    rts: true,
};
function allocNewReadPool(poolSize) {
    const pool = Buffer.allocUnsafe(poolSize);
    pool.used = 0;
    return pool;
}
class SerialPortStream extends stream_1.Duplex {
    /**
     * Create a new serial port object for the `path`. In the case of invalid arguments or invalid options, when constructing a new SerialPort it will throw an error. The port will open automatically by default, which is the equivalent of calling `port.open(openCallback)` in the next tick. You can disable this by setting the option `autoOpen` to `false`.
     * @emits open
     * @emits data
     * @emits close
     * @emits error
     */
    constructor(options, openCallback) {
        const settings = {
            autoOpen: true,
            endOnClose: false,
            highWaterMark: 64 * 1024,
            ...options,
        };
        super({
            highWaterMark: settings.highWaterMark,
        });
        if (!settings.binding) {
            throw new TypeError('"Bindings" is invalid pass it as `options.binding`');
        }
        if (!settings.path) {
            throw new TypeError(`"path" is not defined: ${settings.path}`);
        }
        if (typeof settings.baudRate !== 'number') {
            throw new TypeError(`"baudRate" must be a number: ${settings.baudRate}`);
        }
        this.settings = settings;
        this.opening = false;
        this.closing = false;
        this._pool = allocNewReadPool(this.settings.highWaterMark);
        this._kMinPoolSpace = 128;
        if (this.settings.autoOpen) {
            this.open(openCallback);
        }
    }
    get path() {
        return this.settings.path;
    }
    get baudRate() {
        return this.settings.baudRate;
    }
    get isOpen() {
        var _a, _b;
        return ((_b = (_a = this.port) === null || _a === void 0 ? void 0 : _a.isOpen) !== null && _b !== void 0 ? _b : false) && !this.closing;
    }
    _error(error, callback) {
        if (callback) {
            callback.call(this, error);
        }
        else {
            this.emit('error', error);
        }
    }
    _asyncError(error, callback) {
        process.nextTick(() => this._error(error, callback));
    }
    /**
     * Opens a connection to the given serial port.
     * @param {ErrorCallback=} openCallback - Called after a connection is opened. If this is not provided and an error occurs, it will be emitted on the port's `error` event.
     * @emits open
     */
    open(openCallback) {
        if (this.isOpen) {
            return this._asyncError(new Error('Port is already open'), openCallback);
        }
        if (this.opening) {
            return this._asyncError(new Error('Port is opening'), openCallback);
        }
        // eslint-disable-next-line @typescript-eslint/no-unused-vars
        const { highWaterMark, binding, autoOpen, endOnClose, ...openOptions } = this.settings;
        this.opening = true;
        debug('opening', `path: ${this.path}`);
        this.settings.binding.open(openOptions).then(port => {
            debug('opened', `path: ${this.path}`);
            this.port = port;
            this.opening = false;
            this.emit('open');
            if (openCallback) {
                openCallback.call(this, null);
            }
        }, err => {
            this.opening = false;
            debug('Binding #open had an error', err);
            this._error(err, openCallback);
        });
    }
    /**
     * Changes the baud rate for an open port. Emits an error or calls the callback if the baud rate isn't supported.
     * @param {object=} options Only supports `baudRate`.
     * @param {number=} [options.baudRate] The baud rate of the port to be opened. This should match one of the commonly available baud rates, such as 110, 300, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 57600, or 115200. Custom rates are supported best effort per platform. The device connected to the serial port is not guaranteed to support the requested baud rate, even if the port itself supports that baud rate.
     * @param {ErrorCallback=} [callback] Called once the port's baud rate changes. If `.update` is called without a callback, and there is an error, an error event is emitted.
     * @returns {undefined}
     */
    update(options, callback) {
        if (!this.isOpen || !this.port) {
            debug('update attempted, but port is not open');
            return this._asyncError(new Error('Port is not open'), callback);
        }
        debug('update', `baudRate: ${options.baudRate}`);
        this.port.update(options).then(() => {
            debug('binding.update', 'finished');
            this.settings.baudRate = options.baudRate;
            if (callback) {
                callback.call(this, null);
            }
        }, err => {
            debug('binding.update', 'error', err);
            return this._error(err, callback);
        });
    }
    write(data, encoding, callback) {
        if (Array.isArray(data)) {
            data = Buffer.from(data);
        }
        if (typeof encoding === 'function') {
            return super.write(data, encoding);
        }
        return super.write(data, encoding, callback);
    }
    _write(data, encoding, callback) {
        if (!this.isOpen || !this.port) {
            this.once('open', () => {
                this._write(data, encoding, callback);
            });
            return;
        }
        debug('_write', `${data.length} bytes of data`);
        this.port.write(data).then(() => {
            debug('binding.write', 'write finished');
            callback(null);
        }, err => {
            debug('binding.write', 'error', err);
            if (!err.canceled) {
                this._disconnected(err);
            }
            callback(err);
        });
    }
    _writev(data, callback) {
        debug('_writev', `${data.length} chunks of data`);
        const dataV = data.map(write => write.chunk);
        this._write(Buffer.concat(dataV), undefined, callback);
    }
    _read(bytesToRead) {
        if (!this.isOpen || !this.port) {
            debug('_read', 'queueing _read for after open');
            this.once('open', () => {
                this._read(bytesToRead);
            });
            return;
        }
        if (!this._pool || this._pool.length - this._pool.used < this._kMinPoolSpace) {
            debug('_read', 'discarding the read buffer pool because it is below kMinPoolSpace');
            this._pool = allocNewReadPool(this.settings.highWaterMark);
        }
        // Grab another reference to the pool in the case that while we're
        // in the thread pool another read() finishes up the pool, and
        // allocates a new one.
        const pool = this._pool;
        // Read the smaller of rest of the pool or however many bytes we want
        const toRead = Math.min(pool.length - pool.used, bytesToRead);
        const start = pool.used;
        // the actual read.
        debug('_read', `reading`, { start, toRead });
        this.port.read(pool, start, toRead).then(({ bytesRead }) => {
            debug('binding.read', `finished`, { bytesRead });
            // zero bytes means read means we've hit EOF? Maybe this should be an error
            if (bytesRead === 0) {
                debug('binding.read', 'Zero bytes read closing readable stream');
                this.push(null);
                return;
            }
            pool.used += bytesRead;
            this.push(pool.slice(start, start + bytesRead));
        }, err => {
            debug('binding.read', `error`, err);
            if (!err.canceled) {
                this._disconnected(err);
            }
            this._read(bytesToRead); // prime to read more once we're reconnected
        });
    }
    _disconnected(err) {
        if (!this.isOpen) {
            debug('disconnected aborted because already closed', err);
            return;
        }
        debug('disconnected', err);
        this.close(undefined, new DisconnectedError(err.message));
    }
    /**
     * Closes an open connection.
     *
     * If there are in progress writes when the port is closed the writes will error.
     * @param {ErrorCallback} callback Called once a connection is closed.
     * @param {Error} disconnectError used internally to propagate a disconnect error
     */
    close(callback, disconnectError = null) {
        if (!this.isOpen || !this.port) {
            debug('close attempted, but port is not open');
            return this._asyncError(new Error('Port is not open'), callback);
        }
        this.closing = true;
        debug('#close');
        this.port.close().then(() => {
            this.closing = false;
            debug('binding.close', 'finished');
            this.emit('close', disconnectError);
            if (this.settings.endOnClose) {
                this.emit('end');
            }
            if (callback) {
                callback.call(this, disconnectError);
            }
        }, err => {
            this.closing = false;
            debug('binding.close', 'had an error', err);
            return this._error(err, callback);
        });
    }
    /**
     * Set control flags on an open port. Uses [`SetCommMask`](https://msdn.microsoft.com/en-us/library/windows/desktop/aa363257(v=vs.85).aspx) for Windows and [`ioctl`](http://linux.die.net/man/4/tty_ioctl) for OS X and Linux.
     *
     * All options are operating system default when the port is opened. Every flag is set on each call to the provided or default values. If options isn't provided default options is used.
     */
    set(options, callback) {
        if (!this.isOpen || !this.port) {
            debug('set attempted, but port is not open');
            return this._asyncError(new Error('Port is not open'), callback);
        }
        const settings = { ...defaultSetFlags, ...options };
        debug('#set', settings);
        this.port.set(settings).then(() => {
            debug('binding.set', 'finished');
            if (callback) {
                callback.call(this, null);
            }
        }, err => {
            debug('binding.set', 'had an error', err);
            return this._error(err, callback);
        });
    }
    /**
     * Returns the control flags (CTS, DSR, DCD) on the open port.
     * Uses [`GetCommModemStatus`](https://msdn.microsoft.com/en-us/library/windows/desktop/aa363258(v=vs.85).aspx) for Windows and [`ioctl`](http://linux.die.net/man/4/tty_ioctl) for mac and linux.
     */
    get(callback) {
        if (!this.isOpen || !this.port) {
            debug('get attempted, but port is not open');
            return this._asyncError(new Error('Port is not open'), callback);
        }
        debug('#get');
        this.port.get().then(status => {
            debug('binding.get', 'finished');
            callback.call(this, null, status);
        }, err => {
            debug('binding.get', 'had an error', err);
            return this._error(err, callback);
        });
    }
    /**
     * Flush discards data received but not read, and written but not transmitted by the operating system. For more technical details, see [`tcflush(fd, TCIOFLUSH)`](http://linux.die.net/man/3/tcflush) for Mac/Linux and [`FlushFileBuffers`](http://msdn.microsoft.com/en-us/library/windows/desktop/aa364439) for Windows.
     */
    flush(callback) {
        if (!this.isOpen || !this.port) {
            debug('flush attempted, but port is not open');
            return this._asyncError(new Error('Port is not open'), callback);
        }
        debug('#flush');
        this.port.flush().then(() => {
            debug('binding.flush', 'finished');
            if (callback) {
                callback.call(this, null);
            }
        }, err => {
            debug('binding.flush', 'had an error', err);
            return this._error(err, callback);
        });
    }
    /**
     * Waits until all output data is transmitted to the serial port. After any pending write has completed it calls [`tcdrain()`](http://linux.die.net/man/3/tcdrain) or [FlushFileBuffers()](https://msdn.microsoft.com/en-us/library/windows/desktop/aa364439(v=vs.85).aspx) to ensure it has been written to the device.
    * @example
    Write the `data` and wait until it has finished transmitting to the target serial port before calling the callback. This will queue until the port is open and writes are finished.
  
    ```js
    function writeAndDrain (data, callback) {
      port.write(data);
      port.drain(callback);
    }
    ```
    */
    drain(callback) {
        debug('drain');
        if (!this.isOpen || !this.port) {
            debug('drain queuing on port open');
            this.once('open', () => {
                this.drain(callback);
            });
            return;
        }
        this.port.drain().then(() => {
            debug('binding.drain', 'finished');
            if (callback) {
                callback.call(this, null);
            }
        }, err => {
            debug('binding.drain', 'had an error', err);
            return this._error(err, callback);
        });
    }
}
exports.SerialPortStream = SerialPortStream;
/**
 * The `error` event's callback is called with an error object whenever there is an error.
 * @event error
 */
/**
 * The `open` event's callback is called with no arguments when the port is opened and ready for writing. This happens if you have the constructor open immediately (which opens in the next tick) or if you open the port manually with `open()`. See [Useage/Opening a Port](#opening-a-port) for more information.
 * @event open
 */
/**
 * Request a number of bytes from the SerialPort. The `read()` method pulls some data out of the internal buffer and returns it. If no data is available to be read, null is returned. By default, the data is returned as a `Buffer` object unless an encoding has been specified using the `.setEncoding()` method.
 * @method SerialPort.prototype.read
 * @param {number=} size Specify how many bytes of data to return, if available
 * @returns {(string|Buffer|null)} The data from internal buffers
 */
/**
 * Listening for the `data` event puts the port in flowing mode. Data is emitted as soon as it's received. Data is a `Buffer` object with a varying amount of data in it. The `readLine` parser converts the data into string lines. See the [parsers](https://serialport.io/docs/api-parsers-overview) section for more information on parsers, and the [Node.js stream documentation](https://nodejs.org/api/stream.html#stream_event_data) for more information on the data event.
 * @event data
 */
/**
 * The `close` event's callback is called with no arguments when the port is closed. In the case of a disconnect it will be called with a Disconnect Error object (`err.disconnected == true`). In the event of a close error (unlikely), an error event is triggered.
 * @event close
 */
/**
 * The `pause()` method causes a stream in flowing mode to stop emitting 'data' events, switching out of flowing mode. Any data that becomes available remains in the internal buffer.
 * @method SerialPort.prototype.pause
 * @see resume
 * @returns `this`
 */
/**
 * The `resume()` method causes an explicitly paused, `Readable` stream to resume emitting 'data' events, switching the stream into flowing mode.
 * @method SerialPort.prototype.resume
 * @see pause
 * @returns `this`
 */


/***/ }),

/***/ "./node_modules/debug/src/browser.js":
/*!*******************************************!*\
  !*** ./node_modules/debug/src/browser.js ***!
  \*******************************************/
/***/ ((module, exports, __webpack_require__) => {

/* eslint-env browser */

/**
 * This is the web browser implementation of `debug()`.
 */

exports.formatArgs = formatArgs;
exports.save = save;
exports.load = load;
exports.useColors = useColors;
exports.storage = localstorage();
exports.destroy = (() => {
	let warned = false;

	return () => {
		if (!warned) {
			warned = true;
			console.warn('Instance method `debug.destroy()` is deprecated and no longer does anything. It will be removed in the next major version of `debug`.');
		}
	};
})();

/**
 * Colors.
 */

exports.colors = [
	'#0000CC',
	'#0000FF',
	'#0033CC',
	'#0033FF',
	'#0066CC',
	'#0066FF',
	'#0099CC',
	'#0099FF',
	'#00CC00',
	'#00CC33',
	'#00CC66',
	'#00CC99',
	'#00CCCC',
	'#00CCFF',
	'#3300CC',
	'#3300FF',
	'#3333CC',
	'#3333FF',
	'#3366CC',
	'#3366FF',
	'#3399CC',
	'#3399FF',
	'#33CC00',
	'#33CC33',
	'#33CC66',
	'#33CC99',
	'#33CCCC',
	'#33CCFF',
	'#6600CC',
	'#6600FF',
	'#6633CC',
	'#6633FF',
	'#66CC00',
	'#66CC33',
	'#9900CC',
	'#9900FF',
	'#9933CC',
	'#9933FF',
	'#99CC00',
	'#99CC33',
	'#CC0000',
	'#CC0033',
	'#CC0066',
	'#CC0099',
	'#CC00CC',
	'#CC00FF',
	'#CC3300',
	'#CC3333',
	'#CC3366',
	'#CC3399',
	'#CC33CC',
	'#CC33FF',
	'#CC6600',
	'#CC6633',
	'#CC9900',
	'#CC9933',
	'#CCCC00',
	'#CCCC33',
	'#FF0000',
	'#FF0033',
	'#FF0066',
	'#FF0099',
	'#FF00CC',
	'#FF00FF',
	'#FF3300',
	'#FF3333',
	'#FF3366',
	'#FF3399',
	'#FF33CC',
	'#FF33FF',
	'#FF6600',
	'#FF6633',
	'#FF9900',
	'#FF9933',
	'#FFCC00',
	'#FFCC33'
];

/**
 * Currently only WebKit-based Web Inspectors, Firefox >= v31,
 * and the Firebug extension (any Firefox version) are known
 * to support "%c" CSS customizations.
 *
 * TODO: add a `localStorage` variable to explicitly enable/disable colors
 */

// eslint-disable-next-line complexity
function useColors() {
	// NB: In an Electron preload script, document will be defined but not fully
	// initialized. Since we know we're in Chrome, we'll just detect this case
	// explicitly
	if (typeof window !== 'undefined' && window.process && (window.process.type === 'renderer' || window.process.__nwjs)) {
		return true;
	}

	// Internet Explorer and Edge do not support colors.
	if (typeof navigator !== 'undefined' && navigator.userAgent && navigator.userAgent.toLowerCase().match(/(edge|trident)\/(\d+)/)) {
		return false;
	}

	// Is webkit? http://stackoverflow.com/a/16459606/376773
	// document is undefined in react-native: https://github.com/facebook/react-native/pull/1632
	return (typeof document !== 'undefined' && document.documentElement && document.documentElement.style && document.documentElement.style.WebkitAppearance) ||
		// Is firebug? http://stackoverflow.com/a/398120/376773
		(typeof window !== 'undefined' && window.console && (window.console.firebug || (window.console.exception && window.console.table))) ||
		// Is firefox >= v31?
		// https://developer.mozilla.org/en-US/docs/Tools/Web_Console#Styling_messages
		(typeof navigator !== 'undefined' && navigator.userAgent && navigator.userAgent.toLowerCase().match(/firefox\/(\d+)/) && parseInt(RegExp.$1, 10) >= 31) ||
		// Double check webkit in userAgent just in case we are in a worker
		(typeof navigator !== 'undefined' && navigator.userAgent && navigator.userAgent.toLowerCase().match(/applewebkit\/(\d+)/));
}

/**
 * Colorize log arguments if enabled.
 *
 * @api public
 */

function formatArgs(args) {
	args[0] = (this.useColors ? '%c' : '') +
		this.namespace +
		(this.useColors ? ' %c' : ' ') +
		args[0] +
		(this.useColors ? '%c ' : ' ') +
		'+' + module.exports.humanize(this.diff);

	if (!this.useColors) {
		return;
	}

	const c = 'color: ' + this.color;
	args.splice(1, 0, c, 'color: inherit');

	// The final "%c" is somewhat tricky, because there could be other
	// arguments passed either before or after the %c, so we need to
	// figure out the correct index to insert the CSS into
	let index = 0;
	let lastC = 0;
	args[0].replace(/%[a-zA-Z%]/g, match => {
		if (match === '%%') {
			return;
		}
		index++;
		if (match === '%c') {
			// We only are interested in the *last* %c
			// (the user may have provided their own)
			lastC = index;
		}
	});

	args.splice(lastC, 0, c);
}

/**
 * Invokes `console.debug()` when available.
 * No-op when `console.debug` is not a "function".
 * If `console.debug` is not available, falls back
 * to `console.log`.
 *
 * @api public
 */
exports.log = console.debug || console.log || (() => {});

/**
 * Save `namespaces`.
 *
 * @param {String} namespaces
 * @api private
 */
function save(namespaces) {
	try {
		if (namespaces) {
			exports.storage.setItem('debug', namespaces);
		} else {
			exports.storage.removeItem('debug');
		}
	} catch (error) {
		// Swallow
		// XXX (@Qix-) should we be logging these?
	}
}

/**
 * Load `namespaces`.
 *
 * @return {String} returns the previously persisted debug modes
 * @api private
 */
function load() {
	let r;
	try {
		r = exports.storage.getItem('debug');
	} catch (error) {
		// Swallow
		// XXX (@Qix-) should we be logging these?
	}

	// If debug isn't set in LS, and we're in Electron, try to load $DEBUG
	if (!r && typeof process !== 'undefined' && 'env' in process) {
		r = process.env.DEBUG;
	}

	return r;
}

/**
 * Localstorage attempts to return the localstorage.
 *
 * This is necessary because safari throws
 * when a user disables cookies/localstorage
 * and you attempt to access it.
 *
 * @return {LocalStorage}
 * @api private
 */

function localstorage() {
	try {
		// TVMLKit (Apple TV JS Runtime) does not have a window object, just localStorage in the global context
		// The Browser also has localStorage in the global context.
		return localStorage;
	} catch (error) {
		// Swallow
		// XXX (@Qix-) should we be logging these?
	}
}

module.exports = __webpack_require__(/*! ./common */ "./node_modules/debug/src/common.js")(exports);

const {formatters} = module.exports;

/**
 * Map %j to `JSON.stringify()`, since no Web Inspectors do that by default.
 */

formatters.j = function (v) {
	try {
		return JSON.stringify(v);
	} catch (error) {
		return '[UnexpectedJSONParseError]: ' + error.message;
	}
};


/***/ }),

/***/ "./node_modules/debug/src/common.js":
/*!******************************************!*\
  !*** ./node_modules/debug/src/common.js ***!
  \******************************************/
/***/ ((module, __unused_webpack_exports, __webpack_require__) => {


/**
 * This is the common logic for both the Node.js and web browser
 * implementations of `debug()`.
 */

function setup(env) {
	createDebug.debug = createDebug;
	createDebug.default = createDebug;
	createDebug.coerce = coerce;
	createDebug.disable = disable;
	createDebug.enable = enable;
	createDebug.enabled = enabled;
	createDebug.humanize = __webpack_require__(/*! ms */ "./node_modules/ms/index.js");
	createDebug.destroy = destroy;

	Object.keys(env).forEach(key => {
		createDebug[key] = env[key];
	});

	/**
	* The currently active debug mode names, and names to skip.
	*/

	createDebug.names = [];
	createDebug.skips = [];

	/**
	* Map of special "%n" handling functions, for the debug "format" argument.
	*
	* Valid key names are a single, lower or upper-case letter, i.e. "n" and "N".
	*/
	createDebug.formatters = {};

	/**
	* Selects a color for a debug namespace
	* @param {String} namespace The namespace string for the debug instance to be colored
	* @return {Number|String} An ANSI color code for the given namespace
	* @api private
	*/
	function selectColor(namespace) {
		let hash = 0;

		for (let i = 0; i < namespace.length; i++) {
			hash = ((hash << 5) - hash) + namespace.charCodeAt(i);
			hash |= 0; // Convert to 32bit integer
		}

		return createDebug.colors[Math.abs(hash) % createDebug.colors.length];
	}
	createDebug.selectColor = selectColor;

	/**
	* Create a debugger with the given `namespace`.
	*
	* @param {String} namespace
	* @return {Function}
	* @api public
	*/
	function createDebug(namespace) {
		let prevTime;
		let enableOverride = null;
		let namespacesCache;
		let enabledCache;

		function debug(...args) {
			// Disabled?
			if (!debug.enabled) {
				return;
			}

			const self = debug;

			// Set `diff` timestamp
			const curr = Number(new Date());
			const ms = curr - (prevTime || curr);
			self.diff = ms;
			self.prev = prevTime;
			self.curr = curr;
			prevTime = curr;

			args[0] = createDebug.coerce(args[0]);

			if (typeof args[0] !== 'string') {
				// Anything else let's inspect with %O
				args.unshift('%O');
			}

			// Apply any `formatters` transformations
			let index = 0;
			args[0] = args[0].replace(/%([a-zA-Z%])/g, (match, format) => {
				// If we encounter an escaped % then don't increase the array index
				if (match === '%%') {
					return '%';
				}
				index++;
				const formatter = createDebug.formatters[format];
				if (typeof formatter === 'function') {
					const val = args[index];
					match = formatter.call(self, val);

					// Now we need to remove `args[index]` since it's inlined in the `format`
					args.splice(index, 1);
					index--;
				}
				return match;
			});

			// Apply env-specific formatting (colors, etc.)
			createDebug.formatArgs.call(self, args);

			const logFn = self.log || createDebug.log;
			logFn.apply(self, args);
		}

		debug.namespace = namespace;
		debug.useColors = createDebug.useColors();
		debug.color = createDebug.selectColor(namespace);
		debug.extend = extend;
		debug.destroy = createDebug.destroy; // XXX Temporary. Will be removed in the next major release.

		Object.defineProperty(debug, 'enabled', {
			enumerable: true,
			configurable: false,
			get: () => {
				if (enableOverride !== null) {
					return enableOverride;
				}
				if (namespacesCache !== createDebug.namespaces) {
					namespacesCache = createDebug.namespaces;
					enabledCache = createDebug.enabled(namespace);
				}

				return enabledCache;
			},
			set: v => {
				enableOverride = v;
			}
		});

		// Env-specific initialization logic for debug instances
		if (typeof createDebug.init === 'function') {
			createDebug.init(debug);
		}

		return debug;
	}

	function extend(namespace, delimiter) {
		const newDebug = createDebug(this.namespace + (typeof delimiter === 'undefined' ? ':' : delimiter) + namespace);
		newDebug.log = this.log;
		return newDebug;
	}

	/**
	* Enables a debug mode by namespaces. This can include modes
	* separated by a colon and wildcards.
	*
	* @param {String} namespaces
	* @api public
	*/
	function enable(namespaces) {
		createDebug.save(namespaces);
		createDebug.namespaces = namespaces;

		createDebug.names = [];
		createDebug.skips = [];

		let i;
		const split = (typeof namespaces === 'string' ? namespaces : '').split(/[\s,]+/);
		const len = split.length;

		for (i = 0; i < len; i++) {
			if (!split[i]) {
				// ignore empty strings
				continue;
			}

			namespaces = split[i].replace(/\*/g, '.*?');

			if (namespaces[0] === '-') {
				createDebug.skips.push(new RegExp('^' + namespaces.slice(1) + '$'));
			} else {
				createDebug.names.push(new RegExp('^' + namespaces + '$'));
			}
		}
	}

	/**
	* Disable debug output.
	*
	* @return {String} namespaces
	* @api public
	*/
	function disable() {
		const namespaces = [
			...createDebug.names.map(toNamespace),
			...createDebug.skips.map(toNamespace).map(namespace => '-' + namespace)
		].join(',');
		createDebug.enable('');
		return namespaces;
	}

	/**
	* Returns true if the given mode name is enabled, false otherwise.
	*
	* @param {String} name
	* @return {Boolean}
	* @api public
	*/
	function enabled(name) {
		if (name[name.length - 1] === '*') {
			return true;
		}

		let i;
		let len;

		for (i = 0, len = createDebug.skips.length; i < len; i++) {
			if (createDebug.skips[i].test(name)) {
				return false;
			}
		}

		for (i = 0, len = createDebug.names.length; i < len; i++) {
			if (createDebug.names[i].test(name)) {
				return true;
			}
		}

		return false;
	}

	/**
	* Convert regexp to namespace
	*
	* @param {RegExp} regxep
	* @return {String} namespace
	* @api private
	*/
	function toNamespace(regexp) {
		return regexp.toString()
			.substring(2, regexp.toString().length - 2)
			.replace(/\.\*\?$/, '*');
	}

	/**
	* Coerce `val`.
	*
	* @param {Mixed} val
	* @return {Mixed}
	* @api private
	*/
	function coerce(val) {
		if (val instanceof Error) {
			return val.stack || val.message;
		}
		return val;
	}

	/**
	* XXX DO NOT USE. This is a temporary stub function.
	* XXX It WILL be removed in the next major release.
	*/
	function destroy() {
		console.warn('Instance method `debug.destroy()` is deprecated and no longer does anything. It will be removed in the next major version of `debug`.');
	}

	createDebug.enable(createDebug.load());

	return createDebug;
}

module.exports = setup;


/***/ }),

/***/ "./node_modules/debug/src/index.js":
/*!*****************************************!*\
  !*** ./node_modules/debug/src/index.js ***!
  \*****************************************/
/***/ ((module, __unused_webpack_exports, __webpack_require__) => {

/**
 * Detect Electron renderer / nwjs process, which is node, but we should
 * treat as a browser.
 */

if (typeof process === 'undefined' || process.type === 'renderer' || process.browser === true || process.__nwjs) {
	module.exports = __webpack_require__(/*! ./browser.js */ "./node_modules/debug/src/browser.js");
} else {
	module.exports = __webpack_require__(/*! ./node.js */ "./node_modules/debug/src/node.js");
}


/***/ }),

/***/ "./node_modules/debug/src/node.js":
/*!****************************************!*\
  !*** ./node_modules/debug/src/node.js ***!
  \****************************************/
/***/ ((module, exports, __webpack_require__) => {

/**
 * Module dependencies.
 */

const tty = __webpack_require__(/*! tty */ "tty");
const util = __webpack_require__(/*! util */ "util");

/**
 * This is the Node.js implementation of `debug()`.
 */

exports.init = init;
exports.log = log;
exports.formatArgs = formatArgs;
exports.save = save;
exports.load = load;
exports.useColors = useColors;
exports.destroy = util.deprecate(
	() => {},
	'Instance method `debug.destroy()` is deprecated and no longer does anything. It will be removed in the next major version of `debug`.'
);

/**
 * Colors.
 */

exports.colors = [6, 2, 3, 4, 5, 1];

try {
	// Optional dependency (as in, doesn't need to be installed, NOT like optionalDependencies in package.json)
	// eslint-disable-next-line import/no-extraneous-dependencies
	const supportsColor = __webpack_require__(/*! supports-color */ "./node_modules/supports-color/index.js");

	if (supportsColor && (supportsColor.stderr || supportsColor).level >= 2) {
		exports.colors = [
			20,
			21,
			26,
			27,
			32,
			33,
			38,
			39,
			40,
			41,
			42,
			43,
			44,
			45,
			56,
			57,
			62,
			63,
			68,
			69,
			74,
			75,
			76,
			77,
			78,
			79,
			80,
			81,
			92,
			93,
			98,
			99,
			112,
			113,
			128,
			129,
			134,
			135,
			148,
			149,
			160,
			161,
			162,
			163,
			164,
			165,
			166,
			167,
			168,
			169,
			170,
			171,
			172,
			173,
			178,
			179,
			184,
			185,
			196,
			197,
			198,
			199,
			200,
			201,
			202,
			203,
			204,
			205,
			206,
			207,
			208,
			209,
			214,
			215,
			220,
			221
		];
	}
} catch (error) {
	// Swallow - we only care if `supports-color` is available; it doesn't have to be.
}

/**
 * Build up the default `inspectOpts` object from the environment variables.
 *
 *   $ DEBUG_COLORS=no DEBUG_DEPTH=10 DEBUG_SHOW_HIDDEN=enabled node script.js
 */

exports.inspectOpts = Object.keys(process.env).filter(key => {
	return /^debug_/i.test(key);
}).reduce((obj, key) => {
	// Camel-case
	const prop = key
		.substring(6)
		.toLowerCase()
		.replace(/_([a-z])/g, (_, k) => {
			return k.toUpperCase();
		});

	// Coerce string value into JS value
	let val = process.env[key];
	if (/^(yes|on|true|enabled)$/i.test(val)) {
		val = true;
	} else if (/^(no|off|false|disabled)$/i.test(val)) {
		val = false;
	} else if (val === 'null') {
		val = null;
	} else {
		val = Number(val);
	}

	obj[prop] = val;
	return obj;
}, {});

/**
 * Is stdout a TTY? Colored output is enabled when `true`.
 */

function useColors() {
	return 'colors' in exports.inspectOpts ?
		Boolean(exports.inspectOpts.colors) :
		tty.isatty(process.stderr.fd);
}

/**
 * Adds ANSI color escape codes if enabled.
 *
 * @api public
 */

function formatArgs(args) {
	const {namespace: name, useColors} = this;

	if (useColors) {
		const c = this.color;
		const colorCode = '\u001B[3' + (c < 8 ? c : '8;5;' + c);
		const prefix = `  ${colorCode};1m${name} \u001B[0m`;

		args[0] = prefix + args[0].split('\n').join('\n' + prefix);
		args.push(colorCode + 'm+' + module.exports.humanize(this.diff) + '\u001B[0m');
	} else {
		args[0] = getDate() + name + ' ' + args[0];
	}
}

function getDate() {
	if (exports.inspectOpts.hideDate) {
		return '';
	}
	return new Date().toISOString() + ' ';
}

/**
 * Invokes `util.format()` with the specified arguments and writes to stderr.
 */

function log(...args) {
	return process.stderr.write(util.format(...args) + '\n');
}

/**
 * Save `namespaces`.
 *
 * @param {String} namespaces
 * @api private
 */
function save(namespaces) {
	if (namespaces) {
		process.env.DEBUG = namespaces;
	} else {
		// If you set a process.env field to null or undefined, it gets cast to the
		// string 'null' or 'undefined'. Just delete instead.
		delete process.env.DEBUG;
	}
}

/**
 * Load `namespaces`.
 *
 * @return {String} returns the previously persisted debug modes
 * @api private
 */

function load() {
	return process.env.DEBUG;
}

/**
 * Init logic for `debug` instances.
 *
 * Create a new `inspectOpts` object in case `useColors` is set
 * differently for a particular `debug` instance.
 */

function init(debug) {
	debug.inspectOpts = {};

	const keys = Object.keys(exports.inspectOpts);
	for (let i = 0; i < keys.length; i++) {
		debug.inspectOpts[keys[i]] = exports.inspectOpts[keys[i]];
	}
}

module.exports = __webpack_require__(/*! ./common */ "./node_modules/debug/src/common.js")(exports);

const {formatters} = module.exports;

/**
 * Map %o to `util.inspect()`, all on a single line.
 */

formatters.o = function (v) {
	this.inspectOpts.colors = this.useColors;
	return util.inspect(v, this.inspectOpts)
		.split('\n')
		.map(str => str.trim())
		.join(' ');
};

/**
 * Map %O to `util.inspect()`, allowing multiple lines if needed.
 */

formatters.O = function (v) {
	this.inspectOpts.colors = this.useColors;
	return util.inspect(v, this.inspectOpts);
};


/***/ }),

/***/ "./node_modules/has-flag/index.js":
/*!****************************************!*\
  !*** ./node_modules/has-flag/index.js ***!
  \****************************************/
/***/ ((module) => {

"use strict";


module.exports = (flag, argv = process.argv) => {
	const prefix = flag.startsWith('-') ? '' : (flag.length === 1 ? '-' : '--');
	const position = argv.indexOf(prefix + flag);
	const terminatorPosition = argv.indexOf('--');
	return position !== -1 && (terminatorPosition === -1 || position < terminatorPosition);
};


/***/ }),

/***/ "./node_modules/ms/index.js":
/*!**********************************!*\
  !*** ./node_modules/ms/index.js ***!
  \**********************************/
/***/ ((module) => {

/**
 * Helpers.
 */

var s = 1000;
var m = s * 60;
var h = m * 60;
var d = h * 24;
var w = d * 7;
var y = d * 365.25;

/**
 * Parse or format the given `val`.
 *
 * Options:
 *
 *  - `long` verbose formatting [false]
 *
 * @param {String|Number} val
 * @param {Object} [options]
 * @throws {Error} throw an error if val is not a non-empty string or a number
 * @return {String|Number}
 * @api public
 */

module.exports = function(val, options) {
  options = options || {};
  var type = typeof val;
  if (type === 'string' && val.length > 0) {
    return parse(val);
  } else if (type === 'number' && isFinite(val)) {
    return options.long ? fmtLong(val) : fmtShort(val);
  }
  throw new Error(
    'val is not a non-empty string or a valid number. val=' +
      JSON.stringify(val)
  );
};

/**
 * Parse the given `str` and return milliseconds.
 *
 * @param {String} str
 * @return {Number}
 * @api private
 */

function parse(str) {
  str = String(str);
  if (str.length > 100) {
    return;
  }
  var match = /^(-?(?:\d+)?\.?\d+) *(milliseconds?|msecs?|ms|seconds?|secs?|s|minutes?|mins?|m|hours?|hrs?|h|days?|d|weeks?|w|years?|yrs?|y)?$/i.exec(
    str
  );
  if (!match) {
    return;
  }
  var n = parseFloat(match[1]);
  var type = (match[2] || 'ms').toLowerCase();
  switch (type) {
    case 'years':
    case 'year':
    case 'yrs':
    case 'yr':
    case 'y':
      return n * y;
    case 'weeks':
    case 'week':
    case 'w':
      return n * w;
    case 'days':
    case 'day':
    case 'd':
      return n * d;
    case 'hours':
    case 'hour':
    case 'hrs':
    case 'hr':
    case 'h':
      return n * h;
    case 'minutes':
    case 'minute':
    case 'mins':
    case 'min':
    case 'm':
      return n * m;
    case 'seconds':
    case 'second':
    case 'secs':
    case 'sec':
    case 's':
      return n * s;
    case 'milliseconds':
    case 'millisecond':
    case 'msecs':
    case 'msec':
    case 'ms':
      return n;
    default:
      return undefined;
  }
}

/**
 * Short format for `ms`.
 *
 * @param {Number} ms
 * @return {String}
 * @api private
 */

function fmtShort(ms) {
  var msAbs = Math.abs(ms);
  if (msAbs >= d) {
    return Math.round(ms / d) + 'd';
  }
  if (msAbs >= h) {
    return Math.round(ms / h) + 'h';
  }
  if (msAbs >= m) {
    return Math.round(ms / m) + 'm';
  }
  if (msAbs >= s) {
    return Math.round(ms / s) + 's';
  }
  return ms + 'ms';
}

/**
 * Long format for `ms`.
 *
 * @param {Number} ms
 * @return {String}
 * @api private
 */

function fmtLong(ms) {
  var msAbs = Math.abs(ms);
  if (msAbs >= d) {
    return plural(ms, msAbs, d, 'day');
  }
  if (msAbs >= h) {
    return plural(ms, msAbs, h, 'hour');
  }
  if (msAbs >= m) {
    return plural(ms, msAbs, m, 'minute');
  }
  if (msAbs >= s) {
    return plural(ms, msAbs, s, 'second');
  }
  return ms + ' ms';
}

/**
 * Pluralization helper.
 */

function plural(ms, msAbs, n, name) {
  var isPlural = msAbs >= n * 1.5;
  return Math.round(ms / n) + ' ' + name + (isPlural ? 's' : '');
}


/***/ }),

/***/ "./node_modules/node-gyp-build/index.js":
/*!**********************************************!*\
  !*** ./node_modules/node-gyp-build/index.js ***!
  \**********************************************/
/***/ ((module, __unused_webpack_exports, __webpack_require__) => {

var fs = __webpack_require__(/*! fs */ "fs")
var path = __webpack_require__(/*! path */ "path")
var os = __webpack_require__(/*! os */ "os")

// Workaround to fix webpack's build warnings: 'the request of a dependency is an expression'
var runtimeRequire =  true ? require : 0 // eslint-disable-line

var vars = (process.config && process.config.variables) || {}
var prebuildsOnly = !!process.env.PREBUILDS_ONLY
var abi = process.versions.modules // TODO: support old node where this is undef
var runtime = isElectron() ? 'electron' : (isNwjs() ? 'node-webkit' : 'node')

var arch = os.arch()
var platform = os.platform()
var libc = process.env.LIBC || (isAlpine(platform) ? 'musl' : 'glibc')
var armv = process.env.ARM_VERSION || (arch === 'arm64' ? '8' : vars.arm_version) || ''
var uv = (process.versions.uv || '').split('.')[0]

module.exports = load

function load (dir) {
  return runtimeRequire(load.path(dir))
}

load.path = function (dir) {
  dir = path.resolve(dir || '.')

  try {
    var name = runtimeRequire(path.join(dir, 'package.json')).name.toUpperCase().replace(/-/g, '_')
    if (process.env[name + '_PREBUILD']) dir = process.env[name + '_PREBUILD']
  } catch (err) {}

  if (!prebuildsOnly) {
    var release = getFirst(path.join(dir, 'build/Release'), matchBuild)
    if (release) return release

    var debug = getFirst(path.join(dir, 'build/Debug'), matchBuild)
    if (debug) return debug
  }

  var prebuild = resolve(dir)
  if (prebuild) return prebuild

  var nearby = resolve(path.dirname(process.execPath))
  if (nearby) return nearby

  var target = [
    'platform=' + platform,
    'arch=' + arch,
    'runtime=' + runtime,
    'abi=' + abi,
    'uv=' + uv,
    armv ? 'armv=' + armv : '',
    'libc=' + libc,
    'node=' + process.versions.node,
    process.versions.electron ? 'electron=' + process.versions.electron : '',
     true ? 'webpack=true' : 0 // eslint-disable-line
  ].filter(Boolean).join(' ')

  throw new Error('No native build was found for ' + target + '\n    loaded from: ' + dir + '\n')

  function resolve (dir) {
    // Find matching "prebuilds/<platform>-<arch>" directory
    var tuples = readdirSync(path.join(dir, 'prebuilds')).map(parseTuple)
    var tuple = tuples.filter(matchTuple(platform, arch)).sort(compareTuples)[0]
    if (!tuple) return

    // Find most specific flavor first
    var prebuilds = path.join(dir, 'prebuilds', tuple.name)
    var parsed = readdirSync(prebuilds).map(parseTags)
    var candidates = parsed.filter(matchTags(runtime, abi))
    var winner = candidates.sort(compareTags(runtime))[0]
    if (winner) return path.join(prebuilds, winner.file)
  }
}

function readdirSync (dir) {
  try {
    return fs.readdirSync(dir)
  } catch (err) {
    return []
  }
}

function getFirst (dir, filter) {
  var files = readdirSync(dir).filter(filter)
  return files[0] && path.join(dir, files[0])
}

function matchBuild (name) {
  return /\.node$/.test(name)
}

function parseTuple (name) {
  // Example: darwin-x64+arm64
  var arr = name.split('-')
  if (arr.length !== 2) return

  var platform = arr[0]
  var architectures = arr[1].split('+')

  if (!platform) return
  if (!architectures.length) return
  if (!architectures.every(Boolean)) return

  return { name, platform, architectures }
}

function matchTuple (platform, arch) {
  return function (tuple) {
    if (tuple == null) return false
    if (tuple.platform !== platform) return false
    return tuple.architectures.includes(arch)
  }
}

function compareTuples (a, b) {
  // Prefer single-arch prebuilds over multi-arch
  return a.architectures.length - b.architectures.length
}

function parseTags (file) {
  var arr = file.split('.')
  var extension = arr.pop()
  var tags = { file: file, specificity: 0 }

  if (extension !== 'node') return

  for (var i = 0; i < arr.length; i++) {
    var tag = arr[i]

    if (tag === 'node' || tag === 'electron' || tag === 'node-webkit') {
      tags.runtime = tag
    } else if (tag === 'napi') {
      tags.napi = true
    } else if (tag.slice(0, 3) === 'abi') {
      tags.abi = tag.slice(3)
    } else if (tag.slice(0, 2) === 'uv') {
      tags.uv = tag.slice(2)
    } else if (tag.slice(0, 4) === 'armv') {
      tags.armv = tag.slice(4)
    } else if (tag === 'glibc' || tag === 'musl') {
      tags.libc = tag
    } else {
      continue
    }

    tags.specificity++
  }

  return tags
}

function matchTags (runtime, abi) {
  return function (tags) {
    if (tags == null) return false
    if (tags.runtime !== runtime && !runtimeAgnostic(tags)) return false
    if (tags.abi !== abi && !tags.napi) return false
    if (tags.uv && tags.uv !== uv) return false
    if (tags.armv && tags.armv !== armv) return false
    if (tags.libc && tags.libc !== libc) return false

    return true
  }
}

function runtimeAgnostic (tags) {
  return tags.runtime === 'node' && tags.napi
}

function compareTags (runtime) {
  // Precedence: non-agnostic runtime, abi over napi, then by specificity.
  return function (a, b) {
    if (a.runtime !== b.runtime) {
      return a.runtime === runtime ? -1 : 1
    } else if (a.abi !== b.abi) {
      return a.abi ? -1 : 1
    } else if (a.specificity !== b.specificity) {
      return a.specificity > b.specificity ? -1 : 1
    } else {
      return 0
    }
  }
}

function isNwjs () {
  return !!(process.versions && process.versions.nw)
}

function isElectron () {
  if (process.versions && process.versions.electron) return true
  if (process.env.ELECTRON_RUN_AS_NODE) return true
  return typeof window !== 'undefined' && window.process && window.process.type === 'renderer'
}

function isAlpine (platform) {
  return platform === 'linux' && fs.existsSync('/etc/alpine-release')
}

// Exposed for unit tests
// TODO: move to lib
load.parseTags = parseTags
load.matchTags = matchTags
load.compareTags = compareTags
load.parseTuple = parseTuple
load.matchTuple = matchTuple
load.compareTuples = compareTuples


/***/ }),

/***/ "./node_modules/serialport/dist/index.js":
/*!***********************************************!*\
  !*** ./node_modules/serialport/dist/index.js ***!
  \***********************************************/
/***/ (function(__unused_webpack_module, exports, __webpack_require__) {

"use strict";

var __createBinding = (this && this.__createBinding) || (Object.create ? (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    Object.defineProperty(o, k2, { enumerable: true, get: function() { return m[k]; } });
}) : (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    o[k2] = m[k];
}));
var __exportStar = (this && this.__exportStar) || function(m, exports) {
    for (var p in m) if (p !== "default" && !Object.prototype.hasOwnProperty.call(exports, p)) __createBinding(exports, m, p);
};
Object.defineProperty(exports, "__esModule", ({ value: true }));
__exportStar(__webpack_require__(/*! @serialport/parser-byte-length */ "./node_modules/@serialport/parser-byte-length/dist/index.js"), exports);
__exportStar(__webpack_require__(/*! @serialport/parser-cctalk */ "./node_modules/@serialport/parser-cctalk/dist/index.js"), exports);
__exportStar(__webpack_require__(/*! @serialport/parser-delimiter */ "./node_modules/@serialport/parser-delimiter/dist/index.js"), exports);
__exportStar(__webpack_require__(/*! @serialport/parser-inter-byte-timeout */ "./node_modules/@serialport/parser-inter-byte-timeout/dist/index.js"), exports);
__exportStar(__webpack_require__(/*! @serialport/parser-packet-length */ "./node_modules/@serialport/parser-packet-length/dist/index.js"), exports);
__exportStar(__webpack_require__(/*! @serialport/parser-readline */ "./node_modules/@serialport/parser-readline/dist/index.js"), exports);
__exportStar(__webpack_require__(/*! @serialport/parser-ready */ "./node_modules/@serialport/parser-ready/dist/index.js"), exports);
__exportStar(__webpack_require__(/*! @serialport/parser-regex */ "./node_modules/@serialport/parser-regex/dist/index.js"), exports);
__exportStar(__webpack_require__(/*! @serialport/parser-slip-encoder */ "./node_modules/@serialport/parser-slip-encoder/dist/index.js"), exports);
__exportStar(__webpack_require__(/*! @serialport/parser-spacepacket */ "./node_modules/@serialport/parser-spacepacket/dist/index.js"), exports);
__exportStar(__webpack_require__(/*! ./serialport-mock */ "./node_modules/serialport/dist/serialport-mock.js"), exports);
__exportStar(__webpack_require__(/*! ./serialport */ "./node_modules/serialport/dist/serialport.js"), exports);


/***/ }),

/***/ "./node_modules/serialport/dist/serialport-mock.js":
/*!*********************************************************!*\
  !*** ./node_modules/serialport/dist/serialport-mock.js ***!
  \*********************************************************/
/***/ ((__unused_webpack_module, exports, __webpack_require__) => {

"use strict";

Object.defineProperty(exports, "__esModule", ({ value: true }));
exports.SerialPortMock = void 0;
const stream_1 = __webpack_require__(/*! @serialport/stream */ "./node_modules/@serialport/stream/dist/index.js");
const binding_mock_1 = __webpack_require__(/*! @serialport/binding-mock */ "./node_modules/@serialport/binding-mock/dist/index.js");
class SerialPortMock extends stream_1.SerialPortStream {
    constructor(options, openCallback) {
        const opts = {
            binding: binding_mock_1.MockBinding,
            ...options,
        };
        super(opts, openCallback);
    }
}
exports.SerialPortMock = SerialPortMock;
SerialPortMock.list = binding_mock_1.MockBinding.list;
SerialPortMock.binding = binding_mock_1.MockBinding;


/***/ }),

/***/ "./node_modules/serialport/dist/serialport.js":
/*!****************************************************!*\
  !*** ./node_modules/serialport/dist/serialport.js ***!
  \****************************************************/
/***/ ((__unused_webpack_module, exports, __webpack_require__) => {

"use strict";

Object.defineProperty(exports, "__esModule", ({ value: true }));
exports.SerialPort = void 0;
const stream_1 = __webpack_require__(/*! @serialport/stream */ "./node_modules/@serialport/stream/dist/index.js");
const bindings_cpp_1 = __webpack_require__(/*! @serialport/bindings-cpp */ "./node_modules/@serialport/bindings-cpp/dist/index.js");
const DetectedBinding = (0, bindings_cpp_1.autoDetect)();
class SerialPort extends stream_1.SerialPortStream {
    constructor(options, openCallback) {
        const opts = {
            binding: DetectedBinding,
            ...options,
        };
        super(opts, openCallback);
    }
}
exports.SerialPort = SerialPort;
SerialPort.list = DetectedBinding.list;
SerialPort.binding = DetectedBinding;


/***/ }),

/***/ "./node_modules/supports-color/index.js":
/*!**********************************************!*\
  !*** ./node_modules/supports-color/index.js ***!
  \**********************************************/
/***/ ((module, __unused_webpack_exports, __webpack_require__) => {

"use strict";

const os = __webpack_require__(/*! os */ "os");
const tty = __webpack_require__(/*! tty */ "tty");
const hasFlag = __webpack_require__(/*! has-flag */ "./node_modules/has-flag/index.js");

const {env} = process;

let forceColor;
if (hasFlag('no-color') ||
	hasFlag('no-colors') ||
	hasFlag('color=false') ||
	hasFlag('color=never')) {
	forceColor = 0;
} else if (hasFlag('color') ||
	hasFlag('colors') ||
	hasFlag('color=true') ||
	hasFlag('color=always')) {
	forceColor = 1;
}

if ('FORCE_COLOR' in env) {
	if (env.FORCE_COLOR === 'true') {
		forceColor = 1;
	} else if (env.FORCE_COLOR === 'false') {
		forceColor = 0;
	} else {
		forceColor = env.FORCE_COLOR.length === 0 ? 1 : Math.min(parseInt(env.FORCE_COLOR, 10), 3);
	}
}

function translateLevel(level) {
	if (level === 0) {
		return false;
	}

	return {
		level,
		hasBasic: true,
		has256: level >= 2,
		has16m: level >= 3
	};
}

function supportsColor(haveStream, streamIsTTY) {
	if (forceColor === 0) {
		return 0;
	}

	if (hasFlag('color=16m') ||
		hasFlag('color=full') ||
		hasFlag('color=truecolor')) {
		return 3;
	}

	if (hasFlag('color=256')) {
		return 2;
	}

	if (haveStream && !streamIsTTY && forceColor === undefined) {
		return 0;
	}

	const min = forceColor || 0;

	if (env.TERM === 'dumb') {
		return min;
	}

	if (process.platform === 'win32') {
		// Windows 10 build 10586 is the first Windows release that supports 256 colors.
		// Windows 10 build 14931 is the first release that supports 16m/TrueColor.
		const osRelease = os.release().split('.');
		if (
			Number(osRelease[0]) >= 10 &&
			Number(osRelease[2]) >= 10586
		) {
			return Number(osRelease[2]) >= 14931 ? 3 : 2;
		}

		return 1;
	}

	if ('CI' in env) {
		if (['TRAVIS', 'CIRCLECI', 'APPVEYOR', 'GITLAB_CI', 'GITHUB_ACTIONS', 'BUILDKITE'].some(sign => sign in env) || env.CI_NAME === 'codeship') {
			return 1;
		}

		return min;
	}

	if ('TEAMCITY_VERSION' in env) {
		return /^(9\.(0*[1-9]\d*)\.|\d{2,}\.)/.test(env.TEAMCITY_VERSION) ? 1 : 0;
	}

	if (env.COLORTERM === 'truecolor') {
		return 3;
	}

	if ('TERM_PROGRAM' in env) {
		const version = parseInt((env.TERM_PROGRAM_VERSION || '').split('.')[0], 10);

		switch (env.TERM_PROGRAM) {
			case 'iTerm.app':
				return version >= 3 ? 3 : 2;
			case 'Apple_Terminal':
				return 2;
			// No default
		}
	}

	if (/-256(color)?$/i.test(env.TERM)) {
		return 2;
	}

	if (/^screen|^xterm|^vt100|^vt220|^rxvt|color|ansi|cygwin|linux/i.test(env.TERM)) {
		return 1;
	}

	if ('COLORTERM' in env) {
		return 1;
	}

	return min;
}

function getSupportLevel(stream) {
	const level = supportsColor(stream, stream && stream.isTTY);
	return translateLevel(level);
}

module.exports = {
	supportsColor: getSupportLevel,
	stdout: translateLevel(supportsColor(true, tty.isatty(1))),
	stderr: translateLevel(supportsColor(true, tty.isatty(2)))
};


/***/ }),

/***/ "./src/config.js":
/*!***********************!*\
  !*** ./src/config.js ***!
  \***********************/
/***/ ((module) => {

module.exports = {
  serial: {
    MAX_RX_BYTE_INTERVAL: 100, /* unit: ms */
    MANAGEMENT_PACKET_HEADER: "D1mvOP3M67IGpSrABAWwhv57pe2vT",
    
    GUI_AUTHENTICATION_HASH_KEY: "DYAfwJkdXa1PTYlgc0IpuZTRApNfxwnhatPC6F5HeO9CHoQ9oeB3VWng15qgtZndNpFuL8oq8JemSKdtwq50LzPBnGWeHur3m9jeCEKjz1vrvlKjUnUnRw1IDJpfkWQZv2bS7ougTzn6rNOebs51SewOhrMZBCYUzpEFMCij7fvzDdwSo5ymds5Wqi8bwsVMolrja4FQ0vUlAO20tct2wfoYIsCWmD4I3ymXdaFZluoBkeh4OazCr70tnk",
    AUTHENTICATION_ANIMATION_DELAY: 300,
    AUTHENTICATION_NOT_NEEDDED: false,
    AUTO_INSERT_GUI_PASSWORD_ACTIVE: false,
    AUTO_INSERT_GUI_PASSWORD_VALUE: "1111",
    
    MANAGEMENT_COMMAND: {
      HELLO: 0x00,
      ACK: 0x01,
      NACK: 0x02,
      REQUEST_STATUS: 0x03,

      SET_BUZZER_VOLUME: 0x10,
      TEST_LED: 0x11,
      SET_DEVICE_WORKING_MODE: 0x12,
      SET_DEVICE_ID: 0x13,
      SET_DEVICE_ID_LENGTH: 0x14,
      SET_RTC_TIME: 0x15,
      SET_REMOTE_DISCHARGE_MESSAGE: 0x16,
      SET_BLACK_LIST_BYPASS: 0x17,
      SET_MAIN_KEY_BANK_SEED: 0x18,
      SET_BACKUP_KEY_BANK_SEED: 0x19,
      SET_SELECTED_KEY_BANK: 0x1A,
      SET_CASE_OPEN_EVENT_ACTION: 0x1B,
      SET_REMOTE_DISCHARGE_ENABLE: 0x1C,
      DISCHARGE_KEY_BANKS: 0x1D,
      SET_ENCRYPTED_PORT_TX_BAUD_RATE: 0x1E,
      SET_ENCRYPTED_PORT_RX_BAUD_RATE: 0x1F,
      SET_DECRYPTED_PORT_TX_BAUD_RATE: 0x20,
      SET_DECRYPTED_PORT_RX_BAUD_RATE: 0x21,
      SET_RTC_PACKET_SECTION_ENABLED: 0x22,
      SET_MAXIMUM_VALID_RTC_TIME_DIFFERENCE: 0x23,
      SET_DECRYPTED_PORT_RX_TIMEOUT_MS: 0x24,
      SET_ENCRYPTED_PORT_RX_TIMEOUT_MS: 0x25,
      SET_ENCRYPTED_PACKET_MAX_DATA_LENGTH: 0x26,
      START_KSS_STREAM_GENERATION: 0x27,
      STOP_KSS_STREAM_GENERATION: 0x28,
      ADD_TO_BLACK_LIST_IN_RAM: 0x29,
      READ_FROM_BLACK_LIST: 0x2A,
      ERASE_BLACK_LIST_FROM_FLASH: 0x2B,
      ERASE_BLACK_LIST_FROM_RAM: 0x2C,
      WRITE_BLACK_LIST_TO_FLASH: 0x2D,
      SET_ENCRYPTED_PORT_HEADER: 0x2E,
      SET_GUI_PASSWORD: 0x2F,
      AUTHENTICATION_RANDOM_DATA: 0x30,
      AUTHENTICATION_UNIQUE_ID_AND_HASH: 0x31,
      AUTHENTICATION_GUI_PASSWORD: 0x32,
    },
  },
}



/***/ }),

/***/ "./src/personalExcelApi.js":
/*!*********************************!*\
  !*** ./src/personalExcelApi.js ***!
  \*********************************/
/***/ ((module, __unused_webpack_exports, __webpack_require__) => {

"use strict";


const XLSX = __webpack_require__(Object(function webpackMissingModule() { var e = new Error("Cannot find module 'xlsx'"); e.code = 'MODULE_NOT_FOUND'; throw e; }()));
const { ipcRenderer } = __webpack_require__(/*! electron */ "electron");

function saveLogToExcell (fileName, biasValuesObj) {
  const newBook = XLSX.utils.book_new();
  XLSX.utils.book_append_sheet(
    newBook,
    XLSX.utils.json_to_sheet(biasValuesObj),
    "Test_Results"
  );
  XLSX.writeFile(newBook, fileName);
}

async function selectFolder () {
  return await ipcRenderer.invoke('dialog:openDirectory');
}

async function selectExcelToOpen () {
  return await ipcRenderer.invoke('dialog:selectExcelToOpen');
}

async function selectAndOpenExcellWorkbook () {
  let filePath = await selectExcelToOpen();
  if(!filePath) {
    return null;
  }

  let workbook = XLSX.readFile(filePath);

  return workbook;
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

module.exports = {
  saveLogToExcell,
  getExeFilePath,
  getExeFilePathLooped,
  getExeFilePathConst,
  selectFolder,
  selectExcelToOpen,
  selectExcelToSave,
  selectAndOpenExcellWorkbook,
  saveWorkbook,
}



/***/ }),

/***/ "./src/personalHash.js":
/*!*****************************!*\
  !*** ./src/personalHash.js ***!
  \*****************************/
/***/ ((module, __unused_webpack_exports, __webpack_require__) => {

"use strict";


const crypto = __webpack_require__(/*! crypto */ "crypto");
const toolBox = __webpack_require__(/*! ./toolBox */ "./src/toolBox.js")

function createHash(input, returnHexString=false) {
  if (!Buffer.isBuffer(input)) {
    input = Buffer.from(input); // Convert input to Buffer if it isn't one
  }

  let hash = crypto.createHash('sha256').update(input).digest('hex');

  if(returnHexString) {
    return hash;
  } else {
    return toolBox.fromHexString(hash);
  }
}

module.exports = {
  createHash,
}



/***/ }),

/***/ "./src/personalSerialPort.js":
/*!***********************************!*\
  !*** ./src/personalSerialPort.js ***!
  \***********************************/
/***/ ((module, __unused_webpack_exports, __webpack_require__) => {

"use strict";


const toolBox = __webpack_require__(/*! ./toolBox */ "./src/toolBox.js")
const { SerialPort } = __webpack_require__(/*! serialport */ "./node_modules/serialport/dist/index.js");
const { ByteLengthParser } = __webpack_require__(/*! @serialport/parser-byte-length */ "./node_modules/@serialport/parser-byte-length/dist/index.js");

let serialport = null;
let rxCallBackFunction = () => 0;
let parser = null;

function initPort (port, baudRate=9600) {
  if(serialport && serialport.isOpen) {
    serialport.close();
  }
  serialport = new SerialPort({ autoOpen: false, path: port, baudRate: baudRate });

  parser = serialport.pipe(new ByteLengthParser({length: 1}));
  parser.on('data', (data) => {
    rxCallBackFunction(data["0"]);
  });
}

async function setBaudRate (baudRate) {
  if(serialport && serialport.isOpen) {
    await serialport.close();
    await new Promise(resolve => setTimeout(resolve, 50));

    initPort(
      serialport.settings.path,
      baudRate,
      rxCallBackFunction,
    );

    await serialport.open();
  } else {
    throw new Error('Serial port is not open !!!');
  }
}

function isOpen () {
  return serialport.isOpen;
}

async function open () {
  if(serialport) {
    await serialport.open();
  }
}

async function close () {
  if(serialport && serialport.isOpen) {
    await serialport.close();
  }
}

function write (dataArray) {
  serialport.write(dataArray);
}

function setRxCallbackFunction(callBackFunction) {
  rxCallBackFunction = callBackFunction;
}

async function list() {
  return await SerialPort.list()
}

// below function is used for debugging purposes 👇👇👇 only
function runRxCallbackFunction (rxByte) {
  rxCallBackFunction(rxByte);
}

module.exports = {
  initPort,
  setBaudRate,
  isOpen,
  open,
  close,
  write,
  setRxCallbackFunction,
  list,

  // below function is used for debugging purposes 👇👇👇 only
  runRxCallbackFunction,
}



/***/ }),

/***/ "./src/personalWebFrame.js":
/*!*********************************!*\
  !*** ./src/personalWebFrame.js ***!
  \*********************************/
/***/ ((module, __unused_webpack_exports, __webpack_require__) => {

"use strict";


const toolBox = __webpack_require__(/*! ./toolBox */ "./src/toolBox.js")
const { webFrame } = __webpack_require__(/*! electron */ "electron");

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



/***/ }),

/***/ "./src/popUpMessage.js":
/*!*****************************!*\
  !*** ./src/popUpMessage.js ***!
  \*****************************/
/***/ ((module) => {

"use strict";


const DEFAULT_ANIMATION_TIME = '3s';
const DEFAULT_LANGUAGE_IS_FARSI = true;

function displayPopUp(
  text,
  color,
  isFarsi=DEFAULT_LANGUAGE_IS_FARSI,
  animationTime=DEFAULT_ANIMATION_TIME
) {
  const template = document.querySelector('#pop-up-card-template');
  const clone = template.content.cloneNode(true).querySelector('.pop-up-card');

  clone.style.setProperty('--background-color', color);
  clone.querySelector('.card-label').textContent = text;
  clone.style.setProperty('--animation-time', animationTime);

  if(isFarsi) {
    clone.classList.add('farsi');
  }
  
  const popUpCardsContainer = document.querySelector('.pop-up-cards-container');
  popUpCardsContainer.prepend(clone);
  clone.addEventListener('animationend', () => popUpCardsContainer.removeChild(clone));
}

module.exports = {
  displayPopUp,
}

/***/ }),

/***/ "./src/serialInterface.js":
/*!********************************!*\
  !*** ./src/serialInterface.js ***!
  \********************************/
/***/ ((module, __unused_webpack_exports, __webpack_require__) => {

"use strict";


const config = __webpack_require__(/*! ./config */ "./src/config.js")
const toolBox = __webpack_require__(/*! ./toolBox */ "./src/toolBox.js")
const serialRx = __webpack_require__(/*! ./serialRx */ "./src/serialRx.js")
const serialTx = __webpack_require__(/*! ./serialTx */ "./src/serialTx.js")
const popUpMessage = __webpack_require__(/*! ./popUpMessage */ "./src/popUpMessage.js");
const personalExcelApi = __webpack_require__(/*! ./personalExcelApi */ "./src/personalExcelApi.js");
const personalHash = __webpack_require__(/*! ./personalHash */ "./src/personalHash.js");
const XLSX = __webpack_require__(Object(function webpackMissingModule() { var e = new Error("Cannot find module 'xlsx'"); e.code = 'MODULE_NOT_FOUND'; throw e; }()));

const COMMANDS = config.serial.MANAGEMENT_COMMAND;

const AUTHENTICATION_MAX_RANDOM_DATA_LENGTH = 64;
const AUTHENTICATION_MIN_RANDOM_DATA_LENGTH = 32;
const AUTHENTICATION_MAX_UNIQUE_ID_LENGTH = 64;
const AUTHENTICATION_MIN_UNIQUE_ID_LENGTH = 1;

const DEFAULT_MAX_RESPONSE_TIME = 2000;
const KEY_BANK_GENERATION_MAX_RESPONSE_TIME = 4000;

const PACKET_ERROR_CODES = {
  CONCIFG_PORT_PACKET_ERROR_NONE:                    0,
  CONCIFG_PORT_PACKET_ERROR_COMMAND:                 1,
  CONCIFG_PORT_PACKET_ERROR_DATA_SIZE:               2,
  CONCIFG_PORT_PACKET_ERROR_DATA_CONTENT:            3,
  CONCIFG_PORT_PACKET_ERROR_CHECKSUM:                4,
  CONCIFG_PORT_PACKET_ERROR_AUTHENTICATION_FAILED:   5,
  CONCIFG_PORT_PACKET_ERROR_SESSION_PACKET:          6,
  CONCIFG_PORT_PACKET_ERROR_SESSION_NOT_ACTIVE:      7,
};

let authenticator = {
  deviceNotRespondingCounter: 0,
  sessionPacketFailCounter: 0,
  sessionActive: false,
  sessionKey: [],
}

let txController = {
  state: 'idle',
  stateStep: 0,
}

let appParams = {
  status: {},
  statusBulk: {},
  setting: {},
  settingBulk: {
    deviceIdBlackList: [],
  },
};

let uiToSerialPendingRequest = {
  valid: false,
  packet: [],
  expectedResponse: null,
  successMessage: '',
  failureMessage: '',
  maxResponseTime: null,
  isSpecialCommand: false,
  requestName: false,
  requestData: null,
};

let runInterval = 100;
let serialToUiEventCallback = null;
let rxPacket = {
  valid: false,
  command: 0x00,
  data: [],
};

function createUiToSerialPendingPacket (packet) {
  uiToSerialPendingRequest.valid = true;
  uiToSerialPendingRequest.packet = packet;
}

let comPortStillConnectedFunction = async () => {
  return false;
}

function registerComPortStillConnectedFunction (func) {
  comPortStillConnectedFunction = func;
}

function txControllerStateStepForward (numOfSteps=1) {
  txController.stateStep += numOfSteps;
}

function txControllerGoToState (newState) {
  txController.state = newState;
  txController.stateStep = 0;
}

function txControllerHandleStateMachineFail (message) {
  console.error(txController);
  throw new Error(message);
}

async function txControlRun () {
  let instantReRunRequestFlag = 0;
  const instantReRun = () => { instantReRunRequestFlag = 1; };

  switch(txController.state) {
    case 'idle': {
      if(!authenticator.sessionActive) {
        txControllerGoToState('authentication');
        serialToUiEventCallback({
          name: 'authenticatorStart',
          data: ''
        });
      } else if(uiToSerialPendingRequest.valid) {
        if(await comPortStillConnectedFunction()) {
          serialTx.sendPacketArray(uiToSerialPendingRequest.packet);

          if(uiToSerialPendingRequest.isSpecialCommand) {
            uiToSerialPendingRequest.valid = false;
            txControllerGoToState(uiToSerialPendingRequest.requestName);
            instantReRun();
            break;
          }

          switch(uiToSerialPendingRequest.expectedResponse) {
            case 'simpleAck': {
              await pollForRxPacketReady(uiToSerialPendingRequest.maxResponseTime);
              
              if(rxPacket.valid) {
                switch(rxPacket.command) {
                  case COMMANDS.ACK: {
                    popUpMessage.displayPopUp(
                      uiToSerialPendingRequest.successMessage,
                      'GREEN',
                    );
                  }
                  break;

                  case COMMANDS.NACK: {
                    let nackMessageString = rxPacket.data.slice(2);

                    if(nackMessageString.length) {
                      nackMessageString = toolBox.asciiArrayUtf8Decode(nackMessageString);
                    } else {
                      nackMessageString = null;
                    }

                    popUpMessage.displayPopUp(
                      uiToSerialPendingRequest.failureMessage,
                      'RED',
                    );

                    if(nackMessageString) {
                      popUpMessage.displayPopUp(
                        nackMessageString,
                        'RED',
                      );
                    }

                    // popUpMessage.displayPopUp(
                    //   uiToSerialPendingRequest.failureMessage + ` ${rxPacket.data[1]} `,
                    //   'RED',
                    // );
                  }
                  break;

                  default: {
                    popUpMessage.displayPopUp(
                      `انتظار می رفت ACK دریافت شود ولی کد ${rxPacket.command} دریاف شد`,
                      'RED',
                    );
                  }
                  break;
                }
              } else {
                popUpMessage.displayPopUp(
                  'پاسخی دریافت نشد',
                  'RED'
                );
              }
            }
            break;
            
            case 'none':
            default: {
              /* Do nothing */
            }
            break;
          }
        } else {
          popUpMessage.displayPopUp(
            'پورت سریال متصل نیست',
            'ORANGE'
          );
          console.warn('COM Port not connected');
        }

        uiToSerialPendingRequest.valid = false;
      } else {
        // if(! await comPortStillConnectedFunction()) { break; }

        txControllerGoToState('requestStatus');
        instantReRun();
      }
    }
    break;

    case 'authentication': {
      switch(txController.stateStep) {
        case 0: { /* Check for COM Connection */
          if(await comPortStillConnectedFunction()) {
            serialToUiEventCallback({
              name: 'authenticatorComPortConnectionTest',
              data: 'success'
            });
            txControllerStateStepForward();
            console.log(`Authenticator: COM Port Connected`);
            await toolBox.asyncDelay(config.serial.AUTHENTICATION_ANIMATION_DELAY);
          } else {
            serialToUiEventCallback({
              name: 'authenticatorComPortConnectionTest',
              data: 'start'
            });
          }
        }
        break;

        case 1: { /* HELLO Packet */
          let failed = false;
          
          serialToUiEventCallback({
            name: 'authenticatorHello',
            data: 'start'
          });
          await toolBox.asyncDelay(config.serial.AUTHENTICATION_ANIMATION_DELAY);

          serialTx.createAndSendPacket(
            COMMANDS.HELLO,
          );

          await pollForRxPacketReady(300);

          if(rxPacket.valid) {
            // console.log(rxPacket);

            if(rxPacket.command === COMMANDS.HELLO) {
              console.log(
                `Authenticator: Received HELLO Response`,
              );
              
              serialToUiEventCallback({
                name: 'authenticatorHello',
                data: 'success'
              });
              txControllerStateStepForward();
              await toolBox.asyncDelay(config.serial.AUTHENTICATION_ANIMATION_DELAY);
            } else {
              failed = true;
            }
          } else {
            console.log(`Authenticator: didn't receive "HELLO"`);
            failed = true;
          }

          if(failed) {
            serialToUiEventCallback({
              name: 'authenticatorHello',
              data: 'fail'
            });
            txController.stateStep = 0;
            await toolBox.asyncDelay(config.serial.AUTHENTICATION_ANIMATION_DELAY);
          }
        }
        break;

        case 2: { /* Radnom Data */
          if(config.serial.AUTHENTICATION_NOT_NEEDDED) {
            authenticator.sessionActive = true;
            authenticator.sessionKey = [];
            
            for(let i = 0; i < authenticator.pcRandomDataLength; i++) {
              authenticator.sessionKey.push(toolBox.randomRange(0, 255));
            }
            
            serialToUiEventCallback({
              name: 'authenticatorStop',
              data: ''
            });
  
            txControllerGoToState('idle');
            break;
          }
          
          let failed = false;
          
          serialToUiEventCallback({
            name: 'authenticatorStage1',
            data: 'start'
          });
          await toolBox.asyncDelay(config.serial.AUTHENTICATION_ANIMATION_DELAY);

          authenticator.pcRandomData = [];
          authenticator.pcRandomDataLength = toolBox.randomRange(
            AUTHENTICATION_MIN_RANDOM_DATA_LENGTH,
            AUTHENTICATION_MAX_RANDOM_DATA_LENGTH
          );
          for(let i = 0; i < authenticator.pcRandomDataLength; i++) {
            authenticator.pcRandomData.push(toolBox.randomRange(0, 255));
          }

          console.log(
            `Authenticator: pcRandomData[${authenticator.pcRandomData.length}]:`,
            `[${toolBox.toHexString(authenticator.pcRandomData, ' ')}]`
          );

          serialTx.createAndSendPacket(
            COMMANDS.AUTHENTICATION_RANDOM_DATA,
            authenticator.pcRandomData
          );

          await pollForRxPacketReady(300);

          if(rxPacket.valid) {
            // console.log(rxPacket);
  
            if(rxPacket.command === COMMANDS.AUTHENTICATION_RANDOM_DATA) {
              authenticator.deviceRandomData = toolBox.deepClone(rxPacket.data);
              console.log(
                `Authenticator: deviceRandomData[${authenticator.deviceRandomData.length}]:`,
                `[${toolBox.toHexString(authenticator.deviceRandomData, ' ')}]`
              );
              
              serialToUiEventCallback({
                name: 'authenticatorStage1',
                data: 'success'
              });
              txControllerStateStepForward();
              await toolBox.asyncDelay(config.serial.AUTHENTICATION_ANIMATION_DELAY);
            } else {
              failed = true;
            }
          } else {
            console.log(`Authenticator: didn't receive "Device Random Data"`);
            failed = true;
          
            serialToUiEventCallback({
              name: 'authenticatorStage1',
              data: 'fail'
            });
            await toolBox.asyncDelay(config.serial.AUTHENTICATION_ANIMATION_DELAY);
          }

          if(failed) {
            txController.stateStep = 0;
          }
        }
        break;

        case 3: { /* Unique ID */
          let failed = false;
          
          serialToUiEventCallback({
            name: 'authenticatorStage2',
            data: 'start'
          });
          await toolBox.asyncDelay(config.serial.AUTHENTICATION_ANIMATION_DELAY);

          authenticator.pcUniqueId = [];
          authenticator.pcUniqueIdLength = toolBox.randomRange(
            AUTHENTICATION_MIN_UNIQUE_ID_LENGTH,
            AUTHENTICATION_MAX_UNIQUE_ID_LENGTH
          );
          for(let i = 0; i < authenticator.pcUniqueIdLength; i++) {
            authenticator.pcUniqueId.push(toolBox.randomRange(0, 255));
          }

          authenticator.pcHash = personalHash.createHash([
            ...toolBox.stringToAsciiArray(config.serial.GUI_AUTHENTICATION_HASH_KEY),
            ...authenticator.pcRandomData,
            ...authenticator.deviceRandomData,
            ...authenticator.pcUniqueId,
          ]);

          console.log(
            `Authenticator: pcUniqueId[${authenticator.pcUniqueId.length}]:`,
            `[${toolBox.toHexString(authenticator.pcUniqueId, ' ')}]`
          );

          serialTx.createAndSendPacket(
            COMMANDS.AUTHENTICATION_UNIQUE_ID_AND_HASH,
            [
              ...authenticator.pcHash,
              ...authenticator.pcUniqueId,
            ]
          );

          await pollForRxPacketReady(300);

          if(rxPacket.valid) {
            // console.log(rxPacket);

            if(rxPacket.command === COMMANDS.AUTHENTICATION_UNIQUE_ID_AND_HASH) {
              let packetDataClone = toolBox.deepClone(rxPacket.data);

              authenticator.deviceHash = packetDataClone.splice(0, 32);
              authenticator.deviceUniqueId = packetDataClone;
              
              console.log(
                `Authenticator: deviceHash[${authenticator.deviceHash.length}]:`,
                `[${toolBox.toHexString(authenticator.deviceHash, ' ')}]`
              );

              console.log(
                `Authenticator: deviceUniqueId[${authenticator.deviceUniqueId.length}]:`,
                `[${toolBox.toHexString(authenticator.deviceUniqueId, ' ')}]`
              );

              if(authenticator.deviceUniqueId.length < AUTHENTICATION_MIN_UNIQUE_ID_LENGTH) {
                console.warn(`Authenticator: deviceUniqueId.length is too short"`);
                failed = true;
              } else {
                authenticator.deviceExpectedHash = personalHash.createHash([
                  ...toolBox.stringToAsciiArray(config.serial.GUI_AUTHENTICATION_HASH_KEY),
                  ...authenticator.pcRandomData,
                  ...authenticator.deviceRandomData,
                  ...authenticator.deviceUniqueId,
                ]);

                if(toolBox.deepCompareArrays(authenticator.deviceHash, authenticator.deviceExpectedHash)) {
                  serialToUiEventCallback({
                    name: 'authenticatorStage2',
                    data: 'success'
                  });
                  txControllerStateStepForward();
                  await toolBox.asyncDelay(config.serial.AUTHENTICATION_ANIMATION_DELAY);
                } else {
                  console.warn(`deviceHash and deviceExpectedHash dont match`);
                  console.log(toolBox.deepClone(authenticator));
                  failed = true;
                }
              }
            } else {
              if(true) {
                let packetClone = toolBox.deepClone(rxPacket);
                packetClone.data[0] = toolBox.getFieldNameByValue(
                  COMMANDS,
                  packetClone.data[0],
                );
                packetClone.data[1] = toolBox.getFieldNameByValue(
                  PACKET_ERROR_CODES,
                  packetClone.data[1],
                );
                console.warn(packetClone);
                console.warn(packetClone.data);
              }
              failed = true;
            }
          } else {
            console.warn(`Authenticator: didn't receive "Device Hash Data"`);
            failed = true;
          }

          if(failed) {
            txController.stateStep = 0;

            serialToUiEventCallback({
              name: 'authenticatorStage2',
              data: 'fail'
            });
            await toolBox.asyncDelay(config.serial.AUTHENTICATION_ANIMATION_DELAY);
          }
        }
        break;

        case 4: { /* Take GUI Password From User */
          authenticator.guiPass = null;
          
          serialToUiEventCallback({
            name: 'authenticatorPassword',
            data: 'start'
          });
          await toolBox.asyncDelay(config.serial.AUTHENTICATION_ANIMATION_DELAY);

          txControllerStateStepForward();
        }
        break;

        case 5: {
          /* For Testing Begin ↓ *********************************/
            if(config.serial.AUTO_INSERT_GUI_PASSWORD_ACTIVE) {
              authenticator.guiPass = config.serial.AUTO_INSERT_GUI_PASSWORD_VALUE;
            }
          /* For Testing End   ↑ *********************************/

          if(authenticator.guiPass !== null) {
            console.log(`guiPass = ${authenticator.guiPass}`);

            authenticator.guiPass = toolBox.stringToAsciiArray(authenticator.guiPass);
  
            txControllerStateStepForward();
          }
        }
        break;

        case 6: { /* Send GUI Pass to Device */
          let failed = false;

          serialTx.createAndSendPacket(
            COMMANDS.AUTHENTICATION_GUI_PASSWORD,
            authenticator.guiPass
          );

          await pollForRxPacketReady(300);

          if(rxPacket.valid) {
            // console.log(rxPacket);

            if(rxPacket.command === COMMANDS.ACK) {
              console.log(
                `Authenticator: GUI Password Accepted by device`
              );
              
              authenticator.sessionKey = personalHash.createHash([
                ...toolBox.stringToAsciiArray(config.serial.GUI_AUTHENTICATION_HASH_KEY),
                ...authenticator.pcRandomData,
                ...authenticator.deviceRandomData,
                ...authenticator.pcUniqueId,
                ...authenticator.deviceUniqueId,
                ...authenticator.guiPass,
              ]);
              
              console.log(
                '%cAuthentication Successful',
                'color:black; background:lightgreen; font-size:2rem; padding: .5rem;',
              );
              
              console.log(
                `%cSessionKey: ${toolBox.toHexString(authenticator.sessionKey, ' ')}`,
                'color:black; background:lightgreen; font-size:2rem; padding: .5rem;',
              );

              authenticator.sessionActive = true;
              authenticator.sessionPacketFailCounter = 0;
              txControllerStateStepForward();
              serialToUiEventCallback({
                name: 'authenticatorPassword',
                data: 'success'
              });
              await toolBox.asyncDelay(config.serial.AUTHENTICATION_ANIMATION_DELAY);
            } else {
              console.warn(rxPacket);
              console.warn(rxPacket.data);
              failed = true;
            }
          } else {
            console.warn(`Authenticator: didn't receive "Device Hash Data"`);
            failed = true;
          }

          if(failed) {
            txController.stateStep = 0;
          
            serialToUiEventCallback({
              name: 'authenticatorPassword',
              data: 'fail'
            });
            await toolBox.asyncDelay(config.serial.AUTHENTICATION_ANIMATION_DELAY);
          }
        }
        break;

        default: {
          serialToUiEventCallback({
            name: 'authenticatorStop',
            data: ''
          });

          txControllerGoToState('idle');
        }
        break;
      }
    }
    break;
    
    case 'readBlackList': {
      let failed = false;
      let deviceIdBlackListBytes = [];

      async function sendAndPollForListData (
        commandName,
        data,
        maxTries,
        responseTime=DEFAULT_MAX_RESPONSE_TIME
      ) {
        while(1) {
          maxTries--;
          if(maxTries < 0) {
            break;
          }

          serialTx.createAndSendPacket(
            COMMANDS[commandName],
            data,
            authenticator.sessionKey
          );
          
          await pollForRxPacketReady(responseTime);

          if(rxPacket.valid) {
            if(rxPacket.command === COMMANDS.READ_FROM_BLACK_LIST) {
              break;
            } else if(rxPacket.command === COMMANDS.NACK) {
              console.warn(`Expected ${COMMANDS.ACK} after ${commandName} packet, but received NACK with data: ${toolBox.toHexString(rxPacket.data, ' ')}`);
            } else {
              console.warn(`Expected ${COMMANDS.ACK} after ${commandName} packet, but received ${rxPacket.command}`);
            }
          } else {
            console.warn(`Didn't receive response to ${commandName} packet`);
          }
        }

        if(maxTries < 0) {
          return 'fail'
        } else {
          return 'success'
        }
      }
      
      let deviceIdBlackListLength = appParams.setting.deviceIdBlackListLength;
      let blackListIndex = 0;

      if(deviceIdBlackListLength === 0) {
        popUpMessage.displayPopUp(
          'لیست سیاه رمزکننده خالی است',
          'RED',
        );

        txControllerGoToState('idle');
        instantReRun();
        break;
      }

      // appParams.settingBulk.deviceIdBlackList
      while(deviceIdBlackListLength) {
        let readSize = 100;
        if(deviceIdBlackListLength < readSize) {
          readSize = deviceIdBlackListLength;
        }

        let xferResult = await sendAndPollForListData(
          'READ_FROM_BLACK_LIST',
          [
            ...toolBox.intToArray(blackListIndex, 4, false),
            ...toolBox.intToArray(readSize, 4, false),
          ],
          3
        );

        if(xferResult === 'fail') {
          failed = true;
          break;
        } else {
          deviceIdBlackListBytes.push(...rxPacket.data);
          
          deviceIdBlackListLength -= readSize;
          blackListIndex += readSize;
        }
      }

      if(!failed) {
        appParams.settingBulk.deviceIdBlackList = []

        console.log(deviceIdBlackListBytes);

        while(deviceIdBlackListBytes.length) {
          appParams.settingBulk.deviceIdBlackList.push(
            toolBox.arrayToInt(deviceIdBlackListBytes.splice(0, 2))
          );
        }

        console.log(appParams.settingBulk.deviceIdBlackList);

        appParams.settingBulk.deviceIdBlackList =
          appParams.settingBulk.deviceIdBlackList.map((num) => {
            return toolBox.toHexString(toolBox.intToArray(num, 2, false, false));
          });

        console.log(appParams.settingBulk.deviceIdBlackList);

        exportBlackListExcell(appParams.settingBulk.deviceIdBlackList);
      } else {
        popUpMessage.displayPopUp(
          'قرائت لیست سیاه انجام نشد',
          'RED',
        );
      }

      txControllerGoToState('idle');
    }
    break;

    case 'writeBlackList': {
      let list = toolBox.deepCopy(uiToSerialPendingRequest.requestData);
      let failed = false;

      function extractFromList (numOfIds) {
        return list.splice(0, numOfIds);
      }

      async function sendAndPollForAck (
        commandName,
        data,
        maxTries,
        responseTime=DEFAULT_MAX_RESPONSE_TIME
      ) {
        while(1) {
          maxTries--;
          if(maxTries < 0) {
            break;
          }

          serialTx.createAndSendPacket(
            COMMANDS[commandName],
            data,
            authenticator.sessionKey
          );
          
          await pollForRxPacketReady(responseTime);

          if(rxPacket.valid) {
            if(rxPacket.command === COMMANDS.ACK) {
              break;
            } else if(rxPacket.command === COMMANDS.NACK) {
              console.warn(`Expected ${COMMANDS.ACK} after ${commandName} packet, but received NACK with data: ${toolBox.toHexString(rxPacket.data, ' ')}`);
            } else {
              console.warn(`Expected ${COMMANDS.ACK} after ${commandName} packet, but received ${rxPacket.command}`);
            }
          } else {
            console.warn(`Didn't receive ack response to ${commandName} packet`);
          }
        }

        if(maxTries < 0) {
          return 'fail'
        } else {
          return 'success'
        }
      }

      let xferResult = await sendAndPollForAck(
        'ERASE_BLACK_LIST_FROM_RAM',
        [],
        3,
        1000
      );

      if(xferResult === 'fail') {
        failed = true;
      }

      if(!failed) {
        while(list.length !== 0) {
          let subList = extractFromList(100);
          let subListBytes = [];

          for(let i = 0; i < subList.length; i++) {
            let deviceIdBytes = toolBox.intToArray(subList[i], 2, false, true);
            subListBytes.push(...deviceIdBytes);
          }

          // console.log('subList');
          // console.log(subList);

          // console.log('subListBytes');
          // console.log(subListBytes);

          let xferResult = await sendAndPollForAck(
            'ADD_TO_BLACK_LIST_IN_RAM',
            subListBytes,
            3
          );

          if(xferResult === 'fail') {
            failed = true;
            break;
          }
        }
      }

      if(!failed) {
        let xferResult = await sendAndPollForAck(
          'WRITE_BLACK_LIST_TO_FLASH',
          [],
          3,
          1000
        );

        if(xferResult === 'fail') {
          failed = true;
        }
      }

      if(failed) {
        popUpMessage.displayPopUp(
          'تزریق لیست سیاه انجام نشد',
          'RED',
        );
      } else {
        popUpMessage.displayPopUp(
          'لیست سیاه تزریق شد',
          'GREEN',
        );
      }

      txControllerGoToState('idle');
    }
    break;

    case 'requestStatus': {
      serialTx.createAndSendPacket(
        COMMANDS.REQUEST_STATUS,
        [],
        authenticator.sessionKey
      );

      await pollForRxPacketReady(300);

      if(rxPacket.valid) {
        switch(rxPacket.command) {
          case COMMANDS.REQUEST_STATUS: {
            handleRequestUpdatePacketData(rxPacket.data);
            handleDeviceResponding();
            txControllerGoToState('idle');
          }
          break;

          default: {
            console.warn(`Expected ${COMMANDS.REQUEST_STATUS}, but received ${rxPacket.command}`);
            txControllerGoToState('idle');
          }
          break;
        }
      } else {
        console.warn(`Didn't receive requestStatus response`);
        txControllerGoToState('idle');
        handleDeviceNotResponding();
      }
    }
    break;
  }

  if(!instantReRunRequestFlag) {
    await toolBox.asyncDelay(runInterval);
  }
  
  txControlRun();
}

function handleDeviceNotResponding () {
  authenticator.deviceNotRespondingCounter++
  if(authenticator.deviceNotRespondingCounter === 3) {
    terminateSession();
  }
}

function handleDeviceResponding () {
  if(authenticator.deviceNotRespondingCounter !== 0) {
    authenticator.deviceNotRespondingCounter--;
  }
}

function handleRequestUpdatePacketData (statusData) {
    let bytes = [...statusData];
  
    // console.log('bytes');
    // console.log(bytes);

    const extractBytes = (numOfBytes) => {
      return bytes.splice(0, numOfBytes);
    }
    const extractU32 = () => {
      return toolBox.arrayToInt(extractBytes(4), false);
    }
    const extractU32Array = (numOfU32s) => {
      let result = [];
      for(let i = 0; i < numOfU32s; i++) {
        result.push(extractU32());
      }
      return result;
    }
    const extractI32 = () => {
      return toolBox.arrayToInt(extractBytes(4), true);
    }
    const extractU16 = () => {
      return toolBox.arrayToInt(extractBytes(2), false);
    }
    const extractI16 = () => {
      return toolBox.arrayToInt(extractBytes(2), true);
    }
    const extractU8 = () => {
      return toolBox.arrayToInt(extractBytes(1), false);
    }
    const extractU8Array = (numOfU8s) => {
      let result = [];
      for(let i = 0; i < numOfU8s; i++) {
        result.push(extractU8());
      }
      return result;
    }
    const extractI8 = () => {
      return toolBox.arrayToInt(extractBytes(1), true);
    }
    const extractFloat = () => {
      return toolBox.array4ToFloat32(extractBytes(4), true);
    }
    const extractDouble = () => {
      return toolBox.array8ToFloat64(extractBytes(8), true);
    }
    const extractDummyBytes = (numOfBytes) => {
      extractBytes(numOfBytes);
    }

    appParams.status = {};
    appParams.setting = {};

    /* appStatus Begin ↓ *********************************/
      appParams.status.rtcBatteryVoltage = extractFloat();
      appParams.status.rtcDataArray = extractU8Array(6);
      appParams.status.rtcDataArray[0] += 2000;
      appParams.status.keyBankMainInitialSeedLength = extractU32();
      appParams.status.keyBankMainInitialSeed = extractU8Array(appParams.status.keyBankMainInitialSeedLength);
      appParams.status.keyBankBackupInitialSeedLength = extractU32();
      appParams.status.keyBankBackupInitialSeed = extractU8Array(appParams.status.keyBankBackupInitialSeedLength);
      appParams.status.testKssStreamGenerationRunning = extractU8();
    /* appStatus End   ↑ *********************************/
    /* appSetting Begin ↓ *********************************/
      appParams.setting.buzzerVolumePercent = extractU8();
      appParams.setting.deviceWorkingMode = extractU8();
      appParams.setting.deviceId = extractU16(2);
      appParams.setting.deviceIdLength = extractU8();
      appParams.setting.remoteDischargeMessage = extractU8Array(6);
      appParams.setting.blackListBypass = extractU8();
      appParams.setting.selectedKeyBank = extractU8();
      appParams.setting.caseOpenEventAction = extractU8();
      appParams.setting.remoteDischargeEnable = extractU8();
      appParams.setting.decPortRxBaudRate = extractU32();
      appParams.setting.decPortTxBaudRate = extractU32();
      appParams.setting.encPortRxBaudRate = extractU32();
      appParams.setting.encPortTxBaudRate = extractU32();
      appParams.setting.rtcPacketSectionEnabled = extractU8();
      appParams.setting.maximumValidRtcTimeDifference = extractU32();
      appParams.setting.decryptedPortRxTimeoutMs = extractU32();
      appParams.setting.encryptedPortRxTimeoutMs = extractU32();
      appParams.setting.encryptedPacketMaxDataLength = extractU32();
      appParams.setting.deviceIdBlackListLength = extractU32();
      appParams.setting.encryptedPacketHeaderSize = extractU8();
      appParams.setting.encryptedPacketHeader = extractU8Array(appParams.setting.encryptedPacketHeaderSize);
    /* appSetting End   ↑ *********************************/
  
    if(false){}

    serialToUiEventCallback({
      name: 'appParametersUpdate',
      data: appParams
    });
}

function packetReceiveEvent (command, data) {
  // console.log(`packetReceiveEvent (${toolBox.toHexString([command])}, ${toolBox.toHexString(data)})`);

  rxPacket.data = data;
  rxPacket.command = command;
  rxPacket.commandName = toolBox.getFieldNameByValue(COMMANDS, command);
  rxPacket.valid = true;

  switch(rxPacket.command) {
    case COMMANDS.NACK: {
      let errorCode = rxPacket.data[1];

      switch(errorCode) {
        case PACKET_ERROR_CODES.CONCIFG_PORT_PACKET_ERROR_SESSION_NOT_ACTIVE: {
          console.log('CONCIFG_PORT_PACKET_ERROR_SESSION_NOT_ACTIVE');
          terminateSession();
        }
        break;

        case PACKET_ERROR_CODES.CONCIFG_PORT_PACKET_ERROR_SESSION_PACKET: {
          console.log('CONCIFG_PORT_PACKET_ERROR_SESSION_PACKET');
          authenticator.sessionPacketFailCounter++;
          if(authenticator.sessionPacketFailCounter === 3) {
            terminateSession();
          }
        }
        break;

        default: {
          
        }
        break;
      }
    }
    break;

    default :{

    }
    break;
  }
}

function terminateSession () {
  authenticator.sessionActive = false;
  
  console.log(
    '%cSession Terminated',
    'color:white; background:red; font-size:2rem; padding: .5rem;',
  );
}

async function pollForRxPacketReady (maxTimeout) {
  const TIME_STEP = 20;

  async function _pollForRxPacketReady (maxTimeout) {
    await toolBox.asyncDelay(TIME_STEP);
  
    if(rxPacket.valid) {
      return;
    }
  
    if(maxTimeout > TIME_STEP) {
      maxTimeout -= TIME_STEP;
      await _pollForRxPacketReady(maxTimeout);
    }
  }

  rxPacket.valid = false;
  await _pollForRxPacketReady(maxTimeout);
}

function uiToSerialRequest (requestName, requestData=null) {
  console.log('uiToSerialRequest(', requestName, ',', requestData, ')');
  
  let bytes = [...rxPacket.data];

  const extractBytes = (numOfBytes) => {
    return bytes.splice(0, numOfBytes);
  }
  const extractU32 = () => {
    return toolBox.arrayToInt(extractBytes(4), false);
  }
  const extractU32Array = (numOfU32s) => {
    let result = [];
    for(let i = 0; i < numOfU32s; i++) {
      result.push(extractU32());
    }
    return result;
  }
  const extractI32 = () => {
    return toolBox.arrayToInt(extractBytes(4), true);
  }
  const extractU16 = () => {
    return toolBox.arrayToInt(extractBytes(2), false);
  }
  const extractI16 = () => {
    return toolBox.arrayToInt(extractBytes(2), true);
  }
  const extractU8 = () => {
    return toolBox.arrayToInt(extractBytes(1), false);
  }
  const extractI8 = () => {
    return toolBox.arrayToInt(extractBytes(1), true);
  }
  const extractFloat = () => {
    return toolBox.array4ToFloat32(extractBytes(4), true);
  }
  const extractDummyBytes = (numOfBytes) => {
    extractBytes(numOfBytes);
  }

  uiToSerialPendingRequest.maxResponseTime = DEFAULT_MAX_RESPONSE_TIME;
  uiToSerialPendingRequest.isSpecialCommand = false;
  uiToSerialPendingRequest.requestName = requestName;
  uiToSerialPendingRequest.requestData = requestData;

  switch(requestName) {
    case 'sendHello': {
      createUiToSerialPendingPacket(
        serialTx.createPacket(
          COMMANDS.HELLO
        )
      );
      uiToSerialPendingRequest.expectedResponse = 'none';
      uiToSerialPendingRequest.successMessage = 'پاسخ Hello دریافت شد';
      uiToSerialPendingRequest.failureMessage = 'پاسخ Hello دریافت نشد';
    }
    break;

    case 'setBuzzerVolume': {
      createUiToSerialPendingPacket(
        serialTx.createPacket(
          COMMANDS.SET_BUZZER_VOLUME,
          toolBox.intToArray(requestData, 1, false),
          authenticator.sessionKey
        )
      );
      uiToSerialPendingRequest.expectedResponse = 'simpleAck';
      uiToSerialPendingRequest.successMessage = `سطح صدا بازر اعمال شد`;
      uiToSerialPendingRequest.failureMessage = 'خطا';
    }
    break;

    case 'testLed': {
      createUiToSerialPendingPacket(
        serialTx.createPacket(
          COMMANDS.TEST_LED,
          toolBox.intToArray(requestData, 1, false),
          authenticator.sessionKey
        )
      );
      uiToSerialPendingRequest.expectedResponse = 'simpleAck';
      uiToSerialPendingRequest.successMessage = `تست LED ${requestData + 1} شروع شد`;
      uiToSerialPendingRequest.failureMessage = 'خطا';
    }
    break;

    case 'setWorkingMode': {
      createUiToSerialPendingPacket(
        serialTx.createPacket(
          COMMANDS.SET_DEVICE_WORKING_MODE,
          toolBox.intToArray(requestData, 1, false),
          authenticator.sessionKey
        )
      );
      uiToSerialPendingRequest.expectedResponse = 'simpleAck';
      uiToSerialPendingRequest.successMessage = `حالت کاری سیستم اعمال شد`;
      uiToSerialPendingRequest.failureMessage = 'خطا';
    }
    break;

    case 'setDeviceId': {
      createUiToSerialPendingPacket(
        serialTx.createPacket(
          COMMANDS.SET_DEVICE_ID,
          requestData,
          authenticator.sessionKey
        )
      );
      uiToSerialPendingRequest.expectedResponse = 'simpleAck';
      uiToSerialPendingRequest.successMessage = `شناسه دستگاه اعمال شد`;
      uiToSerialPendingRequest.failureMessage = 'خطا';
    }
    break;

    case 'setDeviceIdLength': {
      createUiToSerialPendingPacket(
        serialTx.createPacket(
          COMMANDS.SET_DEVICE_ID_LENGTH,
          toolBox.intToArray(requestData, 1, false),
          authenticator.sessionKey
        )
      );
      uiToSerialPendingRequest.expectedResponse = 'simpleAck';
      uiToSerialPendingRequest.successMessage = `طول شناسه دستگاه اعمال شد`;
      uiToSerialPendingRequest.failureMessage = 'خطا';
    }
    break;

    case 'setBlackListBypass': {
      createUiToSerialPendingPacket(
        serialTx.createPacket(
          COMMANDS.SET_BLACK_LIST_BYPASS,
          toolBox.intToArray(requestData, 1, false),
          authenticator.sessionKey
        )
      );
      uiToSerialPendingRequest.expectedResponse = 'simpleAck';
      uiToSerialPendingRequest.successMessage = `تنظیم بررسی لیست سیاه اعمال شد`;
      uiToSerialPendingRequest.failureMessage = 'خطا';
    }
    break;

    case 'setRtcTime': {
      createUiToSerialPendingPacket(
        serialTx.createPacket(
          COMMANDS.SET_RTC_TIME,
          requestData,
          authenticator.sessionKey
        )
      );
      uiToSerialPendingRequest.expectedResponse = 'simpleAck';
      uiToSerialPendingRequest.successMessage = `زمان RTC دستگاه اعمال شد`;
      uiToSerialPendingRequest.failureMessage = 'خطا';
    }
    break;

    case 'setRemoteDischargeCommand': {
      createUiToSerialPendingPacket(
        serialTx.createPacket(
          COMMANDS.SET_REMOTE_DISCHARGE_MESSAGE,
          requestData,
          authenticator.sessionKey
        )
      );
      uiToSerialPendingRequest.expectedResponse = 'simpleAck';
      uiToSerialPendingRequest.successMessage = `دستور تخلیه از راه دور جدید اعمال شد`;
      uiToSerialPendingRequest.failureMessage = 'خطا';
    }
    break;

    case 'setKeyBankMainSeed': {
      createUiToSerialPendingPacket(
        serialTx.createPacket(
          COMMANDS.SET_MAIN_KEY_BANK_SEED,
          requestData,
          authenticator.sessionKey
        )
      );
      uiToSerialPendingRequest.expectedResponse = 'simpleAck';
      uiToSerialPendingRequest.successMessage = `مقدار Seed تولید بانک کلید اصلی اعمال شد`;
      uiToSerialPendingRequest.failureMessage = 'خطا';
      uiToSerialPendingRequest.maxResponseTime = KEY_BANK_GENERATION_MAX_RESPONSE_TIME;
    }
    break;

    case 'setKeyBankBackupSeed': {
      createUiToSerialPendingPacket(
        serialTx.createPacket(
          COMMANDS.SET_BACKUP_KEY_BANK_SEED,
          requestData,
          authenticator.sessionKey
        )
      );
      uiToSerialPendingRequest.expectedResponse = 'simpleAck';
      uiToSerialPendingRequest.successMessage = `مقدار Seed تولید بانک کلید پشتیبان اعمال شد`;
      uiToSerialPendingRequest.failureMessage = 'خطا';
      uiToSerialPendingRequest.maxResponseTime = KEY_BANK_GENERATION_MAX_RESPONSE_TIME;
    }
    break;

    case 'setEncPortHeader': {
      createUiToSerialPendingPacket(
        serialTx.createPacket(
          COMMANDS.SET_ENCRYPTED_PORT_HEADER,
          requestData,
          authenticator.sessionKey
        )
      );
      uiToSerialPendingRequest.expectedResponse = 'simpleAck';
      uiToSerialPendingRequest.successMessage = `هدر جدید پکت های رمز اعمال شد`;
      uiToSerialPendingRequest.failureMessage = 'خطا';
    }
    break;

    case 'selectKeyBank': {
      createUiToSerialPendingPacket(
        serialTx.createPacket(
          COMMANDS.SET_SELECTED_KEY_BANK,
          [requestData],
          authenticator.sessionKey
        )
      );
      uiToSerialPendingRequest.expectedResponse = 'simpleAck';
      uiToSerialPendingRequest.successMessage = `بانک کلید جایگزین انتخاب شد`;
      uiToSerialPendingRequest.failureMessage = 'خطا';
      uiToSerialPendingRequest.maxResponseTime = KEY_BANK_GENERATION_MAX_RESPONSE_TIME;
    }
    break;

    case 'setCaseOpenEventAction': {
      createUiToSerialPendingPacket(
        serialTx.createPacket(
          COMMANDS.SET_CASE_OPEN_EVENT_ACTION,
          [requestData],
          authenticator.sessionKey
        )
      );
      uiToSerialPendingRequest.expectedResponse = 'simpleAck';
      uiToSerialPendingRequest.successMessage = `تنظیم تشخیص باز شدن کیس اعمال شد`;
      uiToSerialPendingRequest.failureMessage = 'خطا';
    }
    break;

    case 'setRemoteDischargeEnable': {
      createUiToSerialPendingPacket(
        serialTx.createPacket(
          COMMANDS.SET_REMOTE_DISCHARGE_ENABLE,
          [requestData],
          authenticator.sessionKey
        )
      );
      uiToSerialPendingRequest.expectedResponse = 'simpleAck';
      uiToSerialPendingRequest.successMessage = `تنظیم فعال بودن دستور تخلیه از راه دور`;
      uiToSerialPendingRequest.failureMessage = 'خطا';
    }
    break;

    case 'dischargeKeyBanks': {
      createUiToSerialPendingPacket(
        serialTx.createPacket(
          COMMANDS.DISCHARGE_KEY_BANKS,
          [requestData],
          authenticator.sessionKey
        )
      );
      uiToSerialPendingRequest.expectedResponse = 'simpleAck';
      uiToSerialPendingRequest.successMessage = `بانک های کلید تخلیه شد`;
      uiToSerialPendingRequest.failureMessage = 'خطا';
    }
    break;

    case 'setEncryptedPortTxBaudRate': {
      createUiToSerialPendingPacket(
        serialTx.createPacket(
          COMMANDS.SET_ENCRYPTED_PORT_TX_BAUD_RATE,
          toolBox.intToArray(requestData, 4, false),
          authenticator.sessionKey
        )
      );
      uiToSerialPendingRequest.expectedResponse = 'simpleAck';
      uiToSerialPendingRequest.successMessage = `مقدار Baud Rate تنظیم شد`;
      uiToSerialPendingRequest.failureMessage = 'خطا';
    }
    break;

    case 'setEncryptedPortRxBaudRate': {
      createUiToSerialPendingPacket(
        serialTx.createPacket(
          COMMANDS.SET_ENCRYPTED_PORT_RX_BAUD_RATE,
          toolBox.intToArray(requestData, 4, false),
          authenticator.sessionKey
        )
      );
      uiToSerialPendingRequest.expectedResponse = 'simpleAck';
      uiToSerialPendingRequest.successMessage = `مقدار Baud Rate تنظیم شد`;
      uiToSerialPendingRequest.failureMessage = 'خطا';
    }
    break;

    case 'setDecryptedPortTxBaudRate': {
      createUiToSerialPendingPacket(
        serialTx.createPacket(
          COMMANDS.SET_DECRYPTED_PORT_TX_BAUD_RATE,
          toolBox.intToArray(requestData, 4, false),
          authenticator.sessionKey
        )
      );
      uiToSerialPendingRequest.expectedResponse = 'simpleAck';
      uiToSerialPendingRequest.successMessage = `مقدار Baud Rate تنظیم شد`;
      uiToSerialPendingRequest.failureMessage = 'خطا';
    }
    break;

    case 'setDecryptedPortRxBaudRate': {
      createUiToSerialPendingPacket(
        serialTx.createPacket(
          COMMANDS.SET_DECRYPTED_PORT_RX_BAUD_RATE,
          toolBox.intToArray(requestData, 4, false),
          authenticator.sessionKey
        )
      );
      uiToSerialPendingRequest.expectedResponse = 'simpleAck';
      uiToSerialPendingRequest.successMessage = `مقدار Baud Rate تنظیم شد`;
      uiToSerialPendingRequest.failureMessage = 'خطا';
    }
    break;

    case 'setPacketTimeStampEnable': {
      createUiToSerialPendingPacket(
        serialTx.createPacket(
          COMMANDS.SET_RTC_PACKET_SECTION_ENABLED,
          [requestData],
          authenticator.sessionKey
        )
      );
      uiToSerialPendingRequest.expectedResponse = 'simpleAck';
      uiToSerialPendingRequest.successMessage = `فعال بودن بخش Timestamp تنظیم شد`;
      uiToSerialPendingRequest.failureMessage = 'خطا';
    }
    break;

    case 'setMaxTimeStampDifference': {
      createUiToSerialPendingPacket(
        serialTx.createPacket(
          COMMANDS.SET_MAXIMUM_VALID_RTC_TIME_DIFFERENCE,
          toolBox.intToArray(requestData, 4, false),
          authenticator.sessionKey
        )
      );
      uiToSerialPendingRequest.expectedResponse = 'simpleAck';
      uiToSerialPendingRequest.successMessage = `ماکسیمم اختلاف Timestamp قابل قبول تنظیم شد`;
      uiToSerialPendingRequest.failureMessage = 'خطا';
    }
    break;

    case 'setDecryptedPortRxTimeoutMs': {
      createUiToSerialPendingPacket(
        serialTx.createPacket(
          COMMANDS.SET_DECRYPTED_PORT_RX_TIMEOUT_MS,
          toolBox.intToArray(requestData, 4, false),
          authenticator.sessionKey
        )
      );
      uiToSerialPendingRequest.expectedResponse = 'simpleAck';
      uiToSerialPendingRequest.successMessage = `مقدار Timeout درگاه کشف تنظیم شد`;
      uiToSerialPendingRequest.failureMessage = 'خطا';
    }
    break;

    case 'setEncryptedPortRxTimeoutMs': {
      createUiToSerialPendingPacket(
        serialTx.createPacket(
          COMMANDS.SET_ENCRYPTED_PORT_RX_TIMEOUT_MS,
          toolBox.intToArray(requestData, 4, false),
          authenticator.sessionKey
        )
      );
      uiToSerialPendingRequest.expectedResponse = 'simpleAck';
      uiToSerialPendingRequest.successMessage = `مقدار Timeout درگاه رمز تنظیم شد`;
      uiToSerialPendingRequest.failureMessage = 'خطا';
    }
    break;

    case 'setEncryptedPacketMaxDataLength': {
      createUiToSerialPendingPacket(
        serialTx.createPacket(
          COMMANDS.SET_ENCRYPTED_PACKET_MAX_DATA_LENGTH,
          toolBox.intToArray(requestData, 4, false),
          authenticator.sessionKey
        )
      );
      uiToSerialPendingRequest.expectedResponse = 'simpleAck';
      uiToSerialPendingRequest.successMessage = `ماکسیمم طول Data پکت های رمز تنظیم شد`;
      uiToSerialPendingRequest.failureMessage = 'خطا';
    }
    break;

    case 'startKssStreamGeneration': {
      createUiToSerialPendingPacket(
        serialTx.createPacket(
          COMMANDS.START_KSS_STREAM_GENERATION,
          requestData,
          authenticator.sessionKey
        )
      );
      uiToSerialPendingRequest.expectedResponse = 'simpleAck';
      uiToSerialPendingRequest.successMessage = `تولید رشته KSS بی نهایت شروع شد`;
      uiToSerialPendingRequest.failureMessage = 'خطا';
    }
    break;

    case 'stopKssStreamGeneration': {
      createUiToSerialPendingPacket(
        serialTx.createPacket(
          COMMANDS.STOP_KSS_STREAM_GENERATION,
          [],
          authenticator.sessionKey
        )
      );
      uiToSerialPendingRequest.expectedResponse = 'simpleAck';
      uiToSerialPendingRequest.successMessage = `تولید رشته KSS بی نهایت متوقف شد`;
      uiToSerialPendingRequest.failureMessage = 'خطا';
    }
    break;

    case 'setGuiPassword': {
      createUiToSerialPendingPacket(
        serialTx.createPacket(
          COMMANDS.SET_GUI_PASSWORD,
          requestData,
          authenticator.sessionKey
        )
      );
      uiToSerialPendingRequest.expectedResponse = 'simpleAck';
      uiToSerialPendingRequest.successMessage = `رمز عبور جدید اتصال نرم افزار ذخیره شد`;
      uiToSerialPendingRequest.failureMessage = 'خطا';
    }
    break;

    case 'writeBlackList': {
      uiToSerialPendingRequest.isSpecialCommand = true;
      uiToSerialPendingRequest.valid = true;
    }
    break;

    case 'readBlackList': {
      uiToSerialPendingRequest.isSpecialCommand = true;
      uiToSerialPendingRequest.valid = true;
    }
    break;

    case 'authenticationPassword': {
      authenticator.guiPass = requestData;
    }
    break;

    default:
      throw new Error('uiToSerialRequest: Unknown requestName');
  }
}

async function exportBlackListExcell (blackList) {
  let blackListWorkbookPath = await personalExcelApi.selectExcelToSave();
  if(!blackListWorkbookPath) {
    popUpMessage.displayPopUp(
      `لغو شد`,
      `BLACK`
    );
    
    return;
  }

  let blackListWorkbook = XLSX.utils.book_new();
  let sheet = XLSX.utils.aoa_to_sheet(
    blackList.map((deviceId) => [deviceId])
  );

  XLSX.utils.book_append_sheet(blackListWorkbook, sheet, 'Sheet1');

  personalExcelApi.saveWorkbook(blackListWorkbook, blackListWorkbookPath);
}
window.exportBlackListExcell = exportBlackListExcell;

function init (serialToUiEventCallbackHandle) {
  serialToUiEventCallback = serialToUiEventCallbackHandle;

  serialRx.init(packetReceiveEvent);
  serialTx.init();

  txControlRun();
}

module.exports = {
  init,
  registerComPortStillConnectedFunction,
  uiToSerialRequest,
}



/***/ }),

/***/ "./src/serialRx.js":
/*!*************************!*\
  !*** ./src/serialRx.js ***!
  \*************************/
/***/ ((module, __unused_webpack_exports, __webpack_require__) => {

"use strict";


const toolBox = __webpack_require__(/*! ./toolBox */ "./src/toolBox.js")
const config = __webpack_require__(/*! ./config */ "./src/config.js")
const personalSerialPort = __webpack_require__(/*! ./personalSerialPort */ "./src/personalSerialPort.js")

let rxBytesIntervalThread = toolBox.threadTimerFactoryFunc();
let rxBuffer = [];
let packetReceiveCallbackEvent = null;

let managementHeaderDetector = toolBox.sequenceDetectorFactoryFunc(
  toolBox.stringToAsciiArray(config.serial.MANAGEMENT_PACKET_HEADER)
);

/*
╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════╗
║ MCU to PC Packet Structure ------------------------------------------------------------------------------ ║
╠══════════════════╦════════╤═════════╤═══════════════╤═════════════╤═══════════════════════╤═══════════════╣
║ Packet Section ► ║ Header │ Command │   Data Size   │    Data     │ Authentication Packet │   Checksum    ║
╠══════════════════╣────────┼─────────┼───────────────┼─────────────┼───────────────────────┼───────────────║
║ Num of bytes   ► ║   4    │    1    │       2       │ "Data Size" │          32           │       1       ║
╠══════════════════╣────────┼─────────┼───────────────┼─────────────┼───────────────────────┼───────────────║
║ Description    ► ║        │         │ Little Endian │             │                       │ Little Endian ║
╚══════════════════╩════════╧═════════╧═══════════════╧═════════════╧═══════════════════════╧═══════════════╝
*/
let rxPacketHandler = {
  state: 'header',
  index: 0,
  packetBuffer: {},
  rxRawArray: [],

  handleNewByte(newByte) {
    this.rxRawArray.push(newByte);

    switch(this.state) {
      case 'header':
        break;

      case 'command':
        this.packetBuffer.command = newByte;
        this.goToState('dataSize');
        break;

      case 'dataSize':
        this.packetBuffer.dataSize += (newByte << (8 * this.index));
        this.index++;

        if(this.index === 2) {
          if(this.packetBuffer.dataSize !== 0) {
            this.goToState('data');
          } else {
            this.goToState('sessionPacket');
          }
        }
        break;

      case 'data':
        this.packetBuffer.data.push(newByte);
        this.index++;

        if(this.index === this.packetBuffer.dataSize) {
          this.goToState('sessionPacket');
        }
        break;

      case 'sessionPacket':
        this.packetBuffer.sessionPacket.push(newByte);
        this.index++;

        if(this.index === 32) {
          this.goToState('checksum');
        }
        break;

      case 'checksum':
        this.packetBuffer.checksum += (newByte << (8 * this.index));
        this.index++;
        
        this.handlePacketFinished();
        break;

      default:
        console.log(`WHAT THE HELL IS THIS rxPacketHandler.state: ${this.state}`);
        break;
    }

    if(managementHeaderDetector.checkForSequence(newByte)) {
      this.rxRawArray = [...toolBox.stringToAsciiArray(config.serial.MANAGEMENT_PACKET_HEADER)];
      this.packetBuffer = {
        header: [...toolBox.stringToAsciiArray(config.serial.MANAGEMENT_PACKET_HEADER)],
        command: 0,
        dataSize: 0,
        data: [],
        sessionPacket: [],
        checksum: 0,
      };
      this.goToState('command');
    }
  },

  handlePacketFinished() {
    let expectedChecksum = this.rxRawArray.slice(0, -1).reduce((curr, next) => curr + next);
    expectedChecksum &= 0xFF;

    if(expectedChecksum == this.packetBuffer.checksum) {
      if(packetReceiveCallbackEvent !== null) {
        packetReceiveCallbackEvent(this.packetBuffer.command, this.packetBuffer.data, this.packetBuffer.sessionPacket);
      }
    } else {
      console.log('New Packet:');
      console.log(this.rxRawArray);
      console.log(toolBox.toHexString(this.rxRawArray, ' '));
      console.log(`%cWrong Checkum !!!`, 'color: white; background: red;');
      console.log(`Received Checkum = ${this.packetBuffer.checksum}`);
      console.log(`Expected Checkum = ${expectedChecksum}    ${toolBox.toHexString(toolBox.intToArray(expectedChecksum, 1, false, true), ' ')}`);
      console.log('Packet', toolBox.toHexString(rxBuffer, ' '));
      console.log(this.packetBuffer);
    }
    
    rxBuffer = [];
    this.reset();
  },

  goToState(newState) {
    this.state = newState;
    this.index = 0;
  },

  reset() {
    this.goToState('header');
  },

  handleTimeout() {

  }
}

function serialRxCallbackFunction(dataByte) {
  rxBuffer.push(dataByte);
  rxBytesIntervalThread.setNextInterval(config.serial.MAX_RX_BYTE_INTERVAL);
  
  rxPacketHandler.handleNewByte(dataByte);
}

function init(packetReceiveCallback) {
  packetReceiveCallbackEvent = packetReceiveCallback;
  
  setInterval(() => {
    if(rxBytesIntervalThread.timePassed() && rxBuffer.length) {
      rxPacketHandler.handleTimeout();
    }
  }, config.serial.MAX_RX_BYTE_INTERVAL);

  personalSerialPort.setRxCallbackFunction(serialRxCallbackFunction);
}

function setGuiBaudRate (baudRate) {
  console.log(`setGuiBaudRate (${baudRate})`);
  personalSerialPort.setBaudRate(baudRate);
}

module.exports = {
  init,
  serialRxCallbackFunction,
  setGuiBaudRate,
}



/***/ }),

/***/ "./src/serialTx.js":
/*!*************************!*\
  !*** ./src/serialTx.js ***!
  \*************************/
/***/ ((module, __unused_webpack_exports, __webpack_require__) => {

"use strict";


const toolBox = __webpack_require__(/*! ./toolBox */ "./src/toolBox.js")
const config = __webpack_require__(/*! ./config */ "./src/config.js")
const personalSerialPort = __webpack_require__(/*! ./personalSerialPort */ "./src/personalSerialPort.js")
const personalHash = __webpack_require__(/*! ./personalHash */ "./src/personalHash.js")

const GUI_AUTHENTICATION_HASH_KEY = toolBox.stringToAsciiArray(
  config.serial.GUI_AUTHENTICATION_HASH_KEY
);

async function sendPacketArray (packetArray, consolePrint=false) {
  if(consolePrint) {
    console.log(
      `%cTX Packet (HEX)[0:${packetArray.length}]: ${toolBox.toHexString(packetArray, ' ')}`,
      'color: white; background: black; font-size:1.2em;',
    );
  }

  if(!personalSerialPort.isOpen()) {
    console.warn('Serial Port is Closed')
    return;
  }

  personalSerialPort.write(packetArray);
}

function init () {

}

function createAndSendPacket (command, data=[], sessionKey=[], consolePrint=false) {
  sendPacketArray(createPacket(command, data, sessionKey), consolePrint);
}

function createPacket (command, data=[], sessionKey=[]) {
  // console.log(`createPacket (${command}, ${data})`);

  let packet = [];
  let checksum = 0;
  packet.push(...toolBox.stringToAsciiArray(config.serial.MANAGEMENT_PACKET_HEADER));
  packet.push(command);
  packet.push(...toolBox.intToArray(data.length, 2, false));
  packet.push(...data);

  if(sessionKey.length === 0) {
    let randomArary = [];
    for(let i = 0; i < 32; i++) {
      randomArary.push(toolBox.randomRange(0, 255));
    }
    
    packet.push(...randomArary);
  } else {
    let sessionPacket = personalHash.createHash([
      ...packet,
      ...sessionKey
    ]);
    // console.log(
    //   `%csessionPacket: ${toolBox.toHexString(sessionPacket, ' ')}`,
    //   'color:white; background:black; font-size:2rem; padding: .5rem;',
    // );

    packet.push(...sessionPacket);
  }
  
  checksum = packet.reduce((curr, next) => curr + next);
  checksum &= 0xFF;

  packet.push(checksum);

  return packet;
}

module.exports = {
  init,
  sendPacketArray,
  createAndSendPacket,
  createPacket,
}



/***/ }),

/***/ "./src/toolBox.js":
/*!************************!*\
  !*** ./src/toolBox.js ***!
  \************************/
/***/ ((module) => {

"use strict";


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

function deepClone(obj) {
  return JSON.parse(JSON.stringify(obj));
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

function arrayToInt(arr, signed=false, littleEndian=true) {
  let size = arr.length;
  let uint8Array = new Uint8Array(arr);
  let result;

  if(!littleEndian) {
    uint8Array.reverse();
  }
  
  if(signed) {
    if(size <= 1) {
      result = (new Int8Array(uint8Array.buffer))[0];
    } else if(size <= 2) {
      result = (new Int16Array(uint8Array.buffer))[0];
    } else if(size <= 4) {
      result = (new Int32Array(uint8Array.buffer))[0];
    } else if(size <= 8) {
      throw new Error(`"intToArray: size = ${size}", is not supported`);
    }
  } else {
    if(size <= 1) {
      result = (new Uint8Array(uint8Array.buffer))[0];
    } else if(size <= 2) {
      result = (new Uint16Array(uint8Array.buffer))[0];
    } else if(size <= 4) {
      result = (new Uint32Array(uint8Array.buffer))[0];
    } else if(size <= 8) {
      throw new Error(`"intToArray: size = ${size}", is not supported`);
    }
  }

  return result;
}

function intToArray(num, size, signed=false, littleEndian=true) {
  let refArray;
  let result;
  
  if(signed) {
    if(size <= 1) {
      refArray = new Int8Array([num]);
    } else if(size <= 2) {
      refArray = new Int16Array([num]);
    } else if(size <= 4) {
      refArray = new Int32Array([num]);
    } else if(size <= 8) {
      throw new Error(`"intToArray: size = ${size}", is not supported`);
    }
  } else {
    if(size <= 1) {
      refArray = new Uint8Array([num]);
    } else if(size <= 2) {
      refArray = new Uint16Array([num]);
    } else if(size <= 4) {
      refArray = new Uint32Array([num]);
    } else if(size <= 8) {
      throw new Error(`"intToArray: size = ${size}", is not supported`);
    }
  }

  result = new Uint8Array(refArray.buffer);

  if(!littleEndian) {
    result.reverse();
  }

  return [...result];
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
      console.log("Text copied to clipboard");
  }).catch((err) => {
      console.error("Failed to copy text: ", err);
  });
}

function deepCopy(target) {
  return JSON.parse(JSON.stringify(target));;
}

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

module.exports = {
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
};



/***/ }),

/***/ "child_process":
/*!********************************!*\
  !*** external "child_process" ***!
  \********************************/
/***/ ((module) => {

"use strict";
module.exports = require("child_process");

/***/ }),

/***/ "crypto":
/*!*************************!*\
  !*** external "crypto" ***!
  \*************************/
/***/ ((module) => {

"use strict";
module.exports = require("crypto");

/***/ }),

/***/ "electron":
/*!***************************!*\
  !*** external "electron" ***!
  \***************************/
/***/ ((module) => {

"use strict";
module.exports = require("electron");

/***/ }),

/***/ "events":
/*!*************************!*\
  !*** external "events" ***!
  \*************************/
/***/ ((module) => {

"use strict";
module.exports = require("events");

/***/ }),

/***/ "fs":
/*!*********************!*\
  !*** external "fs" ***!
  \*********************/
/***/ ((module) => {

"use strict";
module.exports = require("fs");

/***/ }),

/***/ "os":
/*!*********************!*\
  !*** external "os" ***!
  \*********************/
/***/ ((module) => {

"use strict";
module.exports = require("os");

/***/ }),

/***/ "path":
/*!***********************!*\
  !*** external "path" ***!
  \***********************/
/***/ ((module) => {

"use strict";
module.exports = require("path");

/***/ }),

/***/ "stream":
/*!*************************!*\
  !*** external "stream" ***!
  \*************************/
/***/ ((module) => {

"use strict";
module.exports = require("stream");

/***/ }),

/***/ "tty":
/*!**********************!*\
  !*** external "tty" ***!
  \**********************/
/***/ ((module) => {

"use strict";
module.exports = require("tty");

/***/ }),

/***/ "util":
/*!***********************!*\
  !*** external "util" ***!
  \***********************/
/***/ ((module) => {

"use strict";
module.exports = require("util");

/***/ })

/******/ 	});
/************************************************************************/
/******/ 	// The module cache
/******/ 	var __webpack_module_cache__ = {};
/******/ 	
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/ 		// Check if module is in cache
/******/ 		var cachedModule = __webpack_module_cache__[moduleId];
/******/ 		if (cachedModule !== undefined) {
/******/ 			return cachedModule.exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = __webpack_module_cache__[moduleId] = {
/******/ 			// no module.id needed
/******/ 			// no module.loaded needed
/******/ 			exports: {}
/******/ 		};
/******/ 	
/******/ 		// Execute the module function
/******/ 		__webpack_modules__[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/ 	
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/ 	
/************************************************************************/
var __webpack_exports__ = {};
// This entry need to be wrapped in an IIFE because it need to be isolated against other modules in the chunk.
(() => {
/*!********************!*\
  !*** ./preload.js ***!
  \********************/
const path = __webpack_require__(/*! path */ "path");
const { contextBridge } = __webpack_require__(/*! electron */ "electron");
const serialInterface = __webpack_require__(/*! ./src/serialInterface */ "./src/serialInterface.js")
const personalSerialPort = __webpack_require__(/*! ./src/personalSerialPort */ "./src/personalSerialPort.js")
const personalWebFrame = __webpack_require__(/*! ./src/personalWebFrame */ "./src/personalWebFrame.js")
const personalExcelApi = __webpack_require__(/*! ./src/personalExcelApi */ "./src/personalExcelApi.js")

contextBridge.exposeInMainWorld('pathAPI', {
  join: path.join,
  __dirname: __dirname
})

contextBridge.exposeInMainWorld('serialPortAPI',   { ...personalSerialPort });
contextBridge.exposeInMainWorld('webFrameAPI',     { ...personalWebFrame });
contextBridge.exposeInMainWorld('excel',           { ...personalExcelApi });
contextBridge.exposeInMainWorld('serialInterface', { ...serialInterface });

window.addEventListener('DOMContentLoaded', () => {

});

})();

/******/ })()
;
//# sourceMappingURL=data:application/json;charset=utf-8;base64,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QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBOztBQUVBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsRUFBRTs7QUFFRjtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxXQUFXLDRDQUE0Qzs7QUFFdkQ7QUFDQTtBQUNBO0FBQ0EsV0FBVyxRQUFRO0FBQ25CO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLElBQUk7QUFDSjtBQUNBO0FBQ0EsR0FBRztBQUNIO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBLFlBQVksUUFBUTtBQUNwQjtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxHQUFHO0FBQ0g7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxZQUFZO0FBQ1o7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFD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RUE7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBOztBQUVBOztBQUVBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7O0FBRUE7QUFDQSxpQ0FBaUMsR0FBRztBQUNwQzs7QUFFQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBOztBQUVBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7Ozs7Ozs7Ozs7QUN0SUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxLQUFLO0FBQ0wsR0FBRztBQUNIO0FBQ0E7Ozs7Ozs7Ozs7OztBQ3ZEYTtBQUNiO0FBQ0EsYUFBYSxtQkFBTyxDQUFDLG1JQUFNO0FBQzNCLFFBQVEsY0FBYyxFQUFFLG1CQUFPLENBQUMsMEJBQVU7QUFDMUM7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNB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QUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSwyREFBMkQsaUJBQWlCO0FBQzVFO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtB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O0FBQ047QUFDQSxNQUFNO0FBQ047QUFDQSxNQUFNO0FBQ04sNkNBQTZDLEtBQUs7QUFDbEQ7QUFDQSxJQUFJO0FBQ0o7QUFDQTtBQUNBLE1BQU07QUFDTjtBQUNBLE1BQU07QUFDTjtBQUNBLE1BQU07QUFDTiw2Q0FBNkMsS0FBSztBQUNsRDtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLE1BQU07QUFDTjtBQUNBLE1BQU07QUFDTjtBQUNBLE1BQU07QUFDTiw2Q0FBNkMsS0FBSztBQUNsRDtBQUNBLElBQUk7QUFDSjtBQUNBO0FBQ0EsTUFBTTtBQUNOO0FBQ0EsTUFBTTtBQUNOO0FBQ0EsTUFBTTtBQUNOLDZDQUE2QyxLQUFLO0FBQ2xEO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLHNDQUFzQyxLQUFLO0FBQzNDO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxzQ0FBc0MsS0FBSztBQUMzQztBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsS0FBSztBQUNMO0FBQ0E7QUFDQTtBQUNBLEtBQUs7QUFDTDtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLEdBQUc7QUFDSDtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsS0FBSztBQUNMO0FBQ0E7QUFDQTtBQUNBLEtBQUs7QUFDTDtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxRQUFRO0FBQ1I7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsR0FBRztBQUNIO0FBQ0EsaUJBQWlCLHFCQUFxQjtBQUN0QztBQUNBO0FBQ0E7QUFDQSxNQUFNO0FBQ047QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLEdBQUc7QUFDSDtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLEdBQUc7QUFDSDtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLHdDQUF3QyxFQUFFO0FBQzFDO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLEdBQUc7QUFDSDtBQUNBLEdBQUc7QUFDSDtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxlQUFlO0FBQ2Y7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsaUJBQWlCLG1CQUFtQjtBQUNwQztBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7Ozs7Ozs7Ozs7OztBQ2pnQkE7Ozs7Ozs7Ozs7O0FDQUE7Ozs7Ozs7Ozs7O0FDQUE7Ozs7Ozs7Ozs7O0FDQUE7Ozs7Ozs7Ozs7O0FDQUE7Ozs7Ozs7Ozs7O0FDQUE7Ozs7Ozs7Ozs7O0FDQUE7Ozs7Ozs7Ozs7O0FDQUE7Ozs7Ozs7Ozs7O0FDQUE7Ozs7Ozs7Ozs7O0FDQUE7Ozs7OztVQ0FBO1VBQ0E7O1VBRUE7VUFDQTtVQUNBO1VBQ0E7VUFDQTtVQUNBO1VBQ0E7VUFDQTtVQUNBO1VBQ0E7VUFDQTtVQUNBO1VBQ0E7O1VBRUE7VUFDQTs7VUFFQTtVQUNBO1VBQ0E7Ozs7Ozs7OztBQ3RCQSxhQUFhLG1CQUFPLENBQUMsa0JBQU07QUFDM0IsUUFBUSxnQkFBZ0IsRUFBRSxtQkFBTyxDQUFDLDBCQUFVO0FBQzVDLHdCQUF3QixtQkFBTyxDQUFDLHVEQUF1QjtBQUN2RCwyQkFBMkIsbUJBQU8sQ0FBQyw2REFBMEI7QUFDN0QseUJBQXlCLG1CQUFPLENBQUMseURBQXdCO0FBQ3pELHlCQUF5QixtQkFBTyxDQUFDLHlEQUF3QjtBQUN6RDtBQUNBO0FBQ0E7QUFDQTtBQUNBLENBQUM7QUFDRDtBQUNBLHFEQUFxRCx1QkFBdUI7QUFDNUUscURBQXFELHFCQUFxQjtBQUMxRSxxREFBcUQscUJBQXFCO0FBQzFFLHFEQUFxRCxvQkFBb0I7QUFDekU7QUFDQTtBQUNBO0FBQ0EsQ0FBQyIsInNvdXJjZXMiOlsid2VicGFjazovL2VuY3J5cHRpb25fZGV2aWNlX3NlcGVocl9tYW5hZ2VtZW50Ly4vbm9kZV9tb2R1bGVzL0BzZXJpYWxwb3J0L2JpbmRpbmctbW9jay9kaXN0L2luZGV4LmpzIiwid2VicGFjazovL2VuY3J5cHRpb25fZGV2aWNlX3NlcGVocl9tYW5hZ2VtZW50Ly4vbm9kZV9tb2R1bGVzL0BzZXJpYWxwb3J0L2JpbmRpbmdzLWNwcC9kaXN0L2Rhcndpbi5qcyIsIndlYnBhY2s6Ly9lbmNyeXB0aW9uX2RldmljZV9zZXBlaHJfbWFuYWdlbWVudC8uL25vZGVfbW9kdWxlcy9Ac2VyaWFscG9ydC9iaW5kaW5ncy1jcHAvZGlzdC9lcnJvcnMuanMiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvLi9ub2RlX21vZHVsZXMvQHNlcmlhbHBvcnQvYmluZGluZ3MtY3BwL2Rpc3QvaW5kZXguanMiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvLi9ub2RlX21vZHVsZXMvQHNlcmlhbHBvcnQvYmluZGluZ3MtY3BwL2Rpc3QvbGludXgtbGlzdC5qcyIsIndlYnBhY2s6Ly9lbmNyeXB0aW9uX2RldmljZV9zZXBlaHJfbWFuYWdlbWVudC8uL25vZGVfbW9kdWxlcy9Ac2VyaWFscG9ydC9iaW5kaW5ncy1jcHAvZGlzdC9saW51eC5qcyIsIndlYnBhY2s6Ly9lbmNyeXB0aW9uX2RldmljZV9zZXBlaHJfbWFuYWdlbWVudC8uL25vZGVfbW9kdWxlcy9Ac2VyaWFscG9ydC9iaW5kaW5ncy1jcHAvZGlzdC9sb2FkLWJpbmRpbmdzLmpzIiwid2VicGFjazovL2VuY3J5cHRpb25fZGV2aWNlX3NlcGVocl9tYW5hZ2VtZW50Ly4vbm9kZV9tb2R1bGVzL0BzZXJpYWxwb3J0L2JpbmRpbmdzLWNwcC9kaXN0L3BvbGxlci5qcyIsIndlYnBhY2s6Ly9lbmNyeXB0aW9uX2RldmljZV9zZXBlaHJfbWFuYWdlbWVudC8uL25vZGVfbW9kdWxlcy9Ac2VyaWFscG9ydC9iaW5kaW5ncy1jcHAvZGlzdC91bml4LXJlYWQuanMiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvLi9ub2RlX21vZHVsZXMvQHNlcmlhbHBvcnQvYmluZGluZ3MtY3BwL2Rpc3QvdW5peC13cml0ZS5qcyIsIndlYnBhY2s6Ly9lbmNyeXB0aW9uX2RldmljZV9zZXBlaHJfbWFuYWdlbWVudC8uL25vZGVfbW9kdWxlcy9Ac2VyaWFscG9ydC9iaW5kaW5ncy1jcHAvZGlzdC93aW4zMi1zbi1wYXJzZXIuanMiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvLi9ub2RlX21vZHVsZXMvQHNlcmlhbHBvcnQvYmluZGluZ3MtY3BwL2Rpc3Qvd2luMzIuanMiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvLi9ub2RlX21vZHVsZXMvQHNlcmlhbHBvcnQvYmluZGluZ3MtaW50ZXJmYWNlL2Rpc3QvaW5kZXguanMiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvLi9ub2RlX21vZHVsZXMvQHNlcmlhbHBvcnQvcGFyc2VyLWJ5dGUtbGVuZ3RoL2Rpc3QvaW5kZXguanMiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvLi9ub2RlX21vZHVsZXMvQHNlcmlhbHBvcnQvcGFyc2VyLWNjdGFsay9kaXN0L2luZGV4LmpzIiwid2VicGFjazovL2VuY3J5cHRpb25fZGV2aWNlX3NlcGVocl9tYW5hZ2VtZW50Ly4vbm9kZV9tb2R1bGVzL0BzZXJpYWxwb3J0L3BhcnNlci1kZWxpbWl0ZXIvZGlzdC9pbmRleC5qcyIsIndlYnBhY2s6Ly9lbmNyeXB0aW9uX2RldmljZV9zZXBlaHJfbWFuYWdlbWVudC8uL25vZGVfbW9kdWxlcy9Ac2VyaWFscG9ydC9wYXJzZXItaW50ZXItYnl0ZS10aW1lb3V0L2Rpc3QvaW5kZXguanMiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvLi9ub2RlX21vZHVsZXMvQHNlcmlhbHBvcnQvcGFyc2VyLXBhY2tldC1sZW5ndGgvZGlzdC9pbmRleC5qcyIsIndlYnBhY2s6Ly9lbmNyeXB0aW9uX2RldmljZV9zZXBlaHJfbWFuYWdlbWVudC8uL25vZGVfbW9kdWxlcy9Ac2VyaWFscG9ydC9wYXJzZXItcmVhZGxpbmUvZGlzdC9pbmRleC5qcyIsIndlYnBhY2s6Ly9lbmNyeXB0aW9uX2RldmljZV9zZXBlaHJfbWFuYWdlbWVudC8uL25vZGVfbW9kdWxlcy9Ac2VyaWFscG9ydC9wYXJzZXItcmVhZHkvZGlzdC9pbmRleC5qcyIsIndlYnBhY2s6Ly9lbmNyeXB0aW9uX2RldmljZV9zZXBlaHJfbWFuYWdlbWVudC8uL25vZGVfbW9kdWxlcy9Ac2VyaWFscG9ydC9wYXJzZXItcmVnZXgvZGlzdC9pbmRleC5qcyIsIndlYnBhY2s6Ly9lbmNyeXB0aW9uX2RldmljZV9zZXBlaHJfbWFuYWdlbWVudC8uL25vZGVfbW9kdWxlcy9Ac2VyaWFscG9ydC9wYXJzZXItc2xpcC1lbmNvZGVyL2Rpc3QvZGVjb2Rlci5qcyIsIndlYnBhY2s6Ly9lbmNyeXB0aW9uX2RldmljZV9zZXBlaHJfbWFuYWdlbWVudC8uL25vZGVfbW9kdWxlcy9Ac2VyaWFscG9ydC9wYXJzZXItc2xpcC1lbmNvZGVyL2Rpc3QvZW5jb2Rlci5qcyIsIndlYnBhY2s6Ly9lbmNyeXB0aW9uX2RldmljZV9zZXBlaHJfbWFuYWdlbWVudC8uL25vZGVfbW9kdWxlcy9Ac2VyaWFscG9ydC9wYXJzZXItc2xpcC1lbmNvZGVyL2Rpc3QvaW5kZXguanMiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvLi9ub2RlX21vZHVsZXMvQHNlcmlhbHBvcnQvcGFyc2VyLXNwYWNlcGFja2V0L2Rpc3QvaW5kZXguanMiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvLi9ub2RlX21vZHVsZXMvQHNlcmlhbHBvcnQvcGFyc2VyLXNwYWNlcGFja2V0L2Rpc3QvdXRpbHMuanMiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvLi9ub2RlX21vZHVsZXMvQHNlcmlhbHBvcnQvc3RyZWFtL2Rpc3QvaW5kZXguanMiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvLi9ub2RlX21vZHVsZXMvZGVidWcvc3JjL2Jyb3dzZXIuanMiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvLi9ub2RlX21vZHVsZXMvZGVidWcvc3JjL2NvbW1vbi5qcyIsIndlYnBhY2s6Ly9lbmNyeXB0aW9uX2RldmljZV9zZXBlaHJfbWFuYWdlbWVudC8uL25vZGVfbW9kdWxlcy9kZWJ1Zy9zcmMvaW5kZXguanMiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvLi9ub2RlX21vZHVsZXMvZGVidWcvc3JjL25vZGUuanMiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvLi9ub2RlX21vZHVsZXMvaGFzLWZsYWcvaW5kZXguanMiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvLi9ub2RlX21vZHVsZXMvbXMvaW5kZXguanMiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvLi9ub2RlX21vZHVsZXMvbm9kZS1neXAtYnVpbGQvaW5kZXguanMiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvLi9ub2RlX21vZHVsZXMvc2VyaWFscG9ydC9kaXN0L2luZGV4LmpzIiwid2VicGFjazovL2VuY3J5cHRpb25fZGV2aWNlX3NlcGVocl9tYW5hZ2VtZW50Ly4vbm9kZV9tb2R1bGVzL3NlcmlhbHBvcnQvZGlzdC9zZXJpYWxwb3J0LW1vY2suanMiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvLi9ub2RlX21vZHVsZXMvc2VyaWFscG9ydC9kaXN0L3NlcmlhbHBvcnQuanMiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvLi9ub2RlX21vZHVsZXMvc3VwcG9ydHMtY29sb3IvaW5kZXguanMiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvLi9zcmMvY29uZmlnLmpzIiwid2VicGFjazovL2VuY3J5cHRpb25fZGV2aWNlX3NlcGVocl9tYW5hZ2VtZW50Ly4vc3JjL3BlcnNvbmFsRXhjZWxBcGkuanMiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvLi9zcmMvcGVyc29uYWxIYXNoLmpzIiwid2VicGFjazovL2VuY3J5cHRpb25fZGV2aWNlX3NlcGVocl9tYW5hZ2VtZW50Ly4vc3JjL3BlcnNvbmFsU2VyaWFsUG9ydC5qcyIsIndlYnBhY2s6Ly9lbmNyeXB0aW9uX2RldmljZV9zZXBlaHJfbWFuYWdlbWVudC8uL3NyYy9wZXJzb25hbFdlYkZyYW1lLmpzIiwid2VicGFjazovL2VuY3J5cHRpb25fZGV2aWNlX3NlcGVocl9tYW5hZ2VtZW50Ly4vc3JjL3BvcFVwTWVzc2FnZS5qcyIsIndlYnBhY2s6Ly9lbmNyeXB0aW9uX2RldmljZV9zZXBlaHJfbWFuYWdlbWVudC8uL3NyYy9zZXJpYWxJbnRlcmZhY2UuanMiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvLi9zcmMvc2VyaWFsUnguanMiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvLi9zcmMvc2VyaWFsVHguanMiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvLi9zcmMvdG9vbEJveC5qcyIsIndlYnBhY2s6Ly9lbmNyeXB0aW9uX2RldmljZV9zZXBlaHJfbWFuYWdlbWVudC9leHRlcm5hbCBub2RlLWNvbW1vbmpzIFwiY2hpbGRfcHJvY2Vzc1wiIiwid2VicGFjazovL2VuY3J5cHRpb25fZGV2aWNlX3NlcGVocl9tYW5hZ2VtZW50L2V4dGVybmFsIG5vZGUtY29tbW9uanMgXCJjcnlwdG9cIiIsIndlYnBhY2s6Ly9lbmNyeXB0aW9uX2RldmljZV9zZXBlaHJfbWFuYWdlbWVudC9leHRlcm5hbCBub2RlLWNvbW1vbmpzIFwiZWxlY3Ryb25cIiIsIndlYnBhY2s6Ly9lbmNyeXB0aW9uX2RldmljZV9zZXBlaHJfbWFuYWdlbWVudC9leHRlcm5hbCBub2RlLWNvbW1vbmpzIFwiZXZlbnRzXCIiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvZXh0ZXJuYWwgbm9kZS1jb21tb25qcyBcImZzXCIiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvZXh0ZXJuYWwgbm9kZS1jb21tb25qcyBcIm9zXCIiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvZXh0ZXJuYWwgbm9kZS1jb21tb25qcyBcInBhdGhcIiIsIndlYnBhY2s6Ly9lbmNyeXB0aW9uX2RldmljZV9zZXBlaHJfbWFuYWdlbWVudC9leHRlcm5hbCBub2RlLWNvbW1vbmpzIFwic3RyZWFtXCIiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvZXh0ZXJuYWwgbm9kZS1jb21tb25qcyBcInR0eVwiIiwid2VicGFjazovL2VuY3J5cHRpb25fZGV2aWNlX3NlcGVocl9tYW5hZ2VtZW50L2V4dGVybmFsIG5vZGUtY29tbW9uanMgXCJ1dGlsXCIiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvd2VicGFjay9ib290c3RyYXAiLCJ3ZWJwYWNrOi8vZW5jcnlwdGlvbl9kZXZpY2Vfc2VwZWhyX21hbmFnZW1lbnQvLi9wcmVsb2FkLmpzIl0sInNvdXJjZXNDb250ZW50IjpbIid1c2Ugc3RyaWN0JztcblxuT2JqZWN0LmRlZmluZVByb3BlcnR5KGV4cG9ydHMsICdfX2VzTW9kdWxlJywgeyB2YWx1ZTogdHJ1ZSB9KTtcblxudmFyIGRlYnVnRmFjdG9yeSA9IHJlcXVpcmUoJ2RlYnVnJyk7XG5cbmZ1bmN0aW9uIF9pbnRlcm9wRGVmYXVsdExlZ2FjeSAoZSkgeyByZXR1cm4gZSAmJiB0eXBlb2YgZSA9PT0gJ29iamVjdCcgJiYgJ2RlZmF1bHQnIGluIGUgPyBlIDogeyAnZGVmYXVsdCc6IGUgfTsgfVxuXG52YXIgZGVidWdGYWN0b3J5X19kZWZhdWx0ID0gLyojX19QVVJFX18qL19pbnRlcm9wRGVmYXVsdExlZ2FjeShkZWJ1Z0ZhY3RvcnkpO1xuXG5jb25zdCBkZWJ1ZyA9IGRlYnVnRmFjdG9yeV9fZGVmYXVsdFtcImRlZmF1bHRcIl0oJ3NlcmlhbHBvcnQvYmluZGluZy1tb2NrJyk7XG5sZXQgcG9ydHMgPSB7fTtcbmxldCBzZXJpYWxOdW1iZXIgPSAwO1xuZnVuY3Rpb24gcmVzb2x2ZU5leHRUaWNrKCkge1xuICAgIHJldHVybiBuZXcgUHJvbWlzZShyZXNvbHZlID0+IHByb2Nlc3MubmV4dFRpY2soKCkgPT4gcmVzb2x2ZSgpKSk7XG59XG5jbGFzcyBDYW5jZWxlZEVycm9yIGV4dGVuZHMgRXJyb3Ige1xuICAgIGNvbnN0cnVjdG9yKG1lc3NhZ2UpIHtcbiAgICAgICAgc3VwZXIobWVzc2FnZSk7XG4gICAgICAgIHRoaXMuY2FuY2VsZWQgPSB0cnVlO1xuICAgIH1cbn1cbmNvbnN0IE1vY2tCaW5kaW5nID0ge1xuICAgIHJlc2V0KCkge1xuICAgICAgICBwb3J0cyA9IHt9O1xuICAgICAgICBzZXJpYWxOdW1iZXIgPSAwO1xuICAgIH0sXG4gICAgLy8gQ3JlYXRlIGEgbW9jayBwb3J0XG4gICAgY3JlYXRlUG9ydChwYXRoLCBvcHRpb25zID0ge30pIHtcbiAgICAgICAgc2VyaWFsTnVtYmVyKys7XG4gICAgICAgIGNvbnN0IG9wdFdpdGhEZWZhdWx0cyA9IE9iamVjdC5hc3NpZ24oeyBlY2hvOiBmYWxzZSwgcmVjb3JkOiBmYWxzZSwgbWFudWZhY3R1cmVyOiAnVGhlIEo1IFJvYm90aWNzIENvbXBhbnknLCB2ZW5kb3JJZDogdW5kZWZpbmVkLCBwcm9kdWN0SWQ6IHVuZGVmaW5lZCwgbWF4UmVhZFNpemU6IDEwMjQgfSwgb3B0aW9ucyk7XG4gICAgICAgIHBvcnRzW3BhdGhdID0ge1xuICAgICAgICAgICAgZGF0YTogQnVmZmVyLmFsbG9jKDApLFxuICAgICAgICAgICAgZWNobzogb3B0V2l0aERlZmF1bHRzLmVjaG8sXG4gICAgICAgICAgICByZWNvcmQ6IG9wdFdpdGhEZWZhdWx0cy5yZWNvcmQsXG4gICAgICAgICAgICByZWFkeURhdGE6IG9wdFdpdGhEZWZhdWx0cy5yZWFkeURhdGEsXG4gICAgICAgICAgICBtYXhSZWFkU2l6ZTogb3B0V2l0aERlZmF1bHRzLm1heFJlYWRTaXplLFxuICAgICAgICAgICAgaW5mbzoge1xuICAgICAgICAgICAgICAgIHBhdGgsXG4gICAgICAgICAgICAgICAgbWFudWZhY3R1cmVyOiBvcHRXaXRoRGVmYXVsdHMubWFudWZhY3R1cmVyLFxuICAgICAgICAgICAgICAgIHNlcmlhbE51bWJlcjogYCR7c2VyaWFsTnVtYmVyfWAsXG4gICAgICAgICAgICAgICAgcG5wSWQ6IHVuZGVmaW5lZCxcbiAgICAgICAgICAgICAgICBsb2NhdGlvbklkOiB1bmRlZmluZWQsXG4gICAgICAgICAgICAgICAgdmVuZG9ySWQ6IG9wdFdpdGhEZWZhdWx0cy52ZW5kb3JJZCxcbiAgICAgICAgICAgICAgICBwcm9kdWN0SWQ6IG9wdFdpdGhEZWZhdWx0cy5wcm9kdWN0SWQsXG4gICAgICAgICAgICB9LFxuICAgICAgICB9O1xuICAgICAgICBkZWJ1ZyhzZXJpYWxOdW1iZXIsICdjcmVhdGVkIHBvcnQnLCBKU09OLnN0cmluZ2lmeSh7IHBhdGgsIG9wdDogb3B0aW9ucyB9KSk7XG4gICAgfSxcbiAgICBhc3luYyBsaXN0KCkge1xuICAgICAgICBkZWJ1ZyhudWxsLCAnbGlzdCcpO1xuICAgICAgICByZXR1cm4gT2JqZWN0LnZhbHVlcyhwb3J0cykubWFwKHBvcnQgPT4gcG9ydC5pbmZvKTtcbiAgICB9LFxuICAgIGFzeW5jIG9wZW4ob3B0aW9ucykge1xuICAgICAgICB2YXIgX2E7XG4gICAgICAgIGlmICghb3B0aW9ucyB8fCB0eXBlb2Ygb3B0aW9ucyAhPT0gJ29iamVjdCcgfHwgQXJyYXkuaXNBcnJheShvcHRpb25zKSkge1xuICAgICAgICAgICAgdGhyb3cgbmV3IFR5cGVFcnJvcignXCJvcHRpb25zXCIgaXMgbm90IGFuIG9iamVjdCcpO1xuICAgICAgICB9XG4gICAgICAgIGlmICghb3B0aW9ucy5wYXRoKSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgVHlwZUVycm9yKCdcInBhdGhcIiBpcyBub3QgYSB2YWxpZCBwb3J0Jyk7XG4gICAgICAgIH1cbiAgICAgICAgaWYgKCFvcHRpb25zLmJhdWRSYXRlKSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgVHlwZUVycm9yKCdcImJhdWRSYXRlXCIgaXMgbm90IGEgdmFsaWQgYmF1ZFJhdGUnKTtcbiAgICAgICAgfVxuICAgICAgICBjb25zdCBvcGVuT3B0aW9ucyA9IE9iamVjdC5hc3NpZ24oeyBkYXRhQml0czogOCwgbG9jazogdHJ1ZSwgc3RvcEJpdHM6IDEsIHBhcml0eTogJ25vbmUnLCBydHNjdHM6IGZhbHNlLCB4b246IGZhbHNlLCB4b2ZmOiBmYWxzZSwgeGFueTogZmFsc2UsIGh1cGNsOiB0cnVlIH0sIG9wdGlvbnMpO1xuICAgICAgICBjb25zdCB7IHBhdGggfSA9IG9wZW5PcHRpb25zO1xuICAgICAgICBkZWJ1ZyhudWxsLCBgb3Blbjogb3BlbmluZyBwYXRoICR7cGF0aH1gKTtcbiAgICAgICAgY29uc3QgcG9ydCA9IHBvcnRzW3BhdGhdO1xuICAgICAgICBhd2FpdCByZXNvbHZlTmV4dFRpY2soKTtcbiAgICAgICAgaWYgKCFwb3J0KSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgRXJyb3IoYFBvcnQgZG9lcyBub3QgZXhpc3QgLSBwbGVhc2UgY2FsbCBNb2NrQmluZGluZy5jcmVhdGVQb3J0KCcke3BhdGh9JykgZmlyc3RgKTtcbiAgICAgICAgfVxuICAgICAgICBjb25zdCBzZXJpYWxOdW1iZXIgPSBwb3J0LmluZm8uc2VyaWFsTnVtYmVyO1xuICAgICAgICBpZiAoKF9hID0gcG9ydC5vcGVuT3B0KSA9PT0gbnVsbCB8fCBfYSA9PT0gdm9pZCAwID8gdm9pZCAwIDogX2EubG9jaykge1xuICAgICAgICAgICAgZGVidWcoc2VyaWFsTnVtYmVyLCAnb3BlbjogUG9ydCBpcyBsb2NrZWQgY2Fubm90IG9wZW4nKTtcbiAgICAgICAgICAgIHRocm93IG5ldyBFcnJvcignUG9ydCBpcyBsb2NrZWQgY2Fubm90IG9wZW4nKTtcbiAgICAgICAgfVxuICAgICAgICBkZWJ1ZyhzZXJpYWxOdW1iZXIsIGBvcGVuOiBvcGVuZWQgcGF0aCAke3BhdGh9YCk7XG4gICAgICAgIHBvcnQub3Blbk9wdCA9IE9iamVjdC5hc3NpZ24oe30sIG9wZW5PcHRpb25zKTtcbiAgICAgICAgcmV0dXJuIG5ldyBNb2NrUG9ydEJpbmRpbmcocG9ydCwgb3Blbk9wdGlvbnMpO1xuICAgIH0sXG59O1xuLyoqXG4gKiBNb2NrIGJpbmRpbmdzIGZvciBwcmV0ZW5kIHNlcmlhbHBvcnQgYWNjZXNzXG4gKi9cbmNsYXNzIE1vY2tQb3J0QmluZGluZyB7XG4gICAgY29uc3RydWN0b3IocG9ydCwgb3Blbk9wdGlvbnMpIHtcbiAgICAgICAgdGhpcy5wb3J0ID0gcG9ydDtcbiAgICAgICAgdGhpcy5vcGVuT3B0aW9ucyA9IG9wZW5PcHRpb25zO1xuICAgICAgICB0aGlzLnBlbmRpbmdSZWFkID0gbnVsbDtcbiAgICAgICAgdGhpcy5pc09wZW4gPSB0cnVlO1xuICAgICAgICB0aGlzLmxhc3RXcml0ZSA9IG51bGw7XG4gICAgICAgIHRoaXMucmVjb3JkaW5nID0gQnVmZmVyLmFsbG9jKDApO1xuICAgICAgICB0aGlzLndyaXRlT3BlcmF0aW9uID0gbnVsbDsgLy8gaW4gZmxpZ2h0IHByb21pc2Ugb3IgbnVsbFxuICAgICAgICB0aGlzLnNlcmlhbE51bWJlciA9IHBvcnQuaW5mby5zZXJpYWxOdW1iZXI7XG4gICAgICAgIGlmIChwb3J0LnJlYWR5RGF0YSkge1xuICAgICAgICAgICAgY29uc3QgZGF0YSA9IHBvcnQucmVhZHlEYXRhO1xuICAgICAgICAgICAgcHJvY2Vzcy5uZXh0VGljaygoKSA9PiB7XG4gICAgICAgICAgICAgICAgaWYgKHRoaXMuaXNPcGVuKSB7XG4gICAgICAgICAgICAgICAgICAgIGRlYnVnKHRoaXMuc2VyaWFsTnVtYmVyLCAnZW1pdHRpbmcgcmVhZHkgZGF0YScpO1xuICAgICAgICAgICAgICAgICAgICB0aGlzLmVtaXREYXRhKGRhdGEpO1xuICAgICAgICAgICAgICAgIH1cbiAgICAgICAgICAgIH0pO1xuICAgICAgICB9XG4gICAgfVxuICAgIC8vIEVtaXQgZGF0YSBvbiBhIG1vY2sgcG9ydFxuICAgIGVtaXREYXRhKGRhdGEpIHtcbiAgICAgICAgaWYgKCF0aGlzLmlzT3BlbiB8fCAhdGhpcy5wb3J0KSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgRXJyb3IoJ1BvcnQgbXVzdCBiZSBvcGVuIHRvIHByZXRlbmQgdG8gcmVjZWl2ZSBkYXRhJyk7XG4gICAgICAgIH1cbiAgICAgICAgY29uc3QgYnVmZmVyRGF0YSA9IEJ1ZmZlci5pc0J1ZmZlcihkYXRhKSA/IGRhdGEgOiBCdWZmZXIuZnJvbShkYXRhKTtcbiAgICAgICAgZGVidWcodGhpcy5zZXJpYWxOdW1iZXIsICdlbWl0dGluZyBkYXRhIC0gcGVuZGluZyByZWFkOicsIEJvb2xlYW4odGhpcy5wZW5kaW5nUmVhZCkpO1xuICAgICAgICB0aGlzLnBvcnQuZGF0YSA9IEJ1ZmZlci5jb25jYXQoW3RoaXMucG9ydC5kYXRhLCBidWZmZXJEYXRhXSk7XG4gICAgICAgIGlmICh0aGlzLnBlbmRpbmdSZWFkKSB7XG4gICAgICAgICAgICBwcm9jZXNzLm5leHRUaWNrKHRoaXMucGVuZGluZ1JlYWQpO1xuICAgICAgICAgICAgdGhpcy5wZW5kaW5nUmVhZCA9IG51bGw7XG4gICAgICAgIH1cbiAgICB9XG4gICAgYXN5bmMgY2xvc2UoKSB7XG4gICAgICAgIGRlYnVnKHRoaXMuc2VyaWFsTnVtYmVyLCAnY2xvc2UnKTtcbiAgICAgICAgaWYgKCF0aGlzLmlzT3Blbikge1xuICAgICAgICAgICAgdGhyb3cgbmV3IEVycm9yKCdQb3J0IGlzIG5vdCBvcGVuJyk7XG4gICAgICAgIH1cbiAgICAgICAgY29uc3QgcG9ydCA9IHRoaXMucG9ydDtcbiAgICAgICAgaWYgKCFwb3J0KSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgRXJyb3IoJ2FscmVhZHkgY2xvc2VkJyk7XG4gICAgICAgIH1cbiAgICAgICAgcG9ydC5vcGVuT3B0ID0gdW5kZWZpbmVkO1xuICAgICAgICAvLyByZXNldCBkYXRhIG9uIGNsb3NlXG4gICAgICAgIHBvcnQuZGF0YSA9IEJ1ZmZlci5hbGxvYygwKTtcbiAgICAgICAgZGVidWcodGhpcy5zZXJpYWxOdW1iZXIsICdwb3J0IGlzIGNsb3NlZCcpO1xuICAgICAgICB0aGlzLnNlcmlhbE51bWJlciA9IHVuZGVmaW5lZDtcbiAgICAgICAgdGhpcy5pc09wZW4gPSBmYWxzZTtcbiAgICAgICAgaWYgKHRoaXMucGVuZGluZ1JlYWQpIHtcbiAgICAgICAgICAgIHRoaXMucGVuZGluZ1JlYWQobmV3IENhbmNlbGVkRXJyb3IoJ3BvcnQgaXMgY2xvc2VkJykpO1xuICAgICAgICB9XG4gICAgfVxuICAgIGFzeW5jIHJlYWQoYnVmZmVyLCBvZmZzZXQsIGxlbmd0aCkge1xuICAgICAgICBpZiAoIUJ1ZmZlci5pc0J1ZmZlcihidWZmZXIpKSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgVHlwZUVycm9yKCdcImJ1ZmZlclwiIGlzIG5vdCBhIEJ1ZmZlcicpO1xuICAgICAgICB9XG4gICAgICAgIGlmICh0eXBlb2Ygb2Zmc2V0ICE9PSAnbnVtYmVyJyB8fCBpc05hTihvZmZzZXQpKSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgVHlwZUVycm9yKGBcIm9mZnNldFwiIGlzIG5vdCBhbiBpbnRlZ2VyIGdvdCBcIiR7aXNOYU4ob2Zmc2V0KSA/ICdOYU4nIDogdHlwZW9mIG9mZnNldH1cImApO1xuICAgICAgICB9XG4gICAgICAgIGlmICh0eXBlb2YgbGVuZ3RoICE9PSAnbnVtYmVyJyB8fCBpc05hTihsZW5ndGgpKSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgVHlwZUVycm9yKGBcImxlbmd0aFwiIGlzIG5vdCBhbiBpbnRlZ2VyIGdvdCBcIiR7aXNOYU4obGVuZ3RoKSA/ICdOYU4nIDogdHlwZW9mIGxlbmd0aH1cImApO1xuICAgICAgICB9XG4gICAgICAgIGlmIChidWZmZXIubGVuZ3RoIDwgb2Zmc2V0ICsgbGVuZ3RoKSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgRXJyb3IoJ2J1ZmZlciBpcyB0b28gc21hbGwnKTtcbiAgICAgICAgfVxuICAgICAgICBpZiAoIXRoaXMuaXNPcGVuKSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgRXJyb3IoJ1BvcnQgaXMgbm90IG9wZW4nKTtcbiAgICAgICAgfVxuICAgICAgICBkZWJ1Zyh0aGlzLnNlcmlhbE51bWJlciwgJ3JlYWQnLCBsZW5ndGgsICdieXRlcycpO1xuICAgICAgICBhd2FpdCByZXNvbHZlTmV4dFRpY2soKTtcbiAgICAgICAgaWYgKCF0aGlzLmlzT3BlbiB8fCAhdGhpcy5wb3J0KSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgQ2FuY2VsZWRFcnJvcignUmVhZCBjYW5jZWxlZCcpO1xuICAgICAgICB9XG4gICAgICAgIGlmICh0aGlzLnBvcnQuZGF0YS5sZW5ndGggPD0gMCkge1xuICAgICAgICAgICAgcmV0dXJuIG5ldyBQcm9taXNlKChyZXNvbHZlLCByZWplY3QpID0+IHtcbiAgICAgICAgICAgICAgICB0aGlzLnBlbmRpbmdSZWFkID0gZXJyID0+IHtcbiAgICAgICAgICAgICAgICAgICAgaWYgKGVycikge1xuICAgICAgICAgICAgICAgICAgICAgICAgcmV0dXJuIHJlamVjdChlcnIpO1xuICAgICAgICAgICAgICAgICAgICB9XG4gICAgICAgICAgICAgICAgICAgIHRoaXMucmVhZChidWZmZXIsIG9mZnNldCwgbGVuZ3RoKS50aGVuKHJlc29sdmUsIHJlamVjdCk7XG4gICAgICAgICAgICAgICAgfTtcbiAgICAgICAgICAgIH0pO1xuICAgICAgICB9XG4gICAgICAgIGNvbnN0IGxlbmd0aFRvUmVhZCA9IHRoaXMucG9ydC5tYXhSZWFkU2l6ZSA+IGxlbmd0aCA/IGxlbmd0aCA6IHRoaXMucG9ydC5tYXhSZWFkU2l6ZTtcbiAgICAgICAgY29uc3QgZGF0YSA9IHRoaXMucG9ydC5kYXRhLnNsaWNlKDAsIGxlbmd0aFRvUmVhZCk7XG4gICAgICAgIGNvbnN0IGJ5dGVzUmVhZCA9IGRhdGEuY29weShidWZmZXIsIG9mZnNldCk7XG4gICAgICAgIHRoaXMucG9ydC5kYXRhID0gdGhpcy5wb3J0LmRhdGEuc2xpY2UobGVuZ3RoVG9SZWFkKTtcbiAgICAgICAgZGVidWcodGhpcy5zZXJpYWxOdW1iZXIsICdyZWFkJywgYnl0ZXNSZWFkLCAnYnl0ZXMnKTtcbiAgICAgICAgcmV0dXJuIHsgYnl0ZXNSZWFkLCBidWZmZXIgfTtcbiAgICB9XG4gICAgYXN5bmMgd3JpdGUoYnVmZmVyKSB7XG4gICAgICAgIGlmICghQnVmZmVyLmlzQnVmZmVyKGJ1ZmZlcikpIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBUeXBlRXJyb3IoJ1wiYnVmZmVyXCIgaXMgbm90IGEgQnVmZmVyJyk7XG4gICAgICAgIH1cbiAgICAgICAgaWYgKCF0aGlzLmlzT3BlbiB8fCAhdGhpcy5wb3J0KSB7XG4gICAgICAgICAgICBkZWJ1Zygnd3JpdGUnLCAnZXJyb3IgcG9ydCBpcyBub3Qgb3BlbicpO1xuICAgICAgICAgICAgdGhyb3cgbmV3IEVycm9yKCdQb3J0IGlzIG5vdCBvcGVuJyk7XG4gICAgICAgIH1cbiAgICAgICAgZGVidWcodGhpcy5zZXJpYWxOdW1iZXIsICd3cml0ZScsIGJ1ZmZlci5sZW5ndGgsICdieXRlcycpO1xuICAgICAgICBpZiAodGhpcy53cml0ZU9wZXJhdGlvbikge1xuICAgICAgICAgICAgdGhyb3cgbmV3IEVycm9yKCdPdmVybGFwcGluZyB3cml0ZXMgYXJlIG5vdCBzdXBwb3J0ZWQgYW5kIHNob3VsZCBiZSBxdWV1ZWQgYnkgdGhlIHNlcmlhbHBvcnQgb2JqZWN0Jyk7XG4gICAgICAgIH1cbiAgICAgICAgdGhpcy53cml0ZU9wZXJhdGlvbiA9IChhc3luYyAoKSA9PiB7XG4gICAgICAgICAgICBhd2FpdCByZXNvbHZlTmV4dFRpY2soKTtcbiAgICAgICAgICAgIGlmICghdGhpcy5pc09wZW4gfHwgIXRoaXMucG9ydCkge1xuICAgICAgICAgICAgICAgIHRocm93IG5ldyBFcnJvcignV3JpdGUgY2FuY2VsZWQnKTtcbiAgICAgICAgICAgIH1cbiAgICAgICAgICAgIGNvbnN0IGRhdGEgPSAodGhpcy5sYXN0V3JpdGUgPSBCdWZmZXIuZnJvbShidWZmZXIpKTsgLy8gY29weVxuICAgICAgICAgICAgaWYgKHRoaXMucG9ydC5yZWNvcmQpIHtcbiAgICAgICAgICAgICAgICB0aGlzLnJlY29yZGluZyA9IEJ1ZmZlci5jb25jYXQoW3RoaXMucmVjb3JkaW5nLCBkYXRhXSk7XG4gICAgICAgICAgICB9XG4gICAgICAgICAgICBpZiAodGhpcy5wb3J0LmVjaG8pIHtcbiAgICAgICAgICAgICAgICBwcm9jZXNzLm5leHRUaWNrKCgpID0+IHtcbiAgICAgICAgICAgICAgICAgICAgaWYgKHRoaXMuaXNPcGVuKSB7XG4gICAgICAgICAgICAgICAgICAgICAgICB0aGlzLmVtaXREYXRhKGRhdGEpO1xuICAgICAgICAgICAgICAgICAgICB9XG4gICAgICAgICAgICAgICAgfSk7XG4gICAgICAgICAgICB9XG4gICAgICAgICAgICB0aGlzLndyaXRlT3BlcmF0aW9uID0gbnVsbDtcbiAgICAgICAgICAgIGRlYnVnKHRoaXMuc2VyaWFsTnVtYmVyLCAnd3JpdGluZyBmaW5pc2hlZCcpO1xuICAgICAgICB9KSgpO1xuICAgICAgICByZXR1cm4gdGhpcy53cml0ZU9wZXJhdGlvbjtcbiAgICB9XG4gICAgYXN5bmMgdXBkYXRlKG9wdGlvbnMpIHtcbiAgICAgICAgaWYgKHR5cGVvZiBvcHRpb25zICE9PSAnb2JqZWN0Jykge1xuICAgICAgICAgICAgdGhyb3cgVHlwZUVycm9yKCdcIm9wdGlvbnNcIiBpcyBub3QgYW4gb2JqZWN0Jyk7XG4gICAgICAgIH1cbiAgICAgICAgaWYgKHR5cGVvZiBvcHRpb25zLmJhdWRSYXRlICE9PSAnbnVtYmVyJykge1xuICAgICAgICAgICAgdGhyb3cgbmV3IFR5cGVFcnJvcignXCJvcHRpb25zLmJhdWRSYXRlXCIgaXMgbm90IGEgbnVtYmVyJyk7XG4gICAgICAgIH1cbiAgICAgICAgZGVidWcodGhpcy5zZXJpYWxOdW1iZXIsICd1cGRhdGUnKTtcbiAgICAgICAgaWYgKCF0aGlzLmlzT3BlbiB8fCAhdGhpcy5wb3J0KSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgRXJyb3IoJ1BvcnQgaXMgbm90IG9wZW4nKTtcbiAgICAgICAgfVxuICAgICAgICBhd2FpdCByZXNvbHZlTmV4dFRpY2soKTtcbiAgICAgICAgaWYgKHRoaXMucG9ydC5vcGVuT3B0KSB7XG4gICAgICAgICAgICB0aGlzLnBvcnQub3Blbk9wdC5iYXVkUmF0ZSA9IG9wdGlvbnMuYmF1ZFJhdGU7XG4gICAgICAgIH1cbiAgICB9XG4gICAgYXN5bmMgc2V0KG9wdGlvbnMpIHtcbiAgICAgICAgaWYgKHR5cGVvZiBvcHRpb25zICE9PSAnb2JqZWN0Jykge1xuICAgICAgICAgICAgdGhyb3cgbmV3IFR5cGVFcnJvcignXCJvcHRpb25zXCIgaXMgbm90IGFuIG9iamVjdCcpO1xuICAgICAgICB9XG4gICAgICAgIGRlYnVnKHRoaXMuc2VyaWFsTnVtYmVyLCAnc2V0Jyk7XG4gICAgICAgIGlmICghdGhpcy5pc09wZW4pIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBFcnJvcignUG9ydCBpcyBub3Qgb3BlbicpO1xuICAgICAgICB9XG4gICAgICAgIGF3YWl0IHJlc29sdmVOZXh0VGljaygpO1xuICAgIH1cbiAgICBhc3luYyBnZXQoKSB7XG4gICAgICAgIGRlYnVnKHRoaXMuc2VyaWFsTnVtYmVyLCAnZ2V0Jyk7XG4gICAgICAgIGlmICghdGhpcy5pc09wZW4pIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBFcnJvcignUG9ydCBpcyBub3Qgb3BlbicpO1xuICAgICAgICB9XG4gICAgICAgIGF3YWl0IHJlc29sdmVOZXh0VGljaygpO1xuICAgICAgICByZXR1cm4ge1xuICAgICAgICAgICAgY3RzOiB0cnVlLFxuICAgICAgICAgICAgZHNyOiBmYWxzZSxcbiAgICAgICAgICAgIGRjZDogZmFsc2UsXG4gICAgICAgIH07XG4gICAgfVxuICAgIGFzeW5jIGdldEJhdWRSYXRlKCkge1xuICAgICAgICB2YXIgX2E7XG4gICAgICAgIGRlYnVnKHRoaXMuc2VyaWFsTnVtYmVyLCAnZ2V0QmF1ZFJhdGUnKTtcbiAgICAgICAgaWYgKCF0aGlzLmlzT3BlbiB8fCAhdGhpcy5wb3J0KSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgRXJyb3IoJ1BvcnQgaXMgbm90IG9wZW4nKTtcbiAgICAgICAgfVxuICAgICAgICBhd2FpdCByZXNvbHZlTmV4dFRpY2soKTtcbiAgICAgICAgaWYgKCEoKF9hID0gdGhpcy5wb3J0Lm9wZW5PcHQpID09PSBudWxsIHx8IF9hID09PSB2b2lkIDAgPyB2b2lkIDAgOiBfYS5iYXVkUmF0ZSkpIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBFcnJvcignSW50ZXJuYWwgRXJyb3InKTtcbiAgICAgICAgfVxuICAgICAgICByZXR1cm4ge1xuICAgICAgICAgICAgYmF1ZFJhdGU6IHRoaXMucG9ydC5vcGVuT3B0LmJhdWRSYXRlLFxuICAgICAgICB9O1xuICAgIH1cbiAgICBhc3luYyBmbHVzaCgpIHtcbiAgICAgICAgZGVidWcodGhpcy5zZXJpYWxOdW1iZXIsICdmbHVzaCcpO1xuICAgICAgICBpZiAoIXRoaXMuaXNPcGVuIHx8ICF0aGlzLnBvcnQpIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBFcnJvcignUG9ydCBpcyBub3Qgb3BlbicpO1xuICAgICAgICB9XG4gICAgICAgIGF3YWl0IHJlc29sdmVOZXh0VGljaygpO1xuICAgICAgICB0aGlzLnBvcnQuZGF0YSA9IEJ1ZmZlci5hbGxvYygwKTtcbiAgICB9XG4gICAgYXN5bmMgZHJhaW4oKSB7XG4gICAgICAgIGRlYnVnKHRoaXMuc2VyaWFsTnVtYmVyLCAnZHJhaW4nKTtcbiAgICAgICAgaWYgKCF0aGlzLmlzT3Blbikge1xuICAgICAgICAgICAgdGhyb3cgbmV3IEVycm9yKCdQb3J0IGlzIG5vdCBvcGVuJyk7XG4gICAgICAgIH1cbiAgICAgICAgYXdhaXQgdGhpcy53cml0ZU9wZXJhdGlvbjtcbiAgICAgICAgYXdhaXQgcmVzb2x2ZU5leHRUaWNrKCk7XG4gICAgfVxufVxuXG5leHBvcnRzLkNhbmNlbGVkRXJyb3IgPSBDYW5jZWxlZEVycm9yO1xuZXhwb3J0cy5Nb2NrQmluZGluZyA9IE1vY2tCaW5kaW5nO1xuZXhwb3J0cy5Nb2NrUG9ydEJpbmRpbmcgPSBNb2NrUG9ydEJpbmRpbmc7XG4iLCJcInVzZSBzdHJpY3RcIjtcbnZhciBfX2ltcG9ydERlZmF1bHQgPSAodGhpcyAmJiB0aGlzLl9faW1wb3J0RGVmYXVsdCkgfHwgZnVuY3Rpb24gKG1vZCkge1xuICAgIHJldHVybiAobW9kICYmIG1vZC5fX2VzTW9kdWxlKSA/IG1vZCA6IHsgXCJkZWZhdWx0XCI6IG1vZCB9O1xufTtcbk9iamVjdC5kZWZpbmVQcm9wZXJ0eShleHBvcnRzLCBcIl9fZXNNb2R1bGVcIiwgeyB2YWx1ZTogdHJ1ZSB9KTtcbmV4cG9ydHMuRGFyd2luUG9ydEJpbmRpbmcgPSBleHBvcnRzLkRhcndpbkJpbmRpbmcgPSB2b2lkIDA7XG5jb25zdCBkZWJ1Z18xID0gX19pbXBvcnREZWZhdWx0KHJlcXVpcmUoXCJkZWJ1Z1wiKSk7XG5jb25zdCBsb2FkX2JpbmRpbmdzXzEgPSByZXF1aXJlKFwiLi9sb2FkLWJpbmRpbmdzXCIpO1xuY29uc3QgcG9sbGVyXzEgPSByZXF1aXJlKFwiLi9wb2xsZXJcIik7XG5jb25zdCB1bml4X3JlYWRfMSA9IHJlcXVpcmUoXCIuL3VuaXgtcmVhZFwiKTtcbmNvbnN0IHVuaXhfd3JpdGVfMSA9IHJlcXVpcmUoXCIuL3VuaXgtd3JpdGVcIik7XG5jb25zdCBkZWJ1ZyA9ICgwLCBkZWJ1Z18xLmRlZmF1bHQpKCdzZXJpYWxwb3J0L2JpbmRpbmdzLWNwcCcpO1xuZXhwb3J0cy5EYXJ3aW5CaW5kaW5nID0ge1xuICAgIGxpc3QoKSB7XG4gICAgICAgIGRlYnVnKCdsaXN0Jyk7XG4gICAgICAgIHJldHVybiAoMCwgbG9hZF9iaW5kaW5nc18xLmFzeW5jTGlzdCkoKTtcbiAgICB9LFxuICAgIGFzeW5jIG9wZW4ob3B0aW9ucykge1xuICAgICAgICBpZiAoIW9wdGlvbnMgfHwgdHlwZW9mIG9wdGlvbnMgIT09ICdvYmplY3QnIHx8IEFycmF5LmlzQXJyYXkob3B0aW9ucykpIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBUeXBlRXJyb3IoJ1wib3B0aW9uc1wiIGlzIG5vdCBhbiBvYmplY3QnKTtcbiAgICAgICAgfVxuICAgICAgICBpZiAoIW9wdGlvbnMucGF0aCkge1xuICAgICAgICAgICAgdGhyb3cgbmV3IFR5cGVFcnJvcignXCJwYXRoXCIgaXMgbm90IGEgdmFsaWQgcG9ydCcpO1xuICAgICAgICB9XG4gICAgICAgIGlmICghb3B0aW9ucy5iYXVkUmF0ZSkge1xuICAgICAgICAgICAgdGhyb3cgbmV3IFR5cGVFcnJvcignXCJiYXVkUmF0ZVwiIGlzIG5vdCBhIHZhbGlkIGJhdWRSYXRlJyk7XG4gICAgICAgIH1cbiAgICAgICAgZGVidWcoJ29wZW4nKTtcbiAgICAgICAgY29uc3Qgb3Blbk9wdGlvbnMgPSBPYmplY3QuYXNzaWduKHsgdm1pbjogMSwgdnRpbWU6IDAsIGRhdGFCaXRzOiA4LCBsb2NrOiB0cnVlLCBzdG9wQml0czogMSwgcGFyaXR5OiAnbm9uZScsIHJ0c2N0czogZmFsc2UsIHhvbjogZmFsc2UsIHhvZmY6IGZhbHNlLCB4YW55OiBmYWxzZSwgaHVwY2w6IHRydWUgfSwgb3B0aW9ucyk7XG4gICAgICAgIGNvbnN0IGZkID0gYXdhaXQgKDAsIGxvYWRfYmluZGluZ3NfMS5hc3luY09wZW4pKG9wZW5PcHRpb25zLnBhdGgsIG9wZW5PcHRpb25zKTtcbiAgICAgICAgcmV0dXJuIG5ldyBEYXJ3aW5Qb3J0QmluZGluZyhmZCwgb3Blbk9wdGlvbnMpO1xuICAgIH0sXG59O1xuLyoqXG4gKiBUaGUgRGFyd2luIGJpbmRpbmcgbGF5ZXIgZm9yIE9TWFxuICovXG5jbGFzcyBEYXJ3aW5Qb3J0QmluZGluZyB7XG4gICAgY29uc3RydWN0b3IoZmQsIG9wdGlvbnMpIHtcbiAgICAgICAgdGhpcy5mZCA9IGZkO1xuICAgICAgICB0aGlzLm9wZW5PcHRpb25zID0gb3B0aW9ucztcbiAgICAgICAgdGhpcy5wb2xsZXIgPSBuZXcgcG9sbGVyXzEuUG9sbGVyKGZkKTtcbiAgICAgICAgdGhpcy53cml0ZU9wZXJhdGlvbiA9IG51bGw7XG4gICAgfVxuICAgIGdldCBpc09wZW4oKSB7XG4gICAgICAgIHJldHVybiB0aGlzLmZkICE9PSBudWxsO1xuICAgIH1cbiAgICBhc3luYyBjbG9zZSgpIHtcbiAgICAgICAgZGVidWcoJ2Nsb3NlJyk7XG4gICAgICAgIGlmICghdGhpcy5pc09wZW4pIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBFcnJvcignUG9ydCBpcyBub3Qgb3BlbicpO1xuICAgICAgICB9XG4gICAgICAgIGNvbnN0IGZkID0gdGhpcy5mZDtcbiAgICAgICAgdGhpcy5wb2xsZXIuc3RvcCgpO1xuICAgICAgICB0aGlzLnBvbGxlci5kZXN0cm95KCk7XG4gICAgICAgIHRoaXMuZmQgPSBudWxsO1xuICAgICAgICBhd2FpdCAoMCwgbG9hZF9iaW5kaW5nc18xLmFzeW5jQ2xvc2UpKGZkKTtcbiAgICB9XG4gICAgYXN5bmMgcmVhZChidWZmZXIsIG9mZnNldCwgbGVuZ3RoKSB7XG4gICAgICAgIGlmICghQnVmZmVyLmlzQnVmZmVyKGJ1ZmZlcikpIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBUeXBlRXJyb3IoJ1wiYnVmZmVyXCIgaXMgbm90IGEgQnVmZmVyJyk7XG4gICAgICAgIH1cbiAgICAgICAgaWYgKHR5cGVvZiBvZmZzZXQgIT09ICdudW1iZXInIHx8IGlzTmFOKG9mZnNldCkpIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBUeXBlRXJyb3IoYFwib2Zmc2V0XCIgaXMgbm90IGFuIGludGVnZXIgZ290IFwiJHtpc05hTihvZmZzZXQpID8gJ05hTicgOiB0eXBlb2Ygb2Zmc2V0fVwiYCk7XG4gICAgICAgIH1cbiAgICAgICAgaWYgKHR5cGVvZiBsZW5ndGggIT09ICdudW1iZXInIHx8IGlzTmFOKGxlbmd0aCkpIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBUeXBlRXJyb3IoYFwibGVuZ3RoXCIgaXMgbm90IGFuIGludGVnZXIgZ290IFwiJHtpc05hTihsZW5ndGgpID8gJ05hTicgOiB0eXBlb2YgbGVuZ3RofVwiYCk7XG4gICAgICAgIH1cbiAgICAgICAgZGVidWcoJ3JlYWQnKTtcbiAgICAgICAgaWYgKGJ1ZmZlci5sZW5ndGggPCBvZmZzZXQgKyBsZW5ndGgpIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBFcnJvcignYnVmZmVyIGlzIHRvbyBzbWFsbCcpO1xuICAgICAgICB9XG4gICAgICAgIGlmICghdGhpcy5pc09wZW4pIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBFcnJvcignUG9ydCBpcyBub3Qgb3BlbicpO1xuICAgICAgICB9XG4gICAgICAgIHJldHVybiAoMCwgdW5peF9yZWFkXzEudW5peFJlYWQpKHsgYmluZGluZzogdGhpcywgYnVmZmVyLCBvZmZzZXQsIGxlbmd0aCB9KTtcbiAgICB9XG4gICAgYXN5bmMgd3JpdGUoYnVmZmVyKSB7XG4gICAgICAgIGlmICghQnVmZmVyLmlzQnVmZmVyKGJ1ZmZlcikpIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBUeXBlRXJyb3IoJ1wiYnVmZmVyXCIgaXMgbm90IGEgQnVmZmVyJyk7XG4gICAgICAgIH1cbiAgICAgICAgZGVidWcoJ3dyaXRlJywgYnVmZmVyLmxlbmd0aCwgJ2J5dGVzJyk7XG4gICAgICAgIGlmICghdGhpcy5pc09wZW4pIHtcbiAgICAgICAgICAgIGRlYnVnKCd3cml0ZScsICdlcnJvciBwb3J0IGlzIG5vdCBvcGVuJyk7XG4gICAgICAgICAgICB0aHJvdyBuZXcgRXJyb3IoJ1BvcnQgaXMgbm90IG9wZW4nKTtcbiAgICAgICAgfVxuICAgICAgICB0aGlzLndyaXRlT3BlcmF0aW9uID0gKGFzeW5jICgpID0+IHtcbiAgICAgICAgICAgIGlmIChidWZmZXIubGVuZ3RoID09PSAwKSB7XG4gICAgICAgICAgICAgICAgcmV0dXJuO1xuICAgICAgICAgICAgfVxuICAgICAgICAgICAgYXdhaXQgKDAsIHVuaXhfd3JpdGVfMS51bml4V3JpdGUpKHsgYmluZGluZzogdGhpcywgYnVmZmVyIH0pO1xuICAgICAgICAgICAgdGhpcy53cml0ZU9wZXJhdGlvbiA9IG51bGw7XG4gICAgICAgIH0pKCk7XG4gICAgICAgIHJldHVybiB0aGlzLndyaXRlT3BlcmF0aW9uO1xuICAgIH1cbiAgICBhc3luYyB1cGRhdGUob3B0aW9ucykge1xuICAgICAgICBpZiAoIW9wdGlvbnMgfHwgdHlwZW9mIG9wdGlvbnMgIT09ICdvYmplY3QnIHx8IEFycmF5LmlzQXJyYXkob3B0aW9ucykpIHtcbiAgICAgICAgICAgIHRocm93IFR5cGVFcnJvcignXCJvcHRpb25zXCIgaXMgbm90IGFuIG9iamVjdCcpO1xuICAgICAgICB9XG4gICAgICAgIGlmICh0eXBlb2Ygb3B0aW9ucy5iYXVkUmF0ZSAhPT0gJ251bWJlcicpIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBUeXBlRXJyb3IoJ1wib3B0aW9ucy5iYXVkUmF0ZVwiIGlzIG5vdCBhIG51bWJlcicpO1xuICAgICAgICB9XG4gICAgICAgIGRlYnVnKCd1cGRhdGUnKTtcbiAgICAgICAgaWYgKCF0aGlzLmlzT3Blbikge1xuICAgICAgICAgICAgdGhyb3cgbmV3IEVycm9yKCdQb3J0IGlzIG5vdCBvcGVuJyk7XG4gICAgICAgIH1cbiAgICAgICAgYXdhaXQgKDAsIGxvYWRfYmluZGluZ3NfMS5hc3luY1VwZGF0ZSkodGhpcy5mZCwgb3B0aW9ucyk7XG4gICAgfVxuICAgIGFzeW5jIHNldChvcHRpb25zKSB7XG4gICAgICAgIGlmICghb3B0aW9ucyB8fCB0eXBlb2Ygb3B0aW9ucyAhPT0gJ29iamVjdCcgfHwgQXJyYXkuaXNBcnJheShvcHRpb25zKSkge1xuICAgICAgICAgICAgdGhyb3cgbmV3IFR5cGVFcnJvcignXCJvcHRpb25zXCIgaXMgbm90IGFuIG9iamVjdCcpO1xuICAgICAgICB9XG4gICAgICAgIGRlYnVnKCdzZXQnLCBvcHRpb25zKTtcbiAgICAgICAgaWYgKCF0aGlzLmlzT3Blbikge1xuICAgICAgICAgICAgdGhyb3cgbmV3IEVycm9yKCdQb3J0IGlzIG5vdCBvcGVuJyk7XG4gICAgICAgIH1cbiAgICAgICAgYXdhaXQgKDAsIGxvYWRfYmluZGluZ3NfMS5hc3luY1NldCkodGhpcy5mZCwgb3B0aW9ucyk7XG4gICAgfVxuICAgIGFzeW5jIGdldCgpIHtcbiAgICAgICAgZGVidWcoJ2dldCcpO1xuICAgICAgICBpZiAoIXRoaXMuaXNPcGVuKSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgRXJyb3IoJ1BvcnQgaXMgbm90IG9wZW4nKTtcbiAgICAgICAgfVxuICAgICAgICByZXR1cm4gKDAsIGxvYWRfYmluZGluZ3NfMS5hc3luY0dldCkodGhpcy5mZCk7XG4gICAgfVxuICAgIGFzeW5jIGdldEJhdWRSYXRlKCkge1xuICAgICAgICBkZWJ1ZygnZ2V0QmF1ZFJhdGUnKTtcbiAgICAgICAgaWYgKCF0aGlzLmlzT3Blbikge1xuICAgICAgICAgICAgdGhyb3cgbmV3IEVycm9yKCdQb3J0IGlzIG5vdCBvcGVuJyk7XG4gICAgICAgIH1cbiAgICAgICAgdGhyb3cgbmV3IEVycm9yKCdnZXRCYXVkUmF0ZSBpcyBub3QgaW1wbGVtZW50ZWQgb24gZGFyd2luJyk7XG4gICAgfVxuICAgIGFzeW5jIGZsdXNoKCkge1xuICAgICAgICBkZWJ1ZygnZmx1c2gnKTtcbiAgICAgICAgaWYgKCF0aGlzLmlzT3Blbikge1xuICAgICAgICAgICAgdGhyb3cgbmV3IEVycm9yKCdQb3J0IGlzIG5vdCBvcGVuJyk7XG4gICAgICAgIH1cbiAgICAgICAgYXdhaXQgKDAsIGxvYWRfYmluZGluZ3NfMS5hc3luY0ZsdXNoKSh0aGlzLmZkKTtcbiAgICB9XG4gICAgYXN5bmMgZHJhaW4oKSB7XG4gICAgICAgIGRlYnVnKCdkcmFpbicpO1xuICAgICAgICBpZiAoIXRoaXMuaXNPcGVuKSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgRXJyb3IoJ1BvcnQgaXMgbm90IG9wZW4nKTtcbiAgICAgICAgfVxuICAgICAgICBhd2FpdCB0aGlzLndyaXRlT3BlcmF0aW9uO1xuICAgICAgICBhd2FpdCAoMCwgbG9hZF9iaW5kaW5nc18xLmFzeW5jRHJhaW4pKHRoaXMuZmQpO1xuICAgIH1cbn1cbmV4cG9ydHMuRGFyd2luUG9ydEJpbmRpbmcgPSBEYXJ3aW5Qb3J0QmluZGluZztcbiIsIlwidXNlIHN0cmljdFwiO1xuT2JqZWN0LmRlZmluZVByb3BlcnR5KGV4cG9ydHMsIFwiX19lc01vZHVsZVwiLCB7IHZhbHVlOiB0cnVlIH0pO1xuZXhwb3J0cy5CaW5kaW5nc0Vycm9yID0gdm9pZCAwO1xuY2xhc3MgQmluZGluZ3NFcnJvciBleHRlbmRzIEVycm9yIHtcbiAgICBjb25zdHJ1Y3RvcihtZXNzYWdlLCB7IGNhbmNlbGVkID0gZmFsc2UgfSA9IHt9KSB7XG4gICAgICAgIHN1cGVyKG1lc3NhZ2UpO1xuICAgICAgICB0aGlzLmNhbmNlbGVkID0gY2FuY2VsZWQ7XG4gICAgfVxufVxuZXhwb3J0cy5CaW5kaW5nc0Vycm9yID0gQmluZGluZ3NFcnJvcjtcbiIsIlwidXNlIHN0cmljdFwiO1xudmFyIF9fY3JlYXRlQmluZGluZyA9ICh0aGlzICYmIHRoaXMuX19jcmVhdGVCaW5kaW5nKSB8fCAoT2JqZWN0LmNyZWF0ZSA/IChmdW5jdGlvbihvLCBtLCBrLCBrMikge1xuICAgIGlmIChrMiA9PT0gdW5kZWZpbmVkKSBrMiA9IGs7XG4gICAgT2JqZWN0LmRlZmluZVByb3BlcnR5KG8sIGsyLCB7IGVudW1lcmFibGU6IHRydWUsIGdldDogZnVuY3Rpb24oKSB7IHJldHVybiBtW2tdOyB9IH0pO1xufSkgOiAoZnVuY3Rpb24obywgbSwgaywgazIpIHtcbiAgICBpZiAoazIgPT09IHVuZGVmaW5lZCkgazIgPSBrO1xuICAgIG9bazJdID0gbVtrXTtcbn0pKTtcbnZhciBfX2V4cG9ydFN0YXIgPSAodGhpcyAmJiB0aGlzLl9fZXhwb3J0U3RhcikgfHwgZnVuY3Rpb24obSwgZXhwb3J0cykge1xuICAgIGZvciAodmFyIHAgaW4gbSkgaWYgKHAgIT09IFwiZGVmYXVsdFwiICYmICFPYmplY3QucHJvdG90eXBlLmhhc093blByb3BlcnR5LmNhbGwoZXhwb3J0cywgcCkpIF9fY3JlYXRlQmluZGluZyhleHBvcnRzLCBtLCBwKTtcbn07XG52YXIgX19pbXBvcnREZWZhdWx0ID0gKHRoaXMgJiYgdGhpcy5fX2ltcG9ydERlZmF1bHQpIHx8IGZ1bmN0aW9uIChtb2QpIHtcbiAgICByZXR1cm4gKG1vZCAmJiBtb2QuX19lc01vZHVsZSkgPyBtb2QgOiB7IFwiZGVmYXVsdFwiOiBtb2QgfTtcbn07XG5PYmplY3QuZGVmaW5lUHJvcGVydHkoZXhwb3J0cywgXCJfX2VzTW9kdWxlXCIsIHsgdmFsdWU6IHRydWUgfSk7XG5leHBvcnRzLmF1dG9EZXRlY3QgPSB2b2lkIDA7XG4vKiBlc2xpbnQtZGlzYWJsZSBAdHlwZXNjcmlwdC1lc2xpbnQvbm8tdmFyLXJlcXVpcmVzICovXG5jb25zdCBkZWJ1Z18xID0gX19pbXBvcnREZWZhdWx0KHJlcXVpcmUoXCJkZWJ1Z1wiKSk7XG5jb25zdCBkYXJ3aW5fMSA9IHJlcXVpcmUoXCIuL2RhcndpblwiKTtcbmNvbnN0IGxpbnV4XzEgPSByZXF1aXJlKFwiLi9saW51eFwiKTtcbmNvbnN0IHdpbjMyXzEgPSByZXF1aXJlKFwiLi93aW4zMlwiKTtcbmNvbnN0IGRlYnVnID0gKDAsIGRlYnVnXzEuZGVmYXVsdCkoJ3NlcmlhbHBvcnQvYmluZGluZ3MtY3BwJyk7XG5fX2V4cG9ydFN0YXIocmVxdWlyZShcIkBzZXJpYWxwb3J0L2JpbmRpbmdzLWludGVyZmFjZVwiKSwgZXhwb3J0cyk7XG5fX2V4cG9ydFN0YXIocmVxdWlyZShcIi4vZGFyd2luXCIpLCBleHBvcnRzKTtcbl9fZXhwb3J0U3RhcihyZXF1aXJlKFwiLi9saW51eFwiKSwgZXhwb3J0cyk7XG5fX2V4cG9ydFN0YXIocmVxdWlyZShcIi4vd2luMzJcIiksIGV4cG9ydHMpO1xuX19leHBvcnRTdGFyKHJlcXVpcmUoXCIuL2Vycm9yc1wiKSwgZXhwb3J0cyk7XG4vKipcbiAqIFRoaXMgaXMgYW4gYXV0byBkZXRlY3RlZCBiaW5kaW5nIGZvciB5b3VyIGN1cnJlbnQgcGxhdGZvcm1cbiAqL1xuZnVuY3Rpb24gYXV0b0RldGVjdCgpIHtcbiAgICBzd2l0Y2ggKHByb2Nlc3MucGxhdGZvcm0pIHtcbiAgICAgICAgY2FzZSAnd2luMzInOlxuICAgICAgICAgICAgZGVidWcoJ2xvYWRpbmcgV2luZG93c0JpbmRpbmcnKTtcbiAgICAgICAgICAgIHJldHVybiB3aW4zMl8xLldpbmRvd3NCaW5kaW5nO1xuICAgICAgICBjYXNlICdkYXJ3aW4nOlxuICAgICAgICAgICAgZGVidWcoJ2xvYWRpbmcgRGFyd2luQmluZGluZycpO1xuICAgICAgICAgICAgcmV0dXJuIGRhcndpbl8xLkRhcndpbkJpbmRpbmc7XG4gICAgICAgIGRlZmF1bHQ6XG4gICAgICAgICAgICBkZWJ1ZygnbG9hZGluZyBMaW51eEJpbmRpbmcnKTtcbiAgICAgICAgICAgIHJldHVybiBsaW51eF8xLkxpbnV4QmluZGluZztcbiAgICB9XG59XG5leHBvcnRzLmF1dG9EZXRlY3QgPSBhdXRvRGV0ZWN0O1xuIiwiXCJ1c2Ugc3RyaWN0XCI7XG5PYmplY3QuZGVmaW5lUHJvcGVydHkoZXhwb3J0cywgXCJfX2VzTW9kdWxlXCIsIHsgdmFsdWU6IHRydWUgfSk7XG5leHBvcnRzLmxpbnV4TGlzdCA9IHZvaWQgMDtcbmNvbnN0IGNoaWxkX3Byb2Nlc3NfMSA9IHJlcXVpcmUoXCJjaGlsZF9wcm9jZXNzXCIpO1xuY29uc3QgcGFyc2VyX3JlYWRsaW5lXzEgPSByZXF1aXJlKFwiQHNlcmlhbHBvcnQvcGFyc2VyLXJlYWRsaW5lXCIpO1xuLy8gZ2V0IG9ubHkgc2VyaWFsIHBvcnQgbmFtZXNcbmZ1bmN0aW9uIGNoZWNrUGF0aE9mRGV2aWNlKHBhdGgpIHtcbiAgICByZXR1cm4gLyh0dHkoU3xXQ0h8QUNNfFVTQnxBTUF8TUZEfE98WFJVU0IpfHJmY29tbSkvLnRlc3QocGF0aCkgJiYgcGF0aDtcbn1cbmZ1bmN0aW9uIHByb3BOYW1lKG5hbWUpIHtcbiAgICByZXR1cm4ge1xuICAgICAgICBERVZOQU1FOiAncGF0aCcsXG4gICAgICAgIElEX1ZFTkRPUl9FTkM6ICdtYW51ZmFjdHVyZXInLFxuICAgICAgICBJRF9TRVJJQUxfU0hPUlQ6ICdzZXJpYWxOdW1iZXInLFxuICAgICAgICBJRF9WRU5ET1JfSUQ6ICd2ZW5kb3JJZCcsXG4gICAgICAgIElEX01PREVMX0lEOiAncHJvZHVjdElkJyxcbiAgICAgICAgREVWTElOS1M6ICdwbnBJZCcsXG4gICAgfVtuYW1lLnRvVXBwZXJDYXNlKCldO1xufVxuZnVuY3Rpb24gZGVjb2RlSGV4RXNjYXBlKHN0cikge1xuICAgIHJldHVybiBzdHIucmVwbGFjZSgvXFxcXHgoW2EtZkEtRjAtOV17Mn0pL2csIChhLCBiKSA9PiB7XG4gICAgICAgIHJldHVybiBTdHJpbmcuZnJvbUNoYXJDb2RlKHBhcnNlSW50KGIsIDE2KSk7XG4gICAgfSk7XG59XG5mdW5jdGlvbiBwcm9wVmFsKG5hbWUsIHZhbCkge1xuICAgIGlmIChuYW1lID09PSAncG5wSWQnKSB7XG4gICAgICAgIGNvbnN0IG1hdGNoID0gdmFsLm1hdGNoKC9cXC9ieS1pZFxcLyhbXlxcc10rKS8pO1xuICAgICAgICByZXR1cm4gKG1hdGNoID09PSBudWxsIHx8IG1hdGNoID09PSB2b2lkIDAgPyB2b2lkIDAgOiBtYXRjaFsxXSkgfHwgdW5kZWZpbmVkO1xuICAgIH1cbiAgICBpZiAobmFtZSA9PT0gJ21hbnVmYWN0dXJlcicpIHtcbiAgICAgICAgcmV0dXJuIGRlY29kZUhleEVzY2FwZSh2YWwpO1xuICAgIH1cbiAgICBpZiAoL14weC8udGVzdCh2YWwpKSB7XG4gICAgICAgIHJldHVybiB2YWwuc3Vic3RyKDIpO1xuICAgIH1cbiAgICByZXR1cm4gdmFsO1xufVxuZnVuY3Rpb24gbGludXhMaXN0KHNwYXduQ21kID0gY2hpbGRfcHJvY2Vzc18xLnNwYXduKSB7XG4gICAgY29uc3QgcG9ydHMgPSBbXTtcbiAgICBjb25zdCB1ZGV2YWRtID0gc3Bhd25DbWQoJ3VkZXZhZG0nLCBbJ2luZm8nLCAnLWUnXSk7XG4gICAgY29uc3QgbGluZXMgPSB1ZGV2YWRtLnN0ZG91dC5waXBlKG5ldyBwYXJzZXJfcmVhZGxpbmVfMS5SZWFkbGluZVBhcnNlcigpKTtcbiAgICBsZXQgc2tpcFBvcnQgPSBmYWxzZTtcbiAgICBsZXQgcG9ydCA9IHtcbiAgICAgICAgcGF0aDogJycsXG4gICAgICAgIG1hbnVmYWN0dXJlcjogdW5kZWZpbmVkLFxuICAgICAgICBzZXJpYWxOdW1iZXI6IHVuZGVmaW5lZCxcbiAgICAgICAgcG5wSWQ6IHVuZGVmaW5lZCxcbiAgICAgICAgbG9jYXRpb25JZDogdW5kZWZpbmVkLFxuICAgICAgICB2ZW5kb3JJZDogdW5kZWZpbmVkLFxuICAgICAgICBwcm9kdWN0SWQ6IHVuZGVmaW5lZCxcbiAgICB9O1xuICAgIGxpbmVzLm9uKCdkYXRhJywgKGxpbmUpID0+IHtcbiAgICAgICAgY29uc3QgbGluZVR5cGUgPSBsaW5lLnNsaWNlKDAsIDEpO1xuICAgICAgICBjb25zdCBkYXRhID0gbGluZS5zbGljZSgzKTtcbiAgICAgICAgLy8gbmV3IHBvcnQgZW50cnlcbiAgICAgICAgaWYgKGxpbmVUeXBlID09PSAnUCcpIHtcbiAgICAgICAgICAgIHBvcnQgPSB7XG4gICAgICAgICAgICAgICAgcGF0aDogJycsXG4gICAgICAgICAgICAgICAgbWFudWZhY3R1cmVyOiB1bmRlZmluZWQsXG4gICAgICAgICAgICAgICAgc2VyaWFsTnVtYmVyOiB1bmRlZmluZWQsXG4gICAgICAgICAgICAgICAgcG5wSWQ6IHVuZGVmaW5lZCxcbiAgICAgICAgICAgICAgICBsb2NhdGlvbklkOiB1bmRlZmluZWQsXG4gICAgICAgICAgICAgICAgdmVuZG9ySWQ6IHVuZGVmaW5lZCxcbiAgICAgICAgICAgICAgICBwcm9kdWN0SWQ6IHVuZGVmaW5lZCxcbiAgICAgICAgICAgIH07XG4gICAgICAgICAgICBza2lwUG9ydCA9IGZhbHNlO1xuICAgICAgICAgICAgcmV0dXJuO1xuICAgICAgICB9XG4gICAgICAgIGlmIChza2lwUG9ydCkge1xuICAgICAgICAgICAgcmV0dXJuO1xuICAgICAgICB9XG4gICAgICAgIC8vIENoZWNrIGRldiBuYW1lIGFuZCBzYXZlIHBvcnQgaWYgaXQgbWF0Y2hlcyBmbGFnIHRvIHNraXAgdGhlIHJlc3Qgb2YgdGhlIGRhdGEgaWYgbm90XG4gICAgICAgIGlmIChsaW5lVHlwZSA9PT0gJ04nKSB7XG4gICAgICAgICAgICBpZiAoY2hlY2tQYXRoT2ZEZXZpY2UoZGF0YSkpIHtcbiAgICAgICAgICAgICAgICBwb3J0cy5wdXNoKHBvcnQpO1xuICAgICAgICAgICAgfVxuICAgICAgICAgICAgZWxzZSB7XG4gICAgICAgICAgICAgICAgc2tpcFBvcnQgPSB0cnVlO1xuICAgICAgICAgICAgfVxuICAgICAgICAgICAgcmV0dXJuO1xuICAgICAgICB9XG4gICAgICAgIC8vIHBhcnNlIGRhdGEgYWJvdXQgZWFjaCBwb3J0XG4gICAgICAgIGlmIChsaW5lVHlwZSA9PT0gJ0UnKSB7XG4gICAgICAgICAgICBjb25zdCBrZXlWYWx1ZSA9IGRhdGEubWF0Y2goL14oLispPSguKikvKTtcbiAgICAgICAgICAgIGlmICgha2V5VmFsdWUpIHtcbiAgICAgICAgICAgICAgICByZXR1cm47XG4gICAgICAgICAgICB9XG4gICAgICAgICAgICBjb25zdCBrZXkgPSBwcm9wTmFtZShrZXlWYWx1ZVsxXSk7XG4gICAgICAgICAgICBpZiAoIWtleSkge1xuICAgICAgICAgICAgICAgIHJldHVybjtcbiAgICAgICAgICAgIH1cbiAgICAgICAgICAgIHBvcnRba2V5XSA9IHByb3BWYWwoa2V5LCBrZXlWYWx1ZVsyXSk7XG4gICAgICAgIH1cbiAgICB9KTtcbiAgICByZXR1cm4gbmV3IFByb21pc2UoKHJlc29sdmUsIHJlamVjdCkgPT4ge1xuICAgICAgICB1ZGV2YWRtLm9uKCdjbG9zZScsIChjb2RlKSA9PiB7XG4gICAgICAgICAgICBpZiAoY29kZSkge1xuICAgICAgICAgICAgICAgIHJlamVjdChuZXcgRXJyb3IoYEVycm9yIGxpc3RpbmcgcG9ydHMgdWRldmFkbSBleGl0ZWQgd2l0aCBlcnJvciBjb2RlOiAke2NvZGV9YCkpO1xuICAgICAgICAgICAgfVxuICAgICAgICB9KTtcbiAgICAgICAgdWRldmFkbS5vbignZXJyb3InLCByZWplY3QpO1xuICAgICAgICBsaW5lcy5vbignZXJyb3InLCByZWplY3QpO1xuICAgICAgICBsaW5lcy5vbignZmluaXNoJywgKCkgPT4gcmVzb2x2ZShwb3J0cykpO1xuICAgIH0pO1xufVxuZXhwb3J0cy5saW51eExpc3QgPSBsaW51eExpc3Q7XG4iLCJcInVzZSBzdHJpY3RcIjtcbnZhciBfX2ltcG9ydERlZmF1bHQgPSAodGhpcyAmJiB0aGlzLl9faW1wb3J0RGVmYXVsdCkgfHwgZnVuY3Rpb24gKG1vZCkge1xuICAgIHJldHVybiAobW9kICYmIG1vZC5fX2VzTW9kdWxlKSA/IG1vZCA6IHsgXCJkZWZhdWx0XCI6IG1vZCB9O1xufTtcbk9iamVjdC5kZWZpbmVQcm9wZXJ0eShleHBvcnRzLCBcIl9fZXNNb2R1bGVcIiwgeyB2YWx1ZTogdHJ1ZSB9KTtcbmV4cG9ydHMuTGludXhQb3J0QmluZGluZyA9IGV4cG9ydHMuTGludXhCaW5kaW5nID0gdm9pZCAwO1xuY29uc3QgZGVidWdfMSA9IF9faW1wb3J0RGVmYXVsdChyZXF1aXJlKFwiZGVidWdcIikpO1xuY29uc3QgbGludXhfbGlzdF8xID0gcmVxdWlyZShcIi4vbGludXgtbGlzdFwiKTtcbmNvbnN0IHBvbGxlcl8xID0gcmVxdWlyZShcIi4vcG9sbGVyXCIpO1xuY29uc3QgdW5peF9yZWFkXzEgPSByZXF1aXJlKFwiLi91bml4LXJlYWRcIik7XG5jb25zdCB1bml4X3dyaXRlXzEgPSByZXF1aXJlKFwiLi91bml4LXdyaXRlXCIpO1xuY29uc3QgbG9hZF9iaW5kaW5nc18xID0gcmVxdWlyZShcIi4vbG9hZC1iaW5kaW5nc1wiKTtcbmNvbnN0IGRlYnVnID0gKDAsIGRlYnVnXzEuZGVmYXVsdCkoJ3NlcmlhbHBvcnQvYmluZGluZ3MtY3BwJyk7XG5leHBvcnRzLkxpbnV4QmluZGluZyA9IHtcbiAgICBsaXN0KCkge1xuICAgICAgICBkZWJ1ZygnbGlzdCcpO1xuICAgICAgICByZXR1cm4gKDAsIGxpbnV4X2xpc3RfMS5saW51eExpc3QpKCk7XG4gICAgfSxcbiAgICBhc3luYyBvcGVuKG9wdGlvbnMpIHtcbiAgICAgICAgaWYgKCFvcHRpb25zIHx8IHR5cGVvZiBvcHRpb25zICE9PSAnb2JqZWN0JyB8fCBBcnJheS5pc0FycmF5KG9wdGlvbnMpKSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgVHlwZUVycm9yKCdcIm9wdGlvbnNcIiBpcyBub3QgYW4gb2JqZWN0Jyk7XG4gICAgICAgIH1cbiAgICAgICAgaWYgKCFvcHRpb25zLnBhdGgpIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBUeXBlRXJyb3IoJ1wicGF0aFwiIGlzIG5vdCBhIHZhbGlkIHBvcnQnKTtcbiAgICAgICAgfVxuICAgICAgICBpZiAoIW9wdGlvbnMuYmF1ZFJhdGUpIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBUeXBlRXJyb3IoJ1wiYmF1ZFJhdGVcIiBpcyBub3QgYSB2YWxpZCBiYXVkUmF0ZScpO1xuICAgICAgICB9XG4gICAgICAgIGRlYnVnKCdvcGVuJyk7XG4gICAgICAgIGNvbnN0IG9wZW5PcHRpb25zID0gT2JqZWN0LmFzc2lnbih7IHZtaW46IDEsIHZ0aW1lOiAwLCBkYXRhQml0czogOCwgbG9jazogdHJ1ZSwgc3RvcEJpdHM6IDEsIHBhcml0eTogJ25vbmUnLCBydHNjdHM6IGZhbHNlLCB4b246IGZhbHNlLCB4b2ZmOiBmYWxzZSwgeGFueTogZmFsc2UsIGh1cGNsOiB0cnVlIH0sIG9wdGlvbnMpO1xuICAgICAgICBjb25zdCBmZCA9IGF3YWl0ICgwLCBsb2FkX2JpbmRpbmdzXzEuYXN5bmNPcGVuKShvcGVuT3B0aW9ucy5wYXRoLCBvcGVuT3B0aW9ucyk7XG4gICAgICAgIHRoaXMuZmQgPSBmZDtcbiAgICAgICAgcmV0dXJuIG5ldyBMaW51eFBvcnRCaW5kaW5nKGZkLCBvcGVuT3B0aW9ucyk7XG4gICAgfSxcbn07XG4vKipcbiAqIFRoZSBsaW51eCBiaW5kaW5nIGxheWVyXG4gKi9cbmNsYXNzIExpbnV4UG9ydEJpbmRpbmcge1xuICAgIGNvbnN0cnVjdG9yKGZkLCBvcGVuT3B0aW9ucykge1xuICAgICAgICB0aGlzLmZkID0gZmQ7XG4gICAgICAgIHRoaXMub3Blbk9wdGlvbnMgPSBvcGVuT3B0aW9ucztcbiAgICAgICAgdGhpcy5wb2xsZXIgPSBuZXcgcG9sbGVyXzEuUG9sbGVyKGZkKTtcbiAgICAgICAgdGhpcy53cml0ZU9wZXJhdGlvbiA9IG51bGw7XG4gICAgfVxuICAgIGdldCBpc09wZW4oKSB7XG4gICAgICAgIHJldHVybiB0aGlzLmZkICE9PSBudWxsO1xuICAgIH1cbiAgICBhc3luYyBjbG9zZSgpIHtcbiAgICAgICAgZGVidWcoJ2Nsb3NlJyk7XG4gICAgICAgIGlmICghdGhpcy5pc09wZW4pIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBFcnJvcignUG9ydCBpcyBub3Qgb3BlbicpO1xuICAgICAgICB9XG4gICAgICAgIGNvbnN0IGZkID0gdGhpcy5mZDtcbiAgICAgICAgdGhpcy5wb2xsZXIuc3RvcCgpO1xuICAgICAgICB0aGlzLnBvbGxlci5kZXN0cm95KCk7XG4gICAgICAgIHRoaXMuZmQgPSBudWxsO1xuICAgICAgICBhd2FpdCAoMCwgbG9hZF9iaW5kaW5nc18xLmFzeW5jQ2xvc2UpKGZkKTtcbiAgICB9XG4gICAgYXN5bmMgcmVhZChidWZmZXIsIG9mZnNldCwgbGVuZ3RoKSB7XG4gICAgICAgIGlmICghQnVmZmVyLmlzQnVmZmVyKGJ1ZmZlcikpIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBUeXBlRXJyb3IoJ1wiYnVmZmVyXCIgaXMgbm90IGEgQnVmZmVyJyk7XG4gICAgICAgIH1cbiAgICAgICAgaWYgKHR5cGVvZiBvZmZzZXQgIT09ICdudW1iZXInIHx8IGlzTmFOKG9mZnNldCkpIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBUeXBlRXJyb3IoYFwib2Zmc2V0XCIgaXMgbm90IGFuIGludGVnZXIgZ290IFwiJHtpc05hTihvZmZzZXQpID8gJ05hTicgOiB0eXBlb2Ygb2Zmc2V0fVwiYCk7XG4gICAgICAgIH1cbiAgICAgICAgaWYgKHR5cGVvZiBsZW5ndGggIT09ICdudW1iZXInIHx8IGlzTmFOKGxlbmd0aCkpIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBUeXBlRXJyb3IoYFwibGVuZ3RoXCIgaXMgbm90IGFuIGludGVnZXIgZ290IFwiJHtpc05hTihsZW5ndGgpID8gJ05hTicgOiB0eXBlb2YgbGVuZ3RofVwiYCk7XG4gICAgICAgIH1cbiAgICAgICAgZGVidWcoJ3JlYWQnKTtcbiAgICAgICAgaWYgKGJ1ZmZlci5sZW5ndGggPCBvZmZzZXQgKyBsZW5ndGgpIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBFcnJvcignYnVmZmVyIGlzIHRvbyBzbWFsbCcpO1xuICAgICAgICB9XG4gICAgICAgIGlmICghdGhpcy5pc09wZW4pIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBFcnJvcignUG9ydCBpcyBub3Qgb3BlbicpO1xuICAgICAgICB9XG4gICAgICAgIHJldHVybiAoMCwgdW5peF9yZWFkXzEudW5peFJlYWQpKHsgYmluZGluZzogdGhpcywgYnVmZmVyLCBvZmZzZXQsIGxlbmd0aCB9KTtcbiAgICB9XG4gICAgYXN5bmMgd3JpdGUoYnVmZmVyKSB7XG4gICAgICAgIGlmICghQnVmZmVyLmlzQnVmZmVyKGJ1ZmZlcikpIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBUeXBlRXJyb3IoJ1wiYnVmZmVyXCIgaXMgbm90IGEgQnVmZmVyJyk7XG4gICAgICAgIH1cbiAgICAgICAgZGVidWcoJ3dyaXRlJywgYnVmZmVyLmxlbmd0aCwgJ2J5dGVzJyk7XG4gICAgICAgIGlmICghdGhpcy5pc09wZW4pIHtcbiAgICAgICAgICAgIGRlYnVnKCd3cml0ZScsICdlcnJvciBwb3J0IGlzIG5vdCBvcGVuJyk7XG4gICAgICAgICAgICB0aHJvdyBuZXcgRXJyb3IoJ1BvcnQgaXMgbm90IG9wZW4nKTtcbiAgICAgICAgfVxuICAgICAgICB0aGlzLndyaXRlT3BlcmF0aW9uID0gKGFzeW5jICgpID0+IHtcbiAgICAgICAgICAgIGlmIChidWZmZXIubGVuZ3RoID09PSAwKSB7XG4gICAgICAgICAgICAgICAgcmV0dXJuO1xuICAgICAgICAgICAgfVxuICAgICAgICAgICAgYXdhaXQgKDAsIHVuaXhfd3JpdGVfMS51bml4V3JpdGUpKHsgYmluZGluZzogdGhpcywgYnVmZmVyIH0pO1xuICAgICAgICAgICAgdGhpcy53cml0ZU9wZXJhdGlvbiA9IG51bGw7XG4gICAgICAgIH0pKCk7XG4gICAgICAgIHJldHVybiB0aGlzLndyaXRlT3BlcmF0aW9uO1xuICAgIH1cbiAgICBhc3luYyB1cGRhdGUob3B0aW9ucykge1xuICAgICAgICBpZiAoIW9wdGlvbnMgfHwgdHlwZW9mIG9wdGlvbnMgIT09ICdvYmplY3QnIHx8IEFycmF5LmlzQXJyYXkob3B0aW9ucykpIHtcbiAgICAgICAgICAgIHRocm93IFR5cGVFcnJvcignXCJvcHRpb25zXCIgaXMgbm90IGFuIG9iamVjdCcpO1xuICAgICAgICB9XG4gICAgICAgIGlmICh0eXBlb2Ygb3B0aW9ucy5iYXVkUmF0ZSAhPT0gJ251bWJlcicpIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBUeXBlRXJyb3IoJ1wib3B0aW9ucy5iYXVkUmF0ZVwiIGlzIG5vdCBhIG51bWJlcicpO1xuICAgICAgICB9XG4gICAgICAgIGRlYnVnKCd1cGRhdGUnKTtcbiAgICAgICAgaWYgKCF0aGlzLmlzT3Blbikge1xuICAgICAgICAgICAgdGhyb3cgbmV3IEVycm9yKCdQb3J0IGlzIG5vdCBvcGVuJyk7XG4gICAgICAgIH1cbiAgICAgICAgYXdhaXQgKDAsIGxvYWRfYmluZGluZ3NfMS5hc3luY1VwZGF0ZSkodGhpcy5mZCwgb3B0aW9ucyk7XG4gICAgfVxuICAgIGFzeW5jIHNldChvcHRpb25zKSB7XG4gICAgICAgIGlmICghb3B0aW9ucyB8fCB0eXBlb2Ygb3B0aW9ucyAhPT0gJ29iamVjdCcgfHwgQXJyYXkuaXNBcnJheShvcHRpb25zKSkge1xuICAgICAgICAgICAgdGhyb3cgbmV3IFR5cGVFcnJvcignXCJvcHRpb25zXCIgaXMgbm90IGFuIG9iamVjdCcpO1xuICAgICAgICB9XG4gICAgICAgIGRlYnVnKCdzZXQnKTtcbiAgICAgICAgaWYgKCF0aGlzLmlzT3Blbikge1xuICAgICAgICAgICAgdGhyb3cgbmV3IEVycm9yKCdQb3J0IGlzIG5vdCBvcGVuJyk7XG4gICAgICAgIH1cbiAgICAgICAgYXdhaXQgKDAsIGxvYWRfYmluZGluZ3NfMS5hc3luY1NldCkodGhpcy5mZCwgb3B0aW9ucyk7XG4gICAgfVxuICAgIGFzeW5jIGdldCgpIHtcbiAgICAgICAgZGVidWcoJ2dldCcpO1xuICAgICAgICBpZiAoIXRoaXMuaXNPcGVuKSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgRXJyb3IoJ1BvcnQgaXMgbm90IG9wZW4nKTtcbiAgICAgICAgfVxuICAgICAgICByZXR1cm4gKDAsIGxvYWRfYmluZGluZ3NfMS5hc3luY0dldCkodGhpcy5mZCk7XG4gICAgfVxuICAgIGFzeW5jIGdldEJhdWRSYXRlKCkge1xuICAgICAgICBkZWJ1ZygnZ2V0QmF1ZFJhdGUnKTtcbiAgICAgICAgaWYgKCF0aGlzLmlzT3Blbikge1xuICAgICAgICAgICAgdGhyb3cgbmV3IEVycm9yKCdQb3J0IGlzIG5vdCBvcGVuJyk7XG4gICAgICAgIH1cbiAgICAgICAgcmV0dXJuICgwLCBsb2FkX2JpbmRpbmdzXzEuYXN5bmNHZXRCYXVkUmF0ZSkodGhpcy5mZCk7XG4gICAgfVxuICAgIGFzeW5jIGZsdXNoKCkge1xuICAgICAgICBkZWJ1ZygnZmx1c2gnKTtcbiAgICAgICAgaWYgKCF0aGlzLmlzT3Blbikge1xuICAgICAgICAgICAgdGhyb3cgbmV3IEVycm9yKCdQb3J0IGlzIG5vdCBvcGVuJyk7XG4gICAgICAgIH1cbiAgICAgICAgYXdhaXQgKDAsIGxvYWRfYmluZGluZ3NfMS5hc3luY0ZsdXNoKSh0aGlzLmZkKTtcbiAgICB9XG4gICAgYXN5bmMgZHJhaW4oKSB7XG4gICAgICAgIGRlYnVnKCdkcmFpbicpO1xuICAgICAgICBpZiAoIXRoaXMuaXNPcGVuKSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgRXJyb3IoJ1BvcnQgaXMgbm90IG9wZW4nKTtcbiAgICAgICAgfVxuICAgICAgICBhd2FpdCB0aGlzLndyaXRlT3BlcmF0aW9uO1xuICAgICAgICBhd2FpdCAoMCwgbG9hZF9iaW5kaW5nc18xLmFzeW5jRHJhaW4pKHRoaXMuZmQpO1xuICAgIH1cbn1cbmV4cG9ydHMuTGludXhQb3J0QmluZGluZyA9IExpbnV4UG9ydEJpbmRpbmc7XG4iLCJcInVzZSBzdHJpY3RcIjtcbnZhciBfX2ltcG9ydERlZmF1bHQgPSAodGhpcyAmJiB0aGlzLl9faW1wb3J0RGVmYXVsdCkgfHwgZnVuY3Rpb24gKG1vZCkge1xuICAgIHJldHVybiAobW9kICYmIG1vZC5fX2VzTW9kdWxlKSA/IG1vZCA6IHsgXCJkZWZhdWx0XCI6IG1vZCB9O1xufTtcbk9iamVjdC5kZWZpbmVQcm9wZXJ0eShleHBvcnRzLCBcIl9fZXNNb2R1bGVcIiwgeyB2YWx1ZTogdHJ1ZSB9KTtcbmV4cG9ydHMuYXN5bmNXcml0ZSA9IGV4cG9ydHMuYXN5bmNSZWFkID0gZXhwb3J0cy5hc3luY1VwZGF0ZSA9IGV4cG9ydHMuYXN5bmNTZXQgPSBleHBvcnRzLmFzeW5jT3BlbiA9IGV4cG9ydHMuYXN5bmNMaXN0ID0gZXhwb3J0cy5hc3luY0dldEJhdWRSYXRlID0gZXhwb3J0cy5hc3luY0dldCA9IGV4cG9ydHMuYXN5bmNGbHVzaCA9IGV4cG9ydHMuYXN5bmNEcmFpbiA9IGV4cG9ydHMuYXN5bmNDbG9zZSA9IHZvaWQgMDtcbmNvbnN0IG5vZGVfZ3lwX2J1aWxkXzEgPSBfX2ltcG9ydERlZmF1bHQocmVxdWlyZShcIm5vZGUtZ3lwLWJ1aWxkXCIpKTtcbmNvbnN0IHV0aWxfMSA9IHJlcXVpcmUoXCJ1dGlsXCIpO1xuY29uc3QgcGF0aF8xID0gcmVxdWlyZShcInBhdGhcIik7XG5jb25zdCBiaW5kaW5nID0gKDAsIG5vZGVfZ3lwX2J1aWxkXzEuZGVmYXVsdCkoKDAsIHBhdGhfMS5qb2luKShfX2Rpcm5hbWUsICcuLi8nKSk7XG5leHBvcnRzLmFzeW5jQ2xvc2UgPSBiaW5kaW5nLmNsb3NlID8gKDAsIHV0aWxfMS5wcm9taXNpZnkpKGJpbmRpbmcuY2xvc2UpIDogYXN5bmMgKCkgPT4geyB0aHJvdyBuZXcgRXJyb3IoJ1wiYmluZGluZy5jbG9zZVwiIE1ldGhvZCBub3QgaW1wbGVtZW50ZWQnKTsgfTtcbmV4cG9ydHMuYXN5bmNEcmFpbiA9IGJpbmRpbmcuZHJhaW4gPyAoMCwgdXRpbF8xLnByb21pc2lmeSkoYmluZGluZy5kcmFpbikgOiBhc3luYyAoKSA9PiB7IHRocm93IG5ldyBFcnJvcignXCJiaW5kaW5nLmRyYWluXCIgTWV0aG9kIG5vdCBpbXBsZW1lbnRlZCcpOyB9O1xuZXhwb3J0cy5hc3luY0ZsdXNoID0gYmluZGluZy5mbHVzaCA/ICgwLCB1dGlsXzEucHJvbWlzaWZ5KShiaW5kaW5nLmZsdXNoKSA6IGFzeW5jICgpID0+IHsgdGhyb3cgbmV3IEVycm9yKCdcImJpbmRpbmcuZmx1c2hcIiBNZXRob2Qgbm90IGltcGxlbWVudGVkJyk7IH07XG5leHBvcnRzLmFzeW5jR2V0ID0gYmluZGluZy5nZXQgPyAoMCwgdXRpbF8xLnByb21pc2lmeSkoYmluZGluZy5nZXQpIDogYXN5bmMgKCkgPT4geyB0aHJvdyBuZXcgRXJyb3IoJ1wiYmluZGluZy5nZXRcIiBNZXRob2Qgbm90IGltcGxlbWVudGVkJyk7IH07XG5leHBvcnRzLmFzeW5jR2V0QmF1ZFJhdGUgPSBiaW5kaW5nLmdldEJhdWRSYXRlID8gKDAsIHV0aWxfMS5wcm9taXNpZnkpKGJpbmRpbmcuZ2V0QmF1ZFJhdGUpIDogYXN5bmMgKCkgPT4geyB0aHJvdyBuZXcgRXJyb3IoJ1wiYmluZGluZy5nZXRCYXVkUmF0ZVwiIE1ldGhvZCBub3QgaW1wbGVtZW50ZWQnKTsgfTtcbmV4cG9ydHMuYXN5bmNMaXN0ID0gYmluZGluZy5saXN0ID8gKDAsIHV0aWxfMS5wcm9taXNpZnkpKGJpbmRpbmcubGlzdCkgOiBhc3luYyAoKSA9PiB7IHRocm93IG5ldyBFcnJvcignXCJiaW5kaW5nLmxpc3RcIiBNZXRob2Qgbm90IGltcGxlbWVudGVkJyk7IH07XG5leHBvcnRzLmFzeW5jT3BlbiA9IGJpbmRpbmcub3BlbiA/ICgwLCB1dGlsXzEucHJvbWlzaWZ5KShiaW5kaW5nLm9wZW4pIDogYXN5bmMgKCkgPT4geyB0aHJvdyBuZXcgRXJyb3IoJ1wiYmluZGluZy5vcGVuXCIgTWV0aG9kIG5vdCBpbXBsZW1lbnRlZCcpOyB9O1xuZXhwb3J0cy5hc3luY1NldCA9IGJpbmRpbmcuc2V0ID8gKDAsIHV0aWxfMS5wcm9taXNpZnkpKGJpbmRpbmcuc2V0KSA6IGFzeW5jICgpID0+IHsgdGhyb3cgbmV3IEVycm9yKCdcImJpbmRpbmcuc2V0XCIgTWV0aG9kIG5vdCBpbXBsZW1lbnRlZCcpOyB9O1xuZXhwb3J0cy5hc3luY1VwZGF0ZSA9IGJpbmRpbmcudXBkYXRlID8gKDAsIHV0aWxfMS5wcm9taXNpZnkpKGJpbmRpbmcudXBkYXRlKSA6IGFzeW5jICgpID0+IHsgdGhyb3cgbmV3IEVycm9yKCdcImJpbmRpbmcudXBkYXRlXCIgTWV0aG9kIG5vdCBpbXBsZW1lbnRlZCcpOyB9O1xuZXhwb3J0cy5hc3luY1JlYWQgPSBiaW5kaW5nLnJlYWQgPyAoMCwgdXRpbF8xLnByb21pc2lmeSkoYmluZGluZy5yZWFkKSA6IGFzeW5jICgpID0+IHsgdGhyb3cgbmV3IEVycm9yKCdcImJpbmRpbmcucmVhZFwiIE1ldGhvZCBub3QgaW1wbGVtZW50ZWQnKTsgfTtcbmV4cG9ydHMuYXN5bmNXcml0ZSA9IGJpbmRpbmcucmVhZCA/ICgwLCB1dGlsXzEucHJvbWlzaWZ5KShiaW5kaW5nLndyaXRlKSA6IGFzeW5jICgpID0+IHsgdGhyb3cgbmV3IEVycm9yKCdcImJpbmRpbmcud3JpdGVcIiBNZXRob2Qgbm90IGltcGxlbWVudGVkJyk7IH07XG4iLCJcInVzZSBzdHJpY3RcIjtcbnZhciBfX2ltcG9ydERlZmF1bHQgPSAodGhpcyAmJiB0aGlzLl9faW1wb3J0RGVmYXVsdCkgfHwgZnVuY3Rpb24gKG1vZCkge1xuICAgIHJldHVybiAobW9kICYmIG1vZC5fX2VzTW9kdWxlKSA/IG1vZCA6IHsgXCJkZWZhdWx0XCI6IG1vZCB9O1xufTtcbk9iamVjdC5kZWZpbmVQcm9wZXJ0eShleHBvcnRzLCBcIl9fZXNNb2R1bGVcIiwgeyB2YWx1ZTogdHJ1ZSB9KTtcbmV4cG9ydHMuUG9sbGVyID0gZXhwb3J0cy5FVkVOVFMgPSB2b2lkIDA7XG5jb25zdCBkZWJ1Z18xID0gX19pbXBvcnREZWZhdWx0KHJlcXVpcmUoXCJkZWJ1Z1wiKSk7XG5jb25zdCBldmVudHNfMSA9IHJlcXVpcmUoXCJldmVudHNcIik7XG5jb25zdCBwYXRoXzEgPSByZXF1aXJlKFwicGF0aFwiKTtcbmNvbnN0IG5vZGVfZ3lwX2J1aWxkXzEgPSBfX2ltcG9ydERlZmF1bHQocmVxdWlyZShcIm5vZGUtZ3lwLWJ1aWxkXCIpKTtcbmNvbnN0IGVycm9yc18xID0gcmVxdWlyZShcIi4vZXJyb3JzXCIpO1xuY29uc3QgeyBQb2xsZXI6IFBvbGxlckJpbmRpbmdzIH0gPSAoMCwgbm9kZV9neXBfYnVpbGRfMS5kZWZhdWx0KSgoMCwgcGF0aF8xLmpvaW4pKF9fZGlybmFtZSwgJy4uLycpKTtcbmNvbnN0IGxvZ2dlciA9ICgwLCBkZWJ1Z18xLmRlZmF1bHQpKCdzZXJpYWxwb3J0L2JpbmRpbmdzLWNwcC9wb2xsZXInKTtcbmV4cG9ydHMuRVZFTlRTID0ge1xuICAgIFVWX1JFQURBQkxFOiAwYjAwMDEsXG4gICAgVVZfV1JJVEFCTEU6IDBiMDAxMCxcbiAgICBVVl9ESVNDT05ORUNUOiAwYjAxMDAsXG59O1xuZnVuY3Rpb24gaGFuZGxlRXZlbnQoZXJyb3IsIGV2ZW50RmxhZykge1xuICAgIGlmIChlcnJvcikge1xuICAgICAgICBsb2dnZXIoJ2Vycm9yJywgZXJyb3IpO1xuICAgICAgICB0aGlzLmVtaXQoJ3JlYWRhYmxlJywgZXJyb3IpO1xuICAgICAgICB0aGlzLmVtaXQoJ3dyaXRhYmxlJywgZXJyb3IpO1xuICAgICAgICB0aGlzLmVtaXQoJ2Rpc2Nvbm5lY3QnLCBlcnJvcik7XG4gICAgICAgIHJldHVybjtcbiAgICB9XG4gICAgaWYgKGV2ZW50RmxhZyAmIGV4cG9ydHMuRVZFTlRTLlVWX1JFQURBQkxFKSB7XG4gICAgICAgIGxvZ2dlcigncmVjZWl2ZWQgXCJyZWFkYWJsZVwiJyk7XG4gICAgICAgIHRoaXMuZW1pdCgncmVhZGFibGUnLCBudWxsKTtcbiAgICB9XG4gICAgaWYgKGV2ZW50RmxhZyAmIGV4cG9ydHMuRVZFTlRTLlVWX1dSSVRBQkxFKSB7XG4gICAgICAgIGxvZ2dlcigncmVjZWl2ZWQgXCJ3cml0YWJsZVwiJyk7XG4gICAgICAgIHRoaXMuZW1pdCgnd3JpdGFibGUnLCBudWxsKTtcbiAgICB9XG4gICAgaWYgKGV2ZW50RmxhZyAmIGV4cG9ydHMuRVZFTlRTLlVWX0RJU0NPTk5FQ1QpIHtcbiAgICAgICAgbG9nZ2VyKCdyZWNlaXZlZCBcImRpc2Nvbm5lY3RcIicpO1xuICAgICAgICB0aGlzLmVtaXQoJ2Rpc2Nvbm5lY3QnLCBudWxsKTtcbiAgICB9XG59XG4vKipcbiAqIFBvbGxzIHVuaXggc3lzdGVtcyBmb3IgcmVhZGFibGUgb3Igd3JpdGFibGUgc3RhdGVzIG9mIGEgZmlsZSBvciBzZXJpYWxwb3J0XG4gKi9cbmNsYXNzIFBvbGxlciBleHRlbmRzIGV2ZW50c18xLkV2ZW50RW1pdHRlciB7XG4gICAgY29uc3RydWN0b3IoZmQsIEZEUG9sbGVyID0gUG9sbGVyQmluZGluZ3MpIHtcbiAgICAgICAgbG9nZ2VyKCdDcmVhdGluZyBwb2xsZXInKTtcbiAgICAgICAgc3VwZXIoKTtcbiAgICAgICAgdGhpcy5wb2xsZXIgPSBuZXcgRkRQb2xsZXIoZmQsIGhhbmRsZUV2ZW50LmJpbmQodGhpcykpO1xuICAgIH1cbiAgICAvKipcbiAgICAgKiBXYWl0IGZvciB0aGUgbmV4dCBldmVudCB0byBvY2N1clxuICAgICAqIEBwYXJhbSB7c3RyaW5nfSBldmVudCAoJ3JlYWRhYmxlJ3wnd3JpdGFibGUnfCdkaXNjb25uZWN0JylcbiAgICAgKiBAcmV0dXJucyB7UG9sbGVyfSByZXR1cm5zIGl0c2VsZlxuICAgICAqL1xuICAgIG9uY2UoZXZlbnQsIGNhbGxiYWNrKSB7XG4gICAgICAgIHN3aXRjaCAoZXZlbnQpIHtcbiAgICAgICAgICAgIGNhc2UgJ3JlYWRhYmxlJzpcbiAgICAgICAgICAgICAgICB0aGlzLnBvbGwoZXhwb3J0cy5FVkVOVFMuVVZfUkVBREFCTEUpO1xuICAgICAgICAgICAgICAgIGJyZWFrO1xuICAgICAgICAgICAgY2FzZSAnd3JpdGFibGUnOlxuICAgICAgICAgICAgICAgIHRoaXMucG9sbChleHBvcnRzLkVWRU5UUy5VVl9XUklUQUJMRSk7XG4gICAgICAgICAgICAgICAgYnJlYWs7XG4gICAgICAgICAgICBjYXNlICdkaXNjb25uZWN0JzpcbiAgICAgICAgICAgICAgICB0aGlzLnBvbGwoZXhwb3J0cy5FVkVOVFMuVVZfRElTQ09OTkVDVCk7XG4gICAgICAgICAgICAgICAgYnJlYWs7XG4gICAgICAgIH1cbiAgICAgICAgcmV0dXJuIHN1cGVyLm9uY2UoZXZlbnQsIGNhbGxiYWNrKTtcbiAgICB9XG4gICAgLyoqXG4gICAgICogQXNrIHRoZSBiaW5kaW5ncyB0byBsaXN0ZW4gZm9yIGFuIGV2ZW50LCBpdCBpcyByZWNvbW1lbmQgdG8gdXNlIGAub25jZSgpYCBmb3IgZWFzeSB1c2VcbiAgICAgKiBAcGFyYW0ge0VWRU5UU30gZXZlbnRGbGFnIHBvbGxzIGZvciBhbiBldmVudCBvciBncm91cCBvZiBldmVudHMgYmFzZWQgdXBvbiBhIGZsYWcuXG4gICAgICovXG4gICAgcG9sbChldmVudEZsYWcgPSAwKSB7XG4gICAgICAgIGlmIChldmVudEZsYWcgJiBleHBvcnRzLkVWRU5UUy5VVl9SRUFEQUJMRSkge1xuICAgICAgICAgICAgbG9nZ2VyKCdQb2xsaW5nIGZvciBcInJlYWRhYmxlXCInKTtcbiAgICAgICAgfVxuICAgICAgICBpZiAoZXZlbnRGbGFnICYgZXhwb3J0cy5FVkVOVFMuVVZfV1JJVEFCTEUpIHtcbiAgICAgICAgICAgIGxvZ2dlcignUG9sbGluZyBmb3IgXCJ3cml0YWJsZVwiJyk7XG4gICAgICAgIH1cbiAgICAgICAgaWYgKGV2ZW50RmxhZyAmIGV4cG9ydHMuRVZFTlRTLlVWX0RJU0NPTk5FQ1QpIHtcbiAgICAgICAgICAgIGxvZ2dlcignUG9sbGluZyBmb3IgXCJkaXNjb25uZWN0XCInKTtcbiAgICAgICAgfVxuICAgICAgICB0aGlzLnBvbGxlci5wb2xsKGV2ZW50RmxhZyk7XG4gICAgfVxuICAgIC8qKlxuICAgICAqIFN0b3AgbGlzdGVuaW5nIGZvciBldmVudHMgYW5kIGNhbmNlbCBhbGwgb3V0c3RhbmRpbmcgbGlzdGVuaW5nIHdpdGggYW4gZXJyb3JcbiAgICAgKi9cbiAgICBzdG9wKCkge1xuICAgICAgICBsb2dnZXIoJ1N0b3BwaW5nIHBvbGxlcicpO1xuICAgICAgICB0aGlzLnBvbGxlci5zdG9wKCk7XG4gICAgICAgIHRoaXMuZW1pdENhbmNlbGVkKCk7XG4gICAgfVxuICAgIGRlc3Ryb3koKSB7XG4gICAgICAgIGxvZ2dlcignRGVzdHJveWluZyBwb2xsZXInKTtcbiAgICAgICAgdGhpcy5wb2xsZXIuZGVzdHJveSgpO1xuICAgICAgICB0aGlzLmVtaXRDYW5jZWxlZCgpO1xuICAgIH1cbiAgICBlbWl0Q2FuY2VsZWQoKSB7XG4gICAgICAgIGNvbnN0IGVyciA9IG5ldyBlcnJvcnNfMS5CaW5kaW5nc0Vycm9yKCdDYW5jZWxlZCcsIHsgY2FuY2VsZWQ6IHRydWUgfSk7XG4gICAgICAgIHRoaXMuZW1pdCgncmVhZGFibGUnLCBlcnIpO1xuICAgICAgICB0aGlzLmVtaXQoJ3dyaXRhYmxlJywgZXJyKTtcbiAgICAgICAgdGhpcy5lbWl0KCdkaXNjb25uZWN0JywgZXJyKTtcbiAgICB9XG59XG5leHBvcnRzLlBvbGxlciA9IFBvbGxlcjtcbiIsIlwidXNlIHN0cmljdFwiO1xudmFyIF9faW1wb3J0RGVmYXVsdCA9ICh0aGlzICYmIHRoaXMuX19pbXBvcnREZWZhdWx0KSB8fCBmdW5jdGlvbiAobW9kKSB7XG4gICAgcmV0dXJuIChtb2QgJiYgbW9kLl9fZXNNb2R1bGUpID8gbW9kIDogeyBcImRlZmF1bHRcIjogbW9kIH07XG59O1xuT2JqZWN0LmRlZmluZVByb3BlcnR5KGV4cG9ydHMsIFwiX19lc01vZHVsZVwiLCB7IHZhbHVlOiB0cnVlIH0pO1xuZXhwb3J0cy51bml4UmVhZCA9IHZvaWQgMDtcbmNvbnN0IHV0aWxfMSA9IHJlcXVpcmUoXCJ1dGlsXCIpO1xuY29uc3QgZnNfMSA9IHJlcXVpcmUoXCJmc1wiKTtcbmNvbnN0IGVycm9yc18xID0gcmVxdWlyZShcIi4vZXJyb3JzXCIpO1xuY29uc3QgZGVidWdfMSA9IF9faW1wb3J0RGVmYXVsdChyZXF1aXJlKFwiZGVidWdcIikpO1xuY29uc3QgbG9nZ2VyID0gKDAsIGRlYnVnXzEuZGVmYXVsdCkoJ3NlcmlhbHBvcnQvYmluZGluZ3MtY3BwL3VuaXhSZWFkJyk7XG5jb25zdCByZWFkQXN5bmMgPSAoMCwgdXRpbF8xLnByb21pc2lmeSkoZnNfMS5yZWFkKTtcbmNvbnN0IHJlYWRhYmxlID0gKGJpbmRpbmcpID0+IHtcbiAgICByZXR1cm4gbmV3IFByb21pc2UoKHJlc29sdmUsIHJlamVjdCkgPT4ge1xuICAgICAgICBpZiAoIWJpbmRpbmcucG9sbGVyKSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgRXJyb3IoJ05vIHBvbGxlciBvbiBiaW5kaW5ncycpO1xuICAgICAgICB9XG4gICAgICAgIGJpbmRpbmcucG9sbGVyLm9uY2UoJ3JlYWRhYmxlJywgZXJyID0+IChlcnIgPyByZWplY3QoZXJyKSA6IHJlc29sdmUoKSkpO1xuICAgIH0pO1xufTtcbmNvbnN0IHVuaXhSZWFkID0gYXN5bmMgKHsgYmluZGluZywgYnVmZmVyLCBvZmZzZXQsIGxlbmd0aCwgZnNSZWFkQXN5bmMgPSByZWFkQXN5bmMsIH0pID0+IHtcbiAgICBsb2dnZXIoJ1N0YXJ0aW5nIHJlYWQnKTtcbiAgICBpZiAoIWJpbmRpbmcuaXNPcGVuIHx8ICFiaW5kaW5nLmZkKSB7XG4gICAgICAgIHRocm93IG5ldyBlcnJvcnNfMS5CaW5kaW5nc0Vycm9yKCdQb3J0IGlzIG5vdCBvcGVuJywgeyBjYW5jZWxlZDogdHJ1ZSB9KTtcbiAgICB9XG4gICAgdHJ5IHtcbiAgICAgICAgY29uc3QgeyBieXRlc1JlYWQgfSA9IGF3YWl0IGZzUmVhZEFzeW5jKGJpbmRpbmcuZmQsIGJ1ZmZlciwgb2Zmc2V0LCBsZW5ndGgsIG51bGwpO1xuICAgICAgICBpZiAoYnl0ZXNSZWFkID09PSAwKSB7XG4gICAgICAgICAgICByZXR1cm4gKDAsIGV4cG9ydHMudW5peFJlYWQpKHsgYmluZGluZywgYnVmZmVyLCBvZmZzZXQsIGxlbmd0aCwgZnNSZWFkQXN5bmMgfSk7XG4gICAgICAgIH1cbiAgICAgICAgbG9nZ2VyKCdGaW5pc2hlZCByZWFkJywgYnl0ZXNSZWFkLCAnYnl0ZXMnKTtcbiAgICAgICAgcmV0dXJuIHsgYnl0ZXNSZWFkLCBidWZmZXIgfTtcbiAgICB9XG4gICAgY2F0Y2ggKGVycikge1xuICAgICAgICBsb2dnZXIoJ3JlYWQgZXJyb3InLCBlcnIpO1xuICAgICAgICBpZiAoZXJyLmNvZGUgPT09ICdFQUdBSU4nIHx8IGVyci5jb2RlID09PSAnRVdPVUxEQkxPQ0snIHx8IGVyci5jb2RlID09PSAnRUlOVFInKSB7XG4gICAgICAgICAgICBpZiAoIWJpbmRpbmcuaXNPcGVuKSB7XG4gICAgICAgICAgICAgICAgdGhyb3cgbmV3IGVycm9yc18xLkJpbmRpbmdzRXJyb3IoJ1BvcnQgaXMgbm90IG9wZW4nLCB7IGNhbmNlbGVkOiB0cnVlIH0pO1xuICAgICAgICAgICAgfVxuICAgICAgICAgICAgbG9nZ2VyKCd3YWl0aW5nIGZvciByZWFkYWJsZSBiZWNhdXNlIG9mIGNvZGU6JywgZXJyLmNvZGUpO1xuICAgICAgICAgICAgYXdhaXQgcmVhZGFibGUoYmluZGluZyk7XG4gICAgICAgICAgICByZXR1cm4gKDAsIGV4cG9ydHMudW5peFJlYWQpKHsgYmluZGluZywgYnVmZmVyLCBvZmZzZXQsIGxlbmd0aCwgZnNSZWFkQXN5bmMgfSk7XG4gICAgICAgIH1cbiAgICAgICAgY29uc3QgZGlzY29ubmVjdEVycm9yID0gZXJyLmNvZGUgPT09ICdFQkFERicgfHwgLy8gQmFkIGZpbGUgbnVtYmVyIG1lYW5zIHdlIGdvdCBjbG9zZWRcbiAgICAgICAgICAgIGVyci5jb2RlID09PSAnRU5YSU8nIHx8IC8vIE5vIHN1Y2ggZGV2aWNlIG9yIGFkZHJlc3MgcHJvYmFibHkgdXNiIGRpc2Nvbm5lY3RcbiAgICAgICAgICAgIGVyci5jb2RlID09PSAnVU5LTk9XTicgfHxcbiAgICAgICAgICAgIGVyci5lcnJubyA9PT0gLTE7IC8vIGdlbmVyaWMgZXJyb3JcbiAgICAgICAgaWYgKGRpc2Nvbm5lY3RFcnJvcikge1xuICAgICAgICAgICAgZXJyLmRpc2Nvbm5lY3QgPSB0cnVlO1xuICAgICAgICAgICAgbG9nZ2VyKCdkaXNjb25uZWN0aW5nJywgZXJyKTtcbiAgICAgICAgfVxuICAgICAgICB0aHJvdyBlcnI7XG4gICAgfVxufTtcbmV4cG9ydHMudW5peFJlYWQgPSB1bml4UmVhZDtcbiIsIlwidXNlIHN0cmljdFwiO1xudmFyIF9faW1wb3J0RGVmYXVsdCA9ICh0aGlzICYmIHRoaXMuX19pbXBvcnREZWZhdWx0KSB8fCBmdW5jdGlvbiAobW9kKSB7XG4gICAgcmV0dXJuIChtb2QgJiYgbW9kLl9fZXNNb2R1bGUpID8gbW9kIDogeyBcImRlZmF1bHRcIjogbW9kIH07XG59O1xuT2JqZWN0LmRlZmluZVByb3BlcnR5KGV4cG9ydHMsIFwiX19lc01vZHVsZVwiLCB7IHZhbHVlOiB0cnVlIH0pO1xuZXhwb3J0cy51bml4V3JpdGUgPSB2b2lkIDA7XG5jb25zdCBmc18xID0gcmVxdWlyZShcImZzXCIpO1xuY29uc3QgZGVidWdfMSA9IF9faW1wb3J0RGVmYXVsdChyZXF1aXJlKFwiZGVidWdcIikpO1xuY29uc3QgdXRpbF8xID0gcmVxdWlyZShcInV0aWxcIik7XG5jb25zdCBsb2dnZXIgPSAoMCwgZGVidWdfMS5kZWZhdWx0KSgnc2VyaWFscG9ydC9iaW5kaW5ncy1jcHAvdW5peFdyaXRlJyk7XG5jb25zdCB3cml0ZUFzeW5jID0gKDAsIHV0aWxfMS5wcm9taXNpZnkpKGZzXzEud3JpdGUpO1xuY29uc3Qgd3JpdGFibGUgPSAoYmluZGluZykgPT4ge1xuICAgIHJldHVybiBuZXcgUHJvbWlzZSgocmVzb2x2ZSwgcmVqZWN0KSA9PiB7XG4gICAgICAgIGJpbmRpbmcucG9sbGVyLm9uY2UoJ3dyaXRhYmxlJywgZXJyID0+IChlcnIgPyByZWplY3QoZXJyKSA6IHJlc29sdmUoKSkpO1xuICAgIH0pO1xufTtcbmNvbnN0IHVuaXhXcml0ZSA9IGFzeW5jICh7IGJpbmRpbmcsIGJ1ZmZlciwgb2Zmc2V0ID0gMCwgZnNXcml0ZUFzeW5jID0gd3JpdGVBc3luYyB9KSA9PiB7XG4gICAgY29uc3QgYnl0ZXNUb1dyaXRlID0gYnVmZmVyLmxlbmd0aCAtIG9mZnNldDtcbiAgICBsb2dnZXIoJ1N0YXJ0aW5nIHdyaXRlJywgYnVmZmVyLmxlbmd0aCwgJ2J5dGVzIG9mZnNldCcsIG9mZnNldCwgJ2J5dGVzVG9Xcml0ZScsIGJ5dGVzVG9Xcml0ZSk7XG4gICAgaWYgKCFiaW5kaW5nLmlzT3BlbiB8fCAhYmluZGluZy5mZCkge1xuICAgICAgICB0aHJvdyBuZXcgRXJyb3IoJ1BvcnQgaXMgbm90IG9wZW4nKTtcbiAgICB9XG4gICAgdHJ5IHtcbiAgICAgICAgY29uc3QgeyBieXRlc1dyaXR0ZW4gfSA9IGF3YWl0IGZzV3JpdGVBc3luYyhiaW5kaW5nLmZkLCBidWZmZXIsIG9mZnNldCwgYnl0ZXNUb1dyaXRlKTtcbiAgICAgICAgbG9nZ2VyKCd3cml0ZSByZXR1cm5lZDogd3JvdGUnLCBieXRlc1dyaXR0ZW4sICdieXRlcycpO1xuICAgICAgICBpZiAoYnl0ZXNXcml0dGVuICsgb2Zmc2V0IDwgYnVmZmVyLmxlbmd0aCkge1xuICAgICAgICAgICAgaWYgKCFiaW5kaW5nLmlzT3Blbikge1xuICAgICAgICAgICAgICAgIHRocm93IG5ldyBFcnJvcignUG9ydCBpcyBub3Qgb3BlbicpO1xuICAgICAgICAgICAgfVxuICAgICAgICAgICAgcmV0dXJuICgwLCBleHBvcnRzLnVuaXhXcml0ZSkoeyBiaW5kaW5nLCBidWZmZXIsIG9mZnNldDogYnl0ZXNXcml0dGVuICsgb2Zmc2V0LCBmc1dyaXRlQXN5bmMgfSk7XG4gICAgICAgIH1cbiAgICAgICAgbG9nZ2VyKCdGaW5pc2hlZCB3cml0aW5nJywgYnl0ZXNXcml0dGVuICsgb2Zmc2V0LCAnYnl0ZXMnKTtcbiAgICB9XG4gICAgY2F0Y2ggKGVycikge1xuICAgICAgICBsb2dnZXIoJ3dyaXRlIGVycm9yZWQnLCBlcnIpO1xuICAgICAgICBpZiAoZXJyLmNvZGUgPT09ICdFQUdBSU4nIHx8IGVyci5jb2RlID09PSAnRVdPVUxEQkxPQ0snIHx8IGVyci5jb2RlID09PSAnRUlOVFInKSB7XG4gICAgICAgICAgICBpZiAoIWJpbmRpbmcuaXNPcGVuKSB7XG4gICAgICAgICAgICAgICAgdGhyb3cgbmV3IEVycm9yKCdQb3J0IGlzIG5vdCBvcGVuJyk7XG4gICAgICAgICAgICB9XG4gICAgICAgICAgICBsb2dnZXIoJ3dhaXRpbmcgZm9yIHdyaXRhYmxlIGJlY2F1c2Ugb2YgY29kZTonLCBlcnIuY29kZSk7XG4gICAgICAgICAgICBhd2FpdCB3cml0YWJsZShiaW5kaW5nKTtcbiAgICAgICAgICAgIHJldHVybiAoMCwgZXhwb3J0cy51bml4V3JpdGUpKHsgYmluZGluZywgYnVmZmVyLCBvZmZzZXQsIGZzV3JpdGVBc3luYyB9KTtcbiAgICAgICAgfVxuICAgICAgICBjb25zdCBkaXNjb25uZWN0RXJyb3IgPSBlcnIuY29kZSA9PT0gJ0VCQURGJyB8fCAvLyBCYWQgZmlsZSBudW1iZXIgbWVhbnMgd2UgZ290IGNsb3NlZFxuICAgICAgICAgICAgZXJyLmNvZGUgPT09ICdFTlhJTycgfHwgLy8gTm8gc3VjaCBkZXZpY2Ugb3IgYWRkcmVzcyBwcm9iYWJseSB1c2IgZGlzY29ubmVjdFxuICAgICAgICAgICAgZXJyLmNvZGUgPT09ICdVTktOT1dOJyB8fFxuICAgICAgICAgICAgZXJyLmVycm5vID09PSAtMTsgLy8gZ2VuZXJpYyBlcnJvclxuICAgICAgICBpZiAoZGlzY29ubmVjdEVycm9yKSB7XG4gICAgICAgICAgICBlcnIuZGlzY29ubmVjdCA9IHRydWU7XG4gICAgICAgICAgICBsb2dnZXIoJ2Rpc2Nvbm5lY3RpbmcnLCBlcnIpO1xuICAgICAgICB9XG4gICAgICAgIGxvZ2dlcignZXJyb3InLCBlcnIpO1xuICAgICAgICB0aHJvdyBlcnI7XG4gICAgfVxufTtcbmV4cG9ydHMudW5peFdyaXRlID0gdW5peFdyaXRlO1xuIiwiXCJ1c2Ugc3RyaWN0XCI7XG5PYmplY3QuZGVmaW5lUHJvcGVydHkoZXhwb3J0cywgXCJfX2VzTW9kdWxlXCIsIHsgdmFsdWU6IHRydWUgfSk7XG5leHBvcnRzLnNlcmlhbE51bVBhcnNlciA9IHZvaWQgMDtcbmNvbnN0IFBBUlNFUlMgPSBbL1VTQlxcXFwoPzouKylcXFxcKC4rKS8sIC9GVERJQlVTXFxcXCg/Oi4rKVxcKyguKz8pQT9cXFxcLisvXTtcbmNvbnN0IHNlcmlhbE51bVBhcnNlciA9IChwbnBJZCkgPT4ge1xuICAgIGlmICghcG5wSWQpIHtcbiAgICAgICAgcmV0dXJuIG51bGw7XG4gICAgfVxuICAgIGZvciAoY29uc3QgcGFyc2VyIG9mIFBBUlNFUlMpIHtcbiAgICAgICAgY29uc3Qgc24gPSBwbnBJZC5tYXRjaChwYXJzZXIpO1xuICAgICAgICBpZiAoc24pIHtcbiAgICAgICAgICAgIHJldHVybiBzblsxXTtcbiAgICAgICAgfVxuICAgIH1cbiAgICByZXR1cm4gbnVsbDtcbn07XG5leHBvcnRzLnNlcmlhbE51bVBhcnNlciA9IHNlcmlhbE51bVBhcnNlcjtcbiIsIlwidXNlIHN0cmljdFwiO1xudmFyIF9faW1wb3J0RGVmYXVsdCA9ICh0aGlzICYmIHRoaXMuX19pbXBvcnREZWZhdWx0KSB8fCBmdW5jdGlvbiAobW9kKSB7XG4gICAgcmV0dXJuIChtb2QgJiYgbW9kLl9fZXNNb2R1bGUpID8gbW9kIDogeyBcImRlZmF1bHRcIjogbW9kIH07XG59O1xuT2JqZWN0LmRlZmluZVByb3BlcnR5KGV4cG9ydHMsIFwiX19lc01vZHVsZVwiLCB7IHZhbHVlOiB0cnVlIH0pO1xuZXhwb3J0cy5XaW5kb3dzUG9ydEJpbmRpbmcgPSBleHBvcnRzLldpbmRvd3NCaW5kaW5nID0gdm9pZCAwO1xuY29uc3QgZGVidWdfMSA9IF9faW1wb3J0RGVmYXVsdChyZXF1aXJlKFwiZGVidWdcIikpO1xuY29uc3QgXzEgPSByZXF1aXJlKFwiLlwiKTtcbmNvbnN0IGxvYWRfYmluZGluZ3NfMSA9IHJlcXVpcmUoXCIuL2xvYWQtYmluZGluZ3NcIik7XG5jb25zdCB3aW4zMl9zbl9wYXJzZXJfMSA9IHJlcXVpcmUoXCIuL3dpbjMyLXNuLXBhcnNlclwiKTtcbmNvbnN0IGRlYnVnID0gKDAsIGRlYnVnXzEuZGVmYXVsdCkoJ3NlcmlhbHBvcnQvYmluZGluZ3MtY3BwJyk7XG5leHBvcnRzLldpbmRvd3NCaW5kaW5nID0ge1xuICAgIGFzeW5jIGxpc3QoKSB7XG4gICAgICAgIGNvbnN0IHBvcnRzID0gYXdhaXQgKDAsIGxvYWRfYmluZGluZ3NfMS5hc3luY0xpc3QpKCk7XG4gICAgICAgIC8vIEdyYWIgdGhlIHNlcmlhbCBudW1iZXIgZnJvbSB0aGUgcG5wIGlkXG4gICAgICAgIHJldHVybiBwb3J0cy5tYXAocG9ydCA9PiB7XG4gICAgICAgICAgICBpZiAocG9ydC5wbnBJZCAmJiAhcG9ydC5zZXJpYWxOdW1iZXIpIHtcbiAgICAgICAgICAgICAgICBjb25zdCBzZXJpYWxOdW1iZXIgPSAoMCwgd2luMzJfc25fcGFyc2VyXzEuc2VyaWFsTnVtUGFyc2VyKShwb3J0LnBucElkKTtcbiAgICAgICAgICAgICAgICBpZiAoc2VyaWFsTnVtYmVyKSB7XG4gICAgICAgICAgICAgICAgICAgIHJldHVybiBPYmplY3QuYXNzaWduKE9iamVjdC5hc3NpZ24oe30sIHBvcnQpLCB7IHNlcmlhbE51bWJlciB9KTtcbiAgICAgICAgICAgICAgICB9XG4gICAgICAgICAgICB9XG4gICAgICAgICAgICByZXR1cm4gcG9ydDtcbiAgICAgICAgfSk7XG4gICAgfSxcbiAgICBhc3luYyBvcGVuKG9wdGlvbnMpIHtcbiAgICAgICAgaWYgKCFvcHRpb25zIHx8IHR5cGVvZiBvcHRpb25zICE9PSAnb2JqZWN0JyB8fCBBcnJheS5pc0FycmF5KG9wdGlvbnMpKSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgVHlwZUVycm9yKCdcIm9wdGlvbnNcIiBpcyBub3QgYW4gb2JqZWN0Jyk7XG4gICAgICAgIH1cbiAgICAgICAgaWYgKCFvcHRpb25zLnBhdGgpIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBUeXBlRXJyb3IoJ1wicGF0aFwiIGlzIG5vdCBhIHZhbGlkIHBvcnQnKTtcbiAgICAgICAgfVxuICAgICAgICBpZiAoIW9wdGlvbnMuYmF1ZFJhdGUpIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBUeXBlRXJyb3IoJ1wiYmF1ZFJhdGVcIiBpcyBub3QgYSB2YWxpZCBiYXVkUmF0ZScpO1xuICAgICAgICB9XG4gICAgICAgIGRlYnVnKCdvcGVuJyk7XG4gICAgICAgIGNvbnN0IG9wZW5PcHRpb25zID0gT2JqZWN0LmFzc2lnbih7IGRhdGFCaXRzOiA4LCBsb2NrOiB0cnVlLCBzdG9wQml0czogMSwgcGFyaXR5OiAnbm9uZScsIHJ0c2N0czogZmFsc2UsIHJ0c01vZGU6ICdoYW5kc2hha2UnLCB4b246IGZhbHNlLCB4b2ZmOiBmYWxzZSwgeGFueTogZmFsc2UsIGh1cGNsOiB0cnVlIH0sIG9wdGlvbnMpO1xuICAgICAgICBjb25zdCBmZCA9IGF3YWl0ICgwLCBsb2FkX2JpbmRpbmdzXzEuYXN5bmNPcGVuKShvcGVuT3B0aW9ucy5wYXRoLCBvcGVuT3B0aW9ucyk7XG4gICAgICAgIHJldHVybiBuZXcgV2luZG93c1BvcnRCaW5kaW5nKGZkLCBvcGVuT3B0aW9ucyk7XG4gICAgfSxcbn07XG4vKipcbiAqIFRoZSBXaW5kb3dzIGJpbmRpbmcgbGF5ZXJcbiAqL1xuY2xhc3MgV2luZG93c1BvcnRCaW5kaW5nIHtcbiAgICBjb25zdHJ1Y3RvcihmZCwgb3B0aW9ucykge1xuICAgICAgICB0aGlzLmZkID0gZmQ7XG4gICAgICAgIHRoaXMub3Blbk9wdGlvbnMgPSBvcHRpb25zO1xuICAgICAgICB0aGlzLndyaXRlT3BlcmF0aW9uID0gbnVsbDtcbiAgICB9XG4gICAgZ2V0IGlzT3BlbigpIHtcbiAgICAgICAgcmV0dXJuIHRoaXMuZmQgIT09IG51bGw7XG4gICAgfVxuICAgIGFzeW5jIGNsb3NlKCkge1xuICAgICAgICBkZWJ1ZygnY2xvc2UnKTtcbiAgICAgICAgaWYgKCF0aGlzLmlzT3Blbikge1xuICAgICAgICAgICAgdGhyb3cgbmV3IEVycm9yKCdQb3J0IGlzIG5vdCBvcGVuJyk7XG4gICAgICAgIH1cbiAgICAgICAgY29uc3QgZmQgPSB0aGlzLmZkO1xuICAgICAgICB0aGlzLmZkID0gbnVsbDtcbiAgICAgICAgYXdhaXQgKDAsIGxvYWRfYmluZGluZ3NfMS5hc3luY0Nsb3NlKShmZCk7XG4gICAgfVxuICAgIGFzeW5jIHJlYWQoYnVmZmVyLCBvZmZzZXQsIGxlbmd0aCkge1xuICAgICAgICBpZiAoIUJ1ZmZlci5pc0J1ZmZlcihidWZmZXIpKSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgVHlwZUVycm9yKCdcImJ1ZmZlclwiIGlzIG5vdCBhIEJ1ZmZlcicpO1xuICAgICAgICB9XG4gICAgICAgIGlmICh0eXBlb2Ygb2Zmc2V0ICE9PSAnbnVtYmVyJyB8fCBpc05hTihvZmZzZXQpKSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgVHlwZUVycm9yKGBcIm9mZnNldFwiIGlzIG5vdCBhbiBpbnRlZ2VyIGdvdCBcIiR7aXNOYU4ob2Zmc2V0KSA/ICdOYU4nIDogdHlwZW9mIG9mZnNldH1cImApO1xuICAgICAgICB9XG4gICAgICAgIGlmICh0eXBlb2YgbGVuZ3RoICE9PSAnbnVtYmVyJyB8fCBpc05hTihsZW5ndGgpKSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgVHlwZUVycm9yKGBcImxlbmd0aFwiIGlzIG5vdCBhbiBpbnRlZ2VyIGdvdCBcIiR7aXNOYU4obGVuZ3RoKSA/ICdOYU4nIDogdHlwZW9mIGxlbmd0aH1cImApO1xuICAgICAgICB9XG4gICAgICAgIGRlYnVnKCdyZWFkJyk7XG4gICAgICAgIGlmIChidWZmZXIubGVuZ3RoIDwgb2Zmc2V0ICsgbGVuZ3RoKSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgRXJyb3IoJ2J1ZmZlciBpcyB0b28gc21hbGwnKTtcbiAgICAgICAgfVxuICAgICAgICBpZiAoIXRoaXMuaXNPcGVuKSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgRXJyb3IoJ1BvcnQgaXMgbm90IG9wZW4nKTtcbiAgICAgICAgfVxuICAgICAgICB0cnkge1xuICAgICAgICAgICAgY29uc3QgYnl0ZXNSZWFkID0gYXdhaXQgKDAsIGxvYWRfYmluZGluZ3NfMS5hc3luY1JlYWQpKHRoaXMuZmQsIGJ1ZmZlciwgb2Zmc2V0LCBsZW5ndGgpO1xuICAgICAgICAgICAgcmV0dXJuIHsgYnl0ZXNSZWFkLCBidWZmZXIgfTtcbiAgICAgICAgfVxuICAgICAgICBjYXRjaCAoZXJyKSB7XG4gICAgICAgICAgICBpZiAoIXRoaXMuaXNPcGVuKSB7XG4gICAgICAgICAgICAgICAgdGhyb3cgbmV3IF8xLkJpbmRpbmdzRXJyb3IoZXJyLm1lc3NhZ2UsIHsgY2FuY2VsZWQ6IHRydWUgfSk7XG4gICAgICAgICAgICB9XG4gICAgICAgICAgICB0aHJvdyBlcnI7XG4gICAgICAgIH1cbiAgICB9XG4gICAgYXN5bmMgd3JpdGUoYnVmZmVyKSB7XG4gICAgICAgIGlmICghQnVmZmVyLmlzQnVmZmVyKGJ1ZmZlcikpIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBUeXBlRXJyb3IoJ1wiYnVmZmVyXCIgaXMgbm90IGEgQnVmZmVyJyk7XG4gICAgICAgIH1cbiAgICAgICAgZGVidWcoJ3dyaXRlJywgYnVmZmVyLmxlbmd0aCwgJ2J5dGVzJyk7XG4gICAgICAgIGlmICghdGhpcy5pc09wZW4pIHtcbiAgICAgICAgICAgIGRlYnVnKCd3cml0ZScsICdlcnJvciBwb3J0IGlzIG5vdCBvcGVuJyk7XG4gICAgICAgICAgICB0aHJvdyBuZXcgRXJyb3IoJ1BvcnQgaXMgbm90IG9wZW4nKTtcbiAgICAgICAgfVxuICAgICAgICB0aGlzLndyaXRlT3BlcmF0aW9uID0gKGFzeW5jICgpID0+IHtcbiAgICAgICAgICAgIGlmIChidWZmZXIubGVuZ3RoID09PSAwKSB7XG4gICAgICAgICAgICAgICAgcmV0dXJuO1xuICAgICAgICAgICAgfVxuICAgICAgICAgICAgYXdhaXQgKDAsIGxvYWRfYmluZGluZ3NfMS5hc3luY1dyaXRlKSh0aGlzLmZkLCBidWZmZXIpO1xuICAgICAgICAgICAgdGhpcy53cml0ZU9wZXJhdGlvbiA9IG51bGw7XG4gICAgICAgIH0pKCk7XG4gICAgICAgIHJldHVybiB0aGlzLndyaXRlT3BlcmF0aW9uO1xuICAgIH1cbiAgICBhc3luYyB1cGRhdGUob3B0aW9ucykge1xuICAgICAgICBpZiAoIW9wdGlvbnMgfHwgdHlwZW9mIG9wdGlvbnMgIT09ICdvYmplY3QnIHx8IEFycmF5LmlzQXJyYXkob3B0aW9ucykpIHtcbiAgICAgICAgICAgIHRocm93IFR5cGVFcnJvcignXCJvcHRpb25zXCIgaXMgbm90IGFuIG9iamVjdCcpO1xuICAgICAgICB9XG4gICAgICAgIGlmICh0eXBlb2Ygb3B0aW9ucy5iYXVkUmF0ZSAhPT0gJ251bWJlcicpIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBUeXBlRXJyb3IoJ1wib3B0aW9ucy5iYXVkUmF0ZVwiIGlzIG5vdCBhIG51bWJlcicpO1xuICAgICAgICB9XG4gICAgICAgIGRlYnVnKCd1cGRhdGUnKTtcbiAgICAgICAgaWYgKCF0aGlzLmlzT3Blbikge1xuICAgICAgICAgICAgdGhyb3cgbmV3IEVycm9yKCdQb3J0IGlzIG5vdCBvcGVuJyk7XG4gICAgICAgIH1cbiAgICAgICAgYXdhaXQgKDAsIGxvYWRfYmluZGluZ3NfMS5hc3luY1VwZGF0ZSkodGhpcy5mZCwgb3B0aW9ucyk7XG4gICAgfVxuICAgIGFzeW5jIHNldChvcHRpb25zKSB7XG4gICAgICAgIGlmICghb3B0aW9ucyB8fCB0eXBlb2Ygb3B0aW9ucyAhPT0gJ29iamVjdCcgfHwgQXJyYXkuaXNBcnJheShvcHRpb25zKSkge1xuICAgICAgICAgICAgdGhyb3cgbmV3IFR5cGVFcnJvcignXCJvcHRpb25zXCIgaXMgbm90IGFuIG9iamVjdCcpO1xuICAgICAgICB9XG4gICAgICAgIGRlYnVnKCdzZXQnLCBvcHRpb25zKTtcbiAgICAgICAgaWYgKCF0aGlzLmlzT3Blbikge1xuICAgICAgICAgICAgdGhyb3cgbmV3IEVycm9yKCdQb3J0IGlzIG5vdCBvcGVuJyk7XG4gICAgICAgIH1cbiAgICAgICAgYXdhaXQgKDAsIGxvYWRfYmluZGluZ3NfMS5hc3luY1NldCkodGhpcy5mZCwgb3B0aW9ucyk7XG4gICAgfVxuICAgIGFzeW5jIGdldCgpIHtcbiAgICAgICAgZGVidWcoJ2dldCcpO1xuICAgICAgICBpZiAoIXRoaXMuaXNPcGVuKSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgRXJyb3IoJ1BvcnQgaXMgbm90IG9wZW4nKTtcbiAgICAgICAgfVxuICAgICAgICByZXR1cm4gKDAsIGxvYWRfYmluZGluZ3NfMS5hc3luY0dldCkodGhpcy5mZCk7XG4gICAgfVxuICAgIGFzeW5jIGdldEJhdWRSYXRlKCkge1xuICAgICAgICBkZWJ1ZygnZ2V0QmF1ZFJhdGUnKTtcbiAgICAgICAgaWYgKCF0aGlzLmlzT3Blbikge1xuICAgICAgICAgICAgdGhyb3cgbmV3IEVycm9yKCdQb3J0IGlzIG5vdCBvcGVuJyk7XG4gICAgICAgIH1cbiAgICAgICAgcmV0dXJuICgwLCBsb2FkX2JpbmRpbmdzXzEuYXN5bmNHZXRCYXVkUmF0ZSkodGhpcy5mZCk7XG4gICAgfVxuICAgIGFzeW5jIGZsdXNoKCkge1xuICAgICAgICBkZWJ1ZygnZmx1c2gnKTtcbiAgICAgICAgaWYgKCF0aGlzLmlzT3Blbikge1xuICAgICAgICAgICAgdGhyb3cgbmV3IEVycm9yKCdQb3J0IGlzIG5vdCBvcGVuJyk7XG4gICAgICAgIH1cbiAgICAgICAgYXdhaXQgKDAsIGxvYWRfYmluZGluZ3NfMS5hc3luY0ZsdXNoKSh0aGlzLmZkKTtcbiAgICB9XG4gICAgYXN5bmMgZHJhaW4oKSB7XG4gICAgICAgIGRlYnVnKCdkcmFpbicpO1xuICAgICAgICBpZiAoIXRoaXMuaXNPcGVuKSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgRXJyb3IoJ1BvcnQgaXMgbm90IG9wZW4nKTtcbiAgICAgICAgfVxuICAgICAgICBhd2FpdCB0aGlzLndyaXRlT3BlcmF0aW9uO1xuICAgICAgICBhd2FpdCAoMCwgbG9hZF9iaW5kaW5nc18xLmFzeW5jRHJhaW4pKHRoaXMuZmQpO1xuICAgIH1cbn1cbmV4cG9ydHMuV2luZG93c1BvcnRCaW5kaW5nID0gV2luZG93c1BvcnRCaW5kaW5nO1xuIiwiJ3VzZSBzdHJpY3QnO1xuXG4iLCJcInVzZSBzdHJpY3RcIjtcbk9iamVjdC5kZWZpbmVQcm9wZXJ0eShleHBvcnRzLCBcIl9fZXNNb2R1bGVcIiwgeyB2YWx1ZTogdHJ1ZSB9KTtcbmV4cG9ydHMuQnl0ZUxlbmd0aFBhcnNlciA9IHZvaWQgMDtcbmNvbnN0IHN0cmVhbV8xID0gcmVxdWlyZShcInN0cmVhbVwiKTtcbi8qKlxuICogRW1pdCBkYXRhIGV2ZXJ5IG51bWJlciBvZiBieXRlc1xuICpcbiAqIEEgdHJhbnNmb3JtIHN0cmVhbSB0aGF0IGVtaXRzIGRhdGEgYXMgYSBidWZmZXIgYWZ0ZXIgYSBzcGVjaWZpYyBudW1iZXIgb2YgYnl0ZXMgYXJlIHJlY2VpdmVkLiBSdW5zIGluIE8obikgdGltZS5cbiAqL1xuY2xhc3MgQnl0ZUxlbmd0aFBhcnNlciBleHRlbmRzIHN0cmVhbV8xLlRyYW5zZm9ybSB7XG4gICAgY29uc3RydWN0b3Iob3B0aW9ucykge1xuICAgICAgICBzdXBlcihvcHRpb25zKTtcbiAgICAgICAgaWYgKHR5cGVvZiBvcHRpb25zLmxlbmd0aCAhPT0gJ251bWJlcicpIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBUeXBlRXJyb3IoJ1wibGVuZ3RoXCIgaXMgbm90IGEgbnVtYmVyJyk7XG4gICAgICAgIH1cbiAgICAgICAgaWYgKG9wdGlvbnMubGVuZ3RoIDwgMSkge1xuICAgICAgICAgICAgdGhyb3cgbmV3IFR5cGVFcnJvcignXCJsZW5ndGhcIiBpcyBub3QgZ3JlYXRlciB0aGFuIDAnKTtcbiAgICAgICAgfVxuICAgICAgICB0aGlzLmxlbmd0aCA9IG9wdGlvbnMubGVuZ3RoO1xuICAgICAgICB0aGlzLnBvc2l0aW9uID0gMDtcbiAgICAgICAgdGhpcy5idWZmZXIgPSBCdWZmZXIuYWxsb2ModGhpcy5sZW5ndGgpO1xuICAgIH1cbiAgICBfdHJhbnNmb3JtKGNodW5rLCBfZW5jb2RpbmcsIGNiKSB7XG4gICAgICAgIGxldCBjdXJzb3IgPSAwO1xuICAgICAgICB3aGlsZSAoY3Vyc29yIDwgY2h1bmsubGVuZ3RoKSB7XG4gICAgICAgICAgICB0aGlzLmJ1ZmZlclt0aGlzLnBvc2l0aW9uXSA9IGNodW5rW2N1cnNvcl07XG4gICAgICAgICAgICBjdXJzb3IrKztcbiAgICAgICAgICAgIHRoaXMucG9zaXRpb24rKztcbiAgICAgICAgICAgIGlmICh0aGlzLnBvc2l0aW9uID09PSB0aGlzLmxlbmd0aCkge1xuICAgICAgICAgICAgICAgIHRoaXMucHVzaCh0aGlzLmJ1ZmZlcik7XG4gICAgICAgICAgICAgICAgdGhpcy5idWZmZXIgPSBCdWZmZXIuYWxsb2ModGhpcy5sZW5ndGgpO1xuICAgICAgICAgICAgICAgIHRoaXMucG9zaXRpb24gPSAwO1xuICAgICAgICAgICAgfVxuICAgICAgICB9XG4gICAgICAgIGNiKCk7XG4gICAgfVxuICAgIF9mbHVzaChjYikge1xuICAgICAgICB0aGlzLnB1c2godGhpcy5idWZmZXIuc2xpY2UoMCwgdGhpcy5wb3NpdGlvbikpO1xuICAgICAgICB0aGlzLmJ1ZmZlciA9IEJ1ZmZlci5hbGxvYyh0aGlzLmxlbmd0aCk7XG4gICAgICAgIGNiKCk7XG4gICAgfVxufVxuZXhwb3J0cy5CeXRlTGVuZ3RoUGFyc2VyID0gQnl0ZUxlbmd0aFBhcnNlcjtcbiIsIlwidXNlIHN0cmljdFwiO1xuT2JqZWN0LmRlZmluZVByb3BlcnR5KGV4cG9ydHMsIFwiX19lc01vZHVsZVwiLCB7IHZhbHVlOiB0cnVlIH0pO1xuZXhwb3J0cy5DQ1RhbGtQYXJzZXIgPSB2b2lkIDA7XG5jb25zdCBzdHJlYW1fMSA9IHJlcXVpcmUoXCJzdHJlYW1cIik7XG4vKipcbiAqIFBhcnNlIHRoZSBDQ1RhbGsgcHJvdG9jb2xcbiAqIEBleHRlbmRzIFRyYW5zZm9ybVxuICpcbiAqIEEgdHJhbnNmb3JtIHN0cmVhbSB0aGF0IGVtaXRzIENDVGFsayBwYWNrZXRzIGFzIHRoZXkgYXJlIHJlY2VpdmVkLlxuICovXG5jbGFzcyBDQ1RhbGtQYXJzZXIgZXh0ZW5kcyBzdHJlYW1fMS5UcmFuc2Zvcm0ge1xuICAgIGNvbnN0cnVjdG9yKG1heERlbGF5QmV0d2VlbkJ5dGVzTXMgPSA1MCkge1xuICAgICAgICBzdXBlcigpO1xuICAgICAgICB0aGlzLmFycmF5ID0gW107XG4gICAgICAgIHRoaXMuY3Vyc29yID0gMDtcbiAgICAgICAgdGhpcy5sYXN0Qnl0ZUZldGNoVGltZSA9IDA7XG4gICAgICAgIHRoaXMubWF4RGVsYXlCZXR3ZWVuQnl0ZXNNcyA9IG1heERlbGF5QmV0d2VlbkJ5dGVzTXM7XG4gICAgfVxuICAgIF90cmFuc2Zvcm0oYnVmZmVyLCBlbmNvZGluZywgY2IpIHtcbiAgICAgICAgaWYgKHRoaXMubWF4RGVsYXlCZXR3ZWVuQnl0ZXNNcyA+IDApIHtcbiAgICAgICAgICAgIGNvbnN0IG5vdyA9IERhdGUubm93KCk7XG4gICAgICAgICAgICBpZiAobm93IC0gdGhpcy5sYXN0Qnl0ZUZldGNoVGltZSA+IHRoaXMubWF4RGVsYXlCZXR3ZWVuQnl0ZXNNcykge1xuICAgICAgICAgICAgICAgIHRoaXMuYXJyYXkgPSBbXTtcbiAgICAgICAgICAgICAgICB0aGlzLmN1cnNvciA9IDA7XG4gICAgICAgICAgICB9XG4gICAgICAgICAgICB0aGlzLmxhc3RCeXRlRmV0Y2hUaW1lID0gbm93O1xuICAgICAgICB9XG4gICAgICAgIHRoaXMuY3Vyc29yICs9IGJ1ZmZlci5sZW5ndGg7XG4gICAgICAgIC8vIFRPRE86IEJldHRlciBGYXN0ZXIgZXM3IG5vIHN1cHBvcnRlZCBieSBub2RlIDRcbiAgICAgICAgLy8gRVM3IGFsbG93cyBkaXJlY3RseSBwdXNoIFsuLi5idWZmZXJdXG4gICAgICAgIC8vIHRoaXMuYXJyYXkgPSB0aGlzLmFycmF5LmNvbmNhdChBcnJheS5mcm9tKGJ1ZmZlcikpIC8vU2xvd2VyID8hP1xuICAgICAgICBBcnJheS5mcm9tKGJ1ZmZlcikubWFwKGJ5dGUgPT4gdGhpcy5hcnJheS5wdXNoKGJ5dGUpKTtcbiAgICAgICAgd2hpbGUgKHRoaXMuY3Vyc29yID4gMSAmJiB0aGlzLmN1cnNvciA+PSB0aGlzLmFycmF5WzFdICsgNSkge1xuICAgICAgICAgICAgLy8gZnVsbCBmcmFtZSBhY2N1bXVsYXRlZFxuICAgICAgICAgICAgLy8gY29weSBjb21tYW5kIGZyb20gdGhlIGFycmF5XG4gICAgICAgICAgICBjb25zdCBGdWxsTXNnTGVuZ3RoID0gdGhpcy5hcnJheVsxXSArIDU7XG4gICAgICAgICAgICBjb25zdCBmcmFtZSA9IEJ1ZmZlci5mcm9tKHRoaXMuYXJyYXkuc2xpY2UoMCwgRnVsbE1zZ0xlbmd0aCkpO1xuICAgICAgICAgICAgLy8gUHJlc2VydmUgRXh0cmEgRGF0YVxuICAgICAgICAgICAgdGhpcy5hcnJheSA9IHRoaXMuYXJyYXkuc2xpY2UoZnJhbWUubGVuZ3RoLCB0aGlzLmFycmF5Lmxlbmd0aCk7XG4gICAgICAgICAgICB0aGlzLmN1cnNvciAtPSBGdWxsTXNnTGVuZ3RoO1xuICAgICAgICAgICAgdGhpcy5wdXNoKGZyYW1lKTtcbiAgICAgICAgfVxuICAgICAgICBjYigpO1xuICAgIH1cbn1cbmV4cG9ydHMuQ0NUYWxrUGFyc2VyID0gQ0NUYWxrUGFyc2VyO1xuIiwiXCJ1c2Ugc3RyaWN0XCI7XG5PYmplY3QuZGVmaW5lUHJvcGVydHkoZXhwb3J0cywgXCJfX2VzTW9kdWxlXCIsIHsgdmFsdWU6IHRydWUgfSk7XG5leHBvcnRzLkRlbGltaXRlclBhcnNlciA9IHZvaWQgMDtcbmNvbnN0IHN0cmVhbV8xID0gcmVxdWlyZShcInN0cmVhbVwiKTtcbi8qKlxuICogQSB0cmFuc2Zvcm0gc3RyZWFtIHRoYXQgZW1pdHMgZGF0YSBlYWNoIHRpbWUgYSBieXRlIHNlcXVlbmNlIGlzIHJlY2VpdmVkLlxuICogQGV4dGVuZHMgVHJhbnNmb3JtXG4gKlxuICogVG8gdXNlIHRoZSBgRGVsaW1pdGVyYCBwYXJzZXIsIHByb3ZpZGUgYSBkZWxpbWl0ZXIgYXMgYSBzdHJpbmcsIGJ1ZmZlciwgb3IgYXJyYXkgb2YgYnl0ZXMuIFJ1bnMgaW4gTyhuKSB0aW1lLlxuICovXG5jbGFzcyBEZWxpbWl0ZXJQYXJzZXIgZXh0ZW5kcyBzdHJlYW1fMS5UcmFuc2Zvcm0ge1xuICAgIGNvbnN0cnVjdG9yKHsgZGVsaW1pdGVyLCBpbmNsdWRlRGVsaW1pdGVyID0gZmFsc2UsIC4uLm9wdGlvbnMgfSkge1xuICAgICAgICBzdXBlcihvcHRpb25zKTtcbiAgICAgICAgaWYgKGRlbGltaXRlciA9PT0gdW5kZWZpbmVkKSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgVHlwZUVycm9yKCdcImRlbGltaXRlclwiIGlzIG5vdCBhIGJ1ZmZlcmFibGUgb2JqZWN0Jyk7XG4gICAgICAgIH1cbiAgICAgICAgaWYgKGRlbGltaXRlci5sZW5ndGggPT09IDApIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBUeXBlRXJyb3IoJ1wiZGVsaW1pdGVyXCIgaGFzIGEgMCBvciB1bmRlZmluZWQgbGVuZ3RoJyk7XG4gICAgICAgIH1cbiAgICAgICAgdGhpcy5pbmNsdWRlRGVsaW1pdGVyID0gaW5jbHVkZURlbGltaXRlcjtcbiAgICAgICAgdGhpcy5kZWxpbWl0ZXIgPSBCdWZmZXIuZnJvbShkZWxpbWl0ZXIpO1xuICAgICAgICB0aGlzLmJ1ZmZlciA9IEJ1ZmZlci5hbGxvYygwKTtcbiAgICB9XG4gICAgX3RyYW5zZm9ybShjaHVuaywgZW5jb2RpbmcsIGNiKSB7XG4gICAgICAgIGxldCBkYXRhID0gQnVmZmVyLmNvbmNhdChbdGhpcy5idWZmZXIsIGNodW5rXSk7XG4gICAgICAgIGxldCBwb3NpdGlvbjtcbiAgICAgICAgd2hpbGUgKChwb3NpdGlvbiA9IGRhdGEuaW5kZXhPZih0aGlzLmRlbGltaXRlcikpICE9PSAtMSkge1xuICAgICAgICAgICAgdGhpcy5wdXNoKGRhdGEuc2xpY2UoMCwgcG9zaXRpb24gKyAodGhpcy5pbmNsdWRlRGVsaW1pdGVyID8gdGhpcy5kZWxpbWl0ZXIubGVuZ3RoIDogMCkpKTtcbiAgICAgICAgICAgIGRhdGEgPSBkYXRhLnNsaWNlKHBvc2l0aW9uICsgdGhpcy5kZWxpbWl0ZXIubGVuZ3RoKTtcbiAgICAgICAgfVxuICAgICAgICB0aGlzLmJ1ZmZlciA9IGRhdGE7XG4gICAgICAgIGNiKCk7XG4gICAgfVxuICAgIF9mbHVzaChjYikge1xuICAgICAgICB0aGlzLnB1c2godGhpcy5idWZmZXIpO1xuICAgICAgICB0aGlzLmJ1ZmZlciA9IEJ1ZmZlci5hbGxvYygwKTtcbiAgICAgICAgY2IoKTtcbiAgICB9XG59XG5leHBvcnRzLkRlbGltaXRlclBhcnNlciA9IERlbGltaXRlclBhcnNlcjtcbiIsIlwidXNlIHN0cmljdFwiO1xuT2JqZWN0LmRlZmluZVByb3BlcnR5KGV4cG9ydHMsIFwiX19lc01vZHVsZVwiLCB7IHZhbHVlOiB0cnVlIH0pO1xuZXhwb3J0cy5JbnRlckJ5dGVUaW1lb3V0UGFyc2VyID0gdm9pZCAwO1xuY29uc3Qgc3RyZWFtXzEgPSByZXF1aXJlKFwic3RyZWFtXCIpO1xuLyoqXG4gKiBBIHRyYW5zZm9ybSBzdHJlYW0gdGhhdCBidWZmZXJzIGRhdGEgYW5kIGVtaXRzIGl0IGFmdGVyIG5vdCByZWNlaXZpbmcgYW55IGJ5dGVzIGZvciB0aGUgc3BlY2lmaWVkIGFtb3VudCBvZiB0aW1lIG9yIGhpdHRpbmcgYSBtYXggYnVmZmVyIHNpemUuXG4gKi9cbmNsYXNzIEludGVyQnl0ZVRpbWVvdXRQYXJzZXIgZXh0ZW5kcyBzdHJlYW1fMS5UcmFuc2Zvcm0ge1xuICAgIGNvbnN0cnVjdG9yKHsgbWF4QnVmZmVyU2l6ZSA9IDY1NTM2LCBpbnRlcnZhbCwgLi4udHJhbnNmb3JtT3B0aW9ucyB9KSB7XG4gICAgICAgIHN1cGVyKHRyYW5zZm9ybU9wdGlvbnMpO1xuICAgICAgICBpZiAoIWludGVydmFsKSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgVHlwZUVycm9yKCdcImludGVydmFsXCIgaXMgcmVxdWlyZWQnKTtcbiAgICAgICAgfVxuICAgICAgICBpZiAodHlwZW9mIGludGVydmFsICE9PSAnbnVtYmVyJyB8fCBOdW1iZXIuaXNOYU4oaW50ZXJ2YWwpKSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgVHlwZUVycm9yKCdcImludGVydmFsXCIgaXMgbm90IGEgbnVtYmVyJyk7XG4gICAgICAgIH1cbiAgICAgICAgaWYgKGludGVydmFsIDwgMSkge1xuICAgICAgICAgICAgdGhyb3cgbmV3IFR5cGVFcnJvcignXCJpbnRlcnZhbFwiIGlzIG5vdCBncmVhdGVyIHRoYW4gMCcpO1xuICAgICAgICB9XG4gICAgICAgIGlmICh0eXBlb2YgbWF4QnVmZmVyU2l6ZSAhPT0gJ251bWJlcicgfHwgTnVtYmVyLmlzTmFOKG1heEJ1ZmZlclNpemUpKSB7XG4gICAgICAgICAgICB0aHJvdyBuZXcgVHlwZUVycm9yKCdcIm1heEJ1ZmZlclNpemVcIiBpcyBub3QgYSBudW1iZXInKTtcbiAgICAgICAgfVxuICAgICAgICBpZiAobWF4QnVmZmVyU2l6ZSA8IDEpIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBUeXBlRXJyb3IoJ1wibWF4QnVmZmVyU2l6ZVwiIGlzIG5vdCBncmVhdGVyIHRoYW4gMCcpO1xuICAgICAgICB9XG4gICAgICAgIHRoaXMubWF4QnVmZmVyU2l6ZSA9IG1heEJ1ZmZlclNpemU7XG4gICAgICAgIHRoaXMuY3VycmVudFBhY2tldCA9IFtdO1xuICAgICAgICB0aGlzLmludGVydmFsID0gaW50ZXJ2YWw7XG4gICAgfVxuICAgIF90cmFuc2Zvcm0oY2h1bmssIGVuY29kaW5nLCBjYikge1xuICAgICAgICBpZiAodGhpcy5pbnRlcnZhbElEKSB7XG4gICAgICAgICAgICBjbGVhclRpbWVvdXQodGhpcy5pbnRlcnZhbElEKTtcbiAgICAgICAgfVxuICAgICAgICBmb3IgKGxldCBvZmZzZXQgPSAwOyBvZmZzZXQgPCBjaHVuay5sZW5ndGg7IG9mZnNldCsrKSB7XG4gICAgICAgICAgICB0aGlzLmN1cnJlbnRQYWNrZXQucHVzaChjaHVua1tvZmZzZXRdKTtcbiAgICAgICAgICAgIGlmICh0aGlzLmN1cnJlbnRQYWNrZXQubGVuZ3RoID49IHRoaXMubWF4QnVmZmVyU2l6ZSkge1xuICAgICAgICAgICAgICAgIHRoaXMuZW1pdFBhY2tldCgpO1xuICAgICAgICAgICAgfVxuICAgICAgICB9XG4gICAgICAgIHRoaXMuaW50ZXJ2YWxJRCA9IHNldFRpbWVvdXQodGhpcy5lbWl0UGFja2V0LmJpbmQodGhpcyksIHRoaXMuaW50ZXJ2YWwpO1xuICAgICAgICBjYigpO1xuICAgIH1cbiAgICBlbWl0UGFja2V0KCkge1xuICAgICAgICBpZiAodGhpcy5pbnRlcnZhbElEKSB7XG4gICAgICAgICAgICBjbGVhclRpbWVvdXQodGhpcy5pbnRlcnZhbElEKTtcbiAgICAgICAgfVxuICAgICAgICBpZiAodGhpcy5jdXJyZW50UGFja2V0Lmxlbmd0aCA+IDApIHtcbiAgICAgICAgICAgIHRoaXMucHVzaChCdWZmZXIuZnJvbSh0aGlzLmN1cnJlbnRQYWNrZXQpKTtcbiAgICAgICAgfVxuICAgICAgICB0aGlzLmN1cnJlbnRQYWNrZXQgPSBbXTtcbiAgICB9XG4gICAgX2ZsdXNoKGNiKSB7XG4gICAgICAgIHRoaXMuZW1pdFBhY2tldCgpO1xuICAgICAgICBjYigpO1xuICAgIH1cbn1cbmV4cG9ydHMuSW50ZXJCeXRlVGltZW91dFBhcnNlciA9IEludGVyQnl0ZVRpbWVvdXRQYXJzZXI7XG4iLCJcInVzZSBzdHJpY3RcIjtcbk9iamVjdC5kZWZpbmVQcm9wZXJ0eShleHBvcnRzLCBcIl9fZXNNb2R1bGVcIiwgeyB2YWx1ZTogdHJ1ZSB9KTtcbmV4cG9ydHMuUGFja2V0TGVuZ3RoUGFyc2VyID0gdm9pZCAwO1xuY29uc3Qgc3RyZWFtXzEgPSByZXF1aXJlKFwic3RyZWFtXCIpO1xuLyoqXG4gKiBBIHRyYW5zZm9ybSBzdHJlYW0gdGhhdCBkZWNvZGVzIHBhY2tldHMgd2l0aCBhIGRlbGltaXRlciBhbmQgbGVuZ3RoIG9mIHBheWxvYWRcbiAqIHNwZWNpZmllZCB3aXRoaW4gdGhlIGRhdGEgc3RyZWFtLlxuICogQGV4dGVuZHMgVHJhbnNmb3JtXG4gKiBAc3VtbWFyeSBEZWNvZGVzIHBhY2tldHMgb2YgdGhlIGdlbmVyYWwgZm9ybTpcbiAqICAgICAgIFtkZWxpbWl0ZXJdW2xlbl1bcGF5bG9hZDBdIC4uLiBbcGF5bG9hZDAgKyBsZW5dXG4gKlxuICogVGhlIGxlbmd0aCBmaWVsZCBjYW4gYmUgdXAgdG8gNCBieXRlcyBhbmQgY2FuIGJlIGF0IGFueSBvZmZzZXQgd2l0aGluIHRoZSBwYWNrZXRcbiAqICAgICAgIFtkZWxpbWl0ZXJdW2hlYWRlcjBdW2hlYWRlcjFdW2xlbjBdW2xlbjFbcGF5bG9hZDBdIC4uLiBbcGF5bG9hZDAgKyBsZW5dXG4gKlxuICogVGhlIG9mZnNldCBhbmQgbnVtYmVyIG9mIGJ5dGVzIG9mIHRoZSBsZW5ndGggZmllbGQgbmVlZCB0byBiZSBwcm92aWRlZCBpbiBvcHRpb25zXG4gKiBpZiBub3QgMSBieXRlIGltbWVkaWF0ZWx5IGZvbGxvd2luZyB0aGUgZGVsaW1pdGVyLlxuICovXG5jbGFzcyBQYWNrZXRMZW5ndGhQYXJzZXIgZXh0ZW5kcyBzdHJlYW1fMS5UcmFuc2Zvcm0ge1xuICAgIGNvbnN0cnVjdG9yKG9wdGlvbnMgPSB7fSkge1xuICAgICAgICBzdXBlcihvcHRpb25zKTtcbiAgICAgICAgY29uc3QgeyBkZWxpbWl0ZXIgPSAweGFhLCBwYWNrZXRPdmVyaGVhZCA9IDIsIGxlbmd0aEJ5dGVzID0gMSwgbGVuZ3RoT2Zmc2V0ID0gMSwgbWF4TGVuID0gMHhmZiB9ID0gb3B0aW9ucztcbiAgICAgICAgdGhpcy5vcHRzID0ge1xuICAgICAgICAgICAgZGVsaW1pdGVyLFxuICAgICAgICAgICAgcGFja2V0T3ZlcmhlYWQsXG4gICAgICAgICAgICBsZW5ndGhCeXRlcyxcbiAgICAgICAgICAgIGxlbmd0aE9mZnNldCxcbiAgICAgICAgICAgIG1heExlbixcbiAgICAgICAgfTtcbiAgICAgICAgdGhpcy5idWZmZXIgPSBCdWZmZXIuYWxsb2MoMCk7XG4gICAgICAgIHRoaXMuc3RhcnQgPSBmYWxzZTtcbiAgICB9XG4gICAgX3RyYW5zZm9ybShjaHVuaywgZW5jb2RpbmcsIGNiKSB7XG4gICAgICAgIGZvciAobGV0IG5keCA9IDA7IG5keCA8IGNodW5rLmxlbmd0aDsgbmR4KyspIHtcbiAgICAgICAgICAgIGNvbnN0IGJ5dGUgPSBjaHVua1tuZHhdO1xuICAgICAgICAgICAgaWYgKGJ5dGUgPT09IHRoaXMub3B0cy5kZWxpbWl0ZXIpIHtcbiAgICAgICAgICAgICAgICB0aGlzLnN0YXJ0ID0gdHJ1ZTtcbiAgICAgICAgICAgIH1cbiAgICAgICAgICAgIGlmICh0cnVlID09PSB0aGlzLnN0YXJ0KSB7XG4gICAgICAgICAgICAgICAgdGhpcy5idWZmZXIgPSBCdWZmZXIuY29uY2F0KFt0aGlzLmJ1ZmZlciwgQnVmZmVyLmZyb20oW2J5dGVdKV0pO1xuICAgICAgICAgICAgICAgIGlmICh0aGlzLmJ1ZmZlci5sZW5ndGggPj0gdGhpcy5vcHRzLmxlbmd0aE9mZnNldCArIHRoaXMub3B0cy5sZW5ndGhCeXRlcykge1xuICAgICAgICAgICAgICAgICAgICBjb25zdCBsZW4gPSB0aGlzLmJ1ZmZlci5yZWFkVUludExFKHRoaXMub3B0cy5sZW5ndGhPZmZzZXQsIHRoaXMub3B0cy5sZW5ndGhCeXRlcyk7XG4gICAgICAgICAgICAgICAgICAgIGlmICh0aGlzLmJ1ZmZlci5sZW5ndGggPT0gbGVuICsgdGhpcy5vcHRzLnBhY2tldE92ZXJoZWFkIHx8IGxlbiA+IHRoaXMub3B0cy5tYXhMZW4pIHtcbiAgICAgICAgICAgICAgICAgICAgICAgIHRoaXMucHVzaCh0aGlzLmJ1ZmZlcik7XG4gICAgICAgICAgICAgICAgICAgICAgICB0aGlzLmJ1ZmZlciA9IEJ1ZmZlci5hbGxvYygwKTtcbiAgICAgICAgICAgICAgICAgICAgICAgIHRoaXMuc3RhcnQgPSBmYWxzZTtcbiAgICAgICAgICAgICAgICAgICAgfVxuICAgICAgICAgICAgICAgIH1cbiAgICAgICAgICAgIH1cbiAgICAgICAgfVxuICAgICAgICBjYigpO1xuICAgIH1cbiAgICBfZmx1c2goY2IpIHtcbiAgICAgICAgdGhpcy5wdXNoKHRoaXMuYnVmZmVyKTtcbiAgICAgICAgdGhpcy5idWZmZXIgPSBCdWZmZXIuYWxsb2MoMCk7XG4gICAgICAgIGNiKCk7XG4gICAgfVxufVxuZXhwb3J0cy5QYWNrZXRMZW5ndGhQYXJzZXIgPSBQYWNrZXRMZW5ndGhQYXJzZXI7XG4iLCJcInVzZSBzdHJpY3RcIjtcbk9iamVjdC5kZWZpbmVQcm9wZXJ0eShleHBvcnRzLCBcIl9fZXNNb2R1bGVcIiwgeyB2YWx1ZTogdHJ1ZSB9KTtcbmV4cG9ydHMuUmVhZGxpbmVQYXJzZXIgPSB2b2lkIDA7XG5jb25zdCBwYXJzZXJfZGVsaW1pdGVyXzEgPSByZXF1aXJlKFwiQHNlcmlhbHBvcnQvcGFyc2VyLWRlbGltaXRlclwiKTtcbi8qKlxuICogIEEgdHJhbnNmb3JtIHN0cmVhbSB0aGF0IGVtaXRzIGRhdGEgYWZ0ZXIgYSBuZXdsaW5lIGRlbGltaXRlciBpcyByZWNlaXZlZC5cbiAqIEBzdW1tYXJ5IFRvIHVzZSB0aGUgYFJlYWRsaW5lYCBwYXJzZXIsIHByb3ZpZGUgYSBkZWxpbWl0ZXIgKGRlZmF1bHRzIHRvIGBcXG5gKS4gRGF0YSBpcyBlbWl0dGVkIGFzIHN0cmluZyBjb250cm9sbGFibGUgYnkgdGhlIGBlbmNvZGluZ2Agb3B0aW9uIChkZWZhdWx0cyB0byBgdXRmOGApLlxuICovXG5jbGFzcyBSZWFkbGluZVBhcnNlciBleHRlbmRzIHBhcnNlcl9kZWxpbWl0ZXJfMS5EZWxpbWl0ZXJQYXJzZXIge1xuICAgIGNvbnN0cnVjdG9yKG9wdGlvbnMpIHtcbiAgICAgICAgY29uc3Qgb3B0cyA9IHtcbiAgICAgICAgICAgIGRlbGltaXRlcjogQnVmZmVyLmZyb20oJ1xcbicsICd1dGY4JyksXG4gICAgICAgICAgICBlbmNvZGluZzogJ3V0ZjgnLFxuICAgICAgICAgICAgLi4ub3B0aW9ucyxcbiAgICAgICAgfTtcbiAgICAgICAgaWYgKHR5cGVvZiBvcHRzLmRlbGltaXRlciA9PT0gJ3N0cmluZycpIHtcbiAgICAgICAgICAgIG9wdHMuZGVsaW1pdGVyID0gQnVmZmVyLmZyb20ob3B0cy5kZWxpbWl0ZXIsIG9wdHMuZW5jb2RpbmcpO1xuICAgICAgICB9XG4gICAgICAgIHN1cGVyKG9wdHMpO1xuICAgIH1cbn1cbmV4cG9ydHMuUmVhZGxpbmVQYXJzZXIgPSBSZWFkbGluZVBhcnNlcjtcbiIsIlwidXNlIHN0cmljdFwiO1xuT2JqZWN0LmRlZmluZVByb3BlcnR5KGV4cG9ydHMsIFwiX19lc01vZHVsZVwiLCB7IHZhbHVlOiB0cnVlIH0pO1xuZXhwb3J0cy5SZWFkeVBhcnNlciA9IHZvaWQgMDtcbmNvbnN0IHN0cmVhbV8xID0gcmVxdWlyZShcInN0cmVhbVwiKTtcbi8qKlxuICogQSB0cmFuc2Zvcm0gc3RyZWFtIHRoYXQgd2FpdHMgZm9yIGEgc2VxdWVuY2Ugb2YgXCJyZWFkeVwiIGJ5dGVzIGJlZm9yZSBlbWl0dGluZyBhIHJlYWR5IGV2ZW50IGFuZCBlbWl0dGluZyBkYXRhIGV2ZW50c1xuICpcbiAqIFRvIHVzZSB0aGUgYFJlYWR5YCBwYXJzZXIgcHJvdmlkZSBhIGJ5dGUgc3RhcnQgc2VxdWVuY2UuIEFmdGVyIHRoZSBieXRlcyBoYXZlIGJlZW4gcmVjZWl2ZWQgYSByZWFkeSBldmVudCBpcyBmaXJlZCBhbmQgZGF0YSBldmVudHMgYXJlIHBhc3NlZCB0aHJvdWdoLlxuICovXG5jbGFzcyBSZWFkeVBhcnNlciBleHRlbmRzIHN0cmVhbV8xLlRyYW5zZm9ybSB7XG4gICAgY29uc3RydWN0b3IoeyBkZWxpbWl0ZXIsIC4uLm9wdGlvbnMgfSkge1xuICAgICAgICBpZiAoZGVsaW1pdGVyID09PSB1bmRlZmluZWQpIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBUeXBlRXJyb3IoJ1wiZGVsaW1pdGVyXCIgaXMgbm90IGEgYnVmZmVyYWJsZSBvYmplY3QnKTtcbiAgICAgICAgfVxuICAgICAgICBpZiAoZGVsaW1pdGVyLmxlbmd0aCA9PT0gMCkge1xuICAgICAgICAgICAgdGhyb3cgbmV3IFR5cGVFcnJvcignXCJkZWxpbWl0ZXJcIiBoYXMgYSAwIG9yIHVuZGVmaW5lZCBsZW5ndGgnKTtcbiAgICAgICAgfVxuICAgICAgICBzdXBlcihvcHRpb25zKTtcbiAgICAgICAgdGhpcy5kZWxpbWl0ZXIgPSBCdWZmZXIuZnJvbShkZWxpbWl0ZXIpO1xuICAgICAgICB0aGlzLnJlYWRPZmZzZXQgPSAwO1xuICAgICAgICB0aGlzLnJlYWR5ID0gZmFsc2U7XG4gICAgfVxuICAgIF90cmFuc2Zvcm0oY2h1bmssIGVuY29kaW5nLCBjYikge1xuICAgICAgICBpZiAodGhpcy5yZWFkeSkge1xuICAgICAgICAgICAgdGhpcy5wdXNoKGNodW5rKTtcbiAgICAgICAgICAgIHJldHVybiBjYigpO1xuICAgICAgICB9XG4gICAgICAgIGNvbnN0IGRlbGltaXRlciA9IHRoaXMuZGVsaW1pdGVyO1xuICAgICAgICBsZXQgY2h1bmtPZmZzZXQgPSAwO1xuICAgICAgICB3aGlsZSAodGhpcy5yZWFkT2Zmc2V0IDwgZGVsaW1pdGVyLmxlbmd0aCAmJiBjaHVua09mZnNldCA8IGNodW5rLmxlbmd0aCkge1xuICAgICAgICAgICAgaWYgKGRlbGltaXRlclt0aGlzLnJlYWRPZmZzZXRdID09PSBjaHVua1tjaHVua09mZnNldF0pIHtcbiAgICAgICAgICAgICAgICB0aGlzLnJlYWRPZmZzZXQrKztcbiAgICAgICAgICAgIH1cbiAgICAgICAgICAgIGVsc2Uge1xuICAgICAgICAgICAgICAgIHRoaXMucmVhZE9mZnNldCA9IDA7XG4gICAgICAgICAgICB9XG4gICAgICAgICAgICBjaHVua09mZnNldCsrO1xuICAgICAgICB9XG4gICAgICAgIGlmICh0aGlzLnJlYWRPZmZzZXQgPT09IGRlbGltaXRlci5sZW5ndGgpIHtcbiAgICAgICAgICAgIHRoaXMucmVhZHkgPSB0cnVlO1xuICAgICAgICAgICAgdGhpcy5lbWl0KCdyZWFkeScpO1xuICAgICAgICAgICAgY29uc3QgY2h1bmtSZXN0ID0gY2h1bmsuc2xpY2UoY2h1bmtPZmZzZXQpO1xuICAgICAgICAgICAgaWYgKGNodW5rUmVzdC5sZW5ndGggPiAwKSB7XG4gICAgICAgICAgICAgICAgdGhpcy5wdXNoKGNodW5rUmVzdCk7XG4gICAgICAgICAgICB9XG4gICAgICAgIH1cbiAgICAgICAgY2IoKTtcbiAgICB9XG59XG5leHBvcnRzLlJlYWR5UGFyc2VyID0gUmVhZHlQYXJzZXI7XG4iLCJcInVzZSBzdHJpY3RcIjtcbk9iamVjdC5kZWZpbmVQcm9wZXJ0eShleHBvcnRzLCBcIl9fZXNNb2R1bGVcIiwgeyB2YWx1ZTogdHJ1ZSB9KTtcbmV4cG9ydHMuUmVnZXhQYXJzZXIgPSB2b2lkIDA7XG5jb25zdCBzdHJlYW1fMSA9IHJlcXVpcmUoXCJzdHJlYW1cIik7XG4vKipcbiAqIEEgdHJhbnNmb3JtIHN0cmVhbSB0aGF0IHVzZXMgYSByZWd1bGFyIGV4cHJlc3Npb24gdG8gc3BsaXQgdGhlIGluY29taW5nIHRleHQgdXBvbi5cbiAqXG4gKiBUbyB1c2UgdGhlIGBSZWdleGAgcGFyc2VyIHByb3ZpZGUgYSByZWd1bGFyIGV4cHJlc3Npb24gdG8gc3BsaXQgdGhlIGluY29taW5nIHRleHQgdXBvbi4gRGF0YSBpcyBlbWl0dGVkIGFzIHN0cmluZyBjb250cm9sbGFibGUgYnkgdGhlIGBlbmNvZGluZ2Agb3B0aW9uIChkZWZhdWx0cyB0byBgdXRmOGApLlxuICovXG5jbGFzcyBSZWdleFBhcnNlciBleHRlbmRzIHN0cmVhbV8xLlRyYW5zZm9ybSB7XG4gICAgY29uc3RydWN0b3IoeyByZWdleCwgLi4ub3B0aW9ucyB9KSB7XG4gICAgICAgIGNvbnN0IG9wdHMgPSB7XG4gICAgICAgICAgICBlbmNvZGluZzogJ3V0ZjgnLFxuICAgICAgICAgICAgLi4ub3B0aW9ucyxcbiAgICAgICAgfTtcbiAgICAgICAgaWYgKHJlZ2V4ID09PSB1bmRlZmluZWQpIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBUeXBlRXJyb3IoJ1wib3B0aW9ucy5yZWdleFwiIG11c3QgYmUgYSByZWd1bGFyIGV4cHJlc3Npb24gcGF0dGVybiBvciBvYmplY3QnKTtcbiAgICAgICAgfVxuICAgICAgICBpZiAoIShyZWdleCBpbnN0YW5jZW9mIFJlZ0V4cCkpIHtcbiAgICAgICAgICAgIHJlZ2V4ID0gbmV3IFJlZ0V4cChyZWdleC50b1N0cmluZygpKTtcbiAgICAgICAgfVxuICAgICAgICBzdXBlcihvcHRzKTtcbiAgICAgICAgdGhpcy5yZWdleCA9IHJlZ2V4O1xuICAgICAgICB0aGlzLmRhdGEgPSAnJztcbiAgICB9XG4gICAgX3RyYW5zZm9ybShjaHVuaywgZW5jb2RpbmcsIGNiKSB7XG4gICAgICAgIGNvbnN0IGRhdGEgPSB0aGlzLmRhdGEgKyBjaHVuaztcbiAgICAgICAgY29uc3QgcGFydHMgPSBkYXRhLnNwbGl0KHRoaXMucmVnZXgpO1xuICAgICAgICB0aGlzLmRhdGEgPSBwYXJ0cy5wb3AoKSB8fCAnJztcbiAgICAgICAgcGFydHMuZm9yRWFjaChwYXJ0ID0+IHtcbiAgICAgICAgICAgIHRoaXMucHVzaChwYXJ0KTtcbiAgICAgICAgfSk7XG4gICAgICAgIGNiKCk7XG4gICAgfVxuICAgIF9mbHVzaChjYikge1xuICAgICAgICB0aGlzLnB1c2godGhpcy5kYXRhKTtcbiAgICAgICAgdGhpcy5kYXRhID0gJyc7XG4gICAgICAgIGNiKCk7XG4gICAgfVxufVxuZXhwb3J0cy5SZWdleFBhcnNlciA9IFJlZ2V4UGFyc2VyO1xuIiwiXCJ1c2Ugc3RyaWN0XCI7XG5PYmplY3QuZGVmaW5lUHJvcGVydHkoZXhwb3J0cywgXCJfX2VzTW9kdWxlXCIsIHsgdmFsdWU6IHRydWUgfSk7XG5leHBvcnRzLlNsaXBEZWNvZGVyID0gdm9pZCAwO1xuY29uc3Qgc3RyZWFtXzEgPSByZXF1aXJlKFwic3RyZWFtXCIpO1xuLyoqXG4gKiBBIHRyYW5zZm9ybSBzdHJlYW0gdGhhdCBkZWNvZGVzIHNsaXAgZW5jb2RlZCBkYXRhLlxuICogQGV4dGVuZHMgVHJhbnNmb3JtXG4gKlxuICogUnVucyBpbiBPKG4pIHRpbWUsIHN0cmlwcGluZyBvdXQgc2xpcCBlbmNvZGluZyBhbmQgZW1pdHRpbmcgZGVjb2RlZCBkYXRhLiBPcHRpb25hbGx5IGN1c3RvbSBzbGlwIGVzY2FwZSBhbmQgZGVsaW1pdGVycyBjYW4gYmUgcHJvdmlkZWQuXG4gKi9cbmNsYXNzIFNsaXBEZWNvZGVyIGV4dGVuZHMgc3RyZWFtXzEuVHJhbnNmb3JtIHtcbiAgICBjb25zdHJ1Y3RvcihvcHRpb25zID0ge30pIHtcbiAgICAgICAgc3VwZXIob3B0aW9ucyk7XG4gICAgICAgIGNvbnN0IHsgU1RBUlQsIEVTQyA9IDB4ZGIsIEVORCA9IDB4YzAsIEVTQ19TVEFSVCwgRVNDX0VORCA9IDB4ZGMsIEVTQ19FU0MgPSAweGRkIH0gPSBvcHRpb25zO1xuICAgICAgICB0aGlzLm9wdHMgPSB7XG4gICAgICAgICAgICBTVEFSVCxcbiAgICAgICAgICAgIEVTQyxcbiAgICAgICAgICAgIEVORCxcbiAgICAgICAgICAgIEVTQ19TVEFSVCxcbiAgICAgICAgICAgIEVTQ19FTkQsXG4gICAgICAgICAgICBFU0NfRVNDLFxuICAgICAgICB9O1xuICAgICAgICB0aGlzLmJ1ZmZlciA9IEJ1ZmZlci5hbGxvYygwKTtcbiAgICAgICAgdGhpcy5lc2NhcGUgPSBmYWxzZTtcbiAgICAgICAgdGhpcy5zdGFydCA9IGZhbHNlO1xuICAgIH1cbiAgICBfdHJhbnNmb3JtKGNodW5rLCBlbmNvZGluZywgY2IpIHtcbiAgICAgICAgZm9yIChsZXQgbmR4ID0gMDsgbmR4IDwgY2h1bmsubGVuZ3RoOyBuZHgrKykge1xuICAgICAgICAgICAgbGV0IGJ5dGUgPSBjaHVua1tuZHhdO1xuICAgICAgICAgICAgaWYgKGJ5dGUgPT09IHRoaXMub3B0cy5TVEFSVCkge1xuICAgICAgICAgICAgICAgIHRoaXMuc3RhcnQgPSB0cnVlO1xuICAgICAgICAgICAgICAgIGNvbnRpbnVlO1xuICAgICAgICAgICAgfVxuICAgICAgICAgICAgZWxzZSBpZiAodW5kZWZpbmVkID09IHRoaXMub3B0cy5TVEFSVCkge1xuICAgICAgICAgICAgICAgIHRoaXMuc3RhcnQgPSB0cnVlO1xuICAgICAgICAgICAgfVxuICAgICAgICAgICAgaWYgKHRoaXMuZXNjYXBlKSB7XG4gICAgICAgICAgICAgICAgaWYgKGJ5dGUgPT09IHRoaXMub3B0cy5FU0NfU1RBUlQgJiYgdGhpcy5vcHRzLlNUQVJUKSB7XG4gICAgICAgICAgICAgICAgICAgIGJ5dGUgPSB0aGlzLm9wdHMuU1RBUlQ7XG4gICAgICAgICAgICAgICAgfVxuICAgICAgICAgICAgICAgIGVsc2UgaWYgKGJ5dGUgPT09IHRoaXMub3B0cy5FU0NfRVNDKSB7XG4gICAgICAgICAgICAgICAgICAgIGJ5dGUgPSB0aGlzLm9wdHMuRVNDO1xuICAgICAgICAgICAgICAgIH1cbiAgICAgICAgICAgICAgICBlbHNlIGlmIChieXRlID09PSB0aGlzLm9wdHMuRVNDX0VORCkge1xuICAgICAgICAgICAgICAgICAgICBieXRlID0gdGhpcy5vcHRzLkVORDtcbiAgICAgICAgICAgICAgICB9XG4gICAgICAgICAgICAgICAgZWxzZSB7XG4gICAgICAgICAgICAgICAgICAgIHRoaXMuZXNjYXBlID0gZmFsc2U7XG4gICAgICAgICAgICAgICAgICAgIHRoaXMucHVzaCh0aGlzLmJ1ZmZlcik7XG4gICAgICAgICAgICAgICAgICAgIHRoaXMuYnVmZmVyID0gQnVmZmVyLmFsbG9jKDApO1xuICAgICAgICAgICAgICAgIH1cbiAgICAgICAgICAgIH1cbiAgICAgICAgICAgIGVsc2Uge1xuICAgICAgICAgICAgICAgIGlmIChieXRlID09PSB0aGlzLm9wdHMuRVNDKSB7XG4gICAgICAgICAgICAgICAgICAgIHRoaXMuZXNjYXBlID0gdHJ1ZTtcbiAgICAgICAgICAgICAgICAgICAgY29udGludWU7XG4gICAgICAgICAgICAgICAgfVxuICAgICAgICAgICAgICAgIGlmIChieXRlID09PSB0aGlzLm9wdHMuRU5EKSB7XG4gICAgICAgICAgICAgICAgICAgIHRoaXMucHVzaCh0aGlzLmJ1ZmZlcik7XG4gICAgICAgICAgICAgICAgICAgIHRoaXMuYnVmZmVyID0gQnVmZmVyLmFsbG9jKDApO1xuICAgICAgICAgICAgICAgICAgICB0aGlzLmVzY2FwZSA9IGZhbHNlO1xuICAgICAgICAgICAgICAgICAgICB0aGlzLnN0YXJ0ID0gZmFsc2U7XG4gICAgICAgICAgICAgICAgICAgIGNvbnRpbnVlO1xuICAgICAgICAgICAgICAgIH1cbiAgICAgICAgICAgIH1cbiAgICAgICAgICAgIHRoaXMuZXNjYXBlID0gZmFsc2U7XG4gICAgICAgICAgICBpZiAodGhpcy5zdGFydCkge1xuICAgICAgICAgICAgICAgIHRoaXMuYnVmZmVyID0gQnVmZmVyLmNvbmNhdChbdGhpcy5idWZmZXIsIEJ1ZmZlci5mcm9tKFtieXRlXSldKTtcbiAgICAgICAgICAgIH1cbiAgICAgICAgfVxuICAgICAgICBjYigpO1xuICAgIH1cbiAgICBfZmx1c2goY2IpIHtcbiAgICAgICAgdGhpcy5wdXNoKHRoaXMuYnVmZmVyKTtcbiAgICAgICAgdGhpcy5idWZmZXIgPSBCdWZmZXIuYWxsb2MoMCk7XG4gICAgICAgIGNiKCk7XG4gICAgfVxufVxuZXhwb3J0cy5TbGlwRGVjb2RlciA9IFNsaXBEZWNvZGVyO1xuIiwiXCJ1c2Ugc3RyaWN0XCI7XG5PYmplY3QuZGVmaW5lUHJvcGVydHkoZXhwb3J0cywgXCJfX2VzTW9kdWxlXCIsIHsgdmFsdWU6IHRydWUgfSk7XG5leHBvcnRzLlNsaXBFbmNvZGVyID0gdm9pZCAwO1xuY29uc3Qgc3RyZWFtXzEgPSByZXF1aXJlKFwic3RyZWFtXCIpO1xuLyoqXG4gKiBBIHRyYW5zZm9ybSBzdHJlYW0gdGhhdCBlbWl0cyBTTElQLWVuY29kZWQgZGF0YSBmb3IgZWFjaCBpbmNvbWluZyBwYWNrZXQuXG4gKlxuICogUnVucyBpbiBPKG4pIHRpbWUsIGFkZGluZyBhIDB4QzAgY2hhcmFjdGVyIGF0IHRoZSBlbmQgb2YgZWFjaFxuICogcmVjZWl2ZWQgcGFja2V0IGFuZCBlc2NhcGluZyBjaGFyYWN0ZXJzLCBhY2NvcmRpbmcgdG8gUkZDIDEwNTUuXG4gKi9cbmNsYXNzIFNsaXBFbmNvZGVyIGV4dGVuZHMgc3RyZWFtXzEuVHJhbnNmb3JtIHtcbiAgICBjb25zdHJ1Y3RvcihvcHRpb25zID0ge30pIHtcbiAgICAgICAgc3VwZXIob3B0aW9ucyk7XG4gICAgICAgIGNvbnN0IHsgU1RBUlQsIEVTQyA9IDB4ZGIsIEVORCA9IDB4YzAsIEVTQ19TVEFSVCwgRVNDX0VORCA9IDB4ZGMsIEVTQ19FU0MgPSAweGRkLCBibHVldG9vdGhRdWlyayA9IGZhbHNlIH0gPSBvcHRpb25zO1xuICAgICAgICB0aGlzLm9wdHMgPSB7XG4gICAgICAgICAgICBTVEFSVCxcbiAgICAgICAgICAgIEVTQyxcbiAgICAgICAgICAgIEVORCxcbiAgICAgICAgICAgIEVTQ19TVEFSVCxcbiAgICAgICAgICAgIEVTQ19FTkQsXG4gICAgICAgICAgICBFU0NfRVNDLFxuICAgICAgICAgICAgYmx1ZXRvb3RoUXVpcmssXG4gICAgICAgIH07XG4gICAgfVxuICAgIF90cmFuc2Zvcm0oY2h1bmssIGVuY29kaW5nLCBjYikge1xuICAgICAgICBjb25zdCBjaHVua0xlbmd0aCA9IGNodW5rLmxlbmd0aDtcbiAgICAgICAgaWYgKHRoaXMub3B0cy5ibHVldG9vdGhRdWlyayAmJiBjaHVua0xlbmd0aCA9PT0gMCkge1xuICAgICAgICAgICAgLy8gRWRnZSBjYXNlOiBwdXNoIG5vIGRhdGEuIEJsdWV0b290aC1xdWlya3kgU0xJUCBwYXJzZXJzIGRvbid0IGxpa2VcbiAgICAgICAgICAgIC8vIGxvdHMgb2YgMHhDMHMgdG9nZXRoZXIuXG4gICAgICAgICAgICByZXR1cm4gY2IoKTtcbiAgICAgICAgfVxuICAgICAgICAvLyBBbGxvY2F0ZSBtZW1vcnkgZm9yIHRoZSB3b3JzdC1jYXNlIHNjZW5hcmlvOiBhbGwgYnl0ZXMgYXJlIGVzY2FwZWQsXG4gICAgICAgIC8vIHBsdXMgc3RhcnQgYW5kIGVuZCBzZXBhcmF0b3JzLlxuICAgICAgICBjb25zdCBlbmNvZGVkID0gQnVmZmVyLmFsbG9jKGNodW5rTGVuZ3RoICogMiArIDIpO1xuICAgICAgICBsZXQgaiA9IDA7XG4gICAgICAgIGlmICh0aGlzLm9wdHMuYmx1ZXRvb3RoUXVpcmsgPT0gdHJ1ZSkge1xuICAgICAgICAgICAgZW5jb2RlZFtqKytdID0gdGhpcy5vcHRzLkVORDtcbiAgICAgICAgfVxuICAgICAgICBpZiAodGhpcy5vcHRzLlNUQVJUICE9PSB1bmRlZmluZWQpIHtcbiAgICAgICAgICAgIGVuY29kZWRbaisrXSA9IHRoaXMub3B0cy5TVEFSVDtcbiAgICAgICAgfVxuICAgICAgICBmb3IgKGxldCBpID0gMDsgaSA8IGNodW5rTGVuZ3RoOyBpKyspIHtcbiAgICAgICAgICAgIGxldCBieXRlID0gY2h1bmtbaV07XG4gICAgICAgICAgICBpZiAoYnl0ZSA9PT0gdGhpcy5vcHRzLlNUQVJUICYmIHRoaXMub3B0cy5FU0NfU1RBUlQpIHtcbiAgICAgICAgICAgICAgICBlbmNvZGVkW2orK10gPSB0aGlzLm9wdHMuRVNDO1xuICAgICAgICAgICAgICAgIGJ5dGUgPSB0aGlzLm9wdHMuRVNDX1NUQVJUO1xuICAgICAgICAgICAgfVxuICAgICAgICAgICAgZWxzZSBpZiAoYnl0ZSA9PT0gdGhpcy5vcHRzLkVORCkge1xuICAgICAgICAgICAgICAgIGVuY29kZWRbaisrXSA9IHRoaXMub3B0cy5FU0M7XG4gICAgICAgICAgICAgICAgYnl0ZSA9IHRoaXMub3B0cy5FU0NfRU5EO1xuICAgICAgICAgICAgfVxuICAgICAgICAgICAgZWxzZSBpZiAoYnl0ZSA9PT0gdGhpcy5vcHRzLkVTQykge1xuICAgICAgICAgICAgICAgIGVuY29kZWRbaisrXSA9IHRoaXMub3B0cy5FU0M7XG4gICAgICAgICAgICAgICAgYnl0ZSA9IHRoaXMub3B0cy5FU0NfRVNDO1xuICAgICAgICAgICAgfVxuICAgICAgICAgICAgZW5jb2RlZFtqKytdID0gYnl0ZTtcbiAgICAgICAgfVxuICAgICAgICBlbmNvZGVkW2orK10gPSB0aGlzLm9wdHMuRU5EO1xuICAgICAgICBjYihudWxsLCBlbmNvZGVkLnNsaWNlKDAsIGopKTtcbiAgICB9XG59XG5leHBvcnRzLlNsaXBFbmNvZGVyID0gU2xpcEVuY29kZXI7XG4iLCJcInVzZSBzdHJpY3RcIjtcbnZhciBfX2NyZWF0ZUJpbmRpbmcgPSAodGhpcyAmJiB0aGlzLl9fY3JlYXRlQmluZGluZykgfHwgKE9iamVjdC5jcmVhdGUgPyAoZnVuY3Rpb24obywgbSwgaywgazIpIHtcbiAgICBpZiAoazIgPT09IHVuZGVmaW5lZCkgazIgPSBrO1xuICAgIE9iamVjdC5kZWZpbmVQcm9wZXJ0eShvLCBrMiwgeyBlbnVtZXJhYmxlOiB0cnVlLCBnZXQ6IGZ1bmN0aW9uKCkgeyByZXR1cm4gbVtrXTsgfSB9KTtcbn0pIDogKGZ1bmN0aW9uKG8sIG0sIGssIGsyKSB7XG4gICAgaWYgKGsyID09PSB1bmRlZmluZWQpIGsyID0gaztcbiAgICBvW2syXSA9IG1ba107XG59KSk7XG52YXIgX19leHBvcnRTdGFyID0gKHRoaXMgJiYgdGhpcy5fX2V4cG9ydFN0YXIpIHx8IGZ1bmN0aW9uKG0sIGV4cG9ydHMpIHtcbiAgICBmb3IgKHZhciBwIGluIG0pIGlmIChwICE9PSBcImRlZmF1bHRcIiAmJiAhT2JqZWN0LnByb3RvdHlwZS5oYXNPd25Qcm9wZXJ0eS5jYWxsKGV4cG9ydHMsIHApKSBfX2NyZWF0ZUJpbmRpbmcoZXhwb3J0cywgbSwgcCk7XG59O1xuT2JqZWN0LmRlZmluZVByb3BlcnR5KGV4cG9ydHMsIFwiX19lc01vZHVsZVwiLCB7IHZhbHVlOiB0cnVlIH0pO1xuX19leHBvcnRTdGFyKHJlcXVpcmUoXCIuL2RlY29kZXJcIiksIGV4cG9ydHMpO1xuX19leHBvcnRTdGFyKHJlcXVpcmUoXCIuL2VuY29kZXJcIiksIGV4cG9ydHMpO1xuIiwiXCJ1c2Ugc3RyaWN0XCI7XG5PYmplY3QuZGVmaW5lUHJvcGVydHkoZXhwb3J0cywgXCJfX2VzTW9kdWxlXCIsIHsgdmFsdWU6IHRydWUgfSk7XG5leHBvcnRzLlNwYWNlUGFja2V0UGFyc2VyID0gdm9pZCAwO1xuY29uc3Qgc3RyZWFtXzEgPSByZXF1aXJlKFwic3RyZWFtXCIpO1xuY29uc3QgdXRpbHNfMSA9IHJlcXVpcmUoXCIuL3V0aWxzXCIpO1xuLyoqXG4gKiBBIFRyYW5zZm9ybSBzdHJlYW0gdGhhdCBhY2NlcHRzIGEgc3RyZWFtIG9mIG9jdGV0IGRhdGEgYW5kIGNvbnZlcnRzIGl0IGludG8gYW4gb2JqZWN0XG4gKiByZXByZXNlbnRhdGlvbiBvZiBhIENDU0RTIFNwYWNlIFBhY2tldC4gU2VlIGh0dHBzOi8vcHVibGljLmNjc2RzLm9yZy9QdWJzLzEzM3gwYjJlMS5wZGYgZm9yIGFcbiAqIGRlc2NyaXB0aW9uIG9mIHRoZSBTcGFjZSBQYWNrZXQgZm9ybWF0LlxuICovXG5jbGFzcyBTcGFjZVBhY2tldFBhcnNlciBleHRlbmRzIHN0cmVhbV8xLlRyYW5zZm9ybSB7XG4gICAgLyoqXG4gICAgICogQSBUcmFuc2Zvcm0gc3RyZWFtIHRoYXQgYWNjZXB0cyBhIHN0cmVhbSBvZiBvY3RldCBkYXRhIGFuZCBlbWl0cyBvYmplY3QgcmVwcmVzZW50YXRpb25zIG9mXG4gICAgICogQ0NTRFMgU3BhY2UgUGFja2V0cyBvbmNlIGEgcGFja2V0IGhhcyBiZWVuIGNvbXBsZXRlbHkgcmVjZWl2ZWQuXG4gICAgICogQHBhcmFtIHtPYmplY3R9IFtvcHRpb25zXSBDb25maWd1cmF0aW9uIG9wdGlvbnMgZm9yIHRoZSBzdHJlYW1cbiAgICAgKiBAcGFyYW0ge051bWJlcn0gb3B0aW9ucy50aW1lQ29kZUZpZWxkTGVuZ3RoIFRoZSBsZW5ndGggb2YgdGhlIHRpbWUgY29kZSBmaWVsZCB3aXRoaW4gdGhlIGRhdGFcbiAgICAgKiBAcGFyYW0ge051bWJlcn0gb3B0aW9ucy5hbmNpbGxhcnlEYXRhRmllbGRMZW5ndGggVGhlIGxlbmd0aCBvZiB0aGUgYW5jaWxsYXJ5IGRhdGEgZmllbGQgd2l0aGluIHRoZSBkYXRhXG4gICAgICovXG4gICAgY29uc3RydWN0b3Iob3B0aW9ucyA9IHt9KSB7XG4gICAgICAgIHN1cGVyKHsgLi4ub3B0aW9ucywgb2JqZWN0TW9kZTogdHJ1ZSB9KTtcbiAgICAgICAgLy8gU2V0IHRoZSBjb25zdGFudHMgZm9yIHRoaXMgU3BhY2UgUGFja2V0IENvbm5lY3Rpb247IHRoZXNlIHdpbGwgaGVscCB1cyBwYXJzZSBpbmNvbWluZyBkYXRhXG4gICAgICAgIC8vIGZpZWxkczpcbiAgICAgICAgdGhpcy50aW1lQ29kZUZpZWxkTGVuZ3RoID0gb3B0aW9ucy50aW1lQ29kZUZpZWxkTGVuZ3RoIHx8IDA7XG4gICAgICAgIHRoaXMuYW5jaWxsYXJ5RGF0YUZpZWxkTGVuZ3RoID0gb3B0aW9ucy5hbmNpbGxhcnlEYXRhRmllbGRMZW5ndGggfHwgMDtcbiAgICAgICAgdGhpcy5kYXRhU2xpY2UgPSB0aGlzLnRpbWVDb2RlRmllbGRMZW5ndGggKyB0aGlzLmFuY2lsbGFyeURhdGFGaWVsZExlbmd0aDtcbiAgICAgICAgLy8gVGhlc2UgYXJlIHN0YXRlZnVsIGJhc2VkIG9uIHRoZSBjdXJyZW50IHBhY2tldCBiZWluZyByZWNlaXZlZDpcbiAgICAgICAgdGhpcy5kYXRhQnVmZmVyID0gQnVmZmVyLmFsbG9jKDApO1xuICAgICAgICB0aGlzLmhlYWRlckJ1ZmZlciA9IEJ1ZmZlci5hbGxvYygwKTtcbiAgICAgICAgdGhpcy5kYXRhTGVuZ3RoID0gMDtcbiAgICAgICAgdGhpcy5leHBlY3RpbmdIZWFkZXIgPSB0cnVlO1xuICAgIH1cbiAgICAvKipcbiAgICAgKiBCdW5kbGUgdGhlIGhlYWRlciwgc2Vjb25kYXJ5IGhlYWRlciBpZiBwcmVzZW50LCBhbmQgdGhlIGRhdGEgaW50byBhIEphdmFTY3JpcHQgb2JqZWN0IHRvIGVtaXQuXG4gICAgICogSWYgbW9yZSBkYXRhIGhhcyBiZWVuIHJlY2VpdmVkIHBhc3QgdGhlIGN1cnJlbnQgcGFja2V0LCBiZWdpbiB0aGUgcHJvY2VzcyBvZiBwYXJzaW5nIHRoZSBuZXh0XG4gICAgICogcGFja2V0KHMpLlxuICAgICAqL1xuICAgIHB1c2hDb21wbGV0ZWRQYWNrZXQoKSB7XG4gICAgICAgIGlmICghdGhpcy5oZWFkZXIpIHtcbiAgICAgICAgICAgIHRocm93IG5ldyBFcnJvcignTWlzc2luZyBoZWFkZXInKTtcbiAgICAgICAgfVxuICAgICAgICBjb25zdCB0aW1lQ29kZSA9IEJ1ZmZlci5mcm9tKHRoaXMuZGF0YUJ1ZmZlci5zbGljZSgwLCB0aGlzLnRpbWVDb2RlRmllbGRMZW5ndGgpKTtcbiAgICAgICAgY29uc3QgYW5jaWxsYXJ5RGF0YSA9IEJ1ZmZlci5mcm9tKHRoaXMuZGF0YUJ1ZmZlci5zbGljZSh0aGlzLnRpbWVDb2RlRmllbGRMZW5ndGgsIHRoaXMudGltZUNvZGVGaWVsZExlbmd0aCArIHRoaXMuYW5jaWxsYXJ5RGF0YUZpZWxkTGVuZ3RoKSk7XG4gICAgICAgIGNvbnN0IGRhdGEgPSBCdWZmZXIuZnJvbSh0aGlzLmRhdGFCdWZmZXIuc2xpY2UodGhpcy5kYXRhU2xpY2UsIHRoaXMuZGF0YUxlbmd0aCkpO1xuICAgICAgICBjb25zdCBjb21wbGV0ZWRQYWNrZXQgPSB7XG4gICAgICAgICAgICBoZWFkZXI6IHsgLi4udGhpcy5oZWFkZXIgfSxcbiAgICAgICAgICAgIGRhdGE6IGRhdGEudG9TdHJpbmcoKSxcbiAgICAgICAgfTtcbiAgICAgICAgaWYgKHRpbWVDb2RlLmxlbmd0aCA+IDAgfHwgYW5jaWxsYXJ5RGF0YS5sZW5ndGggPiAwKSB7XG4gICAgICAgICAgICBjb21wbGV0ZWRQYWNrZXQuc2Vjb25kYXJ5SGVhZGVyID0ge307XG4gICAgICAgICAgICBpZiAodGltZUNvZGUubGVuZ3RoKSB7XG4gICAgICAgICAgICAgICAgY29tcGxldGVkUGFja2V0LnNlY29uZGFyeUhlYWRlci50aW1lQ29kZSA9IHRpbWVDb2RlLnRvU3RyaW5nKCk7XG4gICAgICAgICAgICB9XG4gICAgICAgICAgICBpZiAoYW5jaWxsYXJ5RGF0YS5sZW5ndGgpIHtcbiAgICAgICAgICAgICAgICBjb21wbGV0ZWRQYWNrZXQuc2Vjb25kYXJ5SGVhZGVyLmFuY2lsbGFyeURhdGEgPSBhbmNpbGxhcnlEYXRhLnRvU3RyaW5nKCk7XG4gICAgICAgICAgICB9XG4gICAgICAgIH1cbiAgICAgICAgdGhpcy5wdXNoKGNvbXBsZXRlZFBhY2tldCk7XG4gICAgICAgIC8vIElmIHRoZXJlIGlzIGFuIG92ZXJmbG93IChpLmUuIHdlIGhhdmUgbW9yZSBkYXRhIHRoYW4gdGhlIHBhY2tldCB3ZSBqdXN0IHB1c2hlZCkgYmVnaW4gcGFyc2luZ1xuICAgICAgICAvLyB0aGUgbmV4dCBwYWNrZXQuXG4gICAgICAgIGNvbnN0IG5leHRDaHVuayA9IEJ1ZmZlci5mcm9tKHRoaXMuZGF0YUJ1ZmZlci5zbGljZSh0aGlzLmRhdGFMZW5ndGgpKTtcbiAgICAgICAgaWYgKG5leHRDaHVuay5sZW5ndGggPj0gdXRpbHNfMS5IRUFERVJfTEVOR1RIKSB7XG4gICAgICAgICAgICB0aGlzLmV4dHJhY3RIZWFkZXIobmV4dENodW5rKTtcbiAgICAgICAgfVxuICAgICAgICBlbHNlIHtcbiAgICAgICAgICAgIHRoaXMuaGVhZGVyQnVmZmVyID0gbmV4dENodW5rO1xuICAgICAgICAgICAgdGhpcy5kYXRhQnVmZmVyID0gQnVmZmVyLmFsbG9jKDApO1xuICAgICAgICAgICAgdGhpcy5leHBlY3RpbmdIZWFkZXIgPSB0cnVlO1xuICAgICAgICAgICAgdGhpcy5kYXRhTGVuZ3RoID0gMDtcbiAgICAgICAgICAgIHRoaXMuaGVhZGVyID0gdW5kZWZpbmVkO1xuICAgICAgICB9XG4gICAgfVxuICAgIC8qKlxuICAgICAqIEJ1aWxkIHRoZSBTdHJlYW0ncyBoZWFkZXJCdWZmZXIgcHJvcGVydHkgZnJvbSB0aGUgcmVjZWl2ZWQgQnVmZmVyIGNodW5rOyBleHRyYWN0IGRhdGEgZnJvbSBpdFxuICAgICAqIGlmIGl0J3MgY29tcGxldGUuIElmIHRoZXJlJ3MgbW9yZSB0byB0aGUgY2h1bmsgdGhhbiBqdXN0IHRoZSBoZWFkZXIsIGluaXRpYXRlIGhhbmRsaW5nIHRoZVxuICAgICAqIHBhY2tldCBkYXRhLlxuICAgICAqIEBwYXJhbSBjaHVuayAtICBCdWlsZCB0aGUgU3RyZWFtJ3MgaGVhZGVyQnVmZmVyIHByb3BlcnR5IGZyb21cbiAgICAgKi9cbiAgICBleHRyYWN0SGVhZGVyKGNodW5rKSB7XG4gICAgICAgIGNvbnN0IGhlYWRlckFzQnVmZmVyID0gQnVmZmVyLmNvbmNhdChbdGhpcy5oZWFkZXJCdWZmZXIsIGNodW5rXSk7XG4gICAgICAgIGNvbnN0IHN0YXJ0T2ZEYXRhQnVmZmVyID0gaGVhZGVyQXNCdWZmZXIuc2xpY2UodXRpbHNfMS5IRUFERVJfTEVOR1RIKTtcbiAgICAgICAgaWYgKGhlYWRlckFzQnVmZmVyLmxlbmd0aCA+PSB1dGlsc18xLkhFQURFUl9MRU5HVEgpIHtcbiAgICAgICAgICAgIHRoaXMuaGVhZGVyID0gKDAsIHV0aWxzXzEuY29udmVydEhlYWRlckJ1ZmZlclRvT2JqKShoZWFkZXJBc0J1ZmZlcik7XG4gICAgICAgICAgICB0aGlzLmRhdGFMZW5ndGggPSB0aGlzLmhlYWRlci5kYXRhTGVuZ3RoO1xuICAgICAgICAgICAgdGhpcy5oZWFkZXJCdWZmZXIgPSBCdWZmZXIuYWxsb2MoMCk7XG4gICAgICAgICAgICB0aGlzLmV4cGVjdGluZ0hlYWRlciA9IGZhbHNlO1xuICAgICAgICB9XG4gICAgICAgIGVsc2Uge1xuICAgICAgICAgICAgdGhpcy5oZWFkZXJCdWZmZXIgPSBoZWFkZXJBc0J1ZmZlcjtcbiAgICAgICAgfVxuICAgICAgICBpZiAoc3RhcnRPZkRhdGFCdWZmZXIubGVuZ3RoID4gMCkge1xuICAgICAgICAgICAgdGhpcy5kYXRhQnVmZmVyID0gQnVmZmVyLmZyb20oc3RhcnRPZkRhdGFCdWZmZXIpO1xuICAgICAgICAgICAgaWYgKHRoaXMuZGF0YUJ1ZmZlci5sZW5ndGggPj0gdGhpcy5kYXRhTGVuZ3RoKSB7XG4gICAgICAgICAgICAgICAgdGhpcy5wdXNoQ29tcGxldGVkUGFja2V0KCk7XG4gICAgICAgICAgICB9XG4gICAgICAgIH1cbiAgICB9XG4gICAgX3RyYW5zZm9ybShjaHVuaywgZW5jb2RpbmcsIGNiKSB7XG4gICAgICAgIGlmICh0aGlzLmV4cGVjdGluZ0hlYWRlcikge1xuICAgICAgICAgICAgdGhpcy5leHRyYWN0SGVhZGVyKGNodW5rKTtcbiAgICAgICAgfVxuICAgICAgICBlbHNlIHtcbiAgICAgICAgICAgIHRoaXMuZGF0YUJ1ZmZlciA9IEJ1ZmZlci5jb25jYXQoW3RoaXMuZGF0YUJ1ZmZlciwgY2h1bmtdKTtcbiAgICAgICAgICAgIGlmICh0aGlzLmRhdGFCdWZmZXIubGVuZ3RoID49IHRoaXMuZGF0YUxlbmd0aCkge1xuICAgICAgICAgICAgICAgIHRoaXMucHVzaENvbXBsZXRlZFBhY2tldCgpO1xuICAgICAgICAgICAgfVxuICAgICAgICB9XG4gICAgICAgIGNiKCk7XG4gICAgfVxuICAgIF9mbHVzaChjYikge1xuICAgICAgICBjb25zdCByZW1haW5pbmcgPSBCdWZmZXIuY29uY2F0KFt0aGlzLmhlYWRlckJ1ZmZlciwgdGhpcy5kYXRhQnVmZmVyXSk7XG4gICAgICAgIGNvbnN0IHJlbWFpbmluZ0FycmF5ID0gQXJyYXkuZnJvbShyZW1haW5pbmcpO1xuICAgICAgICB0aGlzLnB1c2gocmVtYWluaW5nQXJyYXkpO1xuICAgICAgICBjYigpO1xuICAgIH1cbn1cbmV4cG9ydHMuU3BhY2VQYWNrZXRQYXJzZXIgPSBTcGFjZVBhY2tldFBhcnNlcjtcbiIsIlwidXNlIHN0cmljdFwiO1xuT2JqZWN0LmRlZmluZVByb3BlcnR5KGV4cG9ydHMsIFwiX19lc01vZHVsZVwiLCB7IHZhbHVlOiB0cnVlIH0pO1xuZXhwb3J0cy5jb252ZXJ0SGVhZGVyQnVmZmVyVG9PYmogPSBleHBvcnRzLkhFQURFUl9MRU5HVEggPSB2b2lkIDA7XG5leHBvcnRzLkhFQURFUl9MRU5HVEggPSA2O1xuLyoqXG4gKiBGb3IgbnVtYmVycyBsZXNzIHRoYW4gMjU1LCB3aWxsIGVuc3VyZSB0aGF0IHRoZWlyIHN0cmluZyByZXByZXNlbnRhdGlvbiBpcyBhdCBsZWFzdCA4IGNoYXJhY3RlcnMgbG9uZy5cbiAqL1xuY29uc3QgdG9PY3RldFN0ciA9IChudW0pID0+IHtcbiAgICBsZXQgc3RyID0gTnVtYmVyKG51bSkudG9TdHJpbmcoMik7XG4gICAgd2hpbGUgKHN0ci5sZW5ndGggPCA4KSB7XG4gICAgICAgIHN0ciA9IGAwJHtzdHJ9YDtcbiAgICB9XG4gICAgcmV0dXJuIHN0cjtcbn07XG4vKipcbiAqIENvbnZlcnRzIGEgQnVmZmVyIG9mIGFueSBsZW5ndGggdG8gYW4gT2JqZWN0IHJlcHJlc2VudGF0aW9uIG9mIGEgU3BhY2UgUGFja2V0IGhlYWRlciwgcHJvdmlkZWRcbiAqIHRoZSByZWNlaXZlZCBkYXRhIGlzIGluIHRoZSBjb3JyZWN0IGZvcm1hdC5cbiAqIEBwYXJhbSBidWYgLSBUaGUgYnVmZmVyIGNvbnRhaW5pbmcgdGhlIFNwYWNlIFBhY2tldCBIZWFkZXIgRGF0YVxuICovXG5jb25zdCBjb252ZXJ0SGVhZGVyQnVmZmVyVG9PYmogPSAoYnVmKSA9PiB7XG4gICAgY29uc3QgaGVhZGVyU3RyID0gQXJyYXkuZnJvbShidWYuc2xpY2UoMCwgZXhwb3J0cy5IRUFERVJfTEVOR1RIKSkucmVkdWNlKChhY2N1bSwgY3VycikgPT4gYCR7YWNjdW19JHt0b09jdGV0U3RyKGN1cnIpfWAsICcnKTtcbiAgICBjb25zdCBpc1ZlcnNpb24xID0gaGVhZGVyU3RyLnNsaWNlKDAsIDMpID09PSAnMDAwJztcbiAgICBjb25zdCB2ZXJzaW9uTnVtYmVyID0gaXNWZXJzaW9uMSA/IDEgOiAnVU5LTk9XTl9WRVJTSU9OJztcbiAgICBjb25zdCB0eXBlID0gTnVtYmVyKGhlYWRlclN0clszXSk7XG4gICAgY29uc3Qgc2Vjb25kYXJ5SGVhZGVyID0gTnVtYmVyKGhlYWRlclN0cls0XSk7XG4gICAgY29uc3QgYXBpZCA9IHBhcnNlSW50KGhlYWRlclN0ci5zbGljZSg1LCAxNiksIDIpO1xuICAgIGNvbnN0IHNlcXVlbmNlRmxhZ3MgPSBwYXJzZUludChoZWFkZXJTdHIuc2xpY2UoMTYsIDE4KSwgMik7XG4gICAgY29uc3QgcGFja2V0TmFtZSA9IHBhcnNlSW50KGhlYWRlclN0ci5zbGljZSgxOCwgMzIpLCAyKTtcbiAgICBjb25zdCBkYXRhTGVuZ3RoID0gcGFyc2VJbnQoaGVhZGVyU3RyLnNsaWNlKC0xNiksIDIpICsgMTtcbiAgICByZXR1cm4ge1xuICAgICAgICB2ZXJzaW9uTnVtYmVyLFxuICAgICAgICBpZGVudGlmaWNhdGlvbjoge1xuICAgICAgICAgICAgYXBpZCxcbiAgICAgICAgICAgIHNlY29uZGFyeUhlYWRlcixcbiAgICAgICAgICAgIHR5cGUsXG4gICAgICAgIH0sXG4gICAgICAgIHNlcXVlbmNlQ29udHJvbDoge1xuICAgICAgICAgICAgcGFja2V0TmFtZSxcbiAgICAgICAgICAgIHNlcXVlbmNlRmxhZ3MsXG4gICAgICAgIH0sXG4gICAgICAgIGRhdGFMZW5ndGgsXG4gICAgfTtcbn07XG5leHBvcnRzLmNvbnZlcnRIZWFkZXJCdWZmZXJUb09iaiA9IGNvbnZlcnRIZWFkZXJCdWZmZXJUb09iajtcbiIsIlwidXNlIHN0cmljdFwiO1xudmFyIF9faW1wb3J0RGVmYXVsdCA9ICh0aGlzICYmIHRoaXMuX19pbXBvcnREZWZhdWx0KSB8fCBmdW5jdGlvbiAobW9kKSB7XG4gICAgcmV0dXJuIChtb2QgJiYgbW9kLl9fZXNNb2R1bGUpID8gbW9kIDogeyBcImRlZmF1bHRcIjogbW9kIH07XG59O1xuT2JqZWN0LmRlZmluZVByb3BlcnR5KGV4cG9ydHMsIFwiX19lc01vZHVsZVwiLCB7IHZhbHVlOiB0cnVlIH0pO1xuZXhwb3J0cy5TZXJpYWxQb3J0U3RyZWFtID0gZXhwb3J0cy5EaXNjb25uZWN0ZWRFcnJvciA9IHZvaWQgMDtcbmNvbnN0IHN0cmVhbV8xID0gcmVxdWlyZShcInN0cmVhbVwiKTtcbmNvbnN0IGRlYnVnXzEgPSBfX2ltcG9ydERlZmF1bHQocmVxdWlyZShcImRlYnVnXCIpKTtcbmNvbnN0IGRlYnVnID0gKDAsIGRlYnVnXzEuZGVmYXVsdCkoJ3NlcmlhbHBvcnQvc3RyZWFtJyk7XG5jbGFzcyBEaXNjb25uZWN0ZWRFcnJvciBleHRlbmRzIEVycm9yIHtcbiAgICBjb25zdHJ1Y3RvcihtZXNzYWdlKSB7XG4gICAgICAgIHN1cGVyKG1lc3NhZ2UpO1xuICAgICAgICB0aGlzLmRpc2Nvbm5lY3RlZCA9IHRydWU7XG4gICAgfVxufVxuZXhwb3J0cy5EaXNjb25uZWN0ZWRFcnJvciA9IERpc2Nvbm5lY3RlZEVycm9yO1xuY29uc3QgZGVmYXVsdFNldEZsYWdzID0ge1xuICAgIGJyazogZmFsc2UsXG4gICAgY3RzOiBmYWxzZSxcbiAgICBkdHI6IHRydWUsXG4gICAgcnRzOiB0cnVlLFxufTtcbmZ1bmN0aW9uIGFsbG9jTmV3UmVhZFBvb2wocG9vbFNpemUpIHtcbiAgICBjb25zdCBwb29sID0gQnVmZmVyLmFsbG9jVW5zYWZlKHBvb2xTaXplKTtcbiAgICBwb29sLnVzZWQgPSAwO1xuICAgIHJldHVybiBwb29sO1xufVxuY2xhc3MgU2VyaWFsUG9ydFN0cmVhbSBleHRlbmRzIHN0cmVhbV8xLkR1cGxleCB7XG4gICAgLyoqXG4gICAgICogQ3JlYXRlIGEgbmV3IHNlcmlhbCBwb3J0IG9iamVjdCBmb3IgdGhlIGBwYXRoYC4gSW4gdGhlIGNhc2Ugb2YgaW52YWxpZCBhcmd1bWVudHMgb3IgaW52YWxpZCBvcHRpb25zLCB3aGVuIGNvbnN0cnVjdGluZyBhIG5ldyBTZXJpYWxQb3J0IGl0IHdpbGwgdGhyb3cgYW4gZXJyb3IuIFRoZSBwb3J0IHdpbGwgb3BlbiBhdXRvbWF0aWNhbGx5IGJ5IGRlZmF1bHQsIHdoaWNoIGlzIHRoZSBlcXVpdmFsZW50IG9mIGNhbGxpbmcgYHBvcnQub3BlbihvcGVuQ2FsbGJhY2spYCBpbiB0aGUgbmV4dCB0aWNrLiBZb3UgY2FuIGRpc2FibGUgdGhpcyBieSBzZXR0aW5nIHRoZSBvcHRpb24gYGF1dG9PcGVuYCB0byBgZmFsc2VgLlxuICAgICAqIEBlbWl0cyBvcGVuXG4gICAgICogQGVtaXRzIGRhdGFcbiAgICAgKiBAZW1pdHMgY2xvc2VcbiAgICAgKiBAZW1pdHMgZXJyb3JcbiAgICAgKi9cbiAgICBjb25zdHJ1Y3RvcihvcHRpb25zLCBvcGVuQ2FsbGJhY2spIHtcbiAgICAgICAgY29uc3Qgc2V0dGluZ3MgPSB7XG4gICAgICAgICAgICBhdXRvT3BlbjogdHJ1ZSxcbiAgICAgICAgICAgIGVuZE9uQ2xvc2U6IGZhbHNlLFxuICAgICAgICAgICAgaGlnaFdhdGVyTWFyazogNjQgKiAxMDI0LFxuICAgICAgICAgICAgLi4ub3B0aW9ucyxcbiAgICAgICAgfTtcbiAgICAgICAgc3VwZXIoe1xuICAgICAgICAgICAgaGlnaFdhdGVyTWFyazogc2V0dGluZ3MuaGlnaFdhdGVyTWFyayxcbiAgICAgICAgfSk7XG4gICAgICAgIGlmICghc2V0dGluZ3MuYmluZGluZykge1xuICAgICAgICAgICAgdGhyb3cgbmV3IFR5cGVFcnJvcignXCJCaW5kaW5nc1wiIGlzIGludmFsaWQgcGFzcyBpdCBhcyBgb3B0aW9ucy5iaW5kaW5nYCcpO1xuICAgICAgICB9XG4gICAgICAgIGlmICghc2V0dGluZ3MucGF0aCkge1xuICAgICAgICAgICAgdGhyb3cgbmV3IFR5cGVFcnJvcihgXCJwYXRoXCIgaXMgbm90IGRlZmluZWQ6ICR7c2V0dGluZ3MucGF0aH1gKTtcbiAgICAgICAgfVxuICAgICAgICBpZiAodHlwZW9mIHNldHRpbmdzLmJhdWRSYXRlICE9PSAnbnVtYmVyJykge1xuICAgICAgICAgICAgdGhyb3cgbmV3IFR5cGVFcnJvcihgXCJiYXVkUmF0ZVwiIG11c3QgYmUgYSBudW1iZXI6ICR7c2V0dGluZ3MuYmF1ZFJhdGV9YCk7XG4gICAgICAgIH1cbiAgICAgICAgdGhpcy5zZXR0aW5ncyA9IHNldHRpbmdzO1xuICAgICAgICB0aGlzLm9wZW5pbmcgPSBmYWxzZTtcbiAgICAgICAgdGhpcy5jbG9zaW5nID0gZmFsc2U7XG4gICAgICAgIHRoaXMuX3Bvb2wgPSBhbGxvY05ld1JlYWRQb29sKHRoaXMuc2V0dGluZ3MuaGlnaFdhdGVyTWFyayk7XG4gICAgICAgIHRoaXMuX2tNaW5Qb29sU3BhY2UgPSAxMjg7XG4gICAgICAgIGlmICh0aGlzLnNldHRpbmdzLmF1dG9PcGVuKSB7XG4gICAgICAgICAgICB0aGlzLm9wZW4ob3BlbkNhbGxiYWNrKTtcbiAgICAgICAgfVxuICAgIH1cbiAgICBnZXQgcGF0aCgpIHtcbiAgICAgICAgcmV0dXJuIHRoaXMuc2V0dGluZ3MucGF0aDtcbiAgICB9XG4gICAgZ2V0IGJhdWRSYXRlKCkge1xuICAgICAgICByZXR1cm4gdGhpcy5zZXR0aW5ncy5iYXVkUmF0ZTtcbiAgICB9XG4gICAgZ2V0IGlzT3BlbigpIHtcbiAgICAgICAgdmFyIF9hLCBfYjtcbiAgICAgICAgcmV0dXJuICgoX2IgPSAoX2EgPSB0aGlzLnBvcnQpID09PSBudWxsIHx8IF9hID09PSB2b2lkIDAgPyB2b2lkIDAgOiBfYS5pc09wZW4pICE9PSBudWxsICYmIF9iICE9PSB2b2lkIDAgPyBfYiA6IGZhbHNlKSAmJiAhdGhpcy5jbG9zaW5nO1xuICAgIH1cbiAgICBfZXJyb3IoZXJyb3IsIGNhbGxiYWNrKSB7XG4gICAgICAgIGlmIChjYWxsYmFjaykge1xuICAgICAgICAgICAgY2FsbGJhY2suY2FsbCh0aGlzLCBlcnJvcik7XG4gICAgICAgIH1cbiAgICAgICAgZWxzZSB7XG4gICAgICAgICAgICB0aGlzLmVtaXQoJ2Vycm9yJywgZXJyb3IpO1xuICAgICAgICB9XG4gICAgfVxuICAgIF9hc3luY0Vycm9yKGVycm9yLCBjYWxsYmFjaykge1xuICAgICAgICBwcm9jZXNzLm5leHRUaWNrKCgpID0+IHRoaXMuX2Vycm9yKGVycm9yLCBjYWxsYmFjaykpO1xuICAgIH1cbiAgICAvKipcbiAgICAgKiBPcGVucyBhIGNvbm5lY3Rpb24gdG8gdGhlIGdpdmVuIHNlcmlhbCBwb3J0LlxuICAgICAqIEBwYXJhbSB7RXJyb3JDYWxsYmFjaz19IG9wZW5DYWxsYmFjayAtIENhbGxlZCBhZnRlciBhIGNvbm5lY3Rpb24gaXMgb3BlbmVkLiBJZiB0aGlzIGlzIG5vdCBwcm92aWRlZCBhbmQgYW4gZXJyb3Igb2NjdXJzLCBpdCB3aWxsIGJlIGVtaXR0ZWQgb24gdGhlIHBvcnQncyBgZXJyb3JgIGV2ZW50LlxuICAgICAqIEBlbWl0cyBvcGVuXG4gICAgICovXG4gICAgb3BlbihvcGVuQ2FsbGJhY2spIHtcbiAgICAgICAgaWYgKHRoaXMuaXNPcGVuKSB7XG4gICAgICAgICAgICByZXR1cm4gdGhpcy5fYXN5bmNFcnJvcihuZXcgRXJyb3IoJ1BvcnQgaXMgYWxyZWFkeSBvcGVuJyksIG9wZW5DYWxsYmFjayk7XG4gICAgICAgIH1cbiAgICAgICAgaWYgKHRoaXMub3BlbmluZykge1xuICAgICAgICAgICAgcmV0dXJuIHRoaXMuX2FzeW5jRXJyb3IobmV3IEVycm9yKCdQb3J0IGlzIG9wZW5pbmcnKSwgb3BlbkNhbGxiYWNrKTtcbiAgICAgICAgfVxuICAgICAgICAvLyBlc2xpbnQtZGlzYWJsZS1uZXh0LWxpbmUgQHR5cGVzY3JpcHQtZXNsaW50L25vLXVudXNlZC12YXJzXG4gICAgICAgIGNvbnN0IHsgaGlnaFdhdGVyTWFyaywgYmluZGluZywgYXV0b09wZW4sIGVuZE9uQ2xvc2UsIC4uLm9wZW5PcHRpb25zIH0gPSB0aGlzLnNldHRpbmdzO1xuICAgICAgICB0aGlzLm9wZW5pbmcgPSB0cnVlO1xuICAgICAgICBkZWJ1Zygnb3BlbmluZycsIGBwYXRoOiAke3RoaXMucGF0aH1gKTtcbiAgICAgICAgdGhpcy5zZXR0aW5ncy5iaW5kaW5nLm9wZW4ob3Blbk9wdGlvbnMpLnRoZW4ocG9ydCA9PiB7XG4gICAgICAgICAgICBkZWJ1Zygnb3BlbmVkJywgYHBhdGg6ICR7dGhpcy5wYXRofWApO1xuICAgICAgICAgICAgdGhpcy5wb3J0ID0gcG9ydDtcbiAgICAgICAgICAgIHRoaXMub3BlbmluZyA9IGZhbHNlO1xuICAgICAgICAgICAgdGhpcy5lbWl0KCdvcGVuJyk7XG4gICAgICAgICAgICBpZiAob3BlbkNhbGxiYWNrKSB7XG4gICAgICAgICAgICAgICAgb3BlbkNhbGxiYWNrLmNhbGwodGhpcywgbnVsbCk7XG4gICAgICAgICAgICB9XG4gICAgICAgIH0sIGVyciA9PiB7XG4gICAgICAgICAgICB0aGlzLm9wZW5pbmcgPSBmYWxzZTtcbiAgICAgICAgICAgIGRlYnVnKCdCaW5kaW5nICNvcGVuIGhhZCBhbiBlcnJvcicsIGVycik7XG4gICAgICAgICAgICB0aGlzLl9lcnJvcihlcnIsIG9wZW5DYWxsYmFjayk7XG4gICAgICAgIH0pO1xuICAgIH1cbiAgICAvKipcbiAgICAgKiBDaGFuZ2VzIHRoZSBiYXVkIHJhdGUgZm9yIGFuIG9wZW4gcG9ydC4gRW1pdHMgYW4gZXJyb3Igb3IgY2FsbHMgdGhlIGNhbGxiYWNrIGlmIHRoZSBiYXVkIHJhdGUgaXNuJ3Qgc3VwcG9ydGVkLlxuICAgICAqIEBwYXJhbSB7b2JqZWN0PX0gb3B0aW9ucyBPbmx5IHN1cHBvcnRzIGBiYXVkUmF0ZWAuXG4gICAgICogQHBhcmFtIHtudW1iZXI9fSBbb3B0aW9ucy5iYXVkUmF0ZV0gVGhlIGJhdWQgcmF0ZSBvZiB0aGUgcG9ydCB0byBiZSBvcGVuZWQuIFRoaXMgc2hvdWxkIG1hdGNoIG9uZSBvZiB0aGUgY29tbW9ubHkgYXZhaWxhYmxlIGJhdWQgcmF0ZXMsIHN1Y2ggYXMgMTEwLCAzMDAsIDEyMDAsIDI0MDAsIDQ4MDAsIDk2MDAsIDE0NDAwLCAxOTIwMCwgMzg0MDAsIDU3NjAwLCBvciAxMTUyMDAuIEN1c3RvbSByYXRlcyBhcmUgc3VwcG9ydGVkIGJlc3QgZWZmb3J0IHBlciBwbGF0Zm9ybS4gVGhlIGRldmljZSBjb25uZWN0ZWQgdG8gdGhlIHNlcmlhbCBwb3J0IGlzIG5vdCBndWFyYW50ZWVkIHRvIHN1cHBvcnQgdGhlIHJlcXVlc3RlZCBiYXVkIHJhdGUsIGV2ZW4gaWYgdGhlIHBvcnQgaXRzZWxmIHN1cHBvcnRzIHRoYXQgYmF1ZCByYXRlLlxuICAgICAqIEBwYXJhbSB7RXJyb3JDYWxsYmFjaz19IFtjYWxsYmFja10gQ2FsbGVkIG9uY2UgdGhlIHBvcnQncyBiYXVkIHJhdGUgY2hhbmdlcy4gSWYgYC51cGRhdGVgIGlzIGNhbGxlZCB3aXRob3V0IGEgY2FsbGJhY2ssIGFuZCB0aGVyZSBpcyBhbiBlcnJvciwgYW4gZXJyb3IgZXZlbnQgaXMgZW1pdHRlZC5cbiAgICAgKiBAcmV0dXJucyB7dW5kZWZpbmVkfVxuICAgICAqL1xuICAgIHVwZGF0ZShvcHRpb25zLCBjYWxsYmFjaykge1xuICAgICAgICBpZiAoIXRoaXMuaXNPcGVuIHx8ICF0aGlzLnBvcnQpIHtcbiAgICAgICAgICAgIGRlYnVnKCd1cGRhdGUgYXR0ZW1wdGVkLCBidXQgcG9ydCBpcyBub3Qgb3BlbicpO1xuICAgICAgICAgICAgcmV0dXJuIHRoaXMuX2FzeW5jRXJyb3IobmV3IEVycm9yKCdQb3J0IGlzIG5vdCBvcGVuJyksIGNhbGxiYWNrKTtcbiAgICAgICAgfVxuICAgICAgICBkZWJ1ZygndXBkYXRlJywgYGJhdWRSYXRlOiAke29wdGlvbnMuYmF1ZFJhdGV9YCk7XG4gICAgICAgIHRoaXMucG9ydC51cGRhdGUob3B0aW9ucykudGhlbigoKSA9PiB7XG4gICAgICAgICAgICBkZWJ1ZygnYmluZGluZy51cGRhdGUnLCAnZmluaXNoZWQnKTtcbiAgICAgICAgICAgIHRoaXMuc2V0dGluZ3MuYmF1ZFJhdGUgPSBvcHRpb25zLmJhdWRSYXRlO1xuICAgICAgICAgICAgaWYgKGNhbGxiYWNrKSB7XG4gICAgICAgICAgICAgICAgY2FsbGJhY2suY2FsbCh0aGlzLCBudWxsKTtcbiAgICAgICAgICAgIH1cbiAgICAgICAgfSwgZXJyID0+IHtcbiAgICAgICAgICAgIGRlYnVnKCdiaW5kaW5nLnVwZGF0ZScsICdlcnJvcicsIGVycik7XG4gICAgICAgICAgICByZXR1cm4gdGhpcy5fZXJyb3IoZXJyLCBjYWxsYmFjayk7XG4gICAgICAgIH0pO1xuICAgIH1cbiAgICB3cml0ZShkYXRhLCBlbmNvZGluZywgY2FsbGJhY2spIHtcbiAgICAgICAgaWYgKEFycmF5LmlzQXJyYXkoZGF0YSkpIHtcbiAgICAgICAgICAgIGRhdGEgPSBCdWZmZXIuZnJvbShkYXRhKTtcbiAgICAgICAgfVxuICAgICAgICBpZiAodHlwZW9mIGVuY29kaW5nID09PSAnZnVuY3Rpb24nKSB7XG4gICAgICAgICAgICByZXR1cm4gc3VwZXIud3JpdGUoZGF0YSwgZW5jb2RpbmcpO1xuICAgICAgICB9XG4gICAgICAgIHJldHVybiBzdXBlci53cml0ZShkYXRhLCBlbmNvZGluZywgY2FsbGJhY2spO1xuICAgIH1cbiAgICBfd3JpdGUoZGF0YSwgZW5jb2RpbmcsIGNhbGxiYWNrKSB7XG4gICAgICAgIGlmICghdGhpcy5pc09wZW4gfHwgIXRoaXMucG9ydCkge1xuICAgICAgICAgICAgdGhpcy5vbmNlKCdvcGVuJywgKCkgPT4ge1xuICAgICAgICAgICAgICAgIHRoaXMuX3dyaXRlKGRhdGEsIGVuY29kaW5nLCBjYWxsYmFjayk7XG4gICAgICAgICAgICB9KTtcbiAgICAgICAgICAgIHJldHVybjtcbiAgICAgICAgfVxuICAgICAgICBkZWJ1ZygnX3dyaXRlJywgYCR7ZGF0YS5sZW5ndGh9IGJ5dGVzIG9mIGRhdGFgKTtcbiAgICAgICAgdGhpcy5wb3J0LndyaXRlKGRhdGEpLnRoZW4oKCkgPT4ge1xuICAgICAgICAgICAgZGVidWcoJ2JpbmRpbmcud3JpdGUnLCAnd3JpdGUgZmluaXNoZWQnKTtcbiAgICAgICAgICAgIGNhbGxiYWNrKG51bGwpO1xuICAgICAgICB9LCBlcnIgPT4ge1xuICAgICAgICAgICAgZGVidWcoJ2JpbmRpbmcud3JpdGUnLCAnZXJyb3InLCBlcnIpO1xuICAgICAgICAgICAgaWYgKCFlcnIuY2FuY2VsZWQpIHtcbiAgICAgICAgICAgICAgICB0aGlzLl9kaXNjb25uZWN0ZWQoZXJyKTtcbiAgICAgICAgICAgIH1cbiAgICAgICAgICAgIGNhbGxiYWNrKGVycik7XG4gICAgICAgIH0pO1xuICAgIH1cbiAgICBfd3JpdGV2KGRhdGEsIGNhbGxiYWNrKSB7XG4gICAgICAgIGRlYnVnKCdfd3JpdGV2JywgYCR7ZGF0YS5sZW5ndGh9IGNodW5rcyBvZiBkYXRhYCk7XG4gICAgICAgIGNvbnN0IGRhdGFWID0gZGF0YS5tYXAod3JpdGUgPT4gd3JpdGUuY2h1bmspO1xuICAgICAgICB0aGlzLl93cml0ZShCdWZmZXIuY29uY2F0KGRhdGFWKSwgdW5kZWZpbmVkLCBjYWxsYmFjayk7XG4gICAgfVxuICAgIF9yZWFkKGJ5dGVzVG9SZWFkKSB7XG4gICAgICAgIGlmICghdGhpcy5pc09wZW4gfHwgIXRoaXMucG9ydCkge1xuICAgICAgICAgICAgZGVidWcoJ19yZWFkJywgJ3F1ZXVlaW5nIF9yZWFkIGZvciBhZnRlciBvcGVuJyk7XG4gICAgICAgICAgICB0aGlzLm9uY2UoJ29wZW4nLCAoKSA9PiB7XG4gICAgICAgICAgICAgICAgdGhpcy5fcmVhZChieXRlc1RvUmVhZCk7XG4gICAgICAgICAgICB9KTtcbiAgICAgICAgICAgIHJldHVybjtcbiAgICAgICAgfVxuICAgICAgICBpZiAoIXRoaXMuX3Bvb2wgfHwgdGhpcy5fcG9vbC5sZW5ndGggLSB0aGlzLl9wb29sLnVzZWQgPCB0aGlzLl9rTWluUG9vbFNwYWNlKSB7XG4gICAgICAgICAgICBkZWJ1ZygnX3JlYWQnLCAnZGlzY2FyZGluZyB0aGUgcmVhZCBidWZmZXIgcG9vbCBiZWNhdXNlIGl0IGlzIGJlbG93IGtNaW5Qb29sU3BhY2UnKTtcbiAgICAgICAgICAgIHRoaXMuX3Bvb2wgPSBhbGxvY05ld1JlYWRQb29sKHRoaXMuc2V0dGluZ3MuaGlnaFdhdGVyTWFyayk7XG4gICAgICAgIH1cbiAgICAgICAgLy8gR3JhYiBhbm90aGVyIHJlZmVyZW5jZSB0byB0aGUgcG9vbCBpbiB0aGUgY2FzZSB0aGF0IHdoaWxlIHdlJ3JlXG4gICAgICAgIC8vIGluIHRoZSB0aHJlYWQgcG9vbCBhbm90aGVyIHJlYWQoKSBmaW5pc2hlcyB1cCB0aGUgcG9vbCwgYW5kXG4gICAgICAgIC8vIGFsbG9jYXRlcyBhIG5ldyBvbmUuXG4gICAgICAgIGNvbnN0IHBvb2wgPSB0aGlzLl9wb29sO1xuICAgICAgICAvLyBSZWFkIHRoZSBzbWFsbGVyIG9mIHJlc3Qgb2YgdGhlIHBvb2wgb3IgaG93ZXZlciBtYW55IGJ5dGVzIHdlIHdhbnRcbiAgICAgICAgY29uc3QgdG9SZWFkID0gTWF0aC5taW4ocG9vbC5sZW5ndGggLSBwb29sLnVzZWQsIGJ5dGVzVG9SZWFkKTtcbiAgICAgICAgY29uc3Qgc3RhcnQgPSBwb29sLnVzZWQ7XG4gICAgICAgIC8vIHRoZSBhY3R1YWwgcmVhZC5cbiAgICAgICAgZGVidWcoJ19yZWFkJywgYHJlYWRpbmdgLCB7IHN0YXJ0LCB0b1JlYWQgfSk7XG4gICAgICAgIHRoaXMucG9ydC5yZWFkKHBvb2wsIHN0YXJ0LCB0b1JlYWQpLnRoZW4oKHsgYnl0ZXNSZWFkIH0pID0+IHtcbiAgICAgICAgICAgIGRlYnVnKCdiaW5kaW5nLnJlYWQnLCBgZmluaXNoZWRgLCB7IGJ5dGVzUmVhZCB9KTtcbiAgICAgICAgICAgIC8vIHplcm8gYnl0ZXMgbWVhbnMgcmVhZCBtZWFucyB3ZSd2ZSBoaXQgRU9GPyBNYXliZSB0aGlzIHNob3VsZCBiZSBhbiBlcnJvclxuICAgICAgICAgICAgaWYgKGJ5dGVzUmVhZCA9PT0gMCkge1xuICAgICAgICAgICAgICAgIGRlYnVnKCdiaW5kaW5nLnJlYWQnLCAnWmVybyBieXRlcyByZWFkIGNsb3NpbmcgcmVhZGFibGUgc3RyZWFtJyk7XG4gICAgICAgICAgICAgICAgdGhpcy5wdXNoKG51bGwpO1xuICAgICAgICAgICAgICAgIHJldHVybjtcbiAgICAgICAgICAgIH1cbiAgICAgICAgICAgIHBvb2wudXNlZCArPSBieXRlc1JlYWQ7XG4gICAgICAgICAgICB0aGlzLnB1c2gocG9vbC5zbGljZShzdGFydCwgc3RhcnQgKyBieXRlc1JlYWQpKTtcbiAgICAgICAgfSwgZXJyID0+IHtcbiAgICAgICAgICAgIGRlYnVnKCdiaW5kaW5nLnJlYWQnLCBgZXJyb3JgLCBlcnIpO1xuICAgICAgICAgICAgaWYgKCFlcnIuY2FuY2VsZWQpIHtcbiAgICAgICAgICAgICAgICB0aGlzLl9kaXNjb25uZWN0ZWQoZXJyKTtcbiAgICAgICAgICAgIH1cbiAgICAgICAgICAgIHRoaXMuX3JlYWQoYnl0ZXNUb1JlYWQpOyAvLyBwcmltZSB0byByZWFkIG1vcmUgb25jZSB3ZSdyZSByZWNvbm5lY3RlZFxuICAgICAgICB9KTtcbiAgICB9XG4gICAgX2Rpc2Nvbm5lY3RlZChlcnIpIHtcbiAgICAgICAgaWYgKCF0aGlzLmlzT3Blbikge1xuICAgICAgICAgICAgZGVidWcoJ2Rpc2Nvbm5lY3RlZCBhYm9ydGVkIGJlY2F1c2UgYWxyZWFkeSBjbG9zZWQnLCBlcnIpO1xuICAgICAgICAgICAgcmV0dXJuO1xuICAgICAgICB9XG4gICAgICAgIGRlYnVnKCdkaXNjb25uZWN0ZWQnLCBlcnIpO1xuICAgICAgICB0aGlzLmNsb3NlKHVuZGVmaW5lZCwgbmV3IERpc2Nvbm5lY3RlZEVycm9yKGVyci5tZXNzYWdlKSk7XG4gICAgfVxuICAgIC8qKlxuICAgICAqIENsb3NlcyBhbiBvcGVuIGNvbm5lY3Rpb24uXG4gICAgICpcbiAgICAgKiBJZiB0aGVyZSBhcmUgaW4gcHJvZ3Jlc3Mgd3JpdGVzIHdoZW4gdGhlIHBvcnQgaXMgY2xvc2VkIHRoZSB3cml0ZXMgd2lsbCBlcnJvci5cbiAgICAgKiBAcGFyYW0ge0Vycm9yQ2FsbGJhY2t9IGNhbGxiYWNrIENhbGxlZCBvbmNlIGEgY29ubmVjdGlvbiBpcyBjbG9zZWQuXG4gICAgICogQHBhcmFtIHtFcnJvcn0gZGlzY29ubmVjdEVycm9yIHVzZWQgaW50ZXJuYWxseSB0byBwcm9wYWdhdGUgYSBkaXNjb25uZWN0IGVycm9yXG4gICAgICovXG4gICAgY2xvc2UoY2FsbGJhY2ssIGRpc2Nvbm5lY3RFcnJvciA9IG51bGwpIHtcbiAgICAgICAgaWYgKCF0aGlzLmlzT3BlbiB8fCAhdGhpcy5wb3J0KSB7XG4gICAgICAgICAgICBkZWJ1ZygnY2xvc2UgYXR0ZW1wdGVkLCBidXQgcG9ydCBpcyBub3Qgb3BlbicpO1xuICAgICAgICAgICAgcmV0dXJuIHRoaXMuX2FzeW5jRXJyb3IobmV3IEVycm9yKCdQb3J0IGlzIG5vdCBvcGVuJyksIGNhbGxiYWNrKTtcbiAgICAgICAgfVxuICAgICAgICB0aGlzLmNsb3NpbmcgPSB0cnVlO1xuICAgICAgICBkZWJ1ZygnI2Nsb3NlJyk7XG4gICAgICAgIHRoaXMucG9ydC5jbG9zZSgpLnRoZW4oKCkgPT4ge1xuICAgICAgICAgICAgdGhpcy5jbG9zaW5nID0gZmFsc2U7XG4gICAgICAgICAgICBkZWJ1ZygnYmluZGluZy5jbG9zZScsICdmaW5pc2hlZCcpO1xuICAgICAgICAgICAgdGhpcy5lbWl0KCdjbG9zZScsIGRpc2Nvbm5lY3RFcnJvcik7XG4gICAgICAgICAgICBpZiAodGhpcy5zZXR0aW5ncy5lbmRPbkNsb3NlKSB7XG4gICAgICAgICAgICAgICAgdGhpcy5lbWl0KCdlbmQnKTtcbiAgICAgICAgICAgIH1cbiAgICAgICAgICAgIGlmIChjYWxsYmFjaykge1xuICAgICAgICAgICAgICAgIGNhbGxiYWNrLmNhbGwodGhpcywgZGlzY29ubmVjdEVycm9yKTtcbiAgICAgICAgICAgIH1cbiAgICAgICAgfSwgZXJyID0+IHtcbiAgICAgICAgICAgIHRoaXMuY2xvc2luZyA9IGZhbHNlO1xuICAgICAgICAgICAgZGVidWcoJ2JpbmRpbmcuY2xvc2UnLCAnaGFkIGFuIGVycm9yJywgZXJyKTtcbiAgICAgICAgICAgIHJldHVybiB0aGlzLl9lcnJvcihlcnIsIGNhbGxiYWNrKTtcbiAgICAgICAgfSk7XG4gICAgfVxuICAgIC8qKlxuICAgICAqIFNldCBjb250cm9sIGZsYWdzIG9uIGFuIG9wZW4gcG9ydC4gVXNlcyBbYFNldENvbW1NYXNrYF0oaHR0cHM6Ly9tc2RuLm1pY3Jvc29mdC5jb20vZW4tdXMvbGlicmFyeS93aW5kb3dzL2Rlc2t0b3AvYWEzNjMyNTcodj12cy44NSkuYXNweCkgZm9yIFdpbmRvd3MgYW5kIFtgaW9jdGxgXShodHRwOi8vbGludXguZGllLm5ldC9tYW4vNC90dHlfaW9jdGwpIGZvciBPUyBYIGFuZCBMaW51eC5cbiAgICAgKlxuICAgICAqIEFsbCBvcHRpb25zIGFyZSBvcGVyYXRpbmcgc3lzdGVtIGRlZmF1bHQgd2hlbiB0aGUgcG9ydCBpcyBvcGVuZWQuIEV2ZXJ5IGZsYWcgaXMgc2V0IG9uIGVhY2ggY2FsbCB0byB0aGUgcHJvdmlkZWQgb3IgZGVmYXVsdCB2YWx1ZXMuIElmIG9wdGlvbnMgaXNuJ3QgcHJvdmlkZWQgZGVmYXVsdCBvcHRpb25zIGlzIHVzZWQuXG4gICAgICovXG4gICAgc2V0KG9wdGlvbnMsIGNhbGxiYWNrKSB7XG4gICAgICAgIGlmICghdGhpcy5pc09wZW4gfHwgIXRoaXMucG9ydCkge1xuICAgICAgICAgICAgZGVidWcoJ3NldCBhdHRlbXB0ZWQsIGJ1dCBwb3J0IGlzIG5vdCBvcGVuJyk7XG4gICAgICAgICAgICByZXR1cm4gdGhpcy5fYXN5bmNFcnJvcihuZXcgRXJyb3IoJ1BvcnQgaXMgbm90IG9wZW4nKSwgY2FsbGJhY2spO1xuICAgICAgICB9XG4gICAgICAgIGNvbnN0IHNldHRpbmdzID0geyAuLi5kZWZhdWx0U2V0RmxhZ3MsIC4uLm9wdGlvbnMgfTtcbiAgICAgICAgZGVidWcoJyNzZXQnLCBzZXR0aW5ncyk7XG4gICAgICAgIHRoaXMucG9ydC5zZXQoc2V0dGluZ3MpLnRoZW4oKCkgPT4ge1xuICAgICAgICAgICAgZGVidWcoJ2JpbmRpbmcuc2V0JywgJ2ZpbmlzaGVkJyk7XG4gICAgICAgICAgICBpZiAoY2FsbGJhY2spIHtcbiAgICAgICAgICAgICAgICBjYWxsYmFjay5jYWxsKHRoaXMsIG51bGwpO1xuICAgICAgICAgICAgfVxuICAgICAgICB9LCBlcnIgPT4ge1xuICAgICAgICAgICAgZGVidWcoJ2JpbmRpbmcuc2V0JywgJ2hhZCBhbiBlcnJvcicsIGVycik7XG4gICAgICAgICAgICByZXR1cm4gdGhpcy5fZXJyb3IoZXJyLCBjYWxsYmFjayk7XG4gICAgICAgIH0pO1xuICAgIH1cbiAgICAvKipcbiAgICAgKiBSZXR1cm5zIHRoZSBjb250cm9sIGZsYWdzIChDVFMsIERTUiwgRENEKSBvbiB0aGUgb3BlbiBwb3J0LlxuICAgICAqIFVzZXMgW2BHZXRDb21tTW9kZW1TdGF0dXNgXShodHRwczovL21zZG4ubWljcm9zb2Z0LmNvbS9lbi11cy9saWJyYXJ5L3dpbmRvd3MvZGVza3RvcC9hYTM2MzI1OCh2PXZzLjg1KS5hc3B4KSBmb3IgV2luZG93cyBhbmQgW2Bpb2N0bGBdKGh0dHA6Ly9saW51eC5kaWUubmV0L21hbi80L3R0eV9pb2N0bCkgZm9yIG1hYyBhbmQgbGludXguXG4gICAgICovXG4gICAgZ2V0KGNhbGxiYWNrKSB7XG4gICAgICAgIGlmICghdGhpcy5pc09wZW4gfHwgIXRoaXMucG9ydCkge1xuICAgICAgICAgICAgZGVidWcoJ2dldCBhdHRlbXB0ZWQsIGJ1dCBwb3J0IGlzIG5vdCBvcGVuJyk7XG4gICAgICAgICAgICByZXR1cm4gdGhpcy5fYXN5bmNFcnJvcihuZXcgRXJyb3IoJ1BvcnQgaXMgbm90IG9wZW4nKSwgY2FsbGJhY2spO1xuICAgICAgICB9XG4gICAgICAgIGRlYnVnKCcjZ2V0Jyk7XG4gICAgICAgIHRoaXMucG9ydC5nZXQoKS50aGVuKHN0YXR1cyA9PiB7XG4gICAgICAgICAgICBkZWJ1ZygnYmluZGluZy5nZXQnLCAnZmluaXNoZWQnKTtcbiAgICAgICAgICAgIGNhbGxiYWNrLmNhbGwodGhpcywgbnVsbCwgc3RhdHVzKTtcbiAgICAgICAgfSwgZXJyID0+IHtcbiAgICAgICAgICAgIGRlYnVnKCdiaW5kaW5nLmdldCcsICdoYWQgYW4gZXJyb3InLCBlcnIpO1xuICAgICAgICAgICAgcmV0dXJuIHRoaXMuX2Vycm9yKGVyciwgY2FsbGJhY2spO1xuICAgICAgICB9KTtcbiAgICB9XG4gICAgLyoqXG4gICAgICogRmx1c2ggZGlzY2FyZHMgZGF0YSByZWNlaXZlZCBidXQgbm90IHJlYWQsIGFuZCB3cml0dGVuIGJ1dCBub3QgdHJhbnNtaXR0ZWQgYnkgdGhlIG9wZXJhdGluZyBzeXN0ZW0uIEZvciBtb3JlIHRlY2huaWNhbCBkZXRhaWxzLCBzZWUgW2B0Y2ZsdXNoKGZkLCBUQ0lPRkxVU0gpYF0oaHR0cDovL2xpbnV4LmRpZS5uZXQvbWFuLzMvdGNmbHVzaCkgZm9yIE1hYy9MaW51eCBhbmQgW2BGbHVzaEZpbGVCdWZmZXJzYF0oaHR0cDovL21zZG4ubWljcm9zb2Z0LmNvbS9lbi11cy9saWJyYXJ5L3dpbmRvd3MvZGVza3RvcC9hYTM2NDQzOSkgZm9yIFdpbmRvd3MuXG4gICAgICovXG4gICAgZmx1c2goY2FsbGJhY2spIHtcbiAgICAgICAgaWYgKCF0aGlzLmlzT3BlbiB8fCAhdGhpcy5wb3J0KSB7XG4gICAgICAgICAgICBkZWJ1ZygnZmx1c2ggYXR0ZW1wdGVkLCBidXQgcG9ydCBpcyBub3Qgb3BlbicpO1xuICAgICAgICAgICAgcmV0dXJuIHRoaXMuX2FzeW5jRXJyb3IobmV3IEVycm9yKCdQb3J0IGlzIG5vdCBvcGVuJyksIGNhbGxiYWNrKTtcbiAgICAgICAgfVxuICAgICAgICBkZWJ1ZygnI2ZsdXNoJyk7XG4gICAgICAgIHRoaXMucG9ydC5mbHVzaCgpLnRoZW4oKCkgPT4ge1xuICAgICAgICAgICAgZGVidWcoJ2JpbmRpbmcuZmx1c2gnLCAnZmluaXNoZWQnKTtcbiAgICAgICAgICAgIGlmIChjYWxsYmFjaykge1xuICAgICAgICAgICAgICAgIGNhbGxiYWNrLmNhbGwodGhpcywgbnVsbCk7XG4gICAgICAgICAgICB9XG4gICAgICAgIH0sIGVyciA9PiB7XG4gICAgICAgICAgICBkZWJ1ZygnYmluZGluZy5mbHVzaCcsICdoYWQgYW4gZXJyb3InLCBlcnIpO1xuICAgICAgICAgICAgcmV0dXJuIHRoaXMuX2Vycm9yKGVyciwgY2FsbGJhY2spO1xuICAgICAgICB9KTtcbiAgICB9XG4gICAgLyoqXG4gICAgICogV2FpdHMgdW50aWwgYWxsIG91dHB1dCBkYXRhIGlzIHRyYW5zbWl0dGVkIHRvIHRoZSBzZXJpYWwgcG9ydC4gQWZ0ZXIgYW55IHBlbmRpbmcgd3JpdGUgaGFzIGNvbXBsZXRlZCBpdCBjYWxscyBbYHRjZHJhaW4oKWBdKGh0dHA6Ly9saW51eC5kaWUubmV0L21hbi8zL3RjZHJhaW4pIG9yIFtGbHVzaEZpbGVCdWZmZXJzKCldKGh0dHBzOi8vbXNkbi5taWNyb3NvZnQuY29tL2VuLXVzL2xpYnJhcnkvd2luZG93cy9kZXNrdG9wL2FhMzY0NDM5KHY9dnMuODUpLmFzcHgpIHRvIGVuc3VyZSBpdCBoYXMgYmVlbiB3cml0dGVuIHRvIHRoZSBkZXZpY2UuXG4gICAgKiBAZXhhbXBsZVxuICAgIFdyaXRlIHRoZSBgZGF0YWAgYW5kIHdhaXQgdW50aWwgaXQgaGFzIGZpbmlzaGVkIHRyYW5zbWl0dGluZyB0byB0aGUgdGFyZ2V0IHNlcmlhbCBwb3J0IGJlZm9yZSBjYWxsaW5nIHRoZSBjYWxsYmFjay4gVGhpcyB3aWxsIHF1ZXVlIHVudGlsIHRoZSBwb3J0IGlzIG9wZW4gYW5kIHdyaXRlcyBhcmUgZmluaXNoZWQuXG4gIFxuICAgIGBgYGpzXG4gICAgZnVuY3Rpb24gd3JpdGVBbmREcmFpbiAoZGF0YSwgY2FsbGJhY2spIHtcbiAgICAgIHBvcnQud3JpdGUoZGF0YSk7XG4gICAgICBwb3J0LmRyYWluKGNhbGxiYWNrKTtcbiAgICB9XG4gICAgYGBgXG4gICAgKi9cbiAgICBkcmFpbihjYWxsYmFjaykge1xuICAgICAgICBkZWJ1ZygnZHJhaW4nKTtcbiAgICAgICAgaWYgKCF0aGlzLmlzT3BlbiB8fCAhdGhpcy5wb3J0KSB7XG4gICAgICAgICAgICBkZWJ1ZygnZHJhaW4gcXVldWluZyBvbiBwb3J0IG9wZW4nKTtcbiAgICAgICAgICAgIHRoaXMub25jZSgnb3BlbicsICgpID0+IHtcbiAgICAgICAgICAgICAgICB0aGlzLmRyYWluKGNhbGxiYWNrKTtcbiAgICAgICAgICAgIH0pO1xuICAgICAgICAgICAgcmV0dXJuO1xuICAgICAgICB9XG4gICAgICAgIHRoaXMucG9ydC5kcmFpbigpLnRoZW4oKCkgPT4ge1xuICAgICAgICAgICAgZGVidWcoJ2JpbmRpbmcuZHJhaW4nLCAnZmluaXNoZWQnKTtcbiAgICAgICAgICAgIGlmIChjYWxsYmFjaykge1xuICAgICAgICAgICAgICAgIGNhbGxiYWNrLmNhbGwodGhpcywgbnVsbCk7XG4gICAgICAgICAgICB9XG4gICAgICAgIH0sIGVyciA9PiB7XG4gICAgICAgICAgICBkZWJ1ZygnYmluZGluZy5kcmFpbicsICdoYWQgYW4gZXJyb3InLCBlcnIpO1xuICAgICAgICAgICAgcmV0dXJuIHRoaXMuX2Vycm9yKGVyciwgY2FsbGJhY2spO1xuICAgICAgICB9KTtcbiAgICB9XG59XG5leHBvcnRzLlNlcmlhbFBvcnRTdHJlYW0gPSBTZXJpYWxQb3J0U3RyZWFtO1xuLyoqXG4gKiBUaGUgYGVycm9yYCBldmVudCdzIGNhbGxiYWNrIGlzIGNhbGxlZCB3aXRoIGFuIGVycm9yIG9iamVjdCB3aGVuZXZlciB0aGVyZSBpcyBhbiBlcnJvci5cbiAqIEBldmVudCBlcnJvclxuICovXG4vKipcbiAqIFRoZSBgb3BlbmAgZXZlbnQncyBjYWxsYmFjayBpcyBjYWxsZWQgd2l0aCBubyBhcmd1bWVudHMgd2hlbiB0aGUgcG9ydCBpcyBvcGVuZWQgYW5kIHJlYWR5IGZvciB3cml0aW5nLiBUaGlzIGhhcHBlbnMgaWYgeW91IGhhdmUgdGhlIGNvbnN0cnVjdG9yIG9wZW4gaW1tZWRpYXRlbHkgKHdoaWNoIG9wZW5zIGluIHRoZSBuZXh0IHRpY2spIG9yIGlmIHlvdSBvcGVuIHRoZSBwb3J0IG1hbnVhbGx5IHdpdGggYG9wZW4oKWAuIFNlZSBbVXNlYWdlL09wZW5pbmcgYSBQb3J0XSgjb3BlbmluZy1hLXBvcnQpIGZvciBtb3JlIGluZm9ybWF0aW9uLlxuICogQGV2ZW50IG9wZW5cbiAqL1xuLyoqXG4gKiBSZXF1ZXN0IGEgbnVtYmVyIG9mIGJ5dGVzIGZyb20gdGhlIFNlcmlhbFBvcnQuIFRoZSBgcmVhZCgpYCBtZXRob2QgcHVsbHMgc29tZSBkYXRhIG91dCBvZiB0aGUgaW50ZXJuYWwgYnVmZmVyIGFuZCByZXR1cm5zIGl0LiBJZiBubyBkYXRhIGlzIGF2YWlsYWJsZSB0byBiZSByZWFkLCBudWxsIGlzIHJldHVybmVkLiBCeSBkZWZhdWx0LCB0aGUgZGF0YSBpcyByZXR1cm5lZCBhcyBhIGBCdWZmZXJgIG9iamVjdCB1bmxlc3MgYW4gZW5jb2RpbmcgaGFzIGJlZW4gc3BlY2lmaWVkIHVzaW5nIHRoZSBgLnNldEVuY29kaW5nKClgIG1ldGhvZC5cbiAqIEBtZXRob2QgU2VyaWFsUG9ydC5wcm90b3R5cGUucmVhZFxuICogQHBhcmFtIHtudW1iZXI9fSBzaXplIFNwZWNpZnkgaG93IG1hbnkgYnl0ZXMgb2YgZGF0YSB0byByZXR1cm4sIGlmIGF2YWlsYWJsZVxuICogQHJldHVybnMgeyhzdHJpbmd8QnVmZmVyfG51bGwpfSBUaGUgZGF0YSBmcm9tIGludGVybmFsIGJ1ZmZlcnNcbiAqL1xuLyoqXG4gKiBMaXN0ZW5pbmcgZm9yIHRoZSBgZGF0YWAgZXZlbnQgcHV0cyB0aGUgcG9ydCBpbiBmbG93aW5nIG1vZGUuIERhdGEgaXMgZW1pdHRlZCBhcyBzb29uIGFzIGl0J3MgcmVjZWl2ZWQuIERhdGEgaXMgYSBgQnVmZmVyYCBvYmplY3Qgd2l0aCBhIHZhcnlpbmcgYW1vdW50IG9mIGRhdGEgaW4gaXQuIFRoZSBgcmVhZExpbmVgIHBhcnNlciBjb252ZXJ0cyB0aGUgZGF0YSBpbnRvIHN0cmluZyBsaW5lcy4gU2VlIHRoZSBbcGFyc2Vyc10oaHR0cHM6Ly9zZXJpYWxwb3J0LmlvL2RvY3MvYXBpLXBhcnNlcnMtb3ZlcnZpZXcpIHNlY3Rpb24gZm9yIG1vcmUgaW5mb3JtYXRpb24gb24gcGFyc2VycywgYW5kIHRoZSBbTm9kZS5qcyBzdHJlYW0gZG9jdW1lbnRhdGlvbl0oaHR0cHM6Ly9ub2RlanMub3JnL2FwaS9zdHJlYW0uaHRtbCNzdHJlYW1fZXZlbnRfZGF0YSkgZm9yIG1vcmUgaW5mb3JtYXRpb24gb24gdGhlIGRhdGEgZXZlbnQuXG4gKiBAZXZlbnQgZGF0YVxuICovXG4vKipcbiAqIFRoZSBgY2xvc2VgIGV2ZW50J3MgY2FsbGJhY2sgaXMgY2FsbGVkIHdpdGggbm8gYXJndW1lbnRzIHdoZW4gdGhlIHBvcnQgaXMgY2xvc2VkLiBJbiB0aGUgY2FzZSBvZiBhIGRpc2Nvbm5lY3QgaXQgd2lsbCBiZSBjYWxsZWQgd2l0aCBhIERpc2Nvbm5lY3QgRXJyb3Igb2JqZWN0IChgZXJyLmRpc2Nvbm5lY3RlZCA9PSB0cnVlYCkuIEluIHRoZSBldmVudCBvZiBhIGNsb3NlIGVycm9yICh1bmxpa2VseSksIGFuIGVycm9yIGV2ZW50IGlzIHRyaWdnZXJlZC5cbiAqIEBldmVudCBjbG9zZVxuICovXG4vKipcbiAqIFRoZSBgcGF1c2UoKWAgbWV0aG9kIGNhdXNlcyBhIHN0cmVhbSBpbiBmbG93aW5nIG1vZGUgdG8gc3RvcCBlbWl0dGluZyAnZGF0YScgZXZlbnRzLCBzd2l0Y2hpbmcgb3V0IG9mIGZsb3dpbmcgbW9kZS4gQW55IGRhdGEgdGhhdCBiZWNvbWVzIGF2YWlsYWJsZSByZW1haW5zIGluIHRoZSBpbnRlcm5hbCBidWZmZXIuXG4gKiBAbWV0aG9kIFNlcmlhbFBvcnQucHJvdG90eXBlLnBhdXNlXG4gKiBAc2VlIHJlc3VtZVxuICogQHJldHVybnMgYHRoaXNgXG4gKi9cbi8qKlxuICogVGhlIGByZXN1bWUoKWAgbWV0aG9kIGNhdXNlcyBhbiBleHBsaWNpdGx5IHBhdXNlZCwgYFJlYWRhYmxlYCBzdHJlYW0gdG8gcmVzdW1lIGVtaXR0aW5nICdkYXRhJyBldmVudHMsIHN3aXRjaGluZyB0aGUgc3RyZWFtIGludG8gZmxvd2luZyBtb2RlLlxuICogQG1ldGhvZCBTZXJpYWxQb3J0LnByb3RvdHlwZS5yZXN1bWVcbiAqIEBzZWUgcGF1c2VcbiAqIEByZXR1cm5zIGB0aGlzYFxuICovXG4iLCIvKiBlc2xpbnQtZW52IGJyb3dzZXIgKi9cblxuLyoqXG4gKiBUaGlzIGlzIHRoZSB3ZWIgYnJvd3NlciBpbXBsZW1lbnRhdGlvbiBvZiBgZGVidWcoKWAuXG4gKi9cblxuZXhwb3J0cy5mb3JtYXRBcmdzID0gZm9ybWF0QXJncztcbmV4cG9ydHMuc2F2ZSA9IHNhdmU7XG5leHBvcnRzLmxvYWQgPSBsb2FkO1xuZXhwb3J0cy51c2VDb2xvcnMgPSB1c2VDb2xvcnM7XG5leHBvcnRzLnN0b3JhZ2UgPSBsb2NhbHN0b3JhZ2UoKTtcbmV4cG9ydHMuZGVzdHJveSA9ICgoKSA9PiB7XG5cdGxldCB3YXJuZWQgPSBmYWxzZTtcblxuXHRyZXR1cm4gKCkgPT4ge1xuXHRcdGlmICghd2FybmVkKSB7XG5cdFx0XHR3YXJuZWQgPSB0cnVlO1xuXHRcdFx0Y29uc29sZS53YXJuKCdJbnN0YW5jZSBtZXRob2QgYGRlYnVnLmRlc3Ryb3koKWAgaXMgZGVwcmVjYXRlZCBhbmQgbm8gbG9uZ2VyIGRvZXMgYW55dGhpbmcuIEl0IHdpbGwgYmUgcmVtb3ZlZCBpbiB0aGUgbmV4dCBtYWpvciB2ZXJzaW9uIG9mIGBkZWJ1Z2AuJyk7XG5cdFx0fVxuXHR9O1xufSkoKTtcblxuLyoqXG4gKiBDb2xvcnMuXG4gKi9cblxuZXhwb3J0cy5jb2xvcnMgPSBbXG5cdCcjMDAwMENDJyxcblx0JyMwMDAwRkYnLFxuXHQnIzAwMzNDQycsXG5cdCcjMDAzM0ZGJyxcblx0JyMwMDY2Q0MnLFxuXHQnIzAwNjZGRicsXG5cdCcjMDA5OUNDJyxcblx0JyMwMDk5RkYnLFxuXHQnIzAwQ0MwMCcsXG5cdCcjMDBDQzMzJyxcblx0JyMwMENDNjYnLFxuXHQnIzAwQ0M5OScsXG5cdCcjMDBDQ0NDJyxcblx0JyMwMENDRkYnLFxuXHQnIzMzMDBDQycsXG5cdCcjMzMwMEZGJyxcblx0JyMzMzMzQ0MnLFxuXHQnIzMzMzNGRicsXG5cdCcjMzM2NkNDJyxcblx0JyMzMzY2RkYnLFxuXHQnIzMzOTlDQycsXG5cdCcjMzM5OUZGJyxcblx0JyMzM0NDMDAnLFxuXHQnIzMzQ0MzMycsXG5cdCcjMzNDQzY2Jyxcblx0JyMzM0NDOTknLFxuXHQnIzMzQ0NDQycsXG5cdCcjMzNDQ0ZGJyxcblx0JyM2NjAwQ0MnLFxuXHQnIzY2MDBGRicsXG5cdCcjNjYzM0NDJyxcblx0JyM2NjMzRkYnLFxuXHQnIzY2Q0MwMCcsXG5cdCcjNjZDQzMzJyxcblx0JyM5OTAwQ0MnLFxuXHQnIzk5MDBGRicsXG5cdCcjOTkzM0NDJyxcblx0JyM5OTMzRkYnLFxuXHQnIzk5Q0MwMCcsXG5cdCcjOTlDQzMzJyxcblx0JyNDQzAwMDAnLFxuXHQnI0NDMDAzMycsXG5cdCcjQ0MwMDY2Jyxcblx0JyNDQzAwOTknLFxuXHQnI0NDMDBDQycsXG5cdCcjQ0MwMEZGJyxcblx0JyNDQzMzMDAnLFxuXHQnI0NDMzMzMycsXG5cdCcjQ0MzMzY2Jyxcblx0JyNDQzMzOTknLFxuXHQnI0NDMzNDQycsXG5cdCcjQ0MzM0ZGJyxcblx0JyNDQzY2MDAnLFxuXHQnI0NDNjYzMycsXG5cdCcjQ0M5OTAwJyxcblx0JyNDQzk5MzMnLFxuXHQnI0NDQ0MwMCcsXG5cdCcjQ0NDQzMzJyxcblx0JyNGRjAwMDAnLFxuXHQnI0ZGMDAzMycsXG5cdCcjRkYwMDY2Jyxcblx0JyNGRjAwOTknLFxuXHQnI0ZGMDBDQycsXG5cdCcjRkYwMEZGJyxcblx0JyNGRjMzMDAnLFxuXHQnI0ZGMzMzMycsXG5cdCcjRkYzMzY2Jyxcblx0JyNGRjMzOTknLFxuXHQnI0ZGMzNDQycsXG5cdCcjRkYzM0ZGJyxcblx0JyNGRjY2MDAnLFxuXHQnI0ZGNjYzMycsXG5cdCcjRkY5OTAwJyxcblx0JyNGRjk5MzMnLFxuXHQnI0ZGQ0MwMCcsXG5cdCcjRkZDQzMzJ1xuXTtcblxuLyoqXG4gKiBDdXJyZW50bHkgb25seSBXZWJLaXQtYmFzZWQgV2ViIEluc3BlY3RvcnMsIEZpcmVmb3ggPj0gdjMxLFxuICogYW5kIHRoZSBGaXJlYnVnIGV4dGVuc2lvbiAoYW55IEZpcmVmb3ggdmVyc2lvbikgYXJlIGtub3duXG4gKiB0byBzdXBwb3J0IFwiJWNcIiBDU1MgY3VzdG9taXphdGlvbnMuXG4gKlxuICogVE9ETzogYWRkIGEgYGxvY2FsU3RvcmFnZWAgdmFyaWFibGUgdG8gZXhwbGljaXRseSBlbmFibGUvZGlzYWJsZSBjb2xvcnNcbiAqL1xuXG4vLyBlc2xpbnQtZGlzYWJsZS1uZXh0LWxpbmUgY29tcGxleGl0eVxuZnVuY3Rpb24gdXNlQ29sb3JzKCkge1xuXHQvLyBOQjogSW4gYW4gRWxlY3Ryb24gcHJlbG9hZCBzY3JpcHQsIGRvY3VtZW50IHdpbGwgYmUgZGVmaW5lZCBidXQgbm90IGZ1bGx5XG5cdC8vIGluaXRpYWxpemVkLiBTaW5jZSB3ZSBrbm93IHdlJ3JlIGluIENocm9tZSwgd2UnbGwganVzdCBkZXRlY3QgdGhpcyBjYXNlXG5cdC8vIGV4cGxpY2l0bHlcblx0aWYgKHR5cGVvZiB3aW5kb3cgIT09ICd1bmRlZmluZWQnICYmIHdpbmRvdy5wcm9jZXNzICYmICh3aW5kb3cucHJvY2Vzcy50eXBlID09PSAncmVuZGVyZXInIHx8IHdpbmRvdy5wcm9jZXNzLl9fbndqcykpIHtcblx0XHRyZXR1cm4gdHJ1ZTtcblx0fVxuXG5cdC8vIEludGVybmV0IEV4cGxvcmVyIGFuZCBFZGdlIGRvIG5vdCBzdXBwb3J0IGNvbG9ycy5cblx0aWYgKHR5cGVvZiBuYXZpZ2F0b3IgIT09ICd1bmRlZmluZWQnICYmIG5hdmlnYXRvci51c2VyQWdlbnQgJiYgbmF2aWdhdG9yLnVzZXJBZ2VudC50b0xvd2VyQ2FzZSgpLm1hdGNoKC8oZWRnZXx0cmlkZW50KVxcLyhcXGQrKS8pKSB7XG5cdFx0cmV0dXJuIGZhbHNlO1xuXHR9XG5cblx0Ly8gSXMgd2Via2l0PyBodHRwOi8vc3RhY2tvdmVyZmxvdy5jb20vYS8xNjQ1OTYwNi8zNzY3NzNcblx0Ly8gZG9jdW1lbnQgaXMgdW5kZWZpbmVkIGluIHJlYWN0LW5hdGl2ZTogaHR0cHM6Ly9naXRodWIuY29tL2ZhY2Vib29rL3JlYWN0LW5hdGl2ZS9wdWxsLzE2MzJcblx0cmV0dXJuICh0eXBlb2YgZG9jdW1lbnQgIT09ICd1bmRlZmluZWQnICYmIGRvY3VtZW50LmRvY3VtZW50RWxlbWVudCAmJiBkb2N1bWVudC5kb2N1bWVudEVsZW1lbnQuc3R5bGUgJiYgZG9jdW1lbnQuZG9jdW1lbnRFbGVtZW50LnN0eWxlLldlYmtpdEFwcGVhcmFuY2UpIHx8XG5cdFx0Ly8gSXMgZmlyZWJ1Zz8gaHR0cDovL3N0YWNrb3ZlcmZsb3cuY29tL2EvMzk4MTIwLzM3Njc3M1xuXHRcdCh0eXBlb2Ygd2luZG93ICE9PSAndW5kZWZpbmVkJyAmJiB3aW5kb3cuY29uc29sZSAmJiAod2luZG93LmNvbnNvbGUuZmlyZWJ1ZyB8fCAod2luZG93LmNvbnNvbGUuZXhjZXB0aW9uICYmIHdpbmRvdy5jb25zb2xlLnRhYmxlKSkpIHx8XG5cdFx0Ly8gSXMgZmlyZWZveCA+PSB2MzE/XG5cdFx0Ly8gaHR0cHM6Ly9kZXZlbG9wZXIubW96aWxsYS5vcmcvZW4tVVMvZG9jcy9Ub29scy9XZWJfQ29uc29sZSNTdHlsaW5nX21lc3NhZ2VzXG5cdFx0KHR5cGVvZiBuYXZpZ2F0b3IgIT09ICd1bmRlZmluZWQnICYmIG5hdmlnYXRvci51c2VyQWdlbnQgJiYgbmF2aWdhdG9yLnVzZXJBZ2VudC50b0xvd2VyQ2FzZSgpLm1hdGNoKC9maXJlZm94XFwvKFxcZCspLykgJiYgcGFyc2VJbnQoUmVnRXhwLiQxLCAxMCkgPj0gMzEpIHx8XG5cdFx0Ly8gRG91YmxlIGNoZWNrIHdlYmtpdCBpbiB1c2VyQWdlbnQganVzdCBpbiBjYXNlIHdlIGFyZSBpbiBhIHdvcmtlclxuXHRcdCh0eXBlb2YgbmF2aWdhdG9yICE9PSAndW5kZWZpbmVkJyAmJiBuYXZpZ2F0b3IudXNlckFnZW50ICYmIG5hdmlnYXRvci51c2VyQWdlbnQudG9Mb3dlckNhc2UoKS5tYXRjaCgvYXBwbGV3ZWJraXRcXC8oXFxkKykvKSk7XG59XG5cbi8qKlxuICogQ29sb3JpemUgbG9nIGFyZ3VtZW50cyBpZiBlbmFibGVkLlxuICpcbiAqIEBhcGkgcHVibGljXG4gKi9cblxuZnVuY3Rpb24gZm9ybWF0QXJncyhhcmdzKSB7XG5cdGFyZ3NbMF0gPSAodGhpcy51c2VDb2xvcnMgPyAnJWMnIDogJycpICtcblx0XHR0aGlzLm5hbWVzcGFjZSArXG5cdFx0KHRoaXMudXNlQ29sb3JzID8gJyAlYycgOiAnICcpICtcblx0XHRhcmdzWzBdICtcblx0XHQodGhpcy51c2VDb2xvcnMgPyAnJWMgJyA6ICcgJykgK1xuXHRcdCcrJyArIG1vZHVsZS5leHBvcnRzLmh1bWFuaXplKHRoaXMuZGlmZik7XG5cblx0aWYgKCF0aGlzLnVzZUNvbG9ycykge1xuXHRcdHJldHVybjtcblx0fVxuXG5cdGNvbnN0IGMgPSAnY29sb3I6ICcgKyB0aGlzLmNvbG9yO1xuXHRhcmdzLnNwbGljZSgxLCAwLCBjLCAnY29sb3I6IGluaGVyaXQnKTtcblxuXHQvLyBUaGUgZmluYWwgXCIlY1wiIGlzIHNvbWV3aGF0IHRyaWNreSwgYmVjYXVzZSB0aGVyZSBjb3VsZCBiZSBvdGhlclxuXHQvLyBhcmd1bWVudHMgcGFzc2VkIGVpdGhlciBiZWZvcmUgb3IgYWZ0ZXIgdGhlICVjLCBzbyB3ZSBuZWVkIHRvXG5cdC8vIGZpZ3VyZSBvdXQgdGhlIGNvcnJlY3QgaW5kZXggdG8gaW5zZXJ0IHRoZSBDU1MgaW50b1xuXHRsZXQgaW5kZXggPSAwO1xuXHRsZXQgbGFzdEMgPSAwO1xuXHRhcmdzWzBdLnJlcGxhY2UoLyVbYS16QS1aJV0vZywgbWF0Y2ggPT4ge1xuXHRcdGlmIChtYXRjaCA9PT0gJyUlJykge1xuXHRcdFx0cmV0dXJuO1xuXHRcdH1cblx0XHRpbmRleCsrO1xuXHRcdGlmIChtYXRjaCA9PT0gJyVjJykge1xuXHRcdFx0Ly8gV2Ugb25seSBhcmUgaW50ZXJlc3RlZCBpbiB0aGUgKmxhc3QqICVjXG5cdFx0XHQvLyAodGhlIHVzZXIgbWF5IGhhdmUgcHJvdmlkZWQgdGhlaXIgb3duKVxuXHRcdFx0bGFzdEMgPSBpbmRleDtcblx0XHR9XG5cdH0pO1xuXG5cdGFyZ3Muc3BsaWNlKGxhc3RDLCAwLCBjKTtcbn1cblxuLyoqXG4gKiBJbnZva2VzIGBjb25zb2xlLmRlYnVnKClgIHdoZW4gYXZhaWxhYmxlLlxuICogTm8tb3Agd2hlbiBgY29uc29sZS5kZWJ1Z2AgaXMgbm90IGEgXCJmdW5jdGlvblwiLlxuICogSWYgYGNvbnNvbGUuZGVidWdgIGlzIG5vdCBhdmFpbGFibGUsIGZhbGxzIGJhY2tcbiAqIHRvIGBjb25zb2xlLmxvZ2AuXG4gKlxuICogQGFwaSBwdWJsaWNcbiAqL1xuZXhwb3J0cy5sb2cgPSBjb25zb2xlLmRlYnVnIHx8IGNvbnNvbGUubG9nIHx8ICgoKSA9PiB7fSk7XG5cbi8qKlxuICogU2F2ZSBgbmFtZXNwYWNlc2AuXG4gKlxuICogQHBhcmFtIHtTdHJpbmd9IG5hbWVzcGFjZXNcbiAqIEBhcGkgcHJpdmF0ZVxuICovXG5mdW5jdGlvbiBzYXZlKG5hbWVzcGFjZXMpIHtcblx0dHJ5IHtcblx0XHRpZiAobmFtZXNwYWNlcykge1xuXHRcdFx0ZXhwb3J0cy5zdG9yYWdlLnNldEl0ZW0oJ2RlYnVnJywgbmFtZXNwYWNlcyk7XG5cdFx0fSBlbHNlIHtcblx0XHRcdGV4cG9ydHMuc3RvcmFnZS5yZW1vdmVJdGVtKCdkZWJ1ZycpO1xuXHRcdH1cblx0fSBjYXRjaCAoZXJyb3IpIHtcblx0XHQvLyBTd2FsbG93XG5cdFx0Ly8gWFhYIChAUWl4LSkgc2hvdWxkIHdlIGJlIGxvZ2dpbmcgdGhlc2U/XG5cdH1cbn1cblxuLyoqXG4gKiBMb2FkIGBuYW1lc3BhY2VzYC5cbiAqXG4gKiBAcmV0dXJuIHtTdHJpbmd9IHJldHVybnMgdGhlIHByZXZpb3VzbHkgcGVyc2lzdGVkIGRlYnVnIG1vZGVzXG4gKiBAYXBpIHByaXZhdGVcbiAqL1xuZnVuY3Rpb24gbG9hZCgpIHtcblx0bGV0IHI7XG5cdHRyeSB7XG5cdFx0ciA9IGV4cG9ydHMuc3RvcmFnZS5nZXRJdGVtKCdkZWJ1ZycpO1xuXHR9IGNhdGNoIChlcnJvcikge1xuXHRcdC8vIFN3YWxsb3dcblx0XHQvLyBYWFggKEBRaXgtKSBzaG91bGQgd2UgYmUgbG9nZ2luZyB0aGVzZT9cblx0fVxuXG5cdC8vIElmIGRlYnVnIGlzbid0IHNldCBpbiBMUywgYW5kIHdlJ3JlIGluIEVsZWN0cm9uLCB0cnkgdG8gbG9hZCAkREVCVUdcblx0aWYgKCFyICYmIHR5cGVvZiBwcm9jZXNzICE9PSAndW5kZWZpbmVkJyAmJiAnZW52JyBpbiBwcm9jZXNzKSB7XG5cdFx0ciA9IHByb2Nlc3MuZW52LkRFQlVHO1xuXHR9XG5cblx0cmV0dXJuIHI7XG59XG5cbi8qKlxuICogTG9jYWxzdG9yYWdlIGF0dGVtcHRzIHRvIHJldHVybiB0aGUgbG9jYWxzdG9yYWdlLlxuICpcbiAqIFRoaXMgaXMgbmVjZXNzYXJ5IGJlY2F1c2Ugc2FmYXJpIHRocm93c1xuICogd2hlbiBhIHVzZXIgZGlzYWJsZXMgY29va2llcy9sb2NhbHN0b3JhZ2VcbiAqIGFuZCB5b3UgYXR0ZW1wdCB0byBhY2Nlc3MgaXQuXG4gKlxuICogQHJldHVybiB7TG9jYWxTdG9yYWdlfVxuICogQGFwaSBwcml2YXRlXG4gKi9cblxuZnVuY3Rpb24gbG9jYWxzdG9yYWdlKCkge1xuXHR0cnkge1xuXHRcdC8vIFRWTUxLaXQgKEFwcGxlIFRWIEpTIFJ1bnRpbWUpIGRvZXMgbm90IGhhdmUgYSB3aW5kb3cgb2JqZWN0LCBqdXN0IGxvY2FsU3RvcmFnZSBpbiB0aGUgZ2xvYmFsIGNvbnRleHRcblx0XHQvLyBUaGUgQnJvd3NlciBhbHNvIGhhcyBsb2NhbFN0b3JhZ2UgaW4gdGhlIGdsb2JhbCBjb250ZXh0LlxuXHRcdHJldHVybiBsb2NhbFN0b3JhZ2U7XG5cdH0gY2F0Y2ggKGVycm9yKSB7XG5cdFx0Ly8gU3dhbGxvd1xuXHRcdC8vIFhYWCAoQFFpeC0pIHNob3VsZCB3ZSBiZSBsb2dnaW5nIHRoZXNlP1xuXHR9XG59XG5cbm1vZHVsZS5leHBvcnRzID0gcmVxdWlyZSgnLi9jb21tb24nKShleHBvcnRzKTtcblxuY29uc3Qge2Zvcm1hdHRlcnN9ID0gbW9kdWxlLmV4cG9ydHM7XG5cbi8qKlxuICogTWFwICVqIHRvIGBKU09OLnN0cmluZ2lmeSgpYCwgc2luY2Ugbm8gV2ViIEluc3BlY3RvcnMgZG8gdGhhdCBieSBkZWZhdWx0LlxuICovXG5cbmZvcm1hdHRlcnMuaiA9IGZ1bmN0aW9uICh2KSB7XG5cdHRyeSB7XG5cdFx0cmV0dXJuIEpTT04uc3RyaW5naWZ5KHYpO1xuXHR9IGNhdGNoIChlcnJvcikge1xuXHRcdHJldHVybiAnW1VuZXhwZWN0ZWRKU09OUGFyc2VFcnJvcl06ICcgKyBlcnJvci5tZXNzYWdlO1xuXHR9XG59O1xuIiwiXG4vKipcbiAqIFRoaXMgaXMgdGhlIGNvbW1vbiBsb2dpYyBmb3IgYm90aCB0aGUgTm9kZS5qcyBhbmQgd2ViIGJyb3dzZXJcbiAqIGltcGxlbWVudGF0aW9ucyBvZiBgZGVidWcoKWAuXG4gKi9cblxuZnVuY3Rpb24gc2V0dXAoZW52KSB7XG5cdGNyZWF0ZURlYnVnLmRlYnVnID0gY3JlYXRlRGVidWc7XG5cdGNyZWF0ZURlYnVnLmRlZmF1bHQgPSBjcmVhdGVEZWJ1Zztcblx0Y3JlYXRlRGVidWcuY29lcmNlID0gY29lcmNlO1xuXHRjcmVhdGVEZWJ1Zy5kaXNhYmxlID0gZGlzYWJsZTtcblx0Y3JlYXRlRGVidWcuZW5hYmxlID0gZW5hYmxlO1xuXHRjcmVhdGVEZWJ1Zy5lbmFibGVkID0gZW5hYmxlZDtcblx0Y3JlYXRlRGVidWcuaHVtYW5pemUgPSByZXF1aXJlKCdtcycpO1xuXHRjcmVhdGVEZWJ1Zy5kZXN0cm95ID0gZGVzdHJveTtcblxuXHRPYmplY3Qua2V5cyhlbnYpLmZvckVhY2goa2V5ID0+IHtcblx0XHRjcmVhdGVEZWJ1Z1trZXldID0gZW52W2tleV07XG5cdH0pO1xuXG5cdC8qKlxuXHQqIFRoZSBjdXJyZW50bHkgYWN0aXZlIGRlYnVnIG1vZGUgbmFtZXMsIGFuZCBuYW1lcyB0byBza2lwLlxuXHQqL1xuXG5cdGNyZWF0ZURlYnVnLm5hbWVzID0gW107XG5cdGNyZWF0ZURlYnVnLnNraXBzID0gW107XG5cblx0LyoqXG5cdCogTWFwIG9mIHNwZWNpYWwgXCIlblwiIGhhbmRsaW5nIGZ1bmN0aW9ucywgZm9yIHRoZSBkZWJ1ZyBcImZvcm1hdFwiIGFyZ3VtZW50LlxuXHQqXG5cdCogVmFsaWQga2V5IG5hbWVzIGFyZSBhIHNpbmdsZSwgbG93ZXIgb3IgdXBwZXItY2FzZSBsZXR0ZXIsIGkuZS4gXCJuXCIgYW5kIFwiTlwiLlxuXHQqL1xuXHRjcmVhdGVEZWJ1Zy5mb3JtYXR0ZXJzID0ge307XG5cblx0LyoqXG5cdCogU2VsZWN0cyBhIGNvbG9yIGZvciBhIGRlYnVnIG5hbWVzcGFjZVxuXHQqIEBwYXJhbSB7U3RyaW5nfSBuYW1lc3BhY2UgVGhlIG5hbWVzcGFjZSBzdHJpbmcgZm9yIHRoZSBkZWJ1ZyBpbnN0YW5jZSB0byBiZSBjb2xvcmVkXG5cdCogQHJldHVybiB7TnVtYmVyfFN0cmluZ30gQW4gQU5TSSBjb2xvciBjb2RlIGZvciB0aGUgZ2l2ZW4gbmFtZXNwYWNlXG5cdCogQGFwaSBwcml2YXRlXG5cdCovXG5cdGZ1bmN0aW9uIHNlbGVjdENvbG9yKG5hbWVzcGFjZSkge1xuXHRcdGxldCBoYXNoID0gMDtcblxuXHRcdGZvciAobGV0IGkgPSAwOyBpIDwgbmFtZXNwYWNlLmxlbmd0aDsgaSsrKSB7XG5cdFx0XHRoYXNoID0gKChoYXNoIDw8IDUpIC0gaGFzaCkgKyBuYW1lc3BhY2UuY2hhckNvZGVBdChpKTtcblx0XHRcdGhhc2ggfD0gMDsgLy8gQ29udmVydCB0byAzMmJpdCBpbnRlZ2VyXG5cdFx0fVxuXG5cdFx0cmV0dXJuIGNyZWF0ZURlYnVnLmNvbG9yc1tNYXRoLmFicyhoYXNoKSAlIGNyZWF0ZURlYnVnLmNvbG9ycy5sZW5ndGhdO1xuXHR9XG5cdGNyZWF0ZURlYnVnLnNlbGVjdENvbG9yID0gc2VsZWN0Q29sb3I7XG5cblx0LyoqXG5cdCogQ3JlYXRlIGEgZGVidWdnZXIgd2l0aCB0aGUgZ2l2ZW4gYG5hbWVzcGFjZWAuXG5cdCpcblx0KiBAcGFyYW0ge1N0cmluZ30gbmFtZXNwYWNlXG5cdCogQHJldHVybiB7RnVuY3Rpb259XG5cdCogQGFwaSBwdWJsaWNcblx0Ki9cblx0ZnVuY3Rpb24gY3JlYXRlRGVidWcobmFtZXNwYWNlKSB7XG5cdFx0bGV0IHByZXZUaW1lO1xuXHRcdGxldCBlbmFibGVPdmVycmlkZSA9IG51bGw7XG5cdFx0bGV0IG5hbWVzcGFjZXNDYWNoZTtcblx0XHRsZXQgZW5hYmxlZENhY2hlO1xuXG5cdFx0ZnVuY3Rpb24gZGVidWcoLi4uYXJncykge1xuXHRcdFx0Ly8gRGlzYWJsZWQ/XG5cdFx0XHRpZiAoIWRlYnVnLmVuYWJsZWQpIHtcblx0XHRcdFx0cmV0dXJuO1xuXHRcdFx0fVxuXG5cdFx0XHRjb25zdCBzZWxmID0gZGVidWc7XG5cblx0XHRcdC8vIFNldCBgZGlmZmAgdGltZXN0YW1wXG5cdFx0XHRjb25zdCBjdXJyID0gTnVtYmVyKG5ldyBEYXRlKCkpO1xuXHRcdFx0Y29uc3QgbXMgPSBjdXJyIC0gKHByZXZUaW1lIHx8IGN1cnIpO1xuXHRcdFx0c2VsZi5kaWZmID0gbXM7XG5cdFx0XHRzZWxmLnByZXYgPSBwcmV2VGltZTtcblx0XHRcdHNlbGYuY3VyciA9IGN1cnI7XG5cdFx0XHRwcmV2VGltZSA9IGN1cnI7XG5cblx0XHRcdGFyZ3NbMF0gPSBjcmVhdGVEZWJ1Zy5jb2VyY2UoYXJnc1swXSk7XG5cblx0XHRcdGlmICh0eXBlb2YgYXJnc1swXSAhPT0gJ3N0cmluZycpIHtcblx0XHRcdFx0Ly8gQW55dGhpbmcgZWxzZSBsZXQncyBpbnNwZWN0IHdpdGggJU9cblx0XHRcdFx0YXJncy51bnNoaWZ0KCclTycpO1xuXHRcdFx0fVxuXG5cdFx0XHQvLyBBcHBseSBhbnkgYGZvcm1hdHRlcnNgIHRyYW5zZm9ybWF0aW9uc1xuXHRcdFx0bGV0IGluZGV4ID0gMDtcblx0XHRcdGFyZ3NbMF0gPSBhcmdzWzBdLnJlcGxhY2UoLyUoW2EtekEtWiVdKS9nLCAobWF0Y2gsIGZvcm1hdCkgPT4ge1xuXHRcdFx0XHQvLyBJZiB3ZSBlbmNvdW50ZXIgYW4gZXNjYXBlZCAlIHRoZW4gZG9uJ3QgaW5jcmVhc2UgdGhlIGFycmF5IGluZGV4XG5cdFx0XHRcdGlmIChtYXRjaCA9PT0gJyUlJykge1xuXHRcdFx0XHRcdHJldHVybiAnJSc7XG5cdFx0XHRcdH1cblx0XHRcdFx0aW5kZXgrKztcblx0XHRcdFx0Y29uc3QgZm9ybWF0dGVyID0gY3JlYXRlRGVidWcuZm9ybWF0dGVyc1tmb3JtYXRdO1xuXHRcdFx0XHRpZiAodHlwZW9mIGZvcm1hdHRlciA9PT0gJ2Z1bmN0aW9uJykge1xuXHRcdFx0XHRcdGNvbnN0IHZhbCA9IGFyZ3NbaW5kZXhdO1xuXHRcdFx0XHRcdG1hdGNoID0gZm9ybWF0dGVyLmNhbGwoc2VsZiwgdmFsKTtcblxuXHRcdFx0XHRcdC8vIE5vdyB3ZSBuZWVkIHRvIHJlbW92ZSBgYXJnc1tpbmRleF1gIHNpbmNlIGl0J3MgaW5saW5lZCBpbiB0aGUgYGZvcm1hdGBcblx0XHRcdFx0XHRhcmdzLnNwbGljZShpbmRleCwgMSk7XG5cdFx0XHRcdFx0aW5kZXgtLTtcblx0XHRcdFx0fVxuXHRcdFx0XHRyZXR1cm4gbWF0Y2g7XG5cdFx0XHR9KTtcblxuXHRcdFx0Ly8gQXBwbHkgZW52LXNwZWNpZmljIGZvcm1hdHRpbmcgKGNvbG9ycywgZXRjLilcblx0XHRcdGNyZWF0ZURlYnVnLmZvcm1hdEFyZ3MuY2FsbChzZWxmLCBhcmdzKTtcblxuXHRcdFx0Y29uc3QgbG9nRm4gPSBzZWxmLmxvZyB8fCBjcmVhdGVEZWJ1Zy5sb2c7XG5cdFx0XHRsb2dGbi5hcHBseShzZWxmLCBhcmdzKTtcblx0XHR9XG5cblx0XHRkZWJ1Zy5uYW1lc3BhY2UgPSBuYW1lc3BhY2U7XG5cdFx0ZGVidWcudXNlQ29sb3JzID0gY3JlYXRlRGVidWcudXNlQ29sb3JzKCk7XG5cdFx0ZGVidWcuY29sb3IgPSBjcmVhdGVEZWJ1Zy5zZWxlY3RDb2xvcihuYW1lc3BhY2UpO1xuXHRcdGRlYnVnLmV4dGVuZCA9IGV4dGVuZDtcblx0XHRkZWJ1Zy5kZXN0cm95ID0gY3JlYXRlRGVidWcuZGVzdHJveTsgLy8gWFhYIFRlbXBvcmFyeS4gV2lsbCBiZSByZW1vdmVkIGluIHRoZSBuZXh0IG1ham9yIHJlbGVhc2UuXG5cblx0XHRPYmplY3QuZGVmaW5lUHJvcGVydHkoZGVidWcsICdlbmFibGVkJywge1xuXHRcdFx0ZW51bWVyYWJsZTogdHJ1ZSxcblx0XHRcdGNvbmZpZ3VyYWJsZTogZmFsc2UsXG5cdFx0XHRnZXQ6ICgpID0+IHtcblx0XHRcdFx0aWYgKGVuYWJsZU92ZXJyaWRlICE9PSBudWxsKSB7XG5cdFx0XHRcdFx0cmV0dXJuIGVuYWJsZU92ZXJyaWRlO1xuXHRcdFx0XHR9XG5cdFx0XHRcdGlmIChuYW1lc3BhY2VzQ2FjaGUgIT09IGNyZWF0ZURlYnVnLm5hbWVzcGFjZXMpIHtcblx0XHRcdFx0XHRuYW1lc3BhY2VzQ2FjaGUgPSBjcmVhdGVEZWJ1Zy5uYW1lc3BhY2VzO1xuXHRcdFx0XHRcdGVuYWJsZWRDYWNoZSA9IGNyZWF0ZURlYnVnLmVuYWJsZWQobmFtZXNwYWNlKTtcblx0XHRcdFx0fVxuXG5cdFx0XHRcdHJldHVybiBlbmFibGVkQ2FjaGU7XG5cdFx0XHR9LFxuXHRcdFx0c2V0OiB2ID0+IHtcblx0XHRcdFx0ZW5hYmxlT3ZlcnJpZGUgPSB2O1xuXHRcdFx0fVxuXHRcdH0pO1xuXG5cdFx0Ly8gRW52LXNwZWNpZmljIGluaXRpYWxpemF0aW9uIGxvZ2ljIGZvciBkZWJ1ZyBpbnN0YW5jZXNcblx0XHRpZiAodHlwZW9mIGNyZWF0ZURlYnVnLmluaXQgPT09ICdmdW5jdGlvbicpIHtcblx0XHRcdGNyZWF0ZURlYnVnLmluaXQoZGVidWcpO1xuXHRcdH1cblxuXHRcdHJldHVybiBkZWJ1Zztcblx0fVxuXG5cdGZ1bmN0aW9uIGV4dGVuZChuYW1lc3BhY2UsIGRlbGltaXRlcikge1xuXHRcdGNvbnN0IG5ld0RlYnVnID0gY3JlYXRlRGVidWcodGhpcy5uYW1lc3BhY2UgKyAodHlwZW9mIGRlbGltaXRlciA9PT0gJ3VuZGVmaW5lZCcgPyAnOicgOiBkZWxpbWl0ZXIpICsgbmFtZXNwYWNlKTtcblx0XHRuZXdEZWJ1Zy5sb2cgPSB0aGlzLmxvZztcblx0XHRyZXR1cm4gbmV3RGVidWc7XG5cdH1cblxuXHQvKipcblx0KiBFbmFibGVzIGEgZGVidWcgbW9kZSBieSBuYW1lc3BhY2VzLiBUaGlzIGNhbiBpbmNsdWRlIG1vZGVzXG5cdCogc2VwYXJhdGVkIGJ5IGEgY29sb24gYW5kIHdpbGRjYXJkcy5cblx0KlxuXHQqIEBwYXJhbSB7U3RyaW5nfSBuYW1lc3BhY2VzXG5cdCogQGFwaSBwdWJsaWNcblx0Ki9cblx0ZnVuY3Rpb24gZW5hYmxlKG5hbWVzcGFjZXMpIHtcblx0XHRjcmVhdGVEZWJ1Zy5zYXZlKG5hbWVzcGFjZXMpO1xuXHRcdGNyZWF0ZURlYnVnLm5hbWVzcGFjZXMgPSBuYW1lc3BhY2VzO1xuXG5cdFx0Y3JlYXRlRGVidWcubmFtZXMgPSBbXTtcblx0XHRjcmVhdGVEZWJ1Zy5za2lwcyA9IFtdO1xuXG5cdFx0bGV0IGk7XG5cdFx0Y29uc3Qgc3BsaXQgPSAodHlwZW9mIG5hbWVzcGFjZXMgPT09ICdzdHJpbmcnID8gbmFtZXNwYWNlcyA6ICcnKS5zcGxpdCgvW1xccyxdKy8pO1xuXHRcdGNvbnN0IGxlbiA9IHNwbGl0Lmxlbmd0aDtcblxuXHRcdGZvciAoaSA9IDA7IGkgPCBsZW47IGkrKykge1xuXHRcdFx0aWYgKCFzcGxpdFtpXSkge1xuXHRcdFx0XHQvLyBpZ25vcmUgZW1wdHkgc3RyaW5nc1xuXHRcdFx0XHRjb250aW51ZTtcblx0XHRcdH1cblxuXHRcdFx0bmFtZXNwYWNlcyA9IHNwbGl0W2ldLnJlcGxhY2UoL1xcKi9nLCAnLio/Jyk7XG5cblx0XHRcdGlmIChuYW1lc3BhY2VzWzBdID09PSAnLScpIHtcblx0XHRcdFx0Y3JlYXRlRGVidWcuc2tpcHMucHVzaChuZXcgUmVnRXhwKCdeJyArIG5hbWVzcGFjZXMuc2xpY2UoMSkgKyAnJCcpKTtcblx0XHRcdH0gZWxzZSB7XG5cdFx0XHRcdGNyZWF0ZURlYnVnLm5hbWVzLnB1c2gobmV3IFJlZ0V4cCgnXicgKyBuYW1lc3BhY2VzICsgJyQnKSk7XG5cdFx0XHR9XG5cdFx0fVxuXHR9XG5cblx0LyoqXG5cdCogRGlzYWJsZSBkZWJ1ZyBvdXRwdXQuXG5cdCpcblx0KiBAcmV0dXJuIHtTdHJpbmd9IG5hbWVzcGFjZXNcblx0KiBAYXBpIHB1YmxpY1xuXHQqL1xuXHRmdW5jdGlvbiBkaXNhYmxlKCkge1xuXHRcdGNvbnN0IG5hbWVzcGFjZXMgPSBbXG5cdFx0XHQuLi5jcmVhdGVEZWJ1Zy5uYW1lcy5tYXAodG9OYW1lc3BhY2UpLFxuXHRcdFx0Li4uY3JlYXRlRGVidWcuc2tpcHMubWFwKHRvTmFtZXNwYWNlKS5tYXAobmFtZXNwYWNlID0+ICctJyArIG5hbWVzcGFjZSlcblx0XHRdLmpvaW4oJywnKTtcblx0XHRjcmVhdGVEZWJ1Zy5lbmFibGUoJycpO1xuXHRcdHJldHVybiBuYW1lc3BhY2VzO1xuXHR9XG5cblx0LyoqXG5cdCogUmV0dXJucyB0cnVlIGlmIHRoZSBnaXZlbiBtb2RlIG5hbWUgaXMgZW5hYmxlZCwgZmFsc2Ugb3RoZXJ3aXNlLlxuXHQqXG5cdCogQHBhcmFtIHtTdHJpbmd9IG5hbWVcblx0KiBAcmV0dXJuIHtCb29sZWFufVxuXHQqIEBhcGkgcHVibGljXG5cdCovXG5cdGZ1bmN0aW9uIGVuYWJsZWQobmFtZSkge1xuXHRcdGlmIChuYW1lW25hbWUubGVuZ3RoIC0gMV0gPT09ICcqJykge1xuXHRcdFx0cmV0dXJuIHRydWU7XG5cdFx0fVxuXG5cdFx0bGV0IGk7XG5cdFx0bGV0IGxlbjtcblxuXHRcdGZvciAoaSA9IDAsIGxlbiA9IGNyZWF0ZURlYnVnLnNraXBzLmxlbmd0aDsgaSA8IGxlbjsgaSsrKSB7XG5cdFx0XHRpZiAoY3JlYXRlRGVidWcuc2tpcHNbaV0udGVzdChuYW1lKSkge1xuXHRcdFx0XHRyZXR1cm4gZmFsc2U7XG5cdFx0XHR9XG5cdFx0fVxuXG5cdFx0Zm9yIChpID0gMCwgbGVuID0gY3JlYXRlRGVidWcubmFtZXMubGVuZ3RoOyBpIDwgbGVuOyBpKyspIHtcblx0XHRcdGlmIChjcmVhdGVEZWJ1Zy5uYW1lc1tpXS50ZXN0KG5hbWUpKSB7XG5cdFx0XHRcdHJldHVybiB0cnVlO1xuXHRcdFx0fVxuXHRcdH1cblxuXHRcdHJldHVybiBmYWxzZTtcblx0fVxuXG5cdC8qKlxuXHQqIENvbnZlcnQgcmVnZXhwIHRvIG5hbWVzcGFjZVxuXHQqXG5cdCogQHBhcmFtIHtSZWdFeHB9IHJlZ3hlcFxuXHQqIEByZXR1cm4ge1N0cmluZ30gbmFtZXNwYWNlXG5cdCogQGFwaSBwcml2YXRlXG5cdCovXG5cdGZ1bmN0aW9uIHRvTmFtZXNwYWNlKHJlZ2V4cCkge1xuXHRcdHJldHVybiByZWdleHAudG9TdHJpbmcoKVxuXHRcdFx0LnN1YnN0cmluZygyLCByZWdleHAudG9TdHJpbmcoKS5sZW5ndGggLSAyKVxuXHRcdFx0LnJlcGxhY2UoL1xcLlxcKlxcPyQvLCAnKicpO1xuXHR9XG5cblx0LyoqXG5cdCogQ29lcmNlIGB2YWxgLlxuXHQqXG5cdCogQHBhcmFtIHtNaXhlZH0gdmFsXG5cdCogQHJldHVybiB7TWl4ZWR9XG5cdCogQGFwaSBwcml2YXRlXG5cdCovXG5cdGZ1bmN0aW9uIGNvZXJjZSh2YWwpIHtcblx0XHRpZiAodmFsIGluc3RhbmNlb2YgRXJyb3IpIHtcblx0XHRcdHJldHVybiB2YWwuc3RhY2sgfHwgdmFsLm1lc3NhZ2U7XG5cdFx0fVxuXHRcdHJldHVybiB2YWw7XG5cdH1cblxuXHQvKipcblx0KiBYWFggRE8gTk9UIFVTRS4gVGhpcyBpcyBhIHRlbXBvcmFyeSBzdHViIGZ1bmN0aW9uLlxuXHQqIFhYWCBJdCBXSUxMIGJlIHJlbW92ZWQgaW4gdGhlIG5leHQgbWFqb3IgcmVsZWFzZS5cblx0Ki9cblx0ZnVuY3Rpb24gZGVzdHJveSgpIHtcblx0XHRjb25zb2xlLndhcm4oJ0luc3RhbmNlIG1ldGhvZCBgZGVidWcuZGVzdHJveSgpYCBpcyBkZXByZWNhdGVkIGFuZCBubyBsb25nZXIgZG9lcyBhbnl0aGluZy4gSXQgd2lsbCBiZSByZW1vdmVkIGluIHRoZSBuZXh0IG1ham9yIHZlcnNpb24gb2YgYGRlYnVnYC4nKTtcblx0fVxuXG5cdGNyZWF0ZURlYnVnLmVuYWJsZShjcmVhdGVEZWJ1Zy5sb2FkKCkpO1xuXG5cdHJldHVybiBjcmVhdGVEZWJ1Zztcbn1cblxubW9kdWxlLmV4cG9ydHMgPSBzZXR1cDtcbiIsIi8qKlxuICogRGV0ZWN0IEVsZWN0cm9uIHJlbmRlcmVyIC8gbndqcyBwcm9jZXNzLCB3aGljaCBpcyBub2RlLCBidXQgd2Ugc2hvdWxkXG4gKiB0cmVhdCBhcyBhIGJyb3dzZXIuXG4gKi9cblxuaWYgKHR5cGVvZiBwcm9jZXNzID09PSAndW5kZWZpbmVkJyB8fCBwcm9jZXNzLnR5cGUgPT09ICdyZW5kZXJlcicgfHwgcHJvY2Vzcy5icm93c2VyID09PSB0cnVlIHx8IHByb2Nlc3MuX19ud2pzKSB7XG5cdG1vZHVsZS5leHBvcnRzID0gcmVxdWlyZSgnLi9icm93c2VyLmpzJyk7XG59IGVsc2Uge1xuXHRtb2R1bGUuZXhwb3J0cyA9IHJlcXVpcmUoJy4vbm9kZS5qcycpO1xufVxuIiwiLyoqXG4gKiBNb2R1bGUgZGVwZW5kZW5jaWVzLlxuICovXG5cbmNvbnN0IHR0eSA9IHJlcXVpcmUoJ3R0eScpO1xuY29uc3QgdXRpbCA9IHJlcXVpcmUoJ3V0aWwnKTtcblxuLyoqXG4gKiBUaGlzIGlzIHRoZSBOb2RlLmpzIGltcGxlbWVudGF0aW9uIG9mIGBkZWJ1ZygpYC5cbiAqL1xuXG5leHBvcnRzLmluaXQgPSBpbml0O1xuZXhwb3J0cy5sb2cgPSBsb2c7XG5leHBvcnRzLmZvcm1hdEFyZ3MgPSBmb3JtYXRBcmdzO1xuZXhwb3J0cy5zYXZlID0gc2F2ZTtcbmV4cG9ydHMubG9hZCA9IGxvYWQ7XG5leHBvcnRzLnVzZUNvbG9ycyA9IHVzZUNvbG9ycztcbmV4cG9ydHMuZGVzdHJveSA9IHV0aWwuZGVwcmVjYXRlKFxuXHQoKSA9PiB7fSxcblx0J0luc3RhbmNlIG1ldGhvZCBgZGVidWcuZGVzdHJveSgpYCBpcyBkZXByZWNhdGVkIGFuZCBubyBsb25nZXIgZG9lcyBhbnl0aGluZy4gSXQgd2lsbCBiZSByZW1vdmVkIGluIHRoZSBuZXh0IG1ham9yIHZlcnNpb24gb2YgYGRlYnVnYC4nXG4pO1xuXG4vKipcbiAqIENvbG9ycy5cbiAqL1xuXG5leHBvcnRzLmNvbG9ycyA9IFs2LCAyLCAzLCA0LCA1LCAxXTtcblxudHJ5IHtcblx0Ly8gT3B0aW9uYWwgZGVwZW5kZW5jeSAoYXMgaW4sIGRvZXNuJ3QgbmVlZCB0byBiZSBpbnN0YWxsZWQsIE5PVCBsaWtlIG9wdGlvbmFsRGVwZW5kZW5jaWVzIGluIHBhY2thZ2UuanNvbilcblx0Ly8gZXNsaW50LWRpc2FibGUtbmV4dC1saW5lIGltcG9ydC9uby1leHRyYW5lb3VzLWRlcGVuZGVuY2llc1xuXHRjb25zdCBzdXBwb3J0c0NvbG9yID0gcmVxdWlyZSgnc3VwcG9ydHMtY29sb3InKTtcblxuXHRpZiAoc3VwcG9ydHNDb2xvciAmJiAoc3VwcG9ydHNDb2xvci5zdGRlcnIgfHwgc3VwcG9ydHNDb2xvcikubGV2ZWwgPj0gMikge1xuXHRcdGV4cG9ydHMuY29sb3JzID0gW1xuXHRcdFx0MjAsXG5cdFx0XHQyMSxcblx0XHRcdDI2LFxuXHRcdFx0MjcsXG5cdFx0XHQzMixcblx0XHRcdDMzLFxuXHRcdFx0MzgsXG5cdFx0XHQzOSxcblx0XHRcdDQwLFxuXHRcdFx0NDEsXG5cdFx0XHQ0Mixcblx0XHRcdDQzLFxuXHRcdFx0NDQsXG5cdFx0XHQ0NSxcblx0XHRcdDU2LFxuXHRcdFx0NTcsXG5cdFx0XHQ2Mixcblx0XHRcdDYzLFxuXHRcdFx0NjgsXG5cdFx0XHQ2OSxcblx0XHRcdDc0LFxuXHRcdFx0NzUsXG5cdFx0XHQ3Nixcblx0XHRcdDc3LFxuXHRcdFx0NzgsXG5cdFx0XHQ3OSxcblx0XHRcdDgwLFxuXHRcdFx0ODEsXG5cdFx0XHQ5Mixcblx0XHRcdDkzLFxuXHRcdFx0OTgsXG5cdFx0XHQ5OSxcblx0XHRcdDExMixcblx0XHRcdDExMyxcblx0XHRcdDEyOCxcblx0XHRcdDEyOSxcblx0XHRcdDEzNCxcblx0XHRcdDEzNSxcblx0XHRcdDE0OCxcblx0XHRcdDE0OSxcblx0XHRcdDE2MCxcblx0XHRcdDE2MSxcblx0XHRcdDE2Mixcblx0XHRcdDE2Myxcblx0XHRcdDE2NCxcblx0XHRcdDE2NSxcblx0XHRcdDE2Nixcblx0XHRcdDE2Nyxcblx0XHRcdDE2OCxcblx0XHRcdDE2OSxcblx0XHRcdDE3MCxcblx0XHRcdDE3MSxcblx0XHRcdDE3Mixcblx0XHRcdDE3Myxcblx0XHRcdDE3OCxcblx0XHRcdDE3OSxcblx0XHRcdDE4NCxcblx0XHRcdDE4NSxcblx0XHRcdDE5Nixcblx0XHRcdDE5Nyxcblx0XHRcdDE5OCxcblx0XHRcdDE5OSxcblx0XHRcdDIwMCxcblx0XHRcdDIwMSxcblx0XHRcdDIwMixcblx0XHRcdDIwMyxcblx0XHRcdDIwNCxcblx0XHRcdDIwNSxcblx0XHRcdDIwNixcblx0XHRcdDIwNyxcblx0XHRcdDIwOCxcblx0XHRcdDIwOSxcblx0XHRcdDIxNCxcblx0XHRcdDIxNSxcblx0XHRcdDIyMCxcblx0XHRcdDIyMVxuXHRcdF07XG5cdH1cbn0gY2F0Y2ggKGVycm9yKSB7XG5cdC8vIFN3YWxsb3cgLSB3ZSBvbmx5IGNhcmUgaWYgYHN1cHBvcnRzLWNvbG9yYCBpcyBhdmFpbGFibGU7IGl0IGRvZXNuJ3QgaGF2ZSB0byBiZS5cbn1cblxuLyoqXG4gKiBCdWlsZCB1cCB0aGUgZGVmYXVsdCBgaW5zcGVjdE9wdHNgIG9iamVjdCBmcm9tIHRoZSBlbnZpcm9ubWVudCB2YXJpYWJsZXMuXG4gKlxuICogICAkIERFQlVHX0NPTE9SUz1ubyBERUJVR19ERVBUSD0xMCBERUJVR19TSE9XX0hJRERFTj1lbmFibGVkIG5vZGUgc2NyaXB0LmpzXG4gKi9cblxuZXhwb3J0cy5pbnNwZWN0T3B0cyA9IE9iamVjdC5rZXlzKHByb2Nlc3MuZW52KS5maWx0ZXIoa2V5ID0+IHtcblx0cmV0dXJuIC9eZGVidWdfL2kudGVzdChrZXkpO1xufSkucmVkdWNlKChvYmosIGtleSkgPT4ge1xuXHQvLyBDYW1lbC1jYXNlXG5cdGNvbnN0IHByb3AgPSBrZXlcblx0XHQuc3Vic3RyaW5nKDYpXG5cdFx0LnRvTG93ZXJDYXNlKClcblx0XHQucmVwbGFjZSgvXyhbYS16XSkvZywgKF8sIGspID0+IHtcblx0XHRcdHJldHVybiBrLnRvVXBwZXJDYXNlKCk7XG5cdFx0fSk7XG5cblx0Ly8gQ29lcmNlIHN0cmluZyB2YWx1ZSBpbnRvIEpTIHZhbHVlXG5cdGxldCB2YWwgPSBwcm9jZXNzLmVudltrZXldO1xuXHRpZiAoL14oeWVzfG9ufHRydWV8ZW5hYmxlZCkkL2kudGVzdCh2YWwpKSB7XG5cdFx0dmFsID0gdHJ1ZTtcblx0fSBlbHNlIGlmICgvXihub3xvZmZ8ZmFsc2V8ZGlzYWJsZWQpJC9pLnRlc3QodmFsKSkge1xuXHRcdHZhbCA9IGZhbHNlO1xuXHR9IGVsc2UgaWYgKHZhbCA9PT0gJ251bGwnKSB7XG5cdFx0dmFsID0gbnVsbDtcblx0fSBlbHNlIHtcblx0XHR2YWwgPSBOdW1iZXIodmFsKTtcblx0fVxuXG5cdG9ialtwcm9wXSA9IHZhbDtcblx0cmV0dXJuIG9iajtcbn0sIHt9KTtcblxuLyoqXG4gKiBJcyBzdGRvdXQgYSBUVFk/IENvbG9yZWQgb3V0cHV0IGlzIGVuYWJsZWQgd2hlbiBgdHJ1ZWAuXG4gKi9cblxuZnVuY3Rpb24gdXNlQ29sb3JzKCkge1xuXHRyZXR1cm4gJ2NvbG9ycycgaW4gZXhwb3J0cy5pbnNwZWN0T3B0cyA/XG5cdFx0Qm9vbGVhbihleHBvcnRzLmluc3BlY3RPcHRzLmNvbG9ycykgOlxuXHRcdHR0eS5pc2F0dHkocHJvY2Vzcy5zdGRlcnIuZmQpO1xufVxuXG4vKipcbiAqIEFkZHMgQU5TSSBjb2xvciBlc2NhcGUgY29kZXMgaWYgZW5hYmxlZC5cbiAqXG4gKiBAYXBpIHB1YmxpY1xuICovXG5cbmZ1bmN0aW9uIGZvcm1hdEFyZ3MoYXJncykge1xuXHRjb25zdCB7bmFtZXNwYWNlOiBuYW1lLCB1c2VDb2xvcnN9ID0gdGhpcztcblxuXHRpZiAodXNlQ29sb3JzKSB7XG5cdFx0Y29uc3QgYyA9IHRoaXMuY29sb3I7XG5cdFx0Y29uc3QgY29sb3JDb2RlID0gJ1xcdTAwMUJbMycgKyAoYyA8IDggPyBjIDogJzg7NTsnICsgYyk7XG5cdFx0Y29uc3QgcHJlZml4ID0gYCAgJHtjb2xvckNvZGV9OzFtJHtuYW1lfSBcXHUwMDFCWzBtYDtcblxuXHRcdGFyZ3NbMF0gPSBwcmVmaXggKyBhcmdzWzBdLnNwbGl0KCdcXG4nKS5qb2luKCdcXG4nICsgcHJlZml4KTtcblx0XHRhcmdzLnB1c2goY29sb3JDb2RlICsgJ20rJyArIG1vZHVsZS5leHBvcnRzLmh1bWFuaXplKHRoaXMuZGlmZikgKyAnXFx1MDAxQlswbScpO1xuXHR9IGVsc2Uge1xuXHRcdGFyZ3NbMF0gPSBnZXREYXRlKCkgKyBuYW1lICsgJyAnICsgYXJnc1swXTtcblx0fVxufVxuXG5mdW5jdGlvbiBnZXREYXRlKCkge1xuXHRpZiAoZXhwb3J0cy5pbnNwZWN0T3B0cy5oaWRlRGF0ZSkge1xuXHRcdHJldHVybiAnJztcblx0fVxuXHRyZXR1cm4gbmV3IERhdGUoKS50b0lTT1N0cmluZygpICsgJyAnO1xufVxuXG4vKipcbiAqIEludm9rZXMgYHV0aWwuZm9ybWF0KClgIHdpdGggdGhlIHNwZWNpZmllZCBhcmd1bWVudHMgYW5kIHdyaXRlcyB0byBzdGRlcnIuXG4gKi9cblxuZnVuY3Rpb24gbG9nKC4uLmFyZ3MpIHtcblx0cmV0dXJuIHByb2Nlc3Muc3RkZXJyLndyaXRlKHV0aWwuZm9ybWF0KC4uLmFyZ3MpICsgJ1xcbicpO1xufVxuXG4vKipcbiAqIFNhdmUgYG5hbWVzcGFjZXNgLlxuICpcbiAqIEBwYXJhbSB7U3RyaW5nfSBuYW1lc3BhY2VzXG4gKiBAYXBpIHByaXZhdGVcbiAqL1xuZnVuY3Rpb24gc2F2ZShuYW1lc3BhY2VzKSB7XG5cdGlmIChuYW1lc3BhY2VzKSB7XG5cdFx0cHJvY2Vzcy5lbnYuREVCVUcgPSBuYW1lc3BhY2VzO1xuXHR9IGVsc2Uge1xuXHRcdC8vIElmIHlvdSBzZXQgYSBwcm9jZXNzLmVudiBmaWVsZCB0byBudWxsIG9yIHVuZGVmaW5lZCwgaXQgZ2V0cyBjYXN0IHRvIHRoZVxuXHRcdC8vIHN0cmluZyAnbnVsbCcgb3IgJ3VuZGVmaW5lZCcuIEp1c3QgZGVsZXRlIGluc3RlYWQuXG5cdFx0ZGVsZXRlIHByb2Nlc3MuZW52LkRFQlVHO1xuXHR9XG59XG5cbi8qKlxuICogTG9hZCBgbmFtZXNwYWNlc2AuXG4gKlxuICogQHJldHVybiB7U3RyaW5nfSByZXR1cm5zIHRoZSBwcmV2aW91c2x5IHBlcnNpc3RlZCBkZWJ1ZyBtb2Rlc1xuICogQGFwaSBwcml2YXRlXG4gKi9cblxuZnVuY3Rpb24gbG9hZCgpIHtcblx0cmV0dXJuIHByb2Nlc3MuZW52LkRFQlVHO1xufVxuXG4vKipcbiAqIEluaXQgbG9naWMgZm9yIGBkZWJ1Z2AgaW5zdGFuY2VzLlxuICpcbiAqIENyZWF0ZSBhIG5ldyBgaW5zcGVjdE9wdHNgIG9iamVjdCBpbiBjYXNlIGB1c2VDb2xvcnNgIGlzIHNldFxuICogZGlmZmVyZW50bHkgZm9yIGEgcGFydGljdWxhciBgZGVidWdgIGluc3RhbmNlLlxuICovXG5cbmZ1bmN0aW9uIGluaXQoZGVidWcpIHtcblx0ZGVidWcuaW5zcGVjdE9wdHMgPSB7fTtcblxuXHRjb25zdCBrZXlzID0gT2JqZWN0LmtleXMoZXhwb3J0cy5pbnNwZWN0T3B0cyk7XG5cdGZvciAobGV0IGkgPSAwOyBpIDwga2V5cy5sZW5ndGg7IGkrKykge1xuXHRcdGRlYnVnLmluc3BlY3RPcHRzW2tleXNbaV1dID0gZXhwb3J0cy5pbnNwZWN0T3B0c1trZXlzW2ldXTtcblx0fVxufVxuXG5tb2R1bGUuZXhwb3J0cyA9IHJlcXVpcmUoJy4vY29tbW9uJykoZXhwb3J0cyk7XG5cbmNvbnN0IHtmb3JtYXR0ZXJzfSA9IG1vZHVsZS5leHBvcnRzO1xuXG4vKipcbiAqIE1hcCAlbyB0byBgdXRpbC5pbnNwZWN0KClgLCBhbGwgb24gYSBzaW5nbGUgbGluZS5cbiAqL1xuXG5mb3JtYXR0ZXJzLm8gPSBmdW5jdGlvbiAodikge1xuXHR0aGlzLmluc3BlY3RPcHRzLmNvbG9ycyA9IHRoaXMudXNlQ29sb3JzO1xuXHRyZXR1cm4gdXRpbC5pbnNwZWN0KHYsIHRoaXMuaW5zcGVjdE9wdHMpXG5cdFx0LnNwbGl0KCdcXG4nKVxuXHRcdC5tYXAoc3RyID0+IHN0ci50cmltKCkpXG5cdFx0LmpvaW4oJyAnKTtcbn07XG5cbi8qKlxuICogTWFwICVPIHRvIGB1dGlsLmluc3BlY3QoKWAsIGFsbG93aW5nIG11bHRpcGxlIGxpbmVzIGlmIG5lZWRlZC5cbiAqL1xuXG5mb3JtYXR0ZXJzLk8gPSBmdW5jdGlvbiAodikge1xuXHR0aGlzLmluc3BlY3RPcHRzLmNvbG9ycyA9IHRoaXMudXNlQ29sb3JzO1xuXHRyZXR1cm4gdXRpbC5pbnNwZWN0KHYsIHRoaXMuaW5zcGVjdE9wdHMpO1xufTtcbiIsIid1c2Ugc3RyaWN0JztcblxubW9kdWxlLmV4cG9ydHMgPSAoZmxhZywgYXJndiA9IHByb2Nlc3MuYXJndikgPT4ge1xuXHRjb25zdCBwcmVmaXggPSBmbGFnLnN0YXJ0c1dpdGgoJy0nKSA/ICcnIDogKGZsYWcubGVuZ3RoID09PSAxID8gJy0nIDogJy0tJyk7XG5cdGNvbnN0IHBvc2l0aW9uID0gYXJndi5pbmRleE9mKHByZWZpeCArIGZsYWcpO1xuXHRjb25zdCB0ZXJtaW5hdG9yUG9zaXRpb24gPSBhcmd2LmluZGV4T2YoJy0tJyk7XG5cdHJldHVybiBwb3NpdGlvbiAhPT0gLTEgJiYgKHRlcm1pbmF0b3JQb3NpdGlvbiA9PT0gLTEgfHwgcG9zaXRpb24gPCB0ZXJtaW5hdG9yUG9zaXRpb24pO1xufTtcbiIsIi8qKlxuICogSGVscGVycy5cbiAqL1xuXG52YXIgcyA9IDEwMDA7XG52YXIgbSA9IHMgKiA2MDtcbnZhciBoID0gbSAqIDYwO1xudmFyIGQgPSBoICogMjQ7XG52YXIgdyA9IGQgKiA3O1xudmFyIHkgPSBkICogMzY1LjI1O1xuXG4vKipcbiAqIFBhcnNlIG9yIGZvcm1hdCB0aGUgZ2l2ZW4gYHZhbGAuXG4gKlxuICogT3B0aW9uczpcbiAqXG4gKiAgLSBgbG9uZ2AgdmVyYm9zZSBmb3JtYXR0aW5nIFtmYWxzZV1cbiAqXG4gKiBAcGFyYW0ge1N0cmluZ3xOdW1iZXJ9IHZhbFxuICogQHBhcmFtIHtPYmplY3R9IFtvcHRpb25zXVxuICogQHRocm93cyB7RXJyb3J9IHRocm93IGFuIGVycm9yIGlmIHZhbCBpcyBub3QgYSBub24tZW1wdHkgc3RyaW5nIG9yIGEgbnVtYmVyXG4gKiBAcmV0dXJuIHtTdHJpbmd8TnVtYmVyfVxuICogQGFwaSBwdWJsaWNcbiAqL1xuXG5tb2R1bGUuZXhwb3J0cyA9IGZ1bmN0aW9uKHZhbCwgb3B0aW9ucykge1xuICBvcHRpb25zID0gb3B0aW9ucyB8fCB7fTtcbiAgdmFyIHR5cGUgPSB0eXBlb2YgdmFsO1xuICBpZiAodHlwZSA9PT0gJ3N0cmluZycgJiYgdmFsLmxlbmd0aCA+IDApIHtcbiAgICByZXR1cm4gcGFyc2UodmFsKTtcbiAgfSBlbHNlIGlmICh0eXBlID09PSAnbnVtYmVyJyAmJiBpc0Zpbml0ZSh2YWwpKSB7XG4gICAgcmV0dXJuIG9wdGlvbnMubG9uZyA/IGZtdExvbmcodmFsKSA6IGZtdFNob3J0KHZhbCk7XG4gIH1cbiAgdGhyb3cgbmV3IEVycm9yKFxuICAgICd2YWwgaXMgbm90IGEgbm9uLWVtcHR5IHN0cmluZyBvciBhIHZhbGlkIG51bWJlci4gdmFsPScgK1xuICAgICAgSlNPTi5zdHJpbmdpZnkodmFsKVxuICApO1xufTtcblxuLyoqXG4gKiBQYXJzZSB0aGUgZ2l2ZW4gYHN0cmAgYW5kIHJldHVybiBtaWxsaXNlY29uZHMuXG4gKlxuICogQHBhcmFtIHtTdHJpbmd9IHN0clxuICogQHJldHVybiB7TnVtYmVyfVxuICogQGFwaSBwcml2YXRlXG4gKi9cblxuZnVuY3Rpb24gcGFyc2Uoc3RyKSB7XG4gIHN0ciA9IFN0cmluZyhzdHIpO1xuICBpZiAoc3RyLmxlbmd0aCA+IDEwMCkge1xuICAgIHJldHVybjtcbiAgfVxuICB2YXIgbWF0Y2ggPSAvXigtPyg/OlxcZCspP1xcLj9cXGQrKSAqKG1pbGxpc2Vjb25kcz98bXNlY3M/fG1zfHNlY29uZHM/fHNlY3M/fHN8bWludXRlcz98bWlucz98bXxob3Vycz98aHJzP3xofGRheXM/fGR8d2Vla3M/fHd8eWVhcnM/fHlycz98eSk/JC9pLmV4ZWMoXG4gICAgc3RyXG4gICk7XG4gIGlmICghbWF0Y2gpIHtcbiAgICByZXR1cm47XG4gIH1cbiAgdmFyIG4gPSBwYXJzZUZsb2F0KG1hdGNoWzFdKTtcbiAgdmFyIHR5cGUgPSAobWF0Y2hbMl0gfHwgJ21zJykudG9Mb3dlckNhc2UoKTtcbiAgc3dpdGNoICh0eXBlKSB7XG4gICAgY2FzZSAneWVhcnMnOlxuICAgIGNhc2UgJ3llYXInOlxuICAgIGNhc2UgJ3lycyc6XG4gICAgY2FzZSAneXInOlxuICAgIGNhc2UgJ3knOlxuICAgICAgcmV0dXJuIG4gKiB5O1xuICAgIGNhc2UgJ3dlZWtzJzpcbiAgICBjYXNlICd3ZWVrJzpcbiAgICBjYXNlICd3JzpcbiAgICAgIHJldHVybiBuICogdztcbiAgICBjYXNlICdkYXlzJzpcbiAgICBjYXNlICdkYXknOlxuICAgIGNhc2UgJ2QnOlxuICAgICAgcmV0dXJuIG4gKiBkO1xuICAgIGNhc2UgJ2hvdXJzJzpcbiAgICBjYXNlICdob3VyJzpcbiAgICBjYXNlICdocnMnOlxuICAgIGNhc2UgJ2hyJzpcbiAgICBjYXNlICdoJzpcbiAgICAgIHJldHVybiBuICogaDtcbiAgICBjYXNlICdtaW51dGVzJzpcbiAgICBjYXNlICdtaW51dGUnOlxuICAgIGNhc2UgJ21pbnMnOlxuICAgIGNhc2UgJ21pbic6XG4gICAgY2FzZSAnbSc6XG4gICAgICByZXR1cm4gbiAqIG07XG4gICAgY2FzZSAnc2Vjb25kcyc6XG4gICAgY2FzZSAnc2Vjb25kJzpcbiAgICBjYXNlICdzZWNzJzpcbiAgICBjYXNlICdzZWMnOlxuICAgIGNhc2UgJ3MnOlxuICAgICAgcmV0dXJuIG4gKiBzO1xuICAgIGNhc2UgJ21pbGxpc2Vjb25kcyc6XG4gICAgY2FzZSAnbWlsbGlzZWNvbmQnOlxuICAgIGNhc2UgJ21zZWNzJzpcbiAgICBjYXNlICdtc2VjJzpcbiAgICBjYXNlICdtcyc6XG4gICAgICByZXR1cm4gbjtcbiAgICBkZWZhdWx0OlxuICAgICAgcmV0dXJuIHVuZGVmaW5lZDtcbiAgfVxufVxuXG4vKipcbiAqIFNob3J0IGZvcm1hdCBmb3IgYG1zYC5cbiAqXG4gKiBAcGFyYW0ge051bWJlcn0gbXNcbiAqIEByZXR1cm4ge1N0cmluZ31cbiAqIEBhcGkgcHJpdmF0ZVxuICovXG5cbmZ1bmN0aW9uIGZtdFNob3J0KG1zKSB7XG4gIHZhciBtc0FicyA9IE1hdGguYWJzKG1zKTtcbiAgaWYgKG1zQWJzID49IGQpIHtcbiAgICByZXR1cm4gTWF0aC5yb3VuZChtcyAvIGQpICsgJ2QnO1xuICB9XG4gIGlmIChtc0FicyA+PSBoKSB7XG4gICAgcmV0dXJuIE1hdGgucm91bmQobXMgLyBoKSArICdoJztcbiAgfVxuICBpZiAobXNBYnMgPj0gbSkge1xuICAgIHJldHVybiBNYXRoLnJvdW5kKG1zIC8gbSkgKyAnbSc7XG4gIH1cbiAgaWYgKG1zQWJzID49IHMpIHtcbiAgICByZXR1cm4gTWF0aC5yb3VuZChtcyAvIHMpICsgJ3MnO1xuICB9XG4gIHJldHVybiBtcyArICdtcyc7XG59XG5cbi8qKlxuICogTG9uZyBmb3JtYXQgZm9yIGBtc2AuXG4gKlxuICogQHBhcmFtIHtOdW1iZXJ9IG1zXG4gKiBAcmV0dXJuIHtTdHJpbmd9XG4gKiBAYXBpIHByaXZhdGVcbiAqL1xuXG5mdW5jdGlvbiBmbXRMb25nKG1zKSB7XG4gIHZhciBtc0FicyA9IE1hdGguYWJzKG1zKTtcbiAgaWYgKG1zQWJzID49IGQpIHtcbiAgICByZXR1cm4gcGx1cmFsKG1zLCBtc0FicywgZCwgJ2RheScpO1xuICB9XG4gIGlmIChtc0FicyA+PSBoKSB7XG4gICAgcmV0dXJuIHBsdXJhbChtcywgbXNBYnMsIGgsICdob3VyJyk7XG4gIH1cbiAgaWYgKG1zQWJzID49IG0pIHtcbiAgICByZXR1cm4gcGx1cmFsKG1zLCBtc0FicywgbSwgJ21pbnV0ZScpO1xuICB9XG4gIGlmIChtc0FicyA+PSBzKSB7XG4gICAgcmV0dXJuIHBsdXJhbChtcywgbXNBYnMsIHMsICdzZWNvbmQnKTtcbiAgfVxuICByZXR1cm4gbXMgKyAnIG1zJztcbn1cblxuLyoqXG4gKiBQbHVyYWxpemF0aW9uIGhlbHBlci5cbiAqL1xuXG5mdW5jdGlvbiBwbHVyYWwobXMsIG1zQWJzLCBuLCBuYW1lKSB7XG4gIHZhciBpc1BsdXJhbCA9IG1zQWJzID49IG4gKiAxLjU7XG4gIHJldHVybiBNYXRoLnJvdW5kKG1zIC8gbikgKyAnICcgKyBuYW1lICsgKGlzUGx1cmFsID8gJ3MnIDogJycpO1xufVxuIiwidmFyIGZzID0gcmVxdWlyZSgnZnMnKVxudmFyIHBhdGggPSByZXF1aXJlKCdwYXRoJylcbnZhciBvcyA9IHJlcXVpcmUoJ29zJylcblxuLy8gV29ya2Fyb3VuZCB0byBmaXggd2VicGFjaydzIGJ1aWxkIHdhcm5pbmdzOiAndGhlIHJlcXVlc3Qgb2YgYSBkZXBlbmRlbmN5IGlzIGFuIGV4cHJlc3Npb24nXG52YXIgcnVudGltZVJlcXVpcmUgPSB0eXBlb2YgX193ZWJwYWNrX3JlcXVpcmVfXyA9PT0gJ2Z1bmN0aW9uJyA/IF9fbm9uX3dlYnBhY2tfcmVxdWlyZV9fIDogcmVxdWlyZSAvLyBlc2xpbnQtZGlzYWJsZS1saW5lXG5cbnZhciB2YXJzID0gKHByb2Nlc3MuY29uZmlnICYmIHByb2Nlc3MuY29uZmlnLnZhcmlhYmxlcykgfHwge31cbnZhciBwcmVidWlsZHNPbmx5ID0gISFwcm9jZXNzLmVudi5QUkVCVUlMRFNfT05MWVxudmFyIGFiaSA9IHByb2Nlc3MudmVyc2lvbnMubW9kdWxlcyAvLyBUT0RPOiBzdXBwb3J0IG9sZCBub2RlIHdoZXJlIHRoaXMgaXMgdW5kZWZcbnZhciBydW50aW1lID0gaXNFbGVjdHJvbigpID8gJ2VsZWN0cm9uJyA6IChpc053anMoKSA/ICdub2RlLXdlYmtpdCcgOiAnbm9kZScpXG5cbnZhciBhcmNoID0gb3MuYXJjaCgpXG52YXIgcGxhdGZvcm0gPSBvcy5wbGF0Zm9ybSgpXG52YXIgbGliYyA9IHByb2Nlc3MuZW52LkxJQkMgfHwgKGlzQWxwaW5lKHBsYXRmb3JtKSA/ICdtdXNsJyA6ICdnbGliYycpXG52YXIgYXJtdiA9IHByb2Nlc3MuZW52LkFSTV9WRVJTSU9OIHx8IChhcmNoID09PSAnYXJtNjQnID8gJzgnIDogdmFycy5hcm1fdmVyc2lvbikgfHwgJydcbnZhciB1diA9IChwcm9jZXNzLnZlcnNpb25zLnV2IHx8ICcnKS5zcGxpdCgnLicpWzBdXG5cbm1vZHVsZS5leHBvcnRzID0gbG9hZFxuXG5mdW5jdGlvbiBsb2FkIChkaXIpIHtcbiAgcmV0dXJuIHJ1bnRpbWVSZXF1aXJlKGxvYWQucGF0aChkaXIpKVxufVxuXG5sb2FkLnBhdGggPSBmdW5jdGlvbiAoZGlyKSB7XG4gIGRpciA9IHBhdGgucmVzb2x2ZShkaXIgfHwgJy4nKVxuXG4gIHRyeSB7XG4gICAgdmFyIG5hbWUgPSBydW50aW1lUmVxdWlyZShwYXRoLmpvaW4oZGlyLCAncGFja2FnZS5qc29uJykpLm5hbWUudG9VcHBlckNhc2UoKS5yZXBsYWNlKC8tL2csICdfJylcbiAgICBpZiAocHJvY2Vzcy5lbnZbbmFtZSArICdfUFJFQlVJTEQnXSkgZGlyID0gcHJvY2Vzcy5lbnZbbmFtZSArICdfUFJFQlVJTEQnXVxuICB9IGNhdGNoIChlcnIpIHt9XG5cbiAgaWYgKCFwcmVidWlsZHNPbmx5KSB7XG4gICAgdmFyIHJlbGVhc2UgPSBnZXRGaXJzdChwYXRoLmpvaW4oZGlyLCAnYnVpbGQvUmVsZWFzZScpLCBtYXRjaEJ1aWxkKVxuICAgIGlmIChyZWxlYXNlKSByZXR1cm4gcmVsZWFzZVxuXG4gICAgdmFyIGRlYnVnID0gZ2V0Rmlyc3QocGF0aC5qb2luKGRpciwgJ2J1aWxkL0RlYnVnJyksIG1hdGNoQnVpbGQpXG4gICAgaWYgKGRlYnVnKSByZXR1cm4gZGVidWdcbiAgfVxuXG4gIHZhciBwcmVidWlsZCA9IHJlc29sdmUoZGlyKVxuICBpZiAocHJlYnVpbGQpIHJldHVybiBwcmVidWlsZFxuXG4gIHZhciBuZWFyYnkgPSByZXNvbHZlKHBhdGguZGlybmFtZShwcm9jZXNzLmV4ZWNQYXRoKSlcbiAgaWYgKG5lYXJieSkgcmV0dXJuIG5lYXJieVxuXG4gIHZhciB0YXJnZXQgPSBbXG4gICAgJ3BsYXRmb3JtPScgKyBwbGF0Zm9ybSxcbiAgICAnYXJjaD0nICsgYXJjaCxcbiAgICAncnVudGltZT0nICsgcnVudGltZSxcbiAgICAnYWJpPScgKyBhYmksXG4gICAgJ3V2PScgKyB1dixcbiAgICBhcm12ID8gJ2FybXY9JyArIGFybXYgOiAnJyxcbiAgICAnbGliYz0nICsgbGliYyxcbiAgICAnbm9kZT0nICsgcHJvY2Vzcy52ZXJzaW9ucy5ub2RlLFxuICAgIHByb2Nlc3MudmVyc2lvbnMuZWxlY3Ryb24gPyAnZWxlY3Ryb249JyArIHByb2Nlc3MudmVyc2lvbnMuZWxlY3Ryb24gOiAnJyxcbiAgICB0eXBlb2YgX193ZWJwYWNrX3JlcXVpcmVfXyA9PT0gJ2Z1bmN0aW9uJyA/ICd3ZWJwYWNrPXRydWUnIDogJycgLy8gZXNsaW50LWRpc2FibGUtbGluZVxuICBdLmZpbHRlcihCb29sZWFuKS5qb2luKCcgJylcblxuICB0aHJvdyBuZXcgRXJyb3IoJ05vIG5hdGl2ZSBidWlsZCB3YXMgZm91bmQgZm9yICcgKyB0YXJnZXQgKyAnXFxuICAgIGxvYWRlZCBmcm9tOiAnICsgZGlyICsgJ1xcbicpXG5cbiAgZnVuY3Rpb24gcmVzb2x2ZSAoZGlyKSB7XG4gICAgLy8gRmluZCBtYXRjaGluZyBcInByZWJ1aWxkcy88cGxhdGZvcm0+LTxhcmNoPlwiIGRpcmVjdG9yeVxuICAgIHZhciB0dXBsZXMgPSByZWFkZGlyU3luYyhwYXRoLmpvaW4oZGlyLCAncHJlYnVpbGRzJykpLm1hcChwYXJzZVR1cGxlKVxuICAgIHZhciB0dXBsZSA9IHR1cGxlcy5maWx0ZXIobWF0Y2hUdXBsZShwbGF0Zm9ybSwgYXJjaCkpLnNvcnQoY29tcGFyZVR1cGxlcylbMF1cbiAgICBpZiAoIXR1cGxlKSByZXR1cm5cblxuICAgIC8vIEZpbmQgbW9zdCBzcGVjaWZpYyBmbGF2b3IgZmlyc3RcbiAgICB2YXIgcHJlYnVpbGRzID0gcGF0aC5qb2luKGRpciwgJ3ByZWJ1aWxkcycsIHR1cGxlLm5hbWUpXG4gICAgdmFyIHBhcnNlZCA9IHJlYWRkaXJTeW5jKHByZWJ1aWxkcykubWFwKHBhcnNlVGFncylcbiAgICB2YXIgY2FuZGlkYXRlcyA9IHBhcnNlZC5maWx0ZXIobWF0Y2hUYWdzKHJ1bnRpbWUsIGFiaSkpXG4gICAgdmFyIHdpbm5lciA9IGNhbmRpZGF0ZXMuc29ydChjb21wYXJlVGFncyhydW50aW1lKSlbMF1cbiAgICBpZiAod2lubmVyKSByZXR1cm4gcGF0aC5qb2luKHByZWJ1aWxkcywgd2lubmVyLmZpbGUpXG4gIH1cbn1cblxuZnVuY3Rpb24gcmVhZGRpclN5bmMgKGRpcikge1xuICB0cnkge1xuICAgIHJldHVybiBmcy5yZWFkZGlyU3luYyhkaXIpXG4gIH0gY2F0Y2ggKGVycikge1xuICAgIHJldHVybiBbXVxuICB9XG59XG5cbmZ1bmN0aW9uIGdldEZpcnN0IChkaXIsIGZpbHRlcikge1xuICB2YXIgZmlsZXMgPSByZWFkZGlyU3luYyhkaXIpLmZpbHRlcihmaWx0ZXIpXG4gIHJldHVybiBmaWxlc1swXSAmJiBwYXRoLmpvaW4oZGlyLCBmaWxlc1swXSlcbn1cblxuZnVuY3Rpb24gbWF0Y2hCdWlsZCAobmFtZSkge1xuICByZXR1cm4gL1xcLm5vZGUkLy50ZXN0KG5hbWUpXG59XG5cbmZ1bmN0aW9uIHBhcnNlVHVwbGUgKG5hbWUpIHtcbiAgLy8gRXhhbXBsZTogZGFyd2luLXg2NCthcm02NFxuICB2YXIgYXJyID0gbmFtZS5zcGxpdCgnLScpXG4gIGlmIChhcnIubGVuZ3RoICE9PSAyKSByZXR1cm5cblxuICB2YXIgcGxhdGZvcm0gPSBhcnJbMF1cbiAgdmFyIGFyY2hpdGVjdHVyZXMgPSBhcnJbMV0uc3BsaXQoJysnKVxuXG4gIGlmICghcGxhdGZvcm0pIHJldHVyblxuICBpZiAoIWFyY2hpdGVjdHVyZXMubGVuZ3RoKSByZXR1cm5cbiAgaWYgKCFhcmNoaXRlY3R1cmVzLmV2ZXJ5KEJvb2xlYW4pKSByZXR1cm5cblxuICByZXR1cm4geyBuYW1lLCBwbGF0Zm9ybSwgYXJjaGl0ZWN0dXJlcyB9XG59XG5cbmZ1bmN0aW9uIG1hdGNoVHVwbGUgKHBsYXRmb3JtLCBhcmNoKSB7XG4gIHJldHVybiBmdW5jdGlvbiAodHVwbGUpIHtcbiAgICBpZiAodHVwbGUgPT0gbnVsbCkgcmV0dXJuIGZhbHNlXG4gICAgaWYgKHR1cGxlLnBsYXRmb3JtICE9PSBwbGF0Zm9ybSkgcmV0dXJuIGZhbHNlXG4gICAgcmV0dXJuIHR1cGxlLmFyY2hpdGVjdHVyZXMuaW5jbHVkZXMoYXJjaClcbiAgfVxufVxuXG5mdW5jdGlvbiBjb21wYXJlVHVwbGVzIChhLCBiKSB7XG4gIC8vIFByZWZlciBzaW5nbGUtYXJjaCBwcmVidWlsZHMgb3ZlciBtdWx0aS1hcmNoXG4gIHJldHVybiBhLmFyY2hpdGVjdHVyZXMubGVuZ3RoIC0gYi5hcmNoaXRlY3R1cmVzLmxlbmd0aFxufVxuXG5mdW5jdGlvbiBwYXJzZVRhZ3MgKGZpbGUpIHtcbiAgdmFyIGFyciA9IGZpbGUuc3BsaXQoJy4nKVxuICB2YXIgZXh0ZW5zaW9uID0gYXJyLnBvcCgpXG4gIHZhciB0YWdzID0geyBmaWxlOiBmaWxlLCBzcGVjaWZpY2l0eTogMCB9XG5cbiAgaWYgKGV4dGVuc2lvbiAhPT0gJ25vZGUnKSByZXR1cm5cblxuICBmb3IgKHZhciBpID0gMDsgaSA8IGFyci5sZW5ndGg7IGkrKykge1xuICAgIHZhciB0YWcgPSBhcnJbaV1cblxuICAgIGlmICh0YWcgPT09ICdub2RlJyB8fCB0YWcgPT09ICdlbGVjdHJvbicgfHwgdGFnID09PSAnbm9kZS13ZWJraXQnKSB7XG4gICAgICB0YWdzLnJ1bnRpbWUgPSB0YWdcbiAgICB9IGVsc2UgaWYgKHRhZyA9PT0gJ25hcGknKSB7XG4gICAgICB0YWdzLm5hcGkgPSB0cnVlXG4gICAgfSBlbHNlIGlmICh0YWcuc2xpY2UoMCwgMykgPT09ICdhYmknKSB7XG4gICAgICB0YWdzLmFiaSA9IHRhZy5zbGljZSgzKVxuICAgIH0gZWxzZSBpZiAodGFnLnNsaWNlKDAsIDIpID09PSAndXYnKSB7XG4gICAgICB0YWdzLnV2ID0gdGFnLnNsaWNlKDIpXG4gICAgfSBlbHNlIGlmICh0YWcuc2xpY2UoMCwgNCkgPT09ICdhcm12Jykge1xuICAgICAgdGFncy5hcm12ID0gdGFnLnNsaWNlKDQpXG4gICAgfSBlbHNlIGlmICh0YWcgPT09ICdnbGliYycgfHwgdGFnID09PSAnbXVzbCcpIHtcbiAgICAgIHRhZ3MubGliYyA9IHRhZ1xuICAgIH0gZWxzZSB7XG4gICAgICBjb250aW51ZVxuICAgIH1cblxuICAgIHRhZ3Muc3BlY2lmaWNpdHkrK1xuICB9XG5cbiAgcmV0dXJuIHRhZ3Ncbn1cblxuZnVuY3Rpb24gbWF0Y2hUYWdzIChydW50aW1lLCBhYmkpIHtcbiAgcmV0dXJuIGZ1bmN0aW9uICh0YWdzKSB7XG4gICAgaWYgKHRhZ3MgPT0gbnVsbCkgcmV0dXJuIGZhbHNlXG4gICAgaWYgKHRhZ3MucnVudGltZSAhPT0gcnVudGltZSAmJiAhcnVudGltZUFnbm9zdGljKHRhZ3MpKSByZXR1cm4gZmFsc2VcbiAgICBpZiAodGFncy5hYmkgIT09IGFiaSAmJiAhdGFncy5uYXBpKSByZXR1cm4gZmFsc2VcbiAgICBpZiAodGFncy51diAmJiB0YWdzLnV2ICE9PSB1dikgcmV0dXJuIGZhbHNlXG4gICAgaWYgKHRhZ3MuYXJtdiAmJiB0YWdzLmFybXYgIT09IGFybXYpIHJldHVybiBmYWxzZVxuICAgIGlmICh0YWdzLmxpYmMgJiYgdGFncy5saWJjICE9PSBsaWJjKSByZXR1cm4gZmFsc2VcblxuICAgIHJldHVybiB0cnVlXG4gIH1cbn1cblxuZnVuY3Rpb24gcnVudGltZUFnbm9zdGljICh0YWdzKSB7XG4gIHJldHVybiB0YWdzLnJ1bnRpbWUgPT09ICdub2RlJyAmJiB0YWdzLm5hcGlcbn1cblxuZnVuY3Rpb24gY29tcGFyZVRhZ3MgKHJ1bnRpbWUpIHtcbiAgLy8gUHJlY2VkZW5jZTogbm9uLWFnbm9zdGljIHJ1bnRpbWUsIGFiaSBvdmVyIG5hcGksIHRoZW4gYnkgc3BlY2lmaWNpdHkuXG4gIHJldHVybiBmdW5jdGlvbiAoYSwgYikge1xuICAgIGlmIChhLnJ1bnRpbWUgIT09IGIucnVudGltZSkge1xuICAgICAgcmV0dXJuIGEucnVudGltZSA9PT0gcnVudGltZSA/IC0xIDogMVxuICAgIH0gZWxzZSBpZiAoYS5hYmkgIT09IGIuYWJpKSB7XG4gICAgICByZXR1cm4gYS5hYmkgPyAtMSA6IDFcbiAgICB9IGVsc2UgaWYgKGEuc3BlY2lmaWNpdHkgIT09IGIuc3BlY2lmaWNpdHkpIHtcbiAgICAgIHJldHVybiBhLnNwZWNpZmljaXR5ID4gYi5zcGVjaWZpY2l0eSA/IC0xIDogMVxuICAgIH0gZWxzZSB7XG4gICAgICByZXR1cm4gMFxuICAgIH1cbiAgfVxufVxuXG5mdW5jdGlvbiBpc053anMgKCkge1xuICByZXR1cm4gISEocHJvY2Vzcy52ZXJzaW9ucyAmJiBwcm9jZXNzLnZlcnNpb25zLm53KVxufVxuXG5mdW5jdGlvbiBpc0VsZWN0cm9uICgpIHtcbiAgaWYgKHByb2Nlc3MudmVyc2lvbnMgJiYgcHJvY2Vzcy52ZXJzaW9ucy5lbGVjdHJvbikgcmV0dXJuIHRydWVcbiAgaWYgKHByb2Nlc3MuZW52LkVMRUNUUk9OX1JVTl9BU19OT0RFKSByZXR1cm4gdHJ1ZVxuICByZXR1cm4gdHlwZW9mIHdpbmRvdyAhPT0gJ3VuZGVmaW5lZCcgJiYgd2luZG93LnByb2Nlc3MgJiYgd2luZG93LnByb2Nlc3MudHlwZSA9PT0gJ3JlbmRlcmVyJ1xufVxuXG5mdW5jdGlvbiBpc0FscGluZSAocGxhdGZvcm0pIHtcbiAgcmV0dXJuIHBsYXRmb3JtID09PSAnbGludXgnICYmIGZzLmV4aXN0c1N5bmMoJy9ldGMvYWxwaW5lLXJlbGVhc2UnKVxufVxuXG4vLyBFeHBvc2VkIGZvciB1bml0IHRlc3RzXG4vLyBUT0RPOiBtb3ZlIHRvIGxpYlxubG9hZC5wYXJzZVRhZ3MgPSBwYXJzZVRhZ3NcbmxvYWQubWF0Y2hUYWdzID0gbWF0Y2hUYWdzXG5sb2FkLmNvbXBhcmVUYWdzID0gY29tcGFyZVRhZ3NcbmxvYWQucGFyc2VUdXBsZSA9IHBhcnNlVHVwbGVcbmxvYWQubWF0Y2hUdXBsZSA9IG1hdGNoVHVwbGVcbmxvYWQuY29tcGFyZVR1cGxlcyA9IGNvbXBhcmVUdXBsZXNcbiIsIlwidXNlIHN0cmljdFwiO1xudmFyIF9fY3JlYXRlQmluZGluZyA9ICh0aGlzICYmIHRoaXMuX19jcmVhdGVCaW5kaW5nKSB8fCAoT2JqZWN0LmNyZWF0ZSA/IChmdW5jdGlvbihvLCBtLCBrLCBrMikge1xuICAgIGlmIChrMiA9PT0gdW5kZWZpbmVkKSBrMiA9IGs7XG4gICAgT2JqZWN0LmRlZmluZVByb3BlcnR5KG8sIGsyLCB7IGVudW1lcmFibGU6IHRydWUsIGdldDogZnVuY3Rpb24oKSB7IHJldHVybiBtW2tdOyB9IH0pO1xufSkgOiAoZnVuY3Rpb24obywgbSwgaywgazIpIHtcbiAgICBpZiAoazIgPT09IHVuZGVmaW5lZCkgazIgPSBrO1xuICAgIG9bazJdID0gbVtrXTtcbn0pKTtcbnZhciBfX2V4cG9ydFN0YXIgPSAodGhpcyAmJiB0aGlzLl9fZXhwb3J0U3RhcikgfHwgZnVuY3Rpb24obSwgZXhwb3J0cykge1xuICAgIGZvciAodmFyIHAgaW4gbSkgaWYgKHAgIT09IFwiZGVmYXVsdFwiICYmICFPYmplY3QucHJvdG90eXBlLmhhc093blByb3BlcnR5LmNhbGwoZXhwb3J0cywgcCkpIF9fY3JlYXRlQmluZGluZyhleHBvcnRzLCBtLCBwKTtcbn07XG5PYmplY3QuZGVmaW5lUHJvcGVydHkoZXhwb3J0cywgXCJfX2VzTW9kdWxlXCIsIHsgdmFsdWU6IHRydWUgfSk7XG5fX2V4cG9ydFN0YXIocmVxdWlyZShcIkBzZXJpYWxwb3J0L3BhcnNlci1ieXRlLWxlbmd0aFwiKSwgZXhwb3J0cyk7XG5fX2V4cG9ydFN0YXIocmVxdWlyZShcIkBzZXJpYWxwb3J0L3BhcnNlci1jY3RhbGtcIiksIGV4cG9ydHMpO1xuX19leHBvcnRTdGFyKHJlcXVpcmUoXCJAc2VyaWFscG9ydC9wYXJzZXItZGVsaW1pdGVyXCIpLCBleHBvcnRzKTtcbl9fZXhwb3J0U3RhcihyZXF1aXJlKFwiQHNlcmlhbHBvcnQvcGFyc2VyLWludGVyLWJ5dGUtdGltZW91dFwiKSwgZXhwb3J0cyk7XG5fX2V4cG9ydFN0YXIocmVxdWlyZShcIkBzZXJpYWxwb3J0L3BhcnNlci1wYWNrZXQtbGVuZ3RoXCIpLCBleHBvcnRzKTtcbl9fZXhwb3J0U3RhcihyZXF1aXJlKFwiQHNlcmlhbHBvcnQvcGFyc2VyLXJlYWRsaW5lXCIpLCBleHBvcnRzKTtcbl9fZXhwb3J0U3RhcihyZXF1aXJlKFwiQHNlcmlhbHBvcnQvcGFyc2VyLXJlYWR5XCIpLCBleHBvcnRzKTtcbl9fZXhwb3J0U3RhcihyZXF1aXJlKFwiQHNlcmlhbHBvcnQvcGFyc2VyLXJlZ2V4XCIpLCBleHBvcnRzKTtcbl9fZXhwb3J0U3RhcihyZXF1aXJlKFwiQHNlcmlhbHBvcnQvcGFyc2VyLXNsaXAtZW5jb2RlclwiKSwgZXhwb3J0cyk7XG5fX2V4cG9ydFN0YXIocmVxdWlyZShcIkBzZXJpYWxwb3J0L3BhcnNlci1zcGFjZXBhY2tldFwiKSwgZXhwb3J0cyk7XG5fX2V4cG9ydFN0YXIocmVxdWlyZShcIi4vc2VyaWFscG9ydC1tb2NrXCIpLCBleHBvcnRzKTtcbl9fZXhwb3J0U3RhcihyZXF1aXJlKFwiLi9zZXJpYWxwb3J0XCIpLCBleHBvcnRzKTtcbiIsIlwidXNlIHN0cmljdFwiO1xuT2JqZWN0LmRlZmluZVByb3BlcnR5KGV4cG9ydHMsIFwiX19lc01vZHVsZVwiLCB7IHZhbHVlOiB0cnVlIH0pO1xuZXhwb3J0cy5TZXJpYWxQb3J0TW9jayA9IHZvaWQgMDtcbmNvbnN0IHN0cmVhbV8xID0gcmVxdWlyZShcIkBzZXJpYWxwb3J0L3N0cmVhbVwiKTtcbmNvbnN0IGJpbmRpbmdfbW9ja18xID0gcmVxdWlyZShcIkBzZXJpYWxwb3J0L2JpbmRpbmctbW9ja1wiKTtcbmNsYXNzIFNlcmlhbFBvcnRNb2NrIGV4dGVuZHMgc3RyZWFtXzEuU2VyaWFsUG9ydFN0cmVhbSB7XG4gICAgY29uc3RydWN0b3Iob3B0aW9ucywgb3BlbkNhbGxiYWNrKSB7XG4gICAgICAgIGNvbnN0IG9wdHMgPSB7XG4gICAgICAgICAgICBiaW5kaW5nOiBiaW5kaW5nX21vY2tfMS5Nb2NrQmluZGluZyxcbiAgICAgICAgICAgIC4uLm9wdGlvbnMsXG4gICAgICAgIH07XG4gICAgICAgIHN1cGVyKG9wdHMsIG9wZW5DYWxsYmFjayk7XG4gICAgfVxufVxuZXhwb3J0cy5TZXJpYWxQb3J0TW9jayA9IFNlcmlhbFBvcnRNb2NrO1xuU2VyaWFsUG9ydE1vY2subGlzdCA9IGJpbmRpbmdfbW9ja18xLk1vY2tCaW5kaW5nLmxpc3Q7XG5TZXJpYWxQb3J0TW9jay5iaW5kaW5nID0gYmluZGluZ19tb2NrXzEuTW9ja0JpbmRpbmc7XG4iLCJcInVzZSBzdHJpY3RcIjtcbk9iamVjdC5kZWZpbmVQcm9wZXJ0eShleHBvcnRzLCBcIl9fZXNNb2R1bGVcIiwgeyB2YWx1ZTogdHJ1ZSB9KTtcbmV4cG9ydHMuU2VyaWFsUG9ydCA9IHZvaWQgMDtcbmNvbnN0IHN0cmVhbV8xID0gcmVxdWlyZShcIkBzZXJpYWxwb3J0L3N0cmVhbVwiKTtcbmNvbnN0IGJpbmRpbmdzX2NwcF8xID0gcmVxdWlyZShcIkBzZXJpYWxwb3J0L2JpbmRpbmdzLWNwcFwiKTtcbmNvbnN0IERldGVjdGVkQmluZGluZyA9ICgwLCBiaW5kaW5nc19jcHBfMS5hdXRvRGV0ZWN0KSgpO1xuY2xhc3MgU2VyaWFsUG9ydCBleHRlbmRzIHN0cmVhbV8xLlNlcmlhbFBvcnRTdHJlYW0ge1xuICAgIGNvbnN0cnVjdG9yKG9wdGlvbnMsIG9wZW5DYWxsYmFjaykge1xuICAgICAgICBjb25zdCBvcHRzID0ge1xuICAgICAgICAgICAgYmluZGluZzogRGV0ZWN0ZWRCaW5kaW5nLFxuICAgICAgICAgICAgLi4ub3B0aW9ucyxcbiAgICAgICAgfTtcbiAgICAgICAgc3VwZXIob3B0cywgb3BlbkNhbGxiYWNrKTtcbiAgICB9XG59XG5leHBvcnRzLlNlcmlhbFBvcnQgPSBTZXJpYWxQb3J0O1xuU2VyaWFsUG9ydC5saXN0ID0gRGV0ZWN0ZWRCaW5kaW5nLmxpc3Q7XG5TZXJpYWxQb3J0LmJpbmRpbmcgPSBEZXRlY3RlZEJpbmRpbmc7XG4iLCIndXNlIHN0cmljdCc7XG5jb25zdCBvcyA9IHJlcXVpcmUoJ29zJyk7XG5jb25zdCB0dHkgPSByZXF1aXJlKCd0dHknKTtcbmNvbnN0IGhhc0ZsYWcgPSByZXF1aXJlKCdoYXMtZmxhZycpO1xuXG5jb25zdCB7ZW52fSA9IHByb2Nlc3M7XG5cbmxldCBmb3JjZUNvbG9yO1xuaWYgKGhhc0ZsYWcoJ25vLWNvbG9yJykgfHxcblx0aGFzRmxhZygnbm8tY29sb3JzJykgfHxcblx0aGFzRmxhZygnY29sb3I9ZmFsc2UnKSB8fFxuXHRoYXNGbGFnKCdjb2xvcj1uZXZlcicpKSB7XG5cdGZvcmNlQ29sb3IgPSAwO1xufSBlbHNlIGlmIChoYXNGbGFnKCdjb2xvcicpIHx8XG5cdGhhc0ZsYWcoJ2NvbG9ycycpIHx8XG5cdGhhc0ZsYWcoJ2NvbG9yPXRydWUnKSB8fFxuXHRoYXNGbGFnKCdjb2xvcj1hbHdheXMnKSkge1xuXHRmb3JjZUNvbG9yID0gMTtcbn1cblxuaWYgKCdGT1JDRV9DT0xPUicgaW4gZW52KSB7XG5cdGlmIChlbnYuRk9SQ0VfQ09MT1IgPT09ICd0cnVlJykge1xuXHRcdGZvcmNlQ29sb3IgPSAxO1xuXHR9IGVsc2UgaWYgKGVudi5GT1JDRV9DT0xPUiA9PT0gJ2ZhbHNlJykge1xuXHRcdGZvcmNlQ29sb3IgPSAwO1xuXHR9IGVsc2Uge1xuXHRcdGZvcmNlQ29sb3IgPSBlbnYuRk9SQ0VfQ09MT1IubGVuZ3RoID09PSAwID8gMSA6IE1hdGgubWluKHBhcnNlSW50KGVudi5GT1JDRV9DT0xPUiwgMTApLCAzKTtcblx0fVxufVxuXG5mdW5jdGlvbiB0cmFuc2xhdGVMZXZlbChsZXZlbCkge1xuXHRpZiAobGV2ZWwgPT09IDApIHtcblx0XHRyZXR1cm4gZmFsc2U7XG5cdH1cblxuXHRyZXR1cm4ge1xuXHRcdGxldmVsLFxuXHRcdGhhc0Jhc2ljOiB0cnVlLFxuXHRcdGhhczI1NjogbGV2ZWwgPj0gMixcblx0XHRoYXMxNm06IGxldmVsID49IDNcblx0fTtcbn1cblxuZnVuY3Rpb24gc3VwcG9ydHNDb2xvcihoYXZlU3RyZWFtLCBzdHJlYW1Jc1RUWSkge1xuXHRpZiAoZm9yY2VDb2xvciA9PT0gMCkge1xuXHRcdHJldHVybiAwO1xuXHR9XG5cblx0aWYgKGhhc0ZsYWcoJ2NvbG9yPTE2bScpIHx8XG5cdFx0aGFzRmxhZygnY29sb3I9ZnVsbCcpIHx8XG5cdFx0aGFzRmxhZygnY29sb3I9dHJ1ZWNvbG9yJykpIHtcblx0XHRyZXR1cm4gMztcblx0fVxuXG5cdGlmIChoYXNGbGFnKCdjb2xvcj0yNTYnKSkge1xuXHRcdHJldHVybiAyO1xuXHR9XG5cblx0aWYgKGhhdmVTdHJlYW0gJiYgIXN0cmVhbUlzVFRZICYmIGZvcmNlQ29sb3IgPT09IHVuZGVmaW5lZCkge1xuXHRcdHJldHVybiAwO1xuXHR9XG5cblx0Y29uc3QgbWluID0gZm9yY2VDb2xvciB8fCAwO1xuXG5cdGlmIChlbnYuVEVSTSA9PT0gJ2R1bWInKSB7XG5cdFx0cmV0dXJuIG1pbjtcblx0fVxuXG5cdGlmIChwcm9jZXNzLnBsYXRmb3JtID09PSAnd2luMzInKSB7XG5cdFx0Ly8gV2luZG93cyAxMCBidWlsZCAxMDU4NiBpcyB0aGUgZmlyc3QgV2luZG93cyByZWxlYXNlIHRoYXQgc3VwcG9ydHMgMjU2IGNvbG9ycy5cblx0XHQvLyBXaW5kb3dzIDEwIGJ1aWxkIDE0OTMxIGlzIHRoZSBmaXJzdCByZWxlYXNlIHRoYXQgc3VwcG9ydHMgMTZtL1RydWVDb2xvci5cblx0XHRjb25zdCBvc1JlbGVhc2UgPSBvcy5yZWxlYXNlKCkuc3BsaXQoJy4nKTtcblx0XHRpZiAoXG5cdFx0XHROdW1iZXIob3NSZWxlYXNlWzBdKSA+PSAxMCAmJlxuXHRcdFx0TnVtYmVyKG9zUmVsZWFzZVsyXSkgPj0gMTA1ODZcblx0XHQpIHtcblx0XHRcdHJldHVybiBOdW1iZXIob3NSZWxlYXNlWzJdKSA+PSAxNDkzMSA/IDMgOiAyO1xuXHRcdH1cblxuXHRcdHJldHVybiAxO1xuXHR9XG5cblx0aWYgKCdDSScgaW4gZW52KSB7XG5cdFx0aWYgKFsnVFJBVklTJywgJ0NJUkNMRUNJJywgJ0FQUFZFWU9SJywgJ0dJVExBQl9DSScsICdHSVRIVUJfQUNUSU9OUycsICdCVUlMREtJVEUnXS5zb21lKHNpZ24gPT4gc2lnbiBpbiBlbnYpIHx8IGVudi5DSV9OQU1FID09PSAnY29kZXNoaXAnKSB7XG5cdFx0XHRyZXR1cm4gMTtcblx0XHR9XG5cblx0XHRyZXR1cm4gbWluO1xuXHR9XG5cblx0aWYgKCdURUFNQ0lUWV9WRVJTSU9OJyBpbiBlbnYpIHtcblx0XHRyZXR1cm4gL14oOVxcLigwKlsxLTldXFxkKilcXC58XFxkezIsfVxcLikvLnRlc3QoZW52LlRFQU1DSVRZX1ZFUlNJT04pID8gMSA6IDA7XG5cdH1cblxuXHRpZiAoZW52LkNPTE9SVEVSTSA9PT0gJ3RydWVjb2xvcicpIHtcblx0XHRyZXR1cm4gMztcblx0fVxuXG5cdGlmICgnVEVSTV9QUk9HUkFNJyBpbiBlbnYpIHtcblx0XHRjb25zdCB2ZXJzaW9uID0gcGFyc2VJbnQoKGVudi5URVJNX1BST0dSQU1fVkVSU0lPTiB8fCAnJykuc3BsaXQoJy4nKVswXSwgMTApO1xuXG5cdFx0c3dpdGNoIChlbnYuVEVSTV9QUk9HUkFNKSB7XG5cdFx0XHRjYXNlICdpVGVybS5hcHAnOlxuXHRcdFx0XHRyZXR1cm4gdmVyc2lvbiA+PSAzID8gMyA6IDI7XG5cdFx0XHRjYXNlICdBcHBsZV9UZXJtaW5hbCc6XG5cdFx0XHRcdHJldHVybiAyO1xuXHRcdFx0Ly8gTm8gZGVmYXVsdFxuXHRcdH1cblx0fVxuXG5cdGlmICgvLTI1Nihjb2xvcik/JC9pLnRlc3QoZW52LlRFUk0pKSB7XG5cdFx0cmV0dXJuIDI7XG5cdH1cblxuXHRpZiAoL15zY3JlZW58Xnh0ZXJtfF52dDEwMHxednQyMjB8XnJ4dnR8Y29sb3J8YW5zaXxjeWd3aW58bGludXgvaS50ZXN0KGVudi5URVJNKSkge1xuXHRcdHJldHVybiAxO1xuXHR9XG5cblx0aWYgKCdDT0xPUlRFUk0nIGluIGVudikge1xuXHRcdHJldHVybiAxO1xuXHR9XG5cblx0cmV0dXJuIG1pbjtcbn1cblxuZnVuY3Rpb24gZ2V0U3VwcG9ydExldmVsKHN0cmVhbSkge1xuXHRjb25zdCBsZXZlbCA9IHN1cHBvcnRzQ29sb3Ioc3RyZWFtLCBzdHJlYW0gJiYgc3RyZWFtLmlzVFRZKTtcblx0cmV0dXJuIHRyYW5zbGF0ZUxldmVsKGxldmVsKTtcbn1cblxubW9kdWxlLmV4cG9ydHMgPSB7XG5cdHN1cHBvcnRzQ29sb3I6IGdldFN1cHBvcnRMZXZlbCxcblx0c3Rkb3V0OiB0cmFuc2xhdGVMZXZlbChzdXBwb3J0c0NvbG9yKHRydWUsIHR0eS5pc2F0dHkoMSkpKSxcblx0c3RkZXJyOiB0cmFuc2xhdGVMZXZlbChzdXBwb3J0c0NvbG9yKHRydWUsIHR0eS5pc2F0dHkoMikpKVxufTtcbiIsIm1vZHVsZS5leHBvcnRzID0ge1xyXG4gIHNlcmlhbDoge1xyXG4gICAgTUFYX1JYX0JZVEVfSU5URVJWQUw6IDEwMCwgLyogdW5pdDogbXMgKi9cclxuICAgIE1BTkFHRU1FTlRfUEFDS0VUX0hFQURFUjogXCJEMW12T1AzTTY3SUdwU3JBQkFXd2h2NTdwZTJ2VFwiLFxyXG4gICAgXHJcbiAgICBHVUlfQVVUSEVOVElDQVRJT05fSEFTSF9LRVk6IFwiRFlBZndKa2RYYTFQVFlsZ2MwSXB1WlRSQXBOZnh3bmhhdFBDNkY1SGVPOUNIb1E5b2VCM1ZXbmcxNXFndFpuZE5wRnVMOG9xOEplbVNLZHR3cTUwTHpQQm5HV2VIdXIzbTlqZUNFS2p6MXZydmxLalVuVW5SdzFJREpwZmtXUVp2MmJTN291Z1R6bjZyTk9lYnM1MVNld09ock1aQkNZVXpwRUZNQ2lqN2Z2ekRkd1NvNXltZHM1V3FpOGJ3c1ZNb2xyamE0RlEwdlVsQU8yMHRjdDJ3Zm9ZSXNDV21ENEkzeW1YZGFGWmx1b0JrZWg0T2F6Q3I3MHRua1wiLFxyXG4gICAgQVVUSEVOVElDQVRJT05fQU5JTUFUSU9OX0RFTEFZOiAzMDAsXHJcbiAgICBBVVRIRU5USUNBVElPTl9OT1RfTkVFRERFRDogZmFsc2UsXHJcbiAgICBBVVRPX0lOU0VSVF9HVUlfUEFTU1dPUkRfQUNUSVZFOiBmYWxzZSxcclxuICAgIEFVVE9fSU5TRVJUX0dVSV9QQVNTV09SRF9WQUxVRTogXCIxMTExXCIsXHJcbiAgICBcclxuICAgIE1BTkFHRU1FTlRfQ09NTUFORDoge1xyXG4gICAgICBIRUxMTzogMHgwMCxcclxuICAgICAgQUNLOiAweDAxLFxyXG4gICAgICBOQUNLOiAweDAyLFxyXG4gICAgICBSRVFVRVNUX1NUQVRVUzogMHgwMyxcclxuXHJcbiAgICAgIFNFVF9CVVpaRVJfVk9MVU1FOiAweDEwLFxyXG4gICAgICBURVNUX0xFRDogMHgxMSxcclxuICAgICAgU0VUX0RFVklDRV9XT1JLSU5HX01PREU6IDB4MTIsXHJcbiAgICAgIFNFVF9ERVZJQ0VfSUQ6IDB4MTMsXHJcbiAgICAgIFNFVF9ERVZJQ0VfSURfTEVOR1RIOiAweDE0LFxyXG4gICAgICBTRVRfUlRDX1RJTUU6IDB4MTUsXHJcbiAgICAgIFNFVF9SRU1PVEVfRElTQ0hBUkdFX01FU1NBR0U6IDB4MTYsXHJcbiAgICAgIFNFVF9CTEFDS19MSVNUX0JZUEFTUzogMHgxNyxcclxuICAgICAgU0VUX01BSU5fS0VZX0JBTktfU0VFRDogMHgxOCxcclxuICAgICAgU0VUX0JBQ0tVUF9LRVlfQkFOS19TRUVEOiAweDE5LFxyXG4gICAgICBTRVRfU0VMRUNURURfS0VZX0JBTks6IDB4MUEsXHJcbiAgICAgIFNFVF9DQVNFX09QRU5fRVZFTlRfQUNUSU9OOiAweDFCLFxyXG4gICAgICBTRVRfUkVNT1RFX0RJU0NIQVJHRV9FTkFCTEU6IDB4MUMsXHJcbiAgICAgIERJU0NIQVJHRV9LRVlfQkFOS1M6IDB4MUQsXHJcbiAgICAgIFNFVF9FTkNSWVBURURfUE9SVF9UWF9CQVVEX1JBVEU6IDB4MUUsXHJcbiAgICAgIFNFVF9FTkNSWVBURURfUE9SVF9SWF9CQVVEX1JBVEU6IDB4MUYsXHJcbiAgICAgIFNFVF9ERUNSWVBURURfUE9SVF9UWF9CQVVEX1JBVEU6IDB4MjAsXHJcbiAgICAgIFNFVF9ERUNSWVBURURfUE9SVF9SWF9CQVVEX1JBVEU6IDB4MjEsXHJcbiAgICAgIFNFVF9SVENfUEFDS0VUX1NFQ1RJT05fRU5BQkxFRDogMHgyMixcclxuICAgICAgU0VUX01BWElNVU1fVkFMSURfUlRDX1RJTUVfRElGRkVSRU5DRTogMHgyMyxcclxuICAgICAgU0VUX0RFQ1JZUFRFRF9QT1JUX1JYX1RJTUVPVVRfTVM6IDB4MjQsXHJcbiAgICAgIFNFVF9FTkNSWVBURURfUE9SVF9SWF9USU1FT1VUX01TOiAweDI1LFxyXG4gICAgICBTRVRfRU5DUllQVEVEX1BBQ0tFVF9NQVhfREFUQV9MRU5HVEg6IDB4MjYsXHJcbiAgICAgIFNUQVJUX0tTU19TVFJFQU1fR0VORVJBVElPTjogMHgyNyxcclxuICAgICAgU1RPUF9LU1NfU1RSRUFNX0dFTkVSQVRJT046IDB4MjgsXHJcbiAgICAgIEFERF9UT19CTEFDS19MSVNUX0lOX1JBTTogMHgyOSxcclxuICAgICAgUkVBRF9GUk9NX0JMQUNLX0xJU1Q6IDB4MkEsXHJcbiAgICAgIEVSQVNFX0JMQUNLX0xJU1RfRlJPTV9GTEFTSDogMHgyQixcclxuICAgICAgRVJBU0VfQkxBQ0tfTElTVF9GUk9NX1JBTTogMHgyQyxcclxuICAgICAgV1JJVEVfQkxBQ0tfTElTVF9UT19GTEFTSDogMHgyRCxcclxuICAgICAgU0VUX0VOQ1JZUFRFRF9QT1JUX0hFQURFUjogMHgyRSxcclxuICAgICAgU0VUX0dVSV9QQVNTV09SRDogMHgyRixcclxuICAgICAgQVVUSEVOVElDQVRJT05fUkFORE9NX0RBVEE6IDB4MzAsXHJcbiAgICAgIEFVVEhFTlRJQ0FUSU9OX1VOSVFVRV9JRF9BTkRfSEFTSDogMHgzMSxcclxuICAgICAgQVVUSEVOVElDQVRJT05fR1VJX1BBU1NXT1JEOiAweDMyLFxyXG4gICAgfSxcclxuICB9LFxyXG59XHJcblxyXG4iLCIndXNlIHN0cmljdCc7XHJcblxyXG5jb25zdCBYTFNYID0gcmVxdWlyZShcInhsc3hcIik7XHJcbmNvbnN0IHsgaXBjUmVuZGVyZXIgfSA9IHJlcXVpcmUoJ2VsZWN0cm9uJyk7XHJcblxyXG5mdW5jdGlvbiBzYXZlTG9nVG9FeGNlbGwgKGZpbGVOYW1lLCBiaWFzVmFsdWVzT2JqKSB7XHJcbiAgY29uc3QgbmV3Qm9vayA9IFhMU1gudXRpbHMuYm9va19uZXcoKTtcclxuICBYTFNYLnV0aWxzLmJvb2tfYXBwZW5kX3NoZWV0KFxyXG4gICAgbmV3Qm9vayxcclxuICAgIFhMU1gudXRpbHMuanNvbl90b19zaGVldChiaWFzVmFsdWVzT2JqKSxcclxuICAgIFwiVGVzdF9SZXN1bHRzXCJcclxuICApO1xyXG4gIFhMU1gud3JpdGVGaWxlKG5ld0Jvb2ssIGZpbGVOYW1lKTtcclxufVxyXG5cclxuYXN5bmMgZnVuY3Rpb24gc2VsZWN0Rm9sZGVyICgpIHtcclxuICByZXR1cm4gYXdhaXQgaXBjUmVuZGVyZXIuaW52b2tlKCdkaWFsb2c6b3BlbkRpcmVjdG9yeScpO1xyXG59XHJcblxyXG5hc3luYyBmdW5jdGlvbiBzZWxlY3RFeGNlbFRvT3BlbiAoKSB7XHJcbiAgcmV0dXJuIGF3YWl0IGlwY1JlbmRlcmVyLmludm9rZSgnZGlhbG9nOnNlbGVjdEV4Y2VsVG9PcGVuJyk7XHJcbn1cclxuXHJcbmFzeW5jIGZ1bmN0aW9uIHNlbGVjdEFuZE9wZW5FeGNlbGxXb3JrYm9vayAoKSB7XHJcbiAgbGV0IGZpbGVQYXRoID0gYXdhaXQgc2VsZWN0RXhjZWxUb09wZW4oKTtcclxuICBpZighZmlsZVBhdGgpIHtcclxuICAgIHJldHVybiBudWxsO1xyXG4gIH1cclxuXHJcbiAgbGV0IHdvcmtib29rID0gWExTWC5yZWFkRmlsZShmaWxlUGF0aCk7XHJcblxyXG4gIHJldHVybiB3b3JrYm9vaztcclxufVxyXG5cclxuYXN5bmMgZnVuY3Rpb24gc2VsZWN0RXhjZWxUb1NhdmUgKCkge1xyXG4gIHJldHVybiBhd2FpdCBpcGNSZW5kZXJlci5pbnZva2UoJ2RpYWxvZzpzZWxlY3RFeGNlbFRvU2F2ZScpO1xyXG59XHJcblxyXG5mdW5jdGlvbiBnZXRFeGVGaWxlUGF0aCAobmFtZSkge1xyXG4gIHJldHVybiBpcGNSZW5kZXJlci5pbnZva2UoJ2dldEV4ZUZpbGVQYXRoJywgbmFtZSk7XHJcbn1cclxuXHJcbmZ1bmN0aW9uIGdldEV4ZUZpbGVQYXRoTG9vcGVkIChuYW1lKSB7XHJcbiAgcmV0dXJuIGlwY1JlbmRlcmVyLmludm9rZSgnZ2V0RXhlRmlsZVBhdGhMb29wZWQnLCBuYW1lKTtcclxufVxyXG5cclxuZnVuY3Rpb24gZ2V0RXhlRmlsZVBhdGhDb25zdCAoKSB7XHJcbiAgcmV0dXJuIGlwY1JlbmRlcmVyLmludm9rZSgnZ2V0RXhlRmlsZVBhdGhDb25zdCcpO1xyXG59XHJcblxyXG5mdW5jdGlvbiBzYXZlV29ya2Jvb2sod29ya2Jvb2ssIGZpbGVQYXRoKSB7XHJcbiAgdHJ5IHtcclxuICAgIFhMU1gud3JpdGVGaWxlKHdvcmtib29rLCBmaWxlUGF0aCk7IC8vIFdyaXRlIHRoZSB3b3JrYm9vayB0byB0aGUgc3BlY2lmaWVkIGZpbGVcclxuICAgIGNvbnNvbGUubG9nKGBXb3JrYm9vayBzYXZlZCB0byAke2ZpbGVQYXRofWApO1xyXG4gIH0gY2F0Y2ggKGVycm9yKSB7XHJcbiAgICBjb25zb2xlLmVycm9yKGBGYWlsZWQgdG8gc2F2ZSB3b3JrYm9vazogJHtlcnJvci5tZXNzYWdlfWApO1xyXG4gIH1cclxufVxyXG5cclxubW9kdWxlLmV4cG9ydHMgPSB7XHJcbiAgc2F2ZUxvZ1RvRXhjZWxsLFxyXG4gIGdldEV4ZUZpbGVQYXRoLFxyXG4gIGdldEV4ZUZpbGVQYXRoTG9vcGVkLFxyXG4gIGdldEV4ZUZpbGVQYXRoQ29uc3QsXHJcbiAgc2VsZWN0Rm9sZGVyLFxyXG4gIHNlbGVjdEV4Y2VsVG9PcGVuLFxyXG4gIHNlbGVjdEV4Y2VsVG9TYXZlLFxyXG4gIHNlbGVjdEFuZE9wZW5FeGNlbGxXb3JrYm9vayxcclxuICBzYXZlV29ya2Jvb2ssXHJcbn1cclxuXHJcbiIsIid1c2Ugc3RyaWN0JztcclxuXHJcbmNvbnN0IGNyeXB0byA9IHJlcXVpcmUoJ2NyeXB0bycpO1xyXG5jb25zdCB0b29sQm94ID0gcmVxdWlyZSgnLi90b29sQm94JylcclxuXHJcbmZ1bmN0aW9uIGNyZWF0ZUhhc2goaW5wdXQsIHJldHVybkhleFN0cmluZz1mYWxzZSkge1xyXG4gIGlmICghQnVmZmVyLmlzQnVmZmVyKGlucHV0KSkge1xyXG4gICAgaW5wdXQgPSBCdWZmZXIuZnJvbShpbnB1dCk7IC8vIENvbnZlcnQgaW5wdXQgdG8gQnVmZmVyIGlmIGl0IGlzbid0IG9uZVxyXG4gIH1cclxuXHJcbiAgbGV0IGhhc2ggPSBjcnlwdG8uY3JlYXRlSGFzaCgnc2hhMjU2JykudXBkYXRlKGlucHV0KS5kaWdlc3QoJ2hleCcpO1xyXG5cclxuICBpZihyZXR1cm5IZXhTdHJpbmcpIHtcclxuICAgIHJldHVybiBoYXNoO1xyXG4gIH0gZWxzZSB7XHJcbiAgICByZXR1cm4gdG9vbEJveC5mcm9tSGV4U3RyaW5nKGhhc2gpO1xyXG4gIH1cclxufVxyXG5cclxubW9kdWxlLmV4cG9ydHMgPSB7XHJcbiAgY3JlYXRlSGFzaCxcclxufVxyXG5cclxuIiwiJ3VzZSBzdHJpY3QnO1xyXG5cclxuY29uc3QgdG9vbEJveCA9IHJlcXVpcmUoJy4vdG9vbEJveCcpXHJcbmNvbnN0IHsgU2VyaWFsUG9ydCB9ID0gcmVxdWlyZSgnc2VyaWFscG9ydCcpO1xyXG5jb25zdCB7IEJ5dGVMZW5ndGhQYXJzZXIgfSA9IHJlcXVpcmUoJ0BzZXJpYWxwb3J0L3BhcnNlci1ieXRlLWxlbmd0aCcpO1xyXG5cclxubGV0IHNlcmlhbHBvcnQgPSBudWxsO1xyXG5sZXQgcnhDYWxsQmFja0Z1bmN0aW9uID0gKCkgPT4gMDtcclxubGV0IHBhcnNlciA9IG51bGw7XHJcblxyXG5mdW5jdGlvbiBpbml0UG9ydCAocG9ydCwgYmF1ZFJhdGU9OTYwMCkge1xyXG4gIGlmKHNlcmlhbHBvcnQgJiYgc2VyaWFscG9ydC5pc09wZW4pIHtcclxuICAgIHNlcmlhbHBvcnQuY2xvc2UoKTtcclxuICB9XHJcbiAgc2VyaWFscG9ydCA9IG5ldyBTZXJpYWxQb3J0KHsgYXV0b09wZW46IGZhbHNlLCBwYXRoOiBwb3J0LCBiYXVkUmF0ZTogYmF1ZFJhdGUgfSk7XHJcblxyXG4gIHBhcnNlciA9IHNlcmlhbHBvcnQucGlwZShuZXcgQnl0ZUxlbmd0aFBhcnNlcih7bGVuZ3RoOiAxfSkpO1xyXG4gIHBhcnNlci5vbignZGF0YScsIChkYXRhKSA9PiB7XHJcbiAgICByeENhbGxCYWNrRnVuY3Rpb24oZGF0YVtcIjBcIl0pO1xyXG4gIH0pO1xyXG59XHJcblxyXG5hc3luYyBmdW5jdGlvbiBzZXRCYXVkUmF0ZSAoYmF1ZFJhdGUpIHtcclxuICBpZihzZXJpYWxwb3J0ICYmIHNlcmlhbHBvcnQuaXNPcGVuKSB7XHJcbiAgICBhd2FpdCBzZXJpYWxwb3J0LmNsb3NlKCk7XHJcbiAgICBhd2FpdCBuZXcgUHJvbWlzZShyZXNvbHZlID0+IHNldFRpbWVvdXQocmVzb2x2ZSwgNTApKTtcclxuXHJcbiAgICBpbml0UG9ydChcclxuICAgICAgc2VyaWFscG9ydC5zZXR0aW5ncy5wYXRoLFxyXG4gICAgICBiYXVkUmF0ZSxcclxuICAgICAgcnhDYWxsQmFja0Z1bmN0aW9uLFxyXG4gICAgKTtcclxuXHJcbiAgICBhd2FpdCBzZXJpYWxwb3J0Lm9wZW4oKTtcclxuICB9IGVsc2Uge1xyXG4gICAgdGhyb3cgbmV3IEVycm9yKCdTZXJpYWwgcG9ydCBpcyBub3Qgb3BlbiAhISEnKTtcclxuICB9XHJcbn1cclxuXHJcbmZ1bmN0aW9uIGlzT3BlbiAoKSB7XHJcbiAgcmV0dXJuIHNlcmlhbHBvcnQuaXNPcGVuO1xyXG59XHJcblxyXG5hc3luYyBmdW5jdGlvbiBvcGVuICgpIHtcclxuICBpZihzZXJpYWxwb3J0KSB7XHJcbiAgICBhd2FpdCBzZXJpYWxwb3J0Lm9wZW4oKTtcclxuICB9XHJcbn1cclxuXHJcbmFzeW5jIGZ1bmN0aW9uIGNsb3NlICgpIHtcclxuICBpZihzZXJpYWxwb3J0ICYmIHNlcmlhbHBvcnQuaXNPcGVuKSB7XHJcbiAgICBhd2FpdCBzZXJpYWxwb3J0LmNsb3NlKCk7XHJcbiAgfVxyXG59XHJcblxyXG5mdW5jdGlvbiB3cml0ZSAoZGF0YUFycmF5KSB7XHJcbiAgc2VyaWFscG9ydC53cml0ZShkYXRhQXJyYXkpO1xyXG59XHJcblxyXG5mdW5jdGlvbiBzZXRSeENhbGxiYWNrRnVuY3Rpb24oY2FsbEJhY2tGdW5jdGlvbikge1xyXG4gIHJ4Q2FsbEJhY2tGdW5jdGlvbiA9IGNhbGxCYWNrRnVuY3Rpb247XHJcbn1cclxuXHJcbmFzeW5jIGZ1bmN0aW9uIGxpc3QoKSB7XHJcbiAgcmV0dXJuIGF3YWl0IFNlcmlhbFBvcnQubGlzdCgpXHJcbn1cclxuXHJcbi8vIGJlbG93IGZ1bmN0aW9uIGlzIHVzZWQgZm9yIGRlYnVnZ2luZyBwdXJwb3NlcyDwn5GH8J+Rh/CfkYcgb25seVxyXG5mdW5jdGlvbiBydW5SeENhbGxiYWNrRnVuY3Rpb24gKHJ4Qnl0ZSkge1xyXG4gIHJ4Q2FsbEJhY2tGdW5jdGlvbihyeEJ5dGUpO1xyXG59XHJcblxyXG5tb2R1bGUuZXhwb3J0cyA9IHtcclxuICBpbml0UG9ydCxcclxuICBzZXRCYXVkUmF0ZSxcclxuICBpc09wZW4sXHJcbiAgb3BlbixcclxuICBjbG9zZSxcclxuICB3cml0ZSxcclxuICBzZXRSeENhbGxiYWNrRnVuY3Rpb24sXHJcbiAgbGlzdCxcclxuXHJcbiAgLy8gYmVsb3cgZnVuY3Rpb24gaXMgdXNlZCBmb3IgZGVidWdnaW5nIHB1cnBvc2VzIPCfkYfwn5GH8J+RhyBvbmx5XHJcbiAgcnVuUnhDYWxsYmFja0Z1bmN0aW9uLFxyXG59XHJcblxyXG4iLCIndXNlIHN0cmljdCc7XHJcblxyXG5jb25zdCB0b29sQm94ID0gcmVxdWlyZSgnLi90b29sQm94JylcclxuY29uc3QgeyB3ZWJGcmFtZSB9ID0gcmVxdWlyZSgnZWxlY3Ryb24nKTtcclxuXHJcbmZ1bmN0aW9uIHNldFpvb21GYWN0b3IgKHpvb21GYWN0b3IpIHtcclxuICBpZih6b29tRmFjdG9yID4gMC4yNSkge1xyXG4gICAgem9vbUZhY3RvciA9IDAuMjU7XHJcbiAgfVxyXG4gIFxyXG4gIHdlYkZyYW1lLnNldFpvb21GYWN0b3Ioem9vbUZhY3Rvcik7XHJcbn1cclxuXHJcbmZ1bmN0aW9uIGdldFpvb21GYWN0b3IgKCkge1xyXG4gIHJldHVybiB3ZWJGcmFtZS5nZXRab29tRmFjdG9yKCk7XHJcbn1cclxuXHJcbmZ1bmN0aW9uIG1vZGlmeVpvb21GYWN0b3IgKG1vZGlmaWNhdGlvblZhbHVlKSB7XHJcbiAgbGV0IG5ld1pvb21GYWN0b3IgPSBtb2RpZmljYXRpb25WYWx1ZSArIHdlYkZyYW1lLmdldFpvb21GYWN0b3IoKTtcclxuICBpZihuZXdab29tRmFjdG9yIDwgMC4yNSkge1xyXG4gICAgbmV3Wm9vbUZhY3RvciA9IDAuMjU7XHJcbiAgfVxyXG4gIFxyXG4gIHdlYkZyYW1lLnNldFpvb21GYWN0b3IobmV3Wm9vbUZhY3Rvcik7XHJcbn1cclxuXHJcbmZ1bmN0aW9uIGluaXQgKGluaXRab29tRmFjdG9yKSB7XHJcbiAgd2ViRnJhbWUuc2V0Wm9vbUZhY3Rvcihpbml0Wm9vbUZhY3Rvcik7XHJcbn1cclxuXHJcbm1vZHVsZS5leHBvcnRzID0ge1xyXG4gIHNldFpvb21GYWN0b3IsXHJcbiAgZ2V0Wm9vbUZhY3RvcixcclxuICBtb2RpZnlab29tRmFjdG9yLFxyXG4gIGluaXQsXHJcbn1cclxuXHJcbiIsIid1c2Ugc3RyaWN0JztcclxuXHJcbmNvbnN0IERFRkFVTFRfQU5JTUFUSU9OX1RJTUUgPSAnM3MnO1xyXG5jb25zdCBERUZBVUxUX0xBTkdVQUdFX0lTX0ZBUlNJID0gdHJ1ZTtcclxuXHJcbmZ1bmN0aW9uIGRpc3BsYXlQb3BVcChcclxuICB0ZXh0LFxyXG4gIGNvbG9yLFxyXG4gIGlzRmFyc2k9REVGQVVMVF9MQU5HVUFHRV9JU19GQVJTSSxcclxuICBhbmltYXRpb25UaW1lPURFRkFVTFRfQU5JTUFUSU9OX1RJTUVcclxuKSB7XHJcbiAgY29uc3QgdGVtcGxhdGUgPSBkb2N1bWVudC5xdWVyeVNlbGVjdG9yKCcjcG9wLXVwLWNhcmQtdGVtcGxhdGUnKTtcclxuICBjb25zdCBjbG9uZSA9IHRlbXBsYXRlLmNvbnRlbnQuY2xvbmVOb2RlKHRydWUpLnF1ZXJ5U2VsZWN0b3IoJy5wb3AtdXAtY2FyZCcpO1xyXG5cclxuICBjbG9uZS5zdHlsZS5zZXRQcm9wZXJ0eSgnLS1iYWNrZ3JvdW5kLWNvbG9yJywgY29sb3IpO1xyXG4gIGNsb25lLnF1ZXJ5U2VsZWN0b3IoJy5jYXJkLWxhYmVsJykudGV4dENvbnRlbnQgPSB0ZXh0O1xyXG4gIGNsb25lLnN0eWxlLnNldFByb3BlcnR5KCctLWFuaW1hdGlvbi10aW1lJywgYW5pbWF0aW9uVGltZSk7XHJcblxyXG4gIGlmKGlzRmFyc2kpIHtcclxuICAgIGNsb25lLmNsYXNzTGlzdC5hZGQoJ2ZhcnNpJyk7XHJcbiAgfVxyXG4gIFxyXG4gIGNvbnN0IHBvcFVwQ2FyZHNDb250YWluZXIgPSBkb2N1bWVudC5xdWVyeVNlbGVjdG9yKCcucG9wLXVwLWNhcmRzLWNvbnRhaW5lcicpO1xyXG4gIHBvcFVwQ2FyZHNDb250YWluZXIucHJlcGVuZChjbG9uZSk7XHJcbiAgY2xvbmUuYWRkRXZlbnRMaXN0ZW5lcignYW5pbWF0aW9uZW5kJywgKCkgPT4gcG9wVXBDYXJkc0NvbnRhaW5lci5yZW1vdmVDaGlsZChjbG9uZSkpO1xyXG59XHJcblxyXG5tb2R1bGUuZXhwb3J0cyA9IHtcclxuICBkaXNwbGF5UG9wVXAsXHJcbn0iLCIndXNlIHN0cmljdCc7XHJcblxyXG5jb25zdCBjb25maWcgPSByZXF1aXJlKCcuL2NvbmZpZycpXHJcbmNvbnN0IHRvb2xCb3ggPSByZXF1aXJlKCcuL3Rvb2xCb3gnKVxyXG5jb25zdCBzZXJpYWxSeCA9IHJlcXVpcmUoJy4vc2VyaWFsUngnKVxyXG5jb25zdCBzZXJpYWxUeCA9IHJlcXVpcmUoJy4vc2VyaWFsVHgnKVxyXG5jb25zdCBwb3BVcE1lc3NhZ2UgPSByZXF1aXJlKCcuL3BvcFVwTWVzc2FnZScpO1xyXG5jb25zdCBwZXJzb25hbEV4Y2VsQXBpID0gcmVxdWlyZSgnLi9wZXJzb25hbEV4Y2VsQXBpJyk7XHJcbmNvbnN0IHBlcnNvbmFsSGFzaCA9IHJlcXVpcmUoJy4vcGVyc29uYWxIYXNoJyk7XHJcbmNvbnN0IFhMU1ggPSByZXF1aXJlKCd4bHN4Jyk7XHJcblxyXG5jb25zdCBDT01NQU5EUyA9IGNvbmZpZy5zZXJpYWwuTUFOQUdFTUVOVF9DT01NQU5EO1xyXG5cclxuY29uc3QgQVVUSEVOVElDQVRJT05fTUFYX1JBTkRPTV9EQVRBX0xFTkdUSCA9IDY0O1xyXG5jb25zdCBBVVRIRU5USUNBVElPTl9NSU5fUkFORE9NX0RBVEFfTEVOR1RIID0gMzI7XHJcbmNvbnN0IEFVVEhFTlRJQ0FUSU9OX01BWF9VTklRVUVfSURfTEVOR1RIID0gNjQ7XHJcbmNvbnN0IEFVVEhFTlRJQ0FUSU9OX01JTl9VTklRVUVfSURfTEVOR1RIID0gMTtcclxuXHJcbmNvbnN0IERFRkFVTFRfTUFYX1JFU1BPTlNFX1RJTUUgPSAyMDAwO1xyXG5jb25zdCBLRVlfQkFOS19HRU5FUkFUSU9OX01BWF9SRVNQT05TRV9USU1FID0gNDAwMDtcclxuXHJcbmNvbnN0IFBBQ0tFVF9FUlJPUl9DT0RFUyA9IHtcclxuICBDT05DSUZHX1BPUlRfUEFDS0VUX0VSUk9SX05PTkU6ICAgICAgICAgICAgICAgICAgICAwLFxyXG4gIENPTkNJRkdfUE9SVF9QQUNLRVRfRVJST1JfQ09NTUFORDogICAgICAgICAgICAgICAgIDEsXHJcbiAgQ09OQ0lGR19QT1JUX1BBQ0tFVF9FUlJPUl9EQVRBX1NJWkU6ICAgICAgICAgICAgICAgMixcclxuICBDT05DSUZHX1BPUlRfUEFDS0VUX0VSUk9SX0RBVEFfQ09OVEVOVDogICAgICAgICAgICAzLFxyXG4gIENPTkNJRkdfUE9SVF9QQUNLRVRfRVJST1JfQ0hFQ0tTVU06ICAgICAgICAgICAgICAgIDQsXHJcbiAgQ09OQ0lGR19QT1JUX1BBQ0tFVF9FUlJPUl9BVVRIRU5USUNBVElPTl9GQUlMRUQ6ICAgNSxcclxuICBDT05DSUZHX1BPUlRfUEFDS0VUX0VSUk9SX1NFU1NJT05fUEFDS0VUOiAgICAgICAgICA2LFxyXG4gIENPTkNJRkdfUE9SVF9QQUNLRVRfRVJST1JfU0VTU0lPTl9OT1RfQUNUSVZFOiAgICAgIDcsXHJcbn07XHJcblxyXG5sZXQgYXV0aGVudGljYXRvciA9IHtcclxuICBkZXZpY2VOb3RSZXNwb25kaW5nQ291bnRlcjogMCxcclxuICBzZXNzaW9uUGFja2V0RmFpbENvdW50ZXI6IDAsXHJcbiAgc2Vzc2lvbkFjdGl2ZTogZmFsc2UsXHJcbiAgc2Vzc2lvbktleTogW10sXHJcbn1cclxuXHJcbmxldCB0eENvbnRyb2xsZXIgPSB7XHJcbiAgc3RhdGU6ICdpZGxlJyxcclxuICBzdGF0ZVN0ZXA6IDAsXHJcbn1cclxuXHJcbmxldCBhcHBQYXJhbXMgPSB7XHJcbiAgc3RhdHVzOiB7fSxcclxuICBzdGF0dXNCdWxrOiB7fSxcclxuICBzZXR0aW5nOiB7fSxcclxuICBzZXR0aW5nQnVsazoge1xyXG4gICAgZGV2aWNlSWRCbGFja0xpc3Q6IFtdLFxyXG4gIH0sXHJcbn07XHJcblxyXG5sZXQgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0ID0ge1xyXG4gIHZhbGlkOiBmYWxzZSxcclxuICBwYWNrZXQ6IFtdLFxyXG4gIGV4cGVjdGVkUmVzcG9uc2U6IG51bGwsXHJcbiAgc3VjY2Vzc01lc3NhZ2U6ICcnLFxyXG4gIGZhaWx1cmVNZXNzYWdlOiAnJyxcclxuICBtYXhSZXNwb25zZVRpbWU6IG51bGwsXHJcbiAgaXNTcGVjaWFsQ29tbWFuZDogZmFsc2UsXHJcbiAgcmVxdWVzdE5hbWU6IGZhbHNlLFxyXG4gIHJlcXVlc3REYXRhOiBudWxsLFxyXG59O1xyXG5cclxubGV0IHJ1bkludGVydmFsID0gMTAwO1xyXG5sZXQgc2VyaWFsVG9VaUV2ZW50Q2FsbGJhY2sgPSBudWxsO1xyXG5sZXQgcnhQYWNrZXQgPSB7XHJcbiAgdmFsaWQ6IGZhbHNlLFxyXG4gIGNvbW1hbmQ6IDB4MDAsXHJcbiAgZGF0YTogW10sXHJcbn07XHJcblxyXG5mdW5jdGlvbiBjcmVhdGVVaVRvU2VyaWFsUGVuZGluZ1BhY2tldCAocGFja2V0KSB7XHJcbiAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LnZhbGlkID0gdHJ1ZTtcclxuICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3QucGFja2V0ID0gcGFja2V0O1xyXG59XHJcblxyXG5sZXQgY29tUG9ydFN0aWxsQ29ubmVjdGVkRnVuY3Rpb24gPSBhc3luYyAoKSA9PiB7XHJcbiAgcmV0dXJuIGZhbHNlO1xyXG59XHJcblxyXG5mdW5jdGlvbiByZWdpc3RlckNvbVBvcnRTdGlsbENvbm5lY3RlZEZ1bmN0aW9uIChmdW5jKSB7XHJcbiAgY29tUG9ydFN0aWxsQ29ubmVjdGVkRnVuY3Rpb24gPSBmdW5jO1xyXG59XHJcblxyXG5mdW5jdGlvbiB0eENvbnRyb2xsZXJTdGF0ZVN0ZXBGb3J3YXJkIChudW1PZlN0ZXBzPTEpIHtcclxuICB0eENvbnRyb2xsZXIuc3RhdGVTdGVwICs9IG51bU9mU3RlcHM7XHJcbn1cclxuXHJcbmZ1bmN0aW9uIHR4Q29udHJvbGxlckdvVG9TdGF0ZSAobmV3U3RhdGUpIHtcclxuICB0eENvbnRyb2xsZXIuc3RhdGUgPSBuZXdTdGF0ZTtcclxuICB0eENvbnRyb2xsZXIuc3RhdGVTdGVwID0gMDtcclxufVxyXG5cclxuZnVuY3Rpb24gdHhDb250cm9sbGVySGFuZGxlU3RhdGVNYWNoaW5lRmFpbCAobWVzc2FnZSkge1xyXG4gIGNvbnNvbGUuZXJyb3IodHhDb250cm9sbGVyKTtcclxuICB0aHJvdyBuZXcgRXJyb3IobWVzc2FnZSk7XHJcbn1cclxuXHJcbmFzeW5jIGZ1bmN0aW9uIHR4Q29udHJvbFJ1biAoKSB7XHJcbiAgbGV0IGluc3RhbnRSZVJ1blJlcXVlc3RGbGFnID0gMDtcclxuICBjb25zdCBpbnN0YW50UmVSdW4gPSAoKSA9PiB7IGluc3RhbnRSZVJ1blJlcXVlc3RGbGFnID0gMTsgfTtcclxuXHJcbiAgc3dpdGNoKHR4Q29udHJvbGxlci5zdGF0ZSkge1xyXG4gICAgY2FzZSAnaWRsZSc6IHtcclxuICAgICAgaWYoIWF1dGhlbnRpY2F0b3Iuc2Vzc2lvbkFjdGl2ZSkge1xyXG4gICAgICAgIHR4Q29udHJvbGxlckdvVG9TdGF0ZSgnYXV0aGVudGljYXRpb24nKTtcclxuICAgICAgICBzZXJpYWxUb1VpRXZlbnRDYWxsYmFjayh7XHJcbiAgICAgICAgICBuYW1lOiAnYXV0aGVudGljYXRvclN0YXJ0JyxcclxuICAgICAgICAgIGRhdGE6ICcnXHJcbiAgICAgICAgfSk7XHJcbiAgICAgIH0gZWxzZSBpZih1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3QudmFsaWQpIHtcclxuICAgICAgICBpZihhd2FpdCBjb21Qb3J0U3RpbGxDb25uZWN0ZWRGdW5jdGlvbigpKSB7XHJcbiAgICAgICAgICBzZXJpYWxUeC5zZW5kUGFja2V0QXJyYXkodWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LnBhY2tldCk7XHJcblxyXG4gICAgICAgICAgaWYodWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LmlzU3BlY2lhbENvbW1hbmQpIHtcclxuICAgICAgICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LnZhbGlkID0gZmFsc2U7XHJcbiAgICAgICAgICAgIHR4Q29udHJvbGxlckdvVG9TdGF0ZSh1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3QucmVxdWVzdE5hbWUpO1xyXG4gICAgICAgICAgICBpbnN0YW50UmVSdW4oKTtcclxuICAgICAgICAgICAgYnJlYWs7XHJcbiAgICAgICAgICB9XHJcblxyXG4gICAgICAgICAgc3dpdGNoKHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5leHBlY3RlZFJlc3BvbnNlKSB7XHJcbiAgICAgICAgICAgIGNhc2UgJ3NpbXBsZUFjayc6IHtcclxuICAgICAgICAgICAgICBhd2FpdCBwb2xsRm9yUnhQYWNrZXRSZWFkeSh1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3QubWF4UmVzcG9uc2VUaW1lKTtcclxuICAgICAgICAgICAgICBcclxuICAgICAgICAgICAgICBpZihyeFBhY2tldC52YWxpZCkge1xyXG4gICAgICAgICAgICAgICAgc3dpdGNoKHJ4UGFja2V0LmNvbW1hbmQpIHtcclxuICAgICAgICAgICAgICAgICAgY2FzZSBDT01NQU5EUy5BQ0s6IHtcclxuICAgICAgICAgICAgICAgICAgICBwb3BVcE1lc3NhZ2UuZGlzcGxheVBvcFVwKFxyXG4gICAgICAgICAgICAgICAgICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LnN1Y2Nlc3NNZXNzYWdlLFxyXG4gICAgICAgICAgICAgICAgICAgICAgJ0dSRUVOJyxcclxuICAgICAgICAgICAgICAgICAgICApO1xyXG4gICAgICAgICAgICAgICAgICB9XHJcbiAgICAgICAgICAgICAgICAgIGJyZWFrO1xyXG5cclxuICAgICAgICAgICAgICAgICAgY2FzZSBDT01NQU5EUy5OQUNLOiB7XHJcbiAgICAgICAgICAgICAgICAgICAgbGV0IG5hY2tNZXNzYWdlU3RyaW5nID0gcnhQYWNrZXQuZGF0YS5zbGljZSgyKTtcclxuXHJcbiAgICAgICAgICAgICAgICAgICAgaWYobmFja01lc3NhZ2VTdHJpbmcubGVuZ3RoKSB7XHJcbiAgICAgICAgICAgICAgICAgICAgICBuYWNrTWVzc2FnZVN0cmluZyA9IHRvb2xCb3guYXNjaWlBcnJheVV0ZjhEZWNvZGUobmFja01lc3NhZ2VTdHJpbmcpO1xyXG4gICAgICAgICAgICAgICAgICAgIH0gZWxzZSB7XHJcbiAgICAgICAgICAgICAgICAgICAgICBuYWNrTWVzc2FnZVN0cmluZyA9IG51bGw7XHJcbiAgICAgICAgICAgICAgICAgICAgfVxyXG5cclxuICAgICAgICAgICAgICAgICAgICBwb3BVcE1lc3NhZ2UuZGlzcGxheVBvcFVwKFxyXG4gICAgICAgICAgICAgICAgICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LmZhaWx1cmVNZXNzYWdlLFxyXG4gICAgICAgICAgICAgICAgICAgICAgJ1JFRCcsXHJcbiAgICAgICAgICAgICAgICAgICAgKTtcclxuXHJcbiAgICAgICAgICAgICAgICAgICAgaWYobmFja01lc3NhZ2VTdHJpbmcpIHtcclxuICAgICAgICAgICAgICAgICAgICAgIHBvcFVwTWVzc2FnZS5kaXNwbGF5UG9wVXAoXHJcbiAgICAgICAgICAgICAgICAgICAgICAgIG5hY2tNZXNzYWdlU3RyaW5nLFxyXG4gICAgICAgICAgICAgICAgICAgICAgICAnUkVEJyxcclxuICAgICAgICAgICAgICAgICAgICAgICk7XHJcbiAgICAgICAgICAgICAgICAgICAgfVxyXG5cclxuICAgICAgICAgICAgICAgICAgICAvLyBwb3BVcE1lc3NhZ2UuZGlzcGxheVBvcFVwKFxyXG4gICAgICAgICAgICAgICAgICAgIC8vICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LmZhaWx1cmVNZXNzYWdlICsgYCAke3J4UGFja2V0LmRhdGFbMV19IGAsXHJcbiAgICAgICAgICAgICAgICAgICAgLy8gICAnUkVEJyxcclxuICAgICAgICAgICAgICAgICAgICAvLyApO1xyXG4gICAgICAgICAgICAgICAgICB9XHJcbiAgICAgICAgICAgICAgICAgIGJyZWFrO1xyXG5cclxuICAgICAgICAgICAgICAgICAgZGVmYXVsdDoge1xyXG4gICAgICAgICAgICAgICAgICAgIHBvcFVwTWVzc2FnZS5kaXNwbGF5UG9wVXAoXHJcbiAgICAgICAgICAgICAgICAgICAgICBg2KfZhtiq2LjYp9ixINmF24wg2LHZgdiqIEFDSyDYr9ix24zYp9mB2Kog2LTZiNivINmI2YTbjCDaqdivICR7cnhQYWNrZXQuY29tbWFuZH0g2K/YsduM2KfZgSDYtNivYCxcclxuICAgICAgICAgICAgICAgICAgICAgICdSRUQnLFxyXG4gICAgICAgICAgICAgICAgICAgICk7XHJcbiAgICAgICAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgICAgICAgYnJlYWs7XHJcbiAgICAgICAgICAgICAgICB9XHJcbiAgICAgICAgICAgICAgfSBlbHNlIHtcclxuICAgICAgICAgICAgICAgIHBvcFVwTWVzc2FnZS5kaXNwbGF5UG9wVXAoXHJcbiAgICAgICAgICAgICAgICAgICfZvtin2LPYrtuMINiv2LHbjNin2YHYqiDZhti02K8nLFxyXG4gICAgICAgICAgICAgICAgICAnUkVEJ1xyXG4gICAgICAgICAgICAgICAgKTtcclxuICAgICAgICAgICAgICB9XHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgYnJlYWs7XHJcbiAgICAgICAgICAgIFxyXG4gICAgICAgICAgICBjYXNlICdub25lJzpcclxuICAgICAgICAgICAgZGVmYXVsdDoge1xyXG4gICAgICAgICAgICAgIC8qIERvIG5vdGhpbmcgKi9cclxuICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICBicmVhaztcclxuICAgICAgICAgIH1cclxuICAgICAgICB9IGVsc2Uge1xyXG4gICAgICAgICAgcG9wVXBNZXNzYWdlLmRpc3BsYXlQb3BVcChcclxuICAgICAgICAgICAgJ9m+2YjYsdiqINiz2LHbjNin2YQg2YXYqti12YQg2YbbjNiz2KonLFxyXG4gICAgICAgICAgICAnT1JBTkdFJ1xyXG4gICAgICAgICAgKTtcclxuICAgICAgICAgIGNvbnNvbGUud2FybignQ09NIFBvcnQgbm90IGNvbm5lY3RlZCcpO1xyXG4gICAgICAgIH1cclxuXHJcbiAgICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LnZhbGlkID0gZmFsc2U7XHJcbiAgICAgIH0gZWxzZSB7XHJcbiAgICAgICAgLy8gaWYoISBhd2FpdCBjb21Qb3J0U3RpbGxDb25uZWN0ZWRGdW5jdGlvbigpKSB7IGJyZWFrOyB9XHJcblxyXG4gICAgICAgIHR4Q29udHJvbGxlckdvVG9TdGF0ZSgncmVxdWVzdFN0YXR1cycpO1xyXG4gICAgICAgIGluc3RhbnRSZVJ1bigpO1xyXG4gICAgICB9XHJcbiAgICB9XHJcbiAgICBicmVhaztcclxuXHJcbiAgICBjYXNlICdhdXRoZW50aWNhdGlvbic6IHtcclxuICAgICAgc3dpdGNoKHR4Q29udHJvbGxlci5zdGF0ZVN0ZXApIHtcclxuICAgICAgICBjYXNlIDA6IHsgLyogQ2hlY2sgZm9yIENPTSBDb25uZWN0aW9uICovXHJcbiAgICAgICAgICBpZihhd2FpdCBjb21Qb3J0U3RpbGxDb25uZWN0ZWRGdW5jdGlvbigpKSB7XHJcbiAgICAgICAgICAgIHNlcmlhbFRvVWlFdmVudENhbGxiYWNrKHtcclxuICAgICAgICAgICAgICBuYW1lOiAnYXV0aGVudGljYXRvckNvbVBvcnRDb25uZWN0aW9uVGVzdCcsXHJcbiAgICAgICAgICAgICAgZGF0YTogJ3N1Y2Nlc3MnXHJcbiAgICAgICAgICAgIH0pO1xyXG4gICAgICAgICAgICB0eENvbnRyb2xsZXJTdGF0ZVN0ZXBGb3J3YXJkKCk7XHJcbiAgICAgICAgICAgIGNvbnNvbGUubG9nKGBBdXRoZW50aWNhdG9yOiBDT00gUG9ydCBDb25uZWN0ZWRgKTtcclxuICAgICAgICAgICAgYXdhaXQgdG9vbEJveC5hc3luY0RlbGF5KGNvbmZpZy5zZXJpYWwuQVVUSEVOVElDQVRJT05fQU5JTUFUSU9OX0RFTEFZKTtcclxuICAgICAgICAgIH0gZWxzZSB7XHJcbiAgICAgICAgICAgIHNlcmlhbFRvVWlFdmVudENhbGxiYWNrKHtcclxuICAgICAgICAgICAgICBuYW1lOiAnYXV0aGVudGljYXRvckNvbVBvcnRDb25uZWN0aW9uVGVzdCcsXHJcbiAgICAgICAgICAgICAgZGF0YTogJ3N0YXJ0J1xyXG4gICAgICAgICAgICB9KTtcclxuICAgICAgICAgIH1cclxuICAgICAgICB9XHJcbiAgICAgICAgYnJlYWs7XHJcblxyXG4gICAgICAgIGNhc2UgMTogeyAvKiBIRUxMTyBQYWNrZXQgKi9cclxuICAgICAgICAgIGxldCBmYWlsZWQgPSBmYWxzZTtcclxuICAgICAgICAgIFxyXG4gICAgICAgICAgc2VyaWFsVG9VaUV2ZW50Q2FsbGJhY2soe1xyXG4gICAgICAgICAgICBuYW1lOiAnYXV0aGVudGljYXRvckhlbGxvJyxcclxuICAgICAgICAgICAgZGF0YTogJ3N0YXJ0J1xyXG4gICAgICAgICAgfSk7XHJcbiAgICAgICAgICBhd2FpdCB0b29sQm94LmFzeW5jRGVsYXkoY29uZmlnLnNlcmlhbC5BVVRIRU5USUNBVElPTl9BTklNQVRJT05fREVMQVkpO1xyXG5cclxuICAgICAgICAgIHNlcmlhbFR4LmNyZWF0ZUFuZFNlbmRQYWNrZXQoXHJcbiAgICAgICAgICAgIENPTU1BTkRTLkhFTExPLFxyXG4gICAgICAgICAgKTtcclxuXHJcbiAgICAgICAgICBhd2FpdCBwb2xsRm9yUnhQYWNrZXRSZWFkeSgzMDApO1xyXG5cclxuICAgICAgICAgIGlmKHJ4UGFja2V0LnZhbGlkKSB7XHJcbiAgICAgICAgICAgIC8vIGNvbnNvbGUubG9nKHJ4UGFja2V0KTtcclxuXHJcbiAgICAgICAgICAgIGlmKHJ4UGFja2V0LmNvbW1hbmQgPT09IENPTU1BTkRTLkhFTExPKSB7XHJcbiAgICAgICAgICAgICAgY29uc29sZS5sb2coXHJcbiAgICAgICAgICAgICAgICBgQXV0aGVudGljYXRvcjogUmVjZWl2ZWQgSEVMTE8gUmVzcG9uc2VgLFxyXG4gICAgICAgICAgICAgICk7XHJcbiAgICAgICAgICAgICAgXHJcbiAgICAgICAgICAgICAgc2VyaWFsVG9VaUV2ZW50Q2FsbGJhY2soe1xyXG4gICAgICAgICAgICAgICAgbmFtZTogJ2F1dGhlbnRpY2F0b3JIZWxsbycsXHJcbiAgICAgICAgICAgICAgICBkYXRhOiAnc3VjY2VzcydcclxuICAgICAgICAgICAgICB9KTtcclxuICAgICAgICAgICAgICB0eENvbnRyb2xsZXJTdGF0ZVN0ZXBGb3J3YXJkKCk7XHJcbiAgICAgICAgICAgICAgYXdhaXQgdG9vbEJveC5hc3luY0RlbGF5KGNvbmZpZy5zZXJpYWwuQVVUSEVOVElDQVRJT05fQU5JTUFUSU9OX0RFTEFZKTtcclxuICAgICAgICAgICAgfSBlbHNlIHtcclxuICAgICAgICAgICAgICBmYWlsZWQgPSB0cnVlO1xyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgICB9IGVsc2Uge1xyXG4gICAgICAgICAgICBjb25zb2xlLmxvZyhgQXV0aGVudGljYXRvcjogZGlkbid0IHJlY2VpdmUgXCJIRUxMT1wiYCk7XHJcbiAgICAgICAgICAgIGZhaWxlZCA9IHRydWU7XHJcbiAgICAgICAgICB9XHJcblxyXG4gICAgICAgICAgaWYoZmFpbGVkKSB7XHJcbiAgICAgICAgICAgIHNlcmlhbFRvVWlFdmVudENhbGxiYWNrKHtcclxuICAgICAgICAgICAgICBuYW1lOiAnYXV0aGVudGljYXRvckhlbGxvJyxcclxuICAgICAgICAgICAgICBkYXRhOiAnZmFpbCdcclxuICAgICAgICAgICAgfSk7XHJcbiAgICAgICAgICAgIHR4Q29udHJvbGxlci5zdGF0ZVN0ZXAgPSAwO1xyXG4gICAgICAgICAgICBhd2FpdCB0b29sQm94LmFzeW5jRGVsYXkoY29uZmlnLnNlcmlhbC5BVVRIRU5USUNBVElPTl9BTklNQVRJT05fREVMQVkpO1xyXG4gICAgICAgICAgfVxyXG4gICAgICAgIH1cclxuICAgICAgICBicmVhaztcclxuXHJcbiAgICAgICAgY2FzZSAyOiB7IC8qIFJhZG5vbSBEYXRhICovXHJcbiAgICAgICAgICBpZihjb25maWcuc2VyaWFsLkFVVEhFTlRJQ0FUSU9OX05PVF9ORUVEREVEKSB7XHJcbiAgICAgICAgICAgIGF1dGhlbnRpY2F0b3Iuc2Vzc2lvbkFjdGl2ZSA9IHRydWU7XHJcbiAgICAgICAgICAgIGF1dGhlbnRpY2F0b3Iuc2Vzc2lvbktleSA9IFtdO1xyXG4gICAgICAgICAgICBcclxuICAgICAgICAgICAgZm9yKGxldCBpID0gMDsgaSA8IGF1dGhlbnRpY2F0b3IucGNSYW5kb21EYXRhTGVuZ3RoOyBpKyspIHtcclxuICAgICAgICAgICAgICBhdXRoZW50aWNhdG9yLnNlc3Npb25LZXkucHVzaCh0b29sQm94LnJhbmRvbVJhbmdlKDAsIDI1NSkpO1xyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgICAgIFxyXG4gICAgICAgICAgICBzZXJpYWxUb1VpRXZlbnRDYWxsYmFjayh7XHJcbiAgICAgICAgICAgICAgbmFtZTogJ2F1dGhlbnRpY2F0b3JTdG9wJyxcclxuICAgICAgICAgICAgICBkYXRhOiAnJ1xyXG4gICAgICAgICAgICB9KTtcclxuICBcclxuICAgICAgICAgICAgdHhDb250cm9sbGVyR29Ub1N0YXRlKCdpZGxlJyk7XHJcbiAgICAgICAgICAgIGJyZWFrO1xyXG4gICAgICAgICAgfVxyXG4gICAgICAgICAgXHJcbiAgICAgICAgICBsZXQgZmFpbGVkID0gZmFsc2U7XHJcbiAgICAgICAgICBcclxuICAgICAgICAgIHNlcmlhbFRvVWlFdmVudENhbGxiYWNrKHtcclxuICAgICAgICAgICAgbmFtZTogJ2F1dGhlbnRpY2F0b3JTdGFnZTEnLFxyXG4gICAgICAgICAgICBkYXRhOiAnc3RhcnQnXHJcbiAgICAgICAgICB9KTtcclxuICAgICAgICAgIGF3YWl0IHRvb2xCb3guYXN5bmNEZWxheShjb25maWcuc2VyaWFsLkFVVEhFTlRJQ0FUSU9OX0FOSU1BVElPTl9ERUxBWSk7XHJcblxyXG4gICAgICAgICAgYXV0aGVudGljYXRvci5wY1JhbmRvbURhdGEgPSBbXTtcclxuICAgICAgICAgIGF1dGhlbnRpY2F0b3IucGNSYW5kb21EYXRhTGVuZ3RoID0gdG9vbEJveC5yYW5kb21SYW5nZShcclxuICAgICAgICAgICAgQVVUSEVOVElDQVRJT05fTUlOX1JBTkRPTV9EQVRBX0xFTkdUSCxcclxuICAgICAgICAgICAgQVVUSEVOVElDQVRJT05fTUFYX1JBTkRPTV9EQVRBX0xFTkdUSFxyXG4gICAgICAgICAgKTtcclxuICAgICAgICAgIGZvcihsZXQgaSA9IDA7IGkgPCBhdXRoZW50aWNhdG9yLnBjUmFuZG9tRGF0YUxlbmd0aDsgaSsrKSB7XHJcbiAgICAgICAgICAgIGF1dGhlbnRpY2F0b3IucGNSYW5kb21EYXRhLnB1c2godG9vbEJveC5yYW5kb21SYW5nZSgwLCAyNTUpKTtcclxuICAgICAgICAgIH1cclxuXHJcbiAgICAgICAgICBjb25zb2xlLmxvZyhcclxuICAgICAgICAgICAgYEF1dGhlbnRpY2F0b3I6IHBjUmFuZG9tRGF0YVske2F1dGhlbnRpY2F0b3IucGNSYW5kb21EYXRhLmxlbmd0aH1dOmAsXHJcbiAgICAgICAgICAgIGBbJHt0b29sQm94LnRvSGV4U3RyaW5nKGF1dGhlbnRpY2F0b3IucGNSYW5kb21EYXRhLCAnICcpfV1gXHJcbiAgICAgICAgICApO1xyXG5cclxuICAgICAgICAgIHNlcmlhbFR4LmNyZWF0ZUFuZFNlbmRQYWNrZXQoXHJcbiAgICAgICAgICAgIENPTU1BTkRTLkFVVEhFTlRJQ0FUSU9OX1JBTkRPTV9EQVRBLFxyXG4gICAgICAgICAgICBhdXRoZW50aWNhdG9yLnBjUmFuZG9tRGF0YVxyXG4gICAgICAgICAgKTtcclxuXHJcbiAgICAgICAgICBhd2FpdCBwb2xsRm9yUnhQYWNrZXRSZWFkeSgzMDApO1xyXG5cclxuICAgICAgICAgIGlmKHJ4UGFja2V0LnZhbGlkKSB7XHJcbiAgICAgICAgICAgIC8vIGNvbnNvbGUubG9nKHJ4UGFja2V0KTtcclxuICBcclxuICAgICAgICAgICAgaWYocnhQYWNrZXQuY29tbWFuZCA9PT0gQ09NTUFORFMuQVVUSEVOVElDQVRJT05fUkFORE9NX0RBVEEpIHtcclxuICAgICAgICAgICAgICBhdXRoZW50aWNhdG9yLmRldmljZVJhbmRvbURhdGEgPSB0b29sQm94LmRlZXBDbG9uZShyeFBhY2tldC5kYXRhKTtcclxuICAgICAgICAgICAgICBjb25zb2xlLmxvZyhcclxuICAgICAgICAgICAgICAgIGBBdXRoZW50aWNhdG9yOiBkZXZpY2VSYW5kb21EYXRhWyR7YXV0aGVudGljYXRvci5kZXZpY2VSYW5kb21EYXRhLmxlbmd0aH1dOmAsXHJcbiAgICAgICAgICAgICAgICBgWyR7dG9vbEJveC50b0hleFN0cmluZyhhdXRoZW50aWNhdG9yLmRldmljZVJhbmRvbURhdGEsICcgJyl9XWBcclxuICAgICAgICAgICAgICApO1xyXG4gICAgICAgICAgICAgIFxyXG4gICAgICAgICAgICAgIHNlcmlhbFRvVWlFdmVudENhbGxiYWNrKHtcclxuICAgICAgICAgICAgICAgIG5hbWU6ICdhdXRoZW50aWNhdG9yU3RhZ2UxJyxcclxuICAgICAgICAgICAgICAgIGRhdGE6ICdzdWNjZXNzJ1xyXG4gICAgICAgICAgICAgIH0pO1xyXG4gICAgICAgICAgICAgIHR4Q29udHJvbGxlclN0YXRlU3RlcEZvcndhcmQoKTtcclxuICAgICAgICAgICAgICBhd2FpdCB0b29sQm94LmFzeW5jRGVsYXkoY29uZmlnLnNlcmlhbC5BVVRIRU5USUNBVElPTl9BTklNQVRJT05fREVMQVkpO1xyXG4gICAgICAgICAgICB9IGVsc2Uge1xyXG4gICAgICAgICAgICAgIGZhaWxlZCA9IHRydWU7XHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICAgIH0gZWxzZSB7XHJcbiAgICAgICAgICAgIGNvbnNvbGUubG9nKGBBdXRoZW50aWNhdG9yOiBkaWRuJ3QgcmVjZWl2ZSBcIkRldmljZSBSYW5kb20gRGF0YVwiYCk7XHJcbiAgICAgICAgICAgIGZhaWxlZCA9IHRydWU7XHJcbiAgICAgICAgICBcclxuICAgICAgICAgICAgc2VyaWFsVG9VaUV2ZW50Q2FsbGJhY2soe1xyXG4gICAgICAgICAgICAgIG5hbWU6ICdhdXRoZW50aWNhdG9yU3RhZ2UxJyxcclxuICAgICAgICAgICAgICBkYXRhOiAnZmFpbCdcclxuICAgICAgICAgICAgfSk7XHJcbiAgICAgICAgICAgIGF3YWl0IHRvb2xCb3guYXN5bmNEZWxheShjb25maWcuc2VyaWFsLkFVVEhFTlRJQ0FUSU9OX0FOSU1BVElPTl9ERUxBWSk7XHJcbiAgICAgICAgICB9XHJcblxyXG4gICAgICAgICAgaWYoZmFpbGVkKSB7XHJcbiAgICAgICAgICAgIHR4Q29udHJvbGxlci5zdGF0ZVN0ZXAgPSAwO1xyXG4gICAgICAgICAgfVxyXG4gICAgICAgIH1cclxuICAgICAgICBicmVhaztcclxuXHJcbiAgICAgICAgY2FzZSAzOiB7IC8qIFVuaXF1ZSBJRCAqL1xyXG4gICAgICAgICAgbGV0IGZhaWxlZCA9IGZhbHNlO1xyXG4gICAgICAgICAgXHJcbiAgICAgICAgICBzZXJpYWxUb1VpRXZlbnRDYWxsYmFjayh7XHJcbiAgICAgICAgICAgIG5hbWU6ICdhdXRoZW50aWNhdG9yU3RhZ2UyJyxcclxuICAgICAgICAgICAgZGF0YTogJ3N0YXJ0J1xyXG4gICAgICAgICAgfSk7XHJcbiAgICAgICAgICBhd2FpdCB0b29sQm94LmFzeW5jRGVsYXkoY29uZmlnLnNlcmlhbC5BVVRIRU5USUNBVElPTl9BTklNQVRJT05fREVMQVkpO1xyXG5cclxuICAgICAgICAgIGF1dGhlbnRpY2F0b3IucGNVbmlxdWVJZCA9IFtdO1xyXG4gICAgICAgICAgYXV0aGVudGljYXRvci5wY1VuaXF1ZUlkTGVuZ3RoID0gdG9vbEJveC5yYW5kb21SYW5nZShcclxuICAgICAgICAgICAgQVVUSEVOVElDQVRJT05fTUlOX1VOSVFVRV9JRF9MRU5HVEgsXHJcbiAgICAgICAgICAgIEFVVEhFTlRJQ0FUSU9OX01BWF9VTklRVUVfSURfTEVOR1RIXHJcbiAgICAgICAgICApO1xyXG4gICAgICAgICAgZm9yKGxldCBpID0gMDsgaSA8IGF1dGhlbnRpY2F0b3IucGNVbmlxdWVJZExlbmd0aDsgaSsrKSB7XHJcbiAgICAgICAgICAgIGF1dGhlbnRpY2F0b3IucGNVbmlxdWVJZC5wdXNoKHRvb2xCb3gucmFuZG9tUmFuZ2UoMCwgMjU1KSk7XHJcbiAgICAgICAgICB9XHJcblxyXG4gICAgICAgICAgYXV0aGVudGljYXRvci5wY0hhc2ggPSBwZXJzb25hbEhhc2guY3JlYXRlSGFzaChbXHJcbiAgICAgICAgICAgIC4uLnRvb2xCb3guc3RyaW5nVG9Bc2NpaUFycmF5KGNvbmZpZy5zZXJpYWwuR1VJX0FVVEhFTlRJQ0FUSU9OX0hBU0hfS0VZKSxcclxuICAgICAgICAgICAgLi4uYXV0aGVudGljYXRvci5wY1JhbmRvbURhdGEsXHJcbiAgICAgICAgICAgIC4uLmF1dGhlbnRpY2F0b3IuZGV2aWNlUmFuZG9tRGF0YSxcclxuICAgICAgICAgICAgLi4uYXV0aGVudGljYXRvci5wY1VuaXF1ZUlkLFxyXG4gICAgICAgICAgXSk7XHJcblxyXG4gICAgICAgICAgY29uc29sZS5sb2coXHJcbiAgICAgICAgICAgIGBBdXRoZW50aWNhdG9yOiBwY1VuaXF1ZUlkWyR7YXV0aGVudGljYXRvci5wY1VuaXF1ZUlkLmxlbmd0aH1dOmAsXHJcbiAgICAgICAgICAgIGBbJHt0b29sQm94LnRvSGV4U3RyaW5nKGF1dGhlbnRpY2F0b3IucGNVbmlxdWVJZCwgJyAnKX1dYFxyXG4gICAgICAgICAgKTtcclxuXHJcbiAgICAgICAgICBzZXJpYWxUeC5jcmVhdGVBbmRTZW5kUGFja2V0KFxyXG4gICAgICAgICAgICBDT01NQU5EUy5BVVRIRU5USUNBVElPTl9VTklRVUVfSURfQU5EX0hBU0gsXHJcbiAgICAgICAgICAgIFtcclxuICAgICAgICAgICAgICAuLi5hdXRoZW50aWNhdG9yLnBjSGFzaCxcclxuICAgICAgICAgICAgICAuLi5hdXRoZW50aWNhdG9yLnBjVW5pcXVlSWQsXHJcbiAgICAgICAgICAgIF1cclxuICAgICAgICAgICk7XHJcblxyXG4gICAgICAgICAgYXdhaXQgcG9sbEZvclJ4UGFja2V0UmVhZHkoMzAwKTtcclxuXHJcbiAgICAgICAgICBpZihyeFBhY2tldC52YWxpZCkge1xyXG4gICAgICAgICAgICAvLyBjb25zb2xlLmxvZyhyeFBhY2tldCk7XHJcblxyXG4gICAgICAgICAgICBpZihyeFBhY2tldC5jb21tYW5kID09PSBDT01NQU5EUy5BVVRIRU5USUNBVElPTl9VTklRVUVfSURfQU5EX0hBU0gpIHtcclxuICAgICAgICAgICAgICBsZXQgcGFja2V0RGF0YUNsb25lID0gdG9vbEJveC5kZWVwQ2xvbmUocnhQYWNrZXQuZGF0YSk7XHJcblxyXG4gICAgICAgICAgICAgIGF1dGhlbnRpY2F0b3IuZGV2aWNlSGFzaCA9IHBhY2tldERhdGFDbG9uZS5zcGxpY2UoMCwgMzIpO1xyXG4gICAgICAgICAgICAgIGF1dGhlbnRpY2F0b3IuZGV2aWNlVW5pcXVlSWQgPSBwYWNrZXREYXRhQ2xvbmU7XHJcbiAgICAgICAgICAgICAgXHJcbiAgICAgICAgICAgICAgY29uc29sZS5sb2coXHJcbiAgICAgICAgICAgICAgICBgQXV0aGVudGljYXRvcjogZGV2aWNlSGFzaFske2F1dGhlbnRpY2F0b3IuZGV2aWNlSGFzaC5sZW5ndGh9XTpgLFxyXG4gICAgICAgICAgICAgICAgYFske3Rvb2xCb3gudG9IZXhTdHJpbmcoYXV0aGVudGljYXRvci5kZXZpY2VIYXNoLCAnICcpfV1gXHJcbiAgICAgICAgICAgICAgKTtcclxuXHJcbiAgICAgICAgICAgICAgY29uc29sZS5sb2coXHJcbiAgICAgICAgICAgICAgICBgQXV0aGVudGljYXRvcjogZGV2aWNlVW5pcXVlSWRbJHthdXRoZW50aWNhdG9yLmRldmljZVVuaXF1ZUlkLmxlbmd0aH1dOmAsXHJcbiAgICAgICAgICAgICAgICBgWyR7dG9vbEJveC50b0hleFN0cmluZyhhdXRoZW50aWNhdG9yLmRldmljZVVuaXF1ZUlkLCAnICcpfV1gXHJcbiAgICAgICAgICAgICAgKTtcclxuXHJcbiAgICAgICAgICAgICAgaWYoYXV0aGVudGljYXRvci5kZXZpY2VVbmlxdWVJZC5sZW5ndGggPCBBVVRIRU5USUNBVElPTl9NSU5fVU5JUVVFX0lEX0xFTkdUSCkge1xyXG4gICAgICAgICAgICAgICAgY29uc29sZS53YXJuKGBBdXRoZW50aWNhdG9yOiBkZXZpY2VVbmlxdWVJZC5sZW5ndGggaXMgdG9vIHNob3J0XCJgKTtcclxuICAgICAgICAgICAgICAgIGZhaWxlZCA9IHRydWU7XHJcbiAgICAgICAgICAgICAgfSBlbHNlIHtcclxuICAgICAgICAgICAgICAgIGF1dGhlbnRpY2F0b3IuZGV2aWNlRXhwZWN0ZWRIYXNoID0gcGVyc29uYWxIYXNoLmNyZWF0ZUhhc2goW1xyXG4gICAgICAgICAgICAgICAgICAuLi50b29sQm94LnN0cmluZ1RvQXNjaWlBcnJheShjb25maWcuc2VyaWFsLkdVSV9BVVRIRU5USUNBVElPTl9IQVNIX0tFWSksXHJcbiAgICAgICAgICAgICAgICAgIC4uLmF1dGhlbnRpY2F0b3IucGNSYW5kb21EYXRhLFxyXG4gICAgICAgICAgICAgICAgICAuLi5hdXRoZW50aWNhdG9yLmRldmljZVJhbmRvbURhdGEsXHJcbiAgICAgICAgICAgICAgICAgIC4uLmF1dGhlbnRpY2F0b3IuZGV2aWNlVW5pcXVlSWQsXHJcbiAgICAgICAgICAgICAgICBdKTtcclxuXHJcbiAgICAgICAgICAgICAgICBpZih0b29sQm94LmRlZXBDb21wYXJlQXJyYXlzKGF1dGhlbnRpY2F0b3IuZGV2aWNlSGFzaCwgYXV0aGVudGljYXRvci5kZXZpY2VFeHBlY3RlZEhhc2gpKSB7XHJcbiAgICAgICAgICAgICAgICAgIHNlcmlhbFRvVWlFdmVudENhbGxiYWNrKHtcclxuICAgICAgICAgICAgICAgICAgICBuYW1lOiAnYXV0aGVudGljYXRvclN0YWdlMicsXHJcbiAgICAgICAgICAgICAgICAgICAgZGF0YTogJ3N1Y2Nlc3MnXHJcbiAgICAgICAgICAgICAgICAgIH0pO1xyXG4gICAgICAgICAgICAgICAgICB0eENvbnRyb2xsZXJTdGF0ZVN0ZXBGb3J3YXJkKCk7XHJcbiAgICAgICAgICAgICAgICAgIGF3YWl0IHRvb2xCb3guYXN5bmNEZWxheShjb25maWcuc2VyaWFsLkFVVEhFTlRJQ0FUSU9OX0FOSU1BVElPTl9ERUxBWSk7XHJcbiAgICAgICAgICAgICAgICB9IGVsc2Uge1xyXG4gICAgICAgICAgICAgICAgICBjb25zb2xlLndhcm4oYGRldmljZUhhc2ggYW5kIGRldmljZUV4cGVjdGVkSGFzaCBkb250IG1hdGNoYCk7XHJcbiAgICAgICAgICAgICAgICAgIGNvbnNvbGUubG9nKHRvb2xCb3guZGVlcENsb25lKGF1dGhlbnRpY2F0b3IpKTtcclxuICAgICAgICAgICAgICAgICAgZmFpbGVkID0gdHJ1ZTtcclxuICAgICAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgICB9XHJcbiAgICAgICAgICAgIH0gZWxzZSB7XHJcbiAgICAgICAgICAgICAgaWYodHJ1ZSkge1xyXG4gICAgICAgICAgICAgICAgbGV0IHBhY2tldENsb25lID0gdG9vbEJveC5kZWVwQ2xvbmUocnhQYWNrZXQpO1xyXG4gICAgICAgICAgICAgICAgcGFja2V0Q2xvbmUuZGF0YVswXSA9IHRvb2xCb3guZ2V0RmllbGROYW1lQnlWYWx1ZShcclxuICAgICAgICAgICAgICAgICAgQ09NTUFORFMsXHJcbiAgICAgICAgICAgICAgICAgIHBhY2tldENsb25lLmRhdGFbMF0sXHJcbiAgICAgICAgICAgICAgICApO1xyXG4gICAgICAgICAgICAgICAgcGFja2V0Q2xvbmUuZGF0YVsxXSA9IHRvb2xCb3guZ2V0RmllbGROYW1lQnlWYWx1ZShcclxuICAgICAgICAgICAgICAgICAgUEFDS0VUX0VSUk9SX0NPREVTLFxyXG4gICAgICAgICAgICAgICAgICBwYWNrZXRDbG9uZS5kYXRhWzFdLFxyXG4gICAgICAgICAgICAgICAgKTtcclxuICAgICAgICAgICAgICAgIGNvbnNvbGUud2FybihwYWNrZXRDbG9uZSk7XHJcbiAgICAgICAgICAgICAgICBjb25zb2xlLndhcm4ocGFja2V0Q2xvbmUuZGF0YSk7XHJcbiAgICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICAgIGZhaWxlZCA9IHRydWU7XHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICAgIH0gZWxzZSB7XHJcbiAgICAgICAgICAgIGNvbnNvbGUud2FybihgQXV0aGVudGljYXRvcjogZGlkbid0IHJlY2VpdmUgXCJEZXZpY2UgSGFzaCBEYXRhXCJgKTtcclxuICAgICAgICAgICAgZmFpbGVkID0gdHJ1ZTtcclxuICAgICAgICAgIH1cclxuXHJcbiAgICAgICAgICBpZihmYWlsZWQpIHtcclxuICAgICAgICAgICAgdHhDb250cm9sbGVyLnN0YXRlU3RlcCA9IDA7XHJcblxyXG4gICAgICAgICAgICBzZXJpYWxUb1VpRXZlbnRDYWxsYmFjayh7XHJcbiAgICAgICAgICAgICAgbmFtZTogJ2F1dGhlbnRpY2F0b3JTdGFnZTInLFxyXG4gICAgICAgICAgICAgIGRhdGE6ICdmYWlsJ1xyXG4gICAgICAgICAgICB9KTtcclxuICAgICAgICAgICAgYXdhaXQgdG9vbEJveC5hc3luY0RlbGF5KGNvbmZpZy5zZXJpYWwuQVVUSEVOVElDQVRJT05fQU5JTUFUSU9OX0RFTEFZKTtcclxuICAgICAgICAgIH1cclxuICAgICAgICB9XHJcbiAgICAgICAgYnJlYWs7XHJcblxyXG4gICAgICAgIGNhc2UgNDogeyAvKiBUYWtlIEdVSSBQYXNzd29yZCBGcm9tIFVzZXIgKi9cclxuICAgICAgICAgIGF1dGhlbnRpY2F0b3IuZ3VpUGFzcyA9IG51bGw7XHJcbiAgICAgICAgICBcclxuICAgICAgICAgIHNlcmlhbFRvVWlFdmVudENhbGxiYWNrKHtcclxuICAgICAgICAgICAgbmFtZTogJ2F1dGhlbnRpY2F0b3JQYXNzd29yZCcsXHJcbiAgICAgICAgICAgIGRhdGE6ICdzdGFydCdcclxuICAgICAgICAgIH0pO1xyXG4gICAgICAgICAgYXdhaXQgdG9vbEJveC5hc3luY0RlbGF5KGNvbmZpZy5zZXJpYWwuQVVUSEVOVElDQVRJT05fQU5JTUFUSU9OX0RFTEFZKTtcclxuXHJcbiAgICAgICAgICB0eENvbnRyb2xsZXJTdGF0ZVN0ZXBGb3J3YXJkKCk7XHJcbiAgICAgICAgfVxyXG4gICAgICAgIGJyZWFrO1xyXG5cclxuICAgICAgICBjYXNlIDU6IHtcclxuICAgICAgICAgIC8qIEZvciBUZXN0aW5nIEJlZ2luIOKGkyAqKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqKiovXHJcbiAgICAgICAgICAgIGlmKGNvbmZpZy5zZXJpYWwuQVVUT19JTlNFUlRfR1VJX1BBU1NXT1JEX0FDVElWRSkge1xyXG4gICAgICAgICAgICAgIGF1dGhlbnRpY2F0b3IuZ3VpUGFzcyA9IGNvbmZpZy5zZXJpYWwuQVVUT19JTlNFUlRfR1VJX1BBU1NXT1JEX1ZBTFVFO1xyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgICAvKiBGb3IgVGVzdGluZyBFbmQgICDihpEgKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqL1xyXG5cclxuICAgICAgICAgIGlmKGF1dGhlbnRpY2F0b3IuZ3VpUGFzcyAhPT0gbnVsbCkge1xyXG4gICAgICAgICAgICBjb25zb2xlLmxvZyhgZ3VpUGFzcyA9ICR7YXV0aGVudGljYXRvci5ndWlQYXNzfWApO1xyXG5cclxuICAgICAgICAgICAgYXV0aGVudGljYXRvci5ndWlQYXNzID0gdG9vbEJveC5zdHJpbmdUb0FzY2lpQXJyYXkoYXV0aGVudGljYXRvci5ndWlQYXNzKTtcclxuICBcclxuICAgICAgICAgICAgdHhDb250cm9sbGVyU3RhdGVTdGVwRm9yd2FyZCgpO1xyXG4gICAgICAgICAgfVxyXG4gICAgICAgIH1cclxuICAgICAgICBicmVhaztcclxuXHJcbiAgICAgICAgY2FzZSA2OiB7IC8qIFNlbmQgR1VJIFBhc3MgdG8gRGV2aWNlICovXHJcbiAgICAgICAgICBsZXQgZmFpbGVkID0gZmFsc2U7XHJcblxyXG4gICAgICAgICAgc2VyaWFsVHguY3JlYXRlQW5kU2VuZFBhY2tldChcclxuICAgICAgICAgICAgQ09NTUFORFMuQVVUSEVOVElDQVRJT05fR1VJX1BBU1NXT1JELFxyXG4gICAgICAgICAgICBhdXRoZW50aWNhdG9yLmd1aVBhc3NcclxuICAgICAgICAgICk7XHJcblxyXG4gICAgICAgICAgYXdhaXQgcG9sbEZvclJ4UGFja2V0UmVhZHkoMzAwKTtcclxuXHJcbiAgICAgICAgICBpZihyeFBhY2tldC52YWxpZCkge1xyXG4gICAgICAgICAgICAvLyBjb25zb2xlLmxvZyhyeFBhY2tldCk7XHJcblxyXG4gICAgICAgICAgICBpZihyeFBhY2tldC5jb21tYW5kID09PSBDT01NQU5EUy5BQ0spIHtcclxuICAgICAgICAgICAgICBjb25zb2xlLmxvZyhcclxuICAgICAgICAgICAgICAgIGBBdXRoZW50aWNhdG9yOiBHVUkgUGFzc3dvcmQgQWNjZXB0ZWQgYnkgZGV2aWNlYFxyXG4gICAgICAgICAgICAgICk7XHJcbiAgICAgICAgICAgICAgXHJcbiAgICAgICAgICAgICAgYXV0aGVudGljYXRvci5zZXNzaW9uS2V5ID0gcGVyc29uYWxIYXNoLmNyZWF0ZUhhc2goW1xyXG4gICAgICAgICAgICAgICAgLi4udG9vbEJveC5zdHJpbmdUb0FzY2lpQXJyYXkoY29uZmlnLnNlcmlhbC5HVUlfQVVUSEVOVElDQVRJT05fSEFTSF9LRVkpLFxyXG4gICAgICAgICAgICAgICAgLi4uYXV0aGVudGljYXRvci5wY1JhbmRvbURhdGEsXHJcbiAgICAgICAgICAgICAgICAuLi5hdXRoZW50aWNhdG9yLmRldmljZVJhbmRvbURhdGEsXHJcbiAgICAgICAgICAgICAgICAuLi5hdXRoZW50aWNhdG9yLnBjVW5pcXVlSWQsXHJcbiAgICAgICAgICAgICAgICAuLi5hdXRoZW50aWNhdG9yLmRldmljZVVuaXF1ZUlkLFxyXG4gICAgICAgICAgICAgICAgLi4uYXV0aGVudGljYXRvci5ndWlQYXNzLFxyXG4gICAgICAgICAgICAgIF0pO1xyXG4gICAgICAgICAgICAgIFxyXG4gICAgICAgICAgICAgIGNvbnNvbGUubG9nKFxyXG4gICAgICAgICAgICAgICAgJyVjQXV0aGVudGljYXRpb24gU3VjY2Vzc2Z1bCcsXHJcbiAgICAgICAgICAgICAgICAnY29sb3I6YmxhY2s7IGJhY2tncm91bmQ6bGlnaHRncmVlbjsgZm9udC1zaXplOjJyZW07IHBhZGRpbmc6IC41cmVtOycsXHJcbiAgICAgICAgICAgICAgKTtcclxuICAgICAgICAgICAgICBcclxuICAgICAgICAgICAgICBjb25zb2xlLmxvZyhcclxuICAgICAgICAgICAgICAgIGAlY1Nlc3Npb25LZXk6ICR7dG9vbEJveC50b0hleFN0cmluZyhhdXRoZW50aWNhdG9yLnNlc3Npb25LZXksICcgJyl9YCxcclxuICAgICAgICAgICAgICAgICdjb2xvcjpibGFjazsgYmFja2dyb3VuZDpsaWdodGdyZWVuOyBmb250LXNpemU6MnJlbTsgcGFkZGluZzogLjVyZW07JyxcclxuICAgICAgICAgICAgICApO1xyXG5cclxuICAgICAgICAgICAgICBhdXRoZW50aWNhdG9yLnNlc3Npb25BY3RpdmUgPSB0cnVlO1xyXG4gICAgICAgICAgICAgIGF1dGhlbnRpY2F0b3Iuc2Vzc2lvblBhY2tldEZhaWxDb3VudGVyID0gMDtcclxuICAgICAgICAgICAgICB0eENvbnRyb2xsZXJTdGF0ZVN0ZXBGb3J3YXJkKCk7XHJcbiAgICAgICAgICAgICAgc2VyaWFsVG9VaUV2ZW50Q2FsbGJhY2soe1xyXG4gICAgICAgICAgICAgICAgbmFtZTogJ2F1dGhlbnRpY2F0b3JQYXNzd29yZCcsXHJcbiAgICAgICAgICAgICAgICBkYXRhOiAnc3VjY2VzcydcclxuICAgICAgICAgICAgICB9KTtcclxuICAgICAgICAgICAgICBhd2FpdCB0b29sQm94LmFzeW5jRGVsYXkoY29uZmlnLnNlcmlhbC5BVVRIRU5USUNBVElPTl9BTklNQVRJT05fREVMQVkpO1xyXG4gICAgICAgICAgICB9IGVsc2Uge1xyXG4gICAgICAgICAgICAgIGNvbnNvbGUud2FybihyeFBhY2tldCk7XHJcbiAgICAgICAgICAgICAgY29uc29sZS53YXJuKHJ4UGFja2V0LmRhdGEpO1xyXG4gICAgICAgICAgICAgIGZhaWxlZCA9IHRydWU7XHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICAgIH0gZWxzZSB7XHJcbiAgICAgICAgICAgIGNvbnNvbGUud2FybihgQXV0aGVudGljYXRvcjogZGlkbid0IHJlY2VpdmUgXCJEZXZpY2UgSGFzaCBEYXRhXCJgKTtcclxuICAgICAgICAgICAgZmFpbGVkID0gdHJ1ZTtcclxuICAgICAgICAgIH1cclxuXHJcbiAgICAgICAgICBpZihmYWlsZWQpIHtcclxuICAgICAgICAgICAgdHhDb250cm9sbGVyLnN0YXRlU3RlcCA9IDA7XHJcbiAgICAgICAgICBcclxuICAgICAgICAgICAgc2VyaWFsVG9VaUV2ZW50Q2FsbGJhY2soe1xyXG4gICAgICAgICAgICAgIG5hbWU6ICdhdXRoZW50aWNhdG9yUGFzc3dvcmQnLFxyXG4gICAgICAgICAgICAgIGRhdGE6ICdmYWlsJ1xyXG4gICAgICAgICAgICB9KTtcclxuICAgICAgICAgICAgYXdhaXQgdG9vbEJveC5hc3luY0RlbGF5KGNvbmZpZy5zZXJpYWwuQVVUSEVOVElDQVRJT05fQU5JTUFUSU9OX0RFTEFZKTtcclxuICAgICAgICAgIH1cclxuICAgICAgICB9XHJcbiAgICAgICAgYnJlYWs7XHJcblxyXG4gICAgICAgIGRlZmF1bHQ6IHtcclxuICAgICAgICAgIHNlcmlhbFRvVWlFdmVudENhbGxiYWNrKHtcclxuICAgICAgICAgICAgbmFtZTogJ2F1dGhlbnRpY2F0b3JTdG9wJyxcclxuICAgICAgICAgICAgZGF0YTogJydcclxuICAgICAgICAgIH0pO1xyXG5cclxuICAgICAgICAgIHR4Q29udHJvbGxlckdvVG9TdGF0ZSgnaWRsZScpO1xyXG4gICAgICAgIH1cclxuICAgICAgICBicmVhaztcclxuICAgICAgfVxyXG4gICAgfVxyXG4gICAgYnJlYWs7XHJcbiAgICBcclxuICAgIGNhc2UgJ3JlYWRCbGFja0xpc3QnOiB7XHJcbiAgICAgIGxldCBmYWlsZWQgPSBmYWxzZTtcclxuICAgICAgbGV0IGRldmljZUlkQmxhY2tMaXN0Qnl0ZXMgPSBbXTtcclxuXHJcbiAgICAgIGFzeW5jIGZ1bmN0aW9uIHNlbmRBbmRQb2xsRm9yTGlzdERhdGEgKFxyXG4gICAgICAgIGNvbW1hbmROYW1lLFxyXG4gICAgICAgIGRhdGEsXHJcbiAgICAgICAgbWF4VHJpZXMsXHJcbiAgICAgICAgcmVzcG9uc2VUaW1lPURFRkFVTFRfTUFYX1JFU1BPTlNFX1RJTUVcclxuICAgICAgKSB7XHJcbiAgICAgICAgd2hpbGUoMSkge1xyXG4gICAgICAgICAgbWF4VHJpZXMtLTtcclxuICAgICAgICAgIGlmKG1heFRyaWVzIDwgMCkge1xyXG4gICAgICAgICAgICBicmVhaztcclxuICAgICAgICAgIH1cclxuXHJcbiAgICAgICAgICBzZXJpYWxUeC5jcmVhdGVBbmRTZW5kUGFja2V0KFxyXG4gICAgICAgICAgICBDT01NQU5EU1tjb21tYW5kTmFtZV0sXHJcbiAgICAgICAgICAgIGRhdGEsXHJcbiAgICAgICAgICAgIGF1dGhlbnRpY2F0b3Iuc2Vzc2lvbktleVxyXG4gICAgICAgICAgKTtcclxuICAgICAgICAgIFxyXG4gICAgICAgICAgYXdhaXQgcG9sbEZvclJ4UGFja2V0UmVhZHkocmVzcG9uc2VUaW1lKTtcclxuXHJcbiAgICAgICAgICBpZihyeFBhY2tldC52YWxpZCkge1xyXG4gICAgICAgICAgICBpZihyeFBhY2tldC5jb21tYW5kID09PSBDT01NQU5EUy5SRUFEX0ZST01fQkxBQ0tfTElTVCkge1xyXG4gICAgICAgICAgICAgIGJyZWFrO1xyXG4gICAgICAgICAgICB9IGVsc2UgaWYocnhQYWNrZXQuY29tbWFuZCA9PT0gQ09NTUFORFMuTkFDSykge1xyXG4gICAgICAgICAgICAgIGNvbnNvbGUud2FybihgRXhwZWN0ZWQgJHtDT01NQU5EUy5BQ0t9IGFmdGVyICR7Y29tbWFuZE5hbWV9IHBhY2tldCwgYnV0IHJlY2VpdmVkIE5BQ0sgd2l0aCBkYXRhOiAke3Rvb2xCb3gudG9IZXhTdHJpbmcocnhQYWNrZXQuZGF0YSwgJyAnKX1gKTtcclxuICAgICAgICAgICAgfSBlbHNlIHtcclxuICAgICAgICAgICAgICBjb25zb2xlLndhcm4oYEV4cGVjdGVkICR7Q09NTUFORFMuQUNLfSBhZnRlciAke2NvbW1hbmROYW1lfSBwYWNrZXQsIGJ1dCByZWNlaXZlZCAke3J4UGFja2V0LmNvbW1hbmR9YCk7XHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICAgIH0gZWxzZSB7XHJcbiAgICAgICAgICAgIGNvbnNvbGUud2FybihgRGlkbid0IHJlY2VpdmUgcmVzcG9uc2UgdG8gJHtjb21tYW5kTmFtZX0gcGFja2V0YCk7XHJcbiAgICAgICAgICB9XHJcbiAgICAgICAgfVxyXG5cclxuICAgICAgICBpZihtYXhUcmllcyA8IDApIHtcclxuICAgICAgICAgIHJldHVybiAnZmFpbCdcclxuICAgICAgICB9IGVsc2Uge1xyXG4gICAgICAgICAgcmV0dXJuICdzdWNjZXNzJ1xyXG4gICAgICAgIH1cclxuICAgICAgfVxyXG4gICAgICBcclxuICAgICAgbGV0IGRldmljZUlkQmxhY2tMaXN0TGVuZ3RoID0gYXBwUGFyYW1zLnNldHRpbmcuZGV2aWNlSWRCbGFja0xpc3RMZW5ndGg7XHJcbiAgICAgIGxldCBibGFja0xpc3RJbmRleCA9IDA7XHJcblxyXG4gICAgICBpZihkZXZpY2VJZEJsYWNrTGlzdExlbmd0aCA9PT0gMCkge1xyXG4gICAgICAgIHBvcFVwTWVzc2FnZS5kaXNwbGF5UG9wVXAoXHJcbiAgICAgICAgICAn2YTbjNiz2Kog2LPbjNin2Ycg2LHZhdiy2qnZhtmG2K/ZhyDYrtin2YTbjCDYp9iz2KonLFxyXG4gICAgICAgICAgJ1JFRCcsXHJcbiAgICAgICAgKTtcclxuXHJcbiAgICAgICAgdHhDb250cm9sbGVyR29Ub1N0YXRlKCdpZGxlJyk7XHJcbiAgICAgICAgaW5zdGFudFJlUnVuKCk7XHJcbiAgICAgICAgYnJlYWs7XHJcbiAgICAgIH1cclxuXHJcbiAgICAgIC8vIGFwcFBhcmFtcy5zZXR0aW5nQnVsay5kZXZpY2VJZEJsYWNrTGlzdFxyXG4gICAgICB3aGlsZShkZXZpY2VJZEJsYWNrTGlzdExlbmd0aCkge1xyXG4gICAgICAgIGxldCByZWFkU2l6ZSA9IDEwMDtcclxuICAgICAgICBpZihkZXZpY2VJZEJsYWNrTGlzdExlbmd0aCA8IHJlYWRTaXplKSB7XHJcbiAgICAgICAgICByZWFkU2l6ZSA9IGRldmljZUlkQmxhY2tMaXN0TGVuZ3RoO1xyXG4gICAgICAgIH1cclxuXHJcbiAgICAgICAgbGV0IHhmZXJSZXN1bHQgPSBhd2FpdCBzZW5kQW5kUG9sbEZvckxpc3REYXRhKFxyXG4gICAgICAgICAgJ1JFQURfRlJPTV9CTEFDS19MSVNUJyxcclxuICAgICAgICAgIFtcclxuICAgICAgICAgICAgLi4udG9vbEJveC5pbnRUb0FycmF5KGJsYWNrTGlzdEluZGV4LCA0LCBmYWxzZSksXHJcbiAgICAgICAgICAgIC4uLnRvb2xCb3guaW50VG9BcnJheShyZWFkU2l6ZSwgNCwgZmFsc2UpLFxyXG4gICAgICAgICAgXSxcclxuICAgICAgICAgIDNcclxuICAgICAgICApO1xyXG5cclxuICAgICAgICBpZih4ZmVyUmVzdWx0ID09PSAnZmFpbCcpIHtcclxuICAgICAgICAgIGZhaWxlZCA9IHRydWU7XHJcbiAgICAgICAgICBicmVhaztcclxuICAgICAgICB9IGVsc2Uge1xyXG4gICAgICAgICAgZGV2aWNlSWRCbGFja0xpc3RCeXRlcy5wdXNoKC4uLnJ4UGFja2V0LmRhdGEpO1xyXG4gICAgICAgICAgXHJcbiAgICAgICAgICBkZXZpY2VJZEJsYWNrTGlzdExlbmd0aCAtPSByZWFkU2l6ZTtcclxuICAgICAgICAgIGJsYWNrTGlzdEluZGV4ICs9IHJlYWRTaXplO1xyXG4gICAgICAgIH1cclxuICAgICAgfVxyXG5cclxuICAgICAgaWYoIWZhaWxlZCkge1xyXG4gICAgICAgIGFwcFBhcmFtcy5zZXR0aW5nQnVsay5kZXZpY2VJZEJsYWNrTGlzdCA9IFtdXHJcblxyXG4gICAgICAgIGNvbnNvbGUubG9nKGRldmljZUlkQmxhY2tMaXN0Qnl0ZXMpO1xyXG5cclxuICAgICAgICB3aGlsZShkZXZpY2VJZEJsYWNrTGlzdEJ5dGVzLmxlbmd0aCkge1xyXG4gICAgICAgICAgYXBwUGFyYW1zLnNldHRpbmdCdWxrLmRldmljZUlkQmxhY2tMaXN0LnB1c2goXHJcbiAgICAgICAgICAgIHRvb2xCb3guYXJyYXlUb0ludChkZXZpY2VJZEJsYWNrTGlzdEJ5dGVzLnNwbGljZSgwLCAyKSlcclxuICAgICAgICAgICk7XHJcbiAgICAgICAgfVxyXG5cclxuICAgICAgICBjb25zb2xlLmxvZyhhcHBQYXJhbXMuc2V0dGluZ0J1bGsuZGV2aWNlSWRCbGFja0xpc3QpO1xyXG5cclxuICAgICAgICBhcHBQYXJhbXMuc2V0dGluZ0J1bGsuZGV2aWNlSWRCbGFja0xpc3QgPVxyXG4gICAgICAgICAgYXBwUGFyYW1zLnNldHRpbmdCdWxrLmRldmljZUlkQmxhY2tMaXN0Lm1hcCgobnVtKSA9PiB7XHJcbiAgICAgICAgICAgIHJldHVybiB0b29sQm94LnRvSGV4U3RyaW5nKHRvb2xCb3guaW50VG9BcnJheShudW0sIDIsIGZhbHNlLCBmYWxzZSkpO1xyXG4gICAgICAgICAgfSk7XHJcblxyXG4gICAgICAgIGNvbnNvbGUubG9nKGFwcFBhcmFtcy5zZXR0aW5nQnVsay5kZXZpY2VJZEJsYWNrTGlzdCk7XHJcblxyXG4gICAgICAgIGV4cG9ydEJsYWNrTGlzdEV4Y2VsbChhcHBQYXJhbXMuc2V0dGluZ0J1bGsuZGV2aWNlSWRCbGFja0xpc3QpO1xyXG4gICAgICB9IGVsc2Uge1xyXG4gICAgICAgIHBvcFVwTWVzc2FnZS5kaXNwbGF5UG9wVXAoXHJcbiAgICAgICAgICAn2YLYsdin2KbYqiDZhNuM2LPYqiDYs9uM2KfZhyDYp9mG2KzYp9mFINmG2LTYrycsXHJcbiAgICAgICAgICAnUkVEJyxcclxuICAgICAgICApO1xyXG4gICAgICB9XHJcblxyXG4gICAgICB0eENvbnRyb2xsZXJHb1RvU3RhdGUoJ2lkbGUnKTtcclxuICAgIH1cclxuICAgIGJyZWFrO1xyXG5cclxuICAgIGNhc2UgJ3dyaXRlQmxhY2tMaXN0Jzoge1xyXG4gICAgICBsZXQgbGlzdCA9IHRvb2xCb3guZGVlcENvcHkodWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LnJlcXVlc3REYXRhKTtcclxuICAgICAgbGV0IGZhaWxlZCA9IGZhbHNlO1xyXG5cclxuICAgICAgZnVuY3Rpb24gZXh0cmFjdEZyb21MaXN0IChudW1PZklkcykge1xyXG4gICAgICAgIHJldHVybiBsaXN0LnNwbGljZSgwLCBudW1PZklkcyk7XHJcbiAgICAgIH1cclxuXHJcbiAgICAgIGFzeW5jIGZ1bmN0aW9uIHNlbmRBbmRQb2xsRm9yQWNrIChcclxuICAgICAgICBjb21tYW5kTmFtZSxcclxuICAgICAgICBkYXRhLFxyXG4gICAgICAgIG1heFRyaWVzLFxyXG4gICAgICAgIHJlc3BvbnNlVGltZT1ERUZBVUxUX01BWF9SRVNQT05TRV9USU1FXHJcbiAgICAgICkge1xyXG4gICAgICAgIHdoaWxlKDEpIHtcclxuICAgICAgICAgIG1heFRyaWVzLS07XHJcbiAgICAgICAgICBpZihtYXhUcmllcyA8IDApIHtcclxuICAgICAgICAgICAgYnJlYWs7XHJcbiAgICAgICAgICB9XHJcblxyXG4gICAgICAgICAgc2VyaWFsVHguY3JlYXRlQW5kU2VuZFBhY2tldChcclxuICAgICAgICAgICAgQ09NTUFORFNbY29tbWFuZE5hbWVdLFxyXG4gICAgICAgICAgICBkYXRhLFxyXG4gICAgICAgICAgICBhdXRoZW50aWNhdG9yLnNlc3Npb25LZXlcclxuICAgICAgICAgICk7XHJcbiAgICAgICAgICBcclxuICAgICAgICAgIGF3YWl0IHBvbGxGb3JSeFBhY2tldFJlYWR5KHJlc3BvbnNlVGltZSk7XHJcblxyXG4gICAgICAgICAgaWYocnhQYWNrZXQudmFsaWQpIHtcclxuICAgICAgICAgICAgaWYocnhQYWNrZXQuY29tbWFuZCA9PT0gQ09NTUFORFMuQUNLKSB7XHJcbiAgICAgICAgICAgICAgYnJlYWs7XHJcbiAgICAgICAgICAgIH0gZWxzZSBpZihyeFBhY2tldC5jb21tYW5kID09PSBDT01NQU5EUy5OQUNLKSB7XHJcbiAgICAgICAgICAgICAgY29uc29sZS53YXJuKGBFeHBlY3RlZCAke0NPTU1BTkRTLkFDS30gYWZ0ZXIgJHtjb21tYW5kTmFtZX0gcGFja2V0LCBidXQgcmVjZWl2ZWQgTkFDSyB3aXRoIGRhdGE6ICR7dG9vbEJveC50b0hleFN0cmluZyhyeFBhY2tldC5kYXRhLCAnICcpfWApO1xyXG4gICAgICAgICAgICB9IGVsc2Uge1xyXG4gICAgICAgICAgICAgIGNvbnNvbGUud2FybihgRXhwZWN0ZWQgJHtDT01NQU5EUy5BQ0t9IGFmdGVyICR7Y29tbWFuZE5hbWV9IHBhY2tldCwgYnV0IHJlY2VpdmVkICR7cnhQYWNrZXQuY29tbWFuZH1gKTtcclxuICAgICAgICAgICAgfVxyXG4gICAgICAgICAgfSBlbHNlIHtcclxuICAgICAgICAgICAgY29uc29sZS53YXJuKGBEaWRuJ3QgcmVjZWl2ZSBhY2sgcmVzcG9uc2UgdG8gJHtjb21tYW5kTmFtZX0gcGFja2V0YCk7XHJcbiAgICAgICAgICB9XHJcbiAgICAgICAgfVxyXG5cclxuICAgICAgICBpZihtYXhUcmllcyA8IDApIHtcclxuICAgICAgICAgIHJldHVybiAnZmFpbCdcclxuICAgICAgICB9IGVsc2Uge1xyXG4gICAgICAgICAgcmV0dXJuICdzdWNjZXNzJ1xyXG4gICAgICAgIH1cclxuICAgICAgfVxyXG5cclxuICAgICAgbGV0IHhmZXJSZXN1bHQgPSBhd2FpdCBzZW5kQW5kUG9sbEZvckFjayhcclxuICAgICAgICAnRVJBU0VfQkxBQ0tfTElTVF9GUk9NX1JBTScsXHJcbiAgICAgICAgW10sXHJcbiAgICAgICAgMyxcclxuICAgICAgICAxMDAwXHJcbiAgICAgICk7XHJcblxyXG4gICAgICBpZih4ZmVyUmVzdWx0ID09PSAnZmFpbCcpIHtcclxuICAgICAgICBmYWlsZWQgPSB0cnVlO1xyXG4gICAgICB9XHJcblxyXG4gICAgICBpZighZmFpbGVkKSB7XHJcbiAgICAgICAgd2hpbGUobGlzdC5sZW5ndGggIT09IDApIHtcclxuICAgICAgICAgIGxldCBzdWJMaXN0ID0gZXh0cmFjdEZyb21MaXN0KDEwMCk7XHJcbiAgICAgICAgICBsZXQgc3ViTGlzdEJ5dGVzID0gW107XHJcblxyXG4gICAgICAgICAgZm9yKGxldCBpID0gMDsgaSA8IHN1Ykxpc3QubGVuZ3RoOyBpKyspIHtcclxuICAgICAgICAgICAgbGV0IGRldmljZUlkQnl0ZXMgPSB0b29sQm94LmludFRvQXJyYXkoc3ViTGlzdFtpXSwgMiwgZmFsc2UsIHRydWUpO1xyXG4gICAgICAgICAgICBzdWJMaXN0Qnl0ZXMucHVzaCguLi5kZXZpY2VJZEJ5dGVzKTtcclxuICAgICAgICAgIH1cclxuXHJcbiAgICAgICAgICAvLyBjb25zb2xlLmxvZygnc3ViTGlzdCcpO1xyXG4gICAgICAgICAgLy8gY29uc29sZS5sb2coc3ViTGlzdCk7XHJcblxyXG4gICAgICAgICAgLy8gY29uc29sZS5sb2coJ3N1Ykxpc3RCeXRlcycpO1xyXG4gICAgICAgICAgLy8gY29uc29sZS5sb2coc3ViTGlzdEJ5dGVzKTtcclxuXHJcbiAgICAgICAgICBsZXQgeGZlclJlc3VsdCA9IGF3YWl0IHNlbmRBbmRQb2xsRm9yQWNrKFxyXG4gICAgICAgICAgICAnQUREX1RPX0JMQUNLX0xJU1RfSU5fUkFNJyxcclxuICAgICAgICAgICAgc3ViTGlzdEJ5dGVzLFxyXG4gICAgICAgICAgICAzXHJcbiAgICAgICAgICApO1xyXG5cclxuICAgICAgICAgIGlmKHhmZXJSZXN1bHQgPT09ICdmYWlsJykge1xyXG4gICAgICAgICAgICBmYWlsZWQgPSB0cnVlO1xyXG4gICAgICAgICAgICBicmVhaztcclxuICAgICAgICAgIH1cclxuICAgICAgICB9XHJcbiAgICAgIH1cclxuXHJcbiAgICAgIGlmKCFmYWlsZWQpIHtcclxuICAgICAgICBsZXQgeGZlclJlc3VsdCA9IGF3YWl0IHNlbmRBbmRQb2xsRm9yQWNrKFxyXG4gICAgICAgICAgJ1dSSVRFX0JMQUNLX0xJU1RfVE9fRkxBU0gnLFxyXG4gICAgICAgICAgW10sXHJcbiAgICAgICAgICAzLFxyXG4gICAgICAgICAgMTAwMFxyXG4gICAgICAgICk7XHJcblxyXG4gICAgICAgIGlmKHhmZXJSZXN1bHQgPT09ICdmYWlsJykge1xyXG4gICAgICAgICAgZmFpbGVkID0gdHJ1ZTtcclxuICAgICAgICB9XHJcbiAgICAgIH1cclxuXHJcbiAgICAgIGlmKGZhaWxlZCkge1xyXG4gICAgICAgIHBvcFVwTWVzc2FnZS5kaXNwbGF5UG9wVXAoXHJcbiAgICAgICAgICAn2KrYstix24zZgiDZhNuM2LPYqiDYs9uM2KfZhyDYp9mG2KzYp9mFINmG2LTYrycsXHJcbiAgICAgICAgICAnUkVEJyxcclxuICAgICAgICApO1xyXG4gICAgICB9IGVsc2Uge1xyXG4gICAgICAgIHBvcFVwTWVzc2FnZS5kaXNwbGF5UG9wVXAoXHJcbiAgICAgICAgICAn2YTbjNiz2Kog2LPbjNin2Ycg2KrYstix24zZgiDYtNivJyxcclxuICAgICAgICAgICdHUkVFTicsXHJcbiAgICAgICAgKTtcclxuICAgICAgfVxyXG5cclxuICAgICAgdHhDb250cm9sbGVyR29Ub1N0YXRlKCdpZGxlJyk7XHJcbiAgICB9XHJcbiAgICBicmVhaztcclxuXHJcbiAgICBjYXNlICdyZXF1ZXN0U3RhdHVzJzoge1xyXG4gICAgICBzZXJpYWxUeC5jcmVhdGVBbmRTZW5kUGFja2V0KFxyXG4gICAgICAgIENPTU1BTkRTLlJFUVVFU1RfU1RBVFVTLFxyXG4gICAgICAgIFtdLFxyXG4gICAgICAgIGF1dGhlbnRpY2F0b3Iuc2Vzc2lvbktleVxyXG4gICAgICApO1xyXG5cclxuICAgICAgYXdhaXQgcG9sbEZvclJ4UGFja2V0UmVhZHkoMzAwKTtcclxuXHJcbiAgICAgIGlmKHJ4UGFja2V0LnZhbGlkKSB7XHJcbiAgICAgICAgc3dpdGNoKHJ4UGFja2V0LmNvbW1hbmQpIHtcclxuICAgICAgICAgIGNhc2UgQ09NTUFORFMuUkVRVUVTVF9TVEFUVVM6IHtcclxuICAgICAgICAgICAgaGFuZGxlUmVxdWVzdFVwZGF0ZVBhY2tldERhdGEocnhQYWNrZXQuZGF0YSk7XHJcbiAgICAgICAgICAgIGhhbmRsZURldmljZVJlc3BvbmRpbmcoKTtcclxuICAgICAgICAgICAgdHhDb250cm9sbGVyR29Ub1N0YXRlKCdpZGxlJyk7XHJcbiAgICAgICAgICB9XHJcbiAgICAgICAgICBicmVhaztcclxuXHJcbiAgICAgICAgICBkZWZhdWx0OiB7XHJcbiAgICAgICAgICAgIGNvbnNvbGUud2FybihgRXhwZWN0ZWQgJHtDT01NQU5EUy5SRVFVRVNUX1NUQVRVU30sIGJ1dCByZWNlaXZlZCAke3J4UGFja2V0LmNvbW1hbmR9YCk7XHJcbiAgICAgICAgICAgIHR4Q29udHJvbGxlckdvVG9TdGF0ZSgnaWRsZScpO1xyXG4gICAgICAgICAgfVxyXG4gICAgICAgICAgYnJlYWs7XHJcbiAgICAgICAgfVxyXG4gICAgICB9IGVsc2Uge1xyXG4gICAgICAgIGNvbnNvbGUud2FybihgRGlkbid0IHJlY2VpdmUgcmVxdWVzdFN0YXR1cyByZXNwb25zZWApO1xyXG4gICAgICAgIHR4Q29udHJvbGxlckdvVG9TdGF0ZSgnaWRsZScpO1xyXG4gICAgICAgIGhhbmRsZURldmljZU5vdFJlc3BvbmRpbmcoKTtcclxuICAgICAgfVxyXG4gICAgfVxyXG4gICAgYnJlYWs7XHJcbiAgfVxyXG5cclxuICBpZighaW5zdGFudFJlUnVuUmVxdWVzdEZsYWcpIHtcclxuICAgIGF3YWl0IHRvb2xCb3guYXN5bmNEZWxheShydW5JbnRlcnZhbCk7XHJcbiAgfVxyXG4gIFxyXG4gIHR4Q29udHJvbFJ1bigpO1xyXG59XHJcblxyXG5mdW5jdGlvbiBoYW5kbGVEZXZpY2VOb3RSZXNwb25kaW5nICgpIHtcclxuICBhdXRoZW50aWNhdG9yLmRldmljZU5vdFJlc3BvbmRpbmdDb3VudGVyKytcclxuICBpZihhdXRoZW50aWNhdG9yLmRldmljZU5vdFJlc3BvbmRpbmdDb3VudGVyID09PSAzKSB7XHJcbiAgICB0ZXJtaW5hdGVTZXNzaW9uKCk7XHJcbiAgfVxyXG59XHJcblxyXG5mdW5jdGlvbiBoYW5kbGVEZXZpY2VSZXNwb25kaW5nICgpIHtcclxuICBpZihhdXRoZW50aWNhdG9yLmRldmljZU5vdFJlc3BvbmRpbmdDb3VudGVyICE9PSAwKSB7XHJcbiAgICBhdXRoZW50aWNhdG9yLmRldmljZU5vdFJlc3BvbmRpbmdDb3VudGVyLS07XHJcbiAgfVxyXG59XHJcblxyXG5mdW5jdGlvbiBoYW5kbGVSZXF1ZXN0VXBkYXRlUGFja2V0RGF0YSAoc3RhdHVzRGF0YSkge1xyXG4gICAgbGV0IGJ5dGVzID0gWy4uLnN0YXR1c0RhdGFdO1xyXG4gIFxyXG4gICAgLy8gY29uc29sZS5sb2coJ2J5dGVzJyk7XHJcbiAgICAvLyBjb25zb2xlLmxvZyhieXRlcyk7XHJcblxyXG4gICAgY29uc3QgZXh0cmFjdEJ5dGVzID0gKG51bU9mQnl0ZXMpID0+IHtcclxuICAgICAgcmV0dXJuIGJ5dGVzLnNwbGljZSgwLCBudW1PZkJ5dGVzKTtcclxuICAgIH1cclxuICAgIGNvbnN0IGV4dHJhY3RVMzIgPSAoKSA9PiB7XHJcbiAgICAgIHJldHVybiB0b29sQm94LmFycmF5VG9JbnQoZXh0cmFjdEJ5dGVzKDQpLCBmYWxzZSk7XHJcbiAgICB9XHJcbiAgICBjb25zdCBleHRyYWN0VTMyQXJyYXkgPSAobnVtT2ZVMzJzKSA9PiB7XHJcbiAgICAgIGxldCByZXN1bHQgPSBbXTtcclxuICAgICAgZm9yKGxldCBpID0gMDsgaSA8IG51bU9mVTMyczsgaSsrKSB7XHJcbiAgICAgICAgcmVzdWx0LnB1c2goZXh0cmFjdFUzMigpKTtcclxuICAgICAgfVxyXG4gICAgICByZXR1cm4gcmVzdWx0O1xyXG4gICAgfVxyXG4gICAgY29uc3QgZXh0cmFjdEkzMiA9ICgpID0+IHtcclxuICAgICAgcmV0dXJuIHRvb2xCb3guYXJyYXlUb0ludChleHRyYWN0Qnl0ZXMoNCksIHRydWUpO1xyXG4gICAgfVxyXG4gICAgY29uc3QgZXh0cmFjdFUxNiA9ICgpID0+IHtcclxuICAgICAgcmV0dXJuIHRvb2xCb3guYXJyYXlUb0ludChleHRyYWN0Qnl0ZXMoMiksIGZhbHNlKTtcclxuICAgIH1cclxuICAgIGNvbnN0IGV4dHJhY3RJMTYgPSAoKSA9PiB7XHJcbiAgICAgIHJldHVybiB0b29sQm94LmFycmF5VG9JbnQoZXh0cmFjdEJ5dGVzKDIpLCB0cnVlKTtcclxuICAgIH1cclxuICAgIGNvbnN0IGV4dHJhY3RVOCA9ICgpID0+IHtcclxuICAgICAgcmV0dXJuIHRvb2xCb3guYXJyYXlUb0ludChleHRyYWN0Qnl0ZXMoMSksIGZhbHNlKTtcclxuICAgIH1cclxuICAgIGNvbnN0IGV4dHJhY3RVOEFycmF5ID0gKG51bU9mVThzKSA9PiB7XHJcbiAgICAgIGxldCByZXN1bHQgPSBbXTtcclxuICAgICAgZm9yKGxldCBpID0gMDsgaSA8IG51bU9mVThzOyBpKyspIHtcclxuICAgICAgICByZXN1bHQucHVzaChleHRyYWN0VTgoKSk7XHJcbiAgICAgIH1cclxuICAgICAgcmV0dXJuIHJlc3VsdDtcclxuICAgIH1cclxuICAgIGNvbnN0IGV4dHJhY3RJOCA9ICgpID0+IHtcclxuICAgICAgcmV0dXJuIHRvb2xCb3guYXJyYXlUb0ludChleHRyYWN0Qnl0ZXMoMSksIHRydWUpO1xyXG4gICAgfVxyXG4gICAgY29uc3QgZXh0cmFjdEZsb2F0ID0gKCkgPT4ge1xyXG4gICAgICByZXR1cm4gdG9vbEJveC5hcnJheTRUb0Zsb2F0MzIoZXh0cmFjdEJ5dGVzKDQpLCB0cnVlKTtcclxuICAgIH1cclxuICAgIGNvbnN0IGV4dHJhY3REb3VibGUgPSAoKSA9PiB7XHJcbiAgICAgIHJldHVybiB0b29sQm94LmFycmF5OFRvRmxvYXQ2NChleHRyYWN0Qnl0ZXMoOCksIHRydWUpO1xyXG4gICAgfVxyXG4gICAgY29uc3QgZXh0cmFjdER1bW15Qnl0ZXMgPSAobnVtT2ZCeXRlcykgPT4ge1xyXG4gICAgICBleHRyYWN0Qnl0ZXMobnVtT2ZCeXRlcyk7XHJcbiAgICB9XHJcblxyXG4gICAgYXBwUGFyYW1zLnN0YXR1cyA9IHt9O1xyXG4gICAgYXBwUGFyYW1zLnNldHRpbmcgPSB7fTtcclxuXHJcbiAgICAvKiBhcHBTdGF0dXMgQmVnaW4g4oaTICoqKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqKi9cclxuICAgICAgYXBwUGFyYW1zLnN0YXR1cy5ydGNCYXR0ZXJ5Vm9sdGFnZSA9IGV4dHJhY3RGbG9hdCgpO1xyXG4gICAgICBhcHBQYXJhbXMuc3RhdHVzLnJ0Y0RhdGFBcnJheSA9IGV4dHJhY3RVOEFycmF5KDYpO1xyXG4gICAgICBhcHBQYXJhbXMuc3RhdHVzLnJ0Y0RhdGFBcnJheVswXSArPSAyMDAwO1xyXG4gICAgICBhcHBQYXJhbXMuc3RhdHVzLmtleUJhbmtNYWluSW5pdGlhbFNlZWRMZW5ndGggPSBleHRyYWN0VTMyKCk7XHJcbiAgICAgIGFwcFBhcmFtcy5zdGF0dXMua2V5QmFua01haW5Jbml0aWFsU2VlZCA9IGV4dHJhY3RVOEFycmF5KGFwcFBhcmFtcy5zdGF0dXMua2V5QmFua01haW5Jbml0aWFsU2VlZExlbmd0aCk7XHJcbiAgICAgIGFwcFBhcmFtcy5zdGF0dXMua2V5QmFua0JhY2t1cEluaXRpYWxTZWVkTGVuZ3RoID0gZXh0cmFjdFUzMigpO1xyXG4gICAgICBhcHBQYXJhbXMuc3RhdHVzLmtleUJhbmtCYWNrdXBJbml0aWFsU2VlZCA9IGV4dHJhY3RVOEFycmF5KGFwcFBhcmFtcy5zdGF0dXMua2V5QmFua0JhY2t1cEluaXRpYWxTZWVkTGVuZ3RoKTtcclxuICAgICAgYXBwUGFyYW1zLnN0YXR1cy50ZXN0S3NzU3RyZWFtR2VuZXJhdGlvblJ1bm5pbmcgPSBleHRyYWN0VTgoKTtcclxuICAgIC8qIGFwcFN0YXR1cyBFbmQgICDihpEgKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqL1xyXG4gICAgLyogYXBwU2V0dGluZyBCZWdpbiDihpMgKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqL1xyXG4gICAgICBhcHBQYXJhbXMuc2V0dGluZy5idXp6ZXJWb2x1bWVQZXJjZW50ID0gZXh0cmFjdFU4KCk7XHJcbiAgICAgIGFwcFBhcmFtcy5zZXR0aW5nLmRldmljZVdvcmtpbmdNb2RlID0gZXh0cmFjdFU4KCk7XHJcbiAgICAgIGFwcFBhcmFtcy5zZXR0aW5nLmRldmljZUlkID0gZXh0cmFjdFUxNigyKTtcclxuICAgICAgYXBwUGFyYW1zLnNldHRpbmcuZGV2aWNlSWRMZW5ndGggPSBleHRyYWN0VTgoKTtcclxuICAgICAgYXBwUGFyYW1zLnNldHRpbmcucmVtb3RlRGlzY2hhcmdlTWVzc2FnZSA9IGV4dHJhY3RVOEFycmF5KDYpO1xyXG4gICAgICBhcHBQYXJhbXMuc2V0dGluZy5ibGFja0xpc3RCeXBhc3MgPSBleHRyYWN0VTgoKTtcclxuICAgICAgYXBwUGFyYW1zLnNldHRpbmcuc2VsZWN0ZWRLZXlCYW5rID0gZXh0cmFjdFU4KCk7XHJcbiAgICAgIGFwcFBhcmFtcy5zZXR0aW5nLmNhc2VPcGVuRXZlbnRBY3Rpb24gPSBleHRyYWN0VTgoKTtcclxuICAgICAgYXBwUGFyYW1zLnNldHRpbmcucmVtb3RlRGlzY2hhcmdlRW5hYmxlID0gZXh0cmFjdFU4KCk7XHJcbiAgICAgIGFwcFBhcmFtcy5zZXR0aW5nLmRlY1BvcnRSeEJhdWRSYXRlID0gZXh0cmFjdFUzMigpO1xyXG4gICAgICBhcHBQYXJhbXMuc2V0dGluZy5kZWNQb3J0VHhCYXVkUmF0ZSA9IGV4dHJhY3RVMzIoKTtcclxuICAgICAgYXBwUGFyYW1zLnNldHRpbmcuZW5jUG9ydFJ4QmF1ZFJhdGUgPSBleHRyYWN0VTMyKCk7XHJcbiAgICAgIGFwcFBhcmFtcy5zZXR0aW5nLmVuY1BvcnRUeEJhdWRSYXRlID0gZXh0cmFjdFUzMigpO1xyXG4gICAgICBhcHBQYXJhbXMuc2V0dGluZy5ydGNQYWNrZXRTZWN0aW9uRW5hYmxlZCA9IGV4dHJhY3RVOCgpO1xyXG4gICAgICBhcHBQYXJhbXMuc2V0dGluZy5tYXhpbXVtVmFsaWRSdGNUaW1lRGlmZmVyZW5jZSA9IGV4dHJhY3RVMzIoKTtcclxuICAgICAgYXBwUGFyYW1zLnNldHRpbmcuZGVjcnlwdGVkUG9ydFJ4VGltZW91dE1zID0gZXh0cmFjdFUzMigpO1xyXG4gICAgICBhcHBQYXJhbXMuc2V0dGluZy5lbmNyeXB0ZWRQb3J0UnhUaW1lb3V0TXMgPSBleHRyYWN0VTMyKCk7XHJcbiAgICAgIGFwcFBhcmFtcy5zZXR0aW5nLmVuY3J5cHRlZFBhY2tldE1heERhdGFMZW5ndGggPSBleHRyYWN0VTMyKCk7XHJcbiAgICAgIGFwcFBhcmFtcy5zZXR0aW5nLmRldmljZUlkQmxhY2tMaXN0TGVuZ3RoID0gZXh0cmFjdFUzMigpO1xyXG4gICAgICBhcHBQYXJhbXMuc2V0dGluZy5lbmNyeXB0ZWRQYWNrZXRIZWFkZXJTaXplID0gZXh0cmFjdFU4KCk7XHJcbiAgICAgIGFwcFBhcmFtcy5zZXR0aW5nLmVuY3J5cHRlZFBhY2tldEhlYWRlciA9IGV4dHJhY3RVOEFycmF5KGFwcFBhcmFtcy5zZXR0aW5nLmVuY3J5cHRlZFBhY2tldEhlYWRlclNpemUpO1xyXG4gICAgLyogYXBwU2V0dGluZyBFbmQgICDihpEgKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqL1xyXG4gIFxyXG4gICAgaWYoZmFsc2UpeyBcclxuICAgICAgaWYoYnl0ZXMubGVuZ3RoICE9PSAwKSB7XHJcbiAgICAgICAgY29uc29sZS53YXJuKCdSZXNpZHVhbDogJywgYnl0ZXMubGVuZ3RoLCBieXRlcyk7XHJcbiAgICAgIH1cclxuICAgIH1cclxuXHJcbiAgICBzZXJpYWxUb1VpRXZlbnRDYWxsYmFjayh7XHJcbiAgICAgIG5hbWU6ICdhcHBQYXJhbWV0ZXJzVXBkYXRlJyxcclxuICAgICAgZGF0YTogYXBwUGFyYW1zXHJcbiAgICB9KTtcclxufVxyXG5cclxuZnVuY3Rpb24gcGFja2V0UmVjZWl2ZUV2ZW50IChjb21tYW5kLCBkYXRhKSB7XHJcbiAgLy8gY29uc29sZS5sb2coYHBhY2tldFJlY2VpdmVFdmVudCAoJHt0b29sQm94LnRvSGV4U3RyaW5nKFtjb21tYW5kXSl9LCAke3Rvb2xCb3gudG9IZXhTdHJpbmcoZGF0YSl9KWApO1xyXG5cclxuICByeFBhY2tldC5kYXRhID0gZGF0YTtcclxuICByeFBhY2tldC5jb21tYW5kID0gY29tbWFuZDtcclxuICByeFBhY2tldC5jb21tYW5kTmFtZSA9IHRvb2xCb3guZ2V0RmllbGROYW1lQnlWYWx1ZShDT01NQU5EUywgY29tbWFuZCk7XHJcbiAgcnhQYWNrZXQudmFsaWQgPSB0cnVlO1xyXG5cclxuICBzd2l0Y2gocnhQYWNrZXQuY29tbWFuZCkge1xyXG4gICAgY2FzZSBDT01NQU5EUy5OQUNLOiB7XHJcbiAgICAgIGxldCBlcnJvckNvZGUgPSByeFBhY2tldC5kYXRhWzFdO1xyXG5cclxuICAgICAgc3dpdGNoKGVycm9yQ29kZSkge1xyXG4gICAgICAgIGNhc2UgUEFDS0VUX0VSUk9SX0NPREVTLkNPTkNJRkdfUE9SVF9QQUNLRVRfRVJST1JfU0VTU0lPTl9OT1RfQUNUSVZFOiB7XHJcbiAgICAgICAgICBjb25zb2xlLmxvZygnQ09OQ0lGR19QT1JUX1BBQ0tFVF9FUlJPUl9TRVNTSU9OX05PVF9BQ1RJVkUnKTtcclxuICAgICAgICAgIHRlcm1pbmF0ZVNlc3Npb24oKTtcclxuICAgICAgICB9XHJcbiAgICAgICAgYnJlYWs7XHJcblxyXG4gICAgICAgIGNhc2UgUEFDS0VUX0VSUk9SX0NPREVTLkNPTkNJRkdfUE9SVF9QQUNLRVRfRVJST1JfU0VTU0lPTl9QQUNLRVQ6IHtcclxuICAgICAgICAgIGNvbnNvbGUubG9nKCdDT05DSUZHX1BPUlRfUEFDS0VUX0VSUk9SX1NFU1NJT05fUEFDS0VUJyk7XHJcbiAgICAgICAgICBhdXRoZW50aWNhdG9yLnNlc3Npb25QYWNrZXRGYWlsQ291bnRlcisrO1xyXG4gICAgICAgICAgaWYoYXV0aGVudGljYXRvci5zZXNzaW9uUGFja2V0RmFpbENvdW50ZXIgPT09IDMpIHtcclxuICAgICAgICAgICAgdGVybWluYXRlU2Vzc2lvbigpO1xyXG4gICAgICAgICAgfVxyXG4gICAgICAgIH1cclxuICAgICAgICBicmVhaztcclxuXHJcbiAgICAgICAgZGVmYXVsdDoge1xyXG4gICAgICAgICAgXHJcbiAgICAgICAgfVxyXG4gICAgICAgIGJyZWFrO1xyXG4gICAgICB9XHJcbiAgICB9XHJcbiAgICBicmVhaztcclxuXHJcbiAgICBkZWZhdWx0IDp7XHJcblxyXG4gICAgfVxyXG4gICAgYnJlYWs7XHJcbiAgfVxyXG59XHJcblxyXG5mdW5jdGlvbiB0ZXJtaW5hdGVTZXNzaW9uICgpIHtcclxuICBhdXRoZW50aWNhdG9yLnNlc3Npb25BY3RpdmUgPSBmYWxzZTtcclxuICBcclxuICBjb25zb2xlLmxvZyhcclxuICAgICclY1Nlc3Npb24gVGVybWluYXRlZCcsXHJcbiAgICAnY29sb3I6d2hpdGU7IGJhY2tncm91bmQ6cmVkOyBmb250LXNpemU6MnJlbTsgcGFkZGluZzogLjVyZW07JyxcclxuICApO1xyXG59XHJcblxyXG5hc3luYyBmdW5jdGlvbiBwb2xsRm9yUnhQYWNrZXRSZWFkeSAobWF4VGltZW91dCkge1xyXG4gIGNvbnN0IFRJTUVfU1RFUCA9IDIwO1xyXG5cclxuICBhc3luYyBmdW5jdGlvbiBfcG9sbEZvclJ4UGFja2V0UmVhZHkgKG1heFRpbWVvdXQpIHtcclxuICAgIGF3YWl0IHRvb2xCb3guYXN5bmNEZWxheShUSU1FX1NURVApO1xyXG4gIFxyXG4gICAgaWYocnhQYWNrZXQudmFsaWQpIHtcclxuICAgICAgcmV0dXJuO1xyXG4gICAgfVxyXG4gIFxyXG4gICAgaWYobWF4VGltZW91dCA+IFRJTUVfU1RFUCkge1xyXG4gICAgICBtYXhUaW1lb3V0IC09IFRJTUVfU1RFUDtcclxuICAgICAgYXdhaXQgX3BvbGxGb3JSeFBhY2tldFJlYWR5KG1heFRpbWVvdXQpO1xyXG4gICAgfVxyXG4gIH1cclxuXHJcbiAgcnhQYWNrZXQudmFsaWQgPSBmYWxzZTtcclxuICBhd2FpdCBfcG9sbEZvclJ4UGFja2V0UmVhZHkobWF4VGltZW91dCk7XHJcbn1cclxuXHJcbmZ1bmN0aW9uIHVpVG9TZXJpYWxSZXF1ZXN0IChyZXF1ZXN0TmFtZSwgcmVxdWVzdERhdGE9bnVsbCkge1xyXG4gIGNvbnNvbGUubG9nKCd1aVRvU2VyaWFsUmVxdWVzdCgnLCByZXF1ZXN0TmFtZSwgJywnLCByZXF1ZXN0RGF0YSwgJyknKTtcclxuICBcclxuICBsZXQgYnl0ZXMgPSBbLi4ucnhQYWNrZXQuZGF0YV07XHJcblxyXG4gIGNvbnN0IGV4dHJhY3RCeXRlcyA9IChudW1PZkJ5dGVzKSA9PiB7XHJcbiAgICByZXR1cm4gYnl0ZXMuc3BsaWNlKDAsIG51bU9mQnl0ZXMpO1xyXG4gIH1cclxuICBjb25zdCBleHRyYWN0VTMyID0gKCkgPT4ge1xyXG4gICAgcmV0dXJuIHRvb2xCb3guYXJyYXlUb0ludChleHRyYWN0Qnl0ZXMoNCksIGZhbHNlKTtcclxuICB9XHJcbiAgY29uc3QgZXh0cmFjdFUzMkFycmF5ID0gKG51bU9mVTMycykgPT4ge1xyXG4gICAgbGV0IHJlc3VsdCA9IFtdO1xyXG4gICAgZm9yKGxldCBpID0gMDsgaSA8IG51bU9mVTMyczsgaSsrKSB7XHJcbiAgICAgIHJlc3VsdC5wdXNoKGV4dHJhY3RVMzIoKSk7XHJcbiAgICB9XHJcbiAgICByZXR1cm4gcmVzdWx0O1xyXG4gIH1cclxuICBjb25zdCBleHRyYWN0STMyID0gKCkgPT4ge1xyXG4gICAgcmV0dXJuIHRvb2xCb3guYXJyYXlUb0ludChleHRyYWN0Qnl0ZXMoNCksIHRydWUpO1xyXG4gIH1cclxuICBjb25zdCBleHRyYWN0VTE2ID0gKCkgPT4ge1xyXG4gICAgcmV0dXJuIHRvb2xCb3guYXJyYXlUb0ludChleHRyYWN0Qnl0ZXMoMiksIGZhbHNlKTtcclxuICB9XHJcbiAgY29uc3QgZXh0cmFjdEkxNiA9ICgpID0+IHtcclxuICAgIHJldHVybiB0b29sQm94LmFycmF5VG9JbnQoZXh0cmFjdEJ5dGVzKDIpLCB0cnVlKTtcclxuICB9XHJcbiAgY29uc3QgZXh0cmFjdFU4ID0gKCkgPT4ge1xyXG4gICAgcmV0dXJuIHRvb2xCb3guYXJyYXlUb0ludChleHRyYWN0Qnl0ZXMoMSksIGZhbHNlKTtcclxuICB9XHJcbiAgY29uc3QgZXh0cmFjdEk4ID0gKCkgPT4ge1xyXG4gICAgcmV0dXJuIHRvb2xCb3guYXJyYXlUb0ludChleHRyYWN0Qnl0ZXMoMSksIHRydWUpO1xyXG4gIH1cclxuICBjb25zdCBleHRyYWN0RmxvYXQgPSAoKSA9PiB7XHJcbiAgICByZXR1cm4gdG9vbEJveC5hcnJheTRUb0Zsb2F0MzIoZXh0cmFjdEJ5dGVzKDQpLCB0cnVlKTtcclxuICB9XHJcbiAgY29uc3QgZXh0cmFjdER1bW15Qnl0ZXMgPSAobnVtT2ZCeXRlcykgPT4ge1xyXG4gICAgZXh0cmFjdEJ5dGVzKG51bU9mQnl0ZXMpO1xyXG4gIH1cclxuXHJcbiAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0Lm1heFJlc3BvbnNlVGltZSA9IERFRkFVTFRfTUFYX1JFU1BPTlNFX1RJTUU7XHJcbiAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LmlzU3BlY2lhbENvbW1hbmQgPSBmYWxzZTtcclxuICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3QucmVxdWVzdE5hbWUgPSByZXF1ZXN0TmFtZTtcclxuICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3QucmVxdWVzdERhdGEgPSByZXF1ZXN0RGF0YTtcclxuXHJcbiAgc3dpdGNoKHJlcXVlc3ROYW1lKSB7XHJcbiAgICBjYXNlICdzZW5kSGVsbG8nOiB7XHJcbiAgICAgIGNyZWF0ZVVpVG9TZXJpYWxQZW5kaW5nUGFja2V0KFxyXG4gICAgICAgIHNlcmlhbFR4LmNyZWF0ZVBhY2tldChcclxuICAgICAgICAgIENPTU1BTkRTLkhFTExPXHJcbiAgICAgICAgKVxyXG4gICAgICApO1xyXG4gICAgICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3QuZXhwZWN0ZWRSZXNwb25zZSA9ICdub25lJztcclxuICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LnN1Y2Nlc3NNZXNzYWdlID0gJ9m+2KfYs9iuIEhlbGxvINiv2LHbjNin2YHYqiDYtNivJztcclxuICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LmZhaWx1cmVNZXNzYWdlID0gJ9m+2KfYs9iuIEhlbGxvINiv2LHbjNin2YHYqiDZhti02K8nO1xyXG4gICAgfVxyXG4gICAgYnJlYWs7XHJcblxyXG4gICAgY2FzZSAnc2V0QnV6emVyVm9sdW1lJzoge1xyXG4gICAgICBjcmVhdGVVaVRvU2VyaWFsUGVuZGluZ1BhY2tldChcclxuICAgICAgICBzZXJpYWxUeC5jcmVhdGVQYWNrZXQoXHJcbiAgICAgICAgICBDT01NQU5EUy5TRVRfQlVaWkVSX1ZPTFVNRSxcclxuICAgICAgICAgIHRvb2xCb3guaW50VG9BcnJheShyZXF1ZXN0RGF0YSwgMSwgZmFsc2UpLFxyXG4gICAgICAgICAgYXV0aGVudGljYXRvci5zZXNzaW9uS2V5XHJcbiAgICAgICAgKVxyXG4gICAgICApO1xyXG4gICAgICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3QuZXhwZWN0ZWRSZXNwb25zZSA9ICdzaW1wbGVBY2snO1xyXG4gICAgICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3Quc3VjY2Vzc01lc3NhZ2UgPSBg2LPYt9itINi12K/YpyDYqNin2LLYsSDYp9i52YXYp9mEINi02K9gO1xyXG4gICAgICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3QuZmFpbHVyZU1lc3NhZ2UgPSAn2K7Yt9inJztcclxuICAgIH1cclxuICAgIGJyZWFrO1xyXG5cclxuICAgIGNhc2UgJ3Rlc3RMZWQnOiB7XHJcbiAgICAgIGNyZWF0ZVVpVG9TZXJpYWxQZW5kaW5nUGFja2V0KFxyXG4gICAgICAgIHNlcmlhbFR4LmNyZWF0ZVBhY2tldChcclxuICAgICAgICAgIENPTU1BTkRTLlRFU1RfTEVELFxyXG4gICAgICAgICAgdG9vbEJveC5pbnRUb0FycmF5KHJlcXVlc3REYXRhLCAxLCBmYWxzZSksXHJcbiAgICAgICAgICBhdXRoZW50aWNhdG9yLnNlc3Npb25LZXlcclxuICAgICAgICApXHJcbiAgICAgICk7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5leHBlY3RlZFJlc3BvbnNlID0gJ3NpbXBsZUFjayc7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5zdWNjZXNzTWVzc2FnZSA9IGDYqtiz2KogTEVEICR7cmVxdWVzdERhdGEgKyAxfSDYtNix2YjYuSDYtNivYDtcclxuICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LmZhaWx1cmVNZXNzYWdlID0gJ9iu2LfYpyc7XHJcbiAgICB9XHJcbiAgICBicmVhaztcclxuXHJcbiAgICBjYXNlICdzZXRXb3JraW5nTW9kZSc6IHtcclxuICAgICAgY3JlYXRlVWlUb1NlcmlhbFBlbmRpbmdQYWNrZXQoXHJcbiAgICAgICAgc2VyaWFsVHguY3JlYXRlUGFja2V0KFxyXG4gICAgICAgICAgQ09NTUFORFMuU0VUX0RFVklDRV9XT1JLSU5HX01PREUsXHJcbiAgICAgICAgICB0b29sQm94LmludFRvQXJyYXkocmVxdWVzdERhdGEsIDEsIGZhbHNlKSxcclxuICAgICAgICAgIGF1dGhlbnRpY2F0b3Iuc2Vzc2lvbktleVxyXG4gICAgICAgIClcclxuICAgICAgKTtcclxuICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LmV4cGVjdGVkUmVzcG9uc2UgPSAnc2ltcGxlQWNrJztcclxuICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LnN1Y2Nlc3NNZXNzYWdlID0gYNit2KfZhNiqINqp2KfYsduMINiz24zYs9iq2YUg2KfYudmF2KfZhCDYtNivYDtcclxuICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LmZhaWx1cmVNZXNzYWdlID0gJ9iu2LfYpyc7XHJcbiAgICB9XHJcbiAgICBicmVhaztcclxuXHJcbiAgICBjYXNlICdzZXREZXZpY2VJZCc6IHtcclxuICAgICAgY3JlYXRlVWlUb1NlcmlhbFBlbmRpbmdQYWNrZXQoXHJcbiAgICAgICAgc2VyaWFsVHguY3JlYXRlUGFja2V0KFxyXG4gICAgICAgICAgQ09NTUFORFMuU0VUX0RFVklDRV9JRCxcclxuICAgICAgICAgIHJlcXVlc3REYXRhLFxyXG4gICAgICAgICAgYXV0aGVudGljYXRvci5zZXNzaW9uS2V5XHJcbiAgICAgICAgKVxyXG4gICAgICApO1xyXG4gICAgICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3QuZXhwZWN0ZWRSZXNwb25zZSA9ICdzaW1wbGVBY2snO1xyXG4gICAgICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3Quc3VjY2Vzc01lc3NhZ2UgPSBg2LTZhtin2LPZhyDYr9iz2Krar9in2Ycg2KfYudmF2KfZhCDYtNivYDtcclxuICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LmZhaWx1cmVNZXNzYWdlID0gJ9iu2LfYpyc7XHJcbiAgICB9XHJcbiAgICBicmVhaztcclxuXHJcbiAgICBjYXNlICdzZXREZXZpY2VJZExlbmd0aCc6IHtcclxuICAgICAgY3JlYXRlVWlUb1NlcmlhbFBlbmRpbmdQYWNrZXQoXHJcbiAgICAgICAgc2VyaWFsVHguY3JlYXRlUGFja2V0KFxyXG4gICAgICAgICAgQ09NTUFORFMuU0VUX0RFVklDRV9JRF9MRU5HVEgsXHJcbiAgICAgICAgICB0b29sQm94LmludFRvQXJyYXkocmVxdWVzdERhdGEsIDEsIGZhbHNlKSxcclxuICAgICAgICAgIGF1dGhlbnRpY2F0b3Iuc2Vzc2lvbktleVxyXG4gICAgICAgIClcclxuICAgICAgKTtcclxuICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LmV4cGVjdGVkUmVzcG9uc2UgPSAnc2ltcGxlQWNrJztcclxuICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LnN1Y2Nlc3NNZXNzYWdlID0gYNi32YjZhCDYtNmG2KfYs9mHINiv2LPYqtqv2KfZhyDYp9i52YXYp9mEINi02K9gO1xyXG4gICAgICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3QuZmFpbHVyZU1lc3NhZ2UgPSAn2K7Yt9inJztcclxuICAgIH1cclxuICAgIGJyZWFrO1xyXG5cclxuICAgIGNhc2UgJ3NldEJsYWNrTGlzdEJ5cGFzcyc6IHtcclxuICAgICAgY3JlYXRlVWlUb1NlcmlhbFBlbmRpbmdQYWNrZXQoXHJcbiAgICAgICAgc2VyaWFsVHguY3JlYXRlUGFja2V0KFxyXG4gICAgICAgICAgQ09NTUFORFMuU0VUX0JMQUNLX0xJU1RfQllQQVNTLFxyXG4gICAgICAgICAgdG9vbEJveC5pbnRUb0FycmF5KHJlcXVlc3REYXRhLCAxLCBmYWxzZSksXHJcbiAgICAgICAgICBhdXRoZW50aWNhdG9yLnNlc3Npb25LZXlcclxuICAgICAgICApXHJcbiAgICAgICk7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5leHBlY3RlZFJlc3BvbnNlID0gJ3NpbXBsZUFjayc7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5zdWNjZXNzTWVzc2FnZSA9IGDYqtmG2LjbjNmFINio2LHYsdiz24wg2YTbjNiz2Kog2LPbjNin2Ycg2KfYudmF2KfZhCDYtNivYDtcclxuICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LmZhaWx1cmVNZXNzYWdlID0gJ9iu2LfYpyc7XHJcbiAgICB9XHJcbiAgICBicmVhaztcclxuXHJcbiAgICBjYXNlICdzZXRSdGNUaW1lJzoge1xyXG4gICAgICBjcmVhdGVVaVRvU2VyaWFsUGVuZGluZ1BhY2tldChcclxuICAgICAgICBzZXJpYWxUeC5jcmVhdGVQYWNrZXQoXHJcbiAgICAgICAgICBDT01NQU5EUy5TRVRfUlRDX1RJTUUsXHJcbiAgICAgICAgICByZXF1ZXN0RGF0YSxcclxuICAgICAgICAgIGF1dGhlbnRpY2F0b3Iuc2Vzc2lvbktleVxyXG4gICAgICAgIClcclxuICAgICAgKTtcclxuICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LmV4cGVjdGVkUmVzcG9uc2UgPSAnc2ltcGxlQWNrJztcclxuICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LnN1Y2Nlc3NNZXNzYWdlID0gYNiy2YXYp9mGIFJUQyDYr9iz2Krar9in2Ycg2KfYudmF2KfZhCDYtNivYDtcclxuICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LmZhaWx1cmVNZXNzYWdlID0gJ9iu2LfYpyc7XHJcbiAgICB9XHJcbiAgICBicmVhaztcclxuXHJcbiAgICBjYXNlICdzZXRSZW1vdGVEaXNjaGFyZ2VDb21tYW5kJzoge1xyXG4gICAgICBjcmVhdGVVaVRvU2VyaWFsUGVuZGluZ1BhY2tldChcclxuICAgICAgICBzZXJpYWxUeC5jcmVhdGVQYWNrZXQoXHJcbiAgICAgICAgICBDT01NQU5EUy5TRVRfUkVNT1RFX0RJU0NIQVJHRV9NRVNTQUdFLFxyXG4gICAgICAgICAgcmVxdWVzdERhdGEsXHJcbiAgICAgICAgICBhdXRoZW50aWNhdG9yLnNlc3Npb25LZXlcclxuICAgICAgICApXHJcbiAgICAgICk7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5leHBlY3RlZFJlc3BvbnNlID0gJ3NpbXBsZUFjayc7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5zdWNjZXNzTWVzc2FnZSA9IGDYr9iz2KrZiNixINiq2K7ZhNuM2Ycg2KfYsiDYsdin2Ycg2K/ZiNixINis2K/bjNivINin2LnZhdin2YQg2LTYr2A7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5mYWlsdXJlTWVzc2FnZSA9ICfYrti32KcnO1xyXG4gICAgfVxyXG4gICAgYnJlYWs7XHJcblxyXG4gICAgY2FzZSAnc2V0S2V5QmFua01haW5TZWVkJzoge1xyXG4gICAgICBjcmVhdGVVaVRvU2VyaWFsUGVuZGluZ1BhY2tldChcclxuICAgICAgICBzZXJpYWxUeC5jcmVhdGVQYWNrZXQoXHJcbiAgICAgICAgICBDT01NQU5EUy5TRVRfTUFJTl9LRVlfQkFOS19TRUVELFxyXG4gICAgICAgICAgcmVxdWVzdERhdGEsXHJcbiAgICAgICAgICBhdXRoZW50aWNhdG9yLnNlc3Npb25LZXlcclxuICAgICAgICApXHJcbiAgICAgICk7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5leHBlY3RlZFJlc3BvbnNlID0gJ3NpbXBsZUFjayc7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5zdWNjZXNzTWVzc2FnZSA9IGDZhdmC2K/Yp9ixIFNlZWQg2KrZiNmE24zYryDYqNin2YbaqSDaqdmE24zYryDYp9i12YTbjCDYp9i52YXYp9mEINi02K9gO1xyXG4gICAgICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3QuZmFpbHVyZU1lc3NhZ2UgPSAn2K7Yt9inJztcclxuICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0Lm1heFJlc3BvbnNlVGltZSA9IEtFWV9CQU5LX0dFTkVSQVRJT05fTUFYX1JFU1BPTlNFX1RJTUU7XHJcbiAgICB9XHJcbiAgICBicmVhaztcclxuXHJcbiAgICBjYXNlICdzZXRLZXlCYW5rQmFja3VwU2VlZCc6IHtcclxuICAgICAgY3JlYXRlVWlUb1NlcmlhbFBlbmRpbmdQYWNrZXQoXHJcbiAgICAgICAgc2VyaWFsVHguY3JlYXRlUGFja2V0KFxyXG4gICAgICAgICAgQ09NTUFORFMuU0VUX0JBQ0tVUF9LRVlfQkFOS19TRUVELFxyXG4gICAgICAgICAgcmVxdWVzdERhdGEsXHJcbiAgICAgICAgICBhdXRoZW50aWNhdG9yLnNlc3Npb25LZXlcclxuICAgICAgICApXHJcbiAgICAgICk7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5leHBlY3RlZFJlc3BvbnNlID0gJ3NpbXBsZUFjayc7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5zdWNjZXNzTWVzc2FnZSA9IGDZhdmC2K/Yp9ixIFNlZWQg2KrZiNmE24zYryDYqNin2YbaqSDaqdmE24zYryDZvti02KrbjNio2KfZhiDYp9i52YXYp9mEINi02K9gO1xyXG4gICAgICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3QuZmFpbHVyZU1lc3NhZ2UgPSAn2K7Yt9inJztcclxuICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0Lm1heFJlc3BvbnNlVGltZSA9IEtFWV9CQU5LX0dFTkVSQVRJT05fTUFYX1JFU1BPTlNFX1RJTUU7XHJcbiAgICB9XHJcbiAgICBicmVhaztcclxuXHJcbiAgICBjYXNlICdzZXRFbmNQb3J0SGVhZGVyJzoge1xyXG4gICAgICBjcmVhdGVVaVRvU2VyaWFsUGVuZGluZ1BhY2tldChcclxuICAgICAgICBzZXJpYWxUeC5jcmVhdGVQYWNrZXQoXHJcbiAgICAgICAgICBDT01NQU5EUy5TRVRfRU5DUllQVEVEX1BPUlRfSEVBREVSLFxyXG4gICAgICAgICAgcmVxdWVzdERhdGEsXHJcbiAgICAgICAgICBhdXRoZW50aWNhdG9yLnNlc3Npb25LZXlcclxuICAgICAgICApXHJcbiAgICAgICk7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5leHBlY3RlZFJlc3BvbnNlID0gJ3NpbXBsZUFjayc7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5zdWNjZXNzTWVzc2FnZSA9IGDZh9iv2LEg2KzYr9uM2K8g2b7aqdiqINmH2KfbjCDYsdmF2LIg2KfYudmF2KfZhCDYtNivYDtcclxuICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LmZhaWx1cmVNZXNzYWdlID0gJ9iu2LfYpyc7XHJcbiAgICB9XHJcbiAgICBicmVhaztcclxuXHJcbiAgICBjYXNlICdzZWxlY3RLZXlCYW5rJzoge1xyXG4gICAgICBjcmVhdGVVaVRvU2VyaWFsUGVuZGluZ1BhY2tldChcclxuICAgICAgICBzZXJpYWxUeC5jcmVhdGVQYWNrZXQoXHJcbiAgICAgICAgICBDT01NQU5EUy5TRVRfU0VMRUNURURfS0VZX0JBTkssXHJcbiAgICAgICAgICBbcmVxdWVzdERhdGFdLFxyXG4gICAgICAgICAgYXV0aGVudGljYXRvci5zZXNzaW9uS2V5XHJcbiAgICAgICAgKVxyXG4gICAgICApO1xyXG4gICAgICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3QuZXhwZWN0ZWRSZXNwb25zZSA9ICdzaW1wbGVBY2snO1xyXG4gICAgICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3Quc3VjY2Vzc01lc3NhZ2UgPSBg2KjYp9mG2qkg2qnZhNuM2K8g2KzYp9uM2q/YstuM2YYg2KfZhtiq2K7Yp9ioINi02K9gO1xyXG4gICAgICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3QuZmFpbHVyZU1lc3NhZ2UgPSAn2K7Yt9inJztcclxuICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0Lm1heFJlc3BvbnNlVGltZSA9IEtFWV9CQU5LX0dFTkVSQVRJT05fTUFYX1JFU1BPTlNFX1RJTUU7XHJcbiAgICB9XHJcbiAgICBicmVhaztcclxuXHJcbiAgICBjYXNlICdzZXRDYXNlT3BlbkV2ZW50QWN0aW9uJzoge1xyXG4gICAgICBjcmVhdGVVaVRvU2VyaWFsUGVuZGluZ1BhY2tldChcclxuICAgICAgICBzZXJpYWxUeC5jcmVhdGVQYWNrZXQoXHJcbiAgICAgICAgICBDT01NQU5EUy5TRVRfQ0FTRV9PUEVOX0VWRU5UX0FDVElPTixcclxuICAgICAgICAgIFtyZXF1ZXN0RGF0YV0sXHJcbiAgICAgICAgICBhdXRoZW50aWNhdG9yLnNlc3Npb25LZXlcclxuICAgICAgICApXHJcbiAgICAgICk7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5leHBlY3RlZFJlc3BvbnNlID0gJ3NpbXBsZUFjayc7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5zdWNjZXNzTWVzc2FnZSA9IGDYqtmG2LjbjNmFINiq2LTYrtuM2LUg2KjYp9iyINi02K/ZhiDaqduM2LMg2KfYudmF2KfZhCDYtNivYDtcclxuICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LmZhaWx1cmVNZXNzYWdlID0gJ9iu2LfYpyc7XHJcbiAgICB9XHJcbiAgICBicmVhaztcclxuXHJcbiAgICBjYXNlICdzZXRSZW1vdGVEaXNjaGFyZ2VFbmFibGUnOiB7XHJcbiAgICAgIGNyZWF0ZVVpVG9TZXJpYWxQZW5kaW5nUGFja2V0KFxyXG4gICAgICAgIHNlcmlhbFR4LmNyZWF0ZVBhY2tldChcclxuICAgICAgICAgIENPTU1BTkRTLlNFVF9SRU1PVEVfRElTQ0hBUkdFX0VOQUJMRSxcclxuICAgICAgICAgIFtyZXF1ZXN0RGF0YV0sXHJcbiAgICAgICAgICBhdXRoZW50aWNhdG9yLnNlc3Npb25LZXlcclxuICAgICAgICApXHJcbiAgICAgICk7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5leHBlY3RlZFJlc3BvbnNlID0gJ3NpbXBsZUFjayc7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5zdWNjZXNzTWVzc2FnZSA9IGDYqtmG2LjbjNmFINmB2LnYp9mEINio2YjYr9mGINiv2LPYqtmI2LEg2KrYrtmE24zZhyDYp9iyINix2KfZhyDYr9mI2LFgO1xyXG4gICAgICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3QuZmFpbHVyZU1lc3NhZ2UgPSAn2K7Yt9inJztcclxuICAgIH1cclxuICAgIGJyZWFrO1xyXG5cclxuICAgIGNhc2UgJ2Rpc2NoYXJnZUtleUJhbmtzJzoge1xyXG4gICAgICBjcmVhdGVVaVRvU2VyaWFsUGVuZGluZ1BhY2tldChcclxuICAgICAgICBzZXJpYWxUeC5jcmVhdGVQYWNrZXQoXHJcbiAgICAgICAgICBDT01NQU5EUy5ESVNDSEFSR0VfS0VZX0JBTktTLFxyXG4gICAgICAgICAgW3JlcXVlc3REYXRhXSxcclxuICAgICAgICAgIGF1dGhlbnRpY2F0b3Iuc2Vzc2lvbktleVxyXG4gICAgICAgIClcclxuICAgICAgKTtcclxuICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LmV4cGVjdGVkUmVzcG9uc2UgPSAnc2ltcGxlQWNrJztcclxuICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LnN1Y2Nlc3NNZXNzYWdlID0gYNio2KfZhtqpINmH2KfbjCDaqdmE24zYryDYqtiu2YTbjNmHINi02K9gO1xyXG4gICAgICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3QuZmFpbHVyZU1lc3NhZ2UgPSAn2K7Yt9inJztcclxuICAgIH1cclxuICAgIGJyZWFrO1xyXG5cclxuICAgIGNhc2UgJ3NldEVuY3J5cHRlZFBvcnRUeEJhdWRSYXRlJzoge1xyXG4gICAgICBjcmVhdGVVaVRvU2VyaWFsUGVuZGluZ1BhY2tldChcclxuICAgICAgICBzZXJpYWxUeC5jcmVhdGVQYWNrZXQoXHJcbiAgICAgICAgICBDT01NQU5EUy5TRVRfRU5DUllQVEVEX1BPUlRfVFhfQkFVRF9SQVRFLFxyXG4gICAgICAgICAgdG9vbEJveC5pbnRUb0FycmF5KHJlcXVlc3REYXRhLCA0LCBmYWxzZSksXHJcbiAgICAgICAgICBhdXRoZW50aWNhdG9yLnNlc3Npb25LZXlcclxuICAgICAgICApXHJcbiAgICAgICk7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5leHBlY3RlZFJlc3BvbnNlID0gJ3NpbXBsZUFjayc7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5zdWNjZXNzTWVzc2FnZSA9IGDZhdmC2K/Yp9ixIEJhdWQgUmF0ZSDYqtmG2LjbjNmFINi02K9gO1xyXG4gICAgICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3QuZmFpbHVyZU1lc3NhZ2UgPSAn2K7Yt9inJztcclxuICAgIH1cclxuICAgIGJyZWFrO1xyXG5cclxuICAgIGNhc2UgJ3NldEVuY3J5cHRlZFBvcnRSeEJhdWRSYXRlJzoge1xyXG4gICAgICBjcmVhdGVVaVRvU2VyaWFsUGVuZGluZ1BhY2tldChcclxuICAgICAgICBzZXJpYWxUeC5jcmVhdGVQYWNrZXQoXHJcbiAgICAgICAgICBDT01NQU5EUy5TRVRfRU5DUllQVEVEX1BPUlRfUlhfQkFVRF9SQVRFLFxyXG4gICAgICAgICAgdG9vbEJveC5pbnRUb0FycmF5KHJlcXVlc3REYXRhLCA0LCBmYWxzZSksXHJcbiAgICAgICAgICBhdXRoZW50aWNhdG9yLnNlc3Npb25LZXlcclxuICAgICAgICApXHJcbiAgICAgICk7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5leHBlY3RlZFJlc3BvbnNlID0gJ3NpbXBsZUFjayc7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5zdWNjZXNzTWVzc2FnZSA9IGDZhdmC2K/Yp9ixIEJhdWQgUmF0ZSDYqtmG2LjbjNmFINi02K9gO1xyXG4gICAgICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3QuZmFpbHVyZU1lc3NhZ2UgPSAn2K7Yt9inJztcclxuICAgIH1cclxuICAgIGJyZWFrO1xyXG5cclxuICAgIGNhc2UgJ3NldERlY3J5cHRlZFBvcnRUeEJhdWRSYXRlJzoge1xyXG4gICAgICBjcmVhdGVVaVRvU2VyaWFsUGVuZGluZ1BhY2tldChcclxuICAgICAgICBzZXJpYWxUeC5jcmVhdGVQYWNrZXQoXHJcbiAgICAgICAgICBDT01NQU5EUy5TRVRfREVDUllQVEVEX1BPUlRfVFhfQkFVRF9SQVRFLFxyXG4gICAgICAgICAgdG9vbEJveC5pbnRUb0FycmF5KHJlcXVlc3REYXRhLCA0LCBmYWxzZSksXHJcbiAgICAgICAgICBhdXRoZW50aWNhdG9yLnNlc3Npb25LZXlcclxuICAgICAgICApXHJcbiAgICAgICk7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5leHBlY3RlZFJlc3BvbnNlID0gJ3NpbXBsZUFjayc7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5zdWNjZXNzTWVzc2FnZSA9IGDZhdmC2K/Yp9ixIEJhdWQgUmF0ZSDYqtmG2LjbjNmFINi02K9gO1xyXG4gICAgICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3QuZmFpbHVyZU1lc3NhZ2UgPSAn2K7Yt9inJztcclxuICAgIH1cclxuICAgIGJyZWFrO1xyXG5cclxuICAgIGNhc2UgJ3NldERlY3J5cHRlZFBvcnRSeEJhdWRSYXRlJzoge1xyXG4gICAgICBjcmVhdGVVaVRvU2VyaWFsUGVuZGluZ1BhY2tldChcclxuICAgICAgICBzZXJpYWxUeC5jcmVhdGVQYWNrZXQoXHJcbiAgICAgICAgICBDT01NQU5EUy5TRVRfREVDUllQVEVEX1BPUlRfUlhfQkFVRF9SQVRFLFxyXG4gICAgICAgICAgdG9vbEJveC5pbnRUb0FycmF5KHJlcXVlc3REYXRhLCA0LCBmYWxzZSksXHJcbiAgICAgICAgICBhdXRoZW50aWNhdG9yLnNlc3Npb25LZXlcclxuICAgICAgICApXHJcbiAgICAgICk7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5leHBlY3RlZFJlc3BvbnNlID0gJ3NpbXBsZUFjayc7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5zdWNjZXNzTWVzc2FnZSA9IGDZhdmC2K/Yp9ixIEJhdWQgUmF0ZSDYqtmG2LjbjNmFINi02K9gO1xyXG4gICAgICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3QuZmFpbHVyZU1lc3NhZ2UgPSAn2K7Yt9inJztcclxuICAgIH1cclxuICAgIGJyZWFrO1xyXG5cclxuICAgIGNhc2UgJ3NldFBhY2tldFRpbWVTdGFtcEVuYWJsZSc6IHtcclxuICAgICAgY3JlYXRlVWlUb1NlcmlhbFBlbmRpbmdQYWNrZXQoXHJcbiAgICAgICAgc2VyaWFsVHguY3JlYXRlUGFja2V0KFxyXG4gICAgICAgICAgQ09NTUFORFMuU0VUX1JUQ19QQUNLRVRfU0VDVElPTl9FTkFCTEVELFxyXG4gICAgICAgICAgW3JlcXVlc3REYXRhXSxcclxuICAgICAgICAgIGF1dGhlbnRpY2F0b3Iuc2Vzc2lvbktleVxyXG4gICAgICAgIClcclxuICAgICAgKTtcclxuICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LmV4cGVjdGVkUmVzcG9uc2UgPSAnc2ltcGxlQWNrJztcclxuICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LnN1Y2Nlc3NNZXNzYWdlID0gYNmB2LnYp9mEINio2YjYr9mGINio2K7YtCBUaW1lc3RhbXAg2KrZhti424zZhSDYtNivYDtcclxuICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LmZhaWx1cmVNZXNzYWdlID0gJ9iu2LfYpyc7XHJcbiAgICB9XHJcbiAgICBicmVhaztcclxuXHJcbiAgICBjYXNlICdzZXRNYXhUaW1lU3RhbXBEaWZmZXJlbmNlJzoge1xyXG4gICAgICBjcmVhdGVVaVRvU2VyaWFsUGVuZGluZ1BhY2tldChcclxuICAgICAgICBzZXJpYWxUeC5jcmVhdGVQYWNrZXQoXHJcbiAgICAgICAgICBDT01NQU5EUy5TRVRfTUFYSU1VTV9WQUxJRF9SVENfVElNRV9ESUZGRVJFTkNFLFxyXG4gICAgICAgICAgdG9vbEJveC5pbnRUb0FycmF5KHJlcXVlc3REYXRhLCA0LCBmYWxzZSksXHJcbiAgICAgICAgICBhdXRoZW50aWNhdG9yLnNlc3Npb25LZXlcclxuICAgICAgICApXHJcbiAgICAgICk7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5leHBlY3RlZFJlc3BvbnNlID0gJ3NpbXBsZUFjayc7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5zdWNjZXNzTWVzc2FnZSA9IGDZhdin2qnYs9uM2YXZhSDYp9iu2KrZhNin2YEgVGltZXN0YW1wINmC2KfYqNmEINmC2KjZiNmEINiq2YbYuNuM2YUg2LTYr2A7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5mYWlsdXJlTWVzc2FnZSA9ICfYrti32KcnO1xyXG4gICAgfVxyXG4gICAgYnJlYWs7XHJcblxyXG4gICAgY2FzZSAnc2V0RGVjcnlwdGVkUG9ydFJ4VGltZW91dE1zJzoge1xyXG4gICAgICBjcmVhdGVVaVRvU2VyaWFsUGVuZGluZ1BhY2tldChcclxuICAgICAgICBzZXJpYWxUeC5jcmVhdGVQYWNrZXQoXHJcbiAgICAgICAgICBDT01NQU5EUy5TRVRfREVDUllQVEVEX1BPUlRfUlhfVElNRU9VVF9NUyxcclxuICAgICAgICAgIHRvb2xCb3guaW50VG9BcnJheShyZXF1ZXN0RGF0YSwgNCwgZmFsc2UpLFxyXG4gICAgICAgICAgYXV0aGVudGljYXRvci5zZXNzaW9uS2V5XHJcbiAgICAgICAgKVxyXG4gICAgICApO1xyXG4gICAgICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3QuZXhwZWN0ZWRSZXNwb25zZSA9ICdzaW1wbGVBY2snO1xyXG4gICAgICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3Quc3VjY2Vzc01lc3NhZ2UgPSBg2YXZgtiv2KfYsSBUaW1lb3V0INiv2LHar9in2Ycg2qnYtNmBINiq2YbYuNuM2YUg2LTYr2A7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5mYWlsdXJlTWVzc2FnZSA9ICfYrti32KcnO1xyXG4gICAgfVxyXG4gICAgYnJlYWs7XHJcblxyXG4gICAgY2FzZSAnc2V0RW5jcnlwdGVkUG9ydFJ4VGltZW91dE1zJzoge1xyXG4gICAgICBjcmVhdGVVaVRvU2VyaWFsUGVuZGluZ1BhY2tldChcclxuICAgICAgICBzZXJpYWxUeC5jcmVhdGVQYWNrZXQoXHJcbiAgICAgICAgICBDT01NQU5EUy5TRVRfRU5DUllQVEVEX1BPUlRfUlhfVElNRU9VVF9NUyxcclxuICAgICAgICAgIHRvb2xCb3guaW50VG9BcnJheShyZXF1ZXN0RGF0YSwgNCwgZmFsc2UpLFxyXG4gICAgICAgICAgYXV0aGVudGljYXRvci5zZXNzaW9uS2V5XHJcbiAgICAgICAgKVxyXG4gICAgICApO1xyXG4gICAgICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3QuZXhwZWN0ZWRSZXNwb25zZSA9ICdzaW1wbGVBY2snO1xyXG4gICAgICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3Quc3VjY2Vzc01lc3NhZ2UgPSBg2YXZgtiv2KfYsSBUaW1lb3V0INiv2LHar9in2Ycg2LHZhdiyINiq2YbYuNuM2YUg2LTYr2A7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5mYWlsdXJlTWVzc2FnZSA9ICfYrti32KcnO1xyXG4gICAgfVxyXG4gICAgYnJlYWs7XHJcblxyXG4gICAgY2FzZSAnc2V0RW5jcnlwdGVkUGFja2V0TWF4RGF0YUxlbmd0aCc6IHtcclxuICAgICAgY3JlYXRlVWlUb1NlcmlhbFBlbmRpbmdQYWNrZXQoXHJcbiAgICAgICAgc2VyaWFsVHguY3JlYXRlUGFja2V0KFxyXG4gICAgICAgICAgQ09NTUFORFMuU0VUX0VOQ1JZUFRFRF9QQUNLRVRfTUFYX0RBVEFfTEVOR1RILFxyXG4gICAgICAgICAgdG9vbEJveC5pbnRUb0FycmF5KHJlcXVlc3REYXRhLCA0LCBmYWxzZSksXHJcbiAgICAgICAgICBhdXRoZW50aWNhdG9yLnNlc3Npb25LZXlcclxuICAgICAgICApXHJcbiAgICAgICk7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5leHBlY3RlZFJlc3BvbnNlID0gJ3NpbXBsZUFjayc7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5zdWNjZXNzTWVzc2FnZSA9IGDZhdin2qnYs9uM2YXZhSDYt9mI2YQgRGF0YSDZvtqp2Kog2YfYp9uMINix2YXYsiDYqtmG2LjbjNmFINi02K9gO1xyXG4gICAgICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3QuZmFpbHVyZU1lc3NhZ2UgPSAn2K7Yt9inJztcclxuICAgIH1cclxuICAgIGJyZWFrO1xyXG5cclxuICAgIGNhc2UgJ3N0YXJ0S3NzU3RyZWFtR2VuZXJhdGlvbic6IHtcclxuICAgICAgY3JlYXRlVWlUb1NlcmlhbFBlbmRpbmdQYWNrZXQoXHJcbiAgICAgICAgc2VyaWFsVHguY3JlYXRlUGFja2V0KFxyXG4gICAgICAgICAgQ09NTUFORFMuU1RBUlRfS1NTX1NUUkVBTV9HRU5FUkFUSU9OLFxyXG4gICAgICAgICAgcmVxdWVzdERhdGEsXHJcbiAgICAgICAgICBhdXRoZW50aWNhdG9yLnNlc3Npb25LZXlcclxuICAgICAgICApXHJcbiAgICAgICk7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5leHBlY3RlZFJlc3BvbnNlID0gJ3NpbXBsZUFjayc7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5zdWNjZXNzTWVzc2FnZSA9IGDYqtmI2YTbjNivINix2LTYqtmHIEtTUyDYqNuMINmG2YfYp9uM2Kog2LTYsdmI2Lkg2LTYr2A7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5mYWlsdXJlTWVzc2FnZSA9ICfYrti32KcnO1xyXG4gICAgfVxyXG4gICAgYnJlYWs7XHJcblxyXG4gICAgY2FzZSAnc3RvcEtzc1N0cmVhbUdlbmVyYXRpb24nOiB7XHJcbiAgICAgIGNyZWF0ZVVpVG9TZXJpYWxQZW5kaW5nUGFja2V0KFxyXG4gICAgICAgIHNlcmlhbFR4LmNyZWF0ZVBhY2tldChcclxuICAgICAgICAgIENPTU1BTkRTLlNUT1BfS1NTX1NUUkVBTV9HRU5FUkFUSU9OLFxyXG4gICAgICAgICAgW10sXHJcbiAgICAgICAgICBhdXRoZW50aWNhdG9yLnNlc3Npb25LZXlcclxuICAgICAgICApXHJcbiAgICAgICk7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5leHBlY3RlZFJlc3BvbnNlID0gJ3NpbXBsZUFjayc7XHJcbiAgICAgIHVpVG9TZXJpYWxQZW5kaW5nUmVxdWVzdC5zdWNjZXNzTWVzc2FnZSA9IGDYqtmI2YTbjNivINix2LTYqtmHIEtTUyDYqNuMINmG2YfYp9uM2Kog2YXYqtmI2YLZgSDYtNivYDtcclxuICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LmZhaWx1cmVNZXNzYWdlID0gJ9iu2LfYpyc7XHJcbiAgICB9XHJcbiAgICBicmVhaztcclxuXHJcbiAgICBjYXNlICdzZXRHdWlQYXNzd29yZCc6IHtcclxuICAgICAgY3JlYXRlVWlUb1NlcmlhbFBlbmRpbmdQYWNrZXQoXHJcbiAgICAgICAgc2VyaWFsVHguY3JlYXRlUGFja2V0KFxyXG4gICAgICAgICAgQ09NTUFORFMuU0VUX0dVSV9QQVNTV09SRCxcclxuICAgICAgICAgIHJlcXVlc3REYXRhLFxyXG4gICAgICAgICAgYXV0aGVudGljYXRvci5zZXNzaW9uS2V5XHJcbiAgICAgICAgKVxyXG4gICAgICApO1xyXG4gICAgICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3QuZXhwZWN0ZWRSZXNwb25zZSA9ICdzaW1wbGVBY2snO1xyXG4gICAgICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3Quc3VjY2Vzc01lc3NhZ2UgPSBg2LHZhdiyINi52KjZiNixINis2K/bjNivINin2KrYtdin2YQg2YbYsdmFINin2YHYstin2LEg2LDYrtuM2LHZhyDYtNivYDtcclxuICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LmZhaWx1cmVNZXNzYWdlID0gJ9iu2LfYpyc7XHJcbiAgICB9XHJcbiAgICBicmVhaztcclxuXHJcbiAgICBjYXNlICd3cml0ZUJsYWNrTGlzdCc6IHtcclxuICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LmlzU3BlY2lhbENvbW1hbmQgPSB0cnVlO1xyXG4gICAgICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3QudmFsaWQgPSB0cnVlO1xyXG4gICAgfVxyXG4gICAgYnJlYWs7XHJcblxyXG4gICAgY2FzZSAncmVhZEJsYWNrTGlzdCc6IHtcclxuICAgICAgdWlUb1NlcmlhbFBlbmRpbmdSZXF1ZXN0LmlzU3BlY2lhbENvbW1hbmQgPSB0cnVlO1xyXG4gICAgICB1aVRvU2VyaWFsUGVuZGluZ1JlcXVlc3QudmFsaWQgPSB0cnVlO1xyXG4gICAgfVxyXG4gICAgYnJlYWs7XHJcblxyXG4gICAgY2FzZSAnYXV0aGVudGljYXRpb25QYXNzd29yZCc6IHtcclxuICAgICAgYXV0aGVudGljYXRvci5ndWlQYXNzID0gcmVxdWVzdERhdGE7XHJcbiAgICB9XHJcbiAgICBicmVhaztcclxuXHJcbiAgICBkZWZhdWx0OlxyXG4gICAgICB0aHJvdyBuZXcgRXJyb3IoJ3VpVG9TZXJpYWxSZXF1ZXN0OiBVbmtub3duIHJlcXVlc3ROYW1lJyk7XHJcbiAgfVxyXG59XHJcblxyXG5hc3luYyBmdW5jdGlvbiBleHBvcnRCbGFja0xpc3RFeGNlbGwgKGJsYWNrTGlzdCkge1xyXG4gIGxldCBibGFja0xpc3RXb3JrYm9va1BhdGggPSBhd2FpdCBwZXJzb25hbEV4Y2VsQXBpLnNlbGVjdEV4Y2VsVG9TYXZlKCk7XHJcbiAgaWYoIWJsYWNrTGlzdFdvcmtib29rUGF0aCkge1xyXG4gICAgcG9wVXBNZXNzYWdlLmRpc3BsYXlQb3BVcChcclxuICAgICAgYNmE2LrZiCDYtNivYCxcclxuICAgICAgYEJMQUNLYFxyXG4gICAgKTtcclxuICAgIFxyXG4gICAgcmV0dXJuO1xyXG4gIH1cclxuXHJcbiAgbGV0IGJsYWNrTGlzdFdvcmtib29rID0gWExTWC51dGlscy5ib29rX25ldygpO1xyXG4gIGxldCBzaGVldCA9IFhMU1gudXRpbHMuYW9hX3RvX3NoZWV0KFxyXG4gICAgYmxhY2tMaXN0Lm1hcCgoZGV2aWNlSWQpID0+IFtkZXZpY2VJZF0pXHJcbiAgKTtcclxuXHJcbiAgWExTWC51dGlscy5ib29rX2FwcGVuZF9zaGVldChibGFja0xpc3RXb3JrYm9vaywgc2hlZXQsICdTaGVldDEnKTtcclxuXHJcbiAgcGVyc29uYWxFeGNlbEFwaS5zYXZlV29ya2Jvb2soYmxhY2tMaXN0V29ya2Jvb2ssIGJsYWNrTGlzdFdvcmtib29rUGF0aCk7XHJcbn1cclxud2luZG93LmV4cG9ydEJsYWNrTGlzdEV4Y2VsbCA9IGV4cG9ydEJsYWNrTGlzdEV4Y2VsbDtcclxuXHJcbmZ1bmN0aW9uIGluaXQgKHNlcmlhbFRvVWlFdmVudENhbGxiYWNrSGFuZGxlKSB7XHJcbiAgc2VyaWFsVG9VaUV2ZW50Q2FsbGJhY2sgPSBzZXJpYWxUb1VpRXZlbnRDYWxsYmFja0hhbmRsZTtcclxuXHJcbiAgc2VyaWFsUnguaW5pdChwYWNrZXRSZWNlaXZlRXZlbnQpO1xyXG4gIHNlcmlhbFR4LmluaXQoKTtcclxuXHJcbiAgdHhDb250cm9sUnVuKCk7XHJcbn1cclxuXHJcbm1vZHVsZS5leHBvcnRzID0ge1xyXG4gIGluaXQsXHJcbiAgcmVnaXN0ZXJDb21Qb3J0U3RpbGxDb25uZWN0ZWRGdW5jdGlvbixcclxuICB1aVRvU2VyaWFsUmVxdWVzdCxcclxufVxyXG5cclxuIiwiJ3VzZSBzdHJpY3QnO1xyXG5cclxuY29uc3QgdG9vbEJveCA9IHJlcXVpcmUoJy4vdG9vbEJveCcpXHJcbmNvbnN0IGNvbmZpZyA9IHJlcXVpcmUoJy4vY29uZmlnJylcclxuY29uc3QgcGVyc29uYWxTZXJpYWxQb3J0ID0gcmVxdWlyZSgnLi9wZXJzb25hbFNlcmlhbFBvcnQnKVxyXG5cclxubGV0IHJ4Qnl0ZXNJbnRlcnZhbFRocmVhZCA9IHRvb2xCb3gudGhyZWFkVGltZXJGYWN0b3J5RnVuYygpO1xyXG5sZXQgcnhCdWZmZXIgPSBbXTtcclxubGV0IHBhY2tldFJlY2VpdmVDYWxsYmFja0V2ZW50ID0gbnVsbDtcclxuXHJcbmxldCBtYW5hZ2VtZW50SGVhZGVyRGV0ZWN0b3IgPSB0b29sQm94LnNlcXVlbmNlRGV0ZWN0b3JGYWN0b3J5RnVuYyhcclxuICB0b29sQm94LnN0cmluZ1RvQXNjaWlBcnJheShjb25maWcuc2VyaWFsLk1BTkFHRU1FTlRfUEFDS0VUX0hFQURFUilcclxuKTtcclxuXHJcbi8qXHJcbuKVlOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVl1xyXG7ilZEgTUNVIHRvIFBDIFBhY2tldCBTdHJ1Y3R1cmUgLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tIOKVkVxyXG7ilaDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilabilZDilZDilZDilZDilZDilZDilZDilZDilaTilZDilZDilZDilZDilZDilZDilZDilZDilZDilaTilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilaTilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilaTilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilaTilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilaNcclxu4pWRIFBhY2tldCBTZWN0aW9uIOKWuiDilZEgSGVhZGVyIOKUgiBDb21tYW5kIOKUgiAgIERhdGEgU2l6ZSAgIOKUgiAgICBEYXRhICAgICDilIIgQXV0aGVudGljYXRpb24gUGFja2V0IOKUgiAgIENoZWNrc3VtICAgIOKVkVxyXG7ilaDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilZDilaPilIDilIDilIDilIDilIDilIDilIDilIDilLzilIDilIDilIDilIDilIDilIDilIDilIDilIDilLzilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilLzilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilLzilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilLzilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilIDilZFcclxu4pWRIE51bSBvZiBieXRlcyAgIOKWuiDilZEgICA0ICAgIOKUgiAgICAxICAgIOKUgiAgICAgICAyICAgICAgIOKUgiBcIkRhdGEgU2l6ZVwiIOKUgiAgICAgICAgICAzMiAgICAgICAgICAg4pSCICAgICAgIDEgICAgICAg4pWRXHJcbuKVoOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVo+KUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUvOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUvOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUvOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUvOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUvOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKUgOKVkVxyXG7ilZEgRGVzY3JpcHRpb24gICAg4pa6IOKVkSAgICAgICAg4pSCICAgICAgICAg4pSCIExpdHRsZSBFbmRpYW4g4pSCICAgICAgICAgICAgIOKUgiAgICAgICAgICAgICAgICAgICAgICAg4pSCIExpdHRsZSBFbmRpYW4g4pWRXHJcbuKVmuKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVqeKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVp+KVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVp+KVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVp+KVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVp+KVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVp+KVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVkOKVnVxyXG4qL1xyXG5sZXQgcnhQYWNrZXRIYW5kbGVyID0ge1xyXG4gIHN0YXRlOiAnaGVhZGVyJyxcclxuICBpbmRleDogMCxcclxuICBwYWNrZXRCdWZmZXI6IHt9LFxyXG4gIHJ4UmF3QXJyYXk6IFtdLFxyXG5cclxuICBoYW5kbGVOZXdCeXRlKG5ld0J5dGUpIHtcclxuICAgIHRoaXMucnhSYXdBcnJheS5wdXNoKG5ld0J5dGUpO1xyXG5cclxuICAgIHN3aXRjaCh0aGlzLnN0YXRlKSB7XHJcbiAgICAgIGNhc2UgJ2hlYWRlcic6XHJcbiAgICAgICAgYnJlYWs7XHJcblxyXG4gICAgICBjYXNlICdjb21tYW5kJzpcclxuICAgICAgICB0aGlzLnBhY2tldEJ1ZmZlci5jb21tYW5kID0gbmV3Qnl0ZTtcclxuICAgICAgICB0aGlzLmdvVG9TdGF0ZSgnZGF0YVNpemUnKTtcclxuICAgICAgICBicmVhaztcclxuXHJcbiAgICAgIGNhc2UgJ2RhdGFTaXplJzpcclxuICAgICAgICB0aGlzLnBhY2tldEJ1ZmZlci5kYXRhU2l6ZSArPSAobmV3Qnl0ZSA8PCAoOCAqIHRoaXMuaW5kZXgpKTtcclxuICAgICAgICB0aGlzLmluZGV4Kys7XHJcblxyXG4gICAgICAgIGlmKHRoaXMuaW5kZXggPT09IDIpIHtcclxuICAgICAgICAgIGlmKHRoaXMucGFja2V0QnVmZmVyLmRhdGFTaXplICE9PSAwKSB7XHJcbiAgICAgICAgICAgIHRoaXMuZ29Ub1N0YXRlKCdkYXRhJyk7XHJcbiAgICAgICAgICB9IGVsc2Uge1xyXG4gICAgICAgICAgICB0aGlzLmdvVG9TdGF0ZSgnc2Vzc2lvblBhY2tldCcpO1xyXG4gICAgICAgICAgfVxyXG4gICAgICAgIH1cclxuICAgICAgICBicmVhaztcclxuXHJcbiAgICAgIGNhc2UgJ2RhdGEnOlxyXG4gICAgICAgIHRoaXMucGFja2V0QnVmZmVyLmRhdGEucHVzaChuZXdCeXRlKTtcclxuICAgICAgICB0aGlzLmluZGV4Kys7XHJcblxyXG4gICAgICAgIGlmKHRoaXMuaW5kZXggPT09IHRoaXMucGFja2V0QnVmZmVyLmRhdGFTaXplKSB7XHJcbiAgICAgICAgICB0aGlzLmdvVG9TdGF0ZSgnc2Vzc2lvblBhY2tldCcpO1xyXG4gICAgICAgIH1cclxuICAgICAgICBicmVhaztcclxuXHJcbiAgICAgIGNhc2UgJ3Nlc3Npb25QYWNrZXQnOlxyXG4gICAgICAgIHRoaXMucGFja2V0QnVmZmVyLnNlc3Npb25QYWNrZXQucHVzaChuZXdCeXRlKTtcclxuICAgICAgICB0aGlzLmluZGV4Kys7XHJcblxyXG4gICAgICAgIGlmKHRoaXMuaW5kZXggPT09IDMyKSB7XHJcbiAgICAgICAgICB0aGlzLmdvVG9TdGF0ZSgnY2hlY2tzdW0nKTtcclxuICAgICAgICB9XHJcbiAgICAgICAgYnJlYWs7XHJcblxyXG4gICAgICBjYXNlICdjaGVja3N1bSc6XHJcbiAgICAgICAgdGhpcy5wYWNrZXRCdWZmZXIuY2hlY2tzdW0gKz0gKG5ld0J5dGUgPDwgKDggKiB0aGlzLmluZGV4KSk7XHJcbiAgICAgICAgdGhpcy5pbmRleCsrO1xyXG4gICAgICAgIFxyXG4gICAgICAgIHRoaXMuaGFuZGxlUGFja2V0RmluaXNoZWQoKTtcclxuICAgICAgICBicmVhaztcclxuXHJcbiAgICAgIGRlZmF1bHQ6XHJcbiAgICAgICAgY29uc29sZS5sb2coYFdIQVQgVEhFIEhFTEwgSVMgVEhJUyByeFBhY2tldEhhbmRsZXIuc3RhdGU6ICR7dGhpcy5zdGF0ZX1gKTtcclxuICAgICAgICBicmVhaztcclxuICAgIH1cclxuXHJcbiAgICBpZihtYW5hZ2VtZW50SGVhZGVyRGV0ZWN0b3IuY2hlY2tGb3JTZXF1ZW5jZShuZXdCeXRlKSkge1xyXG4gICAgICB0aGlzLnJ4UmF3QXJyYXkgPSBbLi4udG9vbEJveC5zdHJpbmdUb0FzY2lpQXJyYXkoY29uZmlnLnNlcmlhbC5NQU5BR0VNRU5UX1BBQ0tFVF9IRUFERVIpXTtcclxuICAgICAgdGhpcy5wYWNrZXRCdWZmZXIgPSB7XHJcbiAgICAgICAgaGVhZGVyOiBbLi4udG9vbEJveC5zdHJpbmdUb0FzY2lpQXJyYXkoY29uZmlnLnNlcmlhbC5NQU5BR0VNRU5UX1BBQ0tFVF9IRUFERVIpXSxcclxuICAgICAgICBjb21tYW5kOiAwLFxyXG4gICAgICAgIGRhdGFTaXplOiAwLFxyXG4gICAgICAgIGRhdGE6IFtdLFxyXG4gICAgICAgIHNlc3Npb25QYWNrZXQ6IFtdLFxyXG4gICAgICAgIGNoZWNrc3VtOiAwLFxyXG4gICAgICB9O1xyXG4gICAgICB0aGlzLmdvVG9TdGF0ZSgnY29tbWFuZCcpO1xyXG4gICAgfVxyXG4gIH0sXHJcblxyXG4gIGhhbmRsZVBhY2tldEZpbmlzaGVkKCkge1xyXG4gICAgbGV0IGV4cGVjdGVkQ2hlY2tzdW0gPSB0aGlzLnJ4UmF3QXJyYXkuc2xpY2UoMCwgLTEpLnJlZHVjZSgoY3VyciwgbmV4dCkgPT4gY3VyciArIG5leHQpO1xyXG4gICAgZXhwZWN0ZWRDaGVja3N1bSAmPSAweEZGO1xyXG5cclxuICAgIGlmKGV4cGVjdGVkQ2hlY2tzdW0gPT0gdGhpcy5wYWNrZXRCdWZmZXIuY2hlY2tzdW0pIHtcclxuICAgICAgaWYocGFja2V0UmVjZWl2ZUNhbGxiYWNrRXZlbnQgIT09IG51bGwpIHtcclxuICAgICAgICBwYWNrZXRSZWNlaXZlQ2FsbGJhY2tFdmVudCh0aGlzLnBhY2tldEJ1ZmZlci5jb21tYW5kLCB0aGlzLnBhY2tldEJ1ZmZlci5kYXRhLCB0aGlzLnBhY2tldEJ1ZmZlci5zZXNzaW9uUGFja2V0KTtcclxuICAgICAgfVxyXG4gICAgfSBlbHNlIHtcclxuICAgICAgY29uc29sZS5sb2coJ05ldyBQYWNrZXQ6Jyk7XHJcbiAgICAgIGNvbnNvbGUubG9nKHRoaXMucnhSYXdBcnJheSk7XHJcbiAgICAgIGNvbnNvbGUubG9nKHRvb2xCb3gudG9IZXhTdHJpbmcodGhpcy5yeFJhd0FycmF5LCAnICcpKTtcclxuICAgICAgY29uc29sZS5sb2coYCVjV3JvbmcgQ2hlY2t1bSAhISFgLCAnY29sb3I6IHdoaXRlOyBiYWNrZ3JvdW5kOiByZWQ7Jyk7XHJcbiAgICAgIGNvbnNvbGUubG9nKGBSZWNlaXZlZCBDaGVja3VtID0gJHt0aGlzLnBhY2tldEJ1ZmZlci5jaGVja3N1bX1gKTtcclxuICAgICAgY29uc29sZS5sb2coYEV4cGVjdGVkIENoZWNrdW0gPSAke2V4cGVjdGVkQ2hlY2tzdW19ICAgICR7dG9vbEJveC50b0hleFN0cmluZyh0b29sQm94LmludFRvQXJyYXkoZXhwZWN0ZWRDaGVja3N1bSwgMSwgZmFsc2UsIHRydWUpLCAnICcpfWApO1xyXG4gICAgICBjb25zb2xlLmxvZygnUGFja2V0JywgdG9vbEJveC50b0hleFN0cmluZyhyeEJ1ZmZlciwgJyAnKSk7XHJcbiAgICAgIGNvbnNvbGUubG9nKHRoaXMucGFja2V0QnVmZmVyKTtcclxuICAgIH1cclxuICAgIFxyXG4gICAgcnhCdWZmZXIgPSBbXTtcclxuICAgIHRoaXMucmVzZXQoKTtcclxuICB9LFxyXG5cclxuICBnb1RvU3RhdGUobmV3U3RhdGUpIHtcclxuICAgIHRoaXMuc3RhdGUgPSBuZXdTdGF0ZTtcclxuICAgIHRoaXMuaW5kZXggPSAwO1xyXG4gIH0sXHJcblxyXG4gIHJlc2V0KCkge1xyXG4gICAgdGhpcy5nb1RvU3RhdGUoJ2hlYWRlcicpO1xyXG4gIH0sXHJcblxyXG4gIGhhbmRsZVRpbWVvdXQoKSB7XHJcblxyXG4gIH1cclxufVxyXG5cclxuZnVuY3Rpb24gc2VyaWFsUnhDYWxsYmFja0Z1bmN0aW9uKGRhdGFCeXRlKSB7XHJcbiAgcnhCdWZmZXIucHVzaChkYXRhQnl0ZSk7XHJcbiAgcnhCeXRlc0ludGVydmFsVGhyZWFkLnNldE5leHRJbnRlcnZhbChjb25maWcuc2VyaWFsLk1BWF9SWF9CWVRFX0lOVEVSVkFMKTtcclxuICBcclxuICByeFBhY2tldEhhbmRsZXIuaGFuZGxlTmV3Qnl0ZShkYXRhQnl0ZSk7XHJcbn1cclxuXHJcbmZ1bmN0aW9uIGluaXQocGFja2V0UmVjZWl2ZUNhbGxiYWNrKSB7XHJcbiAgcGFja2V0UmVjZWl2ZUNhbGxiYWNrRXZlbnQgPSBwYWNrZXRSZWNlaXZlQ2FsbGJhY2s7XHJcbiAgXHJcbiAgc2V0SW50ZXJ2YWwoKCkgPT4ge1xyXG4gICAgaWYocnhCeXRlc0ludGVydmFsVGhyZWFkLnRpbWVQYXNzZWQoKSAmJiByeEJ1ZmZlci5sZW5ndGgpIHtcclxuICAgICAgcnhQYWNrZXRIYW5kbGVyLmhhbmRsZVRpbWVvdXQoKTtcclxuICAgIH1cclxuICB9LCBjb25maWcuc2VyaWFsLk1BWF9SWF9CWVRFX0lOVEVSVkFMKTtcclxuXHJcbiAgcGVyc29uYWxTZXJpYWxQb3J0LnNldFJ4Q2FsbGJhY2tGdW5jdGlvbihzZXJpYWxSeENhbGxiYWNrRnVuY3Rpb24pO1xyXG59XHJcblxyXG5mdW5jdGlvbiBzZXRHdWlCYXVkUmF0ZSAoYmF1ZFJhdGUpIHtcclxuICBjb25zb2xlLmxvZyhgc2V0R3VpQmF1ZFJhdGUgKCR7YmF1ZFJhdGV9KWApO1xyXG4gIHBlcnNvbmFsU2VyaWFsUG9ydC5zZXRCYXVkUmF0ZShiYXVkUmF0ZSk7XHJcbn1cclxuXHJcbm1vZHVsZS5leHBvcnRzID0ge1xyXG4gIGluaXQsXHJcbiAgc2VyaWFsUnhDYWxsYmFja0Z1bmN0aW9uLFxyXG4gIHNldEd1aUJhdWRSYXRlLFxyXG59XHJcblxyXG4iLCIndXNlIHN0cmljdCc7XHJcblxyXG5jb25zdCB0b29sQm94ID0gcmVxdWlyZSgnLi90b29sQm94JylcclxuY29uc3QgY29uZmlnID0gcmVxdWlyZSgnLi9jb25maWcnKVxyXG5jb25zdCBwZXJzb25hbFNlcmlhbFBvcnQgPSByZXF1aXJlKCcuL3BlcnNvbmFsU2VyaWFsUG9ydCcpXHJcbmNvbnN0IHBlcnNvbmFsSGFzaCA9IHJlcXVpcmUoJy4vcGVyc29uYWxIYXNoJylcclxuXHJcbmNvbnN0IEdVSV9BVVRIRU5USUNBVElPTl9IQVNIX0tFWSA9IHRvb2xCb3guc3RyaW5nVG9Bc2NpaUFycmF5KFxyXG4gIGNvbmZpZy5zZXJpYWwuR1VJX0FVVEhFTlRJQ0FUSU9OX0hBU0hfS0VZXHJcbik7XHJcblxyXG5hc3luYyBmdW5jdGlvbiBzZW5kUGFja2V0QXJyYXkgKHBhY2tldEFycmF5LCBjb25zb2xlUHJpbnQ9ZmFsc2UpIHtcclxuICBpZihjb25zb2xlUHJpbnQpIHtcclxuICAgIGNvbnNvbGUubG9nKFxyXG4gICAgICBgJWNUWCBQYWNrZXQgKEhFWClbMDoke3BhY2tldEFycmF5Lmxlbmd0aH1dOiAke3Rvb2xCb3gudG9IZXhTdHJpbmcocGFja2V0QXJyYXksICcgJyl9YCxcclxuICAgICAgJ2NvbG9yOiB3aGl0ZTsgYmFja2dyb3VuZDogYmxhY2s7IGZvbnQtc2l6ZToxLjJlbTsnLFxyXG4gICAgKTtcclxuICB9XHJcblxyXG4gIGlmKCFwZXJzb25hbFNlcmlhbFBvcnQuaXNPcGVuKCkpIHtcclxuICAgIGNvbnNvbGUud2FybignU2VyaWFsIFBvcnQgaXMgQ2xvc2VkJylcclxuICAgIHJldHVybjtcclxuICB9XHJcblxyXG4gIHBlcnNvbmFsU2VyaWFsUG9ydC53cml0ZShwYWNrZXRBcnJheSk7XHJcbn1cclxuXHJcbmZ1bmN0aW9uIGluaXQgKCkge1xyXG5cclxufVxyXG5cclxuZnVuY3Rpb24gY3JlYXRlQW5kU2VuZFBhY2tldCAoY29tbWFuZCwgZGF0YT1bXSwgc2Vzc2lvbktleT1bXSwgY29uc29sZVByaW50PWZhbHNlKSB7XHJcbiAgc2VuZFBhY2tldEFycmF5KGNyZWF0ZVBhY2tldChjb21tYW5kLCBkYXRhLCBzZXNzaW9uS2V5KSwgY29uc29sZVByaW50KTtcclxufVxyXG5cclxuZnVuY3Rpb24gY3JlYXRlUGFja2V0IChjb21tYW5kLCBkYXRhPVtdLCBzZXNzaW9uS2V5PVtdKSB7XHJcbiAgLy8gY29uc29sZS5sb2coYGNyZWF0ZVBhY2tldCAoJHtjb21tYW5kfSwgJHtkYXRhfSlgKTtcclxuXHJcbiAgbGV0IHBhY2tldCA9IFtdO1xyXG4gIGxldCBjaGVja3N1bSA9IDA7XHJcbiAgcGFja2V0LnB1c2goLi4udG9vbEJveC5zdHJpbmdUb0FzY2lpQXJyYXkoY29uZmlnLnNlcmlhbC5NQU5BR0VNRU5UX1BBQ0tFVF9IRUFERVIpKTtcclxuICBwYWNrZXQucHVzaChjb21tYW5kKTtcclxuICBwYWNrZXQucHVzaCguLi50b29sQm94LmludFRvQXJyYXkoZGF0YS5sZW5ndGgsIDIsIGZhbHNlKSk7XHJcbiAgcGFja2V0LnB1c2goLi4uZGF0YSk7XHJcblxyXG4gIGlmKHNlc3Npb25LZXkubGVuZ3RoID09PSAwKSB7XHJcbiAgICBsZXQgcmFuZG9tQXJhcnkgPSBbXTtcclxuICAgIGZvcihsZXQgaSA9IDA7IGkgPCAzMjsgaSsrKSB7XHJcbiAgICAgIHJhbmRvbUFyYXJ5LnB1c2godG9vbEJveC5yYW5kb21SYW5nZSgwLCAyNTUpKTtcclxuICAgIH1cclxuICAgIFxyXG4gICAgcGFja2V0LnB1c2goLi4ucmFuZG9tQXJhcnkpO1xyXG4gIH0gZWxzZSB7XHJcbiAgICBsZXQgc2Vzc2lvblBhY2tldCA9IHBlcnNvbmFsSGFzaC5jcmVhdGVIYXNoKFtcclxuICAgICAgLi4ucGFja2V0LFxyXG4gICAgICAuLi5zZXNzaW9uS2V5XHJcbiAgICBdKTtcclxuICAgIC8vIGNvbnNvbGUubG9nKFxyXG4gICAgLy8gICBgJWNzZXNzaW9uUGFja2V0OiAke3Rvb2xCb3gudG9IZXhTdHJpbmcoc2Vzc2lvblBhY2tldCwgJyAnKX1gLFxyXG4gICAgLy8gICAnY29sb3I6d2hpdGU7IGJhY2tncm91bmQ6YmxhY2s7IGZvbnQtc2l6ZToycmVtOyBwYWRkaW5nOiAuNXJlbTsnLFxyXG4gICAgLy8gKTtcclxuXHJcbiAgICBwYWNrZXQucHVzaCguLi5zZXNzaW9uUGFja2V0KTtcclxuICB9XHJcbiAgXHJcbiAgY2hlY2tzdW0gPSBwYWNrZXQucmVkdWNlKChjdXJyLCBuZXh0KSA9PiBjdXJyICsgbmV4dCk7XHJcbiAgY2hlY2tzdW0gJj0gMHhGRjtcclxuXHJcbiAgcGFja2V0LnB1c2goY2hlY2tzdW0pO1xyXG5cclxuICByZXR1cm4gcGFja2V0O1xyXG59XHJcblxyXG5tb2R1bGUuZXhwb3J0cyA9IHtcclxuICBpbml0LFxyXG4gIHNlbmRQYWNrZXRBcnJheSxcclxuICBjcmVhdGVBbmRTZW5kUGFja2V0LFxyXG4gIGNyZWF0ZVBhY2tldCxcclxufVxyXG5cclxuIiwiJ3VzZSBzdHJpY3QnO1xyXG5cclxuZnVuY3Rpb24gcmFuZG9tUmFuZ2UobWluLCBtYXgpIHtcclxuXHRyZXR1cm4gTWF0aC5mbG9vcihNYXRoLnJhbmRvbSgpICogKG1heCAtIG1pbiArIDEpKSArIG1pbjtcclxufVxyXG5cclxuZnVuY3Rpb24gbWFwVmFsdWUoaW5WYWx1ZSwgaW5NaW4sIGluTWF4LCBvdXRNaW4sIG91dE1heCkge1xyXG4gIHJldHVybiAoaW5WYWx1ZSAtIGluTWluKSAqIChvdXRNYXggLSBvdXRNaW4pIC8gKGluTWF4IC0gaW5NaW4pICsgb3V0TWluO1xyXG59XHJcblxyXG5mdW5jdGlvbiBjb25zdHJhaW5WYWx1ZShpblZhbHVlLCBtaW4sIG1heCkge1xyXG4gIGlmKGluVmFsdWUgPCBtaW4pIHtcclxuICAgIHJldHVybiBtaW47XHJcbiAgfVxyXG4gIFxyXG4gIGlmKGluVmFsdWUgPiBtYXgpIHtcclxuICAgIHJldHVybiBtYXg7XHJcbiAgfVxyXG4gIFxyXG4gIHJldHVybiBpblZhbHVlO1xyXG59XHJcblxyXG5mdW5jdGlvbiB0b0hleFN0cmluZyhieXRlQXJyYXksIHNlcGFyYXRvcj0nJykge1xyXG4gIHJldHVybiBBcnJheS5mcm9tKGJ5dGVBcnJheSwgKGJ5dGUpID0+IHtcclxuICAgIHJldHVybiAoJzAnICsgKGJ5dGUgJiAweEZGKS50b1N0cmluZygxNikpLnNsaWNlKC0yKS50b1VwcGVyQ2FzZSgpO1xyXG4gIH0pLmpvaW4oc2VwYXJhdG9yKVxyXG59XHJcblxyXG5mdW5jdGlvbiBmcm9tSGV4U3RyaW5nKGhleFN0cmluZywgc2VwYXJhdG9yPScnKSB7XHJcbiAgaGV4U3RyaW5nID0gaGV4U3RyaW5nLnNwbGl0KHNlcGFyYXRvcikuam9pbignJyk7XHJcbiAgXHJcbiAgcmV0dXJuIChbLi4uVWludDhBcnJheS5mcm9tKFxyXG4gICAgaGV4U3RyaW5nLm1hdGNoKC8uezEsMn0vZykubWFwKChieXRlKSA9PiBwYXJzZUludChieXRlLCAxNikpXHJcbiAgKV0pO1xyXG59XHJcblxyXG5mdW5jdGlvbiBkZWVwQ2xvbmUob2JqKSB7XHJcbiAgcmV0dXJuIEpTT04ucGFyc2UoSlNPTi5zdHJpbmdpZnkob2JqKSk7XHJcbn1cclxuXHJcbmZ1bmN0aW9uIGFycmF5NFRvRmxvYXQzMihhcnJheTQsIGxpdHRsZUVuZGlhbj10cnVlKSB7XHJcbiAgaWYoIWxpdHRsZUVuZGlhbikge1xyXG4gICAgYXJyYXk0LnJldmVyc2UoKTtcclxuICB9XHJcblxyXG4gIGxldCB1aW50OEFycmF5ID0gbmV3IFVpbnQ4QXJyYXkoYXJyYXk0KTtcclxuICBsZXQgcmVzdWx0ID0gKG5ldyBGbG9hdDMyQXJyYXkodWludDhBcnJheS5idWZmZXIpKVswXTtcclxuXHJcbiAgcmV0dXJuIHJlc3VsdDtcclxufVxyXG5cclxuZnVuY3Rpb24gYXJyYXk4VG9GbG9hdDY0KGFycmF5OCwgbGl0dGxlRW5kaWFuPXRydWUpIHtcclxuICBpZighbGl0dGxlRW5kaWFuKSB7XHJcbiAgICBhcnJheTgucmV2ZXJzZSgpO1xyXG4gIH1cclxuXHJcbiAgbGV0IHVpbnQ4QXJyYXkgPSBuZXcgVWludDhBcnJheShhcnJheTgpO1xyXG4gIGxldCByZXN1bHQgPSAobmV3IEZsb2F0NjRBcnJheSh1aW50OEFycmF5LmJ1ZmZlcikpWzBdO1xyXG5cclxuICByZXR1cm4gcmVzdWx0O1xyXG59XHJcblxyXG5mdW5jdGlvbiBmbG9hdDMyVG9BcnJheTQoZmxvYXQzMiwgbGl0dGxlRW5kaWFuPXRydWUpIHtcclxuICBsZXQgZmxvYXQzMkJ1ZmZlciA9IG5ldyBGbG9hdDMyQXJyYXkoW2Zsb2F0MzJdKTtcclxuICBsZXQgcmVzdWx0QXJyYXkgPSAobmV3IFVpbnQ4QXJyYXkoZmxvYXQzMkJ1ZmZlci5idWZmZXIpKTtcclxuXHJcbiAgaWYoIWxpdHRsZUVuZGlhbikge1xyXG4gICAgcmVzdWx0QXJyYXkucmV2ZXJzZSgpO1xyXG4gIH1cclxuXHJcbiAgcmV0dXJuIFsuLi5yZXN1bHRBcnJheV07XHJcbn1cclxuXHJcbmZ1bmN0aW9uIGZsb2F0NjRUb0FycmF5OChmbG9hdDY0LCBsaXR0bGVFbmRpYW49dHJ1ZSkge1xyXG4gIGxldCBmbG9hdDY0QnVmZmVyID0gbmV3IEZsb2F0NjRBcnJheShbZmxvYXQ2NF0pO1xyXG4gIGxldCByZXN1bHRBcnJheSA9IChuZXcgVWludDhBcnJheShmbG9hdDY0QnVmZmVyLmJ1ZmZlcikpO1xyXG5cclxuICBpZighbGl0dGxlRW5kaWFuKSB7XHJcbiAgICByZXN1bHRBcnJheS5yZXZlcnNlKCk7XHJcbiAgfVxyXG5cclxuICByZXR1cm4gWy4uLnJlc3VsdEFycmF5XTtcclxufVxyXG5cclxuZnVuY3Rpb24gYXJyYXlUb0ludChhcnIsIHNpZ25lZD1mYWxzZSwgbGl0dGxlRW5kaWFuPXRydWUpIHtcclxuICBsZXQgc2l6ZSA9IGFyci5sZW5ndGg7XHJcbiAgbGV0IHVpbnQ4QXJyYXkgPSBuZXcgVWludDhBcnJheShhcnIpO1xyXG4gIGxldCByZXN1bHQ7XHJcblxyXG4gIGlmKCFsaXR0bGVFbmRpYW4pIHtcclxuICAgIHVpbnQ4QXJyYXkucmV2ZXJzZSgpO1xyXG4gIH1cclxuICBcclxuICBpZihzaWduZWQpIHtcclxuICAgIGlmKHNpemUgPD0gMSkge1xyXG4gICAgICByZXN1bHQgPSAobmV3IEludDhBcnJheSh1aW50OEFycmF5LmJ1ZmZlcikpWzBdO1xyXG4gICAgfSBlbHNlIGlmKHNpemUgPD0gMikge1xyXG4gICAgICByZXN1bHQgPSAobmV3IEludDE2QXJyYXkodWludDhBcnJheS5idWZmZXIpKVswXTtcclxuICAgIH0gZWxzZSBpZihzaXplIDw9IDQpIHtcclxuICAgICAgcmVzdWx0ID0gKG5ldyBJbnQzMkFycmF5KHVpbnQ4QXJyYXkuYnVmZmVyKSlbMF07XHJcbiAgICB9IGVsc2UgaWYoc2l6ZSA8PSA4KSB7XHJcbiAgICAgIHRocm93IG5ldyBFcnJvcihgXCJpbnRUb0FycmF5OiBzaXplID0gJHtzaXplfVwiLCBpcyBub3Qgc3VwcG9ydGVkYCk7XHJcbiAgICB9XHJcbiAgfSBlbHNlIHtcclxuICAgIGlmKHNpemUgPD0gMSkge1xyXG4gICAgICByZXN1bHQgPSAobmV3IFVpbnQ4QXJyYXkodWludDhBcnJheS5idWZmZXIpKVswXTtcclxuICAgIH0gZWxzZSBpZihzaXplIDw9IDIpIHtcclxuICAgICAgcmVzdWx0ID0gKG5ldyBVaW50MTZBcnJheSh1aW50OEFycmF5LmJ1ZmZlcikpWzBdO1xyXG4gICAgfSBlbHNlIGlmKHNpemUgPD0gNCkge1xyXG4gICAgICByZXN1bHQgPSAobmV3IFVpbnQzMkFycmF5KHVpbnQ4QXJyYXkuYnVmZmVyKSlbMF07XHJcbiAgICB9IGVsc2UgaWYoc2l6ZSA8PSA4KSB7XHJcbiAgICAgIHRocm93IG5ldyBFcnJvcihgXCJpbnRUb0FycmF5OiBzaXplID0gJHtzaXplfVwiLCBpcyBub3Qgc3VwcG9ydGVkYCk7XHJcbiAgICB9XHJcbiAgfVxyXG5cclxuICByZXR1cm4gcmVzdWx0O1xyXG59XHJcblxyXG5mdW5jdGlvbiBpbnRUb0FycmF5KG51bSwgc2l6ZSwgc2lnbmVkPWZhbHNlLCBsaXR0bGVFbmRpYW49dHJ1ZSkge1xyXG4gIGxldCByZWZBcnJheTtcclxuICBsZXQgcmVzdWx0O1xyXG4gIFxyXG4gIGlmKHNpZ25lZCkge1xyXG4gICAgaWYoc2l6ZSA8PSAxKSB7XHJcbiAgICAgIHJlZkFycmF5ID0gbmV3IEludDhBcnJheShbbnVtXSk7XHJcbiAgICB9IGVsc2UgaWYoc2l6ZSA8PSAyKSB7XHJcbiAgICAgIHJlZkFycmF5ID0gbmV3IEludDE2QXJyYXkoW251bV0pO1xyXG4gICAgfSBlbHNlIGlmKHNpemUgPD0gNCkge1xyXG4gICAgICByZWZBcnJheSA9IG5ldyBJbnQzMkFycmF5KFtudW1dKTtcclxuICAgIH0gZWxzZSBpZihzaXplIDw9IDgpIHtcclxuICAgICAgdGhyb3cgbmV3IEVycm9yKGBcImludFRvQXJyYXk6IHNpemUgPSAke3NpemV9XCIsIGlzIG5vdCBzdXBwb3J0ZWRgKTtcclxuICAgIH1cclxuICB9IGVsc2Uge1xyXG4gICAgaWYoc2l6ZSA8PSAxKSB7XHJcbiAgICAgIHJlZkFycmF5ID0gbmV3IFVpbnQ4QXJyYXkoW251bV0pO1xyXG4gICAgfSBlbHNlIGlmKHNpemUgPD0gMikge1xyXG4gICAgICByZWZBcnJheSA9IG5ldyBVaW50MTZBcnJheShbbnVtXSk7XHJcbiAgICB9IGVsc2UgaWYoc2l6ZSA8PSA0KSB7XHJcbiAgICAgIHJlZkFycmF5ID0gbmV3IFVpbnQzMkFycmF5KFtudW1dKTtcclxuICAgIH0gZWxzZSBpZihzaXplIDw9IDgpIHtcclxuICAgICAgdGhyb3cgbmV3IEVycm9yKGBcImludFRvQXJyYXk6IHNpemUgPSAke3NpemV9XCIsIGlzIG5vdCBzdXBwb3J0ZWRgKTtcclxuICAgIH1cclxuICB9XHJcblxyXG4gIHJlc3VsdCA9IG5ldyBVaW50OEFycmF5KHJlZkFycmF5LmJ1ZmZlcik7XHJcblxyXG4gIGlmKCFsaXR0bGVFbmRpYW4pIHtcclxuICAgIHJlc3VsdC5yZXZlcnNlKCk7XHJcbiAgfVxyXG5cclxuICByZXR1cm4gWy4uLnJlc3VsdF07XHJcbn1cclxuXHJcbmZ1bmN0aW9uIGJ5dGVBcnJheVRvTnVtKGJ5dGVBcnJheSwgdHlwZT0ndWludDMyJywgbGl0dGxlRW5kaWFuPXRydWUpIHtcclxuICB0eXBlID0gdHlwZS50b0xvd2VyQ2FzZSgpO1xyXG4gIGxldCByZXN1bHQgPSBudWxsO1xyXG5cclxuICBzd2l0Y2godHlwZSkge1xyXG4gICAgY2FzZSAndWludDY0JzpcclxuICAgICAgcmVzdWx0ID0gYXJyYXlUb0ludChieXRlQXJyYXksIGZhbHNlLCBsaXR0bGVFbmRpYW4pO1xyXG4gICAgICBicmVhaztcclxuXHJcbiAgICBjYXNlICdpbnQ2NCc6XHJcbiAgICAgIHJlc3VsdCA9IGFycmF5VG9JbnQoYnl0ZUFycmF5LCB0cnVlLCBsaXR0bGVFbmRpYW4pO1xyXG4gICAgICBicmVhaztcclxuICAgIFxyXG4gICAgY2FzZSAndWludDMyJzpcclxuICAgICAgcmVzdWx0ID0gYXJyYXlUb0ludChieXRlQXJyYXksIGZhbHNlLCBsaXR0bGVFbmRpYW4pO1xyXG4gICAgICBicmVhaztcclxuXHJcbiAgICBjYXNlICdpbnQzMic6XHJcbiAgICAgIHJlc3VsdCA9IGFycmF5VG9JbnQoYnl0ZUFycmF5LCB0cnVlLCBsaXR0bGVFbmRpYW4pO1xyXG4gICAgICBicmVhaztcclxuICAgICAgXHJcbiAgICBjYXNlICd1aW50MTYnOlxyXG4gICAgICByZXN1bHQgPSBhcnJheVRvSW50KGJ5dGVBcnJheSwgZmFsc2UsIGxpdHRsZUVuZGlhbik7XHJcbiAgICAgIGJyZWFrO1xyXG5cclxuICAgIGNhc2UgJ2ludDE2JzpcclxuICAgICAgcmVzdWx0ID0gYXJyYXlUb0ludChieXRlQXJyYXksIHRydWUsIGxpdHRsZUVuZGlhbik7XHJcbiAgICAgIGJyZWFrO1xyXG4gICAgXHJcbiAgICBjYXNlICd1aW50OCc6XHJcbiAgICAgIHJlc3VsdCA9IGFycmF5VG9JbnQoYnl0ZUFycmF5LCBmYWxzZSwgbGl0dGxlRW5kaWFuKTtcclxuICAgICAgYnJlYWs7XHJcblxyXG4gICAgY2FzZSAnaW50OCc6XHJcbiAgICAgIHJlc3VsdCA9IGFycmF5VG9JbnQoYnl0ZUFycmF5LCB0cnVlLCBsaXR0bGVFbmRpYW4pO1xyXG4gICAgICBicmVhaztcclxuXHJcbiAgICBjYXNlICdmbG9hdDMyJzpcclxuICAgIGNhc2UgJ2Zsb2F0JzpcclxuICAgICAgcmVzdWx0ID0gYXJyYXk0VG9GbG9hdDMyKGJ5dGVBcnJheSwgbGl0dGxlRW5kaWFuKTtcclxuICAgICAgYnJlYWs7XHJcblxyXG4gICAgZGVmYXVsdDogdGhyb3cgbmV3IEVycm9yKGB0eXBlIFwiJHt0eXBlfVwiIGlzIHVua25vd24uYCk7XHJcbiAgfVxyXG5cclxuICByZXR1cm4gcmVzdWx0O1xyXG59XHJcblxyXG5mdW5jdGlvbiBudW1Ub0J5dGVBcnJheShudW0sIHR5cGU9J3VpbnQzMicsIGxpdHRsZUVuZGlhbj10cnVlKSB7XHJcbiAgdHlwZSA9IHR5cGUudG9Mb3dlckNhc2UoKTtcclxuICBsZXQgcmVzdWx0ID0gbnVsbDtcclxuXHJcbiAgc3dpdGNoKHR5cGUpIHtcclxuICAgIGNhc2UgJ3VpbnQ2NCc6XHJcbiAgICAgIHJlc3VsdCA9IGludFRvQXJyYXkobnVtLCA4LCBmYWxzZSwgbGl0dGxlRW5kaWFuKTtcclxuICAgICAgYnJlYWs7XHJcblxyXG4gICAgY2FzZSAnaW50NjQnOlxyXG4gICAgICByZXN1bHQgPSBpbnRUb0FycmF5KG51bSwgOCwgdHJ1ZSwgbGl0dGxlRW5kaWFuKTtcclxuICAgICAgYnJlYWs7XHJcbiAgICAgIFxyXG4gICAgY2FzZSAndWludDMyJzpcclxuICAgICAgcmVzdWx0ID0gaW50VG9BcnJheShudW0sIDQsIGZhbHNlLCBsaXR0bGVFbmRpYW4pO1xyXG4gICAgICBicmVhaztcclxuXHJcbiAgICBjYXNlICdpbnQzMic6XHJcbiAgICAgIHJlc3VsdCA9IGludFRvQXJyYXkobnVtLCA0LCB0cnVlLCBsaXR0bGVFbmRpYW4pO1xyXG4gICAgICBicmVhaztcclxuICAgICAgXHJcbiAgICBjYXNlICd1aW50MTYnOlxyXG4gICAgICByZXN1bHQgPSBpbnRUb0FycmF5KG51bSwgMiwgZmFsc2UsIGxpdHRsZUVuZGlhbik7XHJcbiAgICAgIGJyZWFrO1xyXG5cclxuICAgIGNhc2UgJ2ludDE2JzpcclxuICAgICAgcmVzdWx0ID0gaW50VG9BcnJheShudW0sIDIsIHRydWUsIGxpdHRsZUVuZGlhbik7XHJcbiAgICAgIGJyZWFrO1xyXG4gICAgICBcclxuICAgIGNhc2UgJ3VpbnQ4JzpcclxuICAgICAgcmVzdWx0ID0gaW50VG9BcnJheShudW0sIDEsIGZhbHNlLCBsaXR0bGVFbmRpYW4pO1xyXG4gICAgICBicmVhaztcclxuXHJcbiAgICBjYXNlICdpbnQ4JzpcclxuICAgICAgcmVzdWx0ID0gaW50VG9BcnJheShudW0sIDEsIHRydWUsIGxpdHRsZUVuZGlhbik7XHJcbiAgICAgIGJyZWFrO1xyXG5cclxuICAgIGNhc2UgJ2Zsb2F0MzInOlxyXG4gICAgY2FzZSAnZmxvYXQnOlxyXG4gICAgICByZXN1bHQgPSBmbG9hdDMyVG9BcnJheTQobnVtLCBsaXR0bGVFbmRpYW4pO1xyXG4gICAgICBicmVhaztcclxuXHJcbiAgICBkZWZhdWx0OiB0aHJvdyBuZXcgRXJyb3IoYHR5cGUgXCIke3R5cGV9XCIgaXMgdW5rbm93bi5gKTtcclxuICB9XHJcblxyXG4gIHJldHVybiByZXN1bHQ7XHJcbn1cclxuXHJcbmZ1bmN0aW9uIGFzY2lpQXJyYXlVdGY4RGVjb2RlIChhcnJheSkge1xyXG4gIGNvbnN0IHVpbnQ4QXJyYXkgPSBuZXcgVWludDhBcnJheShhcnJheSk7XHJcblxyXG4gIGNvbnN0IGRlY29kZXIgPSBuZXcgVGV4dERlY29kZXIoJ3V0Zi04Jyk7XHJcbiAgY29uc3QgZGVjb2RlZFN0cmluZyA9IGRlY29kZXIuZGVjb2RlKHVpbnQ4QXJyYXkpO1xyXG5cclxuICByZXR1cm4gZGVjb2RlZFN0cmluZztcclxufVxyXG5cclxuZnVuY3Rpb24gYXNjaWlBcnJheVRvU3RyaW5nKGFycmF5KSB7XHJcbiAgLy8gYXJyYXkuc3BsaWNlKGFycmF5LmluZGV4T2YoMCkpO1xyXG4gIC8vIHJldHVybiBTdHJpbmcuZnJvbUNoYXJDb2RlKC4uLmFycmF5KTtcclxuICByZXR1cm4gU3RyaW5nLmZyb21DaGFyQ29kZS5hcHBseShTdHJpbmcsIGFycmF5KVxyXG59XHJcblxyXG5mdW5jdGlvbiBzdHJpbmdUb0FzY2lpQXJyYXkoc3RyKSB7XHJcbiAgcmV0dXJuIHN0clxyXG4gICAgLnNwbGl0KCcnKVxyXG4gICAgLm1hcChjaGFyID0+IGNoYXIuY2hhckNvZGVBdCgwKSk7XHJcbn1cclxuXHJcbmZ1bmN0aW9uIHJvdW5kKG51bSwgZGVjaW1hbHM9bnVsbCkge1xyXG4gIGlmKGRlY2ltYWxzID09PSBudWxsKSB7XHJcbiAgICByZXR1cm4gTWF0aC5yb3VuZChudW0pO1xyXG4gIH1cclxuXHJcbiAgcmV0dXJuIHBhcnNlRmxvYXQobnVtLnRvRml4ZWQoZGVjaW1hbHMpKTtcclxufVxyXG5cclxuZnVuY3Rpb24gZ2V0VGljaygpIHtcclxuICByZXR1cm4gKG5ldyBEYXRlKCkuZ2V0VGltZSgpKTtcclxufVxyXG5cclxuZnVuY3Rpb24gdGhyZWFkVGltZXJGYWN0b3J5RnVuYygpIHtcclxuICBsZXQgbmV3VGhyZWFkID0ge1xyXG4gICAgaW50ZXJ2YWw6IDAsXHJcbiAgICBcclxuICAgIHRpbWVQYXNzZWQoKSB7XHJcbiAgICAgIHJldHVybiAodGhpcy5pbnRlcnZhbCA8PSBnZXRUaWNrKCkpXHJcbiAgICB9LFxyXG4gICAgXHJcbiAgICBzZXROZXh0SW50ZXJ2YWwobmV4dEludGVydmFsKSB7XHJcbiAgICAgIHRoaXMuaW50ZXJ2YWwgPSBnZXRUaWNrKCkgKyBuZXh0SW50ZXJ2YWw7XHJcbiAgICB9LFxyXG4gIH1cclxuXHJcbiAgcmV0dXJuIG5ld1RocmVhZDtcclxufVxyXG5cclxuZnVuY3Rpb24gYXJyYXlzQXJlRXF1YWwoLi4uYXJyYXlzKSB7XHJcbiAgaWYoYXJyYXlzLmxlbmd0aCA8IDIpIHtcclxuICAgIHJldHVybiB0cnVlO1xyXG4gIH1cclxuXHJcbiAgY29uc3QgYXJyVG9KU09OID0gKGFycikgPT4gSlNPTi5zdHJpbmdpZnkoYXJyKTtcclxuXHJcbiAgbGV0IGZpcnN0QXJyYXlTdHJpbmcgPSBhcnJUb0pTT04oYXJyYXlzWzBdKTtcclxuXHJcbiAgbGV0IGZhbHNlUmVzdWx0ID0gYXJyYXlzLnNvbWUoKGFycmF5KSA9PiB7XHJcbiAgICByZXR1cm4gZmlyc3RBcnJheVN0cmluZyAhPT0gYXJyVG9KU09OKGFycmF5KTtcclxuICB9KVxyXG5cclxuICByZXR1cm4gZmFsc2VSZXN1bHQgPyBmYWxzZSA6IHRydWU7XHJcbn1cclxuXHJcbmZ1bmN0aW9uIHNlcXVlbmNlRGV0ZWN0b3JGYWN0b3J5RnVuYyAoc2VxdWVuY2VBcnJheSkge1xyXG4gIGxldCBuZXdPbmplY3QgPSB7XHJcbiAgICBpbmRleDogMCxcclxuICAgIHNlcXVlbmNlQXJyYXk6IFsuLi5zZXF1ZW5jZUFycmF5XSxcclxuXHJcbiAgICByZXNldCgpIHtcclxuICAgICAgdGhpcy5pbmRleCA9IDA7XHJcbiAgICB9LFxyXG5cclxuICAgIGN1cnJlbnRseUV4cGVjdGluZ1ZhbHVlKCkge1xyXG4gICAgICByZXR1cm4gdGhpcy5zZXF1ZW5jZUFycmF5W3RoaXMuaW5kZXhdO1xyXG4gICAgfSxcclxuXHJcbiAgICBjaGVja0ZvclNlcXVlbmNlKG5ld1ZhbHVlKSB7XHJcbiAgICAgIGxldCByZXN1bHQgPSAwO1xyXG5cclxuICAgICAgaWYobmV3VmFsdWUgPT09IHRoaXMuY3VycmVudGx5RXhwZWN0aW5nVmFsdWUoKSkge1xyXG4gICAgICAgIHRoaXMuaW5kZXgrKztcclxuICAgICAgfSBlbHNlIHtcclxuICAgICAgICB0aGlzLnJlc2V0KCk7XHJcbiAgICAgICAgaWYobmV3VmFsdWUgPT09IHRoaXMuY3VycmVudGx5RXhwZWN0aW5nVmFsdWUoKSkge1xyXG4gICAgICAgICAgdGhpcy5pbmRleCsrO1xyXG4gICAgICAgIH1cclxuICAgICAgfVxyXG5cclxuICAgICAgaWYodGhpcy5pbmRleCA9PT0gdGhpcy5zZXF1ZW5jZUFycmF5Lmxlbmd0aCkge1xyXG4gICAgICAgIHRoaXMucmVzZXQoKTtcclxuICAgICAgICByZXN1bHQgPSAxO1xyXG4gICAgICB9XHJcblxyXG4gICAgICByZXR1cm4gcmVzdWx0O1xyXG4gICAgfVxyXG4gIH07XHJcblxyXG4gIHJldHVybiBuZXdPbmplY3Q7XHJcbn1cclxuXHJcbmZ1bmN0aW9uIG51bUFycmF5TWFqb3JpdHlFbGVtZW50IChhcnJheSkge1xyXG4gIGxldCBhcnJDbG9uZSA9IFsuLi5hcnJheV07XHJcbiAgbGV0IG1ham9yaXR5Q291bnQgPSAtSW5maW5pdHk7XHJcbiAgbGV0IG1ham9yaXR5Q291bnRUZW1wID0gLUluZmluaXR5O1xyXG4gIGxldCBtYWpvcml0eUVsZW1lbnQgPSAtSW5maW5pdHk7XHJcbiAgbGV0IG1ham9yaXR5RWxlbWVudFRlbXAgPSAtSW5maW5pdHk7XHJcblxyXG4gIGFyckNsb25lLnNvcnQoZnVuY3Rpb24oYSwgYikge1xyXG4gICAgcmV0dXJuIGEgLSBiO1xyXG4gIH0pO1xyXG5cclxuICBmb3IobGV0IGkgPSAwOyBpIDwgYXJyQ2xvbmUubGVuZ3RoOyBpKyspIHtcclxuICAgIGlmKGFyckNsb25lW2ldICE9PSBtYWpvcml0eUVsZW1lbnRUZW1wKSB7XHJcbiAgICAgIG1ham9yaXR5RWxlbWVudFRlbXAgPSBhcnJDbG9uZVtpXTtcclxuICAgICAgbWFqb3JpdHlDb3VudFRlbXAgPSAxO1xyXG4gICAgfSBlbHNlIHtcclxuICAgICAgbWFqb3JpdHlDb3VudFRlbXArKztcclxuICAgICAgaWYobWFqb3JpdHlDb3VudFRlbXAgPiBtYWpvcml0eUNvdW50KSB7XHJcbiAgICAgICAgbWFqb3JpdHlDb3VudCA9IG1ham9yaXR5Q291bnRUZW1wO1xyXG4gICAgICAgIG1ham9yaXR5RWxlbWVudCA9IG1ham9yaXR5RWxlbWVudFRlbXA7XHJcbiAgICAgIH1cclxuICAgIH1cclxuICB9XHJcblxyXG4gIGlmKG1ham9yaXR5Q291bnQgPT09IC1JbmZpbml0eSkge1xyXG4gICAgbWFqb3JpdHlFbGVtZW50ID0gbWFqb3JpdHlFbGVtZW50VGVtcDtcclxuICAgIG1ham9yaXR5Q291bnQgPSBtYWpvcml0eUNvdW50VGVtcDtcclxuICB9XHJcblxyXG4gIHJldHVybiB7XHJcbiAgICBtYWpvcml0eUVsZW1lbnQsXHJcbiAgICBtYWpvcml0eUNvdW50XHJcbiAgfVxyXG59XHJcblxyXG5mdW5jdGlvbiBudW1BcnJNZWFuIChhcnIpIHtcclxuICBsZXQgc3VtID0gMDtcclxuICBhcnIuZm9yRWFjaCgobnVtKSA9PiB7XHJcbiAgICBzdW0gKz0gbnVtXHJcbiAgfSk7XHJcblxyXG4gIHJldHVybiAoc3VtIC8gYXJyLmxlbmd0aCk7XHJcbn1cclxuXHJcbmZ1bmN0aW9uIHJlcG9wdWxhdGVTZWxlY3RJbnB1dCAoXHJcbiAgZG9tRWxlbWVudFNlbGVjdG9yLFxyXG4gIG5ld09wdGlvbnNcclxuKSB7XHJcbiAgY29uc3Qgc2VsZWN0ID0gZG9jdW1lbnQucXVlcnlTZWxlY3Rvcihkb21FbGVtZW50U2VsZWN0b3IpXHJcblxyXG4gIC8vIGNvbnNvbGUubG9nKCduZXdPcHRpb25zJyk7XHJcbiAgLy8gY29uc29sZS5sb2cobmV3T3B0aW9ucyk7XHJcblxyXG4gIHNlbGVjdC5vcHRpb25zLmxlbmd0aCA9IDA7XHJcblxyXG4gIG5ld09wdGlvbnMuZm9yRWFjaCgob3B0aW9uKSA9PiB7XHJcbiAgICBzZWxlY3Qub3B0aW9uc1tzZWxlY3Qub3B0aW9ucy5sZW5ndGhdID0gbmV3IE9wdGlvbihcclxuICAgICAgb3B0aW9uLnRleHQsXHJcbiAgICAgIG9wdGlvbi52YWx1ZSxcclxuICAgICAgb3B0aW9uLnNlbGVjdGVkLFxyXG4gICAgICBvcHRpb24uc2VsZWN0ZWRcclxuICAgICk7XHJcbiAgfSlcclxufVxyXG5cclxuZnVuY3Rpb24gYnl0ZVRvQmluYXJ5U3RyaW5nIChieXRlVmFsdWUpIHtcclxuICBsZXQgcmVzdWx0ID0gbmV3IEFycmF5KDgpLmZpbGwoMCk7XHJcbiAgbGV0IGluZGV4ID0gNztcclxuICB3aGlsZShieXRlVmFsdWUpIHtcclxuICAgIHJlc3VsdFtpbmRleF0gPSBieXRlVmFsdWUgJiAweDAxO1xyXG4gICAgaW5kZXgtLTtcclxuICAgIGJ5dGVWYWx1ZSA+Pj0gMTtcclxuICB9XHJcblxyXG4gIHJldHVybiByZXN1bHQuam9pbignJyk7XHJcbn1cclxuXHJcbmZ1bmN0aW9uIHJldmVyc2VTdHJpbmcgKHN0cikge1xyXG4gIHJldHVybiBbLi4uc3RyXS5yZXZlcnNlKCkuam9pbignJyk7XHJcbn1cclxuXHJcbmZ1bmN0aW9uIG51bWJlcldpdGhDb21tYXMoeCkge1xyXG4gIHJldHVybiB4LnRvU3RyaW5nKCkucmVwbGFjZSgvXFxCKD89KFxcZHszfSkrKD8hXFxkKSkvZywgXCIsXCIpO1xyXG59XHJcblxyXG5hc3luYyBmdW5jdGlvbiBhc3luY0RlbGF5IChkZWxheVRpbWUpIHtcclxuICByZXR1cm4gbmV3IFByb21pc2UocmVzb2x2ZSA9PiBzZXRUaW1lb3V0KHJlc29sdmUsIGRlbGF5VGltZSkpO1xyXG59XHJcblxyXG5mdW5jdGlvbiBjb3B5VG9DbGlwYm9hcmQodGV4dCkge1xyXG4gIG5hdmlnYXRvci5jbGlwYm9hcmQud3JpdGVUZXh0KHRleHQpLnRoZW4oKCkgPT4ge1xyXG4gICAgICBjb25zb2xlLmxvZyhcIlRleHQgY29waWVkIHRvIGNsaXBib2FyZFwiKTtcclxuICB9KS5jYXRjaCgoZXJyKSA9PiB7XHJcbiAgICAgIGNvbnNvbGUuZXJyb3IoXCJGYWlsZWQgdG8gY29weSB0ZXh0OiBcIiwgZXJyKTtcclxuICB9KTtcclxufVxyXG5cclxuZnVuY3Rpb24gZGVlcENvcHkodGFyZ2V0KSB7XHJcbiAgcmV0dXJuIEpTT04ucGFyc2UoSlNPTi5zdHJpbmdpZnkodGFyZ2V0KSk7O1xyXG59XHJcblxyXG5mdW5jdGlvbiBnZXRGaWVsZE5hbWVCeVZhbHVlKG9iaiwgdGFyZ2V0VmFsdWUpIHtcclxuICBmb3IgKGNvbnN0IFtrZXksIHZhbHVlXSBvZiBPYmplY3QuZW50cmllcyhvYmopKSB7XHJcbiAgICBpZiAodmFsdWUgPT09IHRhcmdldFZhbHVlKSB7XHJcbiAgICAgIHJldHVybiBrZXk7XHJcbiAgICB9XHJcbiAgfVxyXG4gIHJldHVybiBudWxsOyAvLyBSZXR1cm4gbnVsbCBpZiBubyBtYXRjaGluZyB2YWx1ZSBpcyBmb3VuZFxyXG59XHJcblxyXG5mdW5jdGlvbiBkZWVwQ29tcGFyZUFycmF5cyguLi5hcnJheXMpIHtcclxuICBsZXQgcHJldkFycmF5SnNvbiA9IEpTT04uc3RyaW5naWZ5KGFycmF5c1swXSk7XHJcbiAgbGV0IGN1cnJlbnRBcnJheUpzb24gPSBudWxsO1xyXG5cclxuICBmb3IobGV0IGkgPSAxOyBpIDwgYXJyYXlzLmxlbmd0aDsgaSsrKSB7XHJcbiAgICBjdXJyZW50QXJyYXlKc29uID0gSlNPTi5zdHJpbmdpZnkoYXJyYXlzW2ldKTtcclxuXHJcbiAgICBpZihwcmV2QXJyYXlKc29uICE9PSBjdXJyZW50QXJyYXlKc29uKSB7XHJcbiAgICAgIHJldHVybiBmYWxzZTtcclxuICAgIH1cclxuXHJcbiAgICBwcmV2QXJyYXlKc29uID0gY3VycmVudEFycmF5SnNvbjtcclxuICB9XHJcblxyXG4gIHJldHVybiB0cnVlO1xyXG59XHJcblxyXG5tb2R1bGUuZXhwb3J0cyA9IHtcclxuICBkZWVwQ29weSxcclxuICBhcnJheXNBcmVFcXVhbCxcclxuICByYW5kb21SYW5nZSxcclxuICBtYXBWYWx1ZSxcclxuICBjb25zdHJhaW5WYWx1ZSxcclxuICB0b0hleFN0cmluZyxcclxuICBmcm9tSGV4U3RyaW5nLFxyXG4gIGRlZXBDbG9uZSxcclxuICBhcnJheTRUb0Zsb2F0MzIsXHJcbiAgYXJyYXk4VG9GbG9hdDY0LFxyXG4gIGZsb2F0MzJUb0FycmF5NCxcclxuICBmbG9hdDY0VG9BcnJheTgsXHJcbiAgYXJyYXlUb0ludCxcclxuICBpbnRUb0FycmF5LFxyXG4gIGJ5dGVBcnJheVRvTnVtLFxyXG4gIG51bVRvQnl0ZUFycmF5LFxyXG4gIGFzY2lpQXJyYXlVdGY4RGVjb2RlLFxyXG4gIGFzY2lpQXJyYXlUb1N0cmluZyxcclxuICBzdHJpbmdUb0FzY2lpQXJyYXksXHJcbiAgcm91bmQsXHJcbiAgZ2V0VGljayxcclxuICB0aHJlYWRUaW1lckZhY3RvcnlGdW5jLFxyXG4gIHNlcXVlbmNlRGV0ZWN0b3JGYWN0b3J5RnVuYyxcclxuICBudW1BcnJheU1ham9yaXR5RWxlbWVudCxcclxuICBudW1BcnJNZWFuLFxyXG4gIHJlcG9wdWxhdGVTZWxlY3RJbnB1dCxcclxuICBieXRlVG9CaW5hcnlTdHJpbmcsXHJcbiAgcmV2ZXJzZVN0cmluZyxcclxuICBudW1iZXJXaXRoQ29tbWFzLFxyXG4gIGFzeW5jRGVsYXksXHJcbiAgY29weVRvQ2xpcGJvYXJkLFxyXG4gIGdldEZpZWxkTmFtZUJ5VmFsdWUsXHJcbiAgZGVlcENvbXBhcmVBcnJheXMsXHJcbn07XHJcblxyXG4iLCJtb2R1bGUuZXhwb3J0cyA9IHJlcXVpcmUoXCJjaGlsZF9wcm9jZXNzXCIpOyIsIm1vZHVsZS5leHBvcnRzID0gcmVxdWlyZShcImNyeXB0b1wiKTsiLCJtb2R1bGUuZXhwb3J0cyA9IHJlcXVpcmUoXCJlbGVjdHJvblwiKTsiLCJtb2R1bGUuZXhwb3J0cyA9IHJlcXVpcmUoXCJldmVudHNcIik7IiwibW9kdWxlLmV4cG9ydHMgPSByZXF1aXJlKFwiZnNcIik7IiwibW9kdWxlLmV4cG9ydHMgPSByZXF1aXJlKFwib3NcIik7IiwibW9kdWxlLmV4cG9ydHMgPSByZXF1aXJlKFwicGF0aFwiKTsiLCJtb2R1bGUuZXhwb3J0cyA9IHJlcXVpcmUoXCJzdHJlYW1cIik7IiwibW9kdWxlLmV4cG9ydHMgPSByZXF1aXJlKFwidHR5XCIpOyIsIm1vZHVsZS5leHBvcnRzID0gcmVxdWlyZShcInV0aWxcIik7IiwiLy8gVGhlIG1vZHVsZSBjYWNoZVxudmFyIF9fd2VicGFja19tb2R1bGVfY2FjaGVfXyA9IHt9O1xuXG4vLyBUaGUgcmVxdWlyZSBmdW5jdGlvblxuZnVuY3Rpb24gX193ZWJwYWNrX3JlcXVpcmVfXyhtb2R1bGVJZCkge1xuXHQvLyBDaGVjayBpZiBtb2R1bGUgaXMgaW4gY2FjaGVcblx0dmFyIGNhY2hlZE1vZHVsZSA9IF9fd2VicGFja19tb2R1bGVfY2FjaGVfX1ttb2R1bGVJZF07XG5cdGlmIChjYWNoZWRNb2R1bGUgIT09IHVuZGVmaW5lZCkge1xuXHRcdHJldHVybiBjYWNoZWRNb2R1bGUuZXhwb3J0cztcblx0fVxuXHQvLyBDcmVhdGUgYSBuZXcgbW9kdWxlIChhbmQgcHV0IGl0IGludG8gdGhlIGNhY2hlKVxuXHR2YXIgbW9kdWxlID0gX193ZWJwYWNrX21vZHVsZV9jYWNoZV9fW21vZHVsZUlkXSA9IHtcblx0XHQvLyBubyBtb2R1bGUuaWQgbmVlZGVkXG5cdFx0Ly8gbm8gbW9kdWxlLmxvYWRlZCBuZWVkZWRcblx0XHRleHBvcnRzOiB7fVxuXHR9O1xuXG5cdC8vIEV4ZWN1dGUgdGhlIG1vZHVsZSBmdW5jdGlvblxuXHRfX3dlYnBhY2tfbW9kdWxlc19fW21vZHVsZUlkXS5jYWxsKG1vZHVsZS5leHBvcnRzLCBtb2R1bGUsIG1vZHVsZS5leHBvcnRzLCBfX3dlYnBhY2tfcmVxdWlyZV9fKTtcblxuXHQvLyBSZXR1cm4gdGhlIGV4cG9ydHMgb2YgdGhlIG1vZHVsZVxuXHRyZXR1cm4gbW9kdWxlLmV4cG9ydHM7XG59XG5cbiIsImNvbnN0IHBhdGggPSByZXF1aXJlKCdwYXRoJyk7XHJcbmNvbnN0IHsgY29udGV4dEJyaWRnZSB9ID0gcmVxdWlyZSgnZWxlY3Ryb24nKTtcclxuY29uc3Qgc2VyaWFsSW50ZXJmYWNlID0gcmVxdWlyZSgnLi9zcmMvc2VyaWFsSW50ZXJmYWNlJylcclxuY29uc3QgcGVyc29uYWxTZXJpYWxQb3J0ID0gcmVxdWlyZSgnLi9zcmMvcGVyc29uYWxTZXJpYWxQb3J0JylcclxuY29uc3QgcGVyc29uYWxXZWJGcmFtZSA9IHJlcXVpcmUoJy4vc3JjL3BlcnNvbmFsV2ViRnJhbWUnKVxyXG5jb25zdCBwZXJzb25hbEV4Y2VsQXBpID0gcmVxdWlyZSgnLi9zcmMvcGVyc29uYWxFeGNlbEFwaScpXHJcblxyXG5jb250ZXh0QnJpZGdlLmV4cG9zZUluTWFpbldvcmxkKCdwYXRoQVBJJywge1xyXG4gIGpvaW46IHBhdGguam9pbixcclxuICBfX2Rpcm5hbWU6IF9fZGlybmFtZVxyXG59KVxyXG5cclxuY29udGV4dEJyaWRnZS5leHBvc2VJbk1haW5Xb3JsZCgnc2VyaWFsUG9ydEFQSScsICAgeyAuLi5wZXJzb25hbFNlcmlhbFBvcnQgfSk7XHJcbmNvbnRleHRCcmlkZ2UuZXhwb3NlSW5NYWluV29ybGQoJ3dlYkZyYW1lQVBJJywgICAgIHsgLi4ucGVyc29uYWxXZWJGcmFtZSB9KTtcclxuY29udGV4dEJyaWRnZS5leHBvc2VJbk1haW5Xb3JsZCgnZXhjZWwnLCAgICAgICAgICAgeyAuLi5wZXJzb25hbEV4Y2VsQXBpIH0pO1xyXG5jb250ZXh0QnJpZGdlLmV4cG9zZUluTWFpbldvcmxkKCdzZXJpYWxJbnRlcmZhY2UnLCB7IC4uLnNlcmlhbEludGVyZmFjZSB9KTtcclxuXHJcbndpbmRvdy5hZGRFdmVudExpc3RlbmVyKCdET01Db250ZW50TG9hZGVkJywgKCkgPT4ge1xyXG5cclxufSk7XHJcbiJdLCJuYW1lcyI6W10sInNvdXJjZVJvb3QiOiIifQ==