using System.Net;
using System.Text.Json.Serialization.Metadata;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Movies.API.Controllers;
using Movies.API.Entities;
using Movies.API.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace Movies.API.UnitTests
{
    public class MovieControllerTesting
    {
        private readonly Mock<IHelper> _mockHelper = new Mock<IHelper>();
        private readonly MovieController _controller;

        public MovieControllerTesting()
        {
            _controller = new MovieController(_mockHelper.Object);
        }

        [Fact]
        public async Task GetMovies_ReturnsOk()
        {
            // Arrange
            var filePath = "moviedata.json";
            var nr = 2;

            var movies = new List<Movie>()
            {
                new Movie()
                {
                    Info = new Info()
                    {
                        Rating = 8
                    },
                    Title = "test1",
                    Year = 2020
                },
                new Movie()
                {
                    Info = new Info()
                    {
                        ImageUrl = "dfgeargerg",
                        Rating = 4
                    },
                    Title = "test2",
                    Year = 2019
                }
            };

            _mockHelper.Setup(r => r.ReadFile<List<Movie>>(filePath)).Returns(movies);

            // Act
            var moviesResult = await _controller.GetMovies(nr);

            // Assert
            Assert.IsType<ActionResult<List<Movie>>>(moviesResult);
            Assert.Equal(JsonConvert.SerializeObject(movies), JsonConvert.SerializeObject((moviesResult.Result as OkObjectResult)?.Value));
        }
    }
}