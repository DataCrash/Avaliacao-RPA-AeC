using RPA.AeC.Application.UseCases.GetSearchedResultUseCase;
using RPA.AeC.Domain.Repositories.MongoDB;
using RPA.AeC.Infra.Persistence.MongoDB.Repositories;
using RPA.AeC.Services.RPA;
using System.Diagnostics.CodeAnalysis;

namespace RPA.AeC.API.Configurations
{
    [ExcludeFromCodeCoverage]
    public static class DependenceInjections
    {
        public static void AddDependenceInjections(this IServiceCollection services)
        {
            services.AddTransient<IGetSearchedResultUseCase, GetSearchedResultUseCase>();
            services.AddTransient<ISearchedResultRepository, SearchedResultRepository>();
            services.AddTransient<ISearchAutomationService, SearchAutomationService>();
        }
    }
}
