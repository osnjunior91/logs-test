using CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Application.DTOs;
using CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Application.Interfaces;
using CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Infrastructure.Interfaces;
using System;


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
            if (string.IsNullOrEmpty(sourceUrl))
                throw new ArgumentNullException(nameof(targetPath));

            if (string.IsNullOrEmpty(targetPath))
                throw new ArgumentNullException(nameof(targetPath));

            var logData = await _httpClientService.FetchDataAsync(sourceUrl);
            List<MinhaCdnLogEntryDto> minhaCdnLogs = logData.Select(x => new MinhaCdnLogEntryDto(x)).ToList();
            List<AgoraLogEntryDto> agoraLogs = minhaCdnLogs.Select(x => new AgoraLogEntryDto(x)).ToList();
            _fileService.WriteAgoraLogsToFile(agoraLogs, targetPath);
        }

    }
}
