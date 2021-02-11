# Catalog
A simple .Net 5  api

# Run Mongo DB Container
docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db mongo

# Run Mongo DB Container with User-Password
docker run -d --rm -name mongo -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=YourPWD mongo
And use SecretManager to store password
dotnet user-secrets init
dotnet user-secrets set MongoDbSettings:Password YourPWD

# HealthCheck

Using aspnetcore.healthchecks.mongodb package
/health/ready   to check if service is connected to database
/health/live   to check if service is up