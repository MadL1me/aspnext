[![Dotnet foundation](https://img.shields.io/badge/-.NET%20Template-blueviolet)](https://dotnetfoundation.org/)
![Version](https://img.shields.io/badge/version-0.3.2-blue)
[![Nuget package](https://img.shields.io/badge/Nuget%20-Package-red)](https://www.nuget.org/packages/Asp.AwesomeTemplates.Main/)

# <img width="35" alt="Asset 1@2x" src="https://github.com/MadL1me/aspnet-awesome-templates/assets/46647517/e81a904e-6b5a-4d25-8ed4-5630d495b045">   AspNext

ASP.NET 6 Awesome templates for easy development. **_Write code, not Configs._**

## Phylosophy

- Use actually _**powerful, but simple**_ templates to _**to start coding in one command**_.

- No useless complex stuff which is not used in 99.9% of the apps, like Event-sourcing, DDD, Multitenancy, and other buzz-words you may ecnounter. It can be included, but it is not **must**.

- Only most useful techs and concepts are used: [ASP.NET 6](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-6.0), [Docker](https://www.docker.com/), [Traefik](https://doc.traefik.io/traefik/), etc.

- **_Use already configured Docker-compose, ASP.NET and other tools. Stop doing config-fucking. Start writing code in one click_**

## Where to start

Currently, main repository contains `Asp.AwesomeTemplates.Spa` template - template with React, ASP.NET Core, and many other things.

Each _Template_ is easy runs in docker, have its own _README_ which contains info about project Stack, documentation and useful commands list.

If you don't want to use it, you can start with __main__ template like this:

1. Install template:

```sh
dotnet new --install Asp.AwesomeTemplates.Spa::0.3.2
```

2. Create template with dotnet new:

```sh
dotnet new asp-awesome-spa -o "MyAwesomeProject"
```

3. Use your template! (For example, go to Asp.AwesomeTemplates.Spa template [README](https://github.com/MadL1me/aspnet-awesome-templates/blob/master/Asp.AwesomeTemplates.Spa/Template/README.md), it will have all required commands with your configuration)

## Contribute

You can contribute by issue proposals, and making pull reqeusts.

Your ideas about how we can make this simpler, more easy etc are very much needed.
