namespace blog_api.Dtos.Users
{
    public class UpdateUserInfosDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public UpdateUserInfosDto(string fistname, string lastname)
        {
            this.Firstname = fistname;
            this.Lastname = lastname;
        }

        public UpdateUserInfosDto()
        {
            Firstname = string.Empty;
            Lastname = string.Empty;
        }
    }
}
