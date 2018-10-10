FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
RUN apt-get update && apt-get install -y iputils-ping
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Sqit.ApiGateway/Sqit.ApiGateway.csproj Sqit.ApiGateway/
RUN dotnet restore Sqit.ApiGateway/Sqit.ApiGateway.csproj
COPY . .
WORKDIR /src/Sqit.ApiGateway
RUN dotnet build Sqit.ApiGateway.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Sqit.ApiGateway.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Sqit.ApiGateway.dll"]
