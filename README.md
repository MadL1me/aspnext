
[![Dotnet foundation](https://img.shields.io/badge/-.NET%20Foundation-blueviolet)](https://dotnetfoundation.org/)
![Version](https://img.shields.io/badge/version-0.0.2-orange)
[![Nuget package](https://img.shields.io/badge/Nuget%20-Package-red)](https://www.nuget.org/packages/Asp.AwesomeTemplates.Main/) 
![PRs Welcome](https://img.shields.io/badge/PRs-welcome-green.svg)
# ASPNET-AWESOME-TEMPLATES 

ASP.NET 6 Awesome templates for easy development. ***Write code, not Configs.***

<img alt="Logo" align="right" src="https://user-images.githubusercontent.com/46647517/172821591-cf472a75-69ea-4447-b5a9-7fac844c8f42.png" width="20%">

## Phylosophy

* Use actually _**powerful, but simple**_ templates to _**to start coding in one command**_.

* No useless complex stuff which is not used in 99.9% of the apps, like Event-sourcing, DDD, Multitenancy, and other buzz-words you may ecnounter. It can be included, but it is not **must**.

* Only most useful techs and concepts are used: [ASP.NET 6](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-6.0), [Docker](https://www.docker.com/), [Traefik](https://doc.traefik.io/traefik/), etc.

* ***Use already configured Docker-compose, ASP.NET and other tools. Stop doing config-fucking. Start writing code in one click***

## Where to start

Currently repo contains only MAIN (Level X template). This is the hardest and most advanced template, all other templates made from this one. It have most of customisable features, however, it may be hard to use this template throught `dotnet new`, so for best user experience, it's highly recommended to use _**[create-aspnet-app](https://github.com/MadL1me/create-aspnet-app)** cli tool_.

Each _Level_ is easy runs in docker, have its own _README_ which contains info about project Stack, documentation and useful commands list.

If you don't want to use it, you can start with Level X template like this:

1. Install template:

  ```sh
  dotnet new --install Asp.AwesomeTemplates.Main::0.1.0
  ```

2. Create template with dotnet new:

  ```sh
  dotnet new aspnet-awesome-main -o "MyAwesomeProjectName"
  ```

3. Use your template! (For example, go to Level X template [README](https://github.com/MadL1me/aspnet-awesome-templates/blob/master/Level%20X/Template/README.md), it will have all required commands with your configuration)

## Contribute

You can contribute by issue proposals, and making pull reqeusts. 

Your ideas about how we can make this simpler, more easy etc are very much needed.
