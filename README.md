# Current Status - dev branch

[![Build Status](https://travis-ci.org/jamesdinht/youtaite-collab.svg?branch=dev)](https://travis-ci.org/jamesdinht/youtaite-collab)
[![Quality Gate](https://sonarcloud.io/api/project_badges/measure?project=youtaite-collab&metric=alert_status)](https://sonarcloud.io/api/project_badges/measure?project=youtaite-collab&metric=alert_status)

## Youtaite Collab Tool

Site: TBA

A web application designed to help organize collaborations and chorus battles by offering a specialized UI for Youtaite projects.

>As a fan of Chorus Battles on Youtube, I decided to try and build an application that would bring the power of Software Management products, like Github, Trello, and JIRA, to the Youtaite community.
>
>I hope to build an application that will help organize collaborations more easily and allow involved parties to see progress at a glance.

## Contributing

Want to contribute? Read [here](CONTRIBUTING.md).

## Downloading and Running the Project

- At minimum:
  - 4GB of RAM
  - Some programming knowledge:
    - Basic git knowledge (`clone`)
- Download and install Git, Vagrant, and Virtualbox
  - [Git](https://git-scm.com/downloads) - version 2.0 or greater
  - [Vagrant](https://www.vagrantup.com/downloads.html) - version 2.0.4 or greater
  - [Virtualbox](https://www.virtualbox.org/wiki/Downloads) - version 5.2 or greater
- Clone the repository
  - `git clone git@github.com:jamesdinht/youtaite-collab.git`
- Change into the project's root directory
  - `cd youtaite-collab`
- Start the Vagrant machine (the virtualbox requires 2GB of RAM)
  - `vagrant up`
- After the machine is done setting up, connect to the VM
  - `vagrant ssh`
- Once inside the vagrant machine, navigate to the /vagrant directory, where the repository is being synced
  - `cd /vagrant`
    - `ls` to check for the repository files and folders
      - If the files are not present, try `vagrant reload`
- Initialize the Docker swarm
  - `docker swarm init`
- Run the localdeploy script to build and run the application on localhost
  - `bash localdeploy.sh`
  - Alternatively, open `docker-compose.override.dev.yml`. The comments contain the individual docker commands to run
- Once the services are deployed, open your browser and navigate to `localhost:9100`
  - If the page loads, Congratulations! You have successfully built and deployed this application locally!
  - If not, feel free to submit an issue or email me at jamesdinh14@gmail.com for questions
    - If emailing: Use `Youtaite-Collab Issue/Question/Comment <current-date>` as the subject line
- Once done, use the following command to destroy the VM to release resources
  - `vagrant destroy`
    - Will prompt for confirmation, answer with `y`
    - Alternatively, `vagrant destroy -f` to ignore the confirmation

## Wiki

Visit the wiki [here](https://github.com/jamesdinht/youtaite-collab/wiki).

## Technologies

- ### Backend
  - [C#](https://docs.microsoft.com/en-us/dotnet/csharp/) - Development Language
  - [ASP.NET Core 2.0](https://www.microsoft.com/net/learn/get-started/windows) - Development Framework
  - [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-2017) - Database
  - [xUnit](http://xunit.github.io/docs/getting-started-dotnet-core) - .NET Testing
- ### Frontend
  - [HTML, CSS, JavaScript](https://www.w3schools.com) - Web Development languages
  - [TypeScript](https://www.typescriptlang.org) - JavaScript transcompiler used for Angular
  - [Angular 5](https://angular.io) - Web development framework
  - [Jasmine](https://jasmine.github.io) - JavaScript testing
  - [Karma](https://karma-runner.github.io/2.0/index.html) - JavaScript test runner
- ### DevOps
  - [Git](https://git-scm.com) - Version Control System
  - [TravisCI](https://travis-ci.org) - Continuous Integration
  - [Docker](https://www.docker.com/community-edition) - Containerization

- ### Other Tools
  - [Visual Studio Code](https://code.visualstudio.com) - IDE
  - [Vagrant](https://www.vagrantup.com) - Virtual Machine for isolated development environment
  - [VirtualBox](https://www.virtualbox.org) - Vagrant provider
  - [SonarCloud](https://www.sonarcloud.io) - Code Analysis