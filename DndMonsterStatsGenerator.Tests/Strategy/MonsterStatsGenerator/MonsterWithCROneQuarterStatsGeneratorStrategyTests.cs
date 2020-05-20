#nullable enable
using Xunit;
using AutoFixture;
using FluentAssertions;
using DndMonsterStatsGenerator.Entities.Options;
using DndMonsterStatsGenerator.Entities.Business;
using DndMonsterStatsGenerator.Strategy.MonsterStatsGenerator;

namespace DndMonsterStatsGenerator.Tests.Strategy.MonsterStatsGenerator
{
    public class MonsterWithCROneQuarterStatsGeneratorStrategyTests
    {
        private readonly Fixture _fixture;
        private readonly MonsterWithCROneQuarterStatsGeneratorStrategy _sut;

        public MonsterWithCROneQuarterStatsGeneratorStrategyTests()
        {
            _fixture = new Fixture();
            _sut = new MonsterWithCROneQuarterStatsGeneratorStrategy();
        }

        [Fact]
        public void GivenMonsterOptionsWithCROneQuarter_GenerateMonsterStats_ShouldCreateMonsterWithGoodStats()
        {
            var monsterCreationOptions = _fixture.Build<MonsterCreationOption>().With(o => o.CR, 0.25).Create();
            var expectedMonsterStats = new MonsterStats
            {
                AC = 13,
                HP = 15,
                Attack = 3,
                Damage = 5,
                DC = 10,
                Save = 2
            };

            var result = _sut.GenerateMonsterStats(monsterCreationOptions);

            result.Should().BeEquivalentTo(expectedMonsterStats);
        }
    }
}
