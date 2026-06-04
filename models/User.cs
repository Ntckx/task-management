namespace TaskManagement.Models;

public class User
{

    //Fields
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // One User can have many tasks
    public ICollection<TaskItem> taskItems { get; set; } = new List<TaskItem>();

    // No Arg Constructor
    public User()
    {

    }

    // Constructor for how object is created
    public User(string name, string email)
    {
        Name = name;
        Email = email;
    }
}
