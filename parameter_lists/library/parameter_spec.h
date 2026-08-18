/**
******************************************************************************
* @file           : parameter_spec.h
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
#ifndef PARAMETER_SPEC_H
#define PARAMETER_SPEC_H

#ifdef __cplusplus
extern "C" {
#endif

/* Includes ------------------------------------------------------------------*/
#include "nstdtype.h"

/* Exported defines ----------------------------------------------------------*/
/**
 * @brief 
 * 
 */
typedef uint16_t parameter_type_t;

#define PARAMETER_TYPE_NONE        ((parameter_type_t)0)
#define PARAMETER_TYPE_MONITORING  ((parameter_type_t)1)
#define PARAMETER_TYPE_COMMAND     ((parameter_type_t)2)
#define PARAMETER_TYPE_SETTING     ((parameter_type_t)3)

/* Exported macro ------------------------------------------------------------*/
/* Exported types ------------------------------------------------------------*/
/**
 * @brief 
 * 
 */
typedef struct {

  char *pName;

  parameter_type_t Type;

  uint16_t Subgroup;

  uint16_t ValueSize;

  void *pValue;

  uint16_t ModbusAddr;

  uint8_t Tag1;

  uint8_t Tag2;

  uint8_t Tag3;

  uint8_t Tag4;

  uint8_t Tag5;

}sParameterSpec;

/* Exported constants --------------------------------------------------------*/
/* Exported functions prototypes ---------------------------------------------*/
/* Exported variables --------------------------------------------------------*/

#ifdef __cplusplus
}
#endif

#endif /* PARAMETER_SPEC_H */

/************************ © COPYRIGHT FaraabinCo *****END OF FILE****/
