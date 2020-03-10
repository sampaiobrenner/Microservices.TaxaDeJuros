# Microservices.TaxaDeJuros

[![CodeFactor](https://www.codefactor.io/repository/github/sampaiobrenner/microservices.taxadejuros/badge)](https://www.codefactor.io/repository/github/sampaiobrenner/microservices.taxadejuros)

### Rotas disponíveis:    
```
api/v1/taxaJuros`
api/v2/taxaJurosPadrao`
```
## O MS calculador de juros está disponível no link: 
```
https://github.com/sampaiobrenner/Microservices.CalculadorDeJuros
```

### O container no docker dessa aplicação está disponível no link: 
```
https://hub.docker.com/r/sampaiobrenner/microservices-taxa-de-juros
```

### Para executar o container e efetuar o build do projeto basta executar o comando abaixo na raiz do projeto:
```
docker-compose -f docker-compose.yml -f docker-compose.override.yml up --build -d
```

### Para somente executar o container basta executar o comando abaixo na raiz do projeto:
```
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```
