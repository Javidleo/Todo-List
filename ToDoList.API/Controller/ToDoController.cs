using Microsoft.AspNetCore.Mvc;
using System;
using ToDoList.API.Domain;
using ToDoList.API.Dtos;
using ToDoList.API.Infrastructure;

namespace ToDoList.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class ToDoController : ControllerBase
{
    private readonly AppDbContext _context;

    public ToDoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AddTask([FromBody] CreateTaskDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title))
        {
            return BadRequest("please provide a good title");
        }
        if (string.IsNullOrEmpty(dto.Description))
        {
            return BadRequest("please provide a good description");
        }

        var task = new Task()
        {
            Title = dto.Title,
            Description = dto.Description,
            CreationTime = DateTime.Now
        };

        _context.Tasks.Add(task);
        _context.SaveChanges();

        return NoContent();
    }
}
