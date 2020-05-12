using DndMonsterStatsGenerator.Entities.Business;
using DndMonsterStatsGenerator.Entities.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DndMonsterStatsGenerator.Service
{
    public interface IFileCreatorService
    {
        Task CreateFile(string path, List<MonsterStats> monsterStats);
    }
}