FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
RUN apt-get update && apt-get install -y iputils-ping
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Sqit.Service2.Api/Sqit.Service2.Api.csproj Sqit.Service2.Api/
RUN dotnet restore Sqit.Service2.Api/Sqit.Service2.Api.csproj
COPY . .
WORKDIR /src/Sqit.Service2.Api
RUN dotnet build Sqit.Service2.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Sqit.Service2.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Sqit.Service2.Api.dll"]
