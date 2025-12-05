# 🏗️ API de Produtos - Arquitetura Limpa

API RESTful com .NET 8, PostgreSQL, seguindo os princípios de Clean Architecture com padrões Repository e Service.

## 📐 Arquitetura

```
ProductApi/
├── Domain/                        # Camada de Domínio
│   ├── Entities/
│   │   └── Product.cs            # Entidade de negócio
│   └── Interfaces/
│       └── IProductRepository.cs # Contrato do repositório
│
├── Application/                   # Camada de Aplicação
│   ├── DTOs/
│   │   └── ProductDTO.cs         # Data Transfer Objects
│   ├── Interfaces/
│   │   └── IProductService.cs    # Contrato do serviço
│   └── Services/
│       └── ProductService.cs     # Regras de negócio
│
├── Infrastructure/                # Camada de Infraestrutura
│   ├── Data/
│   │   └── AppDbContext.cs       # Contexto do EF Core
│   └── Repositories/
│       └── ProductRepository.cs  # Implementação do repositório
│
└── Presentation/                  # Camada de Apresentação
    └── Controllers/
        └── ProductsController.cs  # API Controllers
```

## 🎯 Princípios Aplicados

### ✅ Clean Architecture
- **Separação de Responsabilidades**: Cada camada tem uma função específica
- **Inversão de Dependência**: Abstrações não dependem de detalhes
- **Independência de Frameworks**: Regras de negócio isoladas

### ✅ Design Patterns
- **Repository Pattern**: Abstração do acesso a dados
- **Service Layer Pattern**: Centralização da lógica de negócio
- **DTO Pattern**: Separação entre entidades e contratos da API
- **Dependency Injection**: Acoplamento fraco entre componentes

## 🚀 Como Executar

### 1. Pré-requisitos
- .NET 8 SDK
- PostgreSQL
- IDE (Visual Studio, VS Code, Rider)

### 2. Configurar Connection String
Edite `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=ProductsDB;Username=seu_usuario;Password=sua_senha"
}
```

### 3. Restaurar Pacotes
```bash
dotnet restore
```

### 4. Criar Migrations
```bash
dotnet ef migrations add InitialCreate
```

### 5. Atualizar Banco de Dados
```bash
dotnet ef database update
```

### 6. Executar
```bash
dotnet run
```

Acesse: `https://localhost:7xxx/swagger`

## 📡 Endpoints da API

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/products` | Lista todos os produtos |
| GET | `/api/products/{id}` | Busca produto por ID |
| POST | `/api/products` | Cria novo produto |
| PUT | `/api/products/{id}` | Atualiza produto |
| DELETE | `/api/products/{id}` | Remove produto (soft delete) |

## 📦 Exemplos de Request

### POST /api/products
```json
{
  "nome": "Teclado Mecânico",
  "descricao": "Teclado mecânico RGB com switches blue",
  "preco": 450.00,
  "quantidadeEstoque": 15
}
```

### PUT /api/products/1
```json
{
  "nome": "Notebook Dell Atualizado",
  "descricao": "Notebook Dell Inspiron 15, 32GB RAM, 1TB SSD",
  "preco": 4500.00,
  "quantidadeEstoque": 5
}
```

## 🔑 Benefícios da Arquitetura

### 1. **Testabilidade**
- Fácil criar testes unitários para Services
- Repositórios podem ser mockados facilmente

### 2. **Manutenibilidade**
- Código organizado e previsível
- Mudanças isoladas em suas respectivas camadas

### 3. **Escalabilidade**
- Fácil adicionar novas funcionalidades
- Possível trocar banco de dados sem afetar regras de negócio

### 4. **Reutilização**
- Services podem ser usados em diferentes controllers
- Repositórios abstraem lógica de acesso a dados

## 📚 Camadas Explicadas

### **Domain** (Núcleo)
- Contém entidades e interfaces
- Não depende de nenhuma outra camada
- Representa as regras de negócio puras

### **Application** (Casos de Uso)
- Contém a lógica de aplicação
- Usa as interfaces do Domain
- Define DTOs para comunicação externa

### **Infrastructure** (Detalhes Técnicos)
- Implementa interfaces do Domain
- Acesso a dados (EF Core, PostgreSQL)
- Frameworks e bibliotecas externas

### **Presentation** (Interface)
- Controllers da API
- Recebe requisições HTTP
- Delega processamento para Application

## 🔐 Boas Práticas Implementadas

✅ Injeção de Dependência  
✅ Validação de dados com Data Annotations  
✅ DTOs para separar modelo de domínio da API  
✅ Soft Delete para preservar histórico  
✅ Async/Await para melhor performance  
✅ AsNoTracking para queries read-only  
✅ Tratamento de exceções centralizado  
✅ Documentação com Swagger/OpenAPI  

## 📝 Próximos Passos (Melhorias Possíveis)

- [ ] Adicionar AutoMapper para mapeamento de DTOs
- [ ] Implementar Unit of Work pattern
- [ ] Adicionar FluentValidation
- [ ] Criar camada de testes (xUnit)
- [ ] Implementar CQRS com MediatR
- [ ] Adicionar logging (Serilog)
- [ ] Implementar autenticação JWT
- [ ] Adicionar Redis para cache

## 📄 Licença

MIT License - Sinta-se livre para usar este projeto como base!
