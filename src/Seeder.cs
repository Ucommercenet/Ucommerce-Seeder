using System;
using System.IO;
using Newtonsoft.Json;
using Ucommerce.Seeder.DataAccess;
using Ucommerce.Seeder.DataSeeding;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder
{
    public class Seeder
    {
        private readonly string _cmsConnectionString;
        private readonly string _ucommerceConnectionString;
        private readonly bool _verbose;
        private readonly bool _excludeCmsTables;
        private readonly DatabaseSize _dbSize;

        public Seeder(string cmsConnectionString, string ucommerceConnectionString, DbSizeOption dbSize, bool verbose, bool excludeCmsTables, string useJsonDbSizePath)
        {
	        _cmsConnectionString = cmsConnectionString;
            _ucommerceConnectionString = ucommerceConnectionString;
            _verbose = verbose;
            _excludeCmsTables = excludeCmsTables;

            if (useJsonDbSizePath != null)
            {
                if (!File.Exists(useJsonDbSizePath))
                {
                    throw new ArgumentException($"Can not find file {useJsonDbSizePath}");
                }

                Console.WriteLine($"Using {useJsonDbSizePath} for database size.");
                _dbSize = JsonConvert.DeserializeObject<DatabaseSize>(File.ReadAllText(useJsonDbSizePath));
            }
            else
            {
                switch (dbSize)
                {
                    case DbSizeOption.Huge:
                        _dbSize = DatabaseSize.Huge;
                        break;
                    case DbSizeOption.Large:
                        _dbSize = DatabaseSize.Large;
                        break;
                    case DbSizeOption.Medium:
                        _dbSize = DatabaseSize.Medium;
                        break;
                    case DbSizeOption.TinyForTesting:
                        _dbSize = DatabaseSize.TinyForTesting;
                        break;
                    case DbSizeOption.Dev:
                        _dbSize = DatabaseSize.Developer;
                        break;
                    default:
                        throw new ArgumentException($"Unknown DbSizeOption value {dbSize}");
                }
            }
        }

        public int Run()
        {
            var seeder = new DataSeeder(_dbSize, _excludeCmsTables);

            seeder.Seed(() =>
            {
                var umbracoDbContext = new UmbracoDbContext(_cmsConnectionString, _verbose);
                var ucommerceDbContext = new UcommerceDbContext(_ucommerceConnectionString, _verbose);

                umbracoDbContext.ChangeTracker.AutoDetectChangesEnabled = false;
                ucommerceDbContext.ChangeTracker.AutoDetectChangesEnabled = false;

                var dataContext = new DataContext(ucommerceDbContext, umbracoDbContext);
                return dataContext;
            });

            return 0;
        }
    }
}