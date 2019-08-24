using System.Threading.Tasks;

namespace DndMonsterStatsGenerator
{
    public class MonsterStatsFactory
    {
        public async Task<IMonsterStatsGeneratorStrategy> GetMonsterStatsGeneratorStrategy(Create monsterCreationOptions)
        {
            return new IMonsterStatsGeneratorStrategy();
        }
    }
}
