# ASPNET-AWESOME-TEMPLATES
ASP.NET 6 Awesome templates for easy development. ***Write code, not Configs.***

## Description

The goals of this repo:

* Use actually _**powerful, but simple**_ templates to _**to start coding in one command**_.

* No useless complex stuff which is not used in 99.9% of the apps, like Event-sourcing, DDD, Multitenancy, and other buzz-techs you may ecnounter. It can be included, but it is not **must**.

* Only most useful techs and concepts are used: [ASP.NET 6](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-6.0), [Docker](https://www.docker.com/), [Traefik](https://doc.traefik.io/traefik/), etc.

* ***Use already configured Docker-compose, ASP.NET and other tools. Stop doing config-fucking. Dev your app in one click***

## Where to start

Currently repo contains only MAIN (Level X template). This is the hardest and most advanced template, all other templates made from this one. It have most of customisable features, however, it may be hard to use this template throught ```dotnet new```, so for best user experience, it's highly recommended to use _**[create-aspnet-app](https://github.com/MadL1me/create-aspnet-app)** cli tool_.

Each _Level_ is easy runs in docker, have its own _README_ which contains info about project Stack, documentation and useful commands list.

If you don't want to use it, you can start with Level X template like this:

1. Install template:

  `dotnet new --install Asp.AwesomeTemplates.Main::0.1.0`

2. Create template with dotnet new:

  `dotnet new aspnet-awesome-main`

3. Use your template!

## Contribute

You can contribute by issue proposals, and making pull reqeusts. 

Your ideas about how we can make this simpler, more easy etc are very much needed.
