namespace ResourceManagementSystem;

/// <summary>
/// Central service for managing employees, departments, and resources.
/// </summary>
public class ResourceManager
{
    private readonly List<Employee> _employees = new();
    private readonly List<Department> _departments = new();
    private readonly List<Resource> _resources = new();

    private int _nextEmployeeId = 1;
    private int _nextDepartmentId = 1;
    private int _nextResourceId = 1;

    /// <summary>
    /// Populates the system with sample data for demonstration purposes.
    /// </summary>
    public void SeedSampleData()
    {
        var engineering = CreateDepartment("Engineering", "Software development and technical operations");
        var hr = CreateDepartment("Human Resources", "Employee relations and recruitment");
        var operations = CreateDepartment("Operations", "Day-to-day business operations");

        var alice = AddEmployee("Alice Johnson", "Software Engineer", "alice.johnson@company.com");
        var bob = AddEmployee("Bob Smith", "HR Manager", "bob.smith@company.com");
        var carol = AddEmployee("Carol Williams", "Operations Lead", "carol.williams@company.com");
        var david = AddEmployee("David Brown", "DevOps Engineer", "david.brown@company.com");

        AssignEmployeeToDepartment(alice.Id, engineering.Id);
        AssignEmployeeToDepartment(david.Id, engineering.Id);
        AssignEmployeeToDepartment(bob.Id, hr.Id);
        AssignEmployeeToDepartment(carol.Id, operations.Id);

        var laptop = AddResource("Dell Latitude 5540", "Laptop");
        var monitor = AddResource("LG UltraWide Monitor", "Monitor");
        var vehicle = AddResource("Ford Transit Van", "Vehicle");
        var phone = AddResource("iPhone 15 Pro", "Mobile Device");

        AssignResourceToEmployee(laptop.Id, alice.Id);
        AssignResourceToEmployee(monitor.Id, alice.Id);
        AssignResourceToEmployee(vehicle.Id, carol.Id);
        AssignResourceToEmployee(phone.Id, bob.Id);
    }

    /// <summary>
    /// Adds a new employee to the system.
    /// </summary>
    /// <param name="name">The employee's full name.</param>
    /// <param name="position">The employee's job position.</param>
    /// <param name="email">The employee's email address.</param>
    /// <returns>The created employee.</returns>
    public Employee AddEmployee(string name, string position, string email)
    {
        var employee = new Employee
        {
            Id = _nextEmployeeId++,
            Name = name,
            Position = position,
            Email = email
        };

        _employees.Add(employee);
        return employee;
    }

    /// <summary>
    /// Removes an employee from the system by identifier.
    /// </summary>
    /// <param name="employeeId">The identifier of the employee to remove.</param>
    /// <returns><c>true</c> if the employee was removed; otherwise, <c>false</c>.</returns>
    public bool RemoveEmployee(int employeeId)
    {
        var employee = _employees.FirstOrDefault(e => e.Id == employeeId);
        if (employee is null)
        {
            return false;
        }

        _employees.Remove(employee);
        return true;
    }

    /// <summary>
    /// Returns a read-only list of all employees.
    /// </summary>
    /// <returns>A list of employees.</returns>
    public IReadOnlyList<Employee> ListEmployees()
    {
        return _employees.AsReadOnly();
    }

    /// <summary>
    /// Creates a new department in the system.
    /// </summary>
    /// <param name="name">The department name.</param>
    /// <param name="description">A description of the department.</param>
    /// <returns>The created department.</returns>
    public Department CreateDepartment(string name, string description)
    {
        var department = new Department
        {
            Id = _nextDepartmentId++,
            Name = name,
            Description = description
        };

        _departments.Add(department);
        return department;
    }

    /// <summary>
    /// Assigns an employee to a department.
    /// </summary>
    /// <param name="employeeId">The identifier of the employee.</param>
    /// <param name="departmentId">The identifier of the department.</param>
    /// <returns><c>true</c> if the assignment succeeded; otherwise, <c>false</c>.</returns>
    public bool AssignEmployeeToDepartment(int employeeId, int departmentId)
    {
        var employee = _employees.FirstOrDefault(e => e.Id == employeeId);
        var department = _departments.FirstOrDefault(d => d.Id == departmentId);

        if (employee is null || department is null)
        {
            return false;
        }

        employee.DepartmentId = departmentId;
        return true;
    }

    /// <summary>
    /// Returns a read-only list of all departments.
    /// </summary>
    /// <returns>A list of departments.</returns>
    public IReadOnlyList<Department> ListDepartments()
    {
        return _departments.AsReadOnly();
    }

    /// <summary>
    /// Adds a new resource to the system.
    /// </summary>
    /// <param name="name">The resource name.</param>
    /// <param name="type">The resource type.</param>
    /// <returns>The created resource.</returns>
    public Resource AddResource(string name, string type)
    {
        var resource = new Resource
        {
            Id = _nextResourceId++,
            Name = name,
            Type = type
        };

        _resources.Add(resource);
        return resource;
    }

    /// <summary>
    /// Removes a resource from the system by identifier.
    /// </summary>
    /// <param name="resourceId">The identifier of the resource to remove.</param>
    /// <returns><c>true</c> if the resource was removed; otherwise, <c>false</c>.</returns>
    public bool RemoveResource(int resourceId)
    {
        var resource = _resources.FirstOrDefault(r => r.Id == resourceId);
        if (resource is null)
        {
            return false;
        }

        _resources.Remove(resource);
        return true;
    }

    /// <summary>
    /// Returns a read-only list of all resources.
    /// </summary>
    /// <returns>A list of resources.</returns>
    public IReadOnlyList<Resource> ListResources()
    {
        return _resources.AsReadOnly();
    }

    /// <summary>
    /// Assigns a resource to an employee.
    /// </summary>
    /// <param name="resourceId">The identifier of the resource.</param>
    /// <param name="employeeId">The identifier of the employee.</param>
    /// <returns><c>true</c> if the assignment succeeded; otherwise, <c>false</c>.</returns>
    public bool AssignResourceToEmployee(int resourceId, int employeeId)
    {
        var resource = _resources.FirstOrDefault(r => r.Id == resourceId);
        var employee = _employees.FirstOrDefault(e => e.Id == employeeId);

        if (resource is null || employee is null)
        {
            return false;
        }

        if (resource.IsAssigned)
        {
            return false;
        }

        resource.IsAssigned = true;
        resource.AssignedEmployeeId = employeeId;
        return true;
    }

    /// <summary>
    /// Releases a resource from its current assignment.
    /// </summary>
    /// <param name="resourceId">The identifier of the resource to release.</param>
    /// <returns><c>true</c> if the resource was released; otherwise, <c>false</c>.</returns>
    public bool ReleaseResource(int resourceId)
    {
        var resource = _resources.FirstOrDefault(r => r.Id == resourceId);
        if (resource is null || !resource.IsAssigned)
        {
            return false;
        }

        resource.IsAssigned = false;
        resource.AssignedEmployeeId = null;
        return true;
    }

    /// <summary>
    /// Determines whether a resource is currently assigned.
    /// </summary>
    /// <param name="resourceId">The identifier of the resource.</param>
    /// <returns><c>true</c> if the resource is assigned; otherwise, <c>false</c>.</returns>
    public bool IsResourceAssigned(int resourceId)
    {
        var resource = _resources.FirstOrDefault(r => r.Id == resourceId);
        return resource?.IsAssigned ?? false;
    }

    /// <summary>
    /// Displays a report of all employees in the system.
    /// </summary>
    public void DisplayEmployeeReport()
    {
        Console.WriteLine("\n=== Employee Report ===");
        if (_employees.Count == 0)
        {
            Console.WriteLine("No employees found.");
            return;
        }

        foreach (var employee in _employees)
        {
            string departmentName = GetDepartmentName(employee.DepartmentId);
            Console.WriteLine($"{employee} | Department: {departmentName}");
        }
    }

    /// <summary>
    /// Displays a report of all resources in the system.
    /// </summary>
    public void DisplayResourceReport()
    {
        Console.WriteLine("\n=== Resource Report ===");
        if (_resources.Count == 0)
        {
            Console.WriteLine("No resources found.");
            return;
        }

        foreach (var resource in _resources)
        {
            Console.WriteLine(resource);
        }
    }

    /// <summary>
    /// Displays a report of all currently assigned resources.
    /// </summary>
    public void DisplayAssignedResourcesReport()
    {
        Console.WriteLine("\n=== Assigned Resources Report ===");
        var assignedResources = _resources.Where(r => r.IsAssigned).ToList();

        if (assignedResources.Count == 0)
        {
            Console.WriteLine("No assigned resources found.");
            return;
        }

        foreach (var resource in assignedResources)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == resource.AssignedEmployeeId);
            string employeeName = employee?.Name ?? "Unknown";
            Console.WriteLine($"{resource.Name} ({resource.Type}) -> {employeeName}");
        }
    }

    /// <summary>
    /// Displays a summary report for all departments.
    /// </summary>
    public void DisplayDepartmentSummaryReport()
    {
        Console.WriteLine("\n=== Department Summary Report ===");
        if (_departments.Count == 0)
        {
            Console.WriteLine("No departments found.");
            return;
        }

        foreach (var department in _departments)
        {
            var members = _employees.Where(e => e.DepartmentId == department.Id).ToList();
            Console.WriteLine($"\n{department.Name}: {members.Count} employee(s)");
            foreach (var member in members)
            {
                Console.WriteLine($"  - {member.Name} ({member.Position})");
            }
        }
    }

    private string GetDepartmentName(int? departmentId)
    {
        if (departmentId is null)
        {
            return "Unassigned";
        }

        var department = _departments.FirstOrDefault(d => d.Id == departmentId);
        return department?.Name ?? "Unknown";
    }
}
