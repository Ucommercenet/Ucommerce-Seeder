using System;

namespace Ucommerce.Seeder.DataAccess
{
	public class DataContext : IDisposable
	{
		public DataContext(UcommerceDbContext ucommerce, UmbracoDbContext cms)
		{
			Ucommerce = ucommerce;
			Cms = cms;
		}

		public UcommerceDbContext Ucommerce { get; }
		public UmbracoDbContext Cms { get; }

		public void Dispose()
		{
			Ucommerce?.Dispose();
			Cms?.Dispose();
		}
	}
}
