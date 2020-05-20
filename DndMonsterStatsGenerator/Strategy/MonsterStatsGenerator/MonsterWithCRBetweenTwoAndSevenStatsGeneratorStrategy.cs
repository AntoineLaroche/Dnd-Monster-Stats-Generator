#nullable enable
using DndMonsterStatsGenerator.Entities.Business;
using DndMonsterStatsGenerator.Entities.Options;
using System;

namespace DndMonsterStatsGenerator.Strategy.MonsterStatsGenerator
{
    public class MonsterWithCRBetweenTwoAndSevenStatsGeneratorStrategy : IMonsterStatsGeneratorStrategy
    {
        public MonsterStats GenerateMonsterStats(MonsterCreationOption monsterCreationOption)
        {
            return new MonsterStats
            {
                AC = 13 + Convert.ToInt32(Math.Floor(monsterCreationOption.CR / 3)),
                HP = Convert.ToInt32(15 * monsterCreationOption.CR) + 15,
                Attack = 4 + Convert.ToInt32(Math.Floor(monsterCreationOption.CR / 2)),
                Damage = Convert.ToInt32(5 * monsterCreationOption.CR) + 5,
                DC = 11 + Convert.ToInt32(Math.Floor(monsterCreationOption.CR / 2)),
                Save = 3 + Convert.ToInt32(Math.Floor(monsterCreationOption.CR / 2))
            };
        }
    }
}
