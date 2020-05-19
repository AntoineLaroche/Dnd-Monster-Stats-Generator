using DndMonsterStatsGenerator.Entities.Options;
using DndMonsterStatsGenerator.Strategy.MonsterStatsGenerator;
using System;

namespace DndMonsterStatsGenerator.Factory.MonsterStatsGenerator
{
    public class MonsterStatsGeneratorStrategyFactory : IMonsterStatsGeneratorStrategyFactory
    {
        public IMonsterStatsGeneratorStrategy Get(MonsterCreationOption monsterCreationOptions)
        {
            return monsterCreationOptions.CR switch
            {
                0 => new MonsterWithCRZeroStatsGeneratorStrategy(),
                0.125 => new MonsterWithCROneEightStatsGeneratorStrategy(),
                0.25 => new MonsterWithCROneQuarterStatsGeneratorStrategy(),
                0.5 => new MonsterWithCRHalfStatsGeneratorStrategy(),
                1 => new MonsterWithCROneStatsGeneratorStrategy(),
                double cr when cr >= 2 && cr < 8 => new MonsterWithCRBetweenTwoAndSevenStatsGeneratorStrategy(),
                double cr when cr >= 8 => new MonsterWithCREightOrHigherStatsGeneratorStrategy(),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
