using Xunit;
using AutoFixture;
using KellermanSoftware.CompareNetObjects;
using DndMonsterStatsGenerator.Strategy;
using DndMonsterStatsGenerator.Entities.Options;
using DndMonsterStatsGenerator.Entities.Business;

namespace DndMonsterStatsGenerator.Tests.Strategy
{
    public class MonsterWithCROneQuarterStatsGeneratorStrategyTests
    {
        private readonly Fixture _fixture;
        private readonly CompareLogic _compareLogic;
        private readonly MonsterWithCROneQuarterStatsGeneratorStrategy _sut;

        public MonsterWithCROneQuarterStatsGeneratorStrategyTests()
        {
            _fixture = new Fixture();
            _compareLogic = new CompareLogic();
            _sut = new MonsterWithCROneQuarterStatsGeneratorStrategy();
        }

        [Fact]
        public void GivenMonsterOptionsWithCROneQuarter_GenerateMonsterStats_ShouldCreateMonsterWithGoodStats()
        {
            var monsterCreationOptions = _fixture.Build<MonsterCreationOption>().With(o => o.CR, 0.25).Create();
            var expected = new MonsterStats
            {
                AC = 13,
                HP = 15,
                Attack = 3,
                Damage = 5,
                DC = 10,
                Save = 2
            };

            var result = _sut.GenerateMonsterStats(monsterCreationOptions);

            var compareResult = _compareLogic.Compare(expected, result);
            Assert.True(compareResult.AreEqual);
        }
    }
}
