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
            
            CommandOption<DbSizeOption> sizeArgument = 
                app.Option<DbSizeOption>("-s|--size=<SIZE>", 
                    "The size of the database, either 'huge', 'large' or 'medium'. Default is 'huge'.", CommandOptionType.SingleOrNoValue);

            CommandOption<bool> verboseArgument = 
                app.Option<bool>("-v|--verbose", 
                    "Verbose output", CommandOptionType.NoValue);

            CommandOption<bool> noCmsArgument = 
                app.Option<bool>("-n|--no-cms", 
                    "Exclude CMS specific tables (Umbraco)", CommandOptionType.NoValue);

            CommandOption<bool> fixRandomSeedArgument = 
                app.Option<bool>("-f|--fixed-random-seed", 
                    "Fix the underlying Random seed to produce the same sample values each time", CommandOptionType.NoValue);

            CommandOption<string> jsonFilePath = 
                app.Option<string>("-i|--input-json-file", 
                    "Define database dimensions in a json file. See the example file 'example-db-size.json'.", CommandOptionType.SingleOrNoValue);

            app.OnExecute(() =>
            {
                var connectionString = connectionStringArgument.Value();

                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    app.ShowHelp();
                    return 1;
                }
                
                DbSizeOption dbSize = sizeArgument.HasValue() ? sizeArgument.ParsedValue : DbSizeOption.Huge;
                return new Seeder(connectionString, dbSize, verboseArgument.HasValue(), noCmsArgument.HasValue(), jsonFilePath.Value(), fixRandomSeedArgument.HasValue()).Run();
            });

            return app.Execute(args);
        }
    }
}

