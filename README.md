# ContractFirst
Contract first is a template API project to demonstrate contract first development pattern. Controller delegates / reqeuest response models are generated at build time.
 ## Running config server
 1. Install Docker Hub: [Windows](https://docs.docker.com/desktop/windows/install/), [Mac](https://docs.docker.com/desktop/mac/install/), [Linux](https://docs.docker.com/desktop/linux/install/)
 2. Install Java
 3. [Install Powershell](https://docs.microsoft.com/en-us/powershell/scripting/install/installing-powershell?view=powershell-7.2)
 4. Clone Repo: https://github.com/SteeltoeOSS/Dockerfiles
 ## Build Image
 ```
   $ build.ps1 config-server
 ```
 ## Pushing to dockerhub
 ```
   $ docker push steeltoeoss/config-server:1.2.3-linux
 ```
 ## Push a manifest
 ```
   $ manifest-tool --username * --password * push from-spec config-server/manifest.yml
 ```
 ## Running
 Default Configuration ( sample configuration repo here https://github.com/cory-c/TestConfig )
 ```
    $ docker run --publish 8888:8888 steeltoeoss/config-server
 ```
 Custom Git Repo Configuration
 ```
   $ docker run --publish 8888:8888 steeltoeoss/config-server \
    --spring.cloud.config.server.git.uri=https://github.com/myorg/myrepo
 ```
 Local File System Configuration
 ```
   $ docker run --publish 8888:8888 --volume /path/to/my/config:/config steeltoeoss/config-server \
    --spring.profiles.active=native \
    --spring.cloud.config.server.native.searchLocations=file:///config
 ```
 
 
 
