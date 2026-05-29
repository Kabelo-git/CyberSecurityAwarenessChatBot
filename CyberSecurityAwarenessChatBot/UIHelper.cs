using System;

namespace CyberSecurityChatbot
{
    // UIHelper handles display elements such as ASCII art and UI formatting

    public static class UIHelper
    {
        public static void DisplayLogo()
        {
            Console.WriteLine("   ____            _                     ____        _   ");
            Console.WriteLine("  / ___| ___   ___| | _____ _ __        | __ )  ___ | |_ ");
            Console.WriteLine(" | |    / _ \\ / __| |/ / _ \\ '__|_____  |  _ \\ / _ \\| __|");
            Console.WriteLine(" | |___| (_) | (__|   <  __/ | |_____| | |_) | (_) | |_ ");
            Console.WriteLine("  \\____|\\___/ \\___|_|\\_\\___|_|         |____/ \\___/ \\__|");

            Console.WriteLine();
            Console.WriteLine("        CYBERSECURITY AWARENESS BOT");
            Console.WriteLine();
        }
    }
}