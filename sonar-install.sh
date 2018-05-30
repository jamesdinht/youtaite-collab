#!/bin/bash

sudo apt-get -qq update
wget -O sonar.zip https://github.com/SonarSource/sonar-scanner-msbuild/releases/download/4.2.0.1214/sonar-scanner-msbuild-4.2.0.1214-netcoreapp2.0.zip
unzip -qq sonar.zip -d sonar
ls -l sonar
chmod +x tools/sonar/sonar-scanner-3.1.0.1141/bin/sonar-scanner
chmod +x tools/sonar/SonarScanner.MSBuild.dll