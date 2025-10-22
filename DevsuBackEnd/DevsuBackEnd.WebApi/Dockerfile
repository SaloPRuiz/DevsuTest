FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY DevsuBackEnd.WebApi/DevsuBackEnd.WebApi.csproj DevsuBackEnd.WebApi/
COPY DevsuBackEnd.Domain/DevsuBackEnd.Domain.csproj DevsuBackEnd.Domain/
COPY DevsuBackEnd.Infra/DevsuBackEnd.Infra.csproj DevsuBackEnd.Infra/

RUN dotnet restore DevsuBackEnd.WebApi/DevsuBackEnd.WebApi.csproj

COPY . .

WORKDIR /src/DevsuBackEnd.WebApi
RUN dotnet publish DevsuBackEnd.WebApi.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:5000

ENV ASPNETCORE_ENVIRONMENT=Development

EXPOSE 5000

ENTRYPOINT ["dotnet", "DevsuBackEnd.WebApi.dll"]
