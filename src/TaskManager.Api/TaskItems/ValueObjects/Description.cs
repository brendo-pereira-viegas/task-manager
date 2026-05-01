namespace TaskManager.Api.TaskItems.ValueObjects;

public readonly record struct Description
{
    public string Value { get; }

    private Description(string value) => Value = value;

    public static Description Create(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        return new(value);
    }

    public static implicit operator string(Description description) => description.Value;
}