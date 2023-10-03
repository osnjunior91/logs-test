namespace CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Application.Interfaces
{
    public interface ILogConverterService
    {
        Task ConvertLogAsync(string sourceUrl, string targetPath);
    }
}
