namespace DndMonsterStatsGenerator
{
    using CommandLine;
    using Colorful;
    using DndMonsterStatsGenerator.Entities.Options;
    using DndMonsterStatsGenerator.Service;
    using DndMonsterStatsGenerator.Factory;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(configure => configure.AddConsole())
                .Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Debug)
                .AddTransient<MonsterStatsCreatorService>()
                .AddSingleton<IMonsterStatsCreatorService, MonsterStatsCreatorService>()
                .AddScoped<IMonsterStatsGeneratorStrategyFactory, MonsterStatsGeneratorStrategyFactory>()
                .BuildServiceProvider();

            Console.WriteAscii("DND monster stats generator", System.Drawing.Color.DarkRed);

            var logger = serviceProvider.GetService<ILogger<Program>>();
            logger.LogDebug("Starting application");

            var monsterCreator = serviceProvider.GetService<IMonsterStatsCreatorService>();

            Parser.Default.ParseArguments<MonsterCreationOption>(args)
                  .WithParsed(opts => monsterCreator.CreateStats(opts));
        }
    }
}
