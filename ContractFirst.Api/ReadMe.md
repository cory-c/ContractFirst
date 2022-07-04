#Contract First API Template

### Code Generation 
The template project enforces that a service definition is created before code is implemented. At build time, the project reads from the ServiceDefinition.yaml file in the project root then generates request models, response models, interfaces and controller delegates for each endpoint in a single file called ControllerDelegates.cs. This file is not meant to be checked in so that any changes to the service definition are always reflected. 

### Providing Implementation 

Once the ConrollerDelegates.cs file has been generated an implementation will need to be provided and registered for each Interface. 

### Swagger UI

### Configuration 

### Running Locally
Pre-Reqs, the following software needs to be installed:

Java JDK, 
Docker, 
Git

Steps to run:

1. Build Project
2. Open terminal, cd into /Resources/Config directory
3. Run setup-config.sh, pass -l local file location of config or -r remote github repo
`./setup-config.sh -r https://github.com/cory-c/TestConfig.git`

### Service Lookup
Coming soon

### TODO
1. Get options monitor config working
2. Setup script to test config
3. Endpoint to return config settings
4. Is config abstract for env? for implementation?
