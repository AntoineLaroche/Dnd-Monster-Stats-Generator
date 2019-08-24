using CommandLine;
using System.ComponentModel.DataAnnotations;

namespace DndMonsterStatsGenerator.Entities.Options
{
    /// <summary>
    /// test
    /// </summary>
    [Verb("create", HelpText = "Create a monster stats according to the cr")]
    public class MonsterCreationOption
    {

        [Option('c', "challengeRating",
            HelpText = "The challenge rating relating to the monster"),
            Required]
        public double CR { get; set; }
    }
}
