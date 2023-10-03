using CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Application.DTOs;
using NUnit.Framework;


namespace CandidateTesting.OswaldoDaSilvaNicacioJunior.iTaaSLogConverter.Tests.iTaaSLogConverter.Application.Test.Dtos
{
    public class AgoraLogEntryDtoTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [TestCase("312|200|HIT|\"GET / robots.txt HTTP / 1.1\"|100.2", "\"MINHA CDN\" GET 200 /robots.txt 100 312 HIT")]
        [TestCase("101|200|MISS|\"POST /myImages HTTP/1.1\"|319.4", "\"MINHA CDN\" POST 200 /myImages 319 101 MISS")]
        [TestCase("199|404|MISS|\"GET /not-found HTTP/1.1\"|142.9", "\"MINHA CDN\" GET 404 /not-found 143 199 MISS")]
        [TestCase("312|200|INVALIDATE|\"GET /robots.txt HTTP/1.1\"|245.1", "\"MINHA CDN\" GET 200 /robots.txt 245 312 REFRESH_HIT")]
        public void CreateAgoraLogEntryDto_WithValidParameters_ReturnsValidDto(string input, string outPut)
        {
            var minhaCdn = new MinhaCdnLogEntryDto(input);
            var logEntry = new AgoraLogEntryDto(minhaCdn);
            Assert.IsTrue(outPut.Equals(logEntry.ToString()));
        }
    }
}
