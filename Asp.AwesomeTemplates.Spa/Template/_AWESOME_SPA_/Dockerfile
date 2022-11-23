FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim AS build
WORKDIR /src
COPY ["_AWESOME_SPA_.csproj", "_AWESOME_SPA_/"]
RUN dotnet restore "_AWESOME_SPA_/_AWESOME_SPA_.csproj"
COPY . ./_AWESOME_SPA_
WORKDIR "/src/_AWESOME_SPA_"
RUN dotnet build "_AWESOME_SPA_.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "_AWESOME_SPA_.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "_AWESOME_SPA_.dll"]
