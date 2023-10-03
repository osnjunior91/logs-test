namespace CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Application.DTOs
{
    public class AgoraLogEntryDto
    {
        public string Provider { get; set; }
        public string HttpMethod { get; set; }
        public int StatusCode { get; set; }
        public string UriPath { get; set; }
        public string TimeTaken { get; set; }
        public int ResponseSize { get; set; }
        public string CacheStatus { get; set; }

        public AgoraLogEntryDto(MinhaCdnLogEntryDto minhaCdnLog)
        {
            Provider = "MINHA CDN"; 
            HttpMethod = minhaCdnLog.Request.Split('/')[0].Trim().Replace("\"", "");
            StatusCode = minhaCdnLog.StatusCode;
            UriPath = minhaCdnLog.Request.Split('/')[1].Trim().Split(' ')[0].Trim();
            TimeTaken = minhaCdnLog.TimeTaken;
            ResponseSize = minhaCdnLog.ResponseSize;
            CacheStatus = ConvertCacheStatus(minhaCdnLog.CacheStatus);
        }

        private string ConvertCacheStatus(string cacheStatus)
        {
            switch (cacheStatus)
            {
                case "INVALIDATE":
                    return "REFRESH_HIT";
                default:
                    return cacheStatus;
            }
        }

        public override string ToString()
        {
            return $"\"{Provider}\" {HttpMethod} {StatusCode} /{UriPath} {TimeTaken} {ResponseSize} {CacheStatus}";
        }
    }
}
