namespace ResourceManagementSystem;

/// <summary>
/// Represents an employee within the organization.
/// </summary>
public class Employee
{
    /// <summary>
    /// Gets or sets the unique identifier for the employee.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the full name of the employee.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the job position of the employee.
    /// </summary>
    public string Position { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address of the employee.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the department identifier the employee belongs to.
    /// </summary>
    public int? DepartmentId { get; set; }

    /// <summary>
    /// Returns a string representation of the employee.
    /// </summary>
    /// <returns>A formatted string describing the employee.</returns>
    public override string ToString()
    {
        return $"[{Id}] {Name} - {Position} ({Email})";
    }
}
