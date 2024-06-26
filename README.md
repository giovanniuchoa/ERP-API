# Car API

## English Version

This project is a simple API for a car sales administrative dashboard that uses ASP.NET Core, C#, Entity Framework, and SQL Server.



[Versão em Português](#versão-em-português)

## Packages Used

The project uses the following packages:

1. `Microsoft.AspNetCore.Authentication` (2.2.0)
2. `Microsoft.AspNetCore.Authentication.JwtBearer` (8.0.6)
3. `Microsoft.EntityFrameworkCore` (8.0.2)
4. `Microsoft.EntityFrameworkCore.SqlServer` (8.0.2)
5. `Microsoft.EntityFrameworkCore.Tools` (8.0.2)
6. `Swashbuckle.AspNetCore` (6.6.2)
7. `Swashbuckle.AspNetCore.Annotations` (6.6.2)
8. `System.Security.Cryptography.Cng` (5.0.0)

## Future Implementations

This project aims to implement the following features in the future:

- Repository structure.
- Use Fluent API to configure a more consistent database.

## Project Setup

1. **Prerequisites**:
    - .NET Core SDK
    - SQL Server or another compatible database

2. **Installation**:
    - Clone the repository:
      ```bash
      git clone https://github.com/giovanniuchoa/ERP-API
      ```
    - Navigate to the project directory:
      ```bash
      cd *directory where the project was cloned*
      ```
    - Restore the NuGet packages:
      ```bash
      dotnet restore
      ```

3. **Database Configuration**:
    - Update the connection string in the `Program.cs` file:
      ```bash
      options.UseSqlServer("Your connection string");
      ```
    - Apply the database migrations:
      ```bash
      dotnet ef database update
      ```

4. **Running the Application**:
    - Start the application:
      ```bash
      dotnet run
      ```

5. **Accessing the API**:
    - The API documentation will be available at:
      ```
      http://localhost:5167/index.html
      ```

---

## Versão em Português

Este projeto é uma API simples para um dashboard de vendas de carros que utiliza ASP.NET Core, C# e Entity Framework e SQL Server.

[English Version](#english-version)

## Pacotes Utilizados

O projeto utiliza os seguintes pacotes:

1. `Microsoft.AspNetCore.Authentication` (2.2.0)
2. `Microsoft.AspNetCore.Authentication.JwtBearer` (8.0.6)
3. `Microsoft.EntityFrameworkCore` (8.0.2)
4. `Microsoft.EntityFrameworkCore.SqlServer` (8.0.2)
5. `Microsoft.EntityFrameworkCore.Tools` (8.0.2)
6. `Swashbuckle.AspNetCore` (6.6.2)
7. `Swashbuckle.AspNetCore.Annotations` (6.6.2)
8. `System.Security.Cryptography.Cng` (5.0.0) 

## Implementações Futuras

Este projeto visa implementar as seguintes funcionalidades no futuro:

- Estrutura de Repositório.
- Utilizar Fluent API para configurar um banco de dados mais consistente.

## Configuração do Projeto

1. **Pré-requisitos**:
    - .NET Core SDK
    - SQL Server ou outro banco de dados compatível

2. **Instalação**:
    - Clone o repositório:
      ```bash
      git clone https://github.com/giovanniuchoa/ERP-API
      ```
    - Navegue até o diretório do projeto:
      ```bash
      cd *local onde o projeto foi clonado*
      ```
    - Restaure os pacotes NuGet:
      ```bash
      dotnet restore
      ```

3. **Configuração do Banco de Dados**:
    - Atualize a string de conexão no arquivo `Program.cs`:
      ```bash
      options.UseSqlServer("Sua connection string");
      ```
    - Aplique as migrações ao banco de dados:
      ```bash
      dotnet ef database update
      ```

4. **Executando a Aplicação**:
    - Inicie a aplicação:
      ```bash
      dotnet run
      ```

5. **Acessando a API**:
    - A documentação da API estará disponível em:
      ```
      http://localhost:5167/index.html
      ```
