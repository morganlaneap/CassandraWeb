FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /src
COPY ./src/CassandraWeb.csproj ./
RUN dotnet restore
COPY ./src ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2

EXPOSE 80
EXPOSE 5000

WORKDIR /src
COPY --from=build-env /src/out .
ENTRYPOINT ["dotnet", "./CassandraWeb.dll"]
