using TaskManager.Domain.Contracts;

namespace TaskManager.Application.UseCases.Task.GetById;

public class GetByIdTaskUseCase(ITaskRepository taskRepository)
{
    public ITaskEntity? Execute(Guid id)
    {
        return taskRepository.GetById(id);
    }
}