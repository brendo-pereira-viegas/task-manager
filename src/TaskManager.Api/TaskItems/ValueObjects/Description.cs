namespace TaskManager.Api.TaskItems.ValueObjects;

public readonly record struct Description
{
    public string Value { get; }

    public Description(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        Value = value;
    }

    public static implicit operator string(Description description) => description.Value;
}