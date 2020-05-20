#nullable enable
using Xunit;
using AutoFixture;
using FluentAssertions;
using DndMonsterStatsGenerator.Entities.Options;
using DndMonsterStatsGenerator.Entities.Business;
using System.Collections.Generic;
using DndMonsterStatsGenerator.Strategy.MonsterStatsGenerator;

namespace DndMonsterStatsGenerator.Tests.Strategy.MonsterStatsGenerator
{
    public class MonsterWithCRBetweenTwoAndSevenStatsGeneratorStrategyTests
    {
        private readonly Fixture _fixture;
        private readonly MonsterWithCRBetweenTwoAndSevenStatsGeneratorStrategy _sut;

        public MonsterWithCRBetweenTwoAndSevenStatsGeneratorStrategyTests()
        {
            _fixture = new Fixture();
            _sut = new MonsterWithCRBetweenTwoAndSevenStatsGeneratorStrategy();
        }

        [Theory, MemberData(nameof(ExpectedMonsterStats))]
        public void GiveMonsterBetweenCRTwoAndSeven_GenerateMonsterStats_ShouldGenerateGoodStats(double cr, int expectedAC, int expectedHP, int expectedAttack, int expectedDamage, int expectedDC, int expectedSave)
        {
            var monsterCreationOptions = _fixture.Build<MonsterCreationOption>().With(o => o.CR, cr).Create();
            var expectedMonsterStats = new MonsterStats
            {
                AC = expectedAC,
                HP = expectedHP,
                Attack = expectedAttack,
                Damage = expectedDamage,
                Save = expectedSave,
                DC = expectedDC
            };

            var result = _sut.GenerateMonsterStats(monsterCreationOptions);

            result.Should().BeEquivalentTo(expectedMonsterStats);
        }

        public static IEnumerable<object[]> ExpectedMonsterStats
        {
            get
            {
                return new[]
                {
                    new object[] { 2, 13, 45, 5, 15, 12, 4 },
                    new object[] { 3, 14, 60, 5, 20, 12, 4 },
                    new object[] { 4, 14, 75, 6, 25, 13, 5 },
                    new object[] { 5, 14, 90, 6, 30, 13, 5 },
                    new object[] { 6, 15, 105, 7, 35, 14, 6 },
                    new object[] { 7, 15, 120, 7, 40, 14, 6 }
                };
            }
        }
    }
}
