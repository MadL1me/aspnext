# Asp.AwesomeTemplate Project

## Develop

***

### First Run
At first, you need to create TLS certificate. You can make it with this command: 

```sh
dotnet dev-certs https -ep ${HOME}/.aspnet/https/AspAwesomeTemplate.pfx -p PASSWORD
``` 

> (You can change PASSWORD to your custom certificate password, but then you need also to change it in `docker-compose.yaml`. Because this certificate is development only, I think you can use default password)

Then, trust the certificate: 

```sh
 dotnet dev-certs https --trust
```

Congrats, you setuped your dev certificates

<!--#if(identity) -->
If you use ASP.NET Identity, its required to initialize database with dotnet ef command:

```sh
dotnet ef migrations add InitialMigration
```

```sh
dotnet ef database update
```
<!--#endif -->

***

### Run

Now, you can simply run your app with one command:

```sh
docker compose up --build -d
```
<!--#if(swagger) -->
Back-end Swagger docs: https://localhost:443/swagger
<!--#endif -->

<!--#if(UseReact) -->
Front-end React-app: http://localhost:3000
<!--#endif -->

<!--#if(UsePostgreSql) -->
PostgreSQL pgAdmin is: https://localhost:5050
Note: Server host is "postgres" from pgAdmin, because its container name from network in docker-compose
Username: postgres
Password: changeme
<!--#endif -->

<!--#if(UseJwtAuth) -->

<!--#endif -->