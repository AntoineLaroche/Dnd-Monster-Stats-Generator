using DndMonsterStatsGenerator.Entities.Business;
using DndMonsterStatsGenerator.Entities.Options;

namespace DndMonsterStatsGenerator.Strategy.MonsterStatsGenerator
{
    public class MonsterWithCRHalfStatsGeneratorStrategy : IMonsterStatsGeneratorStrategy
    {
        public MonsterStats GenerateMonsterStats(MonsterCreationOption monsterCreationOption)
        {
            return new MonsterStats
            {
                AC = 13,
                HP = 24,
                Attack = 4,
                Damage = 8,
                DC = 11,
                Save = 3
            };
        }
    }
}
