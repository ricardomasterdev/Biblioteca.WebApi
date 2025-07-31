# Libraria – Sistema de Controle de Biblioteca

## Visão Geral

Libraria é um sistema web completo para gestão de bibliotecas físicas ou digitais. A interface foi criada em **HTML5 + JavaScript (vanilla)**, estilizada com **Bootstrap 5**, enquanto o back‑end é uma **ASP.NET Core 9 Web API** em **C#** integrada a **SQL Server 2022**. O sistema contempla cadastro de livros, usuários e locações, cálculo de multas, relatórios e autenticação via **JSON Web Tokens (JWT)**.

---

## Endereços de Demonstração

| Serviço                             | URL                                                                                                              |
| ----------------------------------- | ---------------------------------------------------------------------------------------------------------------- |
| Front‑end (Bootstrap)               | [http://app1.cdxsistemas.com.br:1111](http://app1.cdxsistemas.com.br:1111)                                       |
| API REST (Web API)                  | [http://app1.cdxsistemas.com.br:2222](http://app1.cdxsistemas.com.br:2222)                                       |
| Swagger (documentação/teste da API) | [http://app1.cdxsistemas.com.br:2222/swagger/index.html](http://app1.cdxsistemas.com.br:2222/swagger/index.html) |

> ⚠️ Todas as rotas protegidas exigem token JWT no header `Authorization: Bearer <token>`.

---

## Principais Funcionalidades

* **Autenticação & Autorização** — geração e validação de tokens JWT, controle de perfis (Administrador, Usuário).
* **CRUD Completo** — livros, usuários e locações, com paginação e busca.
* **Controle de Multas** — cálculo diário de multas para locações vencidas.
* **Relatórios** — livros mais locados, locações ativas vs. concluídas.
* **Swagger** — playground interativo para testar e documentar a API.
* **Arquitetura em Camadas** — Domain › Application › Infrastructure com Repository Pattern.

---

## Stack Tecnológica

| Camada             | Tecnologias                                                                              |
| ------------------ | ---------------------------------------------------------------------------------------- |
| **Front‑end**      | HTML5, JavaScript ES6, **Bootstrap 5**, Chart.js                                         |
| **Back‑end**       | **ASP.NET Core 9 Web API**, C#, Entity Framework Core, AutoMapper, FluentValidation, JWT |
| **Banco de Dados** | **SQL Server 2022**                                                                      |
| **DevOps**         | IIS 10, Git, CI/CD (GitHub Actions)                                                      |

---

## Estrutura do Repositório

```
Libraria/
├── docs/                          # Documentação adicional
├── src/
│   ├── Biblioteca.WebApi/         # Projeto ASP.NET Core 9 (API)
│   ├── Biblioteca.Application/    # Casos de uso e DTOs
│   ├── Biblioteca.Domain/         # Entidades e regras de negócio
│   ├── Biblioteca.Infrastructure/ # Repositórios EF Core, migrations
│   └── web/                       # Front‑end estático (Bootstrap + JS)
└── README.md                      # Este arquivo
```

---

## Instalação Local

### Pré‑requisitos

* .NET SDK 9+
* SQL Server 2022
* Node.js (opcional, apenas para utilitários de build front‑end)

### Passos

1. **Clonar o repositório**

   ```bash
   git clone https://github.com/ricardomasterdev/Biblioteca.WebApi.git
   cd Biblioteca.WebApi
   git checkout master
   ```

2. **Configurar o banco**

   ```bash
   cd src/Biblioteca.WebApi
   # Ajuste a connection string em appsettings.Development.json
   dotnet ef database update
   ```

3. **Rodar o back‑end**

   ```bash
   cd src/Biblioteca.WebApi
   dotnet run
   ```

   A API ficará acessível em `https://localhost:5001` (ou porta configurada) com Swagger em `/swagger`.

4. **Rodar o front‑end**

   Sirva os arquivos estáticos em `src/web` via qualquer servidor HTTP (Live Server, Nginx, IIS).

---

## Como Gerar & Usar Tokens

1. Envie `POST /api/Login` com e‑mail e senha.

2. Copie o token retornado.

3. Nas demais requisições protegidas, inclua:

   ```http
   Authorization: Bearer SEU_TOKEN_AQUI
   ```

4. No Swagger, clique em **Authorize**, cole o token e execute os endpoints.

---

## Boas Práticas e Padrões Adotados

* **Repository Pattern** para abstração de dados.
* **SOLID** aplicado nas camadas Application e Domain.
* **DTOs + AutoMapper** para isolar modelos de domínio de transporte.
* **FluentValidation** garantindo regras de entrada.
* **Middleware** para tratamento unificado de exceções e logs.

---

## Roadmap

* (Em breve) Recursos avançados de estatísticas e integração externa.

---

## Contribuindo

1. Fork este repositório.
2. Crie sua branch de feature: `git checkout -b feature/MinhaFeature`.
3. Commit suas mudanças: `git commit -m "feat: MinhaFeature"`.
4. Push para a branch: `git push origin feature/MinhaFeature`.
5. Abra um Pull Request contra `master`.

---

## Licença

Distribuído sob a licença MIT. Veja `LICENSE` para mais detalhes.
