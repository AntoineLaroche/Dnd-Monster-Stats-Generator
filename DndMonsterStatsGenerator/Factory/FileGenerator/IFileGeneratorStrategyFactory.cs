#nullable enable
using DndMonsterStatsGenerator.Strategy.FileGenerator;

namespace DndMonsterStatsGenerator.Factory.FileGenerator
{
    public interface IFileGeneratorStrategyFactory
    {
        IFileGeneratorStrategy Get(string fileExtension);
    }
}
