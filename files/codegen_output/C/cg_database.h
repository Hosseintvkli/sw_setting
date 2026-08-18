/* Define to prevent recursive inclusion -------------------------------------*/
#ifndef CG_DATABASE_H
#define CG_DATABASE_H

#ifdef __cplusplus
extern "C" {
#endif

/* Includes ------------------------------------------------------------------*/
#include "nstdtype.h"

/* Exported constants --------------------------------------------------------*/
/* Exported defines ----------------------------------------------------------*/
/**
 * @brief 
 * 
 */
typedef uint16_t device_id_t;

#define DEVICE_ID_DATALOGGER_V3_MAIN     ((device_id_t)2)
#define DEVICE_ID_DATALOGGER_V3_SLAVE    ((device_id_t)3)
#define DEVICE_ID_P_IMU_MASTER_V1        ((device_id_t)4)
#define DEVICE_ID_SC_MB_IMU_MASTER_V1P4  ((device_id_t)5)
#define DEVICE_ID_MINI_HOST              ((device_id_t)6)
#define DEVICE_ID_HOST                   ((device_id_t)7)
#define DEVICE_ID_TEST1                  ((device_id_t)1000)
#define DEVICE_ID_TEST2                  ((device_id_t)1001)

/* Exported macro ------------------------------------------------------------*/
/* Exported types (enum, struct, union,...)-----------------------------------*/
/* Exported functions prototypes ---------------------------------------------*/
/* Extern functions ----------------------------------------------------------*/
/* Extern Object or Variable -------------------------------------------------*/

#ifdef __cplusplus
}
#endif

#endif /* CG_DATABASE_H */

/************************ © COPYRIGHT FaraabinCo *****END OF FILE****/

