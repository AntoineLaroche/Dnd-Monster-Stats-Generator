﻿using Xunit;
using AutoFixture;
using KellermanSoftware.CompareNetObjects;
using DndMonsterStatsGenerator.Strategy;
using DndMonsterStatsGenerator.Entities.Options;
using DndMonsterStatsGenerator.Entities.Business;

namespace DndMonsterStatsGenerator.Tests.Strategy
{
    public class MonsterWithCRZeroStatsGeneratorStrategyTests
    {
        private readonly Fixture _fixture;
        private readonly CompareLogic _compareLogic;
        private readonly MonsterWithCRZeroStatsGeneratorStrategy _sut;

        public MonsterWithCRZeroStatsGeneratorStrategyTests()
        {
            _fixture = new Fixture();
            _compareLogic = new CompareLogic();
            _sut = new MonsterWithCRZeroStatsGeneratorStrategy();
        }

        [Fact]
        public void GivenMonsterOptionsWithCRZero_GenerateMonsterStats_ShouldCreateMonsterWithGoodStats()
        {
            var monsterCreationOptions = _fixture.Build<MonsterCreationOption>().With(o => o.CR, 0.125).Create();
            var expected = new MonsterStats
            {
                AC = 12,
                HP = 3,
                Attack = 2,
                Damage = 1,
                DC = 9,
                Save = 1
            };

            var result = _sut.GenerateMonsterStats(monsterCreationOptions);

            var compareResult = _compareLogic.Compare(expected, result);
            Assert.True(compareResult.AreEqual);
        }
    }
}