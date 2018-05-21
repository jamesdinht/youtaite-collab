# DEFINITION - VAGRANT
Vagrant.require_version ">= 2.0.4"

# Make sure vagrant docker-compose plugin is installed
unless Vagrant.has_plugin?("vagrant-docker-compose")
  system("vagrant plugin install vagrant-docker-compose")
  puts "Dependencies installed, please try the command again."
  exit
end

Vagrant.configure("2") do |config|

  # DEFINITION - BOX
  config.vm.box = "ubuntu/xenial64"
  config.vm.box_version = "20180518.0.0"

  # DEFINITION - NETWORK
  config.vm.network "forwarded_port", guest: 9000, host: 9000, host_ip: "127.0.0.1" # web api
  config.vm.network "forwarded_port", guest: 9100, host: 9100, host_ip: "127.0.0.1" # web interface

  # DEFINITION - PROVIDER
  config.vm.provider "virtualbox" do |vb|
    vb.gui = false
    vb.memory = 2048  
    vb.name = "devbox"
  end

  # DEFINITION - PROVISION
  config.vm.provision "shell", inline: "apt-get update"

  # Provision Docker and Docker-Compose for Vagrant box
  config.vm.provision :docker
  config.vm.provision :docker_compose

  # DEFINITION - SYNCED FOLDER
  config.vm.synced_folder ".", "/vagrant"
end
