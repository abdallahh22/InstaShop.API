# 🛒 InstaShop Clone - ASP.NET Core Web API

## 📄 Description
Developed a RESTful API for an e-commerce platform similar to **InstaShop**, a delivery service marketplace that connects users with local stores and delivery providers.

- Users can browse stores and products, place orders, and track deliveries efficiently.
- Implemented authentication and authorization using **JWT** and **ASP.NET Identity** for secure access.
- Optimized database performance using **Entity Framework Core** and **LINQ**.
- Integrated **Redis caching** to improve response times.
- Followed **Clean Architecture principles** to ensure scalability and maintainability.

---

## ⚙️ Tech Stack
- ASP.NET Core
- Clean Architecture
- Repository & Unit of Work Pattern
- Entity Framework Core
- SQL Server
- JWT Authentication
- ASP.NET Identity
- LINQ
- Redis
- Swagger
- Postman

---

## 📂 Project Structure

├── Store.Data          # Entities and Interfaces
├── Store.Repository    # EFCore and Repositories
├── Store.Service       # Business Logic, DTOs, Services
└── Store.API           # Controllers, Middleware, Program.cs
