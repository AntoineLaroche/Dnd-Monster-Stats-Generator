#nullable enable
using System;
using DndMonsterStatsGenerator.Strategy.FileGenerator;

namespace DndMonsterStatsGenerator.Factory.FileGenerator
{
    public class FileGeneratorStrategyFactory : IFileGeneratorStrategyFactory
    {
        public IFileGeneratorStrategy Get(string fileExtension)
        {
            return fileExtension.ToLowerInvariant() switch
            {
                ".json" => new JsonStrategy(),
                ".csv" => new CsvStrategy(),
                ".xml" => new XmlStrategy(),
                string extension when extension == ".yaml" || extension == ".yml" => new YamlStrategy(),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
