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

9600 serialBegin

cr ." tests.fs loaded"
<EOF>


: tt
    10 ms  s" AT+IPR=9600" serialWrite drop
  ;

9600 serialBegin


tt tt tt tt tt tt


s" AT+IPR?" serialWrite drop
200 ms
GSMInput





\ input from LoRa transmitter
: GSMInput ( -- )
    SerialAvailable if
        GSM_RX maxlen$ nip
        SerialReadBytes
        GSM_RX drop cell - !
    else
        0 GSM_RX drop cell - !
    then
  ;

s" AT+IPR?" serialWrite drop
10 ms
GSMInput

only FORTH


cr ." tests.fs loaded"
<EOF>




