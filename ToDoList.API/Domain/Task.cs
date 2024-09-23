namespace ToDoList.API.Domain;

public class Task
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreationTime { get; set; }
}
