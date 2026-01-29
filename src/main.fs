\ *************************************
\ main for ESP32 GSM
\    Filename:      main.fs
\    Date:          29 jan 2026
\    Updated:       29 jan 2026
\    File Version:  1.0
\    MCU:           ESP32-S3 - ESP32 WROOM
\    Forth:         ESP32forth all versions 7.0.7.+
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ **************************************


RECORDFILE /spiffs/main.fs

internals 140 to line-width forth

DEFINED? --espGSM [if] forget --espGSM  [then]
create --espGSM

include /spiffs/strings.fs
include /spiffs/serialGSM.fs

include /spiffs/tests.fs

cr ." main.fs loaded "

<EOF>






