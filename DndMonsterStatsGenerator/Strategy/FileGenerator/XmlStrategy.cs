#nullable enable
using DndMonsterStatsGenerator.Entities.Business;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace DndMonsterStatsGenerator.Strategy.FileGenerator
{
    public class XmlStrategy : IFileGeneratorStrategy
    {
        public async Task CreateFileAsync(List<MonsterStats> content, string path)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<MonsterStats>));
            using var writer = new StreamWriter(path);
            xmlSerializer.Serialize(writer, content);
        }
    }
}
