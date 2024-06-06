
# MarketingAppTester

MarketingAppTester is a .NET-based application designed for testing marketing campaigns and strategies. This application provides a robust platform for analyzing and optimizing marketing efforts.

## Developed by

- Hlib Pavlyk
- Nazarii Horchynskyi
- Oleksandr Bondarenko

## Technology Stack

- **.NET 8.0**: The core framework for building the application.
- **ASP.NET Core**: For building web APIs and web applications.
- **Entity Framework Core**: As the Object-Relational Mapper (ORM) for database operations.
- **xUnit**: For unit testing the application.
- **Docker**: For containerizing the application.

## Prerequisites

- [Docker](https://www.docker.com/get-started)
- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)

## Getting Started

### Building the Docker Image
 
1. **Clone the repository**:
    ```sh
    git clone https://github.com/HlibPavlyk/marketing-app-tester.git
    cd marketing-app-tester
    ```

2. **Build the Docker image**:
    ```sh
    docker build -t marketing-app-tester .
    ```

### Running the Docker Container

1. **Run the Docker container**:
    ```sh
    docker run -d -p 5286:5286 marketing-app-tester
    ```

    - The application will be available at `http://localhost:5286`

### Running Tests

1. **Run the tests using the .NET CLI**:
    ```sh
    dotnet test
    ```

### Application Configuration

The application can be configured using the `launchSettings.json` file. The relevant ports for the application is:

- HTTP: `http://localhost:5286`

### Accessing the Application

After running the Docker container, you can access the application in your browser:

- **HTTP**: [http://localhost:5286](http://localhost:5286)

## Project Structure

- **src**: Contains the main application code.
  - **MTRPZ4.UI**: The web application project.
  - **MTRPZ4.Application**: Application logic and services.
  - **MTRPZ4.Infrastructure**: Infrastructure and data access layer.
  - **MTRPZ4.DomainCore**: Core domain entities and logic.

- **tests**: Contains the unit tests for the application.
  - **MTRPZ4.UnitTests**: Unit test project using xUnit.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any changes.

## License

This project is licensed under the MIT License.

---

Happy coding!
