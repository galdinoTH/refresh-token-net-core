using RefreshToken.Core.Crosscutting.Domain.Events;
using Newtonsoft.Json;
using FluentValidation.Results;

namespace RefreshToken.Core.Crosscutting.Domain.Commands;

public abstract class Command : CommandMessage
{
    [JsonIgnore]
    public DateTime Timestamp { get; private set; }

    [JsonIgnore]
    public ValidationResult ValidationResult { get; set; } = new ValidationResult();


    protected Command()
    {
        Timestamp = DateTime.UtcNow;
    }

    public abstract bool IsValid();
}
