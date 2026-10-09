
# EmployeeApi - ASP.NET Core Clean Architecture

A simple, production-ready REST API for managing employees built with ASP.NET Core Web API using clean architecture principles and dependency injection.

### 🚀 Tech Stack
- .NET 8 / ASP.NET Core Web API
- Entity Framework Core (InMemory)
- Swagger / Swashbuckle
- Dependency Injection

### 🏛️ MVC Architecture (Extended)

This project follows MVC extended with Service & Repository:
Client Request -> Controller -> Service -> Repository -> DbContext -> DB

| Layer | Folder | Responsibility |
| :--- | :--- | :--- |
| **Model** | `/Models` | `Employee.cs` - Entity |
| **View** | `Swagger / JSON` | API returns JSON, Swagger UI is View |
| **Controller** | `/Controllers` | `EmployeesController.cs` - handles HTTP, routing, status codes |
| **Service** | `/Services` | `IEmployeeService` / `EmployeeService` - business logic, validation |
| **Repository** | `/Repositories` | `IEmployeeRepository` / `EmployeeRepository` - EF Core queries only |
| **DTOs** | `/DTOs` | `CreateEmployeeDto` - prevents over-posting |
| **Data** | `/Data` | `AppDbContext` - InMemory database |

**Dependency Injection in Program.cs:**
```csharp
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
Controller gets Service via constructor injection. Scoped = one instance per request.

📁 Project Structure
EmployeeApi/
├── Controllers/EmployeesController.cs
├── Data/AppDbContext.cs
├── DTOs/CreateEmployeeDto.cs
├── Models/Employee.cs
├── Repositories/IEmployeeRepository.cs, EmployeeRepository.cs
├── Services/IEmployeeService.cs, EmployeeService.cs
├── Program.cs
└── EmployeeApi.csproj

📚 API Endpoints

Method	Endpoint	Description
GET	/api/Employees	Get all
GET	/api/Employees/{id}	Get by Id
POST	/api/Employees	Create new
DELETE	/api/Employees/{id}	Delete

POST Example:

{
  "name": "Sayaka",
  "age": 25,
  "department": "IT"
}

▶️ How to Run

git clone https://github.com/SayakaMeem/EmployeeApi
cd EmployeeApi
dotnet restore
dotnet run

Open Swagger: http://localhost:5115/swagger/index.html

Author
Sayaka Meem - https://github.com/SayakaMeem
Built while learning Clean Architecture & DI in ASP.NET Core.
