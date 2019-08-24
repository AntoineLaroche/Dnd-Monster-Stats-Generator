using DndMonsterStatsGenerator.Entities.Business;
using System;

namespace DndMonsterStatsGenerator.Strategy
{
    public class MonsterWithCREightOrHigherStatsGeneratorStrategy : IMonsterStatsGeneratorStrategy
    {
        public MonsterStats GenerateMonsterStats(double challengeRating)
        {
            return new MonsterStats
            {
                AC = 13 + Convert.ToInt32(Math.Floor(challengeRating / 2)),
                HP = Convert.ToInt32(15 * challengeRating),
                Attack = 4 + Convert.ToInt32(Math.Floor(challengeRating / 2)),
                Damage = Convert.ToInt32(5 * challengeRating),
                DC = 11 + Convert.ToInt32(Math.Floor(challengeRating / 2)),
                Save = 3 + Convert.ToInt32(Math.Floor(challengeRating / 2))
            };
        }
    }
}
