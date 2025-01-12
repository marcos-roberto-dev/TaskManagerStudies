using TaskManager.Communication.Enums;

namespace TaskManager.Communication.Responses
{
  public class ResponseTaskJson
  {
    public Guid  Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public PriorityType Priority { get; init; }
    public StatusType Status { get; init; }
    public DateTime EndDate { get; init; }
  }
}
