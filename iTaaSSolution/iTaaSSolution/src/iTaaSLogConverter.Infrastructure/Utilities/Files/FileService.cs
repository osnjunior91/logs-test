using CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Application.DTOs;
using CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Infrastructure.Interfaces;

namespace CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Infrastructure.Utilities.Files
{
    public class FileService : IFileService
    {
        public void WriteAgoraLogsToFile(List<AgoraLogEntryDto> agoraLogs, string targetPath)
        {
            var dtTime = DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss");
            using (StreamWriter writer = new StreamWriter($"{targetPath}\\{dtTime}.txt"))
            {
                writer.WriteLine("#Version: 1.0");
                writer.WriteLine($"#Date: {dtTime}");
                writer.WriteLine("#Fields: provider http-method status-code uri-path time-taken response-size cache-status");

                foreach (var agoraLog in agoraLogs)
                {
                    writer.WriteLine(agoraLog.ToString());
                }
            }
        }
    }
}
