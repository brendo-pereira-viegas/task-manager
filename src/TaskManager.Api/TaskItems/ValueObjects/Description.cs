namespace TaskManager.Api.TaskItems.ValueObjects;

public sealed record Description
{
    public const int MaxLength = 500;

    public string Value { get; }

    public Description(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value.Length, MaxLength);
        Value = value.Trim();
    }

    public override string ToString() => Value;

    public static explicit operator string(Description description) => description.Value;
}