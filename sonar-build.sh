#!/bin/bash

dotnet tools/sonar/SonarScanner.MSBuild.dll begin /k:youtaite-collab /d:sonar.login=${SONAR_TOKEN} /d:sonar.host.url="https://sonarcloud.io"
dotnet build --no-restore
dotnet tools/sonar/SonarScanner.MSBuild.dll end /d:sonar.login=${SONAR_TOKEN}