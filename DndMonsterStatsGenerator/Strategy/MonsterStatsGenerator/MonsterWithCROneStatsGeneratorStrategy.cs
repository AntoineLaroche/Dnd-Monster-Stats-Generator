#nullable enable
using DndMonsterStatsGenerator.Entities.Business;
using DndMonsterStatsGenerator.Entities.Options;

namespace DndMonsterStatsGenerator.Strategy.MonsterStatsGenerator
{
    public class MonsterWithCROneStatsGeneratorStrategy : IMonsterStatsGeneratorStrategy
    {
        public MonsterStats GenerateMonsterStats(MonsterCreationOption monsterCreationOption)
        {
            return new MonsterStats
            {
                AC = 13,
                HP = 30,
                Attack = 4,
                Damage = 10,
                DC = 11,
                Save = 3
            };
        }
    }
}
