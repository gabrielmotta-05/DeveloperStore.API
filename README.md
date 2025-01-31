# DeveloperStore API

Este repositório contém a implementação de uma API para gerenciamento de vendas, com funcionalidades de criação, consulta e cálculo de vendas, utilizando os princípios de **Domain-Driven Design (DDD)**.

## Índice

- [Visão Geral](#visão-geral)
- [Requisitos](#requisitos)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Endpoints da API](#endpoints-da-api)
- [Execução do Projeto](#execução-do-projeto)
- [Testes](#testes)
- [Como Contribuir](#como-contribuir)

## Visão Geral

A API oferece um CRUD completo para a gestão de vendas. As vendas podem ser criadas, recuperadas e atualizadas. A API também inclui o cálculo de valores, descontos e outros detalhes relacionados às vendas.

As principais regras de negócio para o cálculo das vendas são:
- Vendas acima de 4 itens do mesmo produto têm 10% de desconto.
- Vendas entre 10 e 20 itens do mesmo produto têm 20% de desconto.
- Não é possível vender mais de 20 itens do mesmo produto.
- Vendas com menos de 4 itens não recebem desconto.

## Requisitos

- **.NET Core 6.0** ou superior
- **PostgreSQL** ou **MongoDB** (dependendo de sua escolha para o banco de dados)
- **MediatR** para gerenciamento de comandos e consultas
- **AutoMapper** para mapeamento de objetos
- **Rebus** para comunicação assíncrona
- **xUnit** para testes de unidade
- **Postman** ou ferramenta similar para testes manuais de CRUD

## Tecnologias Utilizadas

- **C#**
- **ASP.NET Core** para a criação da API
- **Entity Framework Core** (EF Core) para mapeamento objeto-relacional
- **MediatR** para mediadores de comandos e consultas
- **AutoMapper** para mapeamento de objetos
- **Rebus** para gerenciamento de eventos e mensagens assíncronas
- **PostgreSQL** ou **MongoDB** (banco de dados)

## Estrutura do Projeto

O projeto está organizado da seguinte forma:

- **API**: Contém os controladores da API e os serviços.
- **Models**: Contém os modelos de dados utilizados na aplicação.
- **Requests**: Contém os objetos que representam os comandos de consulta e criação.
- **Services**: Contém a lógica de negócios e serviços auxiliares.
- **Migrations**: Contém as migrações do banco de dados para PostgreSQL.
- **Tests**: Contém os testes de unidade utilizando xUnit.

## Endpoints da API

### Criar Venda

- **POST /api/sale**
- Descrição: Cria uma nova venda.
- Body:
  ```json
  {
    "saleNumber": "12345",
    "saleDate": "2025-01-01T10:00:00",
    "customer": "Customer A",
    "totalAmount": 100.00,
    "branch": "Branch A",
    "items": [
      {
        "productId": "1",
        "quantity": 5,
        "unitPrice": 10.00
      }
    ]
  }
