# CarSenegal - Car Rental Application

## Overview

CarSenegal is an innovative car rental application designed for the Senegalese market. It connects vehicle owners with potential renters, offering a convenient and efficient solution for mobility in Senegal.

## Features

- User registration and authentication (Vehicle Owners and Renters)
- Vehicle listing and management
- Reservation system
- Payment processing
- Review and rating system
- Support ticket management
- Analytics dashboard

## Technology Stack

- Backend: ASP.NET Core 8 Web API
- Database: Microsoft SQL Server
- ORM: Entity Framework Core 8
- Architecture: Clean Architecture
- API Documentation: Swagger / OpenAPI
- Authentication: JWT (JSON Web Tokens)

## Project Structure

The solution follows Clean Architecture principles and is organized into the following projects:

- `CarSenegal.API`: Web API project, entry point of the application
- `CarSenegal.Application`: Contains application logic, DTOs, and interfaces
- `CarSenegal.Domain`: Contains domain entities and interfaces
- `CarSenegal.Infrastructure`: Contains data access implementations and external service integrations

## Getting Started

### Prerequisites

- .NET 8 SDK
- SQL Server
- Visual Studio 2022 or later / Visual Studio Code

### Setup

1. Clone the repository:
   ```
   git clone https://github.com/your-repo/CarSenegal.git
   ```

2. Navigate to the project directory:
   ```
   cd CarSenegal
   ```

3. Update the connection string in `CarSenegal.API/appsettings.json` with your SQL Server details.

4. Apply database migrations:
   ```
   dotnet ef database update --project CarSenegal.Infrastructure --startup-project CarSenegal.API
   ```

5. Run the application:
   ```
   dotnet run --project CarSenegal.API
   ```

6. Open a web browser and navigate to `https://localhost:5001/swagger` to view the Swagger UI.

## Configuration

- Database connection strings and other configuration settings can be found in `CarSenegal.API/appsettings.json`.
- For production deployments, ensure to use secure methods for storing sensitive information like connection strings (e.g., Azure Key Vault).

## API Documentation

API documentation is available via Swagger. When running the application, navigate to `/swagger` to view and interact with the API endpoints.

## Testing

The solution includes unit tests and integration tests. To run the tests:

```
dotnet test
```

## Deployment

For deployment instructions, please refer to the [Deployment Guide](./docs/deployment-guide.md).

## Contributing

Please read [CONTRIBUTING.md](./CONTRIBUTING.md) for details on our code of conduct and the process for submitting pull requests.

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/your-repo/CarSenegal/tags).

## Authors

- **Your Name** - *Initial work* - [YourGitHub](https://github.com/YourGitHub)

See also the list of [contributors](https://github.com/your-repo/CarSenegal/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.

## Acknowledgments

- Hat tip to anyone whose code was used
- Inspiration
- etc.
