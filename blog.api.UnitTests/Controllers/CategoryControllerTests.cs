using blog_api.Controllers;
using blog_api.Dtos.Categories;
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
        private readonly Mock<ICategoryService> categoryServiceStub;

        public CategoryControllerTests()
        {
            categoryServiceStub = new Mock<ICategoryService>();
        }

        [Fact]
        public void GetAllCategories_WhithCategoryList_ReturnsOk()
        {
            //Arrange
            List<Category> expected = new() {CreatedRandomCategory(),CreatedRandomCategory() };
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
            List<Category> expected = new () { CreatedRandomCategory(), CreatedRandomCategory() };
            categoryServiceStub.Setup(service => service.GetAllCategories()).Returns(expected);
            CategoryController controller = new(categoryServiceStub.Object);
            //Act
            var result = controller.GetAllCategories().Result as OkObjectResult;
            //Assert
            result?.Value.Should().BeEquivalentTo(expected,options=>options.ComparingByMembers<Category>());
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

        [Fact]
        public async Task AddCategory_WithCategory_ReturnOk()
        {
            //Arrange
            Category expected = CreatedRandomCategory();
            categoryServiceStub.Setup(service=>service.Add(It.IsAny<CategoryDto>())).ReturnsAsync(expected);
            CategoryController controller = new(categoryServiceStub.Object);
            //Act
            var result = await controller.AddCategory(It.IsAny<CategoryDto>());
            //Assert
            result.Result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task AddCategory_WithCategory_ReturnCategory()
        {
            //Arrange
            Category expected = CreatedRandomCategory();
            categoryServiceStub.Setup(service => service.Add(It.IsAny<CategoryDto>())).ReturnsAsync(expected);
            CategoryController controller = new(categoryServiceStub.Object);
            //Act
            var result = (await controller.AddCategory(It.IsAny<CategoryDto>())).Result as OkObjectResult;
            //Assert
            result?.Value.Should().BeEquivalentTo(expected,options=>options.ComparingByMembers<Category>());
        }

        [Fact]
        public async Task AddCategory_WithException_ReturnBadRequest()
        {
            //Arrange
            categoryServiceStub.Setup(service => service.Add(It.IsAny<CategoryDto>())).Throws(new Exception());
            CategoryController controller = new(categoryServiceStub.Object);
            //Act
            var result = await controller.AddCategory(It.IsAny<CategoryDto>());
            //Assert
            result.Result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public async Task UpdateCategory_WithArticle_ReturnOk()
        {
            //Arrange
            Category expected = CreatedRandomCategory();
            categoryServiceStub.Setup(service => service.Update(It.IsAny<int>(),It.IsAny<CategoryDto>())).ReturnsAsync(expected);
            CategoryController controller = new(categoryServiceStub.Object);
            //Act
            var result = await controller.UpdateCategory(It.IsAny<int>(), It.IsAny<CategoryDto>());
            //Assert
            result.Result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task UpdateCategory_WithArticle_ReturnArticle()
        {
            //Arrange
            Category expected = CreatedRandomCategory();
            categoryServiceStub.Setup(service => service.Update(It.IsAny<int>(), It.IsAny<CategoryDto>())).ReturnsAsync(expected);
            CategoryController controller = new(categoryServiceStub.Object);
            //Act
            var result = (await controller.UpdateCategory(It.IsAny<int>(), It.IsAny<CategoryDto>())).Result as OkObjectResult;
            //Assert
            result?.Value.Should().BeEquivalentTo(expected,options=>options.ComparingByMembers<Category>());
        }

        [Fact]
        public async Task UpdateCategory_WithException_ReturnsNotFound()
        {
            //Arrange
            categoryServiceStub.Setup(service => service.Update(It.IsAny<int>(), It.IsAny<CategoryDto>())).Throws(new Exception());
            CategoryController controller = new(categoryServiceStub.Object);
            //Act
            var result = await controller.UpdateCategory(It.IsAny<int>(), It.IsAny<CategoryDto>());
            //Assert
            result.Result.Should().BeOfType<NotFoundResult>();
        }

        private static Category CreatedRandomCategory()
        {
            Category category = new (Guid.NewGuid().ToString());
            return category;
        }
    }
}
