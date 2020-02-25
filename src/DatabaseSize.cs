// ReSharper disable InconsistentNaming
namespace Ucommerce.Seeder
{
    public struct DatabaseSize
    {
        public uint Currencies;
        public uint Definitions;
        public uint ProductDefinitions;
        public uint Products;
        public uint ProductRelationsPerProduct;
        public uint AverageVariantsPerProduct;
        public uint PriceGroups;
        public uint TiersPerPriceGroup;
        public uint Stores;
        public uint Languages;
        public uint CatalogsPerStore;
        public uint CategoriesPerCatalog;
        public uint AverageProductsPerCategory;
        public uint Campaigns;
        public uint AverageCampaignItemsPerCampaign;
        public uint ShippingMethods;
        public uint CmsMediaFolders;
        public uint CmsImagesPerFolder;
        public uint DataTypes;
        public uint AverageUserDefinedFieldsPerDefinition;
        public uint ProductRelationTypes;
        public uint OrderNumberSeries;

        public static readonly DatabaseSize Realistic = new DatabaseSize
        {
            DataTypes = 0,
            ProductDefinitions = 5,
            Definitions = 5,
            ProductRelationTypes = 2,
            OrderNumberSeries = 5,
            
            AverageUserDefinedFieldsPerDefinition = 20,

            Languages = 4,
            Currencies = 6,
            PriceGroups = 5,
            TiersPerPriceGroup = 2,

            Products = 500_000,
            AverageVariantsPerProduct = 0,
            ProductRelationsPerProduct = 5,

            Stores = 5,
            CatalogsPerStore = 5,
            CategoriesPerCatalog = 100,
            AverageProductsPerCategory = 1_000,
            
            CmsMediaFolders = 10,
            CmsImagesPerFolder = 100
        };

        public static readonly DatabaseSize Huge = new DatabaseSize
        {
            DataTypes = 50,
            ProductDefinitions = 100,
            Definitions = 100,
            ProductRelationTypes = 20,
            OrderNumberSeries = 20,

            AverageUserDefinedFieldsPerDefinition = 200,

            Languages = 20,
            Currencies = 100,
            PriceGroups = 3_000,
            TiersPerPriceGroup = 5,

            Products = 4000000,
            AverageVariantsPerProduct = 8,
            ProductRelationsPerProduct = 10,

            Stores = 1_000,
            CatalogsPerStore = 30,
            CategoriesPerCatalog = 1_000,
            AverageProductsPerCategory = 1000,
            
            CmsMediaFolders = 100,
            CmsImagesPerFolder = 1000
        };
        
        public static readonly DatabaseSize Large = new DatabaseSize
        {
            DataTypes = 10,
            ProductDefinitions = 20,
            Definitions = 20,
            ProductRelationTypes = 10,
            OrderNumberSeries = 5,

            AverageUserDefinedFieldsPerDefinition = 10,

            Languages = 10,
            Currencies = 30,
            PriceGroups = 200,
            TiersPerPriceGroup = 3,

            Products = 20000,
            AverageVariantsPerProduct = 10,
            ProductRelationsPerProduct = 100,

            Stores = 10,
            CatalogsPerStore = 20,
            CategoriesPerCatalog = 75,
            
            AverageProductsPerCategory = 125,
            
            CmsMediaFolders = 25,
            CmsImagesPerFolder = 250
        };

        public static readonly DatabaseSize Medium = new DatabaseSize
        {
            DataTypes = 5,
            ProductDefinitions = 5,
            Definitions = 10,
            ProductRelationTypes = 3,
            OrderNumberSeries = 1,

            AverageUserDefinedFieldsPerDefinition = 5,

            Languages = 4,
            Currencies = 10,
            PriceGroups = 50,
            TiersPerPriceGroup = 3,

            Products = 1_000,
            AverageVariantsPerProduct = 5,
            ProductRelationsPerProduct = 25,

            Stores = 10,
            CatalogsPerStore = 10,
            CategoriesPerCatalog = 50,
            
            AverageProductsPerCategory = 75,
            
            CmsMediaFolders = 10,
            CmsImagesPerFolder = 100
        };

        public static readonly DatabaseSize TinyForTesting = new DatabaseSize
        {
            DataTypes = 1,
            ProductDefinitions = 1,
            Definitions = 1,
            ProductRelationTypes = 1,

            AverageUserDefinedFieldsPerDefinition = 1,

            Languages = 1,
            Currencies = 1,
            PriceGroups = 1,
            TiersPerPriceGroup = 1,

            Products = 3,
            AverageVariantsPerProduct = 1,
            ProductRelationsPerProduct = 1,

            Stores = 1,
            CatalogsPerStore = 1,
            CategoriesPerCatalog = 5,
            
            AverageProductsPerCategory = 2,
            
            CmsMediaFolders = 1,
            CmsImagesPerFolder = 1
        };

    }
}