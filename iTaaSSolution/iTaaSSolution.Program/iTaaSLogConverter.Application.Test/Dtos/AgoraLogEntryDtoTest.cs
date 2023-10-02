using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace iTaaSSolution.Program.iTaaSLogConverter.Application.Test.Dtos
{
    public class AgoraLogEntryDtoTest
    {
        [TestCase("312|200|HIT|\"GET / robots.txt HTTP / 1.1\"|100.2", "\"MINHA CDN\" GET 200 /robots.txt 100 312 HIT")]
        [TestCase("101|200|MISS|\"POST /myImages HTTP/1.1\"|319.4", "\"MINHA CDN\" POST 200 /myImages 319 101 MISS")]
        [TestCase("199|404|MISS|\"GET /not-found HTTP/1.1\"|142.9", "\"MINHA CDN\" GET 404 /not-found 143 199 MISS")]
        [TestCase("312|200|INVALIDATE|\"GET /robots.txt HTTP/1.1\"|245.1", "\"MINHA CDN\" GET 200 /robots.txt 245 312 REFRESH_HIT")]
        public void CreateAgoraLogEntryDto_WithValidParameters_ReturnsValidDto(string input, string outPut)
        {
            
        }
    }
}
