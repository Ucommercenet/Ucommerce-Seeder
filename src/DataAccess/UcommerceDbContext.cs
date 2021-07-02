using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataAccess
{
    public partial class UcommerceDbContext : DbContext
    {
        private readonly string _connectionString;
        private readonly bool _verbose;

        public UcommerceDbContext(string connectionString, bool verbose) : base()
        {
            _connectionString = connectionString;
            _verbose = verbose;
        }

        public UcommerceDbContext(DbContextOptions<UcommerceDbContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<UCommerceAddress> UCommerceAddress { get; set; }
        public virtual DbSet<UCommerceAdminPage> UCommerceAdminPage { get; set; }
        public virtual DbSet<UCommerceAdminTab> UCommerceAdminTab { get; set; }
        public virtual DbSet<UCommerceAmountOffOrderLinesAward> UCommerceAmountOffOrderLinesAward { get; set; }
        public virtual DbSet<UCommerceAmountOffOrderTotalAward> UCommerceAmountOffOrderTotalAward { get; set; }
        public virtual DbSet<UCommerceAmountOffUnitAward> UCommerceAmountOffUnitAward { get; set; }
        public virtual DbSet<UCommerceAppSystemVersion> UCommerceAppSystemVersion { get; set; }
        public virtual DbSet<UCommerceAward> UCommerceAward { get; set; }
        public virtual DbSet<UCommerceCampaign> UCommerceCampaign { get; set; }
        public virtual DbSet<UCommerceCampaignItem> UCommerceCampaignItem { get; set; }
        public virtual DbSet<UCommerceCampaignItemProperty> UCommerceCampaignItemProperty { get; set; }
        public virtual DbSet<UCommerceCategory> UCommerceCategory { get; set; }
        public virtual DbSet<UCommerceCategoryDescription> UCommerceCategoryDescription { get; set; }
        public virtual DbSet<UCommerceCategoryProductRelation> UCommerceCategoryProductRelation { get; set; }
        public virtual DbSet<UCommerceCategoryProperty> UCommerceCategoryProperty { get; set; }
        public virtual DbSet<UCommerceCategoryTarget> UCommerceCategoryTarget { get; set; }
        public virtual DbSet<UCommerceCountry> UCommerceCountry { get; set; }
        public virtual DbSet<UCommerceCurrency> UCommerceCurrency { get; set; }
        public virtual DbSet<UCommerceCurrencyExchangeRate> UCommerceCurrencyExchangeRate { get; set; }
        public virtual DbSet<UCommerceCustomer> UCommerceCustomer { get; set; }
        public virtual DbSet<UCommerceDataType> UCommerceDataType { get; set; }
        public virtual DbSet<UCommerceDataTypeEnum> UCommerceDataTypeEnum { get; set; }
        public virtual DbSet<UCommerceDataTypeEnumDescription> UCommerceDataTypeEnumDescription { get; set; }
        public virtual DbSet<UCommerceDefinition> UCommerceDefinition { get; set; }
        public virtual DbSet<UCommerceDefinitionField> UCommerceDefinitionField { get; set; }
        public virtual DbSet<UCommerceDefinitionFieldDescription> UCommerceDefinitionFieldDescription { get; set; }
        public virtual DbSet<UCommerceDefinitionRelation> UCommerceDefinitionRelation { get; set; }
        public virtual DbSet<UCommerceDefinitionType> UCommerceDefinitionType { get; set; }
        public virtual DbSet<UCommerceDefinitionTypeDescription> UCommerceDefinitionTypeDescription { get; set; }
        public virtual DbSet<UCommerceDiscount> UCommerceDiscount { get; set; }

        public virtual DbSet<UCommerceDiscountSpecificOrderLineAward> UCommerceDiscountSpecificOrderLineAward
        {
            get;
            set;
        }

        public virtual DbSet<UCommerceDynamicOrderPropertyTarget> UCommerceDynamicOrderPropertyTarget { get; set; }
        public virtual DbSet<UCommerceEmailContent> UCommerceEmailContent { get; set; }
        public virtual DbSet<UCommerceEmailParameter> UCommerceEmailParameter { get; set; }
        public virtual DbSet<UCommerceEmailProfile> UCommerceEmailProfile { get; set; }
        public virtual DbSet<UCommerceEmailProfileInformation> UCommerceEmailProfileInformation { get; set; }
        public virtual DbSet<UCommerceEmailType> UCommerceEmailType { get; set; }
        public virtual DbSet<UCommerceEmailTypeParameter> UCommerceEmailTypeParameter { get; set; }
        public virtual DbSet<UCommerceEntityProperty> UCommerceEntityProperty { get; set; }
        public virtual DbSet<UCommerceEntityUi> UCommerceEntityUi { get; set; }
        public virtual DbSet<UCommerceEntityUiDescription> UCommerceEntityUiDescription { get; set; }
        public virtual DbSet<UCommerceFreeGiftAward> UCommerceFreeGiftAward { get; set; }
        public virtual DbSet<UCommerceOrderAddress> UCommerceOrderAddress { get; set; }
        public virtual DbSet<UCommerceOrderAmountTarget> UCommerceOrderAmountTarget { get; set; }
        public virtual DbSet<UCommerceOrderLine> UCommerceOrderLine { get; set; }
        public virtual DbSet<UCommerceOrderLineDiscountRelation> UCommerceOrderLineDiscountRelation { get; set; }
        public virtual DbSet<UCommerceOrderNumberSerie> UCommerceOrderNumberSerie { get; set; }
        public virtual DbSet<UCommerceOrderProperty> UCommerceOrderProperty { get; set; }
        public virtual DbSet<UCommerceOrderStatus> UCommerceOrderStatus { get; set; }
        public virtual DbSet<UCommerceOrderStatusAudit> UCommerceOrderStatusAudit { get; set; }
        public virtual DbSet<UCommercePayment> UCommercePayment { get; set; }
        public virtual DbSet<UCommercePaymentMethod> UCommercePaymentMethod { get; set; }
        public virtual DbSet<UCommercePaymentMethodCountry> UCommercePaymentMethodCountry { get; set; }
        public virtual DbSet<UCommercePaymentMethodDescription> UCommercePaymentMethodDescription { get; set; }
        public virtual DbSet<UCommercePaymentMethodFee> UCommercePaymentMethodFee { get; set; }
        public virtual DbSet<UCommercePaymentMethodProperty> UCommercePaymentMethodProperty { get; set; }
        public virtual DbSet<UCommercePaymentProperty> UCommercePaymentProperty { get; set; }
        public virtual DbSet<UCommercePaymentStatus> UCommercePaymentStatus { get; set; }
        public virtual DbSet<UCommercePercentOffOrderLinesAward> UCommercePercentOffOrderLinesAward { get; set; }
        public virtual DbSet<UCommercePercentOffOrderTotalAward> UCommercePercentOffOrderTotalAward { get; set; }
        public virtual DbSet<UCommercePercentOffShippingTotalAward> UCommercePercentOffShippingTotalAward { get; set; }
        public virtual DbSet<UCommercePermission> UCommercePermission { get; set; }
        public virtual DbSet<UCommercePrice> UCommercePrice { get; set; }
        public virtual DbSet<UCommercePriceGroup> UCommercePriceGroup { get; set; }
        public virtual DbSet<UCommercePriceGroupTarget> UCommercePriceGroupTarget { get; set; }
        public virtual DbSet<UCommerceProduct> UCommerceProduct { get; set; }
        public virtual DbSet<UCommerceProductCatalog> UCommerceProductCatalog { get; set; }
        public virtual DbSet<UCommerceProductCatalogDescription> UCommerceProductCatalogDescription { get; set; }
        public virtual DbSet<UCommerceProductCatalogGroup> UCommerceProductCatalogGroup { get; set; }

        public virtual DbSet<UCommerceProductCatalogGroupCampaignRelation> UCommerceProductCatalogGroupCampaignRelation
        {
            get;
            set;
        }

        public virtual DbSet<UCommerceProductCatalogGroupPaymentMethodMap> UCommerceProductCatalogGroupPaymentMethodMap
        {
            get;
            set;
        }

        public virtual DbSet<UCommerceProductCatalogGroupShippingMethodMap>
            UCommerceProductCatalogGroupShippingMethodMap { get; set; }

        public virtual DbSet<UCommerceProductCatalogGroupTarget> UCommerceProductCatalogGroupTarget { get; set; }

        public virtual DbSet<UCommerceProductCatalogPriceGroupRelation> UCommerceProductCatalogPriceGroupRelation
        {
            get;
            set;
        }

        public virtual DbSet<UCommerceProductCatalogTarget> UCommerceProductCatalogTarget { get; set; }
        public virtual DbSet<UCommerceProductDefinition> UCommerceProductDefinition { get; set; }
        public virtual DbSet<UCommerceProductDefinitionField> UCommerceProductDefinitionField { get; set; }

        public virtual DbSet<UCommerceProductDefinitionFieldDescription> UCommerceProductDefinitionFieldDescription
        {
            get;
            set;
        }

        public virtual DbSet<UCommerceProductDefinitionRelation> UCommerceProductDefinitionRelation { get; set; }
        public virtual DbSet<UCommerceProductDescription> UCommerceProductDescription { get; set; }
        public virtual DbSet<UCommerceProductDescriptionProperty> UCommerceProductDescriptionProperty { get; set; }
        public virtual DbSet<UCommerceProductPrice> UCommerceProductPrice { get; set; }
        public virtual DbSet<UCommerceProductProperty> UCommerceProductProperty { get; set; }
        public virtual DbSet<UCommerceProductRelation> UCommerceProductRelation { get; set; }
        public virtual DbSet<UCommerceProductRelationType> UCommerceProductRelationType { get; set; }
        public virtual DbSet<UCommerceProductReview> UCommerceProductReview { get; set; }
        public virtual DbSet<UCommerceProductReviewComment> UCommerceProductReviewComment { get; set; }
        public virtual DbSet<UCommerceProductReviewStatus> UCommerceProductReviewStatus { get; set; }
        public virtual DbSet<UCommerceProductTarget> UCommerceProductTarget { get; set; }
        public virtual DbSet<UCommercePurchaseOrder> UCommercePurchaseOrder { get; set; }
        public virtual DbSet<UCommerceQuantityTarget> UCommerceQuantityTarget { get; set; }
        public virtual DbSet<UCommerceRole> UCommerceRole { get; set; }
        public virtual DbSet<UCommerceShipment> UCommerceShipment { get; set; }
        public virtual DbSet<UCommerceShipmentDiscountRelation> UCommerceShipmentDiscountRelation { get; set; }
        public virtual DbSet<UCommerceShippingMethod> UCommerceShippingMethod { get; set; }
        public virtual DbSet<UCommerceShippingMethodCountry> UCommerceShippingMethodCountry { get; set; }
        public virtual DbSet<UCommerceShippingMethodDescription> UCommerceShippingMethodDescription { get; set; }
        public virtual DbSet<UCommerceShippingMethodPaymentMethods> UCommerceShippingMethodPaymentMethods { get; set; }
        public virtual DbSet<UCommerceShippingMethodPrice> UCommerceShippingMethodPrice { get; set; }
        public virtual DbSet<UCommerceShippingMethodsTarget> UCommerceShippingMethodsTarget { get; set; }
        public virtual DbSet<UCommerceSystemVersion> UCommerceSystemVersion { get; set; }
        public virtual DbSet<UCommerceTarget> UCommerceTarget { get; set; }
        public virtual DbSet<UCommerceUser> UCommerceUser { get; set; }
        public virtual DbSet<UCommerceUserGroup> UCommerceUserGroup { get; set; }
        public virtual DbSet<UCommerceUserGroupPermission> UCommerceUserGroupPermission { get; set; }
        public virtual DbSet<UCommerceUserWidgetSetting> UCommerceUserWidgetSetting { get; set; }
        public virtual DbSet<UCommerceUserWidgetSettingProperty> UCommerceUserWidgetSettingProperty { get; set; }
        public virtual DbSet<UCommerceVoucherCode> UCommerceVoucherCode { get; set; }
        public virtual DbSet<UCommerceVoucherTarget> UCommerceVoucherTarget { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
                
                if (_verbose)
                {
                    IServiceCollection serviceCollection = new ServiceCollection();
                    serviceCollection.AddLogging(builder => builder
                        .AddConsole()
                        .AddFilter(level => level >= LogLevel.Information)
                    );
                    var loggerFactory = serviceCollection.BuildServiceProvider().GetService<ILoggerFactory>();
                    optionsBuilder.UseLoggerFactory(loggerFactory).EnableSensitiveDataLogging();
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UCommerceAddress>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("uCommerce_PK_Address");

                entity.ToTable("uCommerce_Address");

                entity.HasIndex(e => e.CountryId);

                entity.HasIndex(e => e.CustomerId);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_Address_Guid")
                    .IsUnique();

                entity.Property(e => e.AddressName)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.Attention).HasMaxLength(512);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.CompanyName).HasMaxLength(512);

                entity.Property(e => e.EmailAddress).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(512);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.LastName).HasMaxLength(512);

                entity.Property(e => e.Line1)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.Line2).HasMaxLength(512);

                entity.Property(e => e.MobilePhoneNumber).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(512);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.UCommerceAddress)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_Address_Country");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.UCommerceAddress)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_Address_Customer");
            });

            modelBuilder.Entity<UCommerceAdminPage>(entity =>
            {
                entity.HasKey(e => e.AdminPageId)
                    .HasName("uCommerce_PK_AdminPage");

                entity.ToTable("uCommerce_AdminPage");

                entity.HasIndex(e => e.FullName);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_AdminPage_Guid")
                    .IsUnique();

                entity.Property(e => e.ActiveTab)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");
            });

            modelBuilder.Entity<UCommerceAdminTab>(entity =>
            {
                entity.HasKey(e => e.AdminTabId)
                    .HasName("uCommerce_PK_AdminTab");

                entity.ToTable("uCommerce_AdminTab");

                entity.HasIndex(e => e.AdminPageId);

                entity.HasIndex(e => e.Enabled);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_AdminTab_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.MultiLingual);

                entity.HasIndex(e => e.SortOrder);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.HasSaveButton)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ResouceKey).HasMaxLength(256);

                entity.Property(e => e.VirtualPath)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.HasOne(d => d.AdminPage)
                    .WithMany(p => p.UCommerceAdminTab)
                    .HasForeignKey(d => d.AdminPageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_AdminTab_AdminPage");
            });

            modelBuilder.Entity<UCommerceAmountOffOrderLinesAward>(entity =>
            {
                entity.HasKey(e => e.AmountOffOrderLinesAwardId);

                entity.ToTable("uCommerce_AmountOffOrderLinesAward");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_AmountOffOrderLinesAward_Guid")
                    .IsUnique();

                entity.Property(e => e.AmountOffOrderLinesAwardId).ValueGeneratedNever();

                entity.Property(e => e.AmountOff).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.AmountOffOrderLinesAward)
                    .WithOne(p => p.UCommerceAmountOffOrderLinesAward)
                    .HasForeignKey<UCommerceAmountOffOrderLinesAward>(d => d.AmountOffOrderLinesAwardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_AmountOffOrderLinesAward_uCommerce_Award");
            });

            modelBuilder.Entity<UCommerceAmountOffOrderTotalAward>(entity =>
            {
                entity.HasKey(e => e.AmountOffOrderTotalAwardId)
                    .HasName("PK_uCommerce_AmountOffOrderTotalAward_1");

                entity.ToTable("uCommerce_AmountOffOrderTotalAward");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_AmountOffOrderTotalAward_Guid")
                    .IsUnique();

                entity.Property(e => e.AmountOffOrderTotalAwardId).ValueGeneratedNever();

                entity.Property(e => e.AmountOff).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.AmountOffOrderTotalAward)
                    .WithOne(p => p.UCommerceAmountOffOrderTotalAward)
                    .HasForeignKey<UCommerceAmountOffOrderTotalAward>(d => d.AmountOffOrderTotalAwardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_AmountOffOrderTotalAward_uCommerce_Award");
            });

            modelBuilder.Entity<UCommerceAmountOffUnitAward>(entity =>
            {
                entity.HasKey(e => e.AmountOffUnitAwardId);

                entity.ToTable("uCommerce_AmountOffUnitAward");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_AmountOffUnitAward_Guid")
                    .IsUnique();

                entity.Property(e => e.AmountOffUnitAwardId).ValueGeneratedNever();

                entity.Property(e => e.AmountOff).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.AmountOffUnitAward)
                    .WithOne(p => p.UCommerceAmountOffUnitAward)
                    .HasForeignKey<UCommerceAmountOffUnitAward>(d => d.AmountOffUnitAwardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_AmountOffUnitAward_uCommerce_Award");
            });

            modelBuilder.Entity<UCommerceAppSystemVersion>(entity =>
            {
                entity.HasKey(e => e.AppSystemVersionId);

                entity.ToTable("uCommerce_AppSystemVersion");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_AppSystemVersion_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.SchemaVersion);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.MigrationName).HasMaxLength(512);
            });

            modelBuilder.Entity<UCommerceAward>(entity =>
            {
                entity.HasKey(e => e.AwardId);

                entity.ToTable("uCommerce_Award");

                entity.HasIndex(e => e.CampaignItemId);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_Award_Guid")
                    .IsUnique();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CampaignItem)
                    .WithMany(p => p.UCommerceAward)
                    .HasForeignKey(d => d.CampaignItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_Award_uCommerce_CampaignItem");
            });

            modelBuilder.Entity<UCommerceCampaign>(entity =>
            {
                entity.HasKey(e => e.CampaignId);

                entity.ToTable("uCommerce_Campaign");

                entity.HasIndex(e => e.Deleted);

                entity.HasIndex(e => e.Enabled);

                entity.HasIndex(e => e.EndsOn);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_Campaign_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.Priority);

                entity.HasIndex(e => e.StartsOn);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.EndsOn).HasColumnType("datetime");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(512);

                entity.Property(e => e.StartsOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<UCommerceCampaignItem>(entity =>
            {
                entity.HasKey(e => e.CampaignItemId);

                entity.ToTable("uCommerce_CampaignItem");

                entity.HasIndex(e => e.AllowNextCampaignItems);

                entity.HasIndex(e => e.AnyTargetAdvertises);

                entity.HasIndex(e => e.AnyTargetAppliesAwards);

                entity.HasIndex(e => e.CampaignId);

                entity.HasIndex(e => e.DefinitionId);

                entity.HasIndex(e => e.Deleted);

                entity.HasIndex(e => e.Enabled);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_CampaignItem_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.Priority);

                entity.Property(e => e.AnyTargetAdvertises)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(512);

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.UCommerceCampaignItem)
                    .HasForeignKey(d => d.CampaignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_CampaignItem_uCommerce_Campaign");

                entity.HasOne(d => d.Definition)
                    .WithMany(p => p.UCommerceCampaignItem)
                    .HasForeignKey(d => d.DefinitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_CampaignItem_uCommerce_Definition");
            });

            modelBuilder.Entity<UCommerceCampaignItemProperty>(entity =>
            {
                entity.HasKey(e => e.CampaignItemPropertyId);

                entity.ToTable("uCommerce_CampaignItemProperty");

                entity.HasIndex(e => e.CampaignItemId);

                entity.HasIndex(e => e.CultureCode);

                entity.HasIndex(e => e.DefinitionFieldId);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_CampaignItemProperty_Guid")
                    .IsUnique();

                entity.Property(e => e.CultureCode).HasMaxLength(60);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Value).IsRequired();

                entity.HasOne(d => d.CampaignItem)
                    .WithMany(p => p.UCommerceCampaignItemProperty)
                    .HasForeignKey(d => d.CampaignItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_CampaignItemProperty_uCommerce_CampaignItem");

                entity.HasOne(d => d.DefinitionField)
                    .WithMany(p => p.UCommerceCampaignItemProperty)
                    .HasForeignKey(d => d.DefinitionFieldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_CampaignItemProperty_uCommerce_DefinitionField");
            });

            modelBuilder.Entity<UCommerceCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("uCommerce_PK_Category");

                entity.ToTable("uCommerce_Category");

                entity.HasIndex(e => e.DefinitionId);

                entity.HasIndex(e => e.Deleted);

                entity.HasIndex(e => e.DisplayOnSite);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_Category_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.Name);

                entity.HasIndex(e => e.ParentCategoryId);

                entity.HasIndex(e => e.ProductCatalogId);

                entity.HasIndex(e => e.SortOrder);

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DefinitionId).HasDefaultValueSql("((1))");

                entity.Property(e => e.DisplayOnSite)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.HasOne(d => d.Definition)
                    .WithMany(p => p.UCommerceCategory)
                    .HasForeignKey(d => d.DefinitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_Category_uCommerce_Definition");

                entity.HasOne(d => d.ParentCategory)
                    .WithMany(p => p.InverseParentCategory)
                    .HasForeignKey(d => d.ParentCategoryId)
                    .HasConstraintName("FK_uCommerce_Category_ParentCategory");

                entity.HasOne(d => d.ProductCatalog)
                    .WithMany(p => p.UCommerceCategory)
                    .HasForeignKey(d => d.ProductCatalogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_Category_ProductCatalog");
            });

            modelBuilder.Entity<UCommerceCategoryDescription>(entity =>
            {
                entity.HasKey(e => e.CategoryDescriptionId)
                    .HasName("uCommerce_PK_CategoryDescription");

                entity.ToTable("uCommerce_CategoryDescription");

                entity.HasIndex(e => e.CategoryId);

                entity.HasIndex(e => e.CultureCode);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_CategoryDescription_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.RenderAsContent);

                entity.HasIndex(e => new {e.CultureCode, e.CategoryId})
                    .HasName("UX_uCommerce_CategoryDescription_CultureCode_CategoryId")
                    .IsUnique();

                entity.Property(e => e.CultureCode)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.UCommerceCategoryDescription)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_CategoryDescription_Category");
            });

            modelBuilder.Entity<UCommerceCategoryProductRelation>(entity =>
            {
                entity.HasKey(e => e.CategoryProductRelationId)
                    .HasName("uCommerce_PK_CategoryProductRelation");

                entity.ToTable("uCommerce_CategoryProductRelation");

                entity.HasIndex(e => e.CategoryId);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_CategoryProductRelation_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.ProductId);

                entity.HasIndex(e => e.SortOrder);

                entity.HasIndex(e => new {e.CategoryId, e.ProductId})
                    .HasName("UX_uCommerce_CategoryProductRelation_CategoryId_ProductId")
                    .IsUnique();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.UCommerceCategoryProductRelation)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_CategoryProductRelation_Category");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.UCommerceCategoryProductRelation)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_CategoryProductRelation_Product");
            });

            modelBuilder.Entity<UCommerceCategoryProperty>(entity =>
            {
                entity.HasKey(e => e.CategoryPropertyId);

                entity.ToTable("uCommerce_CategoryProperty");

                entity.HasIndex(e => e.CategoryId);

                entity.HasIndex(e => e.CultureCode);

                entity.HasIndex(e => e.DefinitionFieldId);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_CategoryProperty_Guid")
                    .IsUnique();

                entity.HasIndex(e => new {e.CategoryId, e.CultureCode, e.DefinitionFieldId})
                    .HasName("UX_uCommerce_CategoryProperty_CategoryId_CultureCode_DefinitionFieldId")
                    .IsUnique();

                entity.Property(e => e.CultureCode).HasMaxLength(60);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Value).IsRequired();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.UCommerceCategoryProperty)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_CategoryProperty_uCommerce_Category");

                entity.HasOne(d => d.DefinitionField)
                    .WithMany(p => p.UCommerceCategoryProperty)
                    .HasForeignKey(d => d.DefinitionFieldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_CategoryProperty_uCommerce_DefinitionField");
            });

            modelBuilder.Entity<UCommerceCategoryTarget>(entity =>
            {
                entity.HasKey(e => e.CategoryTargetId);

                entity.ToTable("uCommerce_CategoryTarget");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_CategoryTarget_Guid")
                    .IsUnique();

                entity.Property(e => e.CategoryTargetId).ValueGeneratedNever();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.CategoryTarget)
                    .WithOne(p => p.UCommerceCategoryTarget)
                    .HasForeignKey<UCommerceCategoryTarget>(d => d.CategoryTargetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_CategoryTarget_uCommerce_CategoryTarget");
            });

            modelBuilder.Entity<UCommerceCountry>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .HasName("uCommerce_PK_Country");

                entity.ToTable("uCommerce_Country");

                entity.HasIndex(e => e.Culture);

                entity.HasIndex(e => e.Deleted);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_Country_Guid")
                    .IsUnique();

                entity.Property(e => e.Culture)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<UCommerceCurrency>(entity =>
            {
                entity.HasKey(e => e.CurrencyId)
                    .HasName("uCommerce_PK_Currency");

                entity.ToTable("uCommerce_Currency");

                entity.HasIndex(e => e.Deleted);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_Currency_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.Isocode);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Isocode)
                    .IsRequired()
                    .HasColumnName("ISOCode")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UCommerceCurrencyExchangeRate>(entity =>
            {
                entity.HasKey(e => e.CurrencyExchangeRateId);

                entity.ToTable("uCommerce_CurrencyExchangeRate");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_CurrencyExchangeRate_Guid")
                    .IsUnique();

                entity.HasIndex(e => new {e.FromCurrencyId, e.ToCurrencyId})
                    .HasName("UX_uCommerce_CurrencyExchangeRate_FromCurrencyId")
                    .IsUnique();

                entity.HasIndex(e => new {e.ToCurrencyId, e.FromCurrencyId})
                    .HasName("UX_uCommerce_CurrencyExchangeRate_ToCurrencyId")
                    .IsUnique();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Rate).HasColumnType("decimal(19, 9)");

                entity.HasOne(d => d.FromCurrency)
                    .WithMany(p => p.UCommerceCurrencyExchangeRateFromCurrency)
                    .HasForeignKey(d => d.FromCurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_CurrencyExchangeRate_FromCurrencyId");

                entity.HasOne(d => d.ToCurrency)
                    .WithMany(p => p.UCommerceCurrencyExchangeRateToCurrency)
                    .HasForeignKey(d => d.ToCurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_CurrencyExchangeRate_ToCurrencyId");
            });

            modelBuilder.Entity<UCommerceCustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("uCommerce_PK_Customer");

                entity.ToTable("uCommerce_Customer");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_Customer_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.MemberId);

                entity.Property(e => e.EmailAddress).HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.MemberId).HasMaxLength(255);

                entity.Property(e => e.MobilePhoneNumber).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<UCommerceDataType>(entity =>
            {
                entity.HasKey(e => e.DataTypeId)
                    .HasName("uCommerce_PK_DataType");

                entity.ToTable("uCommerce_DataType");

                entity.HasIndex(e => e.BuiltIn);

                entity.HasIndex(e => e.Deleted);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_DataType_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.Nullable);

                entity.HasIndex(e => e.TypeName);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DefinitionName)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ValidationExpression)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.HasOne(d => d.Definition)
                    .WithMany(p => p.UCommerceDataType)
                    .HasForeignKey(d => d.DefinitionId)
                    .HasConstraintName("FK__uCommerce__Defin__0C70CFB4");
            });

            modelBuilder.Entity<UCommerceDataTypeEnum>(entity =>
            {
                entity.HasKey(e => e.DataTypeEnumId)
                    .HasName("uCommerce_PK_DataTypeEnum");

                entity.ToTable("uCommerce_DataTypeEnum");

                entity.HasIndex(e => e.DataTypeId);

                entity.HasIndex(e => e.Deleted);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_DataTypeEnum_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.SortOrder);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(1024);

                entity.HasOne(d => d.DataType)
                    .WithMany(p => p.UCommerceDataTypeEnum)
                    .HasForeignKey(d => d.DataTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_DataTypeEnum_DataType");
            });

            modelBuilder.Entity<UCommerceDataTypeEnumDescription>(entity =>
            {
                entity.HasKey(e => e.DataTypeEnumDescriptionId)
                    .HasName("uCommerce_PK_DataTypeEnumDescription");

                entity.ToTable("uCommerce_DataTypeEnumDescription");

                entity.HasIndex(e => e.CultureCode);

                entity.HasIndex(e => e.DataTypeEnumId);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_DataTypeEnumDescription_Guid")
                    .IsUnique();

                entity.Property(e => e.CultureCode)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.DataTypeEnum)
                    .WithMany(p => p.UCommerceDataTypeEnumDescription)
                    .HasForeignKey(d => d.DataTypeEnumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_DataTypeEnumDescription_DataTypeEnum");
            });

            modelBuilder.Entity<UCommerceDefinition>(entity =>
            {
                entity.HasKey(e => e.DefinitionId)
                    .HasName("PK_uCommerceDefinition");

                entity.ToTable("uCommerce_Definition");

                entity.HasIndex(e => e.BuiltIn);

                entity.HasIndex(e => e.DefinitionTypeId);

                entity.HasIndex(e => e.Deleted);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_Definition_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.SortOrder);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.HasOne(d => d.DefinitionType)
                    .WithMany(p => p.UCommerceDefinition)
                    .HasForeignKey(d => d.DefinitionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_Definition_uCommerce_DefinitionType");
            });

            modelBuilder.Entity<UCommerceDefinitionField>(entity =>
            {
                entity.HasKey(e => e.DefinitionFieldId)
                    .HasName("PK_DefinitionField");

                entity.ToTable("uCommerce_DefinitionField");

                entity.HasIndex(e => e.BuiltIn);

                entity.HasIndex(e => e.DataTypeId);

                entity.HasIndex(e => e.DefinitionId);

                entity.HasIndex(e => e.Deleted);

                entity.HasIndex(e => e.DisplayOnSite);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_DefinitionField_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.Multilingual);

                entity.HasIndex(e => e.RenderInEditor);

                entity.HasIndex(e => e.Searchable);

                entity.HasIndex(e => e.SortOrder);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.HasOne(d => d.DataType)
                    .WithMany(p => p.UCommerceDefinitionField)
                    .HasForeignKey(d => d.DataTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_DefinitionField_uCommerce_DataType");

                entity.HasOne(d => d.Definition)
                    .WithMany(p => p.UCommerceDefinitionField)
                    .HasForeignKey(d => d.DefinitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_DefinitionField_uCommerce_Definition");
            });

            modelBuilder.Entity<UCommerceDefinitionFieldDescription>(entity =>
            {
                entity.HasKey(e => e.DefinitionFieldDescriptionId)
                    .HasName("PK_DefinitionFieldDescription");

                entity.ToTable("uCommerce_DefinitionFieldDescription");

                entity.HasIndex(e => e.CultureCode);

                entity.HasIndex(e => e.DefinitionFieldId);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_DefinitionFieldDescription_Guid")
                    .IsUnique();

                entity.Property(e => e.CultureCode)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.DefinitionField)
                    .WithMany(p => p.UCommerceDefinitionFieldDescription)
                    .HasForeignKey(d => d.DefinitionFieldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_DefinitionFieldDescription_uCommerce_DefinitionField");
            });

            modelBuilder.Entity<UCommerceDefinitionRelation>(entity =>
            {
                entity.HasKey(e => e.DefinitionRelationId);

                entity.ToTable("uCommerce_DefinitionRelation");

                entity.HasIndex(e => e.DefinitionId);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_DefinitionRelation_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.ParentDefinitionId);

                entity.HasIndex(e => e.SortOrder);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");
            });

            modelBuilder.Entity<UCommerceDefinitionType>(entity =>
            {
                entity.HasKey(e => e.DefinitionTypeId);

                entity.ToTable("uCommerce_DefinitionType");

                entity.HasIndex(e => e.Deleted);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_DefinitionType_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.SortOrder);

                entity.Property(e => e.DefinitionTypeId).ValueGeneratedNever();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(512);
            });

            modelBuilder.Entity<UCommerceDefinitionTypeDescription>(entity =>
            {
                entity.HasKey(e => e.DefinitionTypeDescriptionId)
                    .HasName("PK_DefinitionTypeDescription");

                entity.ToTable("uCommerce_DefinitionTypeDescription");

                entity.HasIndex(e => e.CultureCode);

                entity.HasIndex(e => e.DefinitionTypeId);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_DefinitionTypeDescription_Guid")
                    .IsUnique();

                entity.Property(e => e.CultureCode)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.DefinitionType)
                    .WithMany(p => p.UCommerceDefinitionTypeDescription)
                    .HasForeignKey(d => d.DefinitionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DefinitionTypeDescription_uCommerce_DefinitionType");
            });

            modelBuilder.Entity<UCommerceDiscount>(entity =>
            {
                entity.HasKey(e => e.DiscountId);

                entity.ToTable("uCommerce_Discount");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_Discount_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.OrderId);

                entity.Property(e => e.AmountOffTotal).HasColumnType("money");

                entity.Property(e => e.CampaignItemName).HasMaxLength(512);

                entity.Property(e => e.CampaignName).HasMaxLength(512);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.UCommerceDiscount)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_Discount_uCommerce_PurchaseOrder");
            });

            modelBuilder.Entity<UCommerceDiscountSpecificOrderLineAward>(entity =>
            {
                entity.HasKey(e => e.DiscountSpecificOrderLineAwardId)
                    .HasName("PK_DiscountSpecificOrderLineAward");

                entity.ToTable("uCommerce_DiscountSpecificOrderLineAward");

                entity.HasIndex(e => e.AmountType);

                entity.HasIndex(e => e.DiscountTarget);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_DiscountSpecificOrderLineAward_Guid")
                    .IsUnique();

                entity.Property(e => e.DiscountSpecificOrderLineAwardId).ValueGeneratedNever();

                entity.Property(e => e.AmountOff).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Sku).HasMaxLength(255);

                entity.Property(e => e.VariantSku).HasMaxLength(255);
            });

            modelBuilder.Entity<UCommerceDynamicOrderPropertyTarget>(entity =>
            {
                entity.HasKey(e => e.DynamicOrderPropertyTargetId);

                entity.ToTable("uCommerce_DynamicOrderPropertyTarget");

                entity.HasIndex(e => e.CompareMode);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_DynamicOrderPropertyTarget_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.Key);

                entity.HasIndex(e => e.TargetOrderLine);

                entity.Property(e => e.DynamicOrderPropertyTargetId).ValueGeneratedNever();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Value).IsRequired();
            });

            modelBuilder.Entity<UCommerceEmailContent>(entity =>
            {
                entity.HasKey(e => e.EmailContentId)
                    .HasName("uCommerce_PK_EmailContent");

                entity.ToTable("uCommerce_EmailContent");

                entity.HasIndex(e => e.ContentId);

                entity.HasIndex(e => e.CultureCode);

                entity.HasIndex(e => e.EmailProfileId);

                entity.HasIndex(e => e.EmailTypeId);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_EmailContent_Guid")
                    .IsUnique();

                entity.Property(e => e.ContentId).HasMaxLength(255);

                entity.Property(e => e.CultureCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Subject).HasColumnType("ntext");

                entity.HasOne(d => d.EmailProfile)
                    .WithMany(p => p.UCommerceEmailContent)
                    .HasForeignKey(d => d.EmailProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_EmailContent_EmailProfile");

                entity.HasOne(d => d.EmailType)
                    .WithMany(p => p.UCommerceEmailContent)
                    .HasForeignKey(d => d.EmailTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_EmailContent_EmailType");
            });

            modelBuilder.Entity<UCommerceEmailParameter>(entity =>
            {
                entity.HasKey(e => e.EmailParameterId)
                    .HasName("uCommerce_PK_EmailParameter");

                entity.ToTable("uCommerce_EmailParameter");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_EmailParameter_Guid")
                    .IsUnique();

                entity.Property(e => e.GlobalResourceKey)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.QueryStringKey)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UCommerceEmailProfile>(entity =>
            {
                entity.HasKey(e => e.EmailProfileId)
                    .HasName("uCommerce_PK_EmailProfile");

                entity.ToTable("uCommerce_EmailProfile");

                entity.HasIndex(e => e.Deleted);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_EmailProfile_Guid")
                    .IsUnique();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<UCommerceEmailProfileInformation>(entity =>
            {
                entity.HasKey(e => e.EmailProfileInformationId)
                    .HasName("uCommerce_PK_EmailProfileInformation");

                entity.ToTable("uCommerce_EmailProfileInformation");

                entity.HasIndex(e => e.EmailProfileId);

                entity.HasIndex(e => e.EmailTypeId);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_EmailProfileInformation_Guid")
                    .IsUnique();

                entity.Property(e => e.BccAddress).HasMaxLength(512);

                entity.Property(e => e.CcAddress).HasMaxLength(512);

                entity.Property(e => e.FromAddress)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.FromName)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.EmailProfile)
                    .WithMany(p => p.UCommerceEmailProfileInformation)
                    .HasForeignKey(d => d.EmailProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_EmailProfileInformation_uCommerce_EmailProfile");

                entity.HasOne(d => d.EmailType)
                    .WithMany(p => p.UCommerceEmailProfileInformation)
                    .HasForeignKey(d => d.EmailTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_EmailProfileInformation_uCommerce_EmailType");
            });

            modelBuilder.Entity<UCommerceEmailType>(entity =>
            {
                entity.HasKey(e => e.EmailTypeId)
                    .HasName("uCommerce_PK_EmailType");

                entity.ToTable("uCommerce_EmailType");

                entity.HasIndex(e => e.Deleted);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_EmailType_Guid")
                    .IsUnique();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<UCommerceEmailTypeParameter>(entity =>
            {
                entity.HasKey(e => new {e.EmailTypeId, e.EmailParameterId})
                    .HasName("uCommerce_PK_EmailTypeParameter");

                entity.ToTable("uCommerce_EmailTypeParameter");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_EmailTypeParameter_Guid")
                    .IsUnique();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.EmailParameter)
                    .WithMany(p => p.UCommerceEmailTypeParameter)
                    .HasForeignKey(d => d.EmailParameterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_EmailTypeParameter_EmailParameter");

                entity.HasOne(d => d.EmailType)
                    .WithMany(p => p.UCommerceEmailTypeParameter)
                    .HasForeignKey(d => d.EmailTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_EmailTypeParameter_EmailType");
            });

            modelBuilder.Entity<UCommerceEntityProperty>(entity =>
            {
                entity.HasKey(e => e.EntityPropertyId);

                entity.ToTable("uCommerce_EntityProperty");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_EntityProperty_Guid")
                    .IsUnique();

                entity.Property(e => e.CultureCode).HasMaxLength(60);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Value).IsRequired();

                entity.HasOne(d => d.DefinitionField)
                    .WithMany(p => p.UCommerceEntityProperty)
                    .HasForeignKey(d => d.DefinitionFieldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__uCommerce__Defin__0F4D3C5F");
            });

            modelBuilder.Entity<UCommerceEntityUi>(entity =>
            {
                entity.HasKey(e => e.EntityUiId)
                    .HasName("PK_EntityUi");

                entity.ToTable("uCommerce_EntityUi");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_EntityUi_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.SortOrder);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.VirtualPathUi).HasMaxLength(512);
            });

            modelBuilder.Entity<UCommerceEntityUiDescription>(entity =>
            {
                entity.HasKey(e => e.EntityUiDescriptionId);

                entity.ToTable("uCommerce_EntityUiDescription");

                entity.HasIndex(e => e.CultureCode);

                entity.HasIndex(e => e.EntityUiId);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_EntityUiDescription_Guid")
                    .IsUnique();

                entity.Property(e => e.CultureCode)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.EntityUi)
                    .WithMany(p => p.UCommerceEntityUiDescription)
                    .HasForeignKey(d => d.EntityUiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_EntityUiDescription_uCommerce_EntityUi");
            });

            modelBuilder.Entity<UCommerceFreeGiftAward>(entity =>
            {
                entity.HasKey(e => e.FreeGiftAwardId)
                    .HasName("PK__uCommerc__226D3CCDEA55A012");

                entity.ToTable("uCommerce_FreeGiftAward");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_FreeGiftAward_Guid")
                    .IsUnique();

                entity.Property(e => e.FreeGiftAwardId).ValueGeneratedNever();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Sku).IsRequired();
            });

            modelBuilder.Entity<UCommerceOrderAddress>(entity =>
            {
                entity.HasKey(e => e.OrderAddressId)
                    .HasName("uCommerce_PK_OrderAddress");

                entity.ToTable("uCommerce_OrderAddress");

                entity.HasIndex(e => e.CountryId);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_OrderAddress_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.OrderId);

                entity.Property(e => e.AddressName)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.Attention).HasMaxLength(512);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.CompanyName).HasMaxLength(512);

                entity.Property(e => e.EmailAddress).HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.Line1)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.Line2).HasMaxLength(512);

                entity.Property(e => e.MobilePhoneNumber).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(512);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.UCommerceOrderAddress)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_OrderAddress_Country");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.UCommerceOrderAddress)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_uCommerce_OrderAddress_uCommerce_PurchaseOrder");
            });

            modelBuilder.Entity<UCommerceOrderAmountTarget>(entity =>
            {
                entity.HasKey(e => e.OrderAmountTargetId)
                    .HasName("PK_OrderAmountTarget");

                entity.ToTable("uCommerce_OrderAmountTarget");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_OrderAmountTarget_Guid")
                    .IsUnique();

                entity.Property(e => e.OrderAmountTargetId).ValueGeneratedNever();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.MinAmount).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<UCommerceOrderLine>(entity =>
            {
                entity.HasKey(e => e.OrderLineId)
                    .HasName("uCommerce_PK_OrderLine");

                entity.ToTable("uCommerce_OrderLine");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_OrderLine_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.OrderId);

                entity.HasIndex(e => e.ShipmentId);

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Discount).HasColumnType("money");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.Total).HasColumnType("money");

                entity.Property(e => e.UnitDiscount).HasColumnType("money");

                entity.Property(e => e.VariantSku).HasMaxLength(512);

                entity.Property(e => e.Vat)
                    .HasColumnName("VAT")
                    .HasColumnType("money");

                entity.Property(e => e.Vatrate)
                    .HasColumnName("VATRate")
                    .HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.UCommerceOrderLine)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_OrderLine_Order");

                entity.HasOne(d => d.Shipment)
                    .WithMany(p => p.UCommerceOrderLine)
                    .HasForeignKey(d => d.ShipmentId)
                    .HasConstraintName("FK_OrderLine_Shipment");
            });

            modelBuilder.Entity<UCommerceOrderLineDiscountRelation>(entity =>
            {
                entity.HasKey(e => e.OrderLineDiscountRelationId);

                entity.ToTable("uCommerce_OrderLineDiscountRelation");

                entity.HasIndex(e => e.DiscountId);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_OrderLineDiscountRelation_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.OrderLineId);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.UCommerceOrderLineDiscountRelation)
                    .HasForeignKey(d => d.DiscountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_OrderLineDiscountRelation_uCommerce_Discount");

                entity.HasOne(d => d.OrderLine)
                    .WithMany(p => p.UCommerceOrderLineDiscountRelation)
                    .HasForeignKey(d => d.OrderLineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_OrderLineDiscountRelation_uCommerce_OrderLine");
            });

            modelBuilder.Entity<UCommerceOrderNumberSerie>(entity =>
            {
                entity.HasKey(e => e.OrderNumberId)
                    .HasName("uCommerce_PK_OrderNumbers_1");

                entity.ToTable("uCommerce_OrderNumberSerie");

                entity.HasIndex(e => e.Deleted);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_OrderNumberSerie_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.OrderNumberName);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.OrderNumberName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Postfix).HasMaxLength(50);

                entity.Property(e => e.Prefix).HasMaxLength(50);
            });

            modelBuilder.Entity<UCommerceOrderProperty>(entity =>
            {
                entity.HasKey(e => e.OrderPropertyId);

                entity.ToTable("uCommerce_OrderProperty");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_OrderProperty_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.Key);

                entity.HasIndex(e => e.OrderId);

                entity.HasIndex(e => e.OrderLineId);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Value).IsRequired();

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.UCommerceOrderProperty)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_OrderProperty_uCommerce_PurchaseOrder");

                entity.HasOne(d => d.OrderLine)
                    .WithMany(p => p.UCommerceOrderProperty)
                    .HasForeignKey(d => d.OrderLineId)
                    .HasConstraintName("FK_uCommerce_OrderProperty_uCommerce_OrderLine");
            });

            modelBuilder.Entity<UCommerceOrderStatus>(entity =>
            {
                entity.HasKey(e => e.OrderStatusId)
                    .HasName("uCommerce_PK_OrderStatus");

                entity.ToTable("uCommerce_OrderStatus");

                entity.HasIndex(e => e.AllowOrderEdit);

                entity.HasIndex(e => e.AllowUpdate);

                entity.HasIndex(e => e.AlwaysAvailable);

                entity.HasIndex(e => e.ExternalId);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_OrderStatus_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.IncludeInAuditTrail);

                entity.HasIndex(e => e.Name);

                entity.HasIndex(e => e.NextOrderStatusId);

                entity.HasIndex(e => e.RenderChildren);

                entity.HasIndex(e => e.RenderInMenu);

                entity.HasIndex(e => e.Sort);

                entity.Property(e => e.AllowUpdate)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ExternalId).HasMaxLength(50);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.IncludeInAuditTrail)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pipeline).HasMaxLength(128);

                entity.Property(e => e.RenderInMenu)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.NextOrderStatus)
                    .WithMany(p => p.InverseNextOrderStatus)
                    .HasForeignKey(d => d.NextOrderStatusId)
                    .HasConstraintName("uCommerce_FK_OrderStatus_OrderStatus1");
            });

            modelBuilder.Entity<UCommerceOrderStatusAudit>(entity =>
            {
                entity.HasKey(e => e.OrderStatusAuditId)
                    .HasName("uCommerce_PK_OrderStatusAudit");

                entity.ToTable("uCommerce_OrderStatusAudit");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_OrderStatusAudit_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.NewOrderStatusId);

                entity.HasIndex(e => e.OrderId);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.NewOrderStatus)
                    .WithMany(p => p.UCommerceOrderStatusAudit)
                    .HasForeignKey(d => d.NewOrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_OrderStatusAudit_OrderStatus");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.UCommerceOrderStatusAudit)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_OrderStatusAudit_PurchaseOrder");
            });

            modelBuilder.Entity<UCommercePayment>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("uCommerce_PK_Payment");

                entity.ToTable("uCommerce_Payment");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_Payment_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.PaymentMethodId);

                entity.HasIndex(e => e.PaymentMethodName);

                entity.HasIndex(e => e.PaymentStatusId);

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Fee).HasColumnType("money");

                entity.Property(e => e.FeePercentage).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.FeeTotal)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GrossAmount).HasColumnType("money");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.PaymentMethodName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Tax).HasColumnType("money");

                entity.Property(e => e.TaxRate).HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.UCommercePayment)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_Payment_Order");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.UCommercePayment)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_Payment_PaymentMethod");

                entity.HasOne(d => d.PaymentStatus)
                    .WithMany(p => p.UCommercePayment)
                    .HasForeignKey(d => d.PaymentStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_Payment_PaymentStatus");
            });

            modelBuilder.Entity<UCommercePaymentMethod>(entity =>
            {
                entity.HasKey(e => e.PaymentMethodId)
                    .HasName("uCommerce_PK_PaymentMethod");

                entity.ToTable("uCommerce_PaymentMethod");

                entity.HasIndex(e => e.DefinitionId);

                entity.HasIndex(e => e.Deleted);

                entity.HasIndex(e => e.Enabled);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_PaymentMethod_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.Name);

                entity.Property(e => e.Enabled)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FeePercent).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.ImageMediaId).HasMaxLength(255);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PaymentMethodServiceName).HasMaxLength(512);

                entity.Property(e => e.Pipeline).HasMaxLength(128);

                entity.HasOne(d => d.Definition)
                    .WithMany(p => p.UCommercePaymentMethod)
                    .HasForeignKey(d => d.DefinitionId)
                    .HasConstraintName("FK__uCommerce__Defin__4AA30C57");
            });

            modelBuilder.Entity<UCommercePaymentMethodCountry>(entity =>
            {
                entity.HasKey(e => new {e.PaymentMethodId, e.CountryId})
                    .HasName("uCommerce_PK_PaymentMethodCountry");

                entity.ToTable("uCommerce_PaymentMethodCountry");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_PaymentMethodCountry_Guid")
                    .IsUnique();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.UCommercePaymentMethodCountry)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_PaymentMethodCountry_Country");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.UCommercePaymentMethodCountry)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_PaymentMethodCountry_PaymentMethod");
            });

            modelBuilder.Entity<UCommercePaymentMethodDescription>(entity =>
            {
                entity.HasKey(e => e.PaymentMethodDescriptionId)
                    .HasName("uCommerce_PK_PaymentMethodDescription");

                entity.ToTable("uCommerce_PaymentMethodDescription");

                entity.HasIndex(e => e.CultureCode);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_PaymentMethodDescription_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.PaymentMethodId);

                entity.Property(e => e.CultureCode)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.UCommercePaymentMethodDescription)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_PaymentMethodDescription_PaymentMethod");
            });

            modelBuilder.Entity<UCommercePaymentMethodFee>(entity =>
            {
                entity.HasKey(e => e.PaymentMethodFeeId)
                    .HasName("uCommerce_PK_PaymentMethodFee");

                entity.ToTable("uCommerce_PaymentMethodFee");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_PaymentMethodFee_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.PaymentMethodId);

                entity.HasIndex(e => e.PriceGroupId);

                entity.Property(e => e.Fee).HasColumnType("money");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.UCommercePaymentMethodFee)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_PaymentMethodFee_PaymentMethod");

                entity.HasOne(d => d.PriceGroup)
                    .WithMany(p => p.UCommercePaymentMethodFee)
                    .HasForeignKey(d => d.PriceGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_PaymentMethodFee_PriceGroup");
            });

            modelBuilder.Entity<UCommercePaymentMethodProperty>(entity =>
            {
                entity.HasKey(e => e.PaymentMethodPropertyId);

                entity.ToTable("uCommerce_PaymentMethodProperty");

                entity.HasIndex(e => e.CultureCode);

                entity.HasIndex(e => e.DefinitionFieldId);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_PaymentMethodProperty_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.PaymentMethodId);

                entity.HasIndex(e => new {e.PaymentMethodId, e.CultureCode, e.DefinitionFieldId})
                    .HasName("UX_uCommerce_PaymentMethodProperty_PaymentMethodId_CultureCode_DefinitionFieldId")
                    .IsUnique();

                entity.Property(e => e.CultureCode).HasMaxLength(60);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.DefinitionField)
                    .WithMany(p => p.UCommercePaymentMethodProperty)
                    .HasForeignKey(d => d.DefinitionFieldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_PaymentMethodProperty_uCommerce_DefinitionField");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.UCommercePaymentMethodProperty)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_PaymentMethodProperty_uCommerce_PaymentMethod");
            });

            modelBuilder.Entity<UCommercePaymentProperty>(entity =>
            {
                entity.HasKey(e => e.PaymentPropertyId);

                entity.ToTable("uCommerce_PaymentProperty");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_PaymentProperty_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.Key);

                entity.HasIndex(e => e.PaymentId);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Value).IsRequired();

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.UCommercePaymentProperty)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_PaymentProperty_uCommerce_Payment");
            });

            modelBuilder.Entity<UCommercePaymentStatus>(entity =>
            {
                entity.HasKey(e => e.PaymentStatusId)
                    .HasName("uCommerce_PK_PaymentStatus");

                entity.ToTable("uCommerce_PaymentStatus");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_PaymentStatus_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.Name);

                entity.Property(e => e.PaymentStatusId).ValueGeneratedNever();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UCommercePercentOffOrderLinesAward>(entity =>
            {
                entity.HasKey(e => e.PercentOffOrderLinesAwardId)
                    .HasName("PK_uCommerce_ProcentOffOrderLinesAward");

                entity.ToTable("uCommerce_PercentOffOrderLinesAward");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_PercentOffOrderLinesAward_Guid")
                    .IsUnique();

                entity.Property(e => e.PercentOffOrderLinesAwardId).ValueGeneratedNever();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.PercentOff).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<UCommercePercentOffOrderTotalAward>(entity =>
            {
                entity.HasKey(e => e.PercentOffOrderTotalAwardId)
                    .HasName("PK_PercentOffOrderTotalAward");

                entity.ToTable("uCommerce_PercentOffOrderTotalAward");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_PercentOffOrderTotalAward_Guid")
                    .IsUnique();

                entity.Property(e => e.PercentOffOrderTotalAwardId).ValueGeneratedNever();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.PercentOff).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<UCommercePercentOffShippingTotalAward>(entity =>
            {
                entity.HasKey(e => e.PercentOffShippingTotalAwardId)
                    .HasName("PK_uCommerce_PercentOffShippingAward");

                entity.ToTable("uCommerce_PercentOffShippingTotalAward");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_PercentOffShippingTotalAward_Guid")
                    .IsUnique();

                entity.Property(e => e.PercentOffShippingTotalAwardId).ValueGeneratedNever();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.PercentOff).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<UCommercePermission>(entity =>
            {
                entity.HasKey(e => e.PermissionId)
                    .HasName("uCommerce_PK_Permission");

                entity.ToTable("uCommerce_Permission");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_Permission_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.RoleId);

                entity.HasIndex(e => e.UserId);

                entity.HasIndex(e => new {e.UserId, e.RoleId})
                    .HasName("UX_uCommerce_Permission_UserId_RoleId")
                    .IsUnique();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UCommercePermission)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__uCommerce__RoleI__22951AFD");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UCommercePermission)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__uCommerce__UserI__21A0F6C4");
            });

            modelBuilder.Entity<UCommercePrice>(entity =>
            {
                entity.HasKey(e => e.PriceId)
                    .HasName("uCommerce_PK_Price");

                entity.ToTable("uCommerce_Price");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_Price_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.PriceGroupId);

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.PriceGroup)
                    .WithMany(p => p.UCommercePrice)
                    .HasForeignKey(d => d.PriceGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_PriceGroupPrice_PriceGroup");
            });

            modelBuilder.Entity<UCommercePriceGroup>(entity =>
            {
                entity.HasKey(e => e.PriceGroupId)
                    .HasName("uCommerce_PK_PriceGroup");

                entity.ToTable("uCommerce_PriceGroup");

                entity.HasIndex(e => e.CurrencyId);

                entity.HasIndex(e => e.Deleted);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_PriceGroup_Guid")
                    .IsUnique();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Vatrate)
                    .HasColumnName("VATRate")
                    .HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.UCommercePriceGroup)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_PriceGroup_Currency");
            });

            modelBuilder.Entity<UCommercePriceGroupTarget>(entity =>
            {
                entity.HasKey(e => e.PriceGroupTargetId)
                    .HasName("PK__uCommerc__CA0B8B2729D4A943");

                entity.ToTable("uCommerce_PriceGroupTarget");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_PriceGroupTarget_Guid")
                    .IsUnique();

                entity.Property(e => e.PriceGroupTargetId).ValueGeneratedNever();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.PriceGroupName).HasMaxLength(150);
            });

            modelBuilder.Entity<UCommerceProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("uCommerce_PK_Product");

                entity.ToTable("uCommerce_Product");

                entity.HasIndex(e => e.AllowOrdering);

                entity.HasIndex(e => e.DisplayOnSite);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_Product_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.ParentProductId);

                entity.HasIndex(e => e.ProductDefinitionId);

                entity.HasIndex(e => e.Rating);

                entity.HasIndex(e => e.Sku);

                entity.HasIndex(e => e.VariantSku);

                entity.HasIndex(e => new {e.Sku, e.VariantSku})
                    .HasName("UX_uCommerce_Product_Sku_VariantSku")
                    .IsUnique();

                entity.Property(e => e.AllowOrdering)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DisplayOnSite)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.Rating).HasDefaultValueSql("((0))");

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.VariantSku).HasMaxLength(30);

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.ParentProduct)
                    .WithMany(p => p.InverseParentProduct)
                    .HasForeignKey(d => d.ParentProductId)
                    .HasConstraintName("FK_uCommerce_Product_ParentProduct");

                entity.HasOne(d => d.ProductDefinition)
                    .WithMany(p => p.UCommerceProduct)
                    .HasForeignKey(d => d.ProductDefinitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_Product_ProductDefinition");
            });

            modelBuilder.Entity<UCommerceProductCatalog>(entity =>
            {
                entity.HasKey(e => e.ProductCatalogId)
                    .HasName("uCommerce_PK_Catalog");

                entity.ToTable("uCommerce_ProductCatalog");

                entity.HasIndex(e => e.Deleted);

                entity.HasIndex(e => e.DisplayOnWebSite);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ProductCatalog_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.LimitedAccess);

                entity.HasIndex(e => e.Name);

                entity.HasIndex(e => e.PriceGroupId);

                entity.HasIndex(e => e.ProductCatalogGroupId);

                entity.HasIndex(e => e.ShowPricesIncludingVat);

                entity.HasIndex(e => e.SortOrder);

                entity.HasIndex(e => new {e.Name, e.ProductCatalogGroupId})
                    .HasName("UX_uCommerce_ProductCatalog_Name_ProductCatalogGroupId")
                    .IsUnique()
                    .HasFilter("([Deleted]=(0))");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasDefaultValueSql("(N'(Unknown)')");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasDefaultValueSql("(N'(Unknown)')");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.ShowPricesIncludingVat)
                    .IsRequired()
                    .HasColumnName("ShowPricesIncludingVAT")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Definition)
                    .WithMany(p => p.UCommerceProductCatalog)
                    .HasForeignKey(d => d.DefinitionId)
                    .HasConstraintName("FK__uCommerce__Defin__113584D1");

                entity.HasOne(d => d.PriceGroup)
                    .WithMany(p => p.UCommerceProductCatalog)
                    .HasForeignKey(d => d.PriceGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_Catalog_PriceGroup");

                entity.HasOne(d => d.ProductCatalogGroup)
                    .WithMany(p => p.UCommerceProductCatalog)
                    .HasForeignKey(d => d.ProductCatalogGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_Catalog_CatalogGroup");
            });

            modelBuilder.Entity<UCommerceProductCatalogDescription>(entity =>
            {
                entity.HasKey(e => e.ProductCatalogDescriptionId)
                    .HasName("uCommerce_PK_ProductCatalogDescription");

                entity.ToTable("uCommerce_ProductCatalogDescription");

                entity.HasIndex(e => e.CultureCode);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ProductCatalogDescription_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.ProductCatalogId);

                entity.HasIndex(e => new {e.ProductCatalogId, e.CultureCode})
                    .HasName("UX_uCommerce_ProductCatalogDescription_ProductCatalogId_CultureCode")
                    .IsUnique();

                entity.Property(e => e.CultureCode)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.ProductCatalog)
                    .WithMany(p => p.UCommerceProductCatalogDescription)
                    .HasForeignKey(d => d.ProductCatalogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_ProductCatalogDescription_ProductCatalog");
            });

            modelBuilder.Entity<UCommerceProductCatalogGroup>(entity =>
            {
                entity.HasKey(e => e.ProductCatalogGroupId)
                    .HasName("uCommerce_PK_CatalogGroup");

                entity.ToTable("uCommerce_ProductCatalogGroup");

                entity.HasIndex(e => e.CreateCustomersAsMembers);

                entity.HasIndex(e => e.CurrencyId);

                entity.HasIndex(e => e.Deleted);

                entity.HasIndex(e => e.DomainId);

                entity.HasIndex(e => e.EmailProfileId);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ProductCatalogGroup_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.MemberGroupId);

                entity.HasIndex(e => e.MemberTypeId);

                entity.HasIndex(e => e.Name);

                entity.HasIndex(e => e.OrderNumberId);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.DomainId).HasMaxLength(255);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.MemberGroupId).HasMaxLength(255);

                entity.Property(e => e.MemberTypeId).HasMaxLength(255);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.UCommerceProductCatalogGroup)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_ProductCatalogGroup_Currency");

                entity.HasOne(d => d.Definition)
                    .WithMany(p => p.UCommerceProductCatalogGroup)
                    .HasForeignKey(d => d.DefinitionId)
                    .HasConstraintName("FK__uCommerce__Defin__10416098");

                entity.HasOne(d => d.EmailProfile)
                    .WithMany(p => p.UCommerceProductCatalogGroup)
                    .HasForeignKey(d => d.EmailProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_ProductCatalogGroup_EmailProfile");

                entity.HasOne(d => d.OrderNumber)
                    .WithMany(p => p.UCommerceProductCatalogGroup)
                    .HasForeignKey(d => d.OrderNumberId)
                    .HasConstraintName("uCommerce_FK_ProductCatalogGroup_OrderNumbers");
            });

            modelBuilder.Entity<UCommerceProductCatalogGroupCampaignRelation>(entity =>
            {
                entity.HasKey(e => e.ProductCatalogGroupCampaignRelationId)
                    .HasName("uCommerce_PK_ProductCatalogGroupCampaignRelation");

                entity.ToTable("uCommerce_ProductCatalogGroupCampaignRelation");

                entity.HasIndex(e => e.CampaignId);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ProductCatalogGroupCampaignRelation_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.ProductCatalogGroupId);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.UCommerceProductCatalogGroupCampaignRelation)
                    .HasForeignKey(d => d.CampaignId)
                    .HasConstraintName("FK__uCommerce__Campa__257187A8");

                entity.HasOne(d => d.ProductCatalogGroup)
                    .WithMany(p => p.UCommerceProductCatalogGroupCampaignRelation)
                    .HasForeignKey(d => d.ProductCatalogGroupId)
                    .HasConstraintName("FK__uCommerce__Produ__2665ABE1");
            });

            modelBuilder.Entity<UCommerceProductCatalogGroupPaymentMethodMap>(entity =>
            {
                entity.HasKey(e => new {e.ProductCatalogGroupId, e.PaymentMethodId})
                    .HasName("uCommerce_PK_ProductCatalogGroupPaymentMethodMap");

                entity.ToTable("uCommerce_ProductCatalogGroupPaymentMethodMap");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ProductCatalogGroupPaymentMethodMap_Guid")
                    .IsUnique();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.UCommerceProductCatalogGroupPaymentMethodMap)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_ProductCatalogGroupPaymentMethodMap_PaymentMethod");

                entity.HasOne(d => d.ProductCatalogGroup)
                    .WithMany(p => p.UCommerceProductCatalogGroupPaymentMethodMap)
                    .HasForeignKey(d => d.ProductCatalogGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_ProductCatalogGroupPaymentMethodMap_ProductCatalogGroup");
            });

            modelBuilder.Entity<UCommerceProductCatalogGroupShippingMethodMap>(entity =>
            {
                entity.HasKey(e => new {e.ProductCatalogGroupId, e.ShippingMethodId})
                    .HasName("uCommerce_PK_ProductCatalogGroupShippingMethodMap");

                entity.ToTable("uCommerce_ProductCatalogGroupShippingMethodMap");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ProductCatalogGroupShippingMethodMap_Guid")
                    .IsUnique();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.ProductCatalogGroup)
                    .WithMany(p => p.UCommerceProductCatalogGroupShippingMethodMap)
                    .HasForeignKey(d => d.ProductCatalogGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_ProductCatalogGroupShippingMethodMap_ProductCatalogGroup");

                entity.HasOne(d => d.ShippingMethod)
                    .WithMany(p => p.UCommerceProductCatalogGroupShippingMethodMap)
                    .HasForeignKey(d => d.ShippingMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_ProductCatalogGroupShippingMethodMap_ShippingMethod");
            });

            modelBuilder.Entity<UCommerceProductCatalogGroupTarget>(entity =>
            {
                entity.HasKey(e => e.ProductCatalogGroupTargetId);

                entity.ToTable("uCommerce_ProductCatalogGroupTarget");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ProductCatalogGroupTarget_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.Name);

                entity.Property(e => e.ProductCatalogGroupTargetId).ValueGeneratedNever();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<UCommerceProductCatalogPriceGroupRelation>(entity =>
            {
                entity.HasKey(e => e.ProductCatalogPriceGroupRelationId);

                entity.ToTable("uCommerce_ProductCatalogPriceGroupRelation");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ProductCatalogPriceGroupRelation_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.PriceGroupId);

                entity.HasIndex(e => e.ProductCatalogId);

                entity.HasIndex(e => e.SortOrder);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.PriceGroup)
                    .WithMany(p => p.UCommerceProductCatalogPriceGroupRelation)
                    .HasForeignKey(d => d.PriceGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_ProductCatalogPriceGroupRelation_uCommerce_PriceGroup");

                entity.HasOne(d => d.ProductCatalog)
                    .WithMany(p => p.UCommerceProductCatalogPriceGroupRelation)
                    .HasForeignKey(d => d.ProductCatalogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_ProductCatalogPriceGroupRelation_uCommerce_ProductCatalog");
            });

            modelBuilder.Entity<UCommerceProductCatalogTarget>(entity =>
            {
                entity.HasKey(e => e.ProductCatalogTargetId)
                    .HasName("PK_ProductCatalogTarget");

                entity.ToTable("uCommerce_ProductCatalogTarget");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ProductCatalogTarget_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.Name);

                entity.Property(e => e.ProductCatalogTargetId).ValueGeneratedNever();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.HasOne(d => d.ProductCatalogTarget)
                    .WithOne(p => p.UCommerceProductCatalogTarget)
                    .HasForeignKey<UCommerceProductCatalogTarget>(d => d.ProductCatalogTargetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_ProductCatalogTarget_uCommerce_Target");
            });

            modelBuilder.Entity<UCommerceProductDefinition>(entity =>
            {
                entity.HasKey(e => e.ProductDefinitionId)
                    .HasName("uCommerce_PK_ProductDefinition");

                entity.ToTable("uCommerce_ProductDefinition");

                entity.HasIndex(e => e.Deleted);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ProductDefinition_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.SortOrder);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(512);
            });

            modelBuilder.Entity<UCommerceProductDefinitionField>(entity =>
            {
                entity.HasKey(e => e.ProductDefinitionFieldId)
                    .HasName("uCommerce_PK_ProductDefinitionField");

                entity.ToTable("uCommerce_ProductDefinitionField");

                entity.HasIndex(e => e.DataTypeId);

                entity.HasIndex(e => e.Deleted);

                entity.HasIndex(e => e.DisplayOnSite);

                entity.HasIndex(e => e.Facet);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ProductDefinitionField_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.IsVariantProperty);

                entity.HasIndex(e => e.Multilingual);

                entity.HasIndex(e => e.ProductDefinitionId);

                entity.HasIndex(e => e.RenderInEditor);

                entity.HasIndex(e => e.Searchable);

                entity.HasIndex(e => e.SortOrder);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.HasOne(d => d.DataType)
                    .WithMany(p => p.UCommerceProductDefinitionField)
                    .HasForeignKey(d => d.DataTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_ProductDefinitionField_DataType");

                entity.HasOne(d => d.ProductDefinition)
                    .WithMany(p => p.UCommerceProductDefinitionField)
                    .HasForeignKey(d => d.ProductDefinitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_ProductDefinitionField_ProductDefinition");
            });

            modelBuilder.Entity<UCommerceProductDefinitionFieldDescription>(entity =>
            {
                entity.HasKey(e => e.ProductDefinitionFieldDescriptionId)
                    .HasName("uCommerce_PK_ProductDefinitionFieldDescription");

                entity.ToTable("uCommerce_ProductDefinitionFieldDescription");

                entity.HasIndex(e => e.CultureCode);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ProductDefinitionFieldDescription_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.ProductDefinitionFieldId);

                entity.HasIndex(e => new {e.CultureCode, e.ProductDefinitionFieldId})
                    .HasName("UX_uCommerce_ProductDefinitionFieldDescription_CultureCode_ProductDefinitionFieldId")
                    .IsUnique();

                entity.Property(e => e.CultureCode)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.ProductDefinitionField)
                    .WithMany(p => p.UCommerceProductDefinitionFieldDescription)
                    .HasForeignKey(d => d.ProductDefinitionFieldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_ProductDefinitionFieldDescription_ProductDefinitionField");
            });

            modelBuilder.Entity<UCommerceProductDefinitionRelation>(entity =>
            {
                entity.HasKey(e => e.ProductDefinitionRelationId);

                entity.ToTable("uCommerce_ProductDefinitionRelation");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ProductDefinitionRelation_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.ParentProductDefinitionId);

                entity.HasIndex(e => e.ProductDefinitionId);

                entity.HasIndex(e => e.SortOrder);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.ParentProductDefinition)
                    .WithMany(p => p.UCommerceProductDefinitionRelationParentProductDefinition)
                    .HasForeignKey(d => d.ParentProductDefinitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_ParentProductDefinitionId");

                entity.HasOne(d => d.ProductDefinition)
                    .WithMany(p => p.UCommerceProductDefinitionRelationProductDefinition)
                    .HasForeignKey(d => d.ProductDefinitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_ProductDefinitionId");
            });

            modelBuilder.Entity<UCommerceProductDescription>(entity =>
            {
                entity.HasKey(e => e.ProductDescriptionId)
                    .HasName("uCommerce_PK_ProductDescription");

                entity.ToTable("uCommerce_ProductDescription");

                entity.HasIndex(e => e.CultureCode);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ProductDescription_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.ProductId);

                entity.HasIndex(e => new {e.ProductId, e.CultureCode})
                    .HasName("UX_uCommerce_ProductDescription_ProductId_CultureCode")
                    .IsUnique();

                entity.Property(e => e.CultureCode)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.UCommerceProductDescription)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_ProductDescription_Product");
            });

            modelBuilder.Entity<UCommerceProductDescriptionProperty>(entity =>
            {
                entity.HasKey(e => e.ProductDescriptionPropertyId)
                    .HasName("uCommerce_PK_ProductDescriptionProperty");

                entity.ToTable("uCommerce_ProductDescriptionProperty");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ProductDescriptionProperty_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.ProductDefinitionFieldId);

                entity.HasIndex(e => e.ProductDescriptionId);

                entity.HasIndex(e => new {e.ProductDescriptionId, e.ProductDefinitionFieldId})
                    .HasName("UX_uCommerce_ProductDescriptionProperty_ProductDescriptionId_ProductDefinitionFieldId")
                    .IsUnique();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.ProductDefinitionField)
                    .WithMany(p => p.UCommerceProductDescriptionProperty)
                    .HasForeignKey(d => d.ProductDefinitionFieldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_ProductDescriptionProperty_ProductDefinitionField");

                entity.HasOne(d => d.ProductDescription)
                    .WithMany(p => p.UCommerceProductDescriptionProperty)
                    .HasForeignKey(d => d.ProductDescriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_ProductDescriptionProperty_ProductDescription");
            });

            modelBuilder.Entity<UCommerceProductPrice>(entity =>
            {
                entity.HasKey(e => e.ProductPriceId);

                entity.ToTable("uCommerce_ProductPrice");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ProductPrice_Guid")
                    .IsUnique();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.MinimumQuantity).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Price)
                    .WithMany(p => p.UCommerceProductPrice)
                    .HasForeignKey(d => d.PriceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__uCommerce__Price__15FA39EE");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.UCommerceProductPrice)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__uCommerce__Produ__16EE5E27");
            });

            modelBuilder.Entity<UCommerceProductProperty>(entity =>
            {
                entity.HasKey(e => e.ProductPropertyId)
                    .HasName("uCommerce_PK_ProductProperty");

                entity.ToTable("uCommerce_ProductProperty");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ProductProperty_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.ProductDefinitionFieldId);

                entity.HasIndex(e => e.ProductId);

                entity.HasIndex(e => new {e.ProductId, e.ProductDefinitionFieldId})
                    .HasName("UX_uCommerce_ProductProperty_ProductId_ProductDefinitionFieldId")
                    .IsUnique();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.ProductDefinitionField)
                    .WithMany(p => p.UCommerceProductProperty)
                    .HasForeignKey(d => d.ProductDefinitionFieldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_ProductProperty_ProductDefinitionField");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.UCommerceProductProperty)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_ProductProperty_Product");
            });

            modelBuilder.Entity<UCommerceProductRelation>(entity =>
            {
                entity.HasKey(e => e.ProductRelationId)
                    .HasName("PK_uCommerce_ProductRelation2");

                entity.ToTable("uCommerce_ProductRelation");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ProductRelation_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.ProductId);

                entity.HasIndex(e => e.ProductRelationTypeId);

                entity.HasIndex(e => e.RelatedProductId);

                entity.HasIndex(e => new {e.ProductId, e.RelatedProductId, e.ProductRelationTypeId})
                    .HasName("UX_uCommerce_ProductRelation_ProductId_RelatedProductId_ProductRelationTypeId")
                    .IsUnique();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.UCommerceProductRelationProduct)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_ProductRelation_uCommerce_Product2");

                entity.HasOne(d => d.ProductRelationType)
                    .WithMany(p => p.UCommerceProductRelation)
                    .HasForeignKey(d => d.ProductRelationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_ProductRelation_uCommerce_ProductRelationType");

                entity.HasOne(d => d.RelatedProduct)
                    .WithMany(p => p.UCommerceProductRelationRelatedProduct)
                    .HasForeignKey(d => d.RelatedProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_ProductRelation_uCommerce_Product3");
            });

            modelBuilder.Entity<UCommerceProductRelationType>(entity =>
            {
                entity.HasKey(e => e.ProductRelationTypeId)
                    .HasName("PK_uCommerce_ProductRelation");

                entity.ToTable("uCommerce_ProductRelationType");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ProductRelationType_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.Name);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<UCommerceProductReview>(entity =>
            {
                entity.HasKey(e => e.ProductReviewId);

                entity.ToTable("uCommerce_ProductReview");

                entity.HasIndex(e => e.CultureCode);

                entity.HasIndex(e => e.CustomerId);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ProductReview_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.ProductCatalogGroupId);

                entity.HasIndex(e => e.ProductId);

                entity.HasIndex(e => e.ProductReviewStatusId);

                entity.HasIndex(e => e.Rating);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CultureCode).HasMaxLength(60);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ReviewHeadline).HasMaxLength(512);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.UCommerceProductReview)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_uCommerce_ProductReview_uCommerce_Customer");

                entity.HasOne(d => d.ProductCatalogGroup)
                    .WithMany(p => p.UCommerceProductReview)
                    .HasForeignKey(d => d.ProductCatalogGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_ProductReview_uCommerce_ProductCatalogGroup");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.UCommerceProductReview)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_ProductReview_uCommerce_Product");

                entity.HasOne(d => d.ProductReviewStatus)
                    .WithMany(p => p.UCommerceProductReview)
                    .HasForeignKey(d => d.ProductReviewStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_ProductReview_uCommerce_ProductReviewStatus");
            });

            modelBuilder.Entity<UCommerceProductReviewComment>(entity =>
            {
                entity.HasKey(e => e.ProductReviewCommentId);

                entity.ToTable("uCommerce_ProductReviewComment");

                entity.HasIndex(e => e.CultureCode);

                entity.HasIndex(e => e.CustomerId);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ProductReviewComment_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.Helpful);

                entity.HasIndex(e => e.ProductReviewId);

                entity.HasIndex(e => e.ProductReviewStatusId);

                entity.HasIndex(e => e.Unhelpful);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CultureCode).HasMaxLength(60);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.UCommerceProductReviewComment)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_uCommerce_ProductReviewComment_uCommerce_Customer");

                entity.HasOne(d => d.ProductReview)
                    .WithMany(p => p.UCommerceProductReviewComment)
                    .HasForeignKey(d => d.ProductReviewId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_ProductReviewComment_uCommerce_ProductReview");

                entity.HasOne(d => d.ProductReviewStatus)
                    .WithMany(p => p.UCommerceProductReviewComment)
                    .HasForeignKey(d => d.ProductReviewStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_ProductReviewComment_uCommerce_ProductReviewStatus");
            });

            modelBuilder.Entity<UCommerceProductReviewStatus>(entity =>
            {
                entity.HasKey(e => e.ProductReviewStatusId);

                entity.ToTable("uCommerce_ProductReviewStatus");

                entity.HasIndex(e => e.Deleted);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ProductReviewStatus_Guid")
                    .IsUnique();

                entity.Property(e => e.ProductReviewStatusId).ValueGeneratedNever();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1024);
            });

            modelBuilder.Entity<UCommerceProductTarget>(entity =>
            {
                entity.HasKey(e => e.ProductTargetId);

                entity.ToTable("uCommerce_ProductTarget");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ProductTarget_Guid")
                    .IsUnique();

                entity.Property(e => e.ProductTargetId).ValueGeneratedNever();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.ProductTarget)
                    .WithOne(p => p.UCommerceProductTarget)
                    .HasForeignKey<UCommerceProductTarget>(d => d.ProductTargetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_ProductTarget_uCommerce_Target");
            });

            modelBuilder.Entity<UCommercePurchaseOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("uCommerce_PK_Order");

                entity.ToTable("uCommerce_PurchaseOrder");

                entity.HasIndex(e => e.BasketId);

                entity.HasIndex(e => e.BillingAddressId);

                entity.HasIndex(e => e.CompletedDate);

                entity.HasIndex(e => e.CreatedDate);

                entity.HasIndex(e => e.CurrencyId);

                entity.HasIndex(e => e.CustomerId);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_PurchaseOrder_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.OrderGuid);

                entity.HasIndex(e => e.OrderNumber);

                entity.HasIndex(e => e.OrderStatusId);

                entity.HasIndex(e => e.ProductCatalogGroupId);

                entity.Property(e => e.BasketId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CompletedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CultureCode).HasMaxLength(60);

                entity.Property(e => e.Discount).HasColumnType("money");

                entity.Property(e => e.DiscountTotal).HasColumnType("money");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Note).HasColumnType("ntext");

                entity.Property(e => e.OrderGuid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.OrderNumber).HasMaxLength(50);

                entity.Property(e => e.OrderTotal).HasColumnType("money");

                entity.Property(e => e.PaymentTotal).HasColumnType("money");

                entity.Property(e => e.ShippingTotal).HasColumnType("money");

                entity.Property(e => e.SubTotal).HasColumnType("money");

                entity.Property(e => e.TaxTotal).HasColumnType("money");

                entity.Property(e => e.Vat)
                    .HasColumnName("VAT")
                    .HasColumnType("money");

                entity.HasOne(d => d.BillingAddress)
                    .WithMany(p => p.UCommercePurchaseOrder)
                    .HasForeignKey(d => d.BillingAddressId)
                    .HasConstraintName("FK_uCommerce_PurchaseOrder_uCommerce_OrderAddress");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.UCommercePurchaseOrder)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_Order_Currency");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.UCommercePurchaseOrder)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("uCommerce_FK_Order_Customer");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.UCommercePurchaseOrder)
                    .HasForeignKey(d => d.OrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_Order_OrderStatus1");

                entity.HasOne(d => d.ProductCatalogGroup)
                    .WithMany(p => p.UCommercePurchaseOrder)
                    .HasForeignKey(d => d.ProductCatalogGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_Order_ProductCatalogGroup");
            });

            modelBuilder.Entity<UCommerceQuantityTarget>(entity =>
            {
                entity.HasKey(e => e.QuantityTargetId);

                entity.ToTable("uCommerce_QuantityTarget");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_QuantityTarget_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.TargetOrderLine);

                entity.Property(e => e.QuantityTargetId).ValueGeneratedNever();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");
            });

            modelBuilder.Entity<UCommerceRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("uCommerce_PK_Role");

                entity.ToTable("uCommerce_Role");

                entity.HasIndex(e => e.CultureCode);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_Role_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.Name);

                entity.HasIndex(e => e.ParentRoleId);

                entity.HasIndex(e => e.PriceGroupId);

                entity.HasIndex(e => e.ProductCatalogGroupId);

                entity.HasIndex(e => e.ProductCatalogId);

                entity.HasIndex(e => e.RoleType);

                entity.Property(e => e.CultureCode).HasMaxLength(10);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.ParentRole)
                    .WithMany(p => p.InverseParentRole)
                    .HasForeignKey(d => d.ParentRoleId)
                    .HasConstraintName("FK__uCommerce__Paren__1EC48A19");

                entity.HasOne(d => d.PriceGroup)
                    .WithMany(p => p.UCommerceRole)
                    .HasForeignKey(d => d.PriceGroupId)
                    .HasConstraintName("FK__uCommerce__Price__1DD065E0");

                entity.HasOne(d => d.ProductCatalogGroup)
                    .WithMany(p => p.UCommerceRole)
                    .HasForeignKey(d => d.ProductCatalogGroupId)
                    .HasConstraintName("FK__uCommerce__Produ__1BE81D6E");

                entity.HasOne(d => d.ProductCatalog)
                    .WithMany(p => p.UCommerceRole)
                    .HasForeignKey(d => d.ProductCatalogId)
                    .HasConstraintName("FK__uCommerce__Produ__1CDC41A7");
            });

            modelBuilder.Entity<UCommerceShipment>(entity =>
            {
                entity.HasKey(e => e.ShipmentId)
                    .HasName("uCommerce_PK_Shipping");

                entity.ToTable("uCommerce_Shipment");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_Shipment_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.OrderId);

                entity.HasIndex(e => e.ShipmentAddressId);

                entity.HasIndex(e => e.ShipmentName);

                entity.HasIndex(e => e.ShippingMethodId);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.ShipmentDiscount).HasColumnType("money");

                entity.Property(e => e.ShipmentName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.ShipmentPrice).HasColumnType("money");

                entity.Property(e => e.ShipmentTotal).HasColumnType("money");

                entity.Property(e => e.Tax).HasColumnType("money");

                entity.Property(e => e.TaxRate).HasColumnType("money");

                entity.Property(e => e.TrackAndTrace).HasMaxLength(512);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.UCommerceShipment)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_Shipment_PurchaseOrder");

                entity.HasOne(d => d.ShipmentAddress)
                    .WithMany(p => p.UCommerceShipment)
                    .HasForeignKey(d => d.ShipmentAddressId)
                    .HasConstraintName("FK_uCommerce_Shipment_uCommerce_OrderAddress");

                entity.HasOne(d => d.ShippingMethod)
                    .WithMany(p => p.UCommerceShipment)
                    .HasForeignKey(d => d.ShippingMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_Shipment_uCommerce_ShippingMethod");
            });

            modelBuilder.Entity<UCommerceShipmentDiscountRelation>(entity =>
            {
                entity.HasKey(e => e.ShipmentDiscountRelationId);

                entity.ToTable("uCommerce_ShipmentDiscountRelation");

                entity.HasIndex(e => e.DiscountId);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ShipmentDiscountRelation_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.ShipmentId);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.UCommerceShipmentDiscountRelation)
                    .HasForeignKey(d => d.DiscountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_ShipmentDiscountRelation_uCommerce_Discount");

                entity.HasOne(d => d.Shipment)
                    .WithMany(p => p.UCommerceShipmentDiscountRelation)
                    .HasForeignKey(d => d.ShipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_ShipmentDiscountRelation_uCommerce_Shipment");
            });

            modelBuilder.Entity<UCommerceShippingMethod>(entity =>
            {
                entity.HasKey(e => e.ShippingMethodId)
                    .HasName("uCommerce_PK_ShippingMethod");

                entity.ToTable("uCommerce_ShippingMethod");

                entity.HasIndex(e => e.Deleted);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ShippingMethod_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.Name);

                entity.HasIndex(e => e.PaymentMethodId);

                entity.HasIndex(e => e.ServiceName);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.ImageMediaId).HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.ServiceName).HasMaxLength(128);

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.UCommerceShippingMethod)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .HasConstraintName("uCommerce_FK_ShippingMethod_PaymentMethod");
            });

            modelBuilder.Entity<UCommerceShippingMethodCountry>(entity =>
            {
                entity.HasKey(e => new {e.ShippingMethodId, e.CountryId})
                    .HasName("uCommerce_PK_ShippingMethodCountry");

                entity.ToTable("uCommerce_ShippingMethodCountry");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ShippingMethodCountry_Guid")
                    .IsUnique();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.UCommerceShippingMethodCountry)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_ShippingMethodCountry_Country");

                entity.HasOne(d => d.ShippingMethod)
                    .WithMany(p => p.UCommerceShippingMethodCountry)
                    .HasForeignKey(d => d.ShippingMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_ShippingMethodCountry_ShippingMethod");
            });

            modelBuilder.Entity<UCommerceShippingMethodDescription>(entity =>
            {
                entity.HasKey(e => e.ShippingMethodDescriptionId)
                    .HasName("uCommerce_PK_ShippingMethodDescription");

                entity.ToTable("uCommerce_ShippingMethodDescription");

                entity.HasIndex(e => e.CultureCode);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ShippingMethodDescription_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.ShippingMethodId);

                entity.Property(e => e.CultureCode)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.DeliveryText).HasMaxLength(512);

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.ShippingMethod)
                    .WithMany(p => p.UCommerceShippingMethodDescription)
                    .HasForeignKey(d => d.ShippingMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_ShippingMethodDescription_ShippingMethod");
            });

            modelBuilder.Entity<UCommerceShippingMethodPaymentMethods>(entity =>
            {
                entity.HasKey(e => new {e.ShippingMethodId, e.PaymentMethodId})
                    .HasName("uCommerce_PK_ShippingMethodPaymentMethods");

                entity.ToTable("uCommerce_ShippingMethodPaymentMethods");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ShippingMethodPaymentMethods_Guid")
                    .IsUnique();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.UCommerceShippingMethodPaymentMethods)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_ShippingMethodPaymentMethods_PaymentMethod");

                entity.HasOne(d => d.ShippingMethod)
                    .WithMany(p => p.UCommerceShippingMethodPaymentMethods)
                    .HasForeignKey(d => d.ShippingMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_ShippingMethodPaymentMethods_ShippingMethod");
            });

            modelBuilder.Entity<UCommerceShippingMethodPrice>(entity =>
            {
                entity.HasKey(e => e.ShippingMethodPriceId)
                    .HasName("uCommerce_PK_ShippingMethodPrice");

                entity.ToTable("uCommerce_ShippingMethodPrice");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ShippingMethodPrice_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.PriceGroupId);

                entity.HasIndex(e => e.ShippingMethodId);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.PriceGroup)
                    .WithMany(p => p.UCommerceShippingMethodPrice)
                    .HasForeignKey(d => d.PriceGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_ShippingMethodPrice_PriceGroup");

                entity.HasOne(d => d.ShippingMethod)
                    .WithMany(p => p.UCommerceShippingMethodPrice)
                    .HasForeignKey(d => d.ShippingMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uCommerce_FK_ShippingMethodPrice_ShippingMethod");
            });

            modelBuilder.Entity<UCommerceShippingMethodsTarget>(entity =>
            {
                entity.HasKey(e => e.ShippingMethodsTargetId)
                    .HasName("PK__uCommerc__477C79799D9A0078");

                entity.ToTable("uCommerce_ShippingMethodsTarget");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_ShippingMethodsTarget_Guid")
                    .IsUnique();

                entity.Property(e => e.ShippingMethodsTargetId).ValueGeneratedNever();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");
            });

            modelBuilder.Entity<UCommerceSystemVersion>(entity =>
            {
                entity.HasKey(e => e.SystemVersionId)
                    .HasName("uCommerce_PK_SystemVersion");

                entity.ToTable("uCommerce_SystemVersion");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_SystemVersion_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.SchemaVersion);

                entity.Property(e => e.AssemblyVersion)
                    .IsRequired()
                    .HasDefaultValueSql("('0.0.0.00000')");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");
            });

            modelBuilder.Entity<UCommerceTarget>(entity =>
            {
                entity.HasKey(e => e.TargetId);

                entity.ToTable("uCommerce_Target");

                entity.HasIndex(e => e.CampaignItemId);

                entity.HasIndex(e => e.EnabledForApply);

                entity.HasIndex(e => e.EnabledForDisplay);

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_Target_Guid")
                    .IsUnique();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.CampaignItem)
                    .WithMany(p => p.UCommerceTarget)
                    .HasForeignKey(d => d.CampaignItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_Target_uCommerce_Target");
            });

            modelBuilder.Entity<UCommerceUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("uCommerce_PK_User");

                entity.ToTable("uCommerce_User");

                entity.HasIndex(e => e.ExternalId)
                    .HasName("UX_uCommerce_User_ExternalId")
                    .IsUnique();

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_User_Guid")
                    .IsUnique();

                entity.Property(e => e.ExternalId).HasMaxLength(255);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");
            });

            modelBuilder.Entity<UCommerceUserGroup>(entity =>
            {
                entity.HasKey(e => e.UserGroupId)
                    .HasName("PK__uCommerc__FA5A61C094E3DAF0");

                entity.ToTable("uCommerce_UserGroup");

                entity.HasIndex(e => e.ExternalId)
                    .HasName("UX_uCommerce_UserGroup_ExternalId")
                    .IsUnique();

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_UserGroup_Guid")
                    .IsUnique();

                entity.Property(e => e.ExternalId)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");
            });

            modelBuilder.Entity<UCommerceUserGroupPermission>(entity =>
            {
                entity.HasKey(e => e.PermissionId)
                    .HasName("PK__uCommerc__EFA6FB2F25AE3C37");

                entity.ToTable("uCommerce_UserGroupPermission");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_UserGroupPermission_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.RoleId);

                entity.HasIndex(e => e.UserGroupId);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UCommerceUserGroupPermission)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__uCommerce__RoleI__71BCD978");

                entity.HasOne(d => d.UserGroup)
                    .WithMany(p => p.UCommerceUserGroupPermission)
                    .HasForeignKey(d => d.UserGroupId)
                    .HasConstraintName("FK__uCommerce__UserG__70C8B53F");
            });

            modelBuilder.Entity<UCommerceUserWidgetSetting>(entity =>
            {
                entity.HasKey(e => e.UserWidgetSettingId)
                    .HasName("PK__uCommerc__2BA214F9137F488D");

                entity.ToTable("uCommerce_UserWidgetSetting");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_UserWidgetSetting_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UCommerceUserWidgetSetting)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__uCommerce__UserI__69279377");
            });

            modelBuilder.Entity<UCommerceUserWidgetSettingProperty>(entity =>
            {
                entity.HasKey(e => e.UserWidgetSettingPropertyId)
                    .HasName("PK__uCommerc__38B1BA11FB37380C");

                entity.ToTable("uCommerce_UserWidgetSettingProperty");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_UserWidgetSettingProperty_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.UserWidgetSettingId);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.UserWidgetSetting)
                    .WithMany(p => p.UCommerceUserWidgetSettingProperty)
                    .HasForeignKey(d => d.UserWidgetSettingId)
                    .HasConstraintName("FK__uCommerce__UserW__6C040022");
            });

            modelBuilder.Entity<UCommerceVoucherCode>(entity =>
            {
                entity.HasKey(e => e.VoucherCodeId)
                    .HasName("PK_uCommerce_VoucherCode_1");

                entity.ToTable("uCommerce_VoucherCode");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_VoucherCode_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.MaxUses);

                entity.HasIndex(e => e.NumberUsed);

                entity.HasIndex(e => e.TargetId);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Target)
                    .WithMany(p => p.UCommerceVoucherCode)
                    .HasForeignKey(d => d.TargetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_VoucherCode_uCommerce_VoucherCode");
            });

            modelBuilder.Entity<UCommerceVoucherTarget>(entity =>
            {
                entity.HasKey(e => e.VoucherTargetId)
                    .HasName("PK_uCommerce_SingleUseVoucher_1");

                entity.ToTable("uCommerce_VoucherTarget");

                entity.HasIndex(e => e.Guid)
                    .HasName("UX_uCommerce_VoucherTarget_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.Name);

                entity.Property(e => e.VoucherTargetId).ValueGeneratedNever();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.VoucherTarget)
                    .WithOne(p => p.UCommerceVoucherTarget)
                    .HasForeignKey<UCommerceVoucherTarget>(d => d.VoucherTargetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uCommerce_VoucherTarget_uCommerce_Target");
            });
            
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}