namespace blog_api.Dtos.Users
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public CreateUserDto(string firstName, string lastName, string email, string password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
        }

        public CreateUserDto()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
        }
    }
}
