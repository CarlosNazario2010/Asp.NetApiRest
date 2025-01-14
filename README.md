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
3. **Ou rode em alguma IDE:** Ex Visual Studio**

## Documentação da API

A documentação da API está disponível em https://localhost:7108/swagger/index.html. Você pode utilizar esta ferramenta para explorar os endpoints, ver os exemplos de requisições e respostas, e testar a API.

## Tecnologias Utilizadas

* **ASP.NET Core:** Framework para construção de aplicações web modernas.
* **Entity Framework Core:** ORM para interagir com o banco de dados.
* **SQL Server:** Banco de dados relacional para armazenar os dados.
* **JWT:** Mecanismo de autenticação para proteger os endpoints da API.
* **Swagger:** Ferramenta para gerar documentação interativa da API

## EndPoints da API

### Cadastro
**Método:** POST
**URL:** /cadastrar

**Corpo da requisição (JSON):**

```json
{
    "login": "carlos"
    "senha": "123456"
}
```

Resposta:

200 OK: Retorna um token JWT no corpo da resposta.\
400 Bad Request: Erro na validação dos dados.

### Login
**Método:** POST
**URL:** /logar

**Corpo da requisição (JSON):**

```json
{
    "login": "carlos",
    "senha": "123456"
}
```

Resposta:

200 OK: Retorna um token JWT no corpo da resposta.\
401 Unauthorized: Credenciais inválidas.

Exemplo de resposta com token JWT:

```json
{
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJsb2dpbiI6ImFkbWluIiwibmFtZSI6IkFkbWluIiwiaWF0IjoxNjQ5NTY3MzIyfQ.yJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJsb2dpbiI6ImFkbWluIiwibmFtZSI6IkFkbWluIiwiaWF0IjoxNjQ5NTY3MzIyfQ.yJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJsb2dpbiI6ImFkbWluIiwibmFtZSI6IkFkbWluIiwiaWF0IjoxNjQ9NTY3MzIyfQ"
}
```

### Cadastro de Usuário
**Método:** POST
**URL:** api/Usuario

**Corpo da requisição (JSON):**

```json
{
    "nome": "Carlos Nazario",
    "email": "carlos@email.com"
}
```
Resposta:

201 Created: Usuário criado com sucesso. Retorna o usuário criado no corpo da resposta.\
400 Bad Request: Erro na validação dos dados.

### Listar Todos os Usuários
**Método:** GET\
**URL:** api/Usuario

Resposta:

**200 OK:** Retorna uma lista de todos os usuários.

### Buscar Usuario por id
**Método:** GET\
**URL:** api/Usuario/id\
**Parametro** id: Identificador único do usuário.

Resposta:

200 OK: Retorna o usuário encontrado.\
404 Not Found: Usuário não encontrado.

### Atualizar Usuario

**Método:** PUT\
**URL:** api/Usuario/\
**Parametro** id: Identificador unico do usuario.

**Corpo da requisição (JSON):**

```json
{
    "nome": "Carlos Atualizado",
    "email": "carlosatualizado@email.com"
}
```

Resposta:

200 OK: Usuário atualizado com sucesso.\
404 Not Found: Usuário não encontrado.\
400 Bad Request: Erro na validação dos dados.

### Deletar Usuario

**Método:** DELETE\
**URL:** api/Usuario/\
**Parametro** id: Identificador unico do usuario.

Resposta:

204 No Content: Usuário excluído com sucesso.\
404 Not Found: Usuário não encontrado.

### Cadastro de Tarefa
**Método:** POST
**URL:** api/Tarefa

**Corpo da requisição (JSON):**

```json
{
  "nome": "Programar",
  "descricao": "Fazer uma API em .Net Core",
  "status": 1,
  "usuarioId": 1
}
```
Resposta:

201 Created: Tarefa criada com sucesso. Retorna a tarefa criada no corpo da resposta.\
400 Bad Request: Erro na validação dos dados.

### Listar Todas as Tarefas
**Método:** GET\
**URL:** api/Tarefa

Resposta:

**200 OK:** Retorna uma lista de todas as Tarefas.

### Buscar Tarefa por id
**Método:** GET\
**URL:** api/Tarefa/id\
**Parametro** id: Identificador único da tarefa.

Resposta:

200 OK: Retorna a tarefa encontrado.\
404 Not Found: Tarefa não encontrado.

### Atualizar Tarefa

**Método:** PUT\
**URL:** api/Tarefas/\
**Parametro** id: Identificador unico da tarefa.

**Corpo da requisição (JSON):**

```json
{
  "id": 2,
  "nome": "Programar Atualizado",
  "descricao": "Tarefa de programar em .Net atualizada",
  "status": 2,
  "usuarioId": 1
}
```

Resposta:

200 OK: Tarefa atualizada com sucesso.\
404 Not Found: Tarefa não encontrada.\
400 Bad Request: Erro na validação dos dados.

### Deletar Tarefa

**Método:** DELETE\
**URL:** api/Tarefa/\
**Parametro** id: Identificador unico da Tarefa.

Resposta:

204 No Content: Tarefa excluida com sucesso.\
404 Not Found: Tarefa não encontrada.