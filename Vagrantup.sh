#!/bin/bash

# Docker version
VERSION_DOCKER_CE=18.03.0~ce-0~ubuntu
VERSION_DOCKER_COMPOSE=1.21.2

# Set up docker repository
# https://docs.docker.com/install/linux/docker-ce/ubuntu/#install-docker-ce
sudo apt-get update

sudo apt-get install \
    apt-transport-https \
    ca-certificates \
    curl \
    software-properties-common

curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo apt-key add -

sudo add-apt-repository \
   "deb [arch=amd64] https://download.docker.com/linux/ubuntu \
   $(lsb_release -cs) \
   stable"

# Install Docker Community Edition
sudo apt-get update
sudo apt-get install -y \
    docker-ce=$VERSION_DOCKER_CE

# Install Docker Compose
curl -L https://github.com/docker/compose/releases/download/$VERSION_DOCKER_COMPOSE/docker-compose-`uname -s`-`uname -m` -o /usr/local/bin/docker-compose
chmod +x /usr/local/bin/docker-compose