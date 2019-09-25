using System;
using System.Collections.Generic;
using System.Linq;

namespace Ucommerce.Seeder.DataSeeding.Utilities
{
    public static class GeneratorHelper
    {
        public static T[] Generate<T>(Func<T> generateAction, uint count)
        {
            var generated = new T[count];

            for (int i = 0; i < count; i++)
            {
                generated[i] = generateAction();
            }

            return generated;
        }
        
    }
}
