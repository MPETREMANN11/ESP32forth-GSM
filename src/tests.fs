\ *************************************
\ tests for ESP32 GSM
\    Filename:      tests.fs
\    Date:          29 jan 2026
\    Updated:       29 jan 2026
\    File Version:  1.0
\    MCU:           ESP32-S3 - ESP32 WROOM
\    Forth:         ESP32forth all versions 7.0.7.+
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ **************************************


RECORDFILE /spiffs/tests.fs

include /spiffs/assert.fs

9600 serial2.init


also serial
\ test AT
 s" AT" serial2.write
200 ms
GSM_RX 128 Serial2.readBytes  ( a n -- n )

only FORTH


cr ." tests.fs loaded"
<EOF>


also serial

9600 Serial2.begin 100 ms
Serial2.available
GSM_RX 128 Serial2.readBytes  ( a n -- n )

only FORTH

also serial
Serial2.available
only FORTH

also serial
GSM_RX 128 Serial2.readBytes  ( a n -- n )
only FORTH

serial
115200 Serial2.begin        \ initialise UART 2 at 115200 bauds 
Serial2.available .         \ display 0 
S" AT" Serial2.write drop   \ send strint "AT" to UART 
Serial2.available .



