
# **DeveloperStore.API**

📌 **Visão Geral**

A **DeveloperStore.API** é um serviço para gerenciamento de vendas, permitindo cálculos de descontos automáticos com base na quantidade de itens comprados.

🚀 **Funcionalidades**

📦 **Gerenciamento de Vendas:** Permite calcular o total da venda e aplicar descontos.

🏷️ **Descontos Automáticos:**

- **10%** para compras entre **4 e 9 itens**.
- **20%** para compras entre **10 e 20 itens**.
- **Venda de mais de 20 itens** é bloqueada.

🔍 **Logs de Monitoramento:** O sistema utiliza **logging** para rastrear eventos importantes.

✅ **Testes Unitários:** Implementados usando **xUnit** e **Moq**.

🏗️ **Arquitetura**

O projeto segue a estrutura **Clean Architecture**, com separação clara entre camadas:

```plaintext
DeveloperStore.API
│-- Controllers
│-- Models
│-- Services
│-- Tests
```

- **Controllers** → Gerenciam as requisições HTTP.
- **Models** → Contém os objetos de domínio da aplicação.
- **Services** → Contém a lógica de negócios.
- **Tests** → Projeto separado para testes unitários.

📦 **Como Configurar o Projeto**

1️⃣ **Restaurar Dependências**

Após clonar o repositório, execute:

```bash
dotnet restore
```

Isso instalará todas as dependências necessárias.

2️⃣ **Rodar a API**

Para iniciar o servidor:

```bash
dotnet run --project DeveloperStore.API
```

A API estará disponível em **http://localhost:5000** (ou na porta configurada).

3️⃣ **Executar os Testes**

Para validar se o código está funcionando corretamente:

```bash
dotnet test
```

🤝 **Contribuindo**

- Faça um **Fork** do repositório.
- Crie uma **Branch** para sua feature:

```bash
git checkout -b minha-feature
```

- Implemente as alterações e faça o **commit**:

```bash
git commit -m "Descrição da feature"
```

- Envie um **Pull Request** para revisão.

🛠️ **Tecnologias Utilizadas**

- **.NET 8**
- **xUnit** (Testes Unitários)
- **Moq** (Mocks para testes)
- **Microsoft Logging** (Sistema de logs)

📄 **Licença**

Este projeto está sob a **licença MIT**. Sinta-se à vontade para usá-lo e modificá-lo!

📧 **Contato:** Caso tenha dúvidas ou sugestões, abra uma **issue** no repositório!

---

# 📦 **Gerenciamento de Dependências no .NET**

Este documento descreve como gerenciar e restaurar as dependências do projeto .NET.

## 🔄 **Restaurar Dependências**

Se você acabou de clonar o projeto, execute o seguinte comando para restaurar as dependências:

```bash
dotnet restore
```

Isso baixará todos os pacotes necessários definidos no arquivo `.csproj`.

## 📥 **Adicionar Novas Dependências**

Caso precise adicionar um novo pacote ao projeto:

- **Para o projeto principal**:

  ```bash
  dotnet add package NomeDoPacote
  ```

- **Para o projeto de testes**:

  ```bash
  dotnet add DeveloperStore.API.Tests package NomeDoPacote
  ```

## 🔄 **Atualizar Dependências**

Para verificar e atualizar pacotes existentes:

- **Listar pacotes instalados**:

  ```bash
  dotnet list package
  ```

- **Atualizar pacotes desatualizados**:

  ```bash
  dotnet outdated
  ```

  ```bash
  dotnet add package NomeDoPacote --version X.Y.Z
  ```

Se `dotnet-outdated` não estiver instalado, instale com:

```bash
dotnet tool install --global dotnet-outdated-tool
```

## 📌 **Fixar Versão do .NET**

Para garantir que todos os desenvolvedores utilizem a mesma versão do SDK, crie um arquivo `global.json` na raiz do projeto:

```json
{
  "sdk": {
    "version": "8.0.100"
  }
}
```

Isso evita inconsistências entre ambientes de desenvolvimento.

## 🎯 **Conclusão**

Seguindo essas instruções, você poderá gerenciar dependências de forma eficiente e manter seu ambiente de desenvolvimento alinhado com o restante da equipe.
