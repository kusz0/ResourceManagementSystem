# ResourceManagementSystem

A .NET 8 console application that simulates a distributed-style company resource management system. The project demonstrates object-oriented design, clean architecture principles, and incremental development using Git.

## Project Description

ResourceManagementSystem allows organizations to manage employees, departments, company resources, and resource assignments through a simple console interface. The application maintains in-memory collections of data and provides reporting capabilities to visualize organizational structure and resource utilization.

## Features

### Employee Management
- Add employees with name, position, and email
- Remove employees by identifier
- List all employees

### Department Management
- Create departments with name and description
- Assign employees to departments
- List all departments

### Resource Management
- Add resources with name and type
- Remove resources by identifier
- List all resources

### Resource Assignment
- Assign resources to employees
- Release assigned resources
- Prevent duplicate assignments (a resource cannot be assigned twice)

### Reporting
- Display all employees with department information
- Display all resources and availability status
- Display currently assigned resources
- Display department summaries with member lists

### Console Menu
Interactive menu for viewing employees, resources, departments, and reports.

### Sample Data
On startup, the application automatically loads sample employees, departments, resources, and example assignments for demonstration.

## Installation Instructions

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Git (optional, for cloning the repository)

### Clone the Repository
```bash
git clone https://github.com/<your-username>/ResourceManagementSystem.git
cd ResourceManagementSystem
```

### Restore Dependencies
```bash
dotnet restore
```

## Running Instructions

### Build the Project
```bash
dotnet build
```

### Run the Application
```bash
dotnet run --project ResourceManagementSystem
```

Alternatively, open `ResourceManagementSystem.sln` in Visual Studio and press **F5** to run.

### Menu Navigation
| Option | Action |
|--------|--------|
| 1 | View all employees |
| 2 | View all resources |
| 3 | View all departments |
| 4 | Open reports sub-menu |
| 0 | Exit the application |

## Architecture Overview

The project follows a layered, object-oriented design with one class per file:

```
ResourceManagementSystem/
├── Program.cs           # Application entry point and console menu
├── Employee.cs          # Employee domain model
├── Department.cs        # Department domain model
├── Resource.cs          # Resource domain model
└── ResourceManager.cs   # Core service layer (CRUD, assignments, reporting)
```

### Design Principles
- **Separation of concerns**: Domain models are separate from business logic and presentation
- **Single responsibility**: Each class handles one aspect of the system
- **Encapsulation**: `ResourceManager` encapsulates all data storage and operations
- **XML documentation**: All public classes and methods include XML comments

### Data Flow
```
User Input (Console Menu)
        ↓
    Program.cs
        ↓
  ResourceManager (Service Layer)
        ↓
  Domain Models (Employee, Department, Resource)
```

## Git Workflow Description

This project was developed incrementally using feature-based commits to simulate a real team workflow:

| Commit | Description |
|--------|-------------|
| Initial project structure | Solution, project file, and entry point |
| Add Employee model | Employee domain class |
| Add Department model | Department domain class |
| Add Resource model | Resource domain class |
| Implement ResourceManager service | Core CRUD operations |
| Add resource assignment functionality | Assign and release resources |
| Add reporting module | Report generation methods |
| Add console menu | Interactive user interface |
| Add sample data | Startup data seeding |
| Add README documentation | Project documentation |

### Recommended Workflow
1. Create a feature branch from `main`
2. Implement a single feature or fix
3. Run `dotnet build` to verify compilation
4. Stage changes with `git add`
5. Commit with a descriptive message
6. Push and open a pull request for review
7. Merge into `main` after approval

### Useful Git Commands
```bash
# View commit history
git log --oneline

# Check current status
git status

# Create a feature branch
git checkout -b feature/my-feature

# Stage and commit changes
git add .
git commit -m "Describe your change"
```

## License

This project was created as a university assignment demonstrating C# development and Git version control practices.
