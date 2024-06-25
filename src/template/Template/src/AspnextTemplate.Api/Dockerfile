FROM mcr.microsoft.com/dotnet/aspnet:8.0-bullseye-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0-bullseye-slim AS build
WORKDIR /src
COPY ["AspnextTemplate.csproj", "AspnextTemplate/"]
RUN dotnet restore "AspnextTemplate/AspnextTemplate.csproj"
COPY . ./AspnextTemplate
WORKDIR "/src/AspnextTemplate"
RUN dotnet build "AspnextTemplate.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AspnextTemplate.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AspnextTemplate.dll"]
