using TaskManager.Communication.Enums;

namespace TaskManager.Domain.Entities.Task
{
  public class TaskEntity
  {
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public PriorityType Priority { get; set; }
    public StatusType Status { get; set; }
    public DateTime EndDate { get; set; }
  }
}
