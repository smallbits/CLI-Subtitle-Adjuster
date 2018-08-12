using System;
using System.IO;
using SubtitlesLibrary;

namespace SubtitleAdjuster
{
    public delegate void DoTasks();

    public static class SubtitleController
    {
        public static string HelpMessage { get; } = "Help message";
        public static string ErrorMessage { get; } = "Error message";

        public static string InputFile { get; set; }
        public static string OutputFile { get; set; }
        public static string InFileExtension { get; set; }
        public static string OutFileExtension { get; set;
        }

        public static Subtitle SubtitleInstance { get; set; }
        public static bool AdjustType { get; set; }
        public static TimeSpan AdjustAmount { get; set; }
        public static bool OverrideFile { get; set; }
        public static DoTasks DoAppTasks { get; set; }

        public static void PrintHelp()
        {
            Console.WriteLine(HelpMessage);
        }
        public static void PrintError()
        {
            Console.WriteLine(ErrorMessage);
            PrintHelp();
        }
        private static bool ComfirmOverride()
        {
            Console.WriteLine("Output file not specified, type \"yes\" if you want to override current one:");
            return string.Equals(Console.ReadLine(), "yes", StringComparison.CurrentCultureIgnoreCase);
        }
        public static void WriteFile()
        {
            SubtitleInstance.Adjust(AdjustAmount);
            if (OverrideFile) File.Delete(InputFile);
            File.WriteAllText(OutputFile, SubtitleInstance.ToString());
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
