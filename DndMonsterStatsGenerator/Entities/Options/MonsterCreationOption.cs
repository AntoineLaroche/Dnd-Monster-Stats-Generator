﻿#nullable enable
using CommandLine;
using System.ComponentModel.DataAnnotations;

namespace DndMonsterStatsGenerator.Entities.Options
{
    [Verb("create", HelpText = "Create a monster stats according to the cr")]
    public class MonsterCreationOption
    {

        [Option('c', "challengeRating", HelpText = "The challenge rating relating to the monster", Required = true)]
        public double CR { get; set; }

        [Option('w', "writeToFile", Required = false, HelpText = "Write to a file the monster")]
        public bool WriteToFile { get; set; }

        [Option('p', "path", Required = false, HelpText = "Path to the file to create. Must be use with parameter w")]
        public string? Path { get; set; }
    }
}
