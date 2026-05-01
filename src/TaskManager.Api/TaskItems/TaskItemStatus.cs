namespace TaskManager.Api.TaskItems;

public enum TaskItemStatus : byte
{
    Pending = 1,
    InProgress = 2,
    Completed = 3,
    Cancelled = 4
}