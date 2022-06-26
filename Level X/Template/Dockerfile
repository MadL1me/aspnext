FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim AS build
WORKDIR /src
COPY ["Asp.AwesomeTemplate.csproj", "Asp.AwesomeTemplate/"]
RUN dotnet restore "Asp.AwesomeTemplate/Asp.AwesomeTemplate.csproj"
COPY . ./Asp.AwesomeTemplate
WORKDIR "/src/Asp.AwesomeTemplate"
RUN dotnet build "Asp.AwesomeTemplate.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Asp.AwesomeTemplate.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Asp.AwesomeTemplate.dll"]
