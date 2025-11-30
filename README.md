# LivrariaFDevs
Projeto em ASP .Net MVC C# de uma pequena livraria para o curso FDevs.

---

## Tecnologias utilizadas

- **.NET 9**
- **ASP.NET Core MVC**
- **Entity Framework Core**
- **MySQL**
- **Pomelo.EntityFrameworkCore.MySql**
- **Bootstrap 5**

---

## Como rodar o projeto localmente

### Pré-requisitos

Instale:
- .NET 9 SDK  
- MySQL ou MariaDB  
- Git  

---

### Clonar o repositório

```bash
git clone https://github.com/giovana-cruzado/LivrariaFDevs.git
cd LivrariaFDevs
```

---

### Configurar a Connection String

No arquivo `appsettings.json`, ajuste conforme seu MySQL:

Sem senha:
```json
"DefaultConnection": "server=localhost;user=root;database=LivrariaFDevsDb;"
```

Com senha:
```json
"DefaultConnection": "server=localhost;user=root;password=SUASENHA;database=LivrariaFDevsDb;"
```

---

### Restaurar dependências

```bash
dotnet restore
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Pomelo.EntityFrameworkCore.MySql
```

---

### Executar o projeto

```bash
dotnet watch run
---

## Categorias

Ao rodar o projeto pela primeira vez, se a tabela estiver vazia, são criadas automaticamente:

- Geral  
- Romance  
- Tecnologia  
- Programação  

---

## CRUDs implementados

### Livros
- Listar  
- Criar  
- Editar  
- Detalhes  
- Excluir  

### Categorias
- Listar  
- Criar  
- Editar  
- Detalhes  
- Excluir

---

