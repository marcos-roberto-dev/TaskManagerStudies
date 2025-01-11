namespace TaskManager.Domain.Contracts;

public interface ITaskRepository
{
    public void Save(ITaskEntity task);
    
    public ITaskEntity? GetById(Guid id);
    
    public List<ITaskEntity> GetAll();
    
    public void Update(ITaskEntity task, Guid id);
    
    public void Delete(Guid id);
}