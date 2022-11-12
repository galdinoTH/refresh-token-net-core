using RefreshToken.Domain.Exceptions.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RefreshToken.Domain.Entity;

public class Token : BaseEntity
{
    private Token() { }

    public Token(string token)
    {
        this.SetToken(token);
    }

    [JsonPropertyName("refresh-token")]
    public string? RefreshToken { get; private set; }

    public void SetToken(string token)
    {
        if (!string.IsNullOrEmpty(token))
        {
            this.RefreshToken = token;
        }
        else
        {
            throw new TokenCannotBeNullException();
        }
    }
}
