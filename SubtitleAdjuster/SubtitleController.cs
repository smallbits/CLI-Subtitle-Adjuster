using System;
using System.IO;
using SubtitlesLibrary;

namespace SubtitleAdjuster
{
    delegate void DoTasks();

    static class SubtitleController
    {
        public static string HelpMessage { get; } = "Help message";
        public static string ErrorMessage { get; } = "Error message";

        public static string InputFile { get; set; }
        public static string OutputFile { get; set; }
        public static string InFileExtension { get; set; }
        public static string OutFileExtension { get; set; }

        public static Subtitle SubtitleInstance { get; set; }
        public static bool AdjustType { get; set; }
        public static TimeSpan AdjustAmount { get; set; }
        public static bool OverrideFile { get; set; }
        public static DoTasks DoAppTasks { get; set; }

        private static void PrintHelp()
        {
            Console.WriteLine(HelpMessage);
        }
        private static void PrintError()
        {
            Console.WriteLine(ErrorMessage);
            PrintHelp();
        }
        private static bool ComfirmOverride()
        {
            Console.WriteLine("Output file not specified, type \"yes\" if you want to override current one:");
            return string.Equals(Console.ReadLine(), "yes", StringComparison.CurrentCultureIgnoreCase);
        }
        private static void WriteFile()
        {
            SubtitleInstance.Adjust(AdjustAmount);
            File.WriteAllText(OutputFile, SubtitleInstance.ToString());
        }
        public static DoTasks ParseInput(string[] input)
        {
            if (input == null) return PrintError;
            if (string.Equals(input[0], "help", StringComparison.CurrentCultureIgnoreCase)) return PrintHelp;
            if (CheckInputFile(input[0]) == false) return PrintError;
            if (input.Length <= 1) return PrintError;
            if (input[1].Equals("hastened", StringComparison.CurrentCultureIgnoreCase) || input[1].Equals("delayed", StringComparison.CurrentCultureIgnoreCase)) OverrideFile = ComfirmOverride();
            if (OverrideFile)
            {
                OutputFile = InputFile;
                OutFileExtension = InFileExtension;
            }
            else SetOutput(input[1]);
            if (input.Length <= 2) return PrintError;
            SubtitleInstance = SubtitleFactory.Create(InFileExtension, File.ReadAllText(InputFile));
            int index = OverrideFile ? 1 : 2;
            if (input[index].Equals("hastened", StringComparison.CurrentCultureIgnoreCase)) AdjustType = false;
            else if (input[index].Equals("delayed", StringComparison.CurrentCultureIgnoreCase)) AdjustType = true;
            else return PrintError;
            AdjustAmount = TimeSpan.Parse(input[index + 1]);
            if (AdjustType == false) AdjustAmount = AdjustAmount.Negate();
            return WriteFile;
        }
        private static bool CheckInputFile(string path)
        {
            if (File.Exists(path))
            {
                InputFile = path;
                InFileExtension = Path.GetExtension(path);
                return true;
            }
            return false;
        }
        private static void SetOutput(string path)
        {
            OutputFile = path;
            OutFileExtension = Path.GetExtension(path);
        }
        
    }
}
