namespace ResourceManagementSystem;

/// <summary>
/// Entry point for the Resource Management System console application.
/// </summary>
internal class Program
{
    private static readonly ResourceManager Manager = new();

    /// <summary>
    /// Application entry point.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    static void Main(string[] args)
    {
        Console.WriteLine("============================================");
        Console.WriteLine("   Company Resource Management System");
        Console.WriteLine("============================================");

        RunMenu();
    }

    /// <summary>
    /// Displays the main menu and processes user input.
    /// </summary>
    private static void RunMenu()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Main Menu ---");
            Console.WriteLine("1. View Employees");
            Console.WriteLine("2. View Resources");
            Console.WriteLine("3. View Departments");
            Console.WriteLine("4. View Reports");
            Console.WriteLine("0. Exit");
            Console.Write("Select an option: ");

            string? input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    DisplayEmployees();
                    break;
                case "2":
                    DisplayResources();
                    break;
                case "3":
                    DisplayDepartments();
                    break;
                case "4":
                    DisplayReportsMenu();
                    break;
                case "0":
                    running = false;
                    Console.WriteLine("Thank you for using Resource Management System. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    /// <summary>
    /// Displays all employees in the system.
    /// </summary>
    private static void DisplayEmployees()
    {
        Console.WriteLine("--- Employees ---");
        var employees = Manager.ListEmployees();

        if (employees.Count == 0)
        {
            Console.WriteLine("No employees found.");
            return;
        }

        foreach (var employee in employees)
        {
            Console.WriteLine(employee);
        }
    }

    /// <summary>
    /// Displays all resources in the system.
    /// </summary>
    private static void DisplayResources()
    {
        Console.WriteLine("--- Resources ---");
        var resources = Manager.ListResources();

        if (resources.Count == 0)
        {
            Console.WriteLine("No resources found.");
            return;
        }

        foreach (var resource in resources)
        {
            Console.WriteLine(resource);
        }
    }

    /// <summary>
    /// Displays all departments in the system.
    /// </summary>
    private static void DisplayDepartments()
    {
        Console.WriteLine("--- Departments ---");
        var departments = Manager.ListDepartments();

        if (departments.Count == 0)
        {
            Console.WriteLine("No departments found.");
            return;
        }

        foreach (var department in departments)
        {
            Console.WriteLine(department);
        }
    }

    /// <summary>
    /// Displays the reports sub-menu and processes user input.
    /// </summary>
    private static void DisplayReportsMenu()
    {
        Console.WriteLine("--- Reports ---");
        Console.WriteLine("1. Employee Report");
        Console.WriteLine("2. Resource Report");
        Console.WriteLine("3. Assigned Resources Report");
        Console.WriteLine("4. Department Summary Report");
        Console.WriteLine("0. Back to Main Menu");
        Console.Write("Select a report: ");

        string? input = Console.ReadLine();

        switch (input)
        {
            case "1":
                Manager.DisplayEmployeeReport();
                break;
            case "2":
                Manager.DisplayResourceReport();
                break;
            case "3":
                Manager.DisplayAssignedResourcesReport();
                break;
            case "4":
                Manager.DisplayDepartmentSummaryReport();
                break;
            case "0":
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
}
