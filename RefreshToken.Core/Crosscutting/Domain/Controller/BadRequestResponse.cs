namespace RefreshToken.Core.Crosscutting.Domain.Controller;

public class BadRequestResponse
{
    public bool Success => false;

    public IEnumerable<string> Errors { get; }

    public BadRequestResponse(IEnumerable<string> errors)
    {
        Errors = errors;
    }
}
