using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.UseCases.Task.Create;
using TaskManager.Application.UseCases.Task.Delete;
using TaskManager.Application.UseCases.Task.GetAll;
using TaskManager.Application.UseCases.Task.GetById;
using TaskManager.Application.UseCases.Task.Update;
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
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {

      try
      {
        var response = new GetByIdTaskUseCase(taskRepository).Execute(id);

        return Ok(response);

      }
      catch (Exception ex)
      {
        var errorResponse = new ResponseErrorsJson
        {
          Errors = new List<string> { ex.Message }
        };
        return NotFound(errorResponse);
      }
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id)
    
    {
      try
      {
        new DeleteTaskUseCase(taskRepository).Execute(id);
        return NoContent();
        
      }
      catch(Exception ex)
      {
        var errorResponse = new ResponseErrorsJson
        {
          Errors = new List<string> { ex.Message }
        };
        return NotFound(errorResponse);
      }
    }
    
    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult Update(Guid id, RequestUpdateTaskJson requestTask)
    {
      try
      {
        var taskEdit = new UpdateTaskUseCase(taskRepository).Execute(id, requestTask);
        return Ok(taskEdit);
      }
      catch (Exception ex)
      {
        var errorResponse = new ResponseErrorsJson
        {
          Errors = new List<string> { ex.Message }
        };
        return NotFound(errorResponse);
      }
    }
  }
}