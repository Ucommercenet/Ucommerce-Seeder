using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Ucommerce.Seeder.DataSeeding;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder
{
    public class Seeder
    {
        private readonly string _connectionString;
        private readonly bool _verbose;
        private readonly bool _excludeCmsTables;
        private readonly bool _fixedRandomSeed;
        private readonly DatabaseSize _dbSize;

        public Seeder(    string connectionString, DbSizeOption dbSize, bool verbose, bool excludeCmsTables,
            string useJsonDbSizePath, bool fixedRandomSeed)
        {
            _connectionString = connectionString;
            _verbose = verbose;
            _excludeCmsTables = excludeCmsTables;
            _fixedRandomSeed = fixedRandomSeed;

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
            var seeder = new DataSeeder(_dbSize, _excludeCmsTables, _fixedRandomSeed);

            seeder.Seed(() =>
            {
                var dbContext = new UmbracoDbContext(_connectionString, _verbose);
                dbContext.ChangeTracker.AutoDetectChangesEnabled = false;
                return dbContext;
            });

            return 0;
        }
    }
}