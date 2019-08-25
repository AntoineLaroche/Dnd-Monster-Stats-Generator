using Xunit;
using AutoFixture;
using KellermanSoftware.CompareNetObjects;
using DndMonsterStatsGenerator.Strategy;
using DndMonsterStatsGenerator.Entities.Options;
using DndMonsterStatsGenerator.Entities.Business;

namespace DndMonsterStatsGenerator.Tests.Strategy
{
    public class MonsterWithCROneEightStatsGeneratorStrategyTests
    {
        private readonly Fixture _fixture;
        private readonly CompareLogic _compareLogic;
        private readonly MonsterWithCROneEightStatsGeneratorStrategy _sut;

        public MonsterWithCROneEightStatsGeneratorStrategyTests()
        {
            _fixture = new Fixture();
            _compareLogic = new CompareLogic();
            _sut = new MonsterWithCROneEightStatsGeneratorStrategy();
        }

        [Fact]
        public void GivenMonsterOptionsWithCREight_GenerateMonsterStats_ShouldCreateMonsterWithGoodStats()
        {
            var monsterCreationOptions = _fixture.Build<MonsterCreationOption>().With(o => o.CR, 0.125).Create();
            var expected = new MonsterStats
            {
                AC = 12,
                HP = 9,
                Attack = 3,
                Damage = 3,
                DC = 10,
                Save = 2
            };

            var result = _sut.GenerateMonsterStats(monsterCreationOptions);

            var compareResult = _compareLogic.Compare(expected, result);
            Assert.True(compareResult.AreEqual);
        }
    }
}
