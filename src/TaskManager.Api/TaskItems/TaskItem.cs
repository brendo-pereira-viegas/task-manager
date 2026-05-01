namespace TaskManager.Api.TaskItems;

public sealed class TaskItem(Title title, Description description)
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Title Title { get; private set; } = title;
    public Description Description { get; private set; } = description;
    public TaskItemStatus Status { get; private set; } = TaskItemStatus.Pending;

    public void ChangeTitle(Title title) => Title = title;

    public void ChangeDescription(Description description) => Description = description;

    public void SetInProgress() =>
        Status = Status switch
        {
            TaskItemStatus.InProgress => Status,
            TaskItemStatus.Pending => TaskItemStatus.InProgress,
            _ => throw new InvalidOperationException($"Cannot start task from {Status}.")
        };

    public void Complete() =>
        Status = Status switch
        {
            TaskItemStatus.Completed => Status,
            TaskItemStatus.InProgress => TaskItemStatus.Completed,
            _ => throw new InvalidOperationException($"Cannot complete task from {Status}.")
        };

    public void Cancel() =>
        Status = Status switch
        {
            TaskItemStatus.Cancelled => Status,
            TaskItemStatus.Pending or TaskItemStatus.InProgress => TaskItemStatus.Cancelled,
            _ => throw new InvalidOperationException("Cannot cancel a completed task.")
        };
}