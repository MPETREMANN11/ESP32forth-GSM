\ *************************************
\ define AT SMS commands for ESP32 GSM
\    Filename:      ATcommands.fs
\    Date:          31 jan 2026
\    Updated:       31 jan 2026
\    File Version:  1.0
\    MCU:           ESP32-S3 - ESP32 WROOM
\    Forth:         ESP32forth all versions 7.0.7.+
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ **************************************


RECORDFILE /spiffs/SMScommands.fs

\ Overview of AT Commands According to 3GPP TS 27.005

\ AT+CMGD     DELETE SMS MESSAGE
: AT+CMGD { index delflag -- }
    AT$!  s" +CMGD=" ATappend$
    index   ATappendNum     s" ," ATappend$
    delflag ATappendNum
    .GsmTxBuffer
  ;

\ AT+CMGF     SELECT SMS MESSAGE FORMAT

\ AT+CMGL     LIST SMS MESSAGES FROM PREFERRED STORE

\ AT+CMGR     READ SMS MESSAGE

\ AT+CMGS     SEND SMS MESSAGE

\ AT+CMGW     WRITE SMS MESSAGE TO MEMORY

\ AT+CMSS     SEND SMS MESSAGE FROM STORAGE

\ AT+CNMI     NEW SMS MESSAGE INDICATIONS

\ AT+CPMS     PREFERRED SMS MESSAGE STORAGE

\ AT+CRES     RESTORE SMS SETTINGS

\ AT+CSAS     SAVE SMS SETTINGS

\ AT+CSCA     SMS SERVICE CENTER ADDRESS

\ AT+CSCB     SELECT CELL BROADCAST SMS MESSAGES

\ AT+CSDH     SHOW SMS TEXT MODE PARAMETERS

\ AT+CSMP     SET SMS TEXT MODE PARAMETERS

\ AT+CSMS     SELECT MESSAGE SERVICE

cr ." ..SMScommands.fs loaded"
<EOF>






