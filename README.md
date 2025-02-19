# Gerenciador de Tarefas

![.NET Status](https://img.shields.io/badge/.NET-6-blue)
![License](https://img.shields.io/badge/license-MIT-green)

Este é um sistema de gerenciamento de tarefas desenvolvido com .NET 6, PostgreSQL e uma interface web moderna utilizando HTML, CSS e JavaScript. O sistema permite adicionar, visualizar, editar e excluir tarefas de forma intuitiva e dinâmica.

## 🛠️ Tecnologias Utilizadas

### Backend:
- .NET 6 (C#)
- Entity Framework Core
- PostgreSQL
- Swagger para documentação da API
- xUnit para testes unitários
- AutoMapper para mapeamento de modelos
- FluentValidation para validação de entrada
- MediatR para implementação de CQRS
- Mensageria com RabbitMQ para processamento assíncrono de tarefas

### Frontend:
- HTML5, CSS3, JavaScript
- Fetch API para consumo da API

## 🚀 Funcionalidades

### 📌 Funcionalidades do Backend:
- **CRUD de Tarefas**: Criar, ler, atualizar e excluir tarefas.
- **Registro de Atividades**: Histórico de modificações nas tarefas.
- **Mensageria**: Integração com RabbitMQ para processamento assíncrono de tarefas.
- **Validação de Entrada**: Uso do FluentValidation para validar dados enviados.
- **Documentação da API**: Disponível via Swagger.
- **Testes Unitários**: Cobertura das principais funcionalidades com xUnit.

### 🖥️ Funcionalidades do Frontend:
- **Interface Simples e Funcional**: Desenvolvida com HTML, CSS e JavaScript puro.
- **Consumo da API**: Requisições via Fetch API para CRUD de tarefas.
- **Filtros de Busca**: Pesquisa por status e título.

## 📦 Instalação e Execução

### Backend:

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/gerenciador-tarefas.git
   cd gerenciador-tarefas
   ```
2. Configure o banco de dados PostgreSQL:
   - Atualize a connection string no arquivo `appsettings.json`:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Port=5432;Database=GerenciadorTarefas;Username=postgres;Password=sua_senha"
     }
     ```
3. Execute as migrações:
   ```bash
   dotnet ef database update
   ```
4. Inicie o projeto:
   ```bash
   dotnet run
   ```
5. Acesse no navegador:
   - **API Swagger**: [http://localhost:5063/swagger](http://localhost:5063/swagger)
   - **Frontend**: [http://localhost:5063](http://localhost:5063)

### Frontend:
1. Navegue até a pasta do frontend:
   ```bash
   cd GerenciadorTarefasFront
   ```
2. Abra `index.html` no navegador.

## 🧪 Executando os Testes

Para rodar os testes unitários, utilize o comando abaixo na pasta raiz do projeto:

```bash
cd GerenciadorTarefas.Tests

dotnet test
```

Os testes foram escritos utilizando xUnit, garantindo a integridade das operações de CRUD.

## 📑 Estrutura do Projeto

```
GerenciadorTarefas/
│
├── Controllers/          # Lógica das APIs (TarefaController)
├── Models/               # Modelos da aplicação (Tarefa.cs)
├── Repositories/         # Repositórios para interação com o banco de dados
├── Services/             # Lógica de negócios
├── appsettings.json      # Configurações do banco de dados
├── Messaging/            # Implementação da mensageria (RabbitMQ)
└── Program.cs            # Inicialização da aplicação

GerenciadorTarefasFront/  # Arquivos estáticos (HTML, CSS, JS)
│   ├── index.html
│   ├── styles.css
│   ├── script.js

GerenciadorTarefas.Tests/ # Testes unitários (xUnit)
```

## 📋 API Endpoints

### Tarefas
| Método  | Rota           | Descrição                       |
|---------|---------------|---------------------------------|
| GET    | /api/tarefa   | Lista todas as tarefas         |
| POST   | /api/tarefa   | Cria uma nova tarefa           |
| PUT    | /api/tarefa/{id} | Atualiza uma tarefa existente |
| DELETE | /api/tarefa/{id} | Remove uma tarefa específica |

## ✨ Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues, enviar pull requests ou sugerir melhorias.

1. Fork o projeto.
2. Crie sua feature branch (`git checkout -b feature/SuaFuncionalidade`).
3. Commit suas alterações (`git commit -m 'Adiciona nova funcionalidade'`).
4. Faça o push para o branch (`git push origin feature/SuaFuncionalidade`).
5. Abra um Pull Request.

## 📞 Contato

Desenvolvido por **Felipe Barroso** 🚀

📧 Email | [LinkedIn](https://www.linkedin.com/in/seu-perfil) | [GitHub](https://github.com/seu-usuario)

