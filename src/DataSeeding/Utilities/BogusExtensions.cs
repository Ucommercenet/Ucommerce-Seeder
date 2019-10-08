using System.Collections.Generic;
using System.Linq;

namespace Ucommerce.Seeder.DataSeeding.Utilities
{
    public static class BogusExtensions
    {
        public static T PickRandomOrDefault<T>(this Bogus.Faker faker, IEnumerable<T> items)
        {
            if (!items.Any())
            {
                return default(T);
            }
            return faker.Random.ArrayElement(items.ToArray());
        }

        public static IEnumerable<T> PickRandomOrDefault<T>(this Bogus.Faker faker, IEnumerable<T> items, int quantity)
        {
            if (!items.Any())
            {
                return new T[0];
            }

            return faker.PickRandom(items, quantity);
        }

    }
}