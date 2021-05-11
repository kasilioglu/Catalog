# Catalog
A simple .Net 5  api. No serious api structuring or db operations.
Uses mongodb for basic crud operations.

### Run local
To run this api sample at your local machine, first create a secret at local. Use SecretManager to store password as follows;
```
dotnet user-secrets init
dotnet user-secrets set MongoDbSettings:Password koray123
```
And run mongodb container
`docker run -d --rm -name mongo -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=koray123 mongo`

### Run Docker Container
You can use my repository to test this api,  kasilioglu/catalog:v1
`docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=koray123 --network=catalognetwork mongo`

`docker run -it --rm -p 8080:80 -e MongoDbSettings:Host=mongo -e MongoDbSettings:Password=koray123 --network=catalognetwork kasilioglu/catalog:v1`

### Run Kubernetes
You can also apply yaml files under kubernetes folder and use http://localhost/health/live  
`kubectl apply -f .\mongodb.yaml`
`kubectl apply -f .\catalog.yaml`
`kubectl get pods`

### HealthCheck

Using aspnetcore.healthchecks.mongodb package
/health/ready   to check if service is connected to database
/health/live   to check if service is up