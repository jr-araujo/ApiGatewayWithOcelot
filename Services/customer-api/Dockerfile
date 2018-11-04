FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Services/customer-api/Sqit.CustomerApi.csproj", "Services/customer-api/"]
RUN dotnet restore "Services/customer-api/Sqit.CustomerApi.csproj"
COPY . .
WORKDIR "/src/Services/customer-api"
RUN dotnet build "Sqit.CustomerApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Sqit.CustomerApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Sqit.CustomerApi.dll"]

#FROM microsoft/dotnet AS build-env
#WORKDIR /app
#
## copy csproj and restore as distinct layers
#COPY *Services/customer-api/*.csproj ./
#RUN dotnet restore
#
## copy everything else and build
#COPY . ./
#RUN dotnet publish Sqit.CustomerApi.csproj -o out
#
## build runtime image
#FROM microsoft/dotnet:2.1-aspnetcore-runtime
#WORKDIR /app
#COPY --from=build-env /app/out .
#ENTRYPOINT ["dotnet", "Sqit.CustomerApi.dll"]