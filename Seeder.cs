using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ucommerce.Seeder.DataSeeding;
using Ucommerce.Seeder.Models;
using Z.EntityFramework.Extensions;

namespace Ucommerce.Seeder
{
    public class Seeder
    {
        private readonly string _connectionString;
        private readonly bool _verbose;
        private readonly bool _excludeCmsTables;
        private readonly DatabaseSize _dbSize;

        public Seeder(string connectionString, DbSizeOption dbSize, bool verbose, bool excludeCmsTables)
        {
            _connectionString = connectionString;
            _verbose = verbose;
            _excludeCmsTables = excludeCmsTables;

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
                default:
                    throw new ArgumentException($"Unknown DbSizeOption value {dbSize}");
            }

            // Needed for EF Extensions
            EntityFrameworkManager.ContextFactory = context =>
            {
                var umbracoDbContext = new UmbracoDbContext(connectionString, verbose);
                umbracoDbContext.ChangeTracker.AutoDetectChangesEnabled = false;
                return umbracoDbContext;
            };
        }

        public async Task<int> Run()
        {
            var seeder = new DataSeeder(_dbSize, _excludeCmsTables);

            await seeder.Seed(() =>
            {
                var dbContext = new UmbracoDbContext(_connectionString, _verbose);
                dbContext.ChangeTracker.AutoDetectChangesEnabled = false;
                return dbContext;
            });

            return 0;
        }
    }
}