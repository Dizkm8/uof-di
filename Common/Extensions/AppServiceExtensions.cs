using Microsoft.EntityFrameworkCore;
using TranslateHistory.Common.Data;
using TranslateHistory.Common.Data.Interfaces;
using TranslateHistory.Words;
using TranslateHistory.Words.Interfaces;

namespace TranslateHistory.Common.Extensions
{
    public static class AppServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            BaseConfig(services);

            services.AddScoped<IWordsService, WordsService>();
            services.AddScoped<IWordsRepository, WordsRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void BaseConfig(IServiceCollection services)
        {
            services.AddControllers();
            AddDbContext(services);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        private static void AddDbContext(IServiceCollection services)
        {
            // UseInMemoryDatabase is only for testing purposes
            // Do not bring it to production or even a serious development
            services.AddDbContext<DataContext>(opt =>
                opt.UseInMemoryDatabase("TranslateAppDB")
            );
        }

    }
}