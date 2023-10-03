namespace CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Infrastructure.Interfaces
{
    public interface IHttpClientService
    {
        Task<List<string>> FetchDataAsync(string url);
    }
}
