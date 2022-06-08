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

Now, you can simply run your app with one command:

```sh
docker compose up -d
```

Swagger route:
```
http://localhost:433/swagger
```