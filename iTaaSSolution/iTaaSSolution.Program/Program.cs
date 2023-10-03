using CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Application.Interfaces;
using CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Application.Services;
using CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Infrastructure.ExternalServices;
using CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Infrastructure.Interfaces;
using CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Infrastructure.Utilities.Files;
using Microsoft.Extensions.DependencyInjection;

namespace CandidateTesting.OswaldoDaSilvaNicacioJunior.iTaaSSolution.Program
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                Console.WriteLine("Iniciando a aplicação");
                var serviceCollection = new ServiceCollection();
                ConfigureServices(serviceCollection);
                var serviceProvider = serviceCollection.BuildServiceProvider();
                var _logService = serviceProvider.GetService<ILogConverterService>();
                string targetPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                await _logService.ConvertLogAsync("https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt", targetPath);
                Console.WriteLine("Aplicação Finalizada");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ILogConverterService, LogConverterService>()
                .AddScoped<IHttpClientService, HttpClientService>()
                .AddScoped<IFileService, FileService>();
        
        }
    }
}