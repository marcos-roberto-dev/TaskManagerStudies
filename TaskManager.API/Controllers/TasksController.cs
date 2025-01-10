using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.UseCases.Task.Create;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;

namespace TaskManager.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TasksController : ControllerBase
  {
    private static List<ResponseCreateTaskJson> _tasks = new List<ResponseCreateTaskJson>();

    [HttpPost]
    [ProducesResponseType(typeof(ResponseCreateTaskJson), StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] RequestCreateTaskJson request)
    {
      var response = new CreateTaskUseCase().Execute(request);

      _tasks.Add(response);
      return Created(string.Empty, response);
    }
  }
}