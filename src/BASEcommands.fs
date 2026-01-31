\ *************************************
\ define AT BASE commands for ESP32 GSM
\    Filename:      BASEcommands.fs
\    Date:          31 jan 2026
\    Updated:       31 jan 2026
\    File Version:  1.0
\    MCU:           ESP32-S3 - ESP32 WROOM
\    Forth:         ESP32forth all versions 7.0.7.+
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ **************************************


RECORDFILE /spiffs/BASEcommands.fs

: ATbaseCommand: ( comp: zstring -- <name> | exec: -- )
    create
        ,           \ store address of zstring
    does>
        AT$!
        @ z>s ATappend$
        .GsmTxBuffer
  ;

\ AT  communication test between ESP32 and SIM800L
: AT ( -- )
    AT$!
    .GsmTxBuffer
  ;

\ ATI	Display Product Identification Information
z" I" ATbaseCommand: ATI

\ AT+CPIN?	returns an alphanumeric string indicating 
\ whether some password is required or not.
z" +CPIN?" ATbaseCommand: AT+CPIN?


\ AT+CSQ	Mesure la qualité du signal.	+CSQ: <rssi>,<ber> (Ex: 20,0)

\ AT+CREG?	test Network Registration
\ result: +CREG: 0,1 (1 = Connecté local)
z" +CREG?" ATbaseCommand: +CREG?


cr ." ..BASEcommands.fs loaded"
<EOF>







