using TaskManager.Domain.Contracts;

namespace TaskManager.Domain.Repositories.Tasks;

public class TasksMockRepository : ITaskRepository
{
    private readonly List<ITaskEntity> _tasks = [];


    public void Save(ITaskEntity task)
    {
        _tasks.Add(task);
    }

    public ITaskEntity? GetById(Guid id)
    {
        var getTask = _tasks.Find(e => e.Id == id);
        return getTask;
    }

    public List<ITaskEntity> GetAll()
    {
        return _tasks;
    }

    public void Update(ITaskEntity task, Guid id)
    {
        var getTask = _tasks.Find(e => e.Id == id);
        
        if(getTask != null)
        {
            getTask.Description = task.Description;
            getTask.Name = task.Name;
            getTask.EndDate = task.EndDate;
            getTask.Priority = task.Priority;
            getTask.Status = task.Status;
            return;
        }
        
        throw new Exception("Task not found");
    }

    public void Delete(Guid id)
    {
        var getTask = _tasks.Find(e => e.Id == id);
        
        if(getTask != null)
        {
            _tasks.Remove(getTask);
            return;
        }
        
        throw new Exception("Task not found");
    }
}