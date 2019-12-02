namespace DndMonsterStatsGenerator
{
    using CommandLine;
    using Colorful;
    using DndMonsterStatsGenerator.Entities.Options;
    using DndMonsterStatsGenerator.Service;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;
    using DndMonsterStatsGenerator.Factory.MonsterStatsGenerator;
    using DndMonsterStatsGenerator.Factory.FileGenerator;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(configure => configure.AddConsole())
                .Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Debug)
                .AddTransient<MonsterStatsCreatorService>()
                .AddSingleton<IMonsterStatsCreatorService, MonsterStatsCreatorService>()
                .AddScoped<IMonsterStatsGeneratorStrategyFactory, MonsterStatsGeneratorStrategyFactory>()
                .AddScoped<IFileGeneratorStrategyFactory, FileGeneratorStrategyFactory>()
                .BuildServiceProvider();

            Console.WriteAscii("DND monster stats generator", System.Drawing.Color.DarkRed);

            var logger = serviceProvider.GetService<ILogger<Program>>();
            logger.LogDebug("Starting application");

            var monsterCreator = serviceProvider.GetService<IMonsterStatsCreatorService>();

            await Task.Run(() => Parser.Default.ParseArguments<MonsterCreationOption>(args)
                .WithParsed(async opts => await monsterCreator.CreateStatsAsync(opts)));
        }
    }
}
