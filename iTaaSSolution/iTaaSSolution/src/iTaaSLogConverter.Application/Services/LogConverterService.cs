using CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Application.DTOs;
using CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Application.Interfaces;
using CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Infrastructure.Interfaces;


namespace CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Application.Services
{
    public class LogConverterService : ILogConverterService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IFileService _fileService;

        public LogConverterService(IHttpClientService httpClientService, IFileService fileService)
        {
            _httpClientService = httpClientService;
            _fileService = fileService;
        }

        public async Task ConvertLogAsync(string sourceUrl, string targetPath)
        {
            try
            {
                var logData = await _httpClientService.FetchDataAsync(sourceUrl);

                List<MinhaCdnLogEntryDto> minhaCdnLogs = logData.Select(x => new MinhaCdnLogEntryDto(x)).ToList();

                List<AgoraLogEntryDto> agoraLogs = minhaCdnLogs.Select(x => new AgoraLogEntryDto(x)).ToList();

                _fileService.WriteAgoraLogsToFile(agoraLogs, targetPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
       
    }
}
