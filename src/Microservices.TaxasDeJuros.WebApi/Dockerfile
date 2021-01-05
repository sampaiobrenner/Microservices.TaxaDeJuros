ARG ASPNET_VERSION="5.0.0-rc.1-alpine3.12"
ARG SDK_VERSION="5.0.100-rc.1-alpine3.12"
ARG BASE_ADRESS="mcr.microsoft.com/dotnet"

FROM $BASE_ADRESS/aspnet:$ASPNET_VERSION AS base
WORKDIR /app
EXPOSE 5000

RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

FROM $BASE_ADRESS/sdk:$SDK_VERSION AS build
WORKDIR /src

COPY ./src/Microservices.TaxasDeJuros.Domain.Abstractions/*.csproj ./Microservices.TaxasDeJuros.Domain.Abstractions/
COPY ./src/Microservices.TaxasDeJuros.Repositories.Abstractions/*.csproj ./Microservices.TaxasDeJuros.Repositories.Abstractions/
COPY ./src/Microservices.TaxasDeJuros.Services.Abstractions/*.csproj ./Microservices.TaxasDeJuros.Services.Abstractions/

COPY ./src/Microservices.TaxasDeJuros.Domain/*.csproj ./Microservices.TaxasDeJuros.Domain/
COPY ./src/Microservices.TaxasDeJuros.Repositories/*.csproj ./Microservices.TaxasDeJuros.Repositories/
COPY ./src/Microservices.TaxasDeJuros.Services/*.csproj ./Microservices.TaxasDeJuros.Services/
COPY ./src/Microservices.TaxasDeJuros.WebApi/*.csproj ./Microservices.TaxasDeJuros.WebApi/

COPY ./NuGet.Config ./
#COPY ./Directory.Build.props ./

RUN dotnet restore ./Microservices.TaxasDeJuros.WebApi

COPY ./src/Microservices.TaxasDeJuros.Domain.Abstractions/. ./Microservices.TaxasDeJuros.Domain.Abstractions/
COPY ./src/Microservices.TaxasDeJuros.Repositories.Abstractions/. ./Microservices.TaxasDeJuros.Repositories.Abstractions/
COPY ./src/Microservices.TaxasDeJuros.Services.Abstractions/. ./Microservices.TaxasDeJuros.Services.Abstractions/

COPY ./src/Microservices.TaxasDeJuros.Domain/. ./Microservices.TaxasDeJuros.Domain/
COPY ./src/Microservices.TaxasDeJuros.Repositories/. ./Microservices.TaxasDeJuros.Repositories/
COPY ./src/Microservices.TaxasDeJuros.Services/. ./Microservices.TaxasDeJuros.Services/
COPY ./src/Microservices.TaxasDeJuros.WebApi/. ./Microservices.TaxasDeJuros.WebApi/

WORKDIR /src/Microservices.TaxasDeJuros.WebApi
RUN dotnet build -c Release --no-restore -o /app/build 

FROM build AS publish
RUN dotnet publish -c Release --no-restore -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservices.TaxasDeJuros.WebApi.dll"]