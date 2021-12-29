using blog_api.Controllers;
using blog_api.Models;
using blog_api.Services.Interfaces.Articles;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void GetArticles_WithEmptyList_ReturnsOK()
        {
            //Arrange
            articleServiceStub.Setup(service => service.GetArticles()).Returns(new List<Article>());
            ArticleController controller = new(articleServiceStub.Object,loggerStub.Object);
            //Act
            var result = controller.GetArticles();
            //Assert
            result.Result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void GetArticles_WithException_ReturnsBadRequest()
        {
            //Arrange
            articleServiceStub.Setup(service => service.GetArticles()).Throws(new Exception());
            ArticleController controller = new(articleServiceStub.Object, loggerStub.Object);
            //Act
            var result = controller.GetArticles();
            //Assert
            result.Result.Should().BeOfType<BadRequestResult>();
        }
    }
}