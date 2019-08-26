using DndMonsterStatsGenerator.Entities.Options;
using DndMonsterStatsGenerator.Factory;
using ConsoleTableExt;
using DndMonsterStatsGenerator.Entities.Business;
using System.Collections.Generic;

namespace DndMonsterStatsGenerator.Service
{
    public class MonsterStatsCreatorService : IMonsterStatsCreatorService
    {
        private readonly IMonsterStatsGeneratorStrategyFactory _monsterStatsGeneratorStrategyFactory;

        public MonsterStatsCreatorService(IMonsterStatsGeneratorStrategyFactory monsterStatsGeneratorStrategyFactory)
        {
            _monsterStatsGeneratorStrategyFactory = monsterStatsGeneratorStrategyFactory;
        }

        public int CreateStats(MonsterCreationOption creationOption)
        {
            var strategy = _monsterStatsGeneratorStrategyFactory.Get(creationOption);
            var monsterStats = new List<MonsterStats>
            {
                strategy.GenerateMonsterStats(creationOption)
            };
            ConsoleTableBuilder.From(monsterStats)
                                .WithFormat(ConsoleTableBuilderFormat.MarkDown)
                                .ExportAndWriteLine();
            return 0;
        }
    }
}
