namespace TaskManager.Api.TaskItems.ValueObjects;

public sealed record Title
{
    public const int MaxLength = 100;

    public string Value { get; }

    public Title(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value.Length, MaxLength);
        Value = value.Trim();
    }

    public override string ToString() => Value;

    public static explicit operator string(Title title) => title.Value;
}