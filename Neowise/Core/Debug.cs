using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neowise.Core
{
    public class Debug
    {
        public static void Log (string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[NeowiseEngine_dev_log] {message}");
        }
        public static void LogWarning (string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[NeowiseEngine_dev_warning] {message}");
        }
        public static void LogError (string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[NeowiseEngine_dev_error] {message}");
        }
        public static void LogTechniq (string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[NeowiseEngine_dev_tech] {message}");
        }
    }
}
