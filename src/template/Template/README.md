# AspnextTemplate Project

## Develop

---

### Stack

Backend:

- .NET 6
- ASP.NET Core
- Entity Framework
- Docker
<!--#if(EnableSwaggerSupport) -->
- Swagger
  <!--#endif -->
  <!--#if(UsePostgreSql) -->
- EF PostgreSql driver
<!--#endif -->

Frontend:

- Typescript
- React
- yarn
<!--#if(UseReactVite) -->
- Vite
  <!--#endif -->
  <!--#if(UseNext) -->
- Next.js
<!--#endif -->

### Prerequisites

Before you start, make sure you have installed all of the following prerequisites on your development machine:

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Docker](https://www.docker.com/)
- [Taskfile](https://taskfile.dev/#/installation)
- [Node.js](https://nodejs.org/en/)
- [Yarn](https://yarnpkg.com/)

### Initialize Project

Firslty, you need to initialise your project. It will create developemnt certificate, install all required packages and pull docker images.

```sh
task init
```

---

### Run

Now, you can simply run your app commands in interactive mode:

task/run to run all services (both frontend and backend)

```sh
task run
```

### Links

<!--#if(EnableSwaggerSupport) -->

Back-end Swagger docs: https://localhost:443/swagger

<!--#endif -->

<!--#if(UseReactVite) -->

Front-end React-app: http://127.0.0.1:5173/

<!--#endif -->

<!--#if(UseNext) -->

Front-end React-app: http://localhost:3000/

<!--#endif -->

<!--#if(UsePostgreSql) -->

PostgreSql: http://localhost:5432/

PdAdmin: https://localhost:5050

To connect to PostgreSql from PgAdmin use the following credentials:

- Login: postgres
- Password: changeme

<!--#endif -->
