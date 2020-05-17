# Dnd-Monster-Stats-Generator
Command line tool to create dnd fifth edition stats according to their challenge ratings

## Goal
This very small app is a (very niche) useful demo for: 
* some nuget package uses
* the uses of the Stategy and Factory design patterns
* some C# 8.0 feature uses.

It's purpose is to generate on the fly the statistics for a monster for the Dungeon and Dragons roleplaying game according to a challenge rating.
The formulas used to generate the statistics are described and on this [blog](http://blogofholding.com/?p=7338#together)

## How to use
It's a command line interface application. It only has one command create or -c.
The command has only one obligatory parameter which is the challenge rating.
The challenge rating is a positive number which use to generate the statistics of a dnd monster.
The command display the generated stats in the console windows.

The write optional parameter will create a file wich contains the generated stats of the monster.
It must be used with the path optional parameter which must be a valid path and a valid file name and extension.
The write command supports these file extensions
* csv
* json
* xml
* yaml

## Exemple of use
> dotnet .\DndMonsterStatsGenerator.dll -c 0.

The command above will generate the stats of monster with a challenge rating  of 0 and display the stats in the console

> dotnet .\DndMonsterStatsGenerator.dll -c 7 -w -p "C:\Users\Public\test.json".

The command above will generate the stats of monster with a challenge rating  of 7, display the stats in the console and write the stats to a .json file named test in the supplied path C\Users 
\Public
