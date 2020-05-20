#nullable enable
using DndMonsterStatsGenerator.Entities.Business;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace DndMonsterStatsGenerator.Strategy.FileGenerator
{
    public class YamlStrategy : IFileGeneratorStrategy
    {
        public async Task CreateFileAsync(List<MonsterStats> content, string path)
        {
            var serializer = new Serializer();
            using var writer = new StreamWriter(path);
            serializer.Serialize(writer, content);
        }
    }
}
