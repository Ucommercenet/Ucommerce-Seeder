using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Ucommerce.Seeder.Models
{
    public partial class UmbracoDbContext : DbContext
    {
        private readonly string _connectionString;
        private readonly bool _verbose;

        public UmbracoDbContext(string connectionString, bool verbose) : base()
        {
            _connectionString = connectionString;
            _verbose = verbose;
        }

        public UmbracoDbContext(DbContextOptions<UmbracoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CmsContentNu> CmsContentNu { get; set; }
        public virtual DbSet<CmsContentType> CmsContentType { get; set; }
        public virtual DbSet<CmsContentType2ContentType> CmsContentType2ContentType { get; set; }
        public virtual DbSet<CmsContentTypeAllowedContentType> CmsContentTypeAllowedContentType { get; set; }
        public virtual DbSet<CmsDictionary> CmsDictionary { get; set; }
        public virtual DbSet<CmsDocumentType> CmsDocumentType { get; set; }
        public virtual DbSet<CmsLanguageText> CmsLanguageText { get; set; }
        public virtual DbSet<CmsMacro> CmsMacro { get; set; }
        public virtual DbSet<CmsMacroProperty> CmsMacroProperty { get; set; }
        public virtual DbSet<CmsMember> CmsMember { get; set; }
        public virtual DbSet<CmsMember2MemberGroup> CmsMember2MemberGroup { get; set; }
        public virtual DbSet<CmsMemberType> CmsMemberType { get; set; }
        public virtual DbSet<CmsPropertyType> CmsPropertyType { get; set; }
        public virtual DbSet<CmsPropertyTypeGroup> CmsPropertyTypeGroup { get; set; }
        public virtual DbSet<CmsTagRelationship> CmsTagRelationship { get; set; }
        public virtual DbSet<CmsTags> CmsTags { get; set; }
        public virtual DbSet<CmsTemplate> CmsTemplate { get; set; }
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
        public virtual DbSet<UmbracoAccess> UmbracoAccess { get; set; }
        public virtual DbSet<UmbracoAccessRule> UmbracoAccessRule { get; set; }
        public virtual DbSet<UmbracoAudit> UmbracoAudit { get; set; }
        public virtual DbSet<UmbracoCacheInstruction> UmbracoCacheInstruction { get; set; }
        public virtual DbSet<UmbracoConsent> UmbracoConsent { get; set; }
        public virtual DbSet<UmbracoContent> UmbracoContent { get; set; }
        public virtual DbSet<UmbracoContentSchedule> UmbracoContentSchedule { get; set; }
        public virtual DbSet<UmbracoContentVersion> UmbracoContentVersion { get; set; }
        public virtual DbSet<UmbracoContentVersionCultureVariation> UmbracoContentVersionCultureVariation { get; set; }
        public virtual DbSet<UmbracoDataType> UmbracoDataType { get; set; }
        public virtual DbSet<UmbracoDocument> UmbracoDocument { get; set; }
        public virtual DbSet<UmbracoDocumentCultureVariation> UmbracoDocumentCultureVariation { get; set; }
        public virtual DbSet<UmbracoDocumentVersion> UmbracoDocumentVersion { get; set; }
        public virtual DbSet<UmbracoDomain> UmbracoDomain { get; set; }
        public virtual DbSet<UmbracoExternalLogin> UmbracoExternalLogin { get; set; }
        public virtual DbSet<UmbracoKeyValue> UmbracoKeyValue { get; set; }
        public virtual DbSet<UmbracoLanguage> UmbracoLanguage { get; set; }
        public virtual DbSet<UmbracoLock> UmbracoLock { get; set; }
        public virtual DbSet<UmbracoLog> UmbracoLog { get; set; }
        public virtual DbSet<UmbracoMediaVersion> UmbracoMediaVersion { get; set; }
        public virtual DbSet<UmbracoNode> UmbracoNode { get; set; }
        public virtual DbSet<UmbracoPropertyData> UmbracoPropertyData { get; set; }
        public virtual DbSet<UmbracoRedirectUrl> UmbracoRedirectUrl { get; set; }
        public virtual DbSet<UmbracoRelation> UmbracoRelation { get; set; }
        public virtual DbSet<UmbracoRelationType> UmbracoRelationType { get; set; }
        public virtual DbSet<UmbracoServer> UmbracoServer { get; set; }
        public virtual DbSet<UmbracoUser> UmbracoUser { get; set; }
        public virtual DbSet<UmbracoUser2NodeNotify> UmbracoUser2NodeNotify { get; set; }
        public virtual DbSet<UmbracoUser2UserGroup> UmbracoUser2UserGroup { get; set; }
        public virtual DbSet<UmbracoUserGroup> UmbracoUserGroup { get; set; }
        public virtual DbSet<UmbracoUserGroup2App> UmbracoUserGroup2App { get; set; }
        public virtual DbSet<UmbracoUserGroup2NodePermission> UmbracoUserGroup2NodePermission { get; set; }
        public virtual DbSet<UmbracoUserLogin> UmbracoUserLogin { get; set; }
        public virtual DbSet<UmbracoUserStartNode> UmbracoUserStartNode { get; set; }

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
            modelBuilder.Entity<CmsContentNu>(entity =>
            {
                entity.HasKey(e => new {e.NodeId, e.Published});

                entity.ToTable("cmsContentNu");

                entity.Property(e => e.NodeId).HasColumnName("nodeId");

                entity.Property(e => e.Published).HasColumnName("published");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data")
                    .HasColumnType("ntext");

                entity.Property(e => e.Rv).HasColumnName("rv");

                entity.HasOne(d => d.Node)
                    .WithMany(p => p.CmsContentNu)
                    .HasForeignKey(d => d.NodeId);
            });

            modelBuilder.Entity<CmsContentType>(entity =>
            {
                entity.HasKey(e => e.Pk);

                entity.ToTable("cmsContentType");

                entity.HasIndex(e => e.Icon);

                entity.HasIndex(e => e.NodeId)
                    .HasName("IX_cmsContentType")
                    .IsUnique();

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.Alias)
                    .HasColumnName("alias")
                    .HasMaxLength(255);

                entity.Property(e => e.AllowAtRoot)
                    .IsRequired()
                    .HasColumnName("allowAtRoot")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(1500);

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasMaxLength(255);

                entity.Property(e => e.IsContainer)
                    .IsRequired()
                    .HasColumnName("isContainer")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsElement)
                    .IsRequired()
                    .HasColumnName("isElement")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NodeId).HasColumnName("nodeId");

                entity.Property(e => e.Thumbnail)
                    .IsRequired()
                    .HasColumnName("thumbnail")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('folder.png')");

                entity.Property(e => e.Variations)
                    .HasColumnName("variations")
                    .HasDefaultValueSql("('1')");

                entity.HasOne(d => d.Node)
                    .WithOne(p => p.CmsContentType)
                    .HasForeignKey<CmsContentType>(d => d.NodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cmsContentType_umbracoNode_id");
            });

            modelBuilder.Entity<CmsContentType2ContentType>(entity =>
            {
                entity.HasKey(e => new {e.ParentContentTypeId, e.ChildContentTypeId});

                entity.ToTable("cmsContentType2ContentType");

                entity.Property(e => e.ParentContentTypeId).HasColumnName("parentContentTypeId");

                entity.Property(e => e.ChildContentTypeId).HasColumnName("childContentTypeId");

                entity.HasOne(d => d.ChildContentType)
                    .WithMany(p => p.CmsContentType2ContentTypeChildContentType)
                    .HasForeignKey(d => d.ChildContentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cmsContentType2ContentType_umbracoNode_child");

                entity.HasOne(d => d.ParentContentType)
                    .WithMany(p => p.CmsContentType2ContentTypeParentContentType)
                    .HasForeignKey(d => d.ParentContentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cmsContentType2ContentType_umbracoNode_parent");
            });

            modelBuilder.Entity<CmsContentTypeAllowedContentType>(entity =>
            {
                entity.HasKey(e => new {e.Id, e.AllowedId});

                entity.ToTable("cmsContentTypeAllowedContentType");

                entity.Property(e => e.SortOrder).HasDefaultValueSql("('0')");

                entity.HasOne(d => d.Allowed)
                    .WithMany(p => p.CmsContentTypeAllowedContentTypeAllowed)
                    .HasPrincipalKey(p => p.NodeId)
                    .HasForeignKey(d => d.AllowedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cmsContentTypeAllowedContentType_cmsContentType1");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.CmsContentTypeAllowedContentTypeIdNavigation)
                    .HasPrincipalKey(p => p.NodeId)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cmsContentTypeAllowedContentType_cmsContentType");
            });

            modelBuilder.Entity<CmsDictionary>(entity =>
            {
                entity.HasKey(e => e.Pk);

                entity.ToTable("cmsDictionary");

                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.HasIndex(e => e.Key);

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasColumnName("key");

                entity.Property(e => e.Parent).HasColumnName("parent");

                entity.HasOne(d => d.ParentNavigation)
                    .WithMany(p => p.InverseParentNavigation)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.Parent)
                    .HasConstraintName("FK_cmsDictionary_cmsDictionary_id");
            });

            modelBuilder.Entity<CmsDocumentType>(entity =>
            {
                entity.HasKey(e => new {e.ContentTypeNodeId, e.TemplateNodeId});

                entity.ToTable("cmsDocumentType");

                entity.Property(e => e.ContentTypeNodeId).HasColumnName("contentTypeNodeId");

                entity.Property(e => e.TemplateNodeId).HasColumnName("templateNodeId");

                entity.Property(e => e.IsDefault)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.HasOne(d => d.ContentTypeNode)
                    .WithMany(p => p.CmsDocumentType)
                    .HasForeignKey(d => d.ContentTypeNodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cmsDocumentType_umbracoNode_id");

                entity.HasOne(d => d.ContentTypeNodeNavigation)
                    .WithMany(p => p.CmsDocumentType)
                    .HasPrincipalKey(p => p.NodeId)
                    .HasForeignKey(d => d.ContentTypeNodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cmsDocumentType_cmsContentType_nodeId");

                entity.HasOne(d => d.TemplateNode)
                    .WithMany(p => p.CmsDocumentType)
                    .HasPrincipalKey(p => p.NodeId)
                    .HasForeignKey(d => d.TemplateNodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cmsDocumentType_cmsTemplate_nodeId");
            });

            modelBuilder.Entity<CmsLanguageText>(entity =>
            {
                entity.HasKey(e => e.Pk);

                entity.ToTable("cmsLanguageText");

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.LanguageId).HasColumnName("languageId");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasMaxLength(1000);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.CmsLanguageText)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cmsLanguageText_umbracoLanguage_id");

                entity.HasOne(d => d.Unique)
                    .WithMany(p => p.CmsLanguageText)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.UniqueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cmsLanguageText_cmsDictionary_id");
            });

            modelBuilder.Entity<CmsMacro>(entity =>
            {
                entity.ToTable("cmsMacro");

                entity.HasIndex(e => e.MacroAlias)
                    .HasName("IX_cmsMacroPropertyAlias")
                    .IsUnique();

                entity.HasIndex(e => e.UniqueId)
                    .HasName("IX_cmsMacro_UniqueId")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MacroAlias)
                    .IsRequired()
                    .HasColumnName("macroAlias")
                    .HasMaxLength(255);

                entity.Property(e => e.MacroCacheByPage)
                    .IsRequired()
                    .HasColumnName("macroCacheByPage")
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.MacroCachePersonalized)
                    .IsRequired()
                    .HasColumnName("macroCachePersonalized")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MacroDontRender)
                    .IsRequired()
                    .HasColumnName("macroDontRender")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MacroName)
                    .HasColumnName("macroName")
                    .HasMaxLength(255);

                entity.Property(e => e.MacroRefreshRate)
                    .HasColumnName("macroRefreshRate")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MacroSource)
                    .IsRequired()
                    .HasColumnName("macroSource")
                    .HasMaxLength(255);

                entity.Property(e => e.MacroType).HasColumnName("macroType");

                entity.Property(e => e.MacroUseInEditor)
                    .IsRequired()
                    .HasColumnName("macroUseInEditor")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UniqueId).HasColumnName("uniqueId");
            });

            modelBuilder.Entity<CmsMacroProperty>(entity =>
            {
                entity.ToTable("cmsMacroProperty");

                entity.HasIndex(e => e.UniquePropertyId)
                    .HasName("IX_cmsMacroProperty_UniquePropertyId")
                    .IsUnique();

                entity.HasIndex(e => new {e.Macro, e.MacroPropertyAlias})
                    .HasName("IX_cmsMacroProperty_Alias")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EditorAlias)
                    .IsRequired()
                    .HasColumnName("editorAlias")
                    .HasMaxLength(255);

                entity.Property(e => e.Macro).HasColumnName("macro");

                entity.Property(e => e.MacroPropertyAlias)
                    .IsRequired()
                    .HasColumnName("macroPropertyAlias")
                    .HasMaxLength(50);

                entity.Property(e => e.MacroPropertyName)
                    .IsRequired()
                    .HasColumnName("macroPropertyName")
                    .HasMaxLength(255);

                entity.Property(e => e.MacroPropertySortOrder)
                    .HasColumnName("macroPropertySortOrder")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UniquePropertyId).HasColumnName("uniquePropertyId");

                entity.HasOne(d => d.MacroNavigation)
                    .WithMany(p => p.CmsMacroProperty)
                    .HasForeignKey(d => d.Macro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cmsMacroProperty_cmsMacro_id");
            });

            modelBuilder.Entity<CmsMember>(entity =>
            {
                entity.HasKey(e => e.NodeId);

                entity.ToTable("cmsMember");

                entity.HasIndex(e => e.LoginName);

                entity.Property(e => e.NodeId)
                    .HasColumnName("nodeId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("('''')");

                entity.Property(e => e.LoginName)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("('''')");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("('''')");

                entity.HasOne(d => d.Node)
                    .WithOne(p => p.CmsMember)
                    .HasForeignKey<CmsMember>(d => d.NodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<CmsMember2MemberGroup>(entity =>
            {
                entity.HasKey(e => new {e.Member, e.MemberGroup});

                entity.ToTable("cmsMember2MemberGroup");

                entity.HasOne(d => d.MemberNavigation)
                    .WithMany(p => p.CmsMember2MemberGroup)
                    .HasForeignKey(d => d.Member)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cmsMember2MemberGroup_cmsMember_nodeId");

                entity.HasOne(d => d.MemberGroupNavigation)
                    .WithMany(p => p.CmsMember2MemberGroup)
                    .HasForeignKey(d => d.MemberGroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cmsMember2MemberGroup_umbracoNode_id");
            });

            modelBuilder.Entity<CmsMemberType>(entity =>
            {
                entity.HasKey(e => e.Pk);

                entity.ToTable("cmsMemberType");

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.IsSensitive)
                    .IsRequired()
                    .HasColumnName("isSensitive")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MemberCanEdit)
                    .IsRequired()
                    .HasColumnName("memberCanEdit")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PropertytypeId).HasColumnName("propertytypeId");

                entity.Property(e => e.ViewOnProfile)
                    .IsRequired()
                    .HasColumnName("viewOnProfile")
                    .HasDefaultValueSql("('0')");

                entity.HasOne(d => d.Node)
                    .WithMany(p => p.CmsMemberType)
                    .HasForeignKey(d => d.NodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cmsMemberType_umbracoNode_id");

                entity.HasOne(d => d.NodeNavigation)
                    .WithMany(p => p.CmsMemberType)
                    .HasPrincipalKey(p => p.NodeId)
                    .HasForeignKey(d => d.NodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cmsMemberType_cmsContentType_nodeId");
            });

            modelBuilder.Entity<CmsPropertyType>(entity =>
            {
                entity.ToTable("cmsPropertyType");

                entity.HasIndex(e => e.Alias)
                    .HasName("IX_cmsPropertyTypeAlias");

                entity.HasIndex(e => e.UniqueId)
                    .HasName("IX_cmsPropertyTypeUniqueID")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ContentTypeId).HasColumnName("contentTypeId");

                entity.Property(e => e.DataTypeId).HasColumnName("dataTypeId");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Mandatory)
                    .IsRequired()
                    .HasColumnName("mandatory")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.PropertyTypeGroupId).HasColumnName("propertyTypeGroupId");

                entity.Property(e => e.SortOrder)
                    .HasColumnName("sortOrder")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("UniqueID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ValidationRegExp)
                    .HasColumnName("validationRegExp")
                    .HasMaxLength(255);

                entity.Property(e => e.Variations)
                    .HasColumnName("variations")
                    .HasDefaultValueSql("('1')");

                entity.HasOne(d => d.ContentType)
                    .WithMany(p => p.CmsPropertyType)
                    .HasPrincipalKey(p => p.NodeId)
                    .HasForeignKey(d => d.ContentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cmsPropertyType_cmsContentType_nodeId");

                entity.HasOne(d => d.DataType)
                    .WithMany(p => p.CmsPropertyType)
                    .HasForeignKey(d => d.DataTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cmsPropertyType_umbracoDataType_nodeId");

                entity.HasOne(d => d.PropertyTypeGroup)
                    .WithMany(p => p.CmsPropertyType)
                    .HasForeignKey(d => d.PropertyTypeGroupId)
                    .HasConstraintName("FK_cmsPropertyType_cmsPropertyTypeGroup_id");
            });

            modelBuilder.Entity<CmsPropertyTypeGroup>(entity =>
            {
                entity.ToTable("cmsPropertyTypeGroup");

                entity.HasIndex(e => e.UniqueId)
                    .HasName("IX_cmsPropertyTypeGroupUniqueID")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ContenttypeNodeId).HasColumnName("contenttypeNodeId");

                entity.Property(e => e.Sortorder).HasColumnName("sortorder");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text")
                    .HasMaxLength(255);

                entity.Property(e => e.UniqueId)
                    .HasColumnName("uniqueID")
                    .HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.ContenttypeNode)
                    .WithMany(p => p.CmsPropertyTypeGroup)
                    .HasPrincipalKey(p => p.NodeId)
                    .HasForeignKey(d => d.ContenttypeNodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cmsPropertyTypeGroup_cmsContentType_nodeId");
            });

            modelBuilder.Entity<CmsTagRelationship>(entity =>
            {
                entity.HasKey(e => new {e.NodeId, e.PropertyTypeId, e.TagId});

                entity.ToTable("cmsTagRelationship");

                entity.Property(e => e.NodeId).HasColumnName("nodeId");

                entity.Property(e => e.PropertyTypeId).HasColumnName("propertyTypeId");

                entity.Property(e => e.TagId).HasColumnName("tagId");

                entity.HasOne(d => d.Node)
                    .WithMany(p => p.CmsTagRelationship)
                    .HasForeignKey(d => d.NodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cmsTagRelationship_cmsContent");

                entity.HasOne(d => d.PropertyType)
                    .WithMany(p => p.CmsTagRelationship)
                    .HasForeignKey(d => d.PropertyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cmsTagRelationship_cmsPropertyType");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.CmsTagRelationship)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cmsTagRelationship_cmsTags_id");
            });

            modelBuilder.Entity<CmsTags>(entity =>
            {
                entity.ToTable("cmsTags");

                entity.HasIndex(e => e.LanguageId)
                    .HasName("IX_cmsTags_LanguageId");

                entity.HasIndex(e => new {e.Group, e.Tag, e.LanguageId})
                    .HasName("IX_cmsTags")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Group)
                    .IsRequired()
                    .HasColumnName("group")
                    .HasMaxLength(100);

                entity.Property(e => e.LanguageId).HasColumnName("languageId");

                entity.Property(e => e.Tag)
                    .IsRequired()
                    .HasColumnName("tag")
                    .HasMaxLength(200);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.CmsTags)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_cmsTags_umbracoLanguage_id");
            });

            modelBuilder.Entity<CmsTemplate>(entity =>
            {
                entity.HasKey(e => e.Pk);

                entity.ToTable("cmsTemplate");

                entity.HasIndex(e => e.NodeId)
                    .IsUnique();

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.Alias)
                    .HasColumnName("alias")
                    .HasMaxLength(100);

                entity.Property(e => e.NodeId).HasColumnName("nodeId");

                entity.HasOne(d => d.Node)
                    .WithOne(p => p.CmsTemplate)
                    .HasForeignKey<CmsTemplate>(d => d.NodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cmsTemplate_umbracoNode");
            });

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

            modelBuilder.Entity<UmbracoAccess>(entity =>
            {
                entity.ToTable("umbracoAccess");

                entity.HasIndex(e => e.NodeId)
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LoginNodeId).HasColumnName("loginNodeId");

                entity.Property(e => e.NoAccessNodeId).HasColumnName("noAccessNodeId");

                entity.Property(e => e.NodeId).HasColumnName("nodeId");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("updateDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.LoginNode)
                    .WithMany(p => p.UmbracoAccessLoginNode)
                    .HasForeignKey(d => d.LoginNodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_umbracoAccess_umbracoNode_id1");

                entity.HasOne(d => d.NoAccessNode)
                    .WithMany(p => p.UmbracoAccessNoAccessNode)
                    .HasForeignKey(d => d.NoAccessNodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_umbracoAccess_umbracoNode_id2");

                entity.HasOne(d => d.Node)
                    .WithOne(p => p.UmbracoAccessNode)
                    .HasForeignKey<UmbracoAccess>(d => d.NodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_umbracoAccess_umbracoNode_id");
            });

            modelBuilder.Entity<UmbracoAccessRule>(entity =>
            {
                entity.ToTable("umbracoAccessRule");

                entity.HasIndex(e => new {e.RuleValue, e.RuleType, e.AccessId})
                    .HasName("IX_umbracoAccessRule")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccessId).HasColumnName("accessId");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RuleType)
                    .IsRequired()
                    .HasColumnName("ruleType")
                    .HasMaxLength(255);

                entity.Property(e => e.RuleValue)
                    .IsRequired()
                    .HasColumnName("ruleValue")
                    .HasMaxLength(255);

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("updateDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Access)
                    .WithMany(p => p.UmbracoAccessRule)
                    .HasForeignKey(d => d.AccessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_umbracoAccessRule_umbracoAccess_id");
            });

            modelBuilder.Entity<UmbracoAudit>(entity =>
            {
                entity.ToTable("umbracoAudit");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AffectedDetails)
                    .HasColumnName("affectedDetails")
                    .HasMaxLength(1024);

                entity.Property(e => e.AffectedUserId).HasColumnName("affectedUserId");

                entity.Property(e => e.EventDateUtc)
                    .HasColumnName("eventDateUtc")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EventDetails)
                    .HasColumnName("eventDetails")
                    .HasMaxLength(1024);

                entity.Property(e => e.EventType)
                    .IsRequired()
                    .HasColumnName("eventType")
                    .HasMaxLength(256);

                entity.Property(e => e.PerformingDetails)
                    .HasColumnName("performingDetails")
                    .HasMaxLength(1024);

                entity.Property(e => e.PerformingIp)
                    .HasColumnName("performingIp")
                    .HasMaxLength(64);

                entity.Property(e => e.PerformingUserId).HasColumnName("performingUserId");
            });

            modelBuilder.Entity<UmbracoCacheInstruction>(entity =>
            {
                entity.ToTable("umbracoCacheInstruction");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InstructionCount)
                    .HasColumnName("instructionCount")
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.JsonInstruction)
                    .IsRequired()
                    .HasColumnName("jsonInstruction")
                    .HasColumnType("ntext");

                entity.Property(e => e.Originated)
                    .IsRequired()
                    .HasColumnName("originated")
                    .HasMaxLength(500);

                entity.Property(e => e.UtcStamp)
                    .HasColumnName("utcStamp")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<UmbracoConsent>(entity =>
            {
                entity.ToTable("umbracoConsent");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasColumnName("action")
                    .HasMaxLength(512);

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(255);

                entity.Property(e => e.Context)
                    .IsRequired()
                    .HasColumnName("context")
                    .HasMaxLength(128);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Current).HasColumnName("current");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasColumnName("source")
                    .HasMaxLength(512);

                entity.Property(e => e.State).HasColumnName("state");
            });

            modelBuilder.Entity<UmbracoContent>(entity =>
            {
                entity.HasKey(e => e.NodeId);

                entity.ToTable("umbracoContent");

                entity.Property(e => e.NodeId)
                    .HasColumnName("nodeId")
                    .ValueGeneratedNever();

                entity.Property(e => e.ContentTypeId).HasColumnName("contentTypeId");

                entity.HasOne(d => d.ContentType)
                    .WithMany(p => p.UmbracoContent)
                    .HasPrincipalKey(p => p.NodeId)
                    .HasForeignKey(d => d.ContentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_umbracoContent_cmsContentType_NodeId");

                entity.HasOne(d => d.Node)
                    .WithOne(p => p.UmbracoContent)
                    .HasForeignKey<UmbracoContent>(d => d.NodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_umbracoContent_umbracoNode_id");
            });

            modelBuilder.Entity<UmbracoContentSchedule>(entity =>
            {
                entity.ToTable("umbracoContentSchedule");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasColumnName("action")
                    .HasMaxLength(255);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.LanguageId).HasColumnName("languageId");

                entity.Property(e => e.NodeId).HasColumnName("nodeId");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.UmbracoContentSchedule)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_umbracoContentSchedule_umbracoLanguage_id");

                entity.HasOne(d => d.Node)
                    .WithMany(p => p.UmbracoContentSchedule)
                    .HasForeignKey(d => d.NodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<UmbracoContentVersion>(entity =>
            {
                entity.ToTable("umbracoContentVersion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Current).HasColumnName("current");

                entity.Property(e => e.NodeId).HasColumnName("nodeId");

                entity.Property(e => e.Text)
                    .HasColumnName("text")
                    .HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.VersionDate)
                    .HasColumnName("versionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Node)
                    .WithMany(p => p.UmbracoContentVersion)
                    .HasForeignKey(d => d.NodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UmbracoContentVersion)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_umbracoContentVersion_umbracoUser_id");
            });

            modelBuilder.Entity<UmbracoContentVersionCultureVariation>(entity =>
            {
                entity.ToTable("umbracoContentVersionCultureVariation");

                entity.HasIndex(e => e.LanguageId)
                    .HasName("IX_umbracoContentVersionCultureVariation_LanguageId");

                entity.HasIndex(e => new {e.VersionId, e.LanguageId})
                    .HasName("IX_umbracoContentVersionCultureVariation_VersionId")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AvailableUserId).HasColumnName("availableUserId");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.LanguageId).HasColumnName("languageId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.VersionId).HasColumnName("versionId");

                entity.HasOne(d => d.AvailableUser)
                    .WithMany(p => p.UmbracoContentVersionCultureVariation)
                    .HasForeignKey(d => d.AvailableUserId)
                    .HasConstraintName("FK_umbracoContentVersionCultureVariation_umbracoUser_id");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.UmbracoContentVersionCultureVariation)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_umbracoContentVersionCultureVariation_umbracoLanguage_id");

                entity.HasOne(d => d.Version)
                    .WithMany(p => p.UmbracoContentVersionCultureVariation)
                    .HasForeignKey(d => d.VersionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_umbracoContentVersionCultureVariation_umbracoContentVersion_id");
            });

            modelBuilder.Entity<UmbracoDataType>(entity =>
            {
                entity.HasKey(e => e.NodeId);

                entity.ToTable("umbracoDataType");

                entity.Property(e => e.NodeId)
                    .HasColumnName("nodeId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Config)
                    .HasColumnName("config")
                    .HasColumnType("ntext");

                entity.Property(e => e.DbType)
                    .IsRequired()
                    .HasColumnName("dbType")
                    .HasMaxLength(50);

                entity.Property(e => e.PropertyEditorAlias)
                    .IsRequired()
                    .HasColumnName("propertyEditorAlias")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Node)
                    .WithOne(p => p.UmbracoDataType)
                    .HasForeignKey<UmbracoDataType>(d => d.NodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_umbracoDataType_umbracoNode_id");
            });

            modelBuilder.Entity<UmbracoDocument>(entity =>
            {
                entity.HasKey(e => e.NodeId);

                entity.ToTable("umbracoDocument");

                entity.HasIndex(e => e.Published)
                    .HasName("IX_umbracoDocument_Published");

                entity.Property(e => e.NodeId)
                    .HasColumnName("nodeId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Edited).HasColumnName("edited");

                entity.Property(e => e.Published).HasColumnName("published");

                entity.HasOne(d => d.Node)
                    .WithOne(p => p.UmbracoDocument)
                    .HasForeignKey<UmbracoDocument>(d => d.NodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<UmbracoDocumentCultureVariation>(entity =>
            {
                entity.ToTable("umbracoDocumentCultureVariation");

                entity.HasIndex(e => e.LanguageId)
                    .HasName("IX_umbracoDocumentCultureVariation_LanguageId");

                entity.HasIndex(e => new {e.NodeId, e.LanguageId})
                    .HasName("IX_umbracoDocumentCultureVariation_NodeId")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Available).HasColumnName("available");

                entity.Property(e => e.Edited).HasColumnName("edited");

                entity.Property(e => e.LanguageId).HasColumnName("languageId");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.NodeId).HasColumnName("nodeId");

                entity.Property(e => e.Published).HasColumnName("published");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.UmbracoDocumentCultureVariation)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_umbracoDocumentCultureVariation_umbracoLanguage_id");

                entity.HasOne(d => d.Node)
                    .WithMany(p => p.UmbracoDocumentCultureVariation)
                    .HasForeignKey(d => d.NodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_umbracoDocumentCultureVariation_umbracoNode_id");
            });

            modelBuilder.Entity<UmbracoDocumentVersion>(entity =>
            {
                entity.ToTable("umbracoDocumentVersion");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Published).HasColumnName("published");

                entity.Property(e => e.TemplateId).HasColumnName("templateId");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.UmbracoDocumentVersion)
                    .HasForeignKey<UmbracoDocumentVersion>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.UmbracoDocumentVersion)
                    .HasPrincipalKey(p => p.NodeId)
                    .HasForeignKey(d => d.TemplateId)
                    .HasConstraintName("FK_umbracoDocumentVersion_cmsTemplate_nodeId");
            });

            modelBuilder.Entity<UmbracoDomain>(entity =>
            {
                entity.ToTable("umbracoDomain");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DomainDefaultLanguage).HasColumnName("domainDefaultLanguage");

                entity.Property(e => e.DomainName)
                    .IsRequired()
                    .HasColumnName("domainName")
                    .HasMaxLength(255);

                entity.Property(e => e.DomainRootStructureId).HasColumnName("domainRootStructureID");

                entity.HasOne(d => d.DomainRootStructure)
                    .WithMany(p => p.UmbracoDomain)
                    .HasForeignKey(d => d.DomainRootStructureId)
                    .HasConstraintName("FK_umbracoDomain_umbracoNode_id");
            });

            modelBuilder.Entity<UmbracoExternalLogin>(entity =>
            {
                entity.ToTable("umbracoExternalLogin");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LoginProvider)
                    .IsRequired()
                    .HasColumnName("loginProvider")
                    .HasMaxLength(4000);

                entity.Property(e => e.ProviderKey)
                    .IsRequired()
                    .HasColumnName("providerKey")
                    .HasMaxLength(4000);

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<UmbracoKeyValue>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.ToTable("umbracoKeyValue");

                entity.Property(e => e.Key)
                    .HasColumnName("key")
                    .HasMaxLength(256);

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<UmbracoLanguage>(entity =>
            {
                entity.ToTable("umbracoLanguage");

                entity.HasIndex(e => e.FallbackLanguageId);

                entity.HasIndex(e => e.LanguageIsocode)
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FallbackLanguageId).HasColumnName("fallbackLanguageId");

                entity.Property(e => e.IsDefaultVariantLang)
                    .IsRequired()
                    .HasColumnName("isDefaultVariantLang")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LanguageCultureName)
                    .HasColumnName("languageCultureName")
                    .HasMaxLength(100);

                entity.Property(e => e.LanguageIsocode)
                    .HasColumnName("languageISOCode")
                    .HasMaxLength(14);

                entity.Property(e => e.Mandatory)
                    .IsRequired()
                    .HasColumnName("mandatory")
                    .HasDefaultValueSql("('0')");

                entity.HasOne(d => d.FallbackLanguage)
                    .WithMany(p => p.InverseFallbackLanguage)
                    .HasForeignKey(d => d.FallbackLanguageId)
                    .HasConstraintName("FK_umbracoLanguage_umbracoLanguage_id");
            });

            modelBuilder.Entity<UmbracoLock>(entity =>
            {
                entity.ToTable("umbracoLock");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(64);

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<UmbracoLog>(entity =>
            {
                entity.ToTable("umbracoLog");

                entity.HasIndex(e => e.NodeId)
                    .HasName("IX_umbracoLog");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datestamp)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EntityType)
                    .HasColumnName("entityType")
                    .HasMaxLength(50);

                entity.Property(e => e.LogComment)
                    .HasColumnName("logComment")
                    .HasMaxLength(4000);

                entity.Property(e => e.LogHeader)
                    .IsRequired()
                    .HasColumnName("logHeader")
                    .HasMaxLength(50);

                entity.Property(e => e.Parameters)
                    .HasColumnName("parameters")
                    .HasMaxLength(500);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UmbracoLog)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_umbracoLog_umbracoUser_id");
            });

            modelBuilder.Entity<UmbracoMediaVersion>(entity =>
            {
                entity.ToTable("umbracoMediaVersion");

                entity.HasIndex(e => new {e.Id, e.Path})
                    .HasName("IX_umbracoMediaVersion")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Path)
                    .HasColumnName("path")
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.UmbracoMediaVersion)
                    .HasForeignKey<UmbracoMediaVersion>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<UmbracoNode>(entity =>
            {
                entity.ToTable("umbracoNode");

                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.NodeObjectType)
                    .HasName("IX_umbracoNode_ObjectType");

                entity.HasIndex(e => e.ParentId)
                    .HasName("IX_umbracoNode_ParentId");

                entity.HasIndex(e => e.Path)
                    .HasName("IX_umbracoNode_Path");

                entity.HasIndex(e => e.Trashed)
                    .HasName("IX_umbracoNode_Trashed");

                entity.HasIndex(e => e.UniqueId)
                    .HasName("IX_umbracoNode_UniqueId")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.NodeObjectType).HasColumnName("nodeObjectType");

                entity.Property(e => e.NodeUser).HasColumnName("nodeUser");

                entity.Property(e => e.ParentId).HasColumnName("parentId");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnName("path")
                    .HasMaxLength(150);

                entity.Property(e => e.SortOrder).HasColumnName("sortOrder");

                entity.Property(e => e.Text)
                    .HasColumnName("text")
                    .HasMaxLength(255);

                entity.Property(e => e.Trashed)
                    .IsRequired()
                    .HasColumnName("trashed")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("uniqueId")
                    .HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.NodeUserNavigation)
                    .WithMany(p => p.UmbracoNode)
                    .HasForeignKey(d => d.NodeUser)
                    .HasConstraintName("FK_umbracoNode_umbracoUser_id");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_umbracoNode_umbracoNode_id");
            });

            modelBuilder.Entity<UmbracoPropertyData>(entity =>
            {
                entity.ToTable("umbracoPropertyData");

                entity.HasIndex(e => e.LanguageId)
                    .HasName("IX_umbracoPropertyData_LanguageId");

                entity.HasIndex(e => e.PropertyTypeId)
                    .HasName("IX_umbracoPropertyData_PropertyTypeId");

                entity.HasIndex(e => e.Segment)
                    .HasName("IX_umbracoPropertyData_Segment");

                entity.HasIndex(e => new {e.VersionId, e.PropertyTypeId, e.LanguageId, e.Segment})
                    .HasName("IX_umbracoPropertyData_VersionId")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateValue)
                    .HasColumnName("dateValue")
                    .HasColumnType("datetime");

                entity.Property(e => e.DecimalValue)
                    .HasColumnName("decimalValue")
                    .HasColumnType("decimal(38, 6)");

                entity.Property(e => e.IntValue).HasColumnName("intValue");

                entity.Property(e => e.LanguageId).HasColumnName("languageId");

                entity.Property(e => e.PropertyTypeId).HasColumnName("propertyTypeId");

                entity.Property(e => e.Segment)
                    .HasColumnName("segment")
                    .HasMaxLength(256);

                entity.Property(e => e.TextValue)
                    .HasColumnName("textValue")
                    .HasColumnType("ntext");

                entity.Property(e => e.VarcharValue)
                    .HasColumnName("varcharValue")
                    .HasMaxLength(512);

                entity.Property(e => e.VersionId).HasColumnName("versionId");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.UmbracoPropertyData)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_umbracoPropertyData_umbracoLanguage_id");

                entity.HasOne(d => d.PropertyType)
                    .WithMany(p => p.UmbracoPropertyData)
                    .HasForeignKey(d => d.PropertyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_umbracoPropertyData_cmsPropertyType_id");

                entity.HasOne(d => d.Version)
                    .WithMany(p => p.UmbracoPropertyData)
                    .HasForeignKey(d => d.VersionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_umbracoPropertyData_umbracoContentVersion_id");
            });

            modelBuilder.Entity<UmbracoRedirectUrl>(entity =>
            {
                entity.ToTable("umbracoRedirectUrl");

                entity.HasIndex(e => new {e.UrlHash, e.ContentKey, e.Culture, e.CreateDateUtc})
                    .HasName("IX_umbracoRedirectUrl")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ContentKey).HasColumnName("contentKey");

                entity.Property(e => e.CreateDateUtc)
                    .HasColumnName("createDateUtc")
                    .HasColumnType("datetime");

                entity.Property(e => e.Culture)
                    .HasColumnName("culture")
                    .HasMaxLength(255);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasMaxLength(255);

                entity.Property(e => e.UrlHash)
                    .IsRequired()
                    .HasColumnName("urlHash")
                    .HasMaxLength(40);

                entity.HasOne(d => d.ContentKeyNavigation)
                    .WithMany(p => p.UmbracoRedirectUrl)
                    .HasPrincipalKey(p => p.UniqueId)
                    .HasForeignKey(d => d.ContentKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_umbracoRedirectUrl_umbracoNode_uniqueID");
            });

            modelBuilder.Entity<UmbracoRelation>(entity =>
            {
                entity.ToTable("umbracoRelation");

                entity.HasIndex(e => new {e.ParentId, e.ChildId, e.RelType})
                    .HasName("IX_umbracoRelation_parentChildType")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChildId).HasColumnName("childId");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnName("comment")
                    .HasMaxLength(1000);

                entity.Property(e => e.Datetime)
                    .HasColumnName("datetime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ParentId).HasColumnName("parentId");

                entity.Property(e => e.RelType).HasColumnName("relType");

                entity.HasOne(d => d.Child)
                    .WithMany(p => p.UmbracoRelationChild)
                    .HasForeignKey(d => d.ChildId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_umbracoRelation_umbracoNode1");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.UmbracoRelationParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_umbracoRelation_umbracoNode");

                entity.HasOne(d => d.RelTypeNavigation)
                    .WithMany(p => p.UmbracoRelation)
                    .HasForeignKey(d => d.RelType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_umbracoRelation_umbracoRelationType_id");
            });

            modelBuilder.Entity<UmbracoRelationType>(entity =>
            {
                entity.ToTable("umbracoRelationType");

                entity.HasIndex(e => e.Alias)
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.HasIndex(e => e.TypeUniqueId)
                    .HasName("IX_umbracoRelationType_UniqueId")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Alias)
                    .HasColumnName("alias")
                    .HasMaxLength(100);

                entity.Property(e => e.ChildObjectType).HasColumnName("childObjectType");

                entity.Property(e => e.Dual).HasColumnName("dual");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.ParentObjectType).HasColumnName("parentObjectType");

                entity.Property(e => e.TypeUniqueId).HasColumnName("typeUniqueId");
            });

            modelBuilder.Entity<UmbracoServer>(entity =>
            {
                entity.ToTable("umbracoServer");

                entity.HasIndex(e => e.ComputerName)
                    .HasName("IX_computerName")
                    .IsUnique();

                entity.HasIndex(e => e.IsActive);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(500);

                entity.Property(e => e.ComputerName)
                    .IsRequired()
                    .HasColumnName("computerName")
                    .HasMaxLength(255);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsMaster).HasColumnName("isMaster");

                entity.Property(e => e.LastNotifiedDate)
                    .HasColumnName("lastNotifiedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.RegisteredDate)
                    .HasColumnName("registeredDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<UmbracoUser>(entity =>
            {
                entity.ToTable("umbracoUser");

                entity.HasIndex(e => e.UserLogin);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Avatar)
                    .HasColumnName("avatar")
                    .HasMaxLength(500);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailConfirmedDate)
                    .HasColumnName("emailConfirmedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FailedLoginAttempts).HasColumnName("failedLoginAttempts");

                entity.Property(e => e.InvitedDate)
                    .HasColumnName("invitedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastLockoutDate)
                    .HasColumnName("lastLockoutDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastLoginDate)
                    .HasColumnName("lastLoginDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastPasswordChangeDate)
                    .HasColumnName("lastPasswordChangeDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PasswordConfig)
                    .HasColumnName("passwordConfig")
                    .HasMaxLength(500);

                entity.Property(e => e.SecurityStampToken)
                    .HasColumnName("securityStampToken")
                    .HasMaxLength(255);

                entity.Property(e => e.TourData)
                    .HasColumnName("tourData")
                    .HasColumnType("ntext");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("updateDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserDisabled)
                    .IsRequired()
                    .HasColumnName("userDisabled")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasColumnName("userEmail")
                    .HasMaxLength(255);

                entity.Property(e => e.UserLanguage)
                    .HasColumnName("userLanguage")
                    .HasMaxLength(10);

                entity.Property(e => e.UserLogin)
                    .IsRequired()
                    .HasColumnName("userLogin")
                    .HasMaxLength(125);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(255);

                entity.Property(e => e.UserNoConsole)
                    .IsRequired()
                    .HasColumnName("userNoConsole")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("userPassword")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<UmbracoUser2NodeNotify>(entity =>
            {
                entity.HasKey(e => new {e.UserId, e.NodeId, e.Action});

                entity.ToTable("umbracoUser2NodeNotify");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.NodeId).HasColumnName("nodeId");

                entity.Property(e => e.Action)
                    .HasColumnName("action")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.HasOne(d => d.Node)
                    .WithMany(p => p.UmbracoUser2NodeNotify)
                    .HasForeignKey(d => d.NodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_umbracoUser2NodeNotify_umbracoNode_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UmbracoUser2NodeNotify)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_umbracoUser2NodeNotify_umbracoUser_id");
            });

            modelBuilder.Entity<UmbracoUser2UserGroup>(entity =>
            {
                entity.HasKey(e => new {e.UserId, e.UserGroupId})
                    .HasName("PK_user2userGroup");

                entity.ToTable("umbracoUser2UserGroup");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.UserGroupId).HasColumnName("userGroupId");

                entity.HasOne(d => d.UserGroup)
                    .WithMany(p => p.UmbracoUser2UserGroup)
                    .HasForeignKey(d => d.UserGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_umbracoUser2UserGroup_umbracoUserGroup_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UmbracoUser2UserGroup)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_umbracoUser2UserGroup_umbracoUser_id");
            });

            modelBuilder.Entity<UmbracoUserGroup>(entity =>
            {
                entity.ToTable("umbracoUserGroup");

                entity.HasIndex(e => e.UserGroupAlias)
                    .IsUnique();

                entity.HasIndex(e => e.UserGroupName)
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasMaxLength(255);

                entity.Property(e => e.StartContentId).HasColumnName("startContentId");

                entity.Property(e => e.StartMediaId).HasColumnName("startMediaId");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("updateDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserGroupAlias)
                    .IsRequired()
                    .HasColumnName("userGroupAlias")
                    .HasMaxLength(200);

                entity.Property(e => e.UserGroupDefaultPermissions)
                    .HasColumnName("userGroupDefaultPermissions")
                    .HasMaxLength(50);

                entity.Property(e => e.UserGroupName)
                    .IsRequired()
                    .HasColumnName("userGroupName")
                    .HasMaxLength(200);

                entity.HasOne(d => d.StartContent)
                    .WithMany(p => p.UmbracoUserGroupStartContent)
                    .HasForeignKey(d => d.StartContentId)
                    .HasConstraintName("FK_startContentId_umbracoNode_id");

                entity.HasOne(d => d.StartMedia)
                    .WithMany(p => p.UmbracoUserGroupStartMedia)
                    .HasForeignKey(d => d.StartMediaId)
                    .HasConstraintName("FK_startMediaId_umbracoNode_id");
            });

            modelBuilder.Entity<UmbracoUserGroup2App>(entity =>
            {
                entity.HasKey(e => new {e.UserGroupId, e.App})
                    .HasName("PK_userGroup2App");

                entity.ToTable("umbracoUserGroup2App");

                entity.Property(e => e.UserGroupId).HasColumnName("userGroupId");

                entity.Property(e => e.App)
                    .HasColumnName("app")
                    .HasMaxLength(50);

                entity.HasOne(d => d.UserGroup)
                    .WithMany(p => p.UmbracoUserGroup2App)
                    .HasForeignKey(d => d.UserGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_umbracoUserGroup2App_umbracoUserGroup_id");
            });

            modelBuilder.Entity<UmbracoUserGroup2NodePermission>(entity =>
            {
                entity.HasKey(e => new {e.UserGroupId, e.NodeId, e.Permission});

                entity.ToTable("umbracoUserGroup2NodePermission");

                entity.HasIndex(e => e.NodeId)
                    .HasName("IX_umbracoUser2NodePermission_nodeId");

                entity.Property(e => e.UserGroupId).HasColumnName("userGroupId");

                entity.Property(e => e.NodeId).HasColumnName("nodeId");

                entity.Property(e => e.Permission)
                    .HasColumnName("permission")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Node)
                    .WithMany(p => p.UmbracoUserGroup2NodePermission)
                    .HasForeignKey(d => d.NodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_umbracoUserGroup2NodePermission_umbracoNode_id");

                entity.HasOne(d => d.UserGroup)
                    .WithMany(p => p.UmbracoUserGroup2NodePermission)
                    .HasForeignKey(d => d.UserGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_umbracoUserGroup2NodePermission_umbracoUserGroup_id");
            });

            modelBuilder.Entity<UmbracoUserLogin>(entity =>
            {
                entity.HasKey(e => e.SessionId);

                entity.ToTable("umbracoUserLogin");

                entity.HasIndex(e => e.LastValidatedUtc);

                entity.Property(e => e.SessionId)
                    .HasColumnName("sessionId")
                    .ValueGeneratedNever();

                entity.Property(e => e.IpAddress)
                    .HasColumnName("ipAddress")
                    .HasMaxLength(255);

                entity.Property(e => e.LastValidatedUtc)
                    .HasColumnName("lastValidatedUtc")
                    .HasColumnType("datetime");

                entity.Property(e => e.LoggedInUtc)
                    .HasColumnName("loggedInUtc")
                    .HasColumnType("datetime");

                entity.Property(e => e.LoggedOutUtc)
                    .HasColumnName("loggedOutUtc")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UmbracoUserLogin)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_umbracoUserLogin_umbracoUser_id");
            });

            modelBuilder.Entity<UmbracoUserStartNode>(entity =>
            {
                entity.ToTable("umbracoUserStartNode");

                entity.HasIndex(e => new {e.StartNodeType, e.StartNode, e.UserId})
                    .HasName("IX_umbracoUserStartNode_startNodeType")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.StartNode).HasColumnName("startNode");

                entity.Property(e => e.StartNodeType).HasColumnName("startNodeType");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.StartNodeNavigation)
                    .WithMany(p => p.UmbracoUserStartNode)
                    .HasForeignKey(d => d.StartNode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_umbracoUserStartNode_umbracoNode_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UmbracoUserStartNode)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_umbracoUserStartNode_umbracoUser_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}