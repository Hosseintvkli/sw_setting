/**
******************************************************************************
* @file           : parameter_tools.h
* @brief          :
* @note           :
* @copyright      : COPYRIGHT© 2023 FaraabinCo
******************************************************************************
* @attention
*
* <h2><center>&copy; Copyright© 2023 FaraabinCo.
* All rights reserved.</center></h2>
*
* This software is licensed under terms that can be found in the LICENSE file
* in the root directory of this software component.
* If no LICENSE file comes with this software, it is provided AS-IS.
*
******************************************************************************
* @verbatim
* @endverbatim
*/

/* Define to prevent recursive inclusion -------------------------------------*/
#ifndef PARAMETER_TOOLS_H
#define PARAMETER_TOOLS_H

#ifdef __cplusplus
extern "C" {
#endif

/* Includes ------------------------------------------------------------------*/
#include "nstdtype.h"

#include "parameter_spec.h"
#include "parameter_tools_config.h"

/* Exported defines ----------------------------------------------------------*/

/**
 * @brief 
 * 
 */
typedef uint8_t parameter_tools_res_t;

#define PARAMETER_TOOLS_RES_OK                                    ((parameter_tools_res_t)0)
#define PARAMETER_TOOLS_RES_ERROR_NULL_PTR                        ((parameter_tools_res_t)1)
#define PARAMETER_TOOLS_RES_ERROR_NO_DATA_EXIST                   ((parameter_tools_res_t)2)
#define PARAMETER_TOOLS_RES_ERROR_PARAMETER_ID_OUT_OF_RANGE       ((parameter_tools_res_t)3)
#define PARAMETER_TOOLS_RES_ERROR_SERIALIZE_FAILED                ((parameter_tools_res_t)4)
#define PARAMETER_TOOLS_RES_ERROR_DESERIALIZE_FAILED              ((parameter_tools_res_t)5)
#define PARAMETER_TOOLS_RES_ERROR_CRC                             ((parameter_tools_res_t)6)
#define PARAMETER_TOOLS_RES_ERROR_UNSUPPORTED_DATA_SIZE           ((parameter_tools_res_t)7)
#define PARAMETER_TOOLS_RES_ERROR_BUFFER_OVERFLOW                 ((parameter_tools_res_t)8)
#define PARAMETER_TOOLS_RES_ERROR_PAYLOAD_NOT_ENABLED             ((parameter_tools_res_t)9)

/**
 * @brief 
 * 
 */
#define PARAMETER_TOOLS_MAXIMUM_FRAME_SIZE \
  (8  /* Extended Header(5bytes) + Header(3bytes)*/ + \
   2  /* Status(2bytes) */ + \
   2  /* DeviceId(2bytes) */ + \
   2  /* ParameterListVersion(2bytes) */ + \
   4  /* SerialNo(4bytes) */ + \
   4  /* TimeStamp(4bytes) */ + \
   4  /* FrameCounter(4bytes) */ + \
   1  /* RawDataUserId(1bytes) */ + \
   2  /* RawDataSize(2bytes) */ + \
   PARAMETER_TOOLS_FRAME_MAX_RAW_DATA_SIZE /* RawData */ + \
   1  /* UserId(1bytes) */ + \
   2  /* PayloadSize(2bytes) */ + \
   (10 /* (ParameterId(2Byte) + Max Primitive Parameter Size(8Bytes))*/ * PARAMETER_TOOLS_FRAME_MAX_PARAMETER_QTY) /* PayloadData */ + \
   2   /* Crc(2Bytes) */)

/**
 * @brief 
 * 
 */
#define PARAMETER_TOOLS_EXTENDED_MINIMUM_SERIALIZED_FRAME_SIZE  8

/* Exported macro ------------------------------------------------------------*/
/**
 * @brief Parameter list access macros
 * 
 */
#define GET_PARAM_VALUE_(parameterId_) \
    (*(ParametersSpec[parameterId_].pValue))

/**
 * @brief 
 * 
 */
#define SET_PARAM_VALUE_(parameterId_, value_) \
    (*(ParametersSpec[parameterId_].pValue) = (value_))

/* Exported types ------------------------------------------------------------*/
/**
 * @brief 
 * 
 */
typedef union {

  struct{
    
    uint16_t DeviceIdParamVerIncluded   : 1;
    uint16_t SerialNoIncluded           : 1;
    uint16_t TimeStampIncluded          : 1;
    uint16_t FrameCounterIncluded       : 1;
    uint16_t RawDataIncluded            : 1;
    uint16_t PayloadIncluded            : 1;
    uint16_t PayloadSelfDescriptive     : 1;
    uint16_t PayloadBasedOnTag          : 1;
    uint16_t Offline                    : 1;
    uint16_t Reserve                    : 7;

  }Bits;

  uint16_t Value;

}uParameterListFrame_Status;

/**
 * @brief 
 * 
 */
typedef struct {

  bool IsTag1Used;

  uint8_t Tag1;

  bool IsTag2Used;

  uint8_t Tag2;

  bool IsTag3Used;

  uint8_t Tag3;

  bool IsTag4Used;

  uint8_t Tag4;

  bool IsTag5Used;

  uint8_t Tag5;

}sParameterListFrame_Tag;

/**
 * @brief 
 * 
 */
typedef struct {

  struct {

    const sParameterSpec *pParameterSpecList;
    
    uint32_t ParameterSpecListQty;

    uint16_t DeviceId_ParameterId;

    uint16_t ParameterListVersion_ParameterId;

    uint16_t SerialNo_ParameterId;

  }DataSource;

  bool IsExtendedHeaderEnable;

  bool IsHeaderEnable;

  bool IsFooterEnable;

  sParameterListFrame_Tag Tags;
  
  uParameterListFrame_Status Status;

  uint32_t TimeStampUs;

  uint32_t FrameCounter;

  uint8_t RawDataUserId;

  uint16_t RawDataSize;

  uint8_t *pRawData;

  uint16_t PayloadDataSize;

  uint8_t *pPayloadData;

  uint8_t PayloadUserId;

  uint16_t PayloadParameterIdList[PARAMETER_TOOLS_FRAME_MAX_PARAMETER_QTY];

}sParameterListFrame;

/**
 * @brief 
 * 
 */
typedef struct {

  uint16_t DeviceId;

  uint16_t ParameterListVersion;

}sParameterListInfo;

/* Exported constants --------------------------------------------------------*/
/* Exported functions prototypes ---------------------------------------------*/
parameter_tools_res_t fParameterFrame_nSerialize(sParameterListFrame *pData, uint8_t *pBuffer, uint32_t bufferSize, uint32_t *pSize);
parameter_tools_res_t fParameterFrame_nSerializePayload(sParameterListFrame *pData, uint8_t *pBuffer, uint32_t bufferSize, uint32_t *pSize);
parameter_tools_res_t fParameterFrame_DeSerialize(sParameterListFrame *pData, uint8_t *pBuffer, uint32_t size);
parameter_tools_res_t fParameterFrame_Query(sParameterListFrame *pData, uint32_t *pSize);
parameter_tools_res_t fParameterFrame_GetDeviceInfo(uint8_t *pBuffer, uint32_t size, sParameterListInfo *pInfo);
parameter_tools_res_t fParameterFrame_ResetParameterIdList(sParameterListFrame *pData);

/* Exported variables --------------------------------------------------------*/
extern uint8_t ParameterListFrame_ExtendedHeader[5];
extern uint8_t ParameterListFrame_Header[3];
extern uint8_t ParameterListFrame_Footer[3];

#ifdef __cplusplus
}
#endif

#endif /* PARAMETER_TOOLS_H */

/************************ © COPYRIGHT FaraabinCo *****END OF FILE****/
