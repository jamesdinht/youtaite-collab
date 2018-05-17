#!/bin/bash
# Shortcut to running both of the docker commands below for a faster build and deploy:
#   bash localdeploy.sh
docker-compose -f docker-compose.override.dev.yml build
docker stack deploy -c docker-compose.override.dev.yml collab