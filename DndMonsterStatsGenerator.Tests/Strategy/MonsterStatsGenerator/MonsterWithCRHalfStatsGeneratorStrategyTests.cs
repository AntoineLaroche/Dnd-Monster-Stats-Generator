using Xunit;
using AutoFixture;
using FluentAssertions;
using DndMonsterStatsGenerator.Entities.Options;
using DndMonsterStatsGenerator.Entities.Business;
using DndMonsterStatsGenerator.Strategy.MonsterStatsGenerator;

namespace DndMonsterStatsGenerator.Tests.Strategy.MonsterStatsGenerator
{
    public class MonsterWithCRHalfStatsGeneratorStrategyTests
    {
        private readonly Fixture _fixture;
        private readonly MonsterWithCRHalfStatsGeneratorStrategy _sut;

        public MonsterWithCRHalfStatsGeneratorStrategyTests()
        {
            _fixture = new Fixture();
            _sut = new MonsterWithCRHalfStatsGeneratorStrategy();
        }

        [Fact]
        public void GivenMonsterOptionsWithCRHalf_GenerateMonsterStats_ShouldCreateMonsterWithGoodStats()
        {
            var monsterCreationOptions = _fixture.Build<MonsterCreationOption>().With(o => o.CR, 0.5).Create();
            var expectedMonsterStats = new MonsterStats
            {
                AC = 13,
                HP = 24,
                Attack = 4,
                Damage = 8,
                DC = 11,
                Save = 3
            };

            var result = _sut.GenerateMonsterStats(monsterCreationOptions);

            result.Should().BeEquivalentTo(expectedMonsterStats);
        }
    }
}
