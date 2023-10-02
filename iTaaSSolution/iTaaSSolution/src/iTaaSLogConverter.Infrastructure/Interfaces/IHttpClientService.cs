using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Infrastructure.Interfaces
{
    public interface IHttpClientService
    {
        Task<List<string>> FetchDataAsync(string url);
    }
}
