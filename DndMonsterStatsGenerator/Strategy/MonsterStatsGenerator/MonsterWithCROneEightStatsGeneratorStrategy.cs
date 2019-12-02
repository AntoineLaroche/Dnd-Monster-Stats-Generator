using DndMonsterStatsGenerator.Entities.Business;
using DndMonsterStatsGenerator.Entities.Options;

namespace DndMonsterStatsGenerator.Strategy.MonsterStatsGenerator
{
    public class MonsterWithCROneEightStatsGeneratorStrategy : IMonsterStatsGeneratorStrategy
    {
        public MonsterStats GenerateMonsterStats(MonsterCreationOption monsterCreationOption)
        {
            return new MonsterStats
            {
                AC = 12,
                HP = 9,
                Attack = 3,
                Damage = 3,
                DC = 10,
                Save = 2
            };
        }
    }
}
