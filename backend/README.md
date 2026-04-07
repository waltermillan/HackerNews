# HackerNews - Best Stories API
A high-performance RESTful API built with **.NET 8** that retrieves the top *n* stories from the Hacker News API, sorted by score in descending order.

## Changelog
- **06/04/2026**: Initial project setup and solution structure (Clean Architecture).
- **07/04/2026**: Implementation of the Core logic, Infrastructure layer with `IMemoryCache`, and parallel processing using `Task.WhenAll`.
- **07/04/2026**: Added unit tests using **xUnit** and **Moq** to validate sorting and mapping logic.

## Objective:
Practice **.NET 8 (C#)** focusing on **High Performance**, **Clean Architecture**, and **Design Patterns**. 
The goal is to demonstrate how to handle external API integrations efficiently by implementing caching strategies and asynchronous parallelism to minimize latency.

## Features

### BACKEND:
- **Clean Architecture** (API, Core, Infrastructure).
- **Design Patterns**: 
  - Repository Pattern
  - Dependency Injection (Typed Clients)
  - Data Transfer Objects (DTOs)
  - Singleton (Cache Management)
- **Parallelism**: Efficient data fetching using asynchronous tasks to handle multiple concurrent HTTP requests.
- **Resilience**: In-memory caching to prevent rate-limiting and reduce overhead on the Hacker News API.

### TESTING:
- **xUnit**: Comprehensive unit testing for repository logic.
- **Moq**: Mocking of `HttpMessageHandler` to simulate external API responses without network dependency.

## 🧰 Technologic Stack

- **Framework**: .NET 8 (ASP.NET Core Web API)
- **Testing**: xUnit & Moq
- **IDE**: Visual Studio / VS Code
- **Documentation**: Swagger / OpenAPI

## ⚙️ Installation

1. **Clone the repository**:
   ```bash
   git clone [https://github.com/waltermillan/HackerNews.git](https://github.com/waltermillan/HackerNews.git)