using McMaster.Extensions.CommandLineUtils;

namespace Ucommerce.Seeder
{
    partial class Program
    {
        static int Main(string[] args)
        {
            var app = new CommandLineApplication();
            app.HelpOption();
            
            CommandOption<string> connectionStringArgument = 
                app.Option<string>("-c|--connection=<CONNECTION_STRING>", 
                    "Required: A connectionstring for the database to seed", CommandOptionType.SingleValue);

            CommandOption<string> ucommerceConnectionStringArgument =
	            app.Option<string>("-u|--ucommerce-connection=<CONNECTION_STRING>",
		            "The connectionstring used by Ucommerce when different from the CMS database", CommandOptionType.SingleOrNoValue);

            CommandOption<DbSizeOption> sizeArgument = 
                app.Option<DbSizeOption>("-s|--size=<SIZE>", 
                    "The size of the database, either 'huge', 'large' or 'medium'. Default is 'huge'.", CommandOptionType.SingleOrNoValue);

            CommandOption<bool> verboseArgument = 
                app.Option<bool>("-v|--verbose", 
                    "Verbose output", CommandOptionType.NoValue);

            CommandOption<bool> noCmsArgument = 
                app.Option<bool>("-n|--no-cms", 
                    "Exclude CMS specific tables (Umbraco)", CommandOptionType.NoValue);

            CommandOption<string> jsonFilePath = 
                app.Option<string>("-i|--input-json-file", 
                    "Define database dimensions in a json file. See the example file 'example-db-size.json'.", CommandOptionType.SingleOrNoValue);

            app.OnExecute(() =>
            {
                var cmsConnectionString = connectionStringArgument.Value();
                var ucommerceConnectionString = ucommerceConnectionStringArgument.Value();
                
                if (string.IsNullOrWhiteSpace(cmsConnectionString))
                {
                    app.ShowHelp();
                    return 1;
                }

                if (string.IsNullOrEmpty(ucommerceConnectionString))
                {
	                ucommerceConnectionString = cmsConnectionString;
                }
                
                DbSizeOption dbSize = sizeArgument.HasValue() ? sizeArgument.ParsedValue : DbSizeOption.Huge;
                return new Seeder(cmsConnectionString, ucommerceConnectionString, dbSize, verboseArgument.HasValue(), noCmsArgument.HasValue(), jsonFilePath.Value()).Run();
            });
            
            return app.Execute(args);
        }
    }
}