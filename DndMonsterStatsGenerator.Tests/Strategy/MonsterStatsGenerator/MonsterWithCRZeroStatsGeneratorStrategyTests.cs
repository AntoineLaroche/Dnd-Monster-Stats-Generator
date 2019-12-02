using Xunit;
using AutoFixture;
using FluentAssertions;
using DndMonsterStatsGenerator.Entities.Options;
using DndMonsterStatsGenerator.Entities.Business;
using DndMonsterStatsGenerator.Strategy.MonsterStatsGenerator;

namespace DndMonsterStatsGenerator.Tests.Strategy.MonsterStatsGenerator
{
    public class MonsterWithCRZeroStatsGeneratorStrategyTests
    {
        private readonly Fixture _fixture;
        private readonly MonsterWithCRZeroStatsGeneratorStrategy _sut;

        public MonsterWithCRZeroStatsGeneratorStrategyTests()
        {
            _fixture = new Fixture();
            _sut = new MonsterWithCRZeroStatsGeneratorStrategy();
        }

        [Fact]
        public void GivenMonsterOptionsWithCRZero_GenerateMonsterStats_ShouldCreateMonsterWithGoodStats()
        {
            var monsterCreationOptions = _fixture.Build<MonsterCreationOption>().With(o => o.CR, 0.125).Create();
            var expectedMonsterStats = new MonsterStats
            {
                AC = 12,
                HP = 3,
                Attack = 2,
                Damage = 1,
                DC = 9,
                Save = 1
            };

            var result = _sut.GenerateMonsterStats(monsterCreationOptions);

            result.Should().BeEquivalentTo(expectedMonsterStats);
        }
    }
}
