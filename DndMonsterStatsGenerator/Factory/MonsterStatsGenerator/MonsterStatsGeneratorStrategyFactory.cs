using DndMonsterStatsGenerator.Entities.Options;
using DndMonsterStatsGenerator.Strategy.MonsterStatsGenerator;
using System;

namespace DndMonsterStatsGenerator.Factory.MonsterStatsGenerator
{
    public class MonsterStatsGeneratorStrategyFactory : IMonsterStatsGeneratorStrategyFactory
    {
        public IMonsterStatsGeneratorStrategy Get(MonsterCreationOption monsterCreationOptions)
        {
            return monsterCreationOptions switch
            {
                MonsterCreationOption option when option.CR == 0 => new MonsterWithCRZeroStatsGeneratorStrategy(),

                MonsterCreationOption option when option.CR == 0.125 => new MonsterWithCROneEightStatsGeneratorStrategy(),

                MonsterCreationOption option when option.CR == 0.25 => new MonsterWithCROneQuarterStatsGeneratorStrategy(),

                MonsterCreationOption option when option.CR == 0.5 => new MonsterWithCRHalfStatsGeneratorStrategy(),

                MonsterCreationOption options when options.CR == 1 => new MonsterWithCROneStatsGeneratorStrategy(),

                MonsterCreationOption opts when opts.CR >= 2 && opts.CR < 8 => new MonsterWithCRBetweenTwoAndSevenStatsGeneratorStrategy(),

                MonsterCreationOption monsterCreationOption when monsterCreationOption.CR >= 8 => new MonsterWithCREightOrHigherStatsGeneratorStrategy(),

                _ => throw new NotImplementedException(),
            };
        }
    }
}
