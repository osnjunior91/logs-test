using CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Application.DTOs;
using NUnit.Framework;

namespace CandidateTesting.OswaldoDaSilvaNicacioJunior.iTaaSLogConverter.Tests.iTaaSLogConverter.Application.Test.Dtos
{
    public class MinhaCdnLogEntryDtoTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("312|200|HIT|\"GET / robots.txt HTTP / 1.1\"|100.2")]
        public void CreatMinhaCdnLogEntryDto_WithValidParameters_ReturnsValidDto(string input)
        {
            var minhaCdn = new MinhaCdnLogEntryDto(input);
            Assert.IsTrue(minhaCdn.ResponseSize == 312);
            Assert.IsTrue(minhaCdn.StatusCode == 200);
            Assert.IsTrue(minhaCdn.CacheStatus.Equals("HIT"));
            Assert.IsTrue(minhaCdn.Request.Equals("\"GET / robots.txt HTTP / 1.1\""));
            Assert.IsTrue(minhaCdn.TimeTaken.Equals("100"));
        }
        [TestCase("312|200|HIT|\"GET / robots.txt HTTP / 1.1\"|100.2 | 200")]
        public void CreatMinhaCdnLogEntryDto_WithInvalidParametersNumbers_ReturnsException(string input)
        {
            Assert.Throws<ArgumentException>(() => new MinhaCdnLogEntryDto(input));
        }
        [TestCase("AAA|200|HIT|\"GET / robots.txt HTTP / 1.1\"|100.2")]
        [TestCase("321|AAA|HIT|\"GET / robots.txt HTTP / 1.1\"|100.2")]
        public void CreatMinhaCdnLogEntryDto_WithInvalidParameters_ReturnsException(string input)
        {
            Assert.Throws<ArgumentException>(() => new MinhaCdnLogEntryDto(input));
        }
    }
}
