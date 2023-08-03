using Expenses.App.Services;

namespace Expenses.App
{
	public static class ServiceCollextionExtensions
	{
		public static IServiceCollection AddAppServices(this IServiceCollection services)
		{
			services.AddScoped<IExpensesService, ExpensesService>();
			return services;
		}
	}
}

