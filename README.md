# HackerNews - Best Stories API

A high-performance RESTful API built with **.NET 8** that retrieves the top *n* stories from the Hacker News API, sorted by score in descending order.

## 📝 Changelog
- **07/04/2026**: Initial project setup and solution structure (Clean Architecture).
- **08/04/2026**: Implementation of Core logic, Infrastructure layer with `IMemoryCache`, and parallel processing using `Task.WhenAll`.
- **08/04/2026**: Added unit tests using **xUnit** and **Moq** to validate sorting and mapping logic.
- **08/04/2026**: Environment configuration and README optimization for technical assessment.
- **08/04/2026**: Assumption added: the server hosting this API and the Hacker News API can handle approximately 200 near-simultaneous requests.

---

## 🎯 Technical Assessment: HackerNews API Integration

This project was developed as part of a **technical knowledge assessment for Talan / Santander**. 

The solution implements a high-performance **.NET 8 (C#)** Web API, following **Clean Architecture** principles and **Domain-Driven Design (DDD)** patterns. The primary objective is to demonstrate seniority in handling:

* **Performance Optimization:** Efficient management of external API integrations.
* **Asynchronous Parallelism:** Minimizing latency through concurrent data fetching.
* **Resilience & Efficiency:** Implementing robust caching strategies (`IMemoryCache`) to reduce redundant network calls.
* **Quality Assurance:** Ensuring reliability with unit testing and mock dependencies.

---

## ✨ Features

### BACKEND:
- **Clean Architecture**: Separation of concerns into API, Core, and Infrastructure layers.
- **Design Patterns**: 
  - **Repository Pattern**: Abstracting data access logic.
  - **Dependency Injection**: Using Typed Clients for external services.
  - **DTOs**: Decoupling internal entities from API responses.
- **Parallelism**: Efficient data fetching using asynchronous tasks (`Task.WhenAll`) to handle multiple concurrent HTTP requests.
- **Resilience**: In-memory caching to prevent rate-limiting and reduce overhead on the Hacker News API.

### TESTING:
- **xUnit**: Comprehensive unit testing for repository and sorting logic.
- **Moq**: Professional mocking of `HttpMessageHandler` to simulate external API responses without network dependency.

---

## 🧰 Technologic Stack
- **Framework**: .NET 8 (ASP.NET Core Web API)
- **Testing**: xUnit & Moq
- **Documentation**: Swagger / OpenAPI
- **Logging**: Default ILogger implementation

---

## ⚙️ Quick Start

### 1. Clone & Setup
```bash
# Clone the repository
git clone [https://github.com/waltermillan/HackerNews.git](https://github.com/waltermillan/HackerNews.git)

# Navigate to the solution folder
cd HackerNews/backend