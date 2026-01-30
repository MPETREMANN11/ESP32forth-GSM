\ *************************************
\ serial exchange with GSM module SIM800L
\    Filename:      main.fs
\    Date:          29 jan 2026
\    Updated:       29 jan 2026
\    File Version:  1.0
\    MCU:           ESP32-S3 | ESP32 WROOM
\    Forth:         ESP32forth all versions 7.0.7.+
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ **************************************

RECORDFILE /spiffs/serialGSM.fs

\ store speed communication
0 value SERIAL2_RATE

\ definition of OUTput and INput buffers
128 string GSM_TX   \ buffer ESP32 -> GSM
128 string GSM_RX   \ buffer GSM   -> ESP32


also serial \ Select Serial vocabulary

ESP32-S3? [IF] 
  : serialBegin  ( bauds -- )
      Serial1.begin
    ;

  : serialAvailable ( -- fl )
      Serial1.available
    ;

  : serialWrite ( addr len -- )
      Serial1.write
    ;
[ELSE]
  : serialBegin  ( bauds -- )
      Serial2.begin
    ;

  : serialAvailable ( -- fl )
      Serial2.available
    ;

  : serialWrite ( addr len -- )
      Serial2.write
    ;
[THEN]



\ initialise Serial2
: SerialGSM.init ( baudRate -- )
    dup to SERIAL_RATE
    SerialBegin
  ;

\ input from GSM module
: GSMinput ( -- )
    serialAvailable if
        GSM_RX maxlen$ nip
        Serial2.readBytes
        GSM_RX drop cell - !
    else
        0 GSM_RX drop cell - !
    then
  ;

only FORTH

cr ." serialGSM.fs loaded"
<EOF>

