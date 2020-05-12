using DndMonsterStatsGenerator.Service;
using System;
using System.Collections.Generic;
using Moq;
using Xunit;
using DndMonsterStatsGenerator.Entities.Business;
using System.Threading.Tasks;
using FluentAssertions;
using AutoFixture.Xunit2;
using DndMonsterStatsGenerator.Factory.MonsterStatsGenerator;
using Microsoft.Extensions.Logging;
using DndMonsterStatsGenerator.Entities.Options;
using DndMonsterStatsGenerator.Strategy.MonsterStatsGenerator;

namespace DndMonsterStatsGenerator.Tests.Service
{
    public class MonsterStatsCreatorServiceTests
    {
        private readonly MonsterStatsCreatorService _sut;
        private readonly Mock<IMonsterStatsGeneratorStrategyFactory> _monsterStatsGeneratorStrategyFactory;
        private readonly Mock<ILogger<IMonsterStatsCreatorService>> _logger;
        private readonly Mock<IFileCreatorService> _fileCreatorService;

        public MonsterStatsCreatorServiceTests()
        {
            _monsterStatsGeneratorStrategyFactory = new Mock<IMonsterStatsGeneratorStrategyFactory>();
            _logger = new Mock<ILogger<IMonsterStatsCreatorService>>();
            _fileCreatorService = new Mock<IFileCreatorService>();
            _sut = new MonsterStatsCreatorService(_monsterStatsGeneratorStrategyFactory.Object, _logger.Object, _fileCreatorService.Object);
        }

        [Theory, AutoData]
        public async Task GivenErrorInMonsterStatsGeneratorStrategyFactory_CreateStatsAsync_ShouldReturnErrorAndLog(MonsterCreationOption creationOption)
        {
            _monsterStatsGeneratorStrategyFactory.Setup(m => m.Get(It.Is<MonsterCreationOption>(o => o == creationOption))).Throws(new NotImplementedException());
            Func<object, Type, bool> state = (v, t) => v.ToString().CompareTo("Something went wrong...") == 0;

            var actual = await _sut.CreateStatsAsync(creationOption);

            actual.Should().Be(-1);
            _logger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Debug),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => state(v, t)),
                    It.IsAny<NotImplementedException>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),Times.Once);
        }

        [Theory, AutoData]
        public async Task GivenValidCreationOptions_CreateStatsAsync_ShouldReturnOkStatus(MonsterCreationOption creationOption, Mock<IMonsterStatsGeneratorStrategy> monsterStatsGeneratorStrategy, MonsterStats monsterStats)
        {
            creationOption.WriteToFile = false;
            monsterStatsGeneratorStrategy.Setup(m => m.GenerateMonsterStats(It.Is<MonsterCreationOption>(c => c == creationOption))).Returns(monsterStats);
            _monsterStatsGeneratorStrategyFactory.Setup(m => m.Get(It.Is<MonsterCreationOption>(o => o == creationOption))).Returns(monsterStatsGeneratorStrategy.Object);

            var actual = await _sut.CreateStatsAsync(creationOption);

            actual.Should().Be(0);
            _fileCreatorService.Verify(c => c.CreateFile(It.IsAny<string>(), It.IsAny<List<MonsterStats>>()), Times.Never);
        }

        [Theory, AutoData]
        public async Task GivenValidCreationOptionsAndWriteToFile_CreateStatsAsync_ShouldReturnOkStatusAndCallCreateFile(MonsterCreationOption creationOption, Mock<IMonsterStatsGeneratorStrategy> monsterStatsGeneratorStrategy, MonsterStats monsterStats)
        {
            creationOption.WriteToFile = true;
            monsterStatsGeneratorStrategy.Setup(m => m.GenerateMonsterStats(It.Is<MonsterCreationOption>(c => c == creationOption))).Returns(monsterStats);
            _monsterStatsGeneratorStrategyFactory.Setup(m => m.Get(It.Is<MonsterCreationOption>(o => o == creationOption))).Returns(monsterStatsGeneratorStrategy.Object);

            var actual = await _sut.CreateStatsAsync(creationOption);

            actual.Should().Be(0);
            _fileCreatorService.Verify(c => c.CreateFile(It.IsAny<string>(), It.IsAny<List<MonsterStats>>()), Times.Once);
        }
    }
}
