FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
RUN apt-get update && apt-get install -y iputils-ping
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Sqit.Service1.Api/Sqit.Service1.Api.csproj Sqit.Service1.Api/
RUN dotnet restore Sqit.Service1.Api/Sqit.Service1.Api.csproj
COPY . .
WORKDIR /src/Sqit.Service1.Api
RUN dotnet build Sqit.Service1.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Sqit.Service1.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Sqit.Service1.Api.dll"]
