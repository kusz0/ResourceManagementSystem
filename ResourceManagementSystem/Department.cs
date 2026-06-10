namespace ResourceManagementSystem;

/// <summary>
/// Represents an organizational department.
/// </summary>
public class Department
{
    /// <summary>
    /// Gets or sets the unique identifier for the department.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the department.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a description of the department's responsibilities.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Returns a string representation of the department.
    /// </summary>
    /// <returns>A formatted string describing the department.</returns>
    public override string ToString()
    {
        return $"[{Id}] {Name} - {Description}";
    }
}
