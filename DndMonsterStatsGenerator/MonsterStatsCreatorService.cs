using System.Threading.Tasks;

namespace DndMonsterStatsGenerator
{
    public class MonsterStatsCreatorService : IMonsterStatsCreatorService
    {
        public async Task CreateStats(Create creationOption)
        {
            await Task.Run(() => "");
        }
    }
}
