# DEFINITION - VAGRANT
Vagrant.require_version ">= 2.0.4"

# Make sure vagrant docker-compose plugin is installed
required_plugins = %w(vagrant-docker-compose)
plugins_to_install = required_plugins.select { |plugin| !Vagrant.has_plugin? plugin }
unless plugins_to_install.empty?
  puts "Installing plugins #{plugins_to_install.join(' ')}"
  if system("vagrant plugin install #{plugins_to_install.join(' ')}", :chdir=>"/temp")
    exec "vagrant #{ARGV.join(' ')}"
  else
    abort "Installation of plugins failed. Aborting."
  end
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
  config.vm.provision "docker"
  config.vm.provision "docker_compose"

  # DEFINITION - SYNCED FOLDER
  config.vm.synced_folder ".", "/vagrant"
end
