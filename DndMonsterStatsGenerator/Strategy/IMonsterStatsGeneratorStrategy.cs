using DndMonsterStatsGenerator.Entities.Business;

namespace DndMonsterStatsGenerator.Strategy
{
    public interface IMonsterStatsGeneratorStrategy
    {
        MonsterStats GenerateMonsterStats(double challengeRating);
    }
}
