/**
 ******************************************************************************
 * @file           : parameter_tools.c
 * @brief          :
 ******************************************************************************
 * @attention
 *
 * Copyright (c) 2026 FaraabinCo.
 * All rights reserved.
 *
 * This software is licensed under terms that can be found in the LICENSE file
 * in the root directory of this software component
 * 
 * https://faraabinco.ir/
 * https://github.com/FaraabinCo
 *
 ******************************************************************************
 * @verbatim
 * 
 * @endverbatim
 */

/* Includes ------------------------------------------------------------------*/
#include "parameter_tools.h"

#include <string.h>
#include "fb_assert.h"
#include "bit_converter.h"
#include "modbus_tools.h"

/* Private define ------------------------------------------------------------*/
/* Private macro -------------------------------------------------------------*/
/**
 * @brief 
 * 
 */
#define MEM_CPY_(pDst_, pSrc_, size_) \
  do { \
    if(copyEnable) { \
      if((index + size_) > bufferSize) { \
        return PARAMETER_TOOLS_RES_ERROR_BUFFER_OVERFLOW; \
      } \
      if((pDst_ != NULL) && (pSrc_ != NULL)) { \
        memcpy(pDst_, pSrc_, size_); \
      } \
    } \
  } while(0)

/**
 * @brief 
 * 
 */
#define MEM_CPY_1BYTE_(pDst_, value_) \
  do { \
    if(copyEnable) { \
      if((index + 1) > bufferSize) { \
          return PARAMETER_TOOLS_RES_ERROR_BUFFER_OVERFLOW; \
      } \
      *(pDst_) = (value_); \
    } \
  } while(0)

/**
 * @brief 
 * 
 */
#define MEM_CPY_2BYTE_(pDst_, value_) \
  do { \
    if(copyEnable) { \
      if((index + 2) > bufferSize) { \
          return PARAMETER_TOOLS_RES_ERROR_BUFFER_OVERFLOW; \
      } \
      uByte2 tmp = {0}; \
      tmp.U16 = (value_); \
      (pDst_)[0] = tmp.Bytes[0]; \
      (pDst_)[1] = tmp.Bytes[1]; \
    } \
  } while(0)

/**
 * @brief 
 * 
 */
#define MEM_CPY_4BYTE_(pDst_, value_) \
  do { \
    if(copyEnable) { \
      if((index + 4) > bufferSize) { \
          return PARAMETER_TOOLS_RES_ERROR_BUFFER_OVERFLOW; \
      } \
      uByte4 tmp = {0}; \
      tmp.U32 = (value_); \
      (pDst_)[0] = tmp.Bytes[0]; \
      (pDst_)[1] = tmp.Bytes[1]; \
      (pDst_)[2] = tmp.Bytes[2]; \
      (pDst_)[3] = tmp.Bytes[3]; \
    } \
  } while(0)

/**
 * @brief 
 * 
 */
#define MEM_CPY_8BYTE_(pDst_, value_) \
  do { \
    if(copyEnable) { \
      if((index + 8) > bufferSize) { \
          return PARAMETER_TOOLS_RES_ERROR_BUFFER_OVERFLOW; \
      } \
      uByte8 tmp = {0}; \
      tmp.U64 = (value_); \
      (pDst_)[0] = tmp.Bytes[0]; \
      (pDst_)[1] = tmp.Bytes[1]; \
      (pDst_)[2] = tmp.Bytes[2]; \
      (pDst_)[3] = tmp.Bytes[3]; \
      (pDst_)[4] = tmp.Bytes[4]; \
      (pDst_)[5] = tmp.Bytes[5]; \
      (pDst_)[6] = tmp.Bytes[6]; \
      (pDst_)[7] = tmp.Bytes[7]; \
    } \
  } while(0)

/* Private typedef -----------------------------------------------------------*/
/* Private variables ---------------------------------------------------------*/
/* Private function prototypes -----------------------------------------------*/
static bool fIsTagMatched(sParameterListFrame *pData, const sParameterSpec *pSpec);
static parameter_tools_res_t fnSerialize(sParameterListFrame *pData,uint8_t *pBuffer, uint32_t bufferSize, uint32_t *pSize, bool copyEnable);
static parameter_tools_res_t fnSerialize_Payload(sParameterListFrame *pData, uint8_t *pBuffer, uint32_t bufferSize, uint32_t *pSize, bool copyEnable);

/* Variables -----------------------------------------------------------------*/
uint8_t ParameterListFrame_ExtendedHeader[5] = {0xFD, 0xFE, 0xFF, 0x55, 0xAA};
uint8_t ParameterListFrame_Header[3] = {0xFA, 0xFB, 0xFC};
uint8_t ParameterListFrame_Footer[3] = {0xFF, 0xFE, 0xFD};

/*
╔══════════════════════════════════════════════════════════════════════════════════╗
║                          ##### Exported Functions #####                          ║
╚══════════════════════════════════════════════════════════════════════════════════╝*/
/**
 * @brief 
 * 
 * @param pData 
 * @param pBuffer 
 * @param pSize 
 * @return parameter_tools_res_t 
 */
parameter_tools_res_t fParameterFrame_nSerialize(sParameterListFrame *pData, uint8_t *pBuffer, uint32_t bufferSize, uint32_t *pSize) {

  ASSERT_NOT_NULL_RETURN_(pData, PARAMETER_TOOLS_RES_ERROR_NULL_PTR);
  ASSERT_NOT_NULL_RETURN_(pBuffer, PARAMETER_TOOLS_RES_ERROR_NULL_PTR);
  ASSERT_NOT_NULL_RETURN_(pSize, PARAMETER_TOOLS_RES_ERROR_NULL_PTR);

  parameter_tools_res_t res = fnSerialize(pData, pBuffer, bufferSize, pSize, true);
  if(res != PARAMETER_TOOLS_RES_OK) {
    return res;
  }

  return PARAMETER_TOOLS_RES_OK;
}

/**
 * @brief 
 * 
 * @param pData 
 * @param pBuffer 
 * @param bufferSize 
 * @param pSize 
 * @return parameter_tools_res_t 
 */
parameter_tools_res_t fParameterFrame_nSerializePayload(sParameterListFrame *pData, uint8_t *pBuffer, uint32_t bufferSize, uint32_t *pSize) {

  ASSERT_NOT_NULL_RETURN_(pData, PARAMETER_TOOLS_RES_ERROR_NULL_PTR);
  ASSERT_NOT_NULL_RETURN_(pBuffer, PARAMETER_TOOLS_RES_ERROR_NULL_PTR);
  ASSERT_NOT_NULL_RETURN_(pSize, PARAMETER_TOOLS_RES_ERROR_NULL_PTR);

  parameter_tools_res_t res = fnSerialize_Payload(pData, pBuffer, bufferSize, pSize, true);
  if(res != PARAMETER_TOOLS_RES_OK) {
    return res;
  }

  return PARAMETER_TOOLS_RES_OK;
}

/**
 * @brief 
 * 
 * @param pData 
 * @param pBuffer 
 * @param size 
 * @return parameter_tools_res_t 
 */
parameter_tools_res_t fParameterFrame_DeSerialize(sParameterListFrame *pData, uint8_t *pBuffer, uint32_t size) {

  ASSERT_NOT_NULL_RETURN_(pData, PARAMETER_TOOLS_RES_ERROR_NULL_PTR);
  ASSERT_NOT_NULL_RETURN_(pBuffer, PARAMETER_TOOLS_RES_ERROR_NULL_PTR);

  uint16_t index = 0;
  uint8_t footerSize = 0;

  if(size < PARAMETER_TOOLS_EXTENDED_MINIMUM_SERIALIZED_FRAME_SIZE) {
    return PARAMETER_TOOLS_RES_ERROR_DESERIALIZE_FAILED;
  }

  if(
      (pBuffer[0] == ParameterListFrame_Header[0]) &&
      (pBuffer[1] == ParameterListFrame_Header[1]) &&
      (pBuffer[2] == ParameterListFrame_Header[2])) {
        
    pData->IsHeaderEnable = 1;
    index += 3;
  }

  if(
      (pBuffer[0] == ParameterListFrame_ExtendedHeader[0]) &&
      (pBuffer[1] == ParameterListFrame_ExtendedHeader[1]) &&
      (pBuffer[2] == ParameterListFrame_ExtendedHeader[2]) &&
      (pBuffer[3] == ParameterListFrame_ExtendedHeader[3]) &&
      (pBuffer[4] == ParameterListFrame_ExtendedHeader[4]) &&
      (pBuffer[5] == ParameterListFrame_Header[0]) &&
      (pBuffer[6] == ParameterListFrame_Header[1]) &&
      (pBuffer[7] == ParameterListFrame_Header[2])) {
        
    pData->IsExtendedHeaderEnable = 1;
    pData->IsHeaderEnable = 1;
    index += 8;
  }

  //Footer
  if(
      (pBuffer[size - 3] == ParameterListFrame_Footer[0]) &&
      (pBuffer[size - 2] == ParameterListFrame_Footer[1]) &&
      (pBuffer[size - 1] == ParameterListFrame_Footer[2])) {
        
    pData->IsFooterEnable = 1;
    footerSize = SIZE_OF_ARRAY_(ParameterListFrame_Footer);
  }
			
	uint16_t crcStartIndex = index; //This index is used for crc calculation

  uint16_t bufferCrc;
  bufferCrc = fBitConverter_ToU16(pBuffer, size - 2);
  uint16_t calculatedCrc = fModbusTools_CRC16(&(pBuffer[crcStartIndex]), size - crcStartIndex - footerSize/*Footer size if exist*/ - 2/*2Bytes Crc*/);
  if(calculatedCrc != bufferCrc) {
    return PARAMETER_TOOLS_RES_ERROR_CRC;
  }

  pData->Status.Value = fBitConverter_ToU16(pBuffer, index);
  index += 2;
  
  if(pData->Status.Bits.DeviceIdParamVerIncluded == 1) {
  
    //DeviceId
    index += 2;

    //ParameterListVersion
    index += 2;
  }

  if(pData->Status.Bits.SerialNoIncluded == 1) {

    *((uint32_t *)pData->DataSource.pParameterSpecList[pData->DataSource.SerialNo_ParameterId].pValue) = fBitConverter_ToU32(pBuffer, index);
    index += 4;
  }

  if(pData->Status.Bits.TimeStampIncluded == 1) {
    
    pData->TimeStampUs = fBitConverter_ToU32(pBuffer, index);
    index += 4;
  }

  if(pData->Status.Bits.FrameCounterIncluded == 1) {
    
    pData->FrameCounter = fBitConverter_ToU32(pBuffer, index);
    index += 4;
  }

  if(pData->Status.Bits.RawDataIncluded == 1) {
    

    pData->RawDataUserId = pBuffer[index];
    index += 1;

    pData->RawDataSize = fBitConverter_ToU16(pBuffer, index);
    index += 2;

    memcpy(pData->pRawData, &(pBuffer[index]), pData->RawDataSize);
    index += pData->RawDataSize;
  }

  //Payload
  if(pData->Status.Bits.PayloadIncluded == 1) {

    pData->PayloadUserId = pBuffer[index];
    index += 1;

    //Skip PayloadSize field
    uint16_t payloadSize = fBitConverter_ToU16(pBuffer, index);
    uint16_t remainPayloadSize = payloadSize;
    index += 2;

    if(pData->Status.Bits.PayloadBasedOnTag == 1) {

      if(!(pData->Tags.IsTag1Used ||
           pData->Tags.IsTag2Used ||
           pData->Tags.IsTag3Used ||
           pData->Tags.IsTag4Used ||
           pData->Tags.IsTag5Used)) {
            return PARAMETER_TOOLS_RES_ERROR_NO_DATA_EXIST;
      }

      for(int i = 0; i < pData->DataSource.ParameterSpecListQty; i++) {

        const sParameterSpec *pSpec = &(pData->DataSource.pParameterSpecList[i]);
        
        if(!fIsTagMatched(pData, pSpec)) {
          continue;
        }

        if(pData->Status.Bits.PayloadSelfDescriptive == 1) {
          index += 2;
        }

        if(pSpec->ValueSize > remainPayloadSize) {
          break;
        }

        memcpy(pSpec->pValue, &pBuffer[index], pSpec->ValueSize);
        index += pSpec->ValueSize;
        remainPayloadSize -= pSpec->ValueSize;
      }

    } else {

      for(int i = 0; i < PARAMETER_TOOLS_FRAME_MAX_PARAMETER_QTY; i++) {

        uint16_t parameterId = pData->PayloadParameterIdList[i];
        const sParameterSpec *pSpec = &(pData->DataSource.pParameterSpecList[parameterId]);

        if(parameterId == PARAMETER_TOOLS_FRAME_PARAMETER_ID_NONE) {
          break;
        }

        if(parameterId >= pData->DataSource.ParameterSpecListQty) {
          return PARAMETER_TOOLS_RES_ERROR_PARAMETER_ID_OUT_OF_RANGE;
        }

        if(pSpec->pValue == NULL) {
          return PARAMETER_TOOLS_RES_ERROR_NO_DATA_EXIST;
        }

        if(pData->Status.Bits.PayloadSelfDescriptive == 1) {
          index += 2;
        }

        if(pSpec->ValueSize > remainPayloadSize) {
          break;
        }

        memcpy(pSpec->pValue, &pBuffer[index], pSpec->ValueSize);
        index += pSpec->ValueSize;
        remainPayloadSize -= pSpec->ValueSize;
      }
    }
  }
  
  return PARAMETER_TOOLS_RES_OK;
}

/**
 * @brief 
 * 
 * @param pData 
 * @param pQty 
 * @param pSize 
 * @return parameter_tools_res_t 
 */
parameter_tools_res_t fParameterFrame_Query(sParameterListFrame *pData, uint32_t *pSize) {

  ASSERT_NOT_NULL_RETURN_(pData, PARAMETER_TOOLS_RES_ERROR_NULL_PTR);
  ASSERT_NOT_NULL_RETURN_(pSize, PARAMETER_TOOLS_RES_ERROR_NULL_PTR);

  uint8_t tempBuffer[1];

  parameter_tools_res_t res = fnSerialize(pData, tempBuffer, 1, pSize, false);
  if(res != PARAMETER_TOOLS_RES_OK) {
    return res;
  }

  return PARAMETER_TOOLS_RES_OK;
}

/**
 * @brief 
 * 
 * @param pData 
 * @param pBuffer 
 * @param size 
 * @param pInfo 
 * @return parameter_tools_res_t 
 */
parameter_tools_res_t fParameterFrame_GetDeviceInfo(uint8_t *pBuffer, uint32_t size, sParameterListInfo *pInfo) {

  ASSERT_NOT_NULL_RETURN_(pInfo, PARAMETER_TOOLS_RES_ERROR_NULL_PTR);

  uint16_t index = 0;
  uint8_t footerSize = 0;
  uParameterListFrame_Status status;

  if(size < PARAMETER_TOOLS_EXTENDED_MINIMUM_SERIALIZED_FRAME_SIZE) {
    return PARAMETER_TOOLS_RES_ERROR_DESERIALIZE_FAILED;
  }

  if(
      (pBuffer[0] == ParameterListFrame_Header[0]) &&
      (pBuffer[1] == ParameterListFrame_Header[1]) &&
      (pBuffer[2] == ParameterListFrame_Header[2])) {
        
    index += 3;
  }

  if(
      (pBuffer[0] == ParameterListFrame_ExtendedHeader[0]) &&
      (pBuffer[1] == ParameterListFrame_ExtendedHeader[1]) &&
      (pBuffer[2] == ParameterListFrame_ExtendedHeader[2]) &&
      (pBuffer[3] == ParameterListFrame_ExtendedHeader[3]) &&
      (pBuffer[4] == ParameterListFrame_ExtendedHeader[4]) &&
      (pBuffer[5] == ParameterListFrame_Header[0]) &&
      (pBuffer[6] == ParameterListFrame_Header[1]) &&
      (pBuffer[7] == ParameterListFrame_Header[2])) {
        
    index += 8;
  }

  //Footer
  if(
      (pBuffer[size - 3] == ParameterListFrame_Footer[0]) &&
      (pBuffer[size - 2] == ParameterListFrame_Footer[1]) &&
      (pBuffer[size - 1] == ParameterListFrame_Footer[2])) {
        
    footerSize = SIZE_OF_ARRAY_(ParameterListFrame_Footer);
  }
			
	uint16_t crcStartIndex = index; //This index is used for crc calculation

  uint16_t bufferCrc;
  bufferCrc = fBitConverter_ToU16(pBuffer, size - 2);
  uint16_t calculatedCrc = fModbusTools_CRC16(&(pBuffer[crcStartIndex]), size - crcStartIndex - footerSize/*Footer size if exist*/ - 2/*2Bytes Crc*/);
  if(calculatedCrc != bufferCrc) {
    return PARAMETER_TOOLS_RES_ERROR_CRC;
  }

  status.Value = fBitConverter_ToU16(pBuffer, index);
  index += 2;

  if(status.Bits.DeviceIdParamVerIncluded == 0) {
    return PARAMETER_TOOLS_RES_ERROR_NO_DATA_EXIST;
  }
  
  pInfo->DeviceId = fBitConverter_ToU16(pBuffer, index);
  index += 2;

  pInfo->ParameterListVersion = fBitConverter_ToU16(pBuffer, index);
  index += 2;

  return PARAMETER_TOOLS_RES_OK;
}

/**
 * @brief 
 * 
 * @param pData 
 * @return parameter_tools_res_t 
 */
parameter_tools_res_t fParameterFrame_ResetParameterIdList(sParameterListFrame *pData) {

  ASSERT_NOT_NULL_RETURN_(pData, PARAMETER_TOOLS_RES_ERROR_NULL_PTR);

  for(int i = 0; i < PARAMETER_TOOLS_FRAME_MAX_PARAMETER_QTY; i++) {
    pData->PayloadParameterIdList[i] = PARAMETER_TOOLS_FRAME_PARAMETER_ID_NONE;
  }

  return PARAMETER_TOOLS_RES_OK;
}

/*
╔══════════════════════════════════════════════════════════════════════════════════╗
║                            ##### Private Functions #####                         ║
╚══════════════════════════════════════════════════════════════════════════════════╝*/
/**
 * @brief 
 * 
 * @param pData 
 * @param pSpec 
 * @return true 
 * @return false 
 */
static bool fIsTagMatched(sParameterListFrame *pData, const sParameterSpec *pSpec) {

  if(pSpec->pValue == NULL) {
    return false;
  }

  if(pData->Tags.IsTag1Used && !(pSpec->Tag1 == pData->Tags.Tag1)) {
    return false;
  }

  if(pData->Tags.IsTag2Used && !(pSpec->Tag2 == pData->Tags.Tag2)) {
    return false;
  }

  if(pData->Tags.IsTag3Used && !(pSpec->Tag3 == pData->Tags.Tag3)) {
    return false;
  }

  if(pData->Tags.IsTag4Used && !(pSpec->Tag4 == pData->Tags.Tag4)) {
    return false;
  }

  if(pData->Tags.IsTag5Used && !(pSpec->Tag5 == pData->Tags.Tag5)) {
    return false;
  }

  return true;
}

/**
 * @brief 
 * 
 * @param pData 
 * @param pBuffer 
 * @param pSize 
 * @return parameter_tools_res_t 
 */
static parameter_tools_res_t fnSerialize(sParameterListFrame *pData, uint8_t *pBuffer, uint32_t bufferSize, uint32_t *pSize, bool copyEnable) {

  ASSERT_NOT_NULL_RETURN_(pData, PARAMETER_TOOLS_RES_ERROR_NULL_PTR);
  ASSERT_NOT_NULL_RETURN_(pBuffer, PARAMETER_TOOLS_RES_ERROR_NULL_PTR);
  ASSERT_NOT_NULL_RETURN_(pSize, PARAMETER_TOOLS_RES_ERROR_NULL_PTR);

  uint16_t index = 0;

  if(pData->IsExtendedHeaderEnable) {

    MEM_CPY_(&(pBuffer[index]), ParameterListFrame_ExtendedHeader, SIZE_OF_ARRAY_(ParameterListFrame_ExtendedHeader));
    index += 5;
  }

  if(pData->IsHeaderEnable) {

    MEM_CPY_(&(pBuffer[index]), ParameterListFrame_Header, SIZE_OF_ARRAY_(ParameterListFrame_Header));
    index += 3;
  }

  uint16_t crcStartIndex = index; //This index is used for crc calculation

  MEM_CPY_2BYTE_(&(pBuffer[index]), pData->Status.Value);
  index += 2;
  
  if(pData->Status.Bits.DeviceIdParamVerIncluded == 1) {

    uint16_t deviceId = *((uint16_t *)pData->DataSource.pParameterSpecList[pData->DataSource.DeviceId_ParameterId].pValue);
    MEM_CPY_2BYTE_(&(pBuffer[index]), deviceId);
    index += 2;

    uint16_t parameterListVer = *((uint16_t *)pData->DataSource.pParameterSpecList[pData->DataSource.ParameterListVersion_ParameterId].pValue);
    MEM_CPY_2BYTE_(&(pBuffer[index]), parameterListVer);
    index += 2;
  }

  if(pData->Status.Bits.SerialNoIncluded == 1) {

    uint32_t serialNo = *((uint32_t *)pData->DataSource.pParameterSpecList[pData->DataSource.SerialNo_ParameterId].pValue);
    MEM_CPY_4BYTE_(&(pBuffer[index]), serialNo);
    index += 4;
  }

  if(pData->Status.Bits.TimeStampIncluded == 1) {
    
    MEM_CPY_4BYTE_(&(pBuffer[index]), pData->TimeStampUs);
    index += 4;
  }

  if(pData->Status.Bits.FrameCounterIncluded == 1) {
    
    MEM_CPY_4BYTE_(&(pBuffer[index]), pData->FrameCounter);
    index += 4;
  }

  if(pData->Status.Bits.RawDataIncluded == 1) {
    
    MEM_CPY_1BYTE_(&(pBuffer[index]), pData->RawDataUserId);
    index += 1;

    MEM_CPY_2BYTE_(&(pBuffer[index]), pData->RawDataSize);
    index += 2;

    MEM_CPY_(&(pBuffer[index]), pData->pRawData, pData->RawDataSize);
    index += pData->RawDataSize;
  }

  //Payload
  if(pData->Status.Bits.PayloadIncluded == 1) {

    MEM_CPY_1BYTE_(&(pBuffer[index]), pData->PayloadUserId);
    index += 1;

    uint32_t payloadSizeIndex = index;

    index += 2; //Skip PayloadSize field

    uint32_t serializedPayloadSize;

    parameter_tools_res_t res = fnSerialize_Payload(pData, &(pBuffer[index]), bufferSize - index, &serializedPayloadSize, copyEnable);
    if(res != PARAMETER_TOOLS_RES_OK) {
      return res;
    }

    index += serializedPayloadSize;

    MEM_CPY_2BYTE_(&(pBuffer[payloadSizeIndex]), serializedPayloadSize);
  }
  
  uint16_t crc;
  if(copyEnable) {
    crc = fModbusTools_CRC16(&(pBuffer[crcStartIndex]), index - crcStartIndex);
  }
  
  MEM_CPY_2BYTE_(&(pBuffer[index]), crc);
  index += 2;

  if(pData->IsFooterEnable) {

    MEM_CPY_(&(pBuffer[index]), ParameterListFrame_Footer, SIZE_OF_ARRAY_(ParameterListFrame_Footer));
    index += 3;
  }

  *pSize = index;

  return PARAMETER_TOOLS_RES_OK;
}

/**
 * @brief 
 * 
 * @param pData 
 * @param pBuffer 
 * @param bufferSize 
 * @param pSize 
 * @param copyEnable 
 * @return parameter_tools_res_t 
 */
static parameter_tools_res_t fnSerialize_Payload(sParameterListFrame *pData,uint8_t *pBuffer, uint32_t bufferSize, uint32_t *pSize, bool copyEnable) {

  ASSERT_NOT_NULL_RETURN_(pData, PARAMETER_TOOLS_RES_ERROR_NULL_PTR);
  ASSERT_NOT_NULL_RETURN_(pBuffer, PARAMETER_TOOLS_RES_ERROR_NULL_PTR);
  ASSERT_NOT_NULL_RETURN_(pSize, PARAMETER_TOOLS_RES_ERROR_NULL_PTR);

  uint16_t index = 0;

  //External payload data
  if(pData->pPayloadData != NULL) {

    MEM_CPY_(&(pBuffer[index]), pData->pPayloadData, pData->PayloadDataSize);
    index += pData->PayloadDataSize;

    *pSize = index;

    return PARAMETER_TOOLS_RES_OK;
  }

  //Tag based payload data
  if(pData->Status.Bits.PayloadBasedOnTag == 1) {

    uint16_t itemsCount = 0;

    if(!(pData->Tags.IsTag1Used ||
        pData->Tags.IsTag2Used ||
        pData->Tags.IsTag3Used ||
        pData->Tags.IsTag4Used ||
        pData->Tags.IsTag5Used)) {
          return PARAMETER_TOOLS_RES_ERROR_NO_DATA_EXIST;
    }

    for(int i = 0; i < pData->DataSource.ParameterSpecListQty; i++) {

      const sParameterSpec *pSpec = &(pData->DataSource.pParameterSpecList[i]);
      
      if(!fIsTagMatched(pData, pSpec)) {
        continue;
      }
      
      if(pData->Status.Bits.PayloadSelfDescriptive == 1) {

        MEM_CPY_2BYTE_(&(pBuffer[index]), i);
        index += 2;
      }
      
      MEM_CPY_(&(pBuffer[index]), pSpec->pValue, pSpec->ValueSize);
      index += pSpec->ValueSize;

      itemsCount += 1;
    }

    if(itemsCount == 0) {
      return PARAMETER_TOOLS_RES_ERROR_NO_DATA_EXIST;
    }

    *pSize = index;

    return PARAMETER_TOOLS_RES_OK;
  }
    
  //Parameter id based payload data
  uint16_t itemsCount = 0;

  for(int i = 0; i < PARAMETER_TOOLS_FRAME_MAX_PARAMETER_QTY; i++) {

    uint16_t parameterId = pData->PayloadParameterIdList[i];

    if(parameterId == PARAMETER_TOOLS_FRAME_PARAMETER_ID_NONE) {
      break;
    }

    if(parameterId >= pData->DataSource.ParameterSpecListQty) {
      return PARAMETER_TOOLS_RES_ERROR_PARAMETER_ID_OUT_OF_RANGE;
    }

    if(pData->DataSource.pParameterSpecList[parameterId].pValue == NULL) {
      return PARAMETER_TOOLS_RES_ERROR_NO_DATA_EXIST;
    }

    if(pData->Status.Bits.PayloadSelfDescriptive == 1) {

      MEM_CPY_2BYTE_(&(pBuffer[index]), parameterId);
      index += 2;
    }
    
    MEM_CPY_(&(pBuffer[index]), pData->DataSource.pParameterSpecList[parameterId].pValue, pData->DataSource.pParameterSpecList[parameterId].ValueSize);
    index += pData->DataSource.pParameterSpecList[parameterId].ValueSize;

    itemsCount += 1;
  }

  if(itemsCount == 0) {
    return PARAMETER_TOOLS_RES_ERROR_NO_DATA_EXIST;
  }

  *pSize = index;

  return PARAMETER_TOOLS_RES_OK;
}

/************************ © COPYRIGHT FaraabinCo *****END OF FILE****/
