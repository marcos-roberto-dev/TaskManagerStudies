using TaskManager.Domain.Contracts;

namespace TaskManager.Application.UseCases.Task.Delete;

public class DeleteTaskUseCase(ITaskRepository taskRepository)
{
    public void Execute(Guid id)
    {
        var task = taskRepository.GetById(id);

        if (task == null)
        {
            throw new Exception("Task not found");
        }
        
        taskRepository.Delete(task.Id);
    }
}