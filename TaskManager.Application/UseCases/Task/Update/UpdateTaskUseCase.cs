using TaskManager.Communication.Requests;
using TaskManager.Domain.Contracts;

namespace TaskManager.Application.UseCases.Task.Update;

public class UpdateTaskUseCase(ITaskRepository taskRepository)
{
    public ITaskEntity Execute(Guid id, RequestUpdateTaskJson requestTask)
      
    {
        var hasTask = taskRepository.GetById(id);
        
        if (hasTask == null)
        {
            throw new Exception("Task not found");
        }
        
        hasTask.Name = requestTask.Name ?? hasTask.Name;
        hasTask.Description = requestTask.Description ?? hasTask.Description;
        hasTask.Priority = requestTask.Priority ?? hasTask.Priority;
        hasTask.Status = requestTask.Status ?? hasTask.Status;
        hasTask.EndDate = requestTask.EndDate ?? hasTask.EndDate;

        taskRepository.Update(hasTask, id);
        
        return hasTask;
    }
}