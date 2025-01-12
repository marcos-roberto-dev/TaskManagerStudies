using TaskManager.Domain.Contracts;

namespace TaskManager.Application.UseCases.Task.GetAll
{
  public class GetAllTasksUseCase(ITaskRepository taskRepository)
  {
    
    public List<ITaskEntity> Execute()
    {
      return taskRepository.GetAll();
    }
  }
}
