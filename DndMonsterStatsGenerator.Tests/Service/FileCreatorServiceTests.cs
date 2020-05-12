using DndMonsterStatsGenerator.Service;
using System;
using System.Collections.Generic;
using Moq;
using DndMonsterStatsGenerator.Strategy.FileGenerator;
using DndMonsterStatsGenerator.Factory.FileGenerator;
using System.IO.Abstractions;
using Xunit;
using AutoFixture;
using DndMonsterStatsGenerator.Entities.Business;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using AutoFixture.Xunit2;

namespace DndMonsterStatsGenerator.Tests.Service
{
    public class FileCreatorServiceTests
    {
        private readonly FileCreatorService _sut;
        private readonly Mock<IFileGeneratorStrategyFactory> _fileGeneratorStrategyFactory;
        private readonly Mock<IFileSystem> _fileSystem;
        private readonly IFixture _fixture;

        public FileCreatorServiceTests()
        {
            _fixture = new Fixture();
            _fileGeneratorStrategyFactory = new Mock<IFileGeneratorStrategyFactory>();
            _fileSystem = new Mock<IFileSystem>();
            _sut = new FileCreatorService(_fileGeneratorStrategyFactory.Object, _fileSystem.Object);
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("")]
        public async Task GivenEmptyPath_CreateFile_ShouldThrowArgumentNullException(string path)
        {
            Func<Task> action = async () => { await _sut.CreateFile(path, _fixture.CreateMany<MonsterStats>().ToList()); } ;

            await action.Should().ThrowExactlyAsync<ArgumentNullException>();
        }

        [Theory, AutoData]
        public async Task GivenNonExistingDirectory_CreateFile_ShouldThrowInvalidOperationException(List<MonsterStats> monsterStats, string path)
        {
            _fileSystem.Setup(f => f.Directory.Exists(It.Is<string>(s => s == path))).Returns(false);
            _fileSystem.Setup(f => f.Path.GetDirectoryName(It.IsAny<string>())).Returns(path);

            Func<Task> action = async () => { await _sut.CreateFile(path, monsterStats); };

            await action.Should()
                .ThrowExactlyAsync<InvalidOperationException>()
                .WithMessage("The directory for the file does not exists");
        }

        [Theory, AutoData]
        public async Task GivenExistingDirectory_CreateFile_ShouldCallFileGenerator(List<MonsterStats> monsterStats, string path)
        {
            var strategy = new Mock<IFileGeneratorStrategy>();
            _fileSystem.Setup(f => f.Directory.Exists(It.Is<string>(s => s == path))).Returns(true);
            _fileSystem.Setup(f => f.Path.GetDirectoryName(It.IsAny<string>())).Returns(path);
            _fileSystem.Setup(f => f.Path.GetExtension(It.Is<string>(s => s == path))).Returns(".xml");
            _fileGeneratorStrategyFactory.Setup(x => x.Get(It.Is<string>(s => s == ".xml"))).Returns(strategy.Object);

            await _sut.CreateFile(path, monsterStats);

            strategy.Verify(x => x.CreateFileAsync(It.Is<List<MonsterStats>>(m => m == monsterStats), It.Is<string>(s => s == path)), Times.Once);
        }
    }
}
