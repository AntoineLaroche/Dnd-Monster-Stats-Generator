#nullable enable
using DndMonsterStatsGenerator.Entities.Options;
using System;
using System.Threading.Tasks;

namespace DndMonsterStatsGenerator.Service
{
    public interface IMonsterStatsCreatorService
    {
        Task<int> CreateStatsAsync(MonsterCreationOption creationOption);
    }
}