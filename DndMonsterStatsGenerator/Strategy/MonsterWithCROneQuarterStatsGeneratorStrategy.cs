using DndMonsterStatsGenerator.Entities.Business;
using DndMonsterStatsGenerator.Entities.Options;

namespace DndMonsterStatsGenerator.Strategy
{
    public class MonsterWithCROneQuarterStatsGeneratorStrategy : IMonsterStatsGeneratorStrategy
    {
        public MonsterStats GenerateMonsterStats(MonsterCreationOption monsterCreationOption)
        {
            return new MonsterStats
            {
                AC = 13,
                HP = 15,
                Attack = 3,
                Damage = 5,
                DC = 10,
                Save = 2
            };
        }
    }
}
