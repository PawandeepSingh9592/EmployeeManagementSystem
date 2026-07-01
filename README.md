# Employee Management System

A Clean Architecture based Employee Management Web API built using ASP.NET Core 8, Entity Framework Core, and SQL Server.

---

## 🚀 Project Overview

This project is a RESTful Web API that manages Employees and Departments using Clean Architecture principles. It demonstrates separation of concerns, scalability, and maintainability using layered architecture.

---

## 🏗️ Architecture

The solution follows **Clean Architecture** with four main layers:

- **Domain Layer**
  - Entities (Employee, Department)
  - Core business models

- **Application Layer**
  - DTOs (Request/Response models)
  - Service interfaces & implementations
  - FluentValidation validators
  - Business logic

- **Infrastructure Layer**
  - Entity Framework Core DbContext
  - Repository implementations
  - Database migrations

- **API Layer**
  - Controllers
  - Dependency Injection setup
  - Middleware configuration
  - Swagger configuration

---

## ⚙️ Technologies Used

- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- SQL Server
- AutoMapper
- FluentValidation
- Swagger / OpenAPI
- LINQ
- Dependency Injection
- Async / Await

---

## 📌 Features

### Employee Module
- Create Employee
- Get Employee by ID
- Get all Employees
- Update Employee
- Delete (Soft Delete) Employee
- Search Employees (Name, Email)
- Filter by Department
- Sorting (Salary, Joining Date, Id)
- Pagination support

### Department Module
- Create Department
- Get all Departments

---

## 🔎 API Features

- Pagination (`pageNumber`, `pageSize`)
- Searching
- Filtering
- Sorting
- Relationship handling (Employee → Department)
- Soft Delete implementation
- Model validation using FluentValidation

---

## 🧑‍💻 Setup Instructions

### 1. Clone Repository
git clone https://github.com/PawandeepSingh9592/EmployeeManagementSystem.git

### 2. Open Project
Open solution in Visual Studio 2022 or VS Code.

### 3. Configure Database
Update connection string in:
EmployeeManagement.Api/appsettings.json

### 4. Run Migrations
dotnet ef database update

### 5. Run Project
dotnet run

### 6. Test APIs
Use Swagger: https://localhost:<port>/swagger
