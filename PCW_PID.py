import sys
import csv
import os

doc = pipeflo().doc()

dp_setpoint = 40
EOM = doc.get_control_valve( "EOM" )
dp_actual = SELECT dp FROM Control_Valve
error = dp_setpoint - dp_actual

print( error )
