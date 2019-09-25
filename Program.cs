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

            CommandOption<bool> truncateArgument = 
                app.Option<bool>("-t|--truncate", 
                    "Truncate database", CommandOptionType.NoValue);

            app.OnExecute(async () =>
            {
                var connectionString = connectionStringArgument.Value();

                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    app.ShowHelp();
                    return 1;
                }
                
                DbSizeOption dbSize = sizeArgument.HasValue() ? sizeArgument.ParsedValue : DbSizeOption.Huge;
                int result = await new Seeder(connectionString, dbSize, verboseArgument.HasValue(), truncateArgument.HasValue()).Run();
                return result;
            });

            return app.Execute(args);
        }
    }
}

