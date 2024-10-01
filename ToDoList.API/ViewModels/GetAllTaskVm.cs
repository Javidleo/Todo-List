using Microsoft.Identity.Client;
using System;
using System.Data;

namespace ToDoList.API.ViewModels;

public class GetAllTaskVm
{
    public string Title{ get; set; }
    public string Description{ get; set; }
    public bool IsCompleted{ get; set; }
    public DateTime CreationTime { get; set; }
}
