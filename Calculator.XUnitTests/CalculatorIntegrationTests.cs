using Calculator.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Calculator.XUnitTests {

    public class CalculatorIntegrationTests : BaseTests {

        public CalculatorIntegrationTests() : base("calculator") { }

        [Fact]
        public async Task Add_WhenCalled_Should_Return_Ok_And_18() {
            //Arrange
            var url = $"{baseUrl}/add?param1=5&param2=2&param3=3&param4=5&param5=3";

            //Act
            HttpResponseMessage response = await client.GetAsync(url);
            var result = string.Empty;
            if (response.IsSuccessStatusCode) {
                result = response.Content.ReadAsStringAsync().Result;
            }

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("18", result);
        }

        [Fact]
        public async Task Subtract_WhenCalled_Should_Return_Ok_And_12() {
            //Arrange
            var url = $"{baseUrl}/subtract?param1=25&param2=2&param3=3&param4=5&param5=3";

            //Act
            HttpResponseMessage response = await client.GetAsync(url);
            var result = string.Empty;
            if (response.IsSuccessStatusCode) {
                result = response.Content.ReadAsStringAsync().Result;
            }

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("12", result);
        }

        [Fact]
        public async Task Multiply_WhenCalled_Should_Return_Ok_And_120() {
            //Arrange
            var url = $"{baseUrl}/multiply?param1=2&param2=4&param3=3&param4=5";

            //Act
            HttpResponseMessage response = await client.GetAsync(url);
            var result = string.Empty;
            if (response.IsSuccessStatusCode) {
                result = response.Content.ReadAsStringAsync().Result;
            }

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("120", result);
        }

        [Fact]
        public async Task Divide_WhenCalled_Should_Return_Ok_And_4() {
            //Arrange
            var controller = new CalculatorController();

            //Act
            IActionResult actionResult = controller.Divide(16,4);
            var okResult = actionResult as OkObjectResult;

            //Assert
            decimal four = 4;
            Assert.NotNull(okResult);
            Assert.Equal(four, okResult.Value);
        }

        [Fact]
        public async Task SplitEq_WhenCalled_Should_Return_Ok_And_30() {
            //Arrange
            var controller = new CalculatorController();

            //Act
            IActionResult actionResult = controller.SplitEq(120, 4);
            var okResult = actionResult as OkObjectResult;

            //Assert
            decimal[] result = {30, 30, 30, 30};
            Assert.NotNull(okResult);
            Assert.Equal(result, okResult.Value);
        }

        [Fact]
        public async Task SplitNum_WhenCalled_Should_Return_Ok_And_40() {
            //Arrange
            var url = $"{baseUrl}/splitNum?param1=140&param2=45&param3=35&param4=20";

            //Act
            HttpResponseMessage response = await client.GetAsync(url);
            var result = string.Empty;
            if (response.IsSuccessStatusCode) {
                result = response.Content.ReadAsStringAsync().Result;
            }

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("40", result);
        }

    }
}
