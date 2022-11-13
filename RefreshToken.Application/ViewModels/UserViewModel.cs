using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RefreshToken;

public class UserLoginResponse
{
    public UserLoginResponse(string at, string rf)
    {
        AccessToken = at;
        RefreshToken = rf;
        ExpiresIn = 3600;
    }

    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public int ExpiresIn { get; set; }
}

public class UserRegister
{
    public UserRegister(string firstName, string lastName, string email, string password, string confirmPassword)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        ConfirmPassword = confirmPassword;
    }
    [Required(ErrorMessage = "The {0} is required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "The {0} is required")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "The {0} is required")]
    [EmailAddress(ErrorMessage = "The {0} is in a incorrect format")]
    public string Email { get; set; }

    [Required(ErrorMessage = "The {0} is required")]
    [StringLength(100, ErrorMessage = "The {0} must have between {2} and {1} characters", MinimumLength = 6)]
    public string Password { get; set; }

    [DisplayName("Confirm Password")]
    [Compare("Password", ErrorMessage = "The passwords doesn't match.")]
    public string ConfirmPassword { get; set; }
}

public class UserLogin
{
    public UserLogin(string email, string password)
    {
        Email = email;
        Password = password;
    }

    [Required(ErrorMessage = "The {0} is required")]
    [EmailAddress(ErrorMessage = "The {0} is in a incorrect format")]
    public string Email { get; set; }

    [Required(ErrorMessage = "The {0} is required")]
    [StringLength(100, ErrorMessage = "The {0} must have between {2} and {1} characters", MinimumLength = 6)]
    public string Password { get; set; }
}

public class Token
{
    public Token(string refreshToken)
    {
        RefreshToken = refreshToken;
    }

    [Required]
    [JsonPropertyName("refresh-token")]
    public string RefreshToken { get; set; }
}

