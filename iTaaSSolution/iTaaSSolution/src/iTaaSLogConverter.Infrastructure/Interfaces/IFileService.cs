using CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Infrastructure.Interfaces
{
    public interface IFileService
    {
        void WriteAgoraLogsToFile(List<AgoraLogEntryDto> agoraLogs, string targetPath);
    }
}
