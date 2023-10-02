using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Application.Interfaces
{
    public interface ILogConverterService
    {
        Task ConvertLogAsync(string sourceUrl, string targetPath);
    }
}
