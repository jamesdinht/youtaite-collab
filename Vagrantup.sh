#!/bin/bash

# Docker version
VERSION_DOCKER_CE=18.03.0~ce-0~ubuntu

# PACKAGE - DEFINITION

# Set up docker repository
# https://docs.docker.com/install/linux/docker-ce/ubuntu/#install-docker-ce
sudo apt-get update

sudo apt-get install \
    apt-transport-https \
    ca-certificates \
    curl \
    software-properties-common

curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo apt-key add -

sudo apt-key fingerprint 0EBFCD88

sudo add-apt-repository \
   "deb [arch=amd64] https://download.docker.com/linux/ubuntu \
   $(lsb_release -cs) \
   stable"

# Install Docker Community Edition
sudo apt-get update
sudo apt-get install -y docker-ce=$VERSION_DOCKER_CE

