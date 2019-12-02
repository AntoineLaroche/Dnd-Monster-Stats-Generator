using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DndMonsterStatsGenerator.Entities.Business;
using CsvHelper;
using System.IO;

namespace DndMonsterStatsGenerator.Strategy.FileGenerator
{
    public class CsvStrategy : IFileGeneratorStrategy
    {
        public async Task CreateFileAsync(List<MonsterStats> content, string path)
        {
            using var writer = new StreamWriter(path);
            using var csv = new CsvWriter(writer);
            await Task.Run(() => csv.WriteRecords(content));
        }
    }
}
