# WebApplication2
An ASP.NET Core Web (RESTful) API built with Clean Architecture principles. This project designed to be a demonstration of a modular, testable, and maintainable backend solution following best practices for modern .NET development.

---

## 📐 Architecture Overview

This project uses **Clean Architecture**, separating concerns into distinct layers.
Basically:
- **Domain**: Core business logic and domain entities.
- **Application**: Use cases, interfaces, and DTOs.
- **Infrastructure**: External dependencies like database, file system, APIs.
- **Presentation (Web API)**: HTTP layer for exposing the API.
- **React** client 
