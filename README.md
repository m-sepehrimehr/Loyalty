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

-   **OAuth2 Authentication** (Keycloak or other providers)

-   **Redis** caching for performance optimization

-   **Docker** containerization for easy deployment

📦 Getting Started
------------------

Follow these steps to run the project locally.

### 1\. Clone the Repository

bash

CopyEdit

`git clone https://github.com/your-username/simple-loyalty-api.git
cd simple-loyalty-api`

### 2\. Configure Environment

Create a `.env` file or set the following variables in `appsettings.json`:

-   Database connection string

-   Redis connection string

-   OAuth2 settings (authority, clientId, etc.)

### 3\. Run Database Migrations

bash

CopyEdit

`dotnet ef database update`

Make sure you have the EF Core CLI installed.

### 4\. Build and Run with Docker

bash

CopyEdit

`docker build -t loyalty-api .
docker run -p 5000:80 loyalty-api`

### 5\. Run Without Docker (Optional)

bash

CopyEdit

`dotnet run`

### 6\. Run Unit Tests

bash

CopyEdit

`dotnet test`

🛡️ Authentication
------------------

The API uses OAuth2 for authentication. Configure your Keycloak or OAuth2 provider in the settings, and make sure to secure your endpoints accordingly.

🧪 Example Endpoint
-------------------

-   **POST** `/api/points/earn`\
    Request body:

    json

    CopyEdit

    `{
      "userId": "123",
      "points": 10
    }`

📂 Project Structure
--------------------

diff

CopyEdit

`- Controllers/
- Services/
- Models/
- Data/
- Validators/
- Tests/`

📌 Prerequisites
----------------

-   [.NET 7 SDK](https://dotnet.microsoft.com/download)

-   [Docker](https://www.docker.com/)

-   [Redis](https://redis.io/)

-   [Keycloak](https://www.keycloak.org/) or any OAuth2 provider