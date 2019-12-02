using DndMonsterStatsGenerator.Entities.Options;
using ConsoleTableExt;
using DndMonsterStatsGenerator.Entities.Business;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using DndMonsterStatsGenerator.Factory.MonsterStatsGenerator;
using DndMonsterStatsGenerator.Factory.FileGenerator;

namespace DndMonsterStatsGenerator.Service
{
    public class MonsterStatsCreatorService : IMonsterStatsCreatorService
    {
        private readonly IMonsterStatsGeneratorStrategyFactory _monsterStatsGeneratorStrategyFactory;
        private readonly ILogger<IMonsterStatsCreatorService> _logger;
        private readonly IFileGeneratorStrategyFactory _fileGeneratorStrategyFactory;

        public MonsterStatsCreatorService(IMonsterStatsGeneratorStrategyFactory monsterStatsGeneratorStrategyFactory, ILogger<IMonsterStatsCreatorService> logger, IFileGeneratorStrategyFactory fileGeneratorStrategyFactory)
        {
            _monsterStatsGeneratorStrategyFactory = monsterStatsGeneratorStrategyFactory;
            _logger = logger;
            _fileGeneratorStrategyFactory = fileGeneratorStrategyFactory;
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

                    var fileGenerator = _fileGeneratorStrategyFactory.Get(Path.GetExtension(creationOption.Path));
                    await fileGenerator.CreateFileAsync(monsterStats, creationOption.Path);
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
