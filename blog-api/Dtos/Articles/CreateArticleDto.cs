namespace blog_api.Dtos.Articles
{
    public class CreateArticleDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public int CategoryId { get; set; }
        public CreateArticleDto(string title, string content, string author, int categoryId)
        {
            Title = title;
            Content = content;
            Author = author;
            CategoryId = categoryId;
        }
    }
}
