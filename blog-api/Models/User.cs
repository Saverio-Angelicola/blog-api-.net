using blog_api.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace blog_api.Models
{
    [Table(name: "Users")]
    public class User : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100, MinimumLength = 5)]
        public string Email { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 8)]
        [JsonIgnore]
        public string Password { get; set; }

        [Required]
        public bool Admin { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }

        public User(string firstName, string lastName, string email, string password, bool admin)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Admin = admin;
            RegisterDate = DateTime.UtcNow;
        }

        public User()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            Admin = false;
            RegisterDate = DateTime.UtcNow;
        }
    }
}
