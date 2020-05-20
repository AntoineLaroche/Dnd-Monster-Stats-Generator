#nullable enable
using FluentAssertions;
using System;
using Xunit;
using DndMonsterStatsGenerator.Strategy.FileGenerator;
using DndMonsterStatsGenerator.Factory.FileGenerator;

namespace DndMonsterStatsGenerator.Tests.Factory.MonsterStatsGenerator
{
    public class FileGeneratorStrategyFactoryTests
    {
        private readonly FileGeneratorStrategyFactory _sut;

        public FileGeneratorStrategyFactoryTests()
        {
            _sut = new FileGeneratorStrategyFactory();
        }

        [Fact]
        public void GivenCsvFileExtension_Get_ShouldReturnCsvStrateyType()
        {
            var result = _sut.Get(".csv");

            result.Should().BeOfType<CsvStrategy>();
        }

        [Fact]
        public void GivenJsonFileExtension_Get_ShouldReturnCsvStrateyType()
        {
            var result = _sut.Get(".json");

            result.Should().BeOfType<JsonStrategy>();
        }

        [Fact]
        public void GivenXmlFileExtension_Get_ShouldReturnCsvStrateyType()
        {
            var result = _sut.Get(".xml");

            result.Should().BeOfType<XmlStrategy>();
        }

        [Theory]
        [InlineData(".yaml")]
        [InlineData(".yml")]
        public void GivenYamlFileExtension_Get_ShouldReturnCsvStrateyType(string fileExtension)
        {
            var result = _sut.Get(fileExtension);

            result.Should().BeOfType<YamlStrategy>();
        }

        [Fact]
        public void GivenNonImplementedFileExtension_Get_ShouldThrowNonImplementedExtension()
        {
            Action act = () => _sut.Get(".doesnotexists");

            act.Should().ThrowExactly<NotImplementedException>();
        }

    }
}
