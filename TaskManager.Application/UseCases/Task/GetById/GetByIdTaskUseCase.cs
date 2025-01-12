using TaskManager.Domain.Contracts;

namespace TaskManager.Application.UseCases.Task.GetById;

public class GetByIdTaskUseCase(ITaskRepository taskRepository)
{
    public ITaskEntity? Execute(Guid id)
    {
        var task = taskRepository.GetById(id);

        if (task == null)
        {
            throw new Exception("Task not found"); 
        }

        return task;
    }
}