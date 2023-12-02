using System;
using Microsoft.Extensions.DependencyInjection;
using TOTAL_CAR_FEES.DOMAIN.Attributes;

namespace TOTAL_CAR_FEES.DOMAIN.Extensions
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddDomainServices(this IServiceCollection serviceCollection)
		{
			IEnumerable<Type> service = AppDomain.CurrentDomain.GetAssemblies()
							.Where(assembly =>
							{
								return !(assembly.FullName is null) && assembly.FullName.Contains("TOTAL_CAR_FEES.DOMAIN", StringComparison.InvariantCulture);
							})
							.SelectMany(s => s.GetTypes())
							.Where(p => p.CustomAttributes.Any(a => a.AttributeType == typeof(DomainServiceAttribute)));

			foreach (Type type in service)
			{
				serviceCollection.AddTransient(type);

            }
			return serviceCollection;

        }
	}
}

