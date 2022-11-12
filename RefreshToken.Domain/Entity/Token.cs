using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RefreshToken.Domain.Entity;

public class Token
{
    [Required]
    [JsonPropertyName("refresh-token")]
    public string? RefreshToken { get; set; }
}
