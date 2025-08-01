# Course Microservice

A modern microservices-based course management system built with .NET 8.0 and MongoDB, designed to handle course catalogs, categories, and related operations.

## 🚀 Overview

This project implements a microservices architecture for managing online courses and categories. It provides a robust API for course catalog operations with clean architecture principles and modern development practices.

**⚠️ Note: This project is in early development stage. Some features may be incomplete or under active development.**

## 🛠️ Technology Stack

- **.NET 8.0** - Core framework
- **ASP.NET Core Web API** - REST API development
- **MongoDB** - NoSQL database
- **Entity Framework Core** - Data access layer with MongoDB provider
- **Docker & Docker Compose** - Containerization and orchestration
- **Swagger/OpenAPI** - API documentation
- **FluentValidation** - Input validation
- **MediatR** - Mediator pattern implementation
- **NewId** - Unique identifier generation

## 📋 Prerequisites

Before running this application, make sure you have the following installed:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/install/)
- [Git](https://git-scm.com/)

## 🏗️ Project Structure

```
course-microservice/
├── CourseMicroservice.Catalog.Api/          # Main catalog API service
│   ├── Features/                           # Feature-based organization
│   │   ├── Categories/                     # Category management
│   │   │   ├── Create/                     # Create category command & handler
│   │   │   ├── GetAll/                     # Get all categories query & handler
│   │   │   └── Dtos/                       # Data transfer objects
│   │   └── Courses/                        # Course management
│   ├── Options/                            # Configuration options
│   ├── Repositories/                       # Data access layer
│   └── Program.cs                          # Application entry point
├── CourseMicroservice.Shared/               # Shared components library
│   ├── Extensions/                         # Extension methods
│   ├── Filters/                            # Request filters
│   └── ServiceResult.cs                    # Common result pattern
├── docker-compose.yml                       # Docker services configuration
├── CourseMicroservice.sln                   # Solution file
└── README.md                               # Project documentation
```

### Architecture Patterns

This project follows several architectural patterns:

- **Clean Architecture**: Separation of concerns with clear boundaries
- **CQRS (Command Query Responsibility Segregation)**: Separate models for read and write operations
- **Mediator Pattern**: Using MediatR for request/response handling
- **Feature-based Organization**: Code organized by business features rather than technical layers
- **Repository Pattern**: Data access abstraction
- **Microservices Architecture**: Independent, loosely coupled services

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/mehmetpalaz/course-microservice.git
cd course-microservice
```

### 2. Environment Setup

The project uses environment variables for configuration. The default values are provided in the `.env` file:

```bash
MONGO_USERNAME=mongouser
MONGO_PASSWORD=mongopassword
```

### 3. Running with Docker Compose (Recommended)

Start all services including MongoDB and Mongo Express UI:

```bash
docker-compose up -d
```

This will start:
- **MongoDB** on port `27030`
- **Mongo Express UI** on port `27032` (Database management interface)

### 4. Running the API Locally

```bash
# Restore dependencies
dotnet restore

# Run the Catalog API
cd CourseMicroservice.Catalog.Api
dotnet run
```

The API will be available at:
- **HTTP**: `http://localhost:5000`
- **HTTPS**: `https://localhost:5001`
- **Swagger UI**: `http://localhost:5000/swagger`

## 📚 API Documentation

### Endpoints Overview

The API provides the following main endpoints:

#### Categories
- `GET /categories` - Get all categories
- `POST /categories` - Create a new category

#### Courses
- Course management endpoints (implementation in progress)

### Swagger Documentation

When running in development mode, you can access the interactive API documentation at:
`http://localhost:5000/swagger`

## 🗄️ Database

The application uses MongoDB as its primary database. The database configuration includes:

- **Database**: MongoDB
- **Connection**: Configured via environment variables
- **Port**: 27030 (when using Docker Compose)
- **Management UI**: Mongo Express available at `http://localhost:27032`

### Data Models

#### Category
```csharp
public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Course> Courses { get; set; }
}
```

#### Course
```csharp
public class Course
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Picture { get; set; }
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
    public DateTime CreatedDate { get; set; }
    public Category Category { get; set; }
    public Feature Feature { get; set; }
}
```

## 🧪 Development

### Building the Project

**Note**: The project is currently in development and may require additional setup steps.

```bash
# Build the entire solution
dotnet restore CourseMicroservice.sln
dotnet build CourseMicroservice.sln

# Build specific project
dotnet build CourseMicroservice.Catalog.Api
```

### Development Environment

For development, you can run the services individually:

1. Start MongoDB using Docker:
```bash
docker-compose up mongo.db.catalog mongo.db.catalog.ui -d
```

2. Run the API in development mode:
```bash
cd CourseMicroservice.Catalog.Api
dotnet run --environment Development
```

### Troubleshooting

#### Common Issues

1. **Missing shared project**: If you encounter build errors related to `CourseMicroservice.Shared`, ensure the shared project is properly set up.

2. **MongoDB connection issues**: Verify that MongoDB is running and accessible on the configured port (default: 27030).

3. **Build errors**: The project is in active development. Some features may be incomplete.

#### Quick fixes

```bash
# Clean and rebuild
dotnet clean
dotnet restore
dotnet build

# Reset Docker containers
docker-compose down
docker-compose up -d
```

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

### Coding Standards

- Follow C# naming conventions
- Use meaningful commit messages
- Add appropriate documentation for new features
- Ensure all tests pass before submitting

## 🗺️ Roadmap

### Current Status
- ✅ Basic project structure
- ✅ Category management API foundation
- ✅ MongoDB integration setup
- ✅ Docker containerization
- 🔄 Core business logic implementation
- 🔄 API endpoint completion

### Planned Features
- 🔄 Complete course management API
- 🔄 User authentication and authorization
- 🔄 Course enrollment system
- 🔄 Search and filtering capabilities
- 🔄 File upload for course materials
- 🔄 API versioning
- 🔄 Unit and integration tests
- 🔄 CI/CD pipeline
- 🔄 Monitoring and logging

### Known Issues
- Some API endpoints are under development
- Shared library components need completion
- Integration tests not yet implemented

## 📄 License

This project is licensed under the MIT License. See the LICENSE file for details.

## 📞 Support

If you have any questions or need help with the setup, please:

1. Check the [Issues](https://github.com/mehmetpalaz/course-microservice/issues) page
2. Create a new issue if your question isn't already answered
3. Contact the maintainer: [@mehmetpalaz](https://github.com/mehmetpalaz)

---

**Happy Coding! 🎉**