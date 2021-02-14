using CreatedWithVs.Lib;
using CreatedWithVs.WebApp.Controllers;
using CreatedWithVs.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace CreatedWithVs.WebAppTest
{
    public class HomeControllerTest
    {
        private readonly Mock<IHelloService> _helloServiceMock;
        private readonly HomeController _homeController;

        public HomeControllerTest()
        {
            _helloServiceMock = new Mock<IHelloService>();
            _helloServiceMock
                .Setup(h => h.GetHelloMessage("test user"))
                .Returns("test hello message");
            _homeController = new HomeController(_helloServiceMock.Object);
        }

        [Fact]
        public void CanIndexMethodReturnProperView()
        {
            ViewResult? viewResult = _homeController.Index("test user") as ViewResult;

            Assert.NotNull(viewResult);
            Assert.Equal("Index", viewResult!.ViewName);
        }

        [Fact]
        public void CanIndexMethodReturnProperModelType()
        {
            ViewResult? viewResult = _homeController.Index("test user") as ViewResult;

            Assert.NotNull(viewResult);
            Assert.IsType<HelloViewModel>(viewResult!.Model);
        }

        [Fact]
        public void CanIndexMethodReturnProperModelData()
        {
            ViewResult? viewResult = _homeController.Index("test user") as ViewResult;

            Assert.NotNull(viewResult);
            Assert.IsType<HelloViewModel>(viewResult!.Model);

            HelloViewModel? helloViewModel = viewResult.Model as HelloViewModel;
            Assert.NotNull(helloViewModel);
            Assert.Equal("test hello message", helloViewModel!.HelloMessage);
        }

        [Fact]
        public void CanIndexMethodThrowProperExceptionForEmptyString()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _homeController.Index(string.Empty);
            });
        }

        [Fact]
        public void CanIndexMethodThrowProperExceptionForBlankString()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _homeController.Index("");
            });
        }

        [Fact]
        public void CanIndexMethodThrowProperExceptionForNullString()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _homeController.Index(null);
            });
        }
    }
}
