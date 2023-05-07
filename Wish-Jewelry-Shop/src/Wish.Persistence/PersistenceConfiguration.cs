using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Wish.Persistence;

public static class PersistenceConfiguration
{
	public static void AddServices(IServiceCollection serviceCollection, string connectionString)
	{
		serviceCollection.AddDbContext<MainDbContext>(options => options.UseNpgsql(connectionString));
	}
}
