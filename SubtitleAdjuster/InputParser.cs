using SubtitlesLibrary;
using System;
using System.IO;
using System.Text;

namespace SubtitleAdjuster
{
    static class InputParser
    {
        static string[] args;
        public static DoTasks ParseFirst(string[] input)
        {
            args = input;
            if (input.Length == 0) return SubtitleController.PrintError;
            string firstArg = input[0];
            if (firstArg.Equals("help", StringComparison.CurrentCultureIgnoreCase)) return SubtitleController.PrintHelp;
            if (input.Length == 1) return SubtitleController.PrintError;
            if (CheckInputFile(firstArg) == false) return SubtitleController.PrintError;
            Console.WriteLine(sr.CurrentEncoding);
            SubtitleController.SubtitleInstance = SubtitleFactory.Create(SubtitleController.InFileExtension, File.ReadAllText(SubtitleController.InputFile));
            return ParseSecond(input[1]);
        }
        private static DoTasks ParseSecond(string input)
        {
            if (args.Length == 2) return SubtitleController.PrintError;
            if (input.Equals("hastened", StringComparison.CurrentCultureIgnoreCase) || input.Equals("delayed", StringComparison.CurrentCultureIgnoreCase))
            {
                if (ComfirmOverride() == false) return SubtitleController.PrintError;
                else
                {
                    SubtitleController.OutputFile = SubtitleController.InputFile;
                    SubtitleController.OutFileExtension = SubtitleController.InFileExtension;
                }
                return ParseThird(input, 2);
            }
            else
            {
                SetOutputFile(input);
                return ParseThird(args[2], 3);
            }
        }
        private static DoTasks ParseThird(string input, int counter)
        {
            if (args.Length == counter) return SubtitleController.PrintError;
            if(SetAdjustmentType(input) == false) return SubtitleController.PrintError;
            return ParseFourth(args[counter]);
        }
        private static DoTasks ParseFourth(string input)
        {
            SubtitleController.AdjustAmount = TimeSpan.Parse(input);
            if (SubtitleController.AdjustType == false) SubtitleController.AdjustAmount = SubtitleController.AdjustAmount.Negate();
            return SubtitleController.WriteFile;
        }
        private static bool CheckInputFile(string path)
        {
            if (File.Exists(path))
            {
                SubtitleController.InputFile = path;
                SubtitleController.InFileExtension = Path.GetExtension(path);
                return true;
            }
            return false;
        }
        private static void SetOutputFile(string path)
        {
            SubtitleController.OutputFile = path;
            SubtitleController.OutFileExtension = path;
        }
        private static bool SetAdjustmentType(string input)
        {
            switch (input.ToLower())
            {
                case "hastened":
                    SubtitleController.AdjustType = false;
                    return true;
                case "delayed":
                    SubtitleController.AdjustType = true;
                    return true;
                default:
                    return false;
            }
        }
        private static bool ComfirmOverride()
        {
            Console.WriteLine("Output file not specified, type \"yes\" if you want to override current one:");
            SubtitleController.OverrideFile = string.Equals(Console.ReadLine(), "yes", StringComparison.CurrentCultureIgnoreCase);
            return SubtitleController.OverrideFile;
        }
    }
}
