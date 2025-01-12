# Asp.Net Core API REST com SQL Server

## Visão Geral

Esta API RESTful foi desenvolvida utilizando ASP.NET Core e SQL Server. Ela fornece uma interface para Criacao de Tarefas (projeto de estudo).

## Pré-requisitos

* **.NET Core SDK:** Instale a versão mais recente do .NET Core SDK em https://dotnet.microsoft.com/download
* **Visual Studio:** Um editor de código com suporte para C# para desenvolver a aplicação.
* **SQL Server:** Um banco de dados SQL Server para armazenar os dados.

## Estrutura do Projeto

* **Controllers:** Contêm a lógica para lidar com as requisições HTTP e retornar as respostas.
* **Models:** Representam as entidades do domínio e mapeiam para as tabelas do banco de dados.
* **Interfaces:** Definem contratos para as classes, promovendo a injeção de dependências e facilitando os testes.
* **Repositories:** Fornecem uma camada de abstração para o acesso aos dados, separando a lógica de negócios da persistência.
* **DbContext:** Representa a sessão com o banco de dados, permitindo realizar consultas e operações de CRUD.

## Configuração

1. **Criar um banco de dados:** Crie um banco de dados no SQL Server e configure a string de conexão no arquivo `appsettings.json`.
2. **Executar as migrations:** Utilize o Entity Framework Core para criar as tabelas no banco de dados com base nas classes de modelo.
3. **Configurar o JWT:** Gere uma chave secreta e configure as opções de autenticação no `Program.cs`.

## Utilização

Para iniciar a aplicação:

1. **Abra o terminal:** Navegue até o diretório raiz do projeto.
2. **Execute o comando:** `dotnet run`
3. **Ou rode no Visual Studio**

## Documentação da API

A documentação da API está disponível em https://swagger.io/docs/. Você pode utilizar esta ferramenta para explorar os endpoints, ver os exemplos de requisições e respostas, e testar a API.

## Tecnologias Utilizadas

* **ASP.NET Core:** Framework para construção de aplicações web modernas.
* **Entity Framework Core:** ORM para interagir com o banco de dados.
* **SQL Server:** Banco de dados relacional para armazenar os dados.
* **JWT:** Mecanismo de autenticação para proteger os endpoints da API.
* **Swagger:** Ferramenta para gerar documentação interativa da API.
