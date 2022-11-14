using FluentValidation.Results;
using RefreshToken.Core.Crosscutting.Domain.Events;

namespace RefreshToken.Core.Crosscutting.Domain.Queries;

public abstract class Query<TResponse> : QueryMessage<TResponse>
{
    public DateTime Timestamp { get; private set; }

    public ValidationResult ValidationResult { get; set; } = new ValidationResult();


    protected Query()
    {
        Timestamp = DateTime.UtcNow;
    }

    public abstract bool IsValid();
}
