using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataAccess
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