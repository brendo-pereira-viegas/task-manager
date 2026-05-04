namespace TaskManager.Api.TaskItems;

public sealed class TaskItem
{
    public Guid Id { get; }
    public Title Title { get; private set; }
    public Description Description { get; private set; }
    public TaskItemStatus Status { get; private set; }

    public TaskItem(Title title, Description description)
    {
        ArgumentNullException.ThrowIfNull(title);
        ArgumentNullException.ThrowIfNull(description);

        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Status = TaskItemStatus.Pending;
    }

    public void ChangeTitle(Title title)
    {
        ArgumentNullException.ThrowIfNull(title);
        Title = title;
    }

    public void ChangeDescription(Description description)
    {
        ArgumentNullException.ThrowIfNull(description);
        Description = description;
    }

    public void InProgress()
    {
        ThrowIfInvalidTransition(
            TaskItemStatus.InProgress,
            Status is TaskItemStatus.Pending);

        Status = TaskItemStatus.InProgress;
    }

    public void Complete()
    {
        ThrowIfInvalidTransition(
            TaskItemStatus.Completed,
            Status is TaskItemStatus.InProgress);

        Status = TaskItemStatus.Completed;
    }

    public void Cancel()
    {
        ThrowIfInvalidTransition(
            TaskItemStatus.Cancelled,
            Status is TaskItemStatus.Pending or TaskItemStatus.InProgress);

        Status = TaskItemStatus.Cancelled;
    }

    private void ThrowIfInvalidTransition(TaskItemStatus targetStatus, bool canTransition)
    {
        if (Status == targetStatus) return;

        if (!canTransition)
            throw new InvalidOperationException($"Cannot transition from {Status} to {targetStatus}.");
    }
}