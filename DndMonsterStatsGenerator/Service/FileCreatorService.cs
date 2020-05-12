using DndMonsterStatsGenerator.Entities.Business;
using DndMonsterStatsGenerator.Factory.FileGenerator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DndMonsterStatsGenerator.Service
{
    public class FileCreatorService : IFileCreatorService
    {
        private readonly IFileGeneratorStrategyFactory _fileGeneratorStrategyFactory;

        public FileCreatorService(IFileGeneratorStrategyFactory fileGeneratorStrategyFactory)
        {
            _fileGeneratorStrategyFactory = fileGeneratorStrategyFactory;
        }

        public async Task CreateFile(string path, List<MonsterStats> monsterStats)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException("If the write to file option is enabled a path must be furnished");
            }

            if (path.IndexOfAny(Path.GetInvalidFileNameChars()) < 0)
            {
                throw new InvalidOperationException("Invalid character in the file name");
            }

            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                throw new InvalidOperationException("The directory for the file does not exists");
            }

            var fileGenerator = _fileGeneratorStrategyFactory.Get(Path.GetExtension(path));
            await fileGenerator.CreateFileAsync(monsterStats, path);
        }
    }
}
