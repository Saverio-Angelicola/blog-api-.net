namespace blog_api.Dtos.Tokens
{
    public class TokenDto
    {
        public string Token_jwt { get; set; }

        public DateTime ExpirationDate { get; set; }

        public TokenDto(string token)
        {
            Token_jwt = token;
            ExpirationDate = DateTime.Now.AddDays(1);
        }

        public TokenDto()
        {
            Token_jwt = string.Empty;
            ExpirationDate = DateTime.Now.AddDays(1);
        }
    }
}
