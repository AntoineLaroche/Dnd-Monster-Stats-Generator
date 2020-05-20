#nullable enable
using DndMonsterStatsGenerator.Entities.Business;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DndMonsterStatsGenerator.Strategy.FileGenerator
{
    public interface IFileGeneratorStrategy
    {
        Task CreateFileAsync(List<MonsterStats> content, string path);
    }
}
