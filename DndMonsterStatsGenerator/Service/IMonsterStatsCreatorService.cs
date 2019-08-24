using DndMonsterStatsGenerator.Entities.Options;

namespace DndMonsterStatsGenerator.Service
{
    public interface IMonsterStatsCreatorService
    {
        void CreateStats(MonsterCreationOption creationOption);
    }
}