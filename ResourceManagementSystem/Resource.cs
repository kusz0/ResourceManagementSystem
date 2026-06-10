namespace ResourceManagementSystem;

/// <summary>
/// Represents a company resource such as equipment or assets.
/// </summary>
public class Resource
{
    /// <summary>
    /// Gets or sets the unique identifier for the resource.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the resource.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the type of the resource (e.g., Laptop, Vehicle).
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether the resource is currently assigned.
    /// </summary>
    public bool IsAssigned { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the employee to whom the resource is assigned.
    /// </summary>
    public int? AssignedEmployeeId { get; set; }

    /// <summary>
    /// Returns a string representation of the resource.
    /// </summary>
    /// <returns>A formatted string describing the resource.</returns>
    public override string ToString()
    {
        string status = IsAssigned ? $"Assigned to Employee #{AssignedEmployeeId}" : "Available";
        return $"[{Id}] {Name} ({Type}) - {status}";
    }
}
