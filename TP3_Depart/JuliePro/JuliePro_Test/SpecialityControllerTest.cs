using JuliePro.Controllers;
using JuliePro_Core;
using JuliePro_Core.Interfaces;
using JuliePro_DataAccess.Data;
using JuliePro_Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JuliePro_Test
{
    public class SpecialityControllerTest
    {
        private Mock<ISpecialitiesService> mock;
        private SpecialitiesController controller;
        public SpecialityControllerTest()
        {
            mock = new Mock<ISpecialitiesService>();
            controller = new SpecialitiesController(mock.Object);
        }
        [Fact]
        public async Task SpecialityServiceDeleteTest()
        {
            // Arrange
            mock.Setup(x => x.DeleteAsync<Speciality>(1)).ReturnsAsync(0);

            // Act

            var action = await controller.DeleteConfirmed(1) as RedirectToActionResult;

            // Assert

            Assert.Equal("Index", action.ActionName);
        }
    }
}