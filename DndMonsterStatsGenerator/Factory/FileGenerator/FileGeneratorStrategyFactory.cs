using System;
using DndMonsterStatsGenerator.Strategy.FileGenerator;

namespace DndMonsterStatsGenerator.Factory.FileGenerator
{
    public class FileGeneratorStrategyFactory : IFileGeneratorStrategyFactory
    {
        public IFileGeneratorStrategy Get(string fileExtension)
        {
            return fileExtension.ToLower() switch
            {
                ".json" => new JsonStrategy(),
                ".csv" => new CsvStrategy(),
                ".xml" => new XmlStrategy(),
                string s when s == ".yaml" || s == ".yml" => new YamlStrategy(),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
