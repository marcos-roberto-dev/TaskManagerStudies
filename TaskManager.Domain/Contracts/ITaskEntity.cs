using TaskManager.Communication.Enums;

namespace TaskManager.Domain.Contracts;

public interface ITaskEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } 
    public PriorityType Priority { get; set; }
    public StatusType Status { get; set; }
    public DateTime EndDate { get; set; }
}