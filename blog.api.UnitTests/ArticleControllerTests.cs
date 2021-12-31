using blog_api.Controllers;
using blog_api.Dtos.Articles;
using blog_api.Models;
using blog_api.Services.Interfaces.Articles;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace blog.api.UnitTests
{
    public class ArticleControllerTests
    {
        private Mock<IArticleService> articleServiceStub;
        private Mock<ILogger<ArticleController>> loggerStub;

        public ArticleControllerTests()
        {
            articleServiceStub = new();
            loggerStub = new();
        }

        [Fact]
        public void GetArticles_WithArticles_ReturnsOk()
        {
            //Arrange
            List<Article> expected = new() { CreateRandomArticle(), CreateRandomArticle(), CreateRandomArticle() };
            articleServiceStub.Setup(service => service.GetArticles()).Returns(expected);
            ArticleController controller = new(articleServiceStub.Object, loggerStub.Object);
            //Act
            var result = controller.GetArticles().Result;
            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void GetArticles_WithArticles_ReturnsAllArticles()
        {
            //Arrange
            List<Article> expected = new() { CreateRandomArticle(), CreateRandomArticle(), CreateRandomArticle() };
            articleServiceStub.Setup(service => service.GetArticles()).Returns(expected);
            ArticleController controller = new(articleServiceStub.Object, loggerStub.Object);
            //Act
            var result = (controller.GetArticles().Result as OkObjectResult);
            //Assert
            result.Value.Should().BeEquivalentTo(expected, options => options.ComparingByMembers<Article>());
        }

        [Fact]
        public void GetArticles_WithExceptions_ReturnsBadRequest()
        {
            //Arrange
            articleServiceStub.Setup(service => service.GetArticles()).Throws(new Exception());
            ArticleController controller = new(articleServiceStub.Object, loggerStub.Object);
            //Act
            var result = controller.GetArticles().Result;
            //Assert
            result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public void GetArticle_WithArticle_ReturnsOk()
        {
            //Arrange
            Article expected = CreateRandomArticle();
            articleServiceStub.Setup(service => service.GetArticle(It.IsAny<int>())).Returns(expected);
            ArticleController controller = new(articleServiceStub.Object, loggerStub.Object);
            //Act
            var result = controller.GetArticle(It.IsAny<int>());
            //Assert
            result.Result.Should().BeOfType<OkObjectResult>();

        }

        [Fact]
        public void GetArticle_WithArticle_ReturnsNotFound()
        {
            //Arrange
            articleServiceStub.Setup(service => service.GetArticle(It.IsAny<int>())).Throws(new Exception());
            ArticleController controller = new(articleServiceStub.Object, loggerStub.Object);
            //Act
            var result = controller.GetArticle(It.IsAny<int>());
            //Assert
            result.Result.Should().BeOfType<NotFoundResult>();

        }

        [Fact]
        public void GetArticle_WithArticle_ReturnsArticle()
        {
            //Arrange
            Article expected = CreateRandomArticle();
            articleServiceStub.Setup(service => service.GetArticle(It.IsAny<int>())).Returns(expected);
            ArticleController controller = new(articleServiceStub.Object, loggerStub.Object);
            //Act
            var result = controller.GetArticle(It.IsAny<int>()).Result as OkObjectResult;
            //Assert
            result.Value.Should().BeEquivalentTo(expected, options => options.ComparingByMembers<Article>());

        }

        [Fact]
        public async Task GetByCategory_withArticles_ReturnsOk()
        {
            //Arrange
            List<Article> expected = new() { CreateRandomArticle(), CreateRandomArticle(), CreateRandomArticle() };
            articleServiceStub.Setup(service => service.GetArticleByCategory(It.IsAny<int>())).ReturnsAsync(expected);
            ArticleController controller = new(articleServiceStub.Object,loggerStub.Object);
            //Act
            var result = await controller.GetByCategory(It.IsAny<int>()) ;
            //Assert
            result.Result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task GetByCategory_withArticles_ReturnsAllArticles()
        {
            //Arrange
            List<Article> expected = new() { CreateRandomArticle(), CreateRandomArticle(), CreateRandomArticle() };
            articleServiceStub.Setup(service => service.GetArticleByCategory(It.IsAny<int>())).ReturnsAsync(expected);
            ArticleController controller = new(articleServiceStub.Object, loggerStub.Object);
            //Act
            var result = (await controller.GetByCategory(It.IsAny<int>())).Result as OkObjectResult;
            //Assert
            result.Value.Should().BeEquivalentTo(expected,options=>options.ComparingByMembers<Article>());
        }

        [Fact]
        public async Task GetByCategory_withException_ReturnsNotFound()
        {
            //Arrange
            articleServiceStub.Setup(service => service.GetArticleByCategory(It.IsAny<int>())).Throws(new Exception());
            ArticleController controller = new(articleServiceStub.Object, loggerStub.Object);
            //Act
            var result = await controller.GetByCategory(It.IsAny<int>());
            //Assert
            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task AddArticle_whitArticle_ReturnsOk()
        {
            //Arrange
            Article exected = CreateRandomArticle();
            articleServiceStub.Setup(service => service.Create(It.IsAny<CreateArticleDto>())).ReturnsAsync(exected);
            ArticleController controller = new(articleServiceStub.Object, loggerStub.Object);
            //Act
            var result = await controller.AddArticle(It.IsAny<CreateArticleDto>());
            //Assert
            result.Result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task AddArticle_whitArticle_ReturnsArticle()
        {
            //Arrange
            Article exected = CreateRandomArticle();
            articleServiceStub.Setup(service => service.Create(It.IsAny<CreateArticleDto>())).ReturnsAsync(exected);
            ArticleController controller = new(articleServiceStub.Object, loggerStub.Object);
            //Act
            var result = (await controller.AddArticle(It.IsAny<CreateArticleDto>())).Result as OkObjectResult;
            //Assert
            result.Value.Should().BeEquivalentTo(exected,options=>options.ComparingByMembers<Article>());
        }

        [Fact]
        public async Task AddArticle_whitArticle_ReturnsBadRequest()
        {
            //Arrange
            articleServiceStub.Setup(service => service.Create(It.IsAny<CreateArticleDto>())).Throws(new Exception());
            ArticleController controller = new(articleServiceStub.Object, loggerStub.Object);
            //Act
            var result = await controller.AddArticle(It.IsAny<CreateArticleDto>());
            //Assert
            result.Result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public async Task UpdateArticle_withArticle_ReturnsOk()
        {
            //Arrange
            Article exected = CreateRandomArticle();
            articleServiceStub.Setup(service => service.Update(It.IsAny<int>(), It.IsAny<UpdateArticleDto>())).ReturnsAsync(exected);
            ArticleController controller = new(articleServiceStub.Object, loggerStub.Object);
            //Act
            var result = await controller.UpdateArticle(It.IsAny<int>(),It.IsAny<UpdateArticleDto>());
            //Assert
            result.Result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task UpdateArticle_withArticle_ReturnsArticle()
        {
            //Arrange
            Article exected = CreateRandomArticle();
            articleServiceStub.Setup(service => service.Update(It.IsAny<int>(), It.IsAny<UpdateArticleDto>())).ReturnsAsync(exected);
            ArticleController controller = new(articleServiceStub.Object, loggerStub.Object);
            //Act
            var result = (await controller.UpdateArticle(It.IsAny<int>(), It.IsAny<UpdateArticleDto>())).Result as OkObjectResult;
            //Assert
            result.Value.Should().BeEquivalentTo(exected,options=>options.ComparingByMembers<Article>());
        }

        [Fact]
        public async Task UpdateArticle_withException_ReturnsNotFound()
        {
            //Arrange
            articleServiceStub.Setup(service => service.Update(It.IsAny<int>(), It.IsAny<UpdateArticleDto>())).Throws(new Exception());
            ArticleController controller = new(articleServiceStub.Object, loggerStub.Object);
            //Act
            var result = await controller.UpdateArticle(It.IsAny<int>(), It.IsAny<UpdateArticleDto>());
            //Assert
            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task DeletedArticle_withArticle_ReturnsOk()
        {
            //Arrange
            Article expected = CreateRandomArticle();
            articleServiceStub.Setup(service => service.Delete(It.IsAny<int>())).ReturnsAsync(expected);
            ArticleController controller = new(articleServiceStub.Object, loggerStub.Object);
            //Act
            var result = await controller.DeleteArticle(It.IsAny<int>());
            //Assert
            result.Result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task DeletedArticle_withArticle_ReturnsArticle()
        {
            //Arrange
            Article expected = CreateRandomArticle();
            articleServiceStub.Setup(service => service.Delete(It.IsAny<int>())).ReturnsAsync(expected);
            ArticleController controller = new(articleServiceStub.Object, loggerStub.Object);
            //Act
            var result = (await controller.DeleteArticle(It.IsAny<int>())).Result as OkObjectResult;
            //Assert
            result.Value.Should().BeEquivalentTo(expected,options=>options.ComparingByMembers<Article>());
        }

        [Fact]
        public async Task DeletedArticle_withException_ReturnsNotFound()
        {
            //Arrange
            Article expected = CreateRandomArticle();
            articleServiceStub.Setup(service => service.Delete(It.IsAny<int>())).Throws(new Exception());
            ArticleController controller = new(articleServiceStub.Object, loggerStub.Object);
            //Act
            var result = await controller.DeleteArticle(It.IsAny<int>());
            //Assert
            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]

        private Article CreateRandomArticle()
        {
            var guid = Guid.NewGuid();
            var article = new Article(guid.ToString(), guid.ToString(), guid.ToString());
            return article;
        }
    }
}