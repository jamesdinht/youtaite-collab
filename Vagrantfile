# DEFINITION - VAGRANT
Vagrant.require_version ">= 2.0.4"
Vagrant.configure("2") do |config|

  # DEFINITION - BOX
  config.vm.box = "ubuntu/xenial64"
  config.vm.box_version = "20180503.0.0"

  # DEFINITION - NETWORK
  config.vm.network "forwarded_port", guest: 6000, host: 6000, host_ip: "127.0.0.1" # web api

  # DEFINITION - PROVIDER
  config.vm.provider "virtualbox" do |vb|
    vb.gui = false
    vb.memory = 2048  
    vb.name = "devbox"
  end

  # DEFINITION - PROVISION
  config.vm.provision "shell", path: "Vagrantup.sh"

  # DEFINITION - SYNCED FOLDER
  config.vm.synced_folder ".", "/vagrant"
end
