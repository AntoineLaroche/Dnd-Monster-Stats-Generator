using Xunit;
using AutoFixture;
using FluentAssertions;
using DndMonsterStatsGenerator.Strategy;
using DndMonsterStatsGenerator.Entities.Options;
using DndMonsterStatsGenerator.Entities.Business;

namespace DndMonsterStatsGenerator.Tests.Strategy
{
    public class MonsterWithCROneStatsGeneratorStrategyTests
    {
        private readonly Fixture _fixture;
        private readonly MonsterWithCROneStatsGeneratorStrategy _sut;

        public MonsterWithCROneStatsGeneratorStrategyTests()
        {
            _fixture = new Fixture();
            _sut = new MonsterWithCROneStatsGeneratorStrategy();
        }

        [Fact]
        public void GivenMonsterOptionsWithCROne_GenerateMonsterStats_ShouldCreateMonsterWithGoodStats()
        {
            var monsterCreationOptions = _fixture.Build<MonsterCreationOption>().With(o => o.CR, 1).Create();
            var expectedMonsterStats = new MonsterStats
            {
                AC = 13,
                HP = 30,
                Attack = 4,
                Damage = 10,
                DC = 11,
                Save = 3
            };

            var result = _sut.GenerateMonsterStats(monsterCreationOptions);

            result.Should().BeEquivalentTo(expectedMonsterStats);
        }
    }
}
