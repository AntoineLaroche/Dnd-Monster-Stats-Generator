using DndMonsterStatsGenerator.Entities.Options;
using DndMonsterStatsGenerator.Factory;
using ConsoleTableExt;
using DndMonsterStatsGenerator.Entities.Business;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace DndMonsterStatsGenerator.Service
{
    public class MonsterStatsCreatorService : IMonsterStatsCreatorService
    {
        private readonly IMonsterStatsGeneratorStrategyFactory _monsterStatsGeneratorStrategyFactory;
        private readonly ILogger<IMonsterStatsCreatorService> _logger;
        private IReadOnlyList<string> _supportedFileExtension = new List<string>{ "json", "csv", "xml" };

        public MonsterStatsCreatorService(IMonsterStatsGeneratorStrategyFactory monsterStatsGeneratorStrategyFactory, ILogger<IMonsterStatsCreatorService> logger)
        {
            _monsterStatsGeneratorStrategyFactory = monsterStatsGeneratorStrategyFactory;
            _logger = logger;
        }

        public async Task<int> CreateStatsAsync(MonsterCreationOption creationOption)
        {
            try
            {
                var _monsterStatsGenerator = _monsterStatsGeneratorStrategyFactory.Get(creationOption);
                var monsterStats = new List<MonsterStats>
                {
                    _monsterStatsGenerator.GenerateMonsterStats(creationOption)
                };

                ConsoleTableBuilder.From(monsterStats)
                                    .WithFormat(ConsoleTableBuilderFormat.MarkDown)
                                    .ExportAndWriteLine();

                if (creationOption.WriteToFile)
                {
                    if (string.IsNullOrWhiteSpace(creationOption.Path))
                    {
                        throw new ArgumentNullException($"If the write to file option is enabled a path must be furnished");
                    }

                    if (creationOption.Path.IndexOfAny(Path.GetInvalidFileNameChars()) < 0)
                    {
                        throw new InvalidOperationException("Invalid character in the file name");
                    }

                    if (_supportedFileExtension.Any(x => x == Path.GetExtension(creationOption.Path).ToLower()))
                    {
                        throw new NotSupportedException("File extension for the file was not supported");
                    }

                    var jsonMonsterStats = JsonSerializer.Serialize(monsterStats);
                    await File.WriteAllTextAsync(creationOption.Path, jsonMonsterStats);
                }
            }
            catch(Exception ex)
            {
                _logger.LogDebug(ex, "Something went wrong...");
                return -1;
            }

            return 0;
        }
    }
}
