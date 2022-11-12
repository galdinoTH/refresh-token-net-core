using System.Text.RegularExpressions;

namespace RefreshToken.Domain.Entity
{
    public class User : BaseEntity
    {
        private User() { }

        public User(string firstName, string lastName, string email, string password)
        {
            this.SetName(firstName, lastName);
            this.SetEmail(email);
            this.SetPassword(password);
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public void SetName(string firstName, string lastName)
        {
            var cleanEmptyFirstName = Regex.Replace(firstName, @"\s", "");
            var cleanEmptyLastName = Regex.Replace(lastName, @"\s", "");
            this.Name = cleanEmptyFirstName + " " + cleanEmptyLastName;
        }

        public void SetEmail(string email)
        {
            this.Email = email;
        }

        public void SetPassword(string password)
        {
            this.Password = password;
        }
    }
}
