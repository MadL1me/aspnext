FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim AS build
WORKDIR /src
COPY ["AspAwesomeTemplate.csproj", "AspAwesomeTemplate/"]
RUN dotnet restore "AspAwesomeTemplate/AspAwesomeTemplate.csproj"
COPY . ./AspAwesomeTemplate
WORKDIR "/src/AspAwesomeTemplate"
RUN dotnet build "AspAwesomeTemplate.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AspAwesomeTemplate.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AspAwesomeTemplate.dll"]
