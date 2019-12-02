using DndMonsterStatsGenerator.Entities.Business;
using DndMonsterStatsGenerator.Entities.Options;

namespace DndMonsterStatsGenerator.Strategy.MonsterStatsGenerator
{
    public interface IMonsterStatsGeneratorStrategy
    {
        MonsterStats GenerateMonsterStats(MonsterCreationOption monsterCreationOption);
    }
}
