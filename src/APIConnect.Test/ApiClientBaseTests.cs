using APIConnect.Core.BaseClasses;
using Moq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIConnect.Test
{
    public class ApiClientBaseTests
    {
        private readonly ApiClientBase _apiClient;
        private readonly Mock<IRestClient> _restClientMock;

        public ApiClientBaseTests()
        {
            _restClientMock = new Mock<IRestClient>();
            _apiClient = new ApiClientBase(_restClientMock.Object);
        }

        [Fact]
        public Task GetAsync_SuccessfulResponse_ReturnData()
        {
            // Arrange
            var endpoint = "https://api.example.com/users";
            var expectedData = new { Id = 1, Name = "John Doe" };
            var responseMock = new Mock<RestResponse<object>>();
            responseMock.SetupGet(r => r.IsSuccessful).Returns(true);
            responseMock.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.OK);
            responseMock.SetupGet(r => r.Data).Returns(expectedData);

            _restClientMock.Setup(c => c.ExecuteAsync<object>(It.IsAny<RestRequest>()))
                .ReturnsAsync(responseMock.Object);

        }

    }
}
