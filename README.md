
Ucommerce.Seeder
===

This small tool in invaluable for creating medium, large and huge databases with lots of product data.

Ever tried implementing a webshop on a database with two products in it? It performs well. Until reality strikes and the production database contains 100.000s of products and prices. 

On the other hand, if you build your shop against a large Ucommerce database, chances are higher that you'll end up with a shop that scales a lot better.


## Limitations

1. For now, this tool only works with Umbraco 8 and Ucommerce 8. It has a hard dependency on the table structure of both. 
Future versions will work with other CMSs.

1. Although the tool uses SQL Bulk Copy, seeding large databases takes a long time.

1. Truncation doesn't work yet. You'll need a fresh, empty(ish) database before you start the seeding tool.



## Prerequisites

* .NET Core 2.2
* A SQL Server database with Umbraco 8 and Ucommerce 8 installed.


## Preparation

Contained in the solution is a 40 Mb zip file with royalty free sample images from [unsplash.com](https://unsplash.com/license)

Unpack the samples.zip to <site root>/media/ so you end up with all sample images in <site root>/media/samples/.

Start with a fresh, clean database with Umbraco 8 and Ucommerce installed. Consider using SQL Management Studio to detach your database, then make a copy that you can later attach.


## Use

1. Build the project using Rider, VS or MSBuild
2. `dotnet bin/dotnetcore2.2/uceed.dll -s:<size> -c:<connectionstring>`

Size can be `medium`, `large` or `huge`. I know, there's no "small" option; the whole reason for the tool is creating *large databases*.


### Other options

-v or --verbose for detailed logging



