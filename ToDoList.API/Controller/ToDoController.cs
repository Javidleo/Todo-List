using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using ToDoList.API.Domain;
using ToDoList.API.Dtos;
using ToDoList.API.Infrastructure;
using ToDoList.API.ViewModels;

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

    [HttpGet]
    public IActionResult GetAll()
    {
        List<GetAllTask> tasks = _context.Tasks
            .Select(i => new GetAllTask
            {
                Title = i.Title,
                Description = i.Description,
                IsCompleted = i.IsCompleted,
                CreationTime = i.CreationTime,
            }).ToList();

        return Ok(tasks);
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
            IsCompleted = dto.IsCompleted,
            CreationTime = DateTime.Now
        };

        _context.Tasks.Add(task);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("mark/{id}")]
    public IActionResult CheckStatus(int id)
    {
        var task = _context.Tasks.Where(i => i.Id == id).FirstOrDefault();

        if (task == null)
        {
            return NotFound("didn't found");
        }

        if (task.IsCompleted == true)
        {
            return BadRequest("already checked");
        }

        _context.Tasks.Update(task);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("unmark/{id}")]
    public IActionResult UncheckStatus(int id)
    {
        var task = _context.Tasks.Where(i => i.Id == id).FirstOrDefault();

        if(task == null)
        {
            return NotFound("didn't found");
        }

        if(task.IsCompleted == false)
        {
            return BadRequest("already unmarked");
        }
      
        task.IsCompleted = false;

        _context.Tasks.Update(task);
        _context.SaveChanges();

        return NoContent();
    }
}
