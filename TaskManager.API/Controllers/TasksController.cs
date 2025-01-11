using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.UseCases.Task.Create;
using TaskManager.Application.UseCases.Task.GetAll;
using TaskManager.Application.UseCases.Task.GetById;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;
using TaskManager.Domain.Contracts;
using TaskManager.Domain.Repositories.Tasks;

namespace TaskManager.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TasksController(ITaskRepository taskRepository) : ControllerBase
  {
    [HttpPost]
    [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] RequestCreateTaskJson request)
    {
      var response = new CreateTaskUseCase(taskRepository).Execute(request);
      return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ResponseTaskJson>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
      var response = new GetAllTasksUseCase(taskRepository).Execute();
      return Ok(response);
    }
    
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
      var response = new GetByIdTaskUseCase(taskRepository).Execute(id);
      if (response is null)
      {
        return NotFound();
      }
      return Ok(response);
    }
  }
}