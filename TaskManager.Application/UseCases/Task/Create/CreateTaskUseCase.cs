using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;
using TaskManager.Domain.Contracts;
using TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.UseCases.Task.Create
{
  public class CreateTaskUseCase(ITaskRepository taskRepository)
  {
    

    public ResponseTaskJson Execute(RequestCreateTaskJson request)
    {
      var task = new TaskEntity
      {
        Name = request.Name,
        Description = request.Description,
        Priority = request.Priority,
        Status = request.Status,
        EndDate = request.EndDate
      };
      
      taskRepository.Save(task);

      return new ResponseTaskJson
      {
        Id = task.Id,
        Name = task.Name,
        Description = task.Description,
        Priority = task.Priority,
        Status = task.Status,
        EndDate = task.EndDate
      };
    }
  }
}
