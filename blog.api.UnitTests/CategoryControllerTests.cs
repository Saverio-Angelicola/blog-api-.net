using blog_api.Controllers;
using blog_api.Models;
using blog_api.Services.Interfaces.Categories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace blog.api.UnitTests
{
    public class CategoryControllerTests
    {
        private Mock<ICategoryService> categoryServiceStub;

        public CategoryControllerTests()
        {
            categoryServiceStub = new Mock<ICategoryService>();
        }

        [Fact]
        public void GetAllCategories_WhithCategoryList_ReturnsOk()
        {
            //Arrange
            List<Category> expected = new List<Category>() {createdRandomCategory(),createdRandomCategory() };
            categoryServiceStub.Setup(service => service.GetAllCategories()).Returns(expected);
            CategoryController controller = new (categoryServiceStub.Object);
            //Act
            var result = controller.GetAllCategories();
            //Assert
            result.Result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void GetAllCategories_WhithCategoryList_ReturnsAllCategory()
        {
            //Arrange
            List<Category> expected = new List<Category>() { createdRandomCategory(), createdRandomCategory() };
            categoryServiceStub.Setup(service => service.GetAllCategories()).Returns(expected);
            CategoryController controller = new(categoryServiceStub.Object);
            //Act
            var result = controller.GetAllCategories().Result as OkObjectResult;
            //Assert
            result.Value.Should().BeEquivalentTo(expected,options=>options.ComparingByMembers<Category>());
        }

        [Fact]
        public void GetAllCategories_WhithException_ReturnsBadRequest()
        {
            //Arrange
            categoryServiceStub.Setup(service => service.GetAllCategories()).Throws(new Exception());
            CategoryController controller = new(categoryServiceStub.Object);
            //Act
            var result = controller.GetAllCategories();
            //Assert
            result.Result.Should().BeOfType<BadRequestResult>();
        }

        private Category createdRandomCategory()
        {
            Category category = new Category(Guid.NewGuid().ToString());
            return category;
        }
    }
}
