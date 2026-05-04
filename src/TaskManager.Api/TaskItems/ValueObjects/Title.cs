namespace TaskManager.Api.TaskItems.ValueObjects;

public sealed record Title
{
    public const int MaxLength = 100;

    public string Value { get; }

    public Title(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Title is required.", nameof(value));

        if (value.Length > MaxLength)
            throw new ArgumentException($"Title length cannot exceed {MaxLength} characters.", nameof(value));

        Value = value.Trim();
    }

    public static explicit operator string(Title title) => title.Value;
}