using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubtitleAdjuster
{
    class Program
    {
        static void Main(string[] args)
        {
            SubtitleController.DoAppTasks = SubtitleController.ParseInput(args);
            SubtitleController.DoAppTasks.Invoke();
        }
    }
}
