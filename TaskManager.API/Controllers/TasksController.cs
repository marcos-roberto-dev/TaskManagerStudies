using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.UseCases.Task.Create;
using TaskManager.Application.UseCases.Task.GetAll;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;

namespace TaskManager.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TasksController : ControllerBase
  {
    [HttpPost]
    [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] RequestCreateTaskJson request)
    {
      var response = new CreateTaskUseCase().Execute(request);
      return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ResponseTaskJson>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
      var response = new GetAllTasksUseCase().Execute();
      return Ok(response);
    }
  }
}