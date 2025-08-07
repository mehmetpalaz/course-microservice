# Course Microservice Platform

A modern, scalable microservices-based course management platform built with .NET 8 and Clean Architecture principles.

## ??? Architecture Overview

This project implements a microservices architecture with the following services:

### Current Services
- **Catalog API** - Manages courses and categories
- **Basket API** - Handles shopping basket functionality
- **Shared Library** - Common functionality across microservices

### Planned Services (Coming Soon)
- Authentication & Authorization Service
- Payment Service
- User Management Service
- Notification Service
- API Gateway

## ??? Tech Stack

- **Framework**: .NET 8
- **Architecture**: Clean Architecture with CQRS pattern
- **Database**: 
  - MongoDB (Catalog Service)
  - Redis (Basket Service)
- **Libraries**:
  - MediatR for CQRS implementation
  - FluentValidation for input validation
  - AutoMapper for object mapping
  - ASP.NET Core API Versioning
- **Containerization**: Docker & Docker Compose

## ?? Getting Started

### Prerequisites
- .NET 8 SDK
- Docker & Docker Compose
- Git

### Running the Application

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd CourseMicroservice
   ```

2. **Set up environment variables**
   - Copy `.env.example` to `.env` (if exists)
   - Configure your database credentials

3. **Start the infrastructure**
   ```bash
   docker-compose up -d
   ```

4. **Run the services**
   ```bash
   # Terminal 1 - Catalog API
   cd CourseMicroservice.Catalog.Api
   dotnet run

   # Terminal 2 - Basket API
   cd CourseMicroservice.Basket.Api
   dotnet run
   ```

### Available Services

| Service | Port | Swagger UI |
|---------|------|------------|
| Catalog API | 5001 | http://localhost:5001/swagger |
| Basket API | 5002 | http://localhost:5002/swagger |

### Database Management UIs

| Service | Port | Description |
|---------|------|-------------|
| Mongo Express | 27032 | MongoDB management UI |
| Redis Commander | 27033 | Redis management UI |

## ?? Project Structure

```
CourseMicroservice/
??? CourseMicroservice.Catalog.Api/     # Course & Category management
?   ??? Features/
?   ?   ??? Categories/                 # Category CRUD operations
?   ?   ??? Courses/                    # Course CRUD operations
?   ??? Repositories/                   # Data access layer
??? CourseMicroservice.Basket.Api/      # Shopping basket functionality
?   ??? Features/
?       ??? Baskets/                    # Basket operations
??? CourseMicroservice.Shared/          # Shared libraries
?   ??? Extensions/                     # Common service extensions
?   ??? Filters/                        # Shared filters
??? docker-compose.yml                 # Infrastructure setup
```

## ??? Architecture Patterns

- **Clean Architecture**: Clear separation of concerns with distinct layers
- **CQRS (Command Query Responsibility Segregation)**: Separate read and write operations
- **Vertical Slice Architecture**: Features organized by business capability
- **API Versioning**: Built-in support for API evolution
- **Repository Pattern**: Data access abstraction

## ?? Key Features

### Catalog Service
- ? Course management (CRUD operations)
- ? Category management
- ? MongoDB integration with Entity Framework
- ? Automatic data seeding
- ? API versioning support

### Basket Service
- ? Add items to basket
- ? Redis caching for performance
- ? API versioning support

### Shared Library
- ? Common service extensions
- ? Validation filters
- ? API versioning configuration
- ? MediatR integration
- ? AutoMapper configuration

## ?? Development Status

This project is in active development. The foundation has been established with core services, and additional microservices will be added incrementally.

### Completed ?
- Basic microservice infrastructure
- Catalog service with full CRUD operations
- Basket service foundation
- Docker containerization
- API versioning
- Input validation
- Clean architecture implementation

### In Progress ??
- Enhanced basket operations
- Service-to-service communication
- Error handling improvements

### Planned ??
- Authentication & Authorization
- API Gateway implementation
- Payment processing
- User management
- Event-driven communication
- Monitoring & logging
- Automated testing suite

## ?? Contributing

This is a learning and development project. Feel free to explore the code and suggest improvements!

## ?? License

This project is for educational and development purposes.

---

**Note**: This project is continuously evolving. Check back regularly for updates and new service implementations!