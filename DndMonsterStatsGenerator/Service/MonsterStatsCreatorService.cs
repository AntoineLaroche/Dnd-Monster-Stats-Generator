using DndMonsterStatsGenerator.Entities.Options;
using DndMonsterStatsGenerator.Factory;

namespace DndMonsterStatsGenerator.Service
{
    public class MonsterStatsCreatorService : IMonsterStatsCreatorService
    {
        private IMonsterStatsGeneratorStrategyFactory _monsterStatsGeneratorStrategyFactory;

        public MonsterStatsCreatorService(IMonsterStatsGeneratorStrategyFactory monsterStatsGeneratorStrategyFactory)
        {
            _monsterStatsGeneratorStrategyFactory = monsterStatsGeneratorStrategyFactory;
        }

        public void CreateStats(MonsterCreationOption creationOption)
        {
           var strategy = _monsterStatsGeneratorStrategyFactory.Get(creationOption);
           var monster = strategy.GenerateMonsterStats(creationOption.CR);
        }
    }
}
