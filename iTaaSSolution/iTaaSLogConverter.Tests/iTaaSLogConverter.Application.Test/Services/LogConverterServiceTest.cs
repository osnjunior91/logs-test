using CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Application.DTOs;
using CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Application.Services;
using CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;

namespace CandidateTesting.OswaldoDaSilvaNicacioJunior.iTaaSLogConverter.Tests.iTaaSLogConverter.Application.Test.Services
{
    public class LogConverterServiceTest
    {
        private Mock<IHttpClientService> _httpClientService;
        private Mock<IFileService> _fileService;

        [SetUp]
        public void Setup()
        {
            _httpClientService = new Mock<IHttpClientService>();
            _fileService = new Mock<IFileService>();
        }

        [Test]
        public async Task ConvertLogAsync_ValidInput_CallsFetchDataAsyncAndWriteAgoraLogsToFile()
        {
           
            var logData = new List<string>() { 
                "312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2",
                "101|200|MISS|\"POST /myImages HTTP/1.1\"|319.4" 
            };
            _httpClientService.Setup(x => x.FetchDataAsync(It.IsAny<string>())).ReturnsAsync(logData);

            var logConverterService = new LogConverterService(_httpClientService.Object, _fileService.Object);

            await logConverterService.ConvertLogAsync("http://example.com/logs.txt", "output.txt");


            _httpClientService.Verify(x => x.FetchDataAsync("http://example.com/logs.txt"), Times.Once);

            _fileService.Verify(x => x.WriteAgoraLogsToFile(
                It.IsAny<List<AgoraLogEntryDto>>(),
                "output.txt"), Times.Once);
        }

        [Test]
        public void ConvertLogAsync_NullSourceUrl_ThrowsArgumentNullException()
        {
           
            var logConverterService = new LogConverterService(_httpClientService.Object, _fileService.Object);
            Assert.ThrowsAsync<ArgumentNullException>(async () => await logConverterService.ConvertLogAsync(null, "output.txt"));
        }

        [Test]
        public void ConvertLogAsync_NullTargetPath_ThrowsArgumentNullException()
        {
            var logConverterService = new LogConverterService(_httpClientService.Object, _fileService.Object);
            Assert.ThrowsAsync<ArgumentNullException>(async () => await logConverterService.ConvertLogAsync("http://example.com/logs.txt", null));
        }
    }
}
