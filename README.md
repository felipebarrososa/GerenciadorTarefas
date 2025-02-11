# Gerenciador de Tarefas

![.NET](https://img.shields.io/badge/.NET-6.0-purple)
![Status](https://img.shields.io/badge/build-passing-brightgreen)
![License](https://img.shields.io/badge/license-MIT-blue)

Este é um sistema de gerenciamento de tarefas desenvolvido com **.NET 6**, **PostgreSQL** e uma interface web moderna utilizando **HTML**, **CSS**, e **JavaScript**. O sistema permite adicionar, visualizar, editar e excluir tarefas de forma intuitiva e dinâmica.

---

## 🛠️ Tecnologias Utilizadas

- **Backend:** .NET 6 (C#)
- **Frontend:** HTML5, CSS3, JavaScript
- **Banco de Dados:** PostgreSQL
- **ORM:** Entity Framework Core
- **Testes:** xUnit

---

## 🚀 Funcionalidades

- 📌 **Adicionar Tarefas:** Criação de novas tarefas com título, descrição e status.
- 📝 **Editar Tarefas:** Alteração de informações das tarefas existentes.
- ❌ **Excluir Tarefas:** Remoção de tarefas indesejadas.
- 📋 **Visualizar Tarefas:** Interface limpa e moderna para listar as tarefas cadastradas.
- ✅ **Testes Unitários:** Cobertura completa das funcionalidades principais.

---

## 📦 Instalação e Execução

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/seu-usuario/gerenciador-tarefas.git
   cd gerenciador-tarefas
   ```

2. **Configure o banco de dados PostgreSQL:**
   - Atualize a *connection string* no arquivo `appsettings.json`:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Port=5432;Database=GerenciadorTarefas;Username=postgres;Password=sua_senha"
     }
     ```

3. **Execute as migrações:**
   ```bash
   dotnet ef database update
   ```

4. **Inicie o projeto:**
   ```bash
   dotnet run
   ```

5. **Acesse no navegador:**
   ```
   http://localhost:5063
   ```

---

## 🧪 Executando os Testes

Para rodar os testes unitários, utilize o comando abaixo na pasta raiz do projeto:

```bash
cd GerenciadorTarefas.Tests

dotnet test
```

Os testes foram escritos utilizando **xUnit**, garantindo a integridade das operações de CRUD.

---

## 📑 Estrutura do Projeto

```
GerenciadorTarefas/
│
├── Controllers/          # Lógica das APIs (TarefaController)
├── Models/               # Modelos da aplicação (Tarefa.cs)
├── Repositories/         # Repositórios para interação com o banco de dados
├── Services/             # Lógica de negócios
├── appsettings.json      # Configurações do banco de dados
└── Program.cs            # Inicialização da aplicação
GerenciadorTarefasFront/  # Arquivos estáticos (HTML, CSS, JS)
│   ├── index.html
│   ├── styles.css
│   └── script.js
GerenciadorTarefas.Tests/ # Testes unitários (xUnit)
```

---

## 📋 API Endpoints

| Método | Rota             | Descrição                    |
| ------ | ---------------- | ---------------------------- |
| GET    | `/api/tarefa`    | Lista todas as tarefas       |
| POST   | `/api/tarefa`    | Cria uma nova tarefa         |
| PUT    | `/api/tarefa/{id}` | Atualiza uma tarefa existente |
| DELETE | `/api/tarefa/{id}` | Remove uma tarefa específica |

---

## ✨ Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para abrir *issues*, enviar *pull requests* ou sugerir melhorias.

1. **Fork** o projeto.
2. Crie sua *feature branch* (`git checkout -b feature/SuaFuncionalidade`).
3. *Commit* suas alterações (`git commit -m 'Adiciona nova funcionalidade'`).
4. Faça o *push* para o branch (`git push origin feature/SuaFuncionalidade`).
5. Abra um *Pull Request*.

---

## 📞 Contato

Desenvolvido por **Felipe Barroso** 🚀

📧 [Email](mailto:fsbarroso0890@gmail.com)  |  [LinkedIn](https://www.linkedin.com/in/felipebarrososa)  |  [GitHub](https://github.com/felipebarrososa)

---

