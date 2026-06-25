using System;
using System.Media;
using System.Windows.Forms;
//update for final submission

namespace CyberSecurityAwarenessChatBot
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("greeting.wav");
                player.PlaySync();
            }
            catch
            {
                MessageBox.Show("Voice greeting could not be played.");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
