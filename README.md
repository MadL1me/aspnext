# aspnet-ez-templates
ASP NET 6 Modern templates for ez development. ***Write code, not Configs.***

## Description

The goals of this repo:

* Create actually _**usable, but easy**_ templates with _**deploying and developing in one command**_.

* No useless complex stuff which is not used in 99.9% of the apps, like Event-sourcing, DDD and other buzz-techs you may ecnounter. 

* Only most useful techs and concepts is used, like [ASP.NET 6](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-6.0), [Docker](https://www.docker.com/), [Traefik](https://doc.traefik.io/traefik/) as Reverse-proxy, etc.

* ***Use already configured Docker-compose, ASP.NET and Traefik. Stop doing config-fucking. Dev your app in one click***

## Where to start

(Currently repo contains only my personal template (Level 5))
You can start with Level 0 template. It contains most simple yet useful things you need for your app.
Each _Level_ is easy runs in docker, and have its own certificates. Each folder have its own _README_ you should read. It contains info about stack, documentation and useful commands list.

## Levels
Each "Level" adds complexity to the templates. The problem is, to be effective with a very advanced template, you need to be effective with almost each technology down there.

In _Level 0_ there is the most simple templates with world most convinient enterprise technologies - Just Docker + ASP.NET 6 for example. 

The _Level 5_ may have a lot of libraries or stuff you may not even need - like _Authorization, Logging configs, Traefik reverse proxy, etc._ For more info you can check unique **README** in each _"Level X"_ folder.

## TODO
- [ ] Templates from level 0 to 4.
- [ ] Docs to each template
- [ ] Traefik support 
- [ ] Easy deploy as production docker composes for each template
