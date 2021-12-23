using blog_api.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace blog_api.Models
{
    [Table(name: "Articles")]
    public class Article : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime UpdatedDate { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        public Article()
        {
            Title = string.Empty;
            Content = string.Empty;
            Author = string.Empty;
            CreatedDate = DateTime.UtcNow;
            UpdatedDate = DateTime.UtcNow;
        }
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
            CreatedDate = DateTime.UtcNow;
            UpdatedDate = DateTime.UtcNow;

        }
    }
}
