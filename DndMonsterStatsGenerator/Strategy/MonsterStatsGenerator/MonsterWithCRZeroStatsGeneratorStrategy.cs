#nullable enable
using DndMonsterStatsGenerator.Entities.Business;
using DndMonsterStatsGenerator.Entities.Options;

namespace DndMonsterStatsGenerator.Strategy.MonsterStatsGenerator
{
    public class MonsterWithCRZeroStatsGeneratorStrategy : IMonsterStatsGeneratorStrategy
    {
        public MonsterStats GenerateMonsterStats(MonsterCreationOption monsterCreationOption)
        {
            return new MonsterStats
            {
                AC = 12,
                HP = 3,
                Attack = 2,
                Damage = 1,
                DC = 9,
                Save = 1
            };
        }
    }
}
