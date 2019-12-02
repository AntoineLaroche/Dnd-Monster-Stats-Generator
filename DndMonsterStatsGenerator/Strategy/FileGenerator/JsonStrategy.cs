using DndMonsterStatsGenerator.Entities.Business;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace DndMonsterStatsGenerator.Strategy.FileGenerator
{
    public class JsonStrategy : IFileGeneratorStrategy
    {
        public async Task CreateFileAsync(List<MonsterStats> content, string path)
        {
            var jsonMonsterStats = JsonSerializer.Serialize(content);
            await File.WriteAllTextAsync(path, jsonMonsterStats);
        }
    }
}
