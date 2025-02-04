Task Master Pro is a robust and efficient to-do list application designed to help users manage tasks and lists with ease. Built using ASP.NET Core and SQL Server, this tool allows users to categorize, sort, and track tasks effortlessly. The application follows a well-structured architecture to ensure scalability, maintainability, and testability.

# Key Features & Design Choices
* ASP.NET Core & C#: Provides a strong backend with high performance and scalability.
* Entity Framework Core (Code-First Approach): Enables seamless database management and schema evolution.
* Repository Pattern: Ensures a clear separation between data access and business logic for better maintainability.
* SQL Server Integration: Reliable and efficient database management for handling complex queries.
* Layered Architecture & Dependency Injection: Promotes modularity and separation of concerns.
* Frontend with HTML, CSS, and JavaScript: Delivers a simple, user-friendly, and responsive interface


# How to Run the Application Locally
```csharp
Step 1: Configure the Connection String in appsettings.json
1.For Windows Authentication: Add the following connection string in the appsettings.json file:

"ConnectionStrings": {
    "DefaultConnection": "Server=serverAddress;Database=databaseName;Trusted_Connection=True;TrustServerCertificate=True;"
}

2.For SQL Server Authentication: Add the following connection string in the appsettings.json file:

"ConnectionStrings": {
    "DefaultConnection": "Data Source=serverAddress;Database=databaseName;User Id=yourUserId;Password=yourPassword;TrustServerCertificate=True;"
}

Step 2: Register the Connection String in Program.cs
Ensure that the connection string is registered in the Program.cs file. It should look something like this:

using Microsoft.EntityFrameworkCore;
using yourNamespace.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registering the database context with the connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
app.Run();

Step 3: Apply Migrations and Update the Database
Open the Package Manager Console (Tools > NuGet Package Manager > Package Manager Console) and run the following commands to apply any pending migrations and update the database:

Add-Migration <nameOfMigration>
Update-Database

Step 4: Run the Application Locally
You can now run the application locally by pressing F5 or selecting the IIS Express option in Visual Studio.

Step 5: Add some categories by navigating to “Categories” section in navigation bar and then add tasks as per your choice and category.
