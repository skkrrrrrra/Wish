using Microsoft.Extensions.DependencyInjection;
using Wish.Application.Services;
using Wish.Application.Services.Interfaces;
using Wish.Persistence.Common;

namespace Wish.Application;

public static class ApplicationConfiguration
{
	public static void AddServices(IServiceCollection serviceCollection)
	{
		serviceCollection.AddScoped<IAuditUserProvider, AuditUserProvider>();
		serviceCollection.AddScoped<IProductService, ProductService>();
		serviceCollection.AddScoped<ICartshopService, CartshopService>();
		serviceCollection.AddScoped<ISearchService, SearchService>();
		serviceCollection.AddScoped<IUserService, UserService>();
	}
}
