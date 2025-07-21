# FinanceApi

Una API REST robusta para la gestión de finanzas personales, desarrollada con .NET 8, que permite administrar ingresos y gastos con autenticación segura mediante JWT.

## 🚀 Características

- ✅ **Gestión de Ingresos**: CRUD completo para registro de ingresos
- ✅ **Gestión de Gastos**: CRUD completo para registro de gastos
- ✅ **Autenticación JWT**: Sistema de autenticación seguro con tokens JWT
- ✅ **Encriptación de Contraseñas**: Uso de BCrypt para hash seguro de contraseñas
- ✅ **Patrón Repository**: Implementación del patrón Repository Genérico
- ✅ **Clean Architecture**: Separación clara de responsabilidades por capas
- ✅ **AutoMapper**: Mapeo automático entre entidades y DTOs
- ✅ **Entity Framework Core**: ORM para acceso a datos
- ✅ **Documentación Swagger**: API documentada y explorable

## 🏗️ Arquitectura

```
┌─────────────────────────────────────────────────┐
│                 CONTROLLERS                     │
│  ┌─────────────┐ ┌─────────────┐ ┌──────────────┐│
│  │   Income    │ │   Expense   │ │    User      ││
│  │ Controller  │ │ Controller  │ │  Controller  ││
│  └─────────────┘ └─────────────┘ └──────────────┘│
└─────────────────┬───────────────────────────────┘
                  │
┌─────────────────▼───────────────────────────────┐
│                 SERVICES                        │
│  ┌─────────────┐ ┌─────────────┐ ┌──────────────┐│
│  │   Income    │ │   Expense   │ │    User      ││
│  │   Service   │ │   Service   │ │   Service    ││
│  └─────────────┘ └─────────────┘ └──────────────┘│
└─────────────────┬───────────────────────────────┘
                  │
┌─────────────────▼───────────────────────────────┐
│               REPOSITORIES                      │
│  ┌─────────────────────────────────────────────┐│
│  │           Generic Repository                ││
│  │        (IGenericRepository<T>)              ││
│  └─────────────────────────────────────────────┘│
└─────────────────┬───────────────────────────────┘
                  │
┌─────────────────▼───────────────────────────────┐
│                DATA LAYER                       │
│  ┌─────────────────────────────────────────────┐│
│  │           FinanceDbContext                  ││
│  │         (Entity Framework)                  ││
│  └─────────────────────────────────────────────┘│
└─────────────────┬───────────────────────────────┘
                  │
┌─────────────────▼───────────────────────────────┐
│                DATABASE                         │
│            (SQL Server/SQLite)                  │
└─────────────────────────────────────────────────┘
```

## 📁 Estructura del Proyecto

```
finance-api/
│
├── 📁 Controllers/          # Controladores API REST
│   ├── IncomeController.cs
│   ├── ExpenseController.cs
│   └── UserController.cs
│
├── 📁 Services/             # Lógica de negocio
│   ├── 📁 UserServices/
│   │   └── UserService.cs   # Autenticación JWT & BCrypt
│   ├── IIncomeService.cs
│   ├── IncomeService.cs
│   ├── IExpenseService.cs
│   └── ExpenseService.cs
│
├── 📁 Repositories/         # Acceso a datos
│   └── GenericRepository.cs
│
├── 📁 Interfaces/          # Contratos
│   └── IGenericRepository.cs
│
├── 📁 Models/              # Entidades del dominio
│   ├── Income.cs
│   ├── Expense.cs
│   └── User.cs
│
├── 📁 Dtos/                # Objetos de transferencia
│   ├── IncomeDto.cs
│   ├── ExpenseDto.cs
│   └── UserDto.cs
│
├── 📁 Data/                # Contexto de base de datos
│   └── FinanceDbContext.cs
│
├── 📁 Mappings/            # Configuración AutoMapper
│   └── MappingProfile.cs
│
├── Program.cs              # Punto de entrada
├── finance-api.csproj      # Configuración del proyecto
└── appsettings.json        # Configuraciones
```

## 🛠️ Tecnologías y Dependencias

- **.NET 8.0**: Framework principal
- **Entity Framework Core**: ORM para acceso a datos
- **AutoMapper**: Mapeo objeto-objeto
- **JWT (JSON Web Tokens)**: Autenticación y autorización
- **BCrypt.Net**: Hash seguro de contraseñas
- **Swagger/OpenAPI**: Documentación de la API

### Paquetes NuGet Principales

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" />
<PackageReference Include="AutoMapper" />
<PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" />
<PackageReference Include="System.IdentityModel.Tokens.Jwt" />
<PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" />
<PackageReference Include="BCrypt.Net-Next" />
<PackageReference Include="Swashbuckle.AspNetCore" />
```

## ⚙️ Configuración

### 1. Base de Datos

Configura la cadena de conexión en `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=FinanceApiDb;Trusted_Connection=true;"
  },
  "JwtSettings": {
    "Secret": "tu-clave-secreta-super-segura-de-al-menos-32-caracteres",
    "Issuer": "FinanceApi",
    "Audience": "FinanceApiUsers",
    "ExpiryInMinutes": 60
  }
}
```

### 2. Migración de Base de Datos

```bash
# Crear migración inicial
dotnet ef migrations add InitialCreate

# Actualizar base de datos
dotnet ef database update
```

## 🚦 Instalación y Ejecución

### Prerrequisitos

- .NET 8.0 SDK
- SQL Server (o SQL Server LocalDB)
- Visual Studio 2022 o VS Code

### Pasos de instalación

1. **Clonar el repositorio:**
   ```bash
   git clone https://github.com/mcarisc/FinanceApi.git
   cd FinanceApi/finance-api
   ```

2. **Restaurar dependencias:**
   ```bash
   dotnet restore
   ```

3. **Configurar la base de datos:**
   - Actualiza la cadena de conexión en `appsettings.json`
   - Ejecuta las migraciones:
   ```bash
   dotnet ef database update
   ```

4. **Ejecutar la aplicación:**
   ```bash
   dotnet run
   ```

La API estará disponible en:
- **HTTP**: `http://localhost:5000`
- **HTTPS**: `https://localhost:5001`
- **Swagger UI**: `https://localhost:5001/swagger`

## 📋 API Endpoints

### Autenticación
```
POST   /api/auth/register    # Registrar nuevo usuario
POST   /api/auth/login       # Iniciar sesión
```

### Ingresos
```
GET    /api/income           # Obtener todos los ingresos
GET    /api/income/{id}      # Obtener ingreso por ID
POST   /api/income           # Crear nuevo ingreso
PUT    /api/income/{id}      # Actualizar ingreso
DELETE /api/income/{id}      # Eliminar ingreso
```

### Gastos
```
GET    /api/expense          # Obtener todos los gastos
GET    /api/expense/{id}     # Obtener gasto por ID
POST   /api/expense          # Crear nuevo gasto
PUT    /api/expense/{id}     # Actualizar gasto
DELETE /api/expense/{id}     # Eliminar gasto
```

## 🔒 Seguridad

### Autenticación JWT

La API utiliza JSON Web Tokens para la autenticación:

1. **Registro/Login**: Los usuarios se registran o inician sesión para obtener un token JWT
2. **Hash de Contraseñas**: Las contraseñas se hashean usando BCrypt antes de almacenarlas
3. **Autorización**: Los endpoints protegidos requieren el token JWT en el header `Authorization`

#### Ejemplo de uso:

```bash
# Login
curl -X POST "https://localhost:5001/api/auth/login" \
  -H "Content-Type: application/json" \
  -d '{"email": "user@example.com", "password": "password123"}'

# Respuesta
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "expiration": "2024-01-01T12:00:00Z"
}

# Usar token en requests protegidos
curl -X GET "https://localhost:5001/api/income" \
  -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
```

## 📊 Modelos de Datos

### Income (Ingresos)
```csharp
public class Income
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Category { get; set; }
    public int UserId { get; set; }
}
```

### Expense (Gastos)
```csharp
public class Expense
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Category { get; set; }
    public int UserId { get; set; }
}
```

### User (Usuario)
```csharp
public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime CreatedAt { get; set; }
}
```

## 🧪 Testing

### Pruebas con Swagger

1. Navega a `https://localhost:5001/swagger`
2. Regístrate o inicia sesión para obtener un token JWT
3. Usa el botón "Authorize" en Swagger UI para configurar el token
4. Prueba los diferentes endpoints

### Ejemplo con Postman

1. **Crear colección** con los endpoints de la API
2. **Configurar variables** de entorno para la URL base y token
3. **Automatizar autenticación** usando scripts pre-request

## 🔧 Patrones de Diseño Implementados

### Repository Pattern
- **GenericRepository**: Implementación genérica para operaciones CRUD
- **IGenericRepository**: Contrato para el repositorio
- **Beneficios**: Desacoplamiento, testabilidad, reutilización de código

### Service Layer Pattern
- **Separación de responsabilidades**: Lógica de negocio en servicios
- **Inyección de dependencias**: Configurada en Program.cs
- **Manejo de errores**: Centralizado en la capa de servicios

### DTO Pattern
- **Transferencia de datos**: Objetos específicos para la API
- **AutoMapper**: Mapeo automático entre entidades y DTOs
- **Validación**: Atributos de validación en DTOs

## 📈 Próximas Mejoras

- [ ] **Logging**: Implementar logging con Serilog
- [ ] **Caching**: Redis para cache distribuido  
- [ ] **Validación**: FluentValidation para reglas de negocio complejas
- [ ] **Tests**: Unit testing y integration testing
- [ ] **Docker**: Containerización de la aplicación
- [ ] **CI/CD**: Pipeline de integración continua
- [ ] **Documentación**: Documentación técnica extendida
- [ ] **Monitoreo**: Health checks y métricas
- [ ] **Rate Limiting**: Limitación de requests por IP

## 🤝 Contribución

1. Fork el proyecto
2. Crea una rama para tu feature (`git checkout -b feature/nueva-funcionalidad`)
3. Commit tus cambios (`git commit -m 'Agregar nueva funcionalidad'`)
4. Push a la rama (`git push origin feature/nueva-funcionalidad`)
5. Abre un Pull Request

## 📝 Licencia

Este proyecto está bajo la Licencia MIT. Ver el archivo `LICENSE` para más detalles.

## 👨‍💻 Autor

**mcarisc** - [GitHub](https://github.com/mcarisc)

---

⭐ **¡Si te gusta este proyecto, dale una estrella en GitHub!**
