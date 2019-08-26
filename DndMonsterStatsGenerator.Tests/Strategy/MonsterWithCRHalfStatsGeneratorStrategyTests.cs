using Xunit;
using AutoFixture;
using KellermanSoftware.CompareNetObjects;
using DndMonsterStatsGenerator.Strategy;
using DndMonsterStatsGenerator.Entities.Options;
using DndMonsterStatsGenerator.Entities.Business;

namespace DndMonsterStatsGenerator.Tests.Strategy
{
    public class MonsterWithCRHalfStatsGeneratorStrategyTests
    {
        private readonly Fixture _fixture;
        private readonly CompareLogic _compareLogic;
        private readonly MonsterWithCRHalfStatsGeneratorStrategy _sut;
        public MonsterWithCRHalfStatsGeneratorStrategyTests()
        {
            _fixture = new Fixture();
            _compareLogic = new CompareLogic();
            _sut = new MonsterWithCRHalfStatsGeneratorStrategy();
        }

        [Fact]
        public void GivenMonsterOptionsWithCRHalf_GenerateMonsterStats_ShouldCreateMonsterWithGoodStats()
        {
            var monsterCreationOptions = _fixture.Build<MonsterCreationOption>().With(o => o.CR, 0.5).Create();
            var expected = new MonsterStats
            {
                AC = 13,
                HP = 24,
                Attack = 4,
                Damage = 8,
                DC = 11,
                Save = 3
            };

            var result = _sut.GenerateMonsterStats(monsterCreationOptions);

            var compareResult = _compareLogic.Compare(expected, result);
            Assert.True(compareResult.AreEqual);
        }
    }
}
