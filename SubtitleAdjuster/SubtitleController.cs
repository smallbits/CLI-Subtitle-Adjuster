using System;
using System.IO;
using SubtitlesLibrary;

namespace SubtitleAdjuster
{
    static class SubtitleController
    {
        public static string HelpMessage { get; set; }
        public static string ErrorMessage { get; set; }

        public static string InputFile { get; set; }
        public static string OutputFile { get; set; }
        public static string FileExtension { get; set; }

        public static Subtitle SubtitleInstance { get; set; }
        public static bool AdjustType { get; set; }
        public static TimeSpan AdjustAmount { get; set; }

        public static DoTasks DoAppTasks { get; set; }

        public static void ParseInput(string input)
        {
            throw new NotImplementedException();
        }
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
            File.WriteAllLines(file)
        }
    }
    public delegate void DoTasks();
}
