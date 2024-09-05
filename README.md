# SignSage

**SignSage** is a full-stack application featuring a backend API built with ASP.NET Core and a frontend client developed using Angular. The project utilizes Azure Cosmos DB for database management and includes user authentication via JWT tokens.

## Table of Contents

- [Features](#features)
- [Technologies](#technologies)
- [Setup](#setup)
- [Usage](#usage)
- [API Documentation](#api-documentation)
- [Contributing](#contributing)
- [License](#license)

## Features

- **User Authentication:** Register and login with JWT-based authentication.
- **Cosmos DB Integration:** Store and manage user data using Azure Cosmos DB.
- **Angular Frontend:** Responsive and modern UI for interacting with the backend.
- **ASP.NET Core Backend:** Robust API for handling user authentication and data management.

## Technologies

- **Frontend:**
  - Angular
  - TypeScript
  - HTML/CSS

- **Backend:**
  - ASP.NET Core
  - Entity Framework Core
  - Azure Cosmos DB
  - JWT Authentication

- **Development Tools:**
  - Visual Studio (Backend)
  - Visual Studio Code (Frontend)
  - Git

## Setup

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (5.0 or higher)
- [Node.js](https://nodejs.org/) (14.x or higher)
- [Angular CLI](https://angular.io/cli) (`npm install -g @angular/cli`)
- [Azure Cosmos DB Account](https://azure.microsoft.com/en-us/services/cosmos-db/)

### Backend Setup

1. **Clone the repository:**

   ```bash
   git clone <repository-url>
   ```

2. **Navigate to the API directory:**

   ```bash
   cd SignSageAPI
   ```

3. **Install the required packages:**

   ```bash
   dotnet restore
   ```

4. **Configure the application:**

   - Update `appsettings.json` with your Cosmos DB connection details.

5. **Run the API:**

   ```bash
   dotnet run
   ```

### Frontend Setup

1. **Navigate to the client directory:**

   ```bash
   cd SignSageClient
   ```

2. **Install the required packages:**

   ```bash
   npm install
   ```

3. **Run the Angular application:**

   ```bash
   ng serve
   ```

   The frontend will be available at `http://localhost:4200`.

## Usage

- **Register a New User:** POST request to `/api/auth/register` with `UserName`, `Email`, `Password`, and `ConfirmPassword`.
- **Login:** POST request to `/api/auth/login` with `UserName` and `Password`.
- **Access the API:** Use the JWT token obtained from the login response for authenticated requests.

## API Documentation

- **Swagger UI:** Available at `http://localhost:5079/swagger` (for the backend API).

## Contributing

1. **Fork the repository.**
2. **Create a new branch for your feature or bug fix.**
3. **Commit your changes.**
4. **Push to your forked repository.**
5. **Create a Pull Request.**
