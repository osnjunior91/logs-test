using CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Infrastructure.Utilities.Extensions;

namespace CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Application.DTOs
{
    public class MinhaCdnLogEntryDto
    {
        public MinhaCdnLogEntryDto() { }

        public MinhaCdnLogEntryDto(string logLine) 
        {
            var logFields = logLine.Split('|');

            if (logFields.Length != 5)
            {
                throw new ArgumentException("Invalid log format. Expected 5 fields separated by '|'.");
            }

            if (!int.TryParse(logFields[0], out int responseSize) ||
                !int.TryParse(logFields[1], out int statusCode))
            {
                throw new ArgumentException("Failed to parse log fields.");
            }

            ResponseSize = responseSize;
            StatusCode = statusCode;
            CacheStatus = logFields[2];
            Request = logFields[3];
            TimeTaken = logFields[4].RoundToDecimalString();
        
        }


        public int ResponseSize { get; set; }
        public int StatusCode { get; set; }
        public string CacheStatus { get; set; }
        public string Request { get; set; }
        public string TimeTaken { get; set; }
    }
}
