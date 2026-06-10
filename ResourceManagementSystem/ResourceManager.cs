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
}
