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

serial2.init

cr ." tests.fs loaded"
<EOF>


