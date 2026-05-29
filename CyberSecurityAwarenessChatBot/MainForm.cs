using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CyberSecurityAwarenessChatBot
{


    public partial class MainForm : Form
    {
        private Random rand = new Random();
        private string currentTopic = "";
        private string userName = "";
        private string userInterest = "";


        private string GetResponse(string message)
        {

            message = message.ToLower();

            // SENTIMENT
            if (message.Contains("worried"))
                return "It's completely understandable to feel that way. Let me help you stay safe.";

            if (message.Contains("curious"))
                return "That's great curiosity! Cybersecurity is very important.";

            if (message.Contains("frustrated"))
                return "I understand. I'll simplify things for you.";

            // MEMORY INPUT
            if (message.Contains("my name is"))
            {
                userName = message.Replace("my name is", "").Trim();
                return "Nice to meet you, " + userName + "!";
            }

            if (message.Contains("i'm interested in"))
            {
                userInterest = message.Replace("i'm interested in", "").Trim();
                return "Great! I'll remember that you're interested in " + userInterest + ".";
            }

            // FOLLOW-UP QUESTIONS
            if (message.Contains("tell me more") ||
                message.Contains("explain more") ||
                message.Contains("another tip") ||
                message.Contains("continue"))
            {
                if (currentTopic == "password")
                    return "Another password tip: enable two-factor authentication.";

                if (currentTopic == "scam")
                    return "Never trust urgent messages asking for money or passwords.";

                if (currentTopic == "privacy")
                    return "Regularly review your app permissions.";

                if (currentTopic == "phishing")
                    return "Always check links before clicking them.";

                return "What topic would you like more help with?";
            }

            // KEYWORDS
            if (message.Contains("password"))
            {
                currentTopic = "password";
                return "Use strong, unique passwords and avoid reusing them.";
            }

            if (message.Contains("scam"))
            {
                currentTopic = "scam";
                return "Be careful of scams and never share personal information.";
            }

            if (message.Contains("privacy"))
            {
                currentTopic = "privacy";
                return "Protect your privacy by reviewing your settings regularly.";
            }

            // RANDOM PHISHING
            if (message.Contains("phishing"))
            {
                currentTopic = "phishing";

                List<string> responses = new List<string>
        {
            "Be careful of phishing emails asking for personal info.",
            "Always check the sender before clicking links.",
            "Scammers often pretend to be trusted companies.",
            "Never enter passwords on suspicious websites."
        };

                Random rand = new Random();
                return responses[rand.Next(responses.Count)];
            }

            // ✔ FINAL FALLBACK (THIS FIXES YOUR ERROR)
            return "I'm not sure I understand. Can you rephrase?";
        }

        public MainForm()
        {
            InitializeComponent();
            rtbChat.AppendText("CyberSecurity Bot: Hello! Ask me about passwords, scams, privacy, or phishing."
       + Environment.NewLine + Environment.NewLine);
        }
        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string userMessage = txtInput.Text ??"";

            if (string.IsNullOrWhiteSpace(userMessage))
                return;

            rtbChat.AppendText("You: " + userMessage + Environment.NewLine);

            string response = GetResponse(userMessage);

            rtbChat.AppendText("Bot: " + response + Environment.NewLine + Environment.NewLine);

            txtInput.Clear();
            rtbChat.AppendText("You: " + userMessage + Environment.NewLine);
            rtbChat.AppendText("Bot: " + response + Environment.NewLine + Environment.NewLine);

            // AUTO SCROLL (IMPORTANT)
            rtbChat.SelectionStart = rtbChat.Text.Length;
            rtbChat.ScrollToCaret();

            txtInput.Clear();
            txtInput.Focus();

        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtInput_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend.PerformClick();
                e.SuppressKeyPress = true;
            }

        }
    }
}
