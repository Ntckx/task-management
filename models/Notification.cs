namespace TaskManagement.Models;

public class Notification
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid TaskId { get; set; }
    public string Message { get; set; } = string.Empty;
    public string RecepientEmail { get; set; } = string.Empty;
    public DateTime SentAt { get; set; } = DateTime.UtcNow;

    // NoArgConstructor
    public Notification()
    {

    }

    //AllArgConstructor
    public Notification(
        string message, string recepientEmail
    )
    {
        Message = message;
        RecepientEmail = recepientEmail;
    }

}