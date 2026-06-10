# ResourceManagementSystem

A .NET 8 console application that simulates a distributed-style company resource management system.

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
