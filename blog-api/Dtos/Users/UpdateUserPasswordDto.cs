namespace blog_api.Dtos.Users
{
    public class UpdateUserPasswordDto
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }

        public UpdateUserPasswordDto(string currentPassword, string newPassword)
        {
            CurrentPassword = currentPassword;
            NewPassword = newPassword;
        }

        public UpdateUserPasswordDto()
        {
            CurrentPassword = string.Empty;
            NewPassword = string.Empty;
        }
    }
}
