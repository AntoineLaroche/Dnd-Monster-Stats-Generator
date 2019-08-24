using DndMonsterStatsGenerator.Entities.Options;
using DndMonsterStatsGenerator.Strategy;

namespace DndMonsterStatsGenerator.Factory
{
    public class MonsterStatsGeneratorStrategyFactory : IMonsterStatsGeneratorStrategyFactory
    {
        public IMonsterStatsGeneratorStrategy Get(MonsterCreationOption monsterCreationOptions)
        {
            switch (monsterCreationOptions)
            {
                case MonsterCreationOption monsterCreationOption when monsterCreationOption.CR >= 8:
                    return new MonsterWithCREightOrHigherStatsGeneratorStrategy();
                default:
                    return new MonsterWithCREightOrHigherStatsGeneratorStrategy();
            }
        }
    }
}
