using DndMonsterStatsGenerator.Entities.Business;
using DndMonsterStatsGenerator.Entities.Options;

namespace DndMonsterStatsGenerator.Service
{
    public interface IMonsterStatsCreatorService
    {
        int CreateStats(MonsterCreationOption creationOption);
    }
}