using System.Threading.Tasks;

namespace DndMonsterStatsGenerator
{
    public interface IMonsterStatsCreatorService
    {
        Task CreateStats(Create creationOption);
    }
}