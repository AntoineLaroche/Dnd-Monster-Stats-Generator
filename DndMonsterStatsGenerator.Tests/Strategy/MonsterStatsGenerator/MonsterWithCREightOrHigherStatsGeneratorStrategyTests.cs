using Xunit;
using AutoFixture;
using FluentAssertions;
using DndMonsterStatsGenerator.Entities.Options;
using DndMonsterStatsGenerator.Entities.Business;
using System.Collections.Generic;
using DndMonsterStatsGenerator.Strategy.MonsterStatsGenerator;

namespace DndMonsterStatsGenerator.Tests.Strategy.MonsterStatsGenerator
{
    public class MonsterWithCREightOrHigherStatsGeneratorStrategyTests
    {
        private readonly Fixture _fixture;
        private readonly MonsterWithCREightOrHigherStatsGeneratorStrategy _sut;

        public MonsterWithCREightOrHigherStatsGeneratorStrategyTests()
        {
            _fixture = new Fixture();
            _sut = new MonsterWithCREightOrHigherStatsGeneratorStrategy();
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
                    new object[] { 8, 15, 120, 8, 40, 15, 7 },
                    new object[] { 10, 16, 150, 9, 50, 16, 8 },
                    new object[] { 26, 21, 390, 17, 130, 24, 16 }
                };
            }
        }
    }
}
