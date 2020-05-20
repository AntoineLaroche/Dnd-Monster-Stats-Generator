#nullable enable
using DndMonsterStatsGenerator.Entities.Options;
using DndMonsterStatsGenerator.Strategy.MonsterStatsGenerator;

namespace DndMonsterStatsGenerator.Factory.MonsterStatsGenerator
{
    public interface IMonsterStatsGeneratorStrategyFactory
    {
        IMonsterStatsGeneratorStrategy Get(MonsterCreationOption monsterCreationOptions);
    }
}