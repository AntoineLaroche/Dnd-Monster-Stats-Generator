using DndMonsterStatsGenerator.Entities.Options;
using DndMonsterStatsGenerator.Strategy;

namespace DndMonsterStatsGenerator.Factory
{
    public interface IMonsterStatsGeneratorStrategyFactory
    {
        IMonsterStatsGeneratorStrategy Get(MonsterCreationOption monsterCreationOptions);
    }
}