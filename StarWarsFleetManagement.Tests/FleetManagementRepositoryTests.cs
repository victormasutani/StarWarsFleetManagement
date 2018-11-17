using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using StarWarsFleetManagement.Infrastructure.Repository;
using StarWarsFleetManagement.Tests.Stubs;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace StarWarsFleetManagement.Tests
{
    [TestClass]
    public class FleetManagementRepositoryTests
    {
        [TestMethod]
        public void GetAllStarshipsOk()
        {
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               // Setup the PROTECTED method to mock
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               // prepare the expected response of the mocked http call
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(FleetManagementRepositoryStub.JONStarships, Encoding.UTF8, "application/json")
               })
               .Verifiable();

            // use real http client with mocked handler here
            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/"),
            };

            var respository = new FleetManagementRepository(httpClient);
            var starships = respository.GetStarshipsAsync().Result;

            Assert.AreEqual(2, starships.Count());
        }
    }
}
