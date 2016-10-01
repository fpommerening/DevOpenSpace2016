#!/bin/sh
cd logging-caller
docker build -t fpommerening/rpi-devopenspace2016:logging-caller .
cd ..
cd logging-console
docker build -t fpommerening/rpi-devopenspace2016:logging-console .
cd ..
cd logging-web
docker build -t fpommerening/rpi-devopenspace2016:logging-web .
cd ..
cd logging-loadbalancer
docker build -t fpommerening/rpi-devopenspace2016:logging-loadbalancer .
cd ..



