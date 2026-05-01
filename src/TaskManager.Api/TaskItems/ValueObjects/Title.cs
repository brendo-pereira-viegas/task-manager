namespace TaskManager.Api.TaskItems.ValueObjects;

public readonly record struct Title
{
    public string Value { get; }

    public Title(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        Value = value;
    }

    public static implicit operator string(Title title) => title.Value;
}