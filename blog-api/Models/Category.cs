using blog_api.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace blog_api.Models
{
    public class Category : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [JsonIgnore]
        public List<Article> Articles { get; set; }

        public Category(string name)
        {
            Name = name;
            Articles = new List<Article>();
        }

        public Category()
        {
            Name = string.Empty;
            Articles = new List<Article>();
        }
    }
}
