using CommandLine;
using CommandLine.Text;
using System.ComponentModel.DataAnnotations;

namespace DndMonsterStatsGenerator
{
    /// <summary>
    /// test
    /// </summary>
    [Verb("create", HelpText = "Create a monster stats according to the cr")]
    public class Create
    {

        [Option('c', "challengeRating",
            HelpText = "The challenge rating relating to the monster"),
            Required]
        public double CR { get; set; }
    }
}
