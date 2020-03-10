#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Microservices.TaxasDeJuros.WebApi/Microservices.TaxasDeJuros.WebApi.csproj", "src/Microservices.TaxasDeJuros.WebApi/"]
COPY ["src/Microservices.TaxasDeJuros.Services/Microservices.TaxasDeJuros.Services.csproj", "src/Microservices.TaxasDeJuros.Services/"]
COPY ["src/Microservices.TaxasDeJuros.Repositories/Microservices.TaxasDeJuros.Repositories.csproj", "src/Microservices.TaxasDeJuros.Repositories/"]
COPY ["src/Microservices.TaxasDeJuros.Domain/Microservices.TaxasDeJuros.Domain.csproj", "src/Microservices.TaxasDeJuros.Domain/"]
RUN dotnet restore "src/Microservices.TaxasDeJuros.WebApi/Microservices.TaxasDeJuros.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Microservices.TaxasDeJuros.WebApi"
RUN dotnet build "Microservices.TaxasDeJuros.WebApi.csproj" -c Release -o /app/build --no-restore

FROM build AS publish
RUN dotnet publish "Microservices.TaxasDeJuros.WebApi.csproj" -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservices.TaxasDeJuros.WebApi.dll"]
