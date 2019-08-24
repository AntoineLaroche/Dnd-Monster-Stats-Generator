namespace DndMonsterStatsGenerator
{
    public interface IMonsterStatsGeneratorStrategy
    {
        void GenerateMonsterStats(double challengeRating);
    }
}
