#nullable enable
using Xunit;
using AutoFixture;
using FluentAssertions;
using DndMonsterStatsGenerator.Entities.Options;
using DndMonsterStatsGenerator.Entities.Business;
using DndMonsterStatsGenerator.Strategy.MonsterStatsGenerator;

namespace DndMonsterStatsGenerator.Tests.Strategy.MonsterStatsGenerator
{
    public class MonsterWithCROneEightStatsGeneratorStrategyTests
    {
        private readonly Fixture _fixture;
        private readonly MonsterWithCROneEightStatsGeneratorStrategy _sut;

        public MonsterWithCROneEightStatsGeneratorStrategyTests()
        {
            _fixture = new Fixture();
            _sut = new MonsterWithCROneEightStatsGeneratorStrategy();
        }

        [Fact]
        public void GivenMonsterOptionsWithCREight_GenerateMonsterStats_ShouldCreateMonsterWithGoodStats()
        {
            var monsterCreationOptions = _fixture.Build<MonsterCreationOption>().With(o => o.CR, 0.125).Create();
            var expectedMonsterStats = new MonsterStats
            {
                AC = 12,
                HP = 9,
                Attack = 3,
                Damage = 3,
                DC = 10,
                Save = 2
            };

            var result = _sut.GenerateMonsterStats(monsterCreationOptions);

            result.Should().BeEquivalentTo(expectedMonsterStats);
        }
    }
}
