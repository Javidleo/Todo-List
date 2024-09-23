namespace ToDoList.API.Dtos;

public class CreateTaskDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}
public class CheckMarkDto
{
    public int Id { get; set; }
    public bool ISCompleted { get; set; }
}
