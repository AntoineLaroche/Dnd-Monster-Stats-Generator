using AutoFixture;
using FluentAssertions;
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

            result.Should().BeOfType<MonsterWithCREightOrHigherStatsGeneratorStrategy>();
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

            result.Should().BeOfType<MonsterWithCRBetweenTwoAndSevenStatsGeneratorStrategy>();
        }

        [Fact]
        public void GivenMonsterOptionsWithCROne_Get_ShouldReturnGoodStrategy()
        {
            var monsterCreationOptions = _fixture.Build<MonsterCreationOption>().With(o => o.CR, 1).Create();

            var result = _sut.Get(monsterCreationOptions);

            result.Should().BeOfType<MonsterWithCROneStatsGeneratorStrategy>();
        }

        [Fact]
        public void GivenMonsterOptionsWithCRHalf_Get_ShouldReturnGoodStrategy()
        {
            var monsterCreationOptions = _fixture.Build<MonsterCreationOption>().With(o => o.CR, 0.5).Create();

            var result = _sut.Get(monsterCreationOptions);

            result.Should().BeOfType<MonsterWithCRHalfStatsGeneratorStrategy>();
        }

        [Fact]
        public void GivenMonsterOptionsWithCROneQuarter_Get_ShouldReturnGoodStrategy()
        {
            var monsterCreationOptions = _fixture.Build<MonsterCreationOption>().With(o => o.CR, 0.25).Create();

            var result = _sut.Get(monsterCreationOptions);

            result.Should().BeOfType<MonsterWithCROneQuarterStatsGeneratorStrategy>();
        }

        [Fact]
        public void GivenMonsterOptionsWithCROneEight_Get_ShouldReturnGoodStrategy()
        {
            var monsterCreationOptions = _fixture.Build<MonsterCreationOption>().With(o => o.CR, 0.125).Create();

            var result = _sut.Get(monsterCreationOptions);

            result.Should().BeOfType<MonsterWithCROneEightStatsGeneratorStrategy>();
        }

        [Fact]
        public void GivenMonsterOptionsWithCRZero_Get_ShouldReturnGoodStrategy()
        {
            var monsterCreationOptions = _fixture.Build<MonsterCreationOption>().With(o => o.CR, 0).Create();

            var result = _sut.Get(monsterCreationOptions);

            result.Should().BeOfType<MonsterWithCRZeroStatsGeneratorStrategy>();
        }

        [Fact]
        public void GivenMonsterOptionsWithNotImplementedCR_Get_ShouldThrowException()
        {
            var monsterCreationOptions = _fixture.Build<MonsterCreationOption>().With(o => o.CR, 0.3333).Create();

            Action act = () => _sut.Get(monsterCreationOptions);

            act.Should().ThrowExactly<NotImplementedException>();
        }
    }
}
