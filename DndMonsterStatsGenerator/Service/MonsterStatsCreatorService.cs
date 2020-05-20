#nullable enable
using DndMonsterStatsGenerator.Entities.Options;
using ConsoleTableExt;
using DndMonsterStatsGenerator.Entities.Business;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using DndMonsterStatsGenerator.Factory.MonsterStatsGenerator;

namespace DndMonsterStatsGenerator.Service
{
    public class MonsterStatsCreatorService : IMonsterStatsCreatorService
    {
        private readonly IMonsterStatsGeneratorStrategyFactory _monsterStatsGeneratorStrategyFactory;
        private readonly ILogger<IMonsterStatsCreatorService> _logger;
        private readonly IFileCreatorService _fileCreatorService;

        public MonsterStatsCreatorService(IMonsterStatsGeneratorStrategyFactory monsterStatsGeneratorStrategyFactory, ILogger<IMonsterStatsCreatorService> logger, IFileCreatorService fileCreatorService)
        {
            _monsterStatsGeneratorStrategyFactory = monsterStatsGeneratorStrategyFactory;
            _logger = logger;
            _fileCreatorService = fileCreatorService;
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
                    await _fileCreatorService.CreateFile(creationOption.Path, monsterStats);
                }
            }
            catch(Exception ex)
            {
                _logger.LogDebug(ex, "Something went wrong...");
                return -1;
            }

            return 0;
        }

        public Func<MonsterCreationOption, Task> CreateStatsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
