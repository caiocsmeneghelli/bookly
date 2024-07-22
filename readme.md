# Bookly

Este é um projeto de um gerenciador de bibliotecas simples, desenvolvido utilizando C# 7, Clean Architecture, Padrão Repository, EF Core e Fluent Validation. O objetivo é fornecer uma aplicação base para a gestão de bibliotecas, incluindo funcionalidades básicas como gerenciamento de livros e autores.

## Tecnologias Utilizadas

- **C# 7**
- **Clean Architecture**
- **Padrão Repository**
- **Entity Framework Core**
- **Fluent Validation**

## Estrutura do Projeto

O projeto está estruturado seguindo os princípios da Clean Architecture. Ele é dividido em várias camadas, cada uma com uma responsabilidade específica:

- **Core:** Contém as entidades, interfaces e lógica de negócio.
- **Application:** Contém os casos de uso e validações.
- **Infrastructure:** Implementações específicas de infraestrutura, como repositórios e contexto de banco de dados.
- **API:** API.

### Diretórios

- **Bookly.Core:** Contém as entidades e interfaces de domínio.
- **Bookly.Application:** Contém os casos de uso e validações.
- **Bookly.Infrastructure:** Contém as implementações de repositórios e o contexto do EF Core.
- **Bookly.API:** Contém a API ASP.NET Core para interação com o sistema.