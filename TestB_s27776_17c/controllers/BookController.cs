using Microsoft.AspNetCore.Mvc;
using TestB_s27776_17c.services;

namespace TestB_s27776_17c.controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(IBookService service): ControllerBase
{
    [HttpDelete("{id:int}")]
    public IActionResult DeleteStudent(int id)
    {
        var affectedCount = service.DeleteGener(id);
        return NoContent();
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetStudent(int id)
    {
        var student = service.GetBook(id);

        if (student==null)
        {
            return NotFound("Book not found");
        }
        return Ok(student);
    }
}