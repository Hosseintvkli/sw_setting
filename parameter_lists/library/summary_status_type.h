/**
******************************************************************************
* @file           : summary_status_type.h
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
#ifndef SUMMARY_STATUS_TYPE_H
#define SUMMARY_STATUS_TYPE_H

#ifdef __cplusplus
extern "C" {
#endif

/* Includes ------------------------------------------------------------------*/
#include <stdarg.h>

/* Exported defines ----------------------------------------------------------*/
/* Exported macro ------------------------------------------------------------*/
/* Exported types ------------------------------------------------------------*/

/**
 * @brief 
 * 
 */
typedef union {

  struct {

    uint32_t Active                 : 1;
    uint32_t Enable                 : 1;

    uint32_t ConnectionResult       : 1;
    uint32_t ConnectionRetry        : 3;
    
    uint32_t ConfigResult           : 1;
    uint32_t ConfigRetry            : 3;
    
    uint32_t BootTimeMs             : 8; //ConnectionTime + ConfigTime
    
    uint32_t ReadTimingErrorCounter : 4;

    uint32_t Reserve                : 10;

  }Bits;

  uint32_t Value;

}uChipSummaryStatus;

/**
 * @brief 
 * 
 */
typedef union {

  struct {

    uint16_t LoadStatusAll        : 1;
    uint16_t LoadStatusMemory1    : 1;
    uint16_t LoadStatusMemory2    : 1;
    uint16_t LoadStatusMemory3    : 1;
    uint16_t LoadStatusMemory4    : 1;
    uint16_t LoadStatusMemory5    : 1;
    uint16_t LoadStatusMemory6    : 1;
    uint16_t LoadStatusMemory7    : 1;
    uint16_t LoadStatusMemory8    : 1;
    uint16_t LoadStatusMemory9    : 1;
    uint16_t LoadStatusMemory10   : 1;
    uint16_t LoadStatusMemory11   : 1;
    uint16_t LoadStatusMemory12   : 1;
    uint16_t LoadStatusMemory13   : 1;
    uint16_t LoadStatusMemory14   : 1;
    uint16_t LoadStatusMemory15   : 1;

  }Bits;

  uint16_t Value;

}uLoadMemorySummaryStatus;

/* Exported constants --------------------------------------------------------*/
/* Exported functions prototypes ---------------------------------------------*/
/* Exported variables --------------------------------------------------------*/

#ifdef __cplusplus
}
#endif

#endif /* SUMMARY_STATUS_TYPE_H */

/************************ © COPYRIGHT FaraabinCo *****END OF FILE****/
