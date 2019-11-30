using DndMonsterStatsGenerator.Entities.Options;
using DndMonsterStatsGenerator.Factory;
using ConsoleTableExt;
using DndMonsterStatsGenerator.Entities.Business;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace DndMonsterStatsGenerator.Service
{
    public class MonsterStatsCreatorService : IMonsterStatsCreatorService
    {
        private readonly IMonsterStatsGeneratorStrategyFactory _monsterStatsGeneratorStrategyFactory;

        public MonsterStatsCreatorService(IMonsterStatsGeneratorStrategyFactory monsterStatsGeneratorStrategyFactory)
        {
            _monsterStatsGeneratorStrategyFactory = monsterStatsGeneratorStrategyFactory;
        }

        public async Task<int> CreateStatsAsync(MonsterCreationOption creationOption)
        {
            var strategy = _monsterStatsGeneratorStrategyFactory.Get(creationOption);
            var monsterStats = new List<MonsterStats>
            {
                strategy.GenerateMonsterStats(creationOption)
            };

            ConsoleTableBuilder.From(monsterStats)
                                .WithFormat(ConsoleTableBuilderFormat.MarkDown)
                                .ExportAndWriteLine();

            if (creationOption.WriteToFile)
            {
                var jsonMonsterStats = JsonSerializer.Serialize(monsterStats);
                using var file = new System.IO.StreamWriter(creationOption.Path);
                await file.WriteLineAsync(jsonMonsterStats);
            }

            return 0;
        }
    }
}
