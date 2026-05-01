namespace TaskManager.Api.TaskItems;

public sealed class TaskItem(Title title, Description description)
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Title Title { get; private set; } = title;
    public Description Description { get; private set; } = description;
    public TaskItemStatus Status { get; private set; } = TaskItemStatus.Pending;

    public void ChangeTitle(Title title) => Title = Title = title;

    public void ChangeDescription(Description description) => Description = description;

    public void ChangeStatus(TaskItemStatus next)
    {
        TransitionTo(Status, next);
        Status = next;
    }

    private static void TransitionTo(TaskItemStatus current, TaskItemStatus next)
    {
        if (current == next) return;

        bool isValidTrnsition = (current, next) switch
        {
            (TaskItemStatus.Pending, TaskItemStatus.InProgress) => true,
            (TaskItemStatus.InProgress, TaskItemStatus.Completed) => true,
            (TaskItemStatus.Pending, TaskItemStatus.Cancelled) => true,
            (TaskItemStatus.InProgress, TaskItemStatus.Cancelled) => true,
            (_, TaskItemStatus.Pending) => true,
            _ => false
        };

        if (!isValidTrnsition)
            throw new InvalidOperationException($"Invalid state transition from: {current} to {next}.");
    }
}