FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["..", "Asp.EzTemplate/"]
RUN dotnet restore "Asp.EzTemplate/Asp.EzTemplate.csproj"
COPY . .
WORKDIR "/src/Asp.EzTemplate"
RUN dotnet build "Asp.EzTemplate.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Asp.EzTemplate.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Asp.EzTemplate.dll"]
