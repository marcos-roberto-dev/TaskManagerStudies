using TaskManager.Communication.Enums;

namespace TaskManager.Communication.Requests;

public class RequestUpdateTaskJson
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public PriorityType? Priority { get; set; }
    public StatusType? Status { get; set; }
    public DateTime? EndDate { get; set; }
}