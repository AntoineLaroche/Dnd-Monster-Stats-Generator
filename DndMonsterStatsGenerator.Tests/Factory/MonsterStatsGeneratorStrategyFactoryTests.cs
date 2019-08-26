using AutoFixture;
using DndMonsterStatsGenerator.Entities.Options;
using DndMonsterStatsGenerator.Factory;
using DndMonsterStatsGenerator.Strategy;
using System;
using Xunit;

namespace DndMonsterStatsGenerator.Tests.Factory
{
    public class MonsterStatsGeneratorStrategyFactoryTests
    {
        private readonly Fixture _fixture;
        private readonly MonsterStatsGeneratorStrategyFactory _sut;

        public MonsterStatsGeneratorStrategyFactoryTests()
        {
            _fixture = new Fixture();
            _sut = new MonsterStatsGeneratorStrategyFactory();
        }

        [Theory]
        [InlineData(8)]
        [InlineData(10)]
        [InlineData(100)]
        public void GivenMonsterOptionsWithCREight_Get_ShouldReturnGoodStrategy(double challengeRating)
        {
            var monsterCreationOptions = _fixture.Build<MonsterCreationOption>().With(o => o.CR, challengeRating).Create();

            var result = _sut.Get(monsterCreationOptions);

            Assert.IsType<MonsterWithCREightOrHigherStatsGeneratorStrategy>(result);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        public void GivenMonsterOptionsWithCRBetweenTwoAndSeven_Get_ShouldReturnGoodStrategy(double challengeRating)
        {
            var monsterCreationOptions = _fixture.Build<MonsterCreationOption>().With(o => o.CR, challengeRating).Create();

            var result = _sut.Get(monsterCreationOptions);

            Assert.IsType<MonsterWithCRBetweenTwoAndSevenStatsGeneratorStrategy>(result);
        }

        [Fact]
        public void GivenMonsterOptionsWithCROne_Get_ShouldReturnGoodStrategy()
        {
            var monsterCreationOptions = _fixture.Build<MonsterCreationOption>().With(o => o.CR, 1).Create();

            var result = _sut.Get(monsterCreationOptions);

            Assert.IsType<MonsterWithCROneStatsGeneratorStrategy>(result);
        }

        [Fact]
        public void GivenMonsterOptionsWithCRHalf_Get_ShouldReturnGoodStrategy()
        {
            var monsterCreationOptions = _fixture.Build<MonsterCreationOption>().With(o => o.CR, 0.5).Create();

            var result = _sut.Get(monsterCreationOptions);

            Assert.IsType<MonsterWithCRHalfStatsGeneratorStrategy>(result);
        }

        [Fact]
        public void GivenMonsterOptionsWithCROneQuarter_Get_ShouldReturnGoodStrategy()
        {
            var monsterCreationOptions = _fixture.Build<MonsterCreationOption>().With(o => o.CR, 0.25).Create();

            var result = _sut.Get(monsterCreationOptions);

            Assert.IsType<MonsterWithCROneQuarterStatsGeneratorStrategy>(result);
        }

        [Fact]
        public void GivenMonsterOptionsWithCROneEight_Get_ShouldReturnGoodStrategy()
        {
            var monsterCreationOptions = _fixture.Build<MonsterCreationOption>().With(o => o.CR, 0.125).Create();

            var result = _sut.Get(monsterCreationOptions);

            Assert.IsType<MonsterWithCROneEightStatsGeneratorStrategy>(result);
        }

        [Fact]
        public void GivenMonsterOptionsWithCRZero_Get_ShouldReturnGoodStrategy()
        {
            var monsterCreationOptions = _fixture.Build<MonsterCreationOption>().With(o => o.CR, 0).Create();

            var result = _sut.Get(monsterCreationOptions);

            Assert.IsType<MonsterWithCRZeroStatsGeneratorStrategy>(result);
        }

        [Fact]
        public void GivenMonsterOptionsWithNotImplementedCR_Get_ShouldThrowException()
        {
            var monsterCreationOptions = _fixture.Build<MonsterCreationOption>().With(o => o.CR, 0.3333).Create();

           Assert.Throws<NotImplementedException>(() => _sut.Get(monsterCreationOptions));
        }
    }
}
