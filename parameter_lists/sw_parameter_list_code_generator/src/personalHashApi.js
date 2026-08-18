'use strict';

const crypto = require('crypto');
const toolBox = require('./toolBox')

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

