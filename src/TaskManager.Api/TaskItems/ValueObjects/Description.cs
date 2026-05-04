namespace TaskManager.Api.TaskItems.ValueObjects;

public sealed record Description
{
    public const int MaxLength = 500;

    public string Value { get; }

    public Description(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Description is required.", nameof(value));

        if (value.Length > MaxLength)
            throw new ArgumentException($"Description length cannot exceed {MaxLength} characters.", nameof(value));

        Value = value.Trim();
    }

    public static explicit operator string(Description description) => description.Value;
}