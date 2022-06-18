# Asp.AwesomeTemplate Project

## Develop

***

### First Run
At first, you need to create TLS certificate. You can make it with this command: 

```sh
dotnet dev-certs https -ep ${HOME}/.aspnet/https/Asp.AwesomeTemplate.pfx -p PASSWORD
``` 

> (You can change PASSWORD to your custom certificate password, but then you need also to change it in `docker-compose.yaml`. Because this certificate is development only, I think you can use default password)

Then, trust the certificate: 

```sh
 dotnet dev-certs https --trust
```

Congrats, you setuped your dev certificates

***

### Run

Now, you can simply run your app with one command in interactive mode:

```sh
docker compose up 
```
<!--#if(EnableSwaggerSupport) -->
Back-end Swagger docs: https://localhost:443/swagger
<!--#endif -->

<!--#if(UseReact) -->
Front-end React-app: http://localhost:3000
<!--#endif -->