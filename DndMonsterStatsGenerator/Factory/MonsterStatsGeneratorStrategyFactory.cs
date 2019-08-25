using DndMonsterStatsGenerator.Entities.Options;
using DndMonsterStatsGenerator.Strategy;
using System;

namespace DndMonsterStatsGenerator.Factory
{
    public class MonsterStatsGeneratorStrategyFactory : IMonsterStatsGeneratorStrategyFactory
    {
        public IMonsterStatsGeneratorStrategy Get(MonsterCreationOption monsterCreationOptions)
        {
            switch (monsterCreationOptions)
            {
                case MonsterCreationOption option when option.CR == 0:
                    return new MonsterWithCRZeroStatsGeneratorStrategy();

                case MonsterCreationOption option when option.CR == 0.125:
                    return new MonsterWithCROneEightStatsGeneratorStrategy();

                case MonsterCreationOption option when option.CR == 0.25:
                    return new MonsterWithCROneQuarterStatsGeneratorStrategy();

                case MonsterCreationOption option when option.CR == 0.5:
                    return new MonsterWithCRHalfStatsGeneratorStrategy();

                case MonsterCreationOption options when options.CR == 1:
                    return new MonsterWithCROneStatsGeneratorStrategy();

                case MonsterCreationOption opts when opts.CR >= 2 && opts.CR < 8:
                    return new MonsterWithCRBetweenTwoAndSevenStatsGeneratorStrategy();

                case MonsterCreationOption monsterCreationOption when monsterCreationOption.CR >= 8:
                    return new MonsterWithCREightOrHigherStatsGeneratorStrategy();

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
