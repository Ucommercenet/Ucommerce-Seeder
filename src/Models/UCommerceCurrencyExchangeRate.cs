using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceCurrencyExchangeRate
    {
        public int CurrencyExchangeRateId { get; set; }
        public Guid Guid { get; set; }
        public int FromCurrencyId { get; set; }
        public int ToCurrencyId { get; set; }
        public decimal Rate { get; set; }

        public virtual UCommerceCurrency FromCurrency { get; set; }
        public virtual UCommerceCurrency ToCurrency { get; set; }
    }
}
