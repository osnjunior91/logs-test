using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            UriPath = minhaCdnLog.Request.Split('/')[1].Trim();
            TimeTaken = minhaCdnLog.TimeTaken;
            ResponseSize = minhaCdnLog.ResponseSize;
            CacheStatus = minhaCdnLog.CacheStatus;
        }

    }
}
