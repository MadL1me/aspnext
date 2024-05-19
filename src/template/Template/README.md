# AspnextTemplate Project

## Develop

---

### Stack

Backend:

- .NET 8
- ASP.NET Core
- Entity Framework
- Docker
- Swagger
  <!--#if(UsePostgreSql) -->
- EF PostgreSql driver
<!--#endif -->

### Prerequisites

Before you start, make sure you have installed all of the following prerequisites on your development machine:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Docker](https://www.docker.com/)
- [Make]()

### Initialize Project

Firslty, you need to initialise your project. It will create developemnt certificate, install all required packages and pull docker images.

```sh
make init
```

---

### Run

Now, you can simply run your app commands in interactive mode:

task/run to run all services (both frontend and backend)

```sh
make run
```

### Links

Back-end Swagger docs: https://localhost:443/swagger

<!--#if(UsePostgreSql) -->
Run PostgreSQL in docker:
```sh
make run-db
```

PostgreSql: http://localhost:5432/
PdAdmin: https://localhost:5050

To connect to PostgreSql from PgAdmin use the following credentials:

- Login: postgres
- Password: changeme

(P.s если используешь PgViewer по localhost:5050 вместо DataGrip, то надо добавить сервер - через addServer:
host: postgres, user: postgres, pass: changeme);

<!--#endif -->

---

<!--#if(AddZitadelAuth) -->
Run Zitadel in docker:
```sh
make run-auth
```

Local ui: http://localhost:8080/ui/login/login?authRequestID=253013912000193539

- Login: zitadel-admin@zitadel.localhost
- Pass: Password1!

<!--#endif -->
