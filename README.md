🏆 Simple Loyalty System API
============================

A minimalistic API built with .NET Core that allows users to earn and manage loyalty points. The system includes essential backend features like logging, validation, authentication, caching, and containerization---ideal for learning and demonstration purposes.

🚀 Features
-----------

-   **.NET Core** for robust API development

-   **Serilog** for structured logging

-   **Entity Framework Core (EF Core)** with migrations for database access

-   **FluentValidation** for input validation

-   **XUnit + Moq** for unit testing

-   **OAuth2 Authentication** (Keycloak)

-   **Redis** caching for performance optimization

-   **Docker** containerization for easy deployment

📦 Getting Started
------------------

Follow these steps to run the project locally.

### 1\. Clone the Repository

bash

CopyEdit

`git clone https://github.com/m-sepehrimehr/Loyalty.git
cd simple-loyalty-api`

### 2\. Run with Docker-compose

bash

CopyEdit

`docker-compose up --build`

### 3\. Open in browser

bash

CopyEdit

`http://localhost:5000/swagger`