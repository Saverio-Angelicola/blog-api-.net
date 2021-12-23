﻿namespace blog_api.Dtos.Articles
{
    public class UpdateArticleDto
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int? CategoryId { get; set; }
        public UpdateArticleDto(string? title, string? content, int? categoryId)
        {
            Title = title;
            Content = content;
            CategoryId = categoryId;
        }
    }
}
