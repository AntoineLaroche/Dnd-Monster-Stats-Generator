#nullable enable
using DndMonsterStatsGenerator.Entities.Business;
using DndMonsterStatsGenerator.Factory.FileGenerator;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Threading.Tasks;

namespace DndMonsterStatsGenerator.Service
{
    public class FileCreatorService : IFileCreatorService
    {
        private readonly IFileGeneratorStrategyFactory _fileGeneratorStrategyFactory;
        private readonly IFileSystem _fileSystem;

        public FileCreatorService(IFileGeneratorStrategyFactory fileGeneratorStrategyFactory, IFileSystem fileSystem)
        {
            _fileGeneratorStrategyFactory = fileGeneratorStrategyFactory;
            _fileSystem = fileSystem;
        }

        public async Task CreateFile(string path, List<MonsterStats> monsterStats)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException("If the write to file option is enabled a path must be furnished");
            }

            if (!_fileSystem.Directory.Exists(_fileSystem.Path.GetDirectoryName(path)))
            {
                throw new InvalidOperationException("The directory for the file does not exists");
            }

            var fileGenerator = _fileGeneratorStrategyFactory.Get(_fileSystem.Path.GetExtension(path));
            await fileGenerator.CreateFileAsync(monsterStats, path);
        }
    }
}
