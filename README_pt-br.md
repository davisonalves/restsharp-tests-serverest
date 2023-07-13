# Testes de API com Restsharp
Este é um exemplo de como automatizar testes de API utilizando C#.

## Instalação e execução
### Pré-requisitos

- Docker
- .NET 6

### Executando a API em seu ambiente local
[![Badge ServeRest](https://img.shields.io/badge/API-ServeRest-green)](https://github.com/ServeRest/ServeRest/)
```
docker run --rm -p 3000:3000 paulogoncalvesbh/serverest:latest
```

### Rodando os testes via linha de comando

Execute todos os testes via linha de comando com:
```
dotnet test -s .\app.runsettings
```

ou

Filtre os testes que deseja executar utilizando:

| Categoria          | Comando															|
|--------------------|------------------------------------------------------------------|
| smoke				 | `dotnet test --filter Category=smoke -s .\app.runsettings`		|
| contract tests     | `dotnet test --filter Category=contract -s .\app.runsettings`	|
| functional tests   | `dotnet test --filter Category=functional -s .\app.runsettings`	|

## Estrutura do projeto
```
.
├───App
│   ├───Data
│   │   ├───Common
│   │   ├───Factory
│   │   └───Schema
│   ├───Helper
│   └───Model
│       ├───Login
│       ├───Product
│       └───User
|
└───Test
    ├───Login 
    ├───Product 
    └───User
```

## Tecnologias utilizadas

- [Restsharp](https://restsharp.dev/) - Para realizar as requisições na API
- [Nunit](https://nunit.org/) - Para escrever e executar os testes
- [Bogus](https://github.com/bchavez/Bogus) - Para gerar dados aleatórios
- [NJsonSchema](https://github.com/RicoSuter/NJsonSchema) - Para carregar e validar schemas json

> Observação: A ideia por trás dessa arquitetura é associar cada teste automatizado a um caso de teste no Azure Test Plan e, por fim, acoplar isso a uma pipeline, de modo que os relatórios de execução dos testes com gráficos e outras informações sejam gerados e permaneçam no próprio Azure.