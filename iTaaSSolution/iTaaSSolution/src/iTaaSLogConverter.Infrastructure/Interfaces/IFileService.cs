using CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Application.DTOs;

namespace CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Infrastructure.Interfaces
{
    public interface IFileService
    {
        void WriteAgoraLogsToFile(List<AgoraLogEntryDto> agoraLogs, string targetPath);
    }
}
