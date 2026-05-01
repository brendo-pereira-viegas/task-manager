namespace TaskManager.Api.TaskItems.ValueObjects;

public readonly record struct Title
{
    public string Value { get; }

    private Title(string value) => Value = value;

    public static Title Create(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        return new(value);
    }

    public static implicit operator string(Title title) => title.Value;
}