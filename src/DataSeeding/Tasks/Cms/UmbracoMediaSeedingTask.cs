using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Ucommerce.Seeder.DataSeeding.Utilities;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding.Tasks.Cms
{
    public class UmbracoMediaSeedingTask : DataSeedingTaskBase
    {
        private readonly DatabaseSize _sizeOptions;
        private readonly Faker<UmbracoNode> _folderNodeFaker;
        private readonly Faker<UmbracoNode> _imageNodeFaker;
        private readonly Faker _faker;

        private const int mediaFolderType = 1031;
        private const int mediaType = 1032;

        public UmbracoMediaSeedingTask(DatabaseSize sizeOptions) : base(
            sizeOptions.CmsMediaFolders * sizeOptions.CmsImagesPerFolder)
        {
            _faker = new Faker();
            _sizeOptions = sizeOptions;
            _folderNodeFaker = new Faker<UmbracoNode>()
                .RuleFor(x => x.Level, f => 1)
                .RuleFor(x => x.Path, f => "-1,1051")
                .RuleFor(x => x.ParentId, f => -1)
                .RuleFor(x => x.UniqueId, f => f.Random.Guid())
                .RuleFor(x => x.SortOrder, f => 0)
                .RuleFor(x => x.NodeUser, f => -1)
                .RuleFor(x => x.NodeObjectType, f => UmbracoContentProvider.UmbracoMediaNodeType)
                .RuleFor(x => x.Text, f => f.Name.JobArea());

            _imageNodeFaker = new Faker<UmbracoNode>()
                .RuleFor(x => x.Level, f => 2)
                .RuleFor(x => x.UniqueId, f => f.Random.Guid())
                .RuleFor(x => x.SortOrder, f => 0)
                .RuleFor(x => x.NodeUser, f => -1)
                .RuleFor(x => x.NodeObjectType, f => UmbracoContentProvider.UmbracoMediaNodeType)
                .RuleFor(x => x.Text, f => f.Name.JobArea());
        }

        public override async Task Seed(UmbracoDbContext context)
        {
            Console.Write(
                $"Generating {_sizeOptions.CmsMediaFolders} media folders with {_sizeOptions.CmsImagesPerFolder} images in each. ");

            using (var p = new ProgressBar())
            {
                // Folders

                var folderNodes = GeneratorHelper.Generate(GenerateFolder, _sizeOptions.CmsMediaFolders);

                folderNodes.ConsecutiveSortOrder((f, v) => f.SortOrder = (int) v);

                await context.BulkInsertAsync(folderNodes, options => options.ColumnPrimaryKeyExpression = node => node.Id);
            
                foreach (var folderNode in folderNodes)
                {
                    folderNode.Path = $"{folderNode.Path},{folderNode.Id}";
                }
                await context.BulkMergeAsync(folderNodes, options => options.ColumnPrimaryKeyExpression = node => node.Id);
                p.Report(0.1);

                
                // Folder contents

                var folderContents = folderNodes.Select(folder => new UmbracoContent
                    {NodeId = folder.Id, ContentTypeId = mediaFolderType}).ToArray();
                await context.BulkInsertAsync(folderContents);
                p.Report(0.2);

                
                // Folder ContentNUs

                var folderContentNus =
                    folderContents.Select(folder => new CmsContentNu
                    {
                        NodeId = folder.NodeId, Published = true,
                        Data = "{\"properties\":{},\"cultureData\":{},\"urlSegment\":\"" + _faker.Lorem.Slug() + "\"}"
                    }).ToArray();
                await context.BulkInsertAsync(folderContentNus);
                p.Report(0.3);

                // Images

                var imageNodes = folderNodes.SelectMany(folder =>
                    {
                        return GeneratorHelper.Generate(() => GenerateImage(folder), _sizeOptions.CmsImagesPerFolder);
                    }
                ).ToArray();

                imageNodes.ConsecutiveSortOrder((f, v) => f.SortOrder = (int) v);
                await context.BulkInsertAsync(imageNodes);

                foreach (var imageNode in imageNodes)
                {
                    imageNode.Path = $"{imageNode.Path},{imageNode.Id}";
                }
                await context.BulkMergeAsync(imageNodes, options => options.ColumnPrimaryKeyExpression = node => node.Id);
                p.Report(0.4);

                // Image Content

                var imageContents = imageNodes
                    .Select(image => new UmbracoContent {NodeId = image.Id, ContentTypeId = mediaType}).ToArray();
                await context.BulkInsertAsync(imageContents);
                p.Report(0.5);


                // Sample images

                var sampleImageNames = File.ReadAllLines("sample_image_list.txt");
                string contentNuTemplate = File.ReadAllText("cmsContentNu.template");
                string propertyDataTemplate = File.ReadAllText("propertyData.template");

                Dictionary<int, string> imagePaths = imageNodes.ToDictionary(node => node.Id,
                    node => $"/media/samples/{_faker.PickRandom(sampleImageNames)}");
                p.Report(0.6);

                // Image ContentNUs

                var imageContentNus =
                    imageContents.Select(imageContent =>
                        GenerateImageNu(imageContent, imagePaths[imageContent.NodeId], contentNuTemplate)).ToArray();
                await context.BulkInsertAsync(imageContentNus);
                p.Report(0.7);


                // Folder: Content versions and media versions

                var folderContentVersions = folderNodes
                    .Select(media => new UmbracoContentVersion
                        {Current = true, NodeId = media.Id, Text = media.Text, UserId = -1}).ToArray();
                await context.BulkInsertAsync(folderContentVersions);

                var folderMediaVersions = folderContentVersions
                    .Select(contentVersion => new UmbracoMediaVersion {Id = contentVersion.Id, Path = ""}).ToArray();
                await context.BulkInsertAsync(folderMediaVersions, options => options.AutoMapOutputDirection = false);
                p.Report(0.8);


                // Image: Content versions and media versions

                var imageContentVersions = imageNodes
                    .Select(media => new UmbracoContentVersion
                        {Current = true, NodeId = media.Id, Text = media.Text, UserId = -1}).ToArray();
                await context.BulkInsertAsync(imageContentVersions);

                var propertyData = imageContentVersions.SelectMany(contentVersion =>
                {
                    return new[]
                    {
                        new UmbracoPropertyData {VersionId = contentVersion.Id, PropertyTypeId = 10, VarcharValue = "jpg"},
                        new UmbracoPropertyData {VersionId = contentVersion.Id, PropertyTypeId = 9, VarcharValue = "10000"},
                        new UmbracoPropertyData {VersionId = contentVersion.Id, PropertyTypeId = 8, IntValue = 1080},
                        new UmbracoPropertyData {VersionId = contentVersion.Id, PropertyTypeId = 7, IntValue = 1080},
                        new UmbracoPropertyData {VersionId = contentVersion.Id, PropertyTypeId = 6, TextValue = propertyDataTemplate.Replace("<mediaPath>", imagePaths[contentVersion.NodeId])},
                    };
                });
                await context.BulkInsertAsync(propertyData, options => options.AutoMapOutputDirection = false);
                p.Report(0.9);

                var imageMediaVersions = imageContentVersions
                    .Select(contentVersion => new UmbracoMediaVersion
                        {Id = contentVersion.Id, Path = imagePaths[contentVersion.NodeId]}).ToArray();
                await context.BulkInsertAsync(imageMediaVersions);
            }
        }

        private UmbracoNode GenerateFolder()
        {
            return _folderNodeFaker.Generate();
        }

        private CmsContentNu GenerateImageNu(UmbracoContent image, string imagePath, string template)
        {
            string json = template.Replace("<mediaPath>", imagePath);
            return new CmsContentNu {NodeId = image.NodeId, Published = true, Data = json};
        }

        private UmbracoNode GenerateImage(UmbracoNode folder)
        {
            return _imageNodeFaker
                .RuleFor(x => x.Path, f => $"-1,{folder.Id}")
                .RuleFor(x => x.ParentId, f => folder.Id)
                .Generate();
        }

    }
}