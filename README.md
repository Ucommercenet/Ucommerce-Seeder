
Ucommerce.Seeder
===

![.NET Core](https://github.com/Ucommercenet/Ucommerce-Seeder/workflows/.NET%20Core/badge.svg?branch=master)

This small tool is invaluable for creating medium, large and huge databases with lots of product data.

Ever tried implementing a webshop on a database with two products in it? It performs well. Until reality strikes and the production database contains 100.000s of products and prices. 

On the other hand, if you build your shop against a large Ucommerce database, chances are higher that you'll end up with a shop that scales a lot better.



## Seeding a brand new database using docker

1. install docker and docker-compose

2. `./seed`

```
Sending build context to Docker daemon  223.5MB
Step 1/9 : FROM mcr.microsoft.com/mssql/server
 ---> 885d07287041
Step 2/9 : ADD db /var/db/
 ---> Using cache
 ---> ab39544581f8
Step 3/9 : COPY db/* /var/opt/mssql/data/
 ---> Using cache
 ---> 866f2b985246
Step 4/9 : ENV SA_PASSWORD=Pass@Word1
 ---> Using cache
 ---> 5480a36c01fc
Step 5/9 : WORKDIR /var/opt/mssql/data/
 ---> Using cache
 ---> 55fac9af362c
Step 6/9 : RUN cp -f umbraco810_blank.mdf umbraco810_seeding.mdf
 ---> Using cache
 ---> 591e4c4f64af
Step 7/9 : RUN cp -f umbraco810_blank.ldf umbraco810_seeding.ldf
 ---> Using cache
 ---> 3b972f9aea91
Step 8/9 : EXPOSE 1433
 ---> Using cache
 ---> f82959dd755a
Step 9/9 : CMD [ "/opt/mssql/bin/sqlservr" ]
 ---> Using cache
 ---> e05cb09bdb61
Successfully built e05cb09bdb61
ucommerce-seeder_mssql_1 is up-to-date
Starting mssql ... done
Starting ucommerce-seeder_mssql_1 ... done
Changed database context to 'master'.
Starting ucommerce-seeder_mssql_1 ... done
Changed database context to 'master'.
Starting ucommerce-seeder_mssql_1 ... done
Generating 10 media folders with 100 images in each. 3 secs
Generating 10 definitions. 0 secs
Generating 50 definition fields. 0 secs
Generating descriptions for 50 definition fields. 0 secs
Generating 5 data types.0 secs
Generating properties for 5 data types.0 secs
Generating 4 languages. 1 secs
Generating 10 currencies. 0 secs
Generating 50 price groups. 0 secs
Generating 3 product relation types. 0 secs
Generating 5 product definitions. 0 secs
Generating 25 product definition fields. 0 secs
Generating descriptions for 25 product definition fields. 0 secs
Generating 10 stores. 0 secs
Generating properties for 10 stores. 0 secs
Generating 100 catalogs. 0 secs
Generating descriptions for 100 catalogs. 0 secs
Generating properties for 100 catalogs...0 secs
Generating allowed price groups for 100 catalogs. 0 secs
Generating 1,000 top level categories. 0 secs
Generating 4,000 subcategories. 1 secs
Generating 24,980 descriptions for 4,996 categories. 2 secs
Generating ~4,996 properties for 4,996 categories. 3 secs
Generating 1,000 products. 0 secs
Generating 5,000 descriptions for 1,000 products with  5 languages. 1 secs
Generating ~0 language variant properties with values for 1,000 products. 0 secs
Generating ~0 language invariant properties with values for 1,000 products. 0 secs
Generating 150,000 prices in batches of 100,000. 14 secs
Generating 25,000 relations for 1,000 products. 1 secs
Generating 5,000 variants. 1 secs
```

Your fininshed db will be in the `db` folder by the name `umbraco810_done.mdf|ldf`.
You can attach this database using SQL management studio or T-SQL.

`seed` takes one argument, the db size: `medium`, `large` or `huge`

For example: `./seed large` will generate a "large" database.

## Seeding an existing database

## Limitations

1. For now, this tool only works with Umbraco 8 and Ucommerce 9. It has a hard dependency on the table structure of both. 
Future versions will work with other CMSs.

1. Although the tool uses SQL Bulk Copy, seeding large databases takes a long time.

1. Truncation doesn't work yet. You'll need a fresh, empty(ish) database before you start the seeding tool.



## Prerequisites

* [.NET Core 3.0](https://dotnet.microsoft.com/download/dotnet-core/3.0)
* A SQL Server database with Umbraco 8 and Ucommerce 9 installed.


## Preparation

Contained in the solution is a 40 Mb zip file with royalty free sample images from [unsplash.com](https://unsplash.com/license)

Unpack the samples.zip to <site root>/media/ so you end up with all sample images in <site root>/media/samples/.

Start with a fresh, clean database with Umbraco 8 and Ucommerce installed. Consider using SQL Management Studio to detach your database, then make a copy that you can later attach.


## Use

1. Build the project using Rider, VS or MSBuild
2. `dotnet bin/Debug/netcoreapp3.0/uceed.dll -s:<size> -c:<connectionstring>`

Size can be `medium`, `large` or `huge`. I know, there's no "small" option; the whole reason for the tool is creating *large databases*.


### Other options
 
 -u or --ucommerce-connection for specifying a Ucommerce connection string, in case Ucommerce has been installed into a separate DB from the CMS. If this option is not provided, the '-c' connection string will be used for both.

-v or --verbose for detailed logging



