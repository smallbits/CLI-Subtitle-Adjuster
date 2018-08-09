using SubtitlesLibrary;
using System;

namespace SubtitleAdjuster
{
    static class SubtitleController
    {
        public static string HelpMessage { get; set; }
        public static string ErrorMessage { get; set; }
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
            throw new NotImplementedException();
        }
        private static void PrintError()
        {
            throw new NotImplementedException();
        }
        private static bool ComfirmOverride()
        {
            throw new NotImplementedException();
        }
        private static void WriteFile()
        {
            throw new NotImplementedException();
        }
    }
    public delegate void DoTasks();
}
