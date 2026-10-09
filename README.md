EmployeeApi - ASP.NET Core Clean Architecture
A simple, production-ready REST API for managing employees built with ASP.NET Core Web API using clean architecture principles and dependency injection.



🚀 Tech Stack
.NET 8 / ASP.NET Core Web API
Entity Framework Core (InMemory)
Swagger / Swashbuckle - API documentation
Dependency Injection - built-in .NET container
🏛️ MVC Architecture (Extended to Clean Architecture)
This project follows MVC pattern extended with Service & Repository layers for clean separation of concerns:

Request -> Controller -> Service -> Repository -> DbContext -> InMemory DB
Layer	Folder	Responsibility
Model	/Models	Employee entity - represents database table
View	Swagger UI / JSON	No Razor View - API returns JSON (View = Swagger + API Response)
Controller	/Controllers	EmployeesController - handles HTTP requests, routing (api/[controller]), status codes. Thin controller, no business logic
Service (Business Logic)	/Services	IEmployeeService / EmployeeService - business rules, validation, mapping DTO -> Entity
Repository (Data Access)	/Repositories	IEmployeeRepository / EmployeeRepository - only data access, talks to AppDbContext
DTOs	/DTOs	CreateEmployeeDto - input validation, prevents over-posting
Data	/Data	AppDbContext - EF Core DbContext, InMemory provider
Why this separation?
Controller should not know how data is stored.
Service should not know EF Core.
Repository should not know business rules.
Each layer can be mocked and tested independently.
🔌 Dependency Injection - How it works
In Program.cs:

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
And in Controller:

private readonly IEmployeeService _service;
public EmployeesController(IEmployeeService service) => _service = service;
The DI Container automatically resolves:
AppDbContext -> EmployeeRepository -> EmployeeService -> EmployeesController

AddScoped = one instance per HTTP request.

📁 Project Structure
EmployeeApi/
├── Controllers/
│   └── EmployeesController.cs
├── Data/
│   └── AppDbContext.cs
├── DTOs/
│   └── CreateEmployeeDto.cs
├── Middleware/
├── Models/
│   └── Employee.cs
├── Repositories/
│   ├── IEmployeeRepository.cs
│   └── EmployeeRepository.cs
├── Services/
│   ├── IEmployeeService.cs
│   └── EmployeeService.cs
├── Properties/
│   └── launchSettings.json
├── Program.cs
└── EmployeeApi.csproj
📚 API Endpoints
Method	Endpoint	Description
GET	/api/Employees	Get all employees
GET	/api/Employees/{id}	Get employee by Id
POST	/api/Employees	Create new employee
DELETE	/api/Employees/{id}	Delete employee
Example POST Body:

{
  "name": "Sayaka",
  "age": 25,
  "department": "IT"
}
▶️ How to Run
# 1. Clone
git clone https://github.com/SayakaMeem/EmployeeApi.git
cd EmployeeApi
# 2. Restore packages
dotnet restore
# 3. Run
dotnet run
Open Swagger:

http://localhost:5115/swagger/index.html
🔮 Future Improvements
 Add PUT /api/Employees/{id} - Update
 Add SQL Server instead of InMemory
 Add FluentValidation
 Add Unit Tests for Service layer
 Add JWT Authentication
👩‍💻 Author
Sayaka Meem - GitHub

Built while learning Clean Architecture & Dependency Injection in ASP.NET Core.
