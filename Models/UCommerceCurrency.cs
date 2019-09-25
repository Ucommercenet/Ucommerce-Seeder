using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceCurrency
    {
        public UCommerceCurrency()
        {
            UCommerceCurrencyExchangeRateFromCurrency = new HashSet<UCommerceCurrencyExchangeRate>();
            UCommerceCurrencyExchangeRateToCurrency = new HashSet<UCommerceCurrencyExchangeRate>();
            UCommercePriceGroup = new HashSet<UCommercePriceGroup>();
            UCommerceProductCatalogGroup = new HashSet<UCommerceProductCatalogGroup>();
            UCommercePurchaseOrder = new HashSet<UCommercePurchaseOrder>();
        }

        public int CurrencyId { get; set; }
        public string Isocode { get; set; }
        public int ExchangeRate { get; set; }
        public bool Deleted { get; set; }
        public Guid Guid { get; set; }

        public virtual ICollection<UCommerceCurrencyExchangeRate> UCommerceCurrencyExchangeRateFromCurrency { get; set; }
        public virtual ICollection<UCommerceCurrencyExchangeRate> UCommerceCurrencyExchangeRateToCurrency { get; set; }
        public virtual ICollection<UCommercePriceGroup> UCommercePriceGroup { get; set; }
        public virtual ICollection<UCommerceProductCatalogGroup> UCommerceProductCatalogGroup { get; set; }
        public virtual ICollection<UCommercePurchaseOrder> UCommercePurchaseOrder { get; set; }
    }
}
