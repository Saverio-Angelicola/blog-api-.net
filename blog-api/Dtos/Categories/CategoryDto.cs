namespace blog_api.Dtos.Categories
{
    public class CategoryDto
    {
        public string Name { get; set; }
        public CategoryDto(string name)
        {
            Name = name;
        }
    }
}
