using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CyberSecurityAwarenessChatBot
{
    public partial class MainForm : Form
    {
        private DatabaseHelper db = new DatabaseHelper();
        private string currentTopic = "";
        private string userName = "";
        private string userInterest = "";
        private List<string> activityLog = new List<string>();

        private void LogAction(string action)
        {
            string entry = $"[{DateTime.Now:HH:mm:ss}] {action}";
            activityLog.Add(entry);
        }

        private string GetResponse(string message)
        {
            string lower = message.ToLower();

            // --- ACTIVITY LOG ---
            if (lower.Contains("activity log") || lower.Contains("what have you done") || lower.Contains("show log"))
            {
                if (activityLog.Count == 0)
                    return "No actions recorded yet.";

                int start = Math.Max(0, activityLog.Count - 10);
                var recent = activityLog.GetRange(start, activityLog.Count - start);
                return "Here are my recent actions:\n" + string.Join("\n", recent);
            }

            // --- OPEN TASKS via chat ---
            if (lower.Contains("add task") || lower.Contains("new task") || lower.Contains("create task") ||
                lower.Contains("manage task") || lower.Contains("show task") || lower.Contains("view task") ||
                lower.Contains("my task"))
            {
                LogAction("NLP: User requested task manager via chat.");
                OpenTaskForm();
                return "Opening your Task Assistant now!";
            }
            // --- REMIND ME IN X DAYS ---
            var daysMatch = System.Text.RegularExpressions.Regex.Match(lower, @"remind me in (\d+) days?");
            if (daysMatch.Success)
            {
                int days = int.Parse(daysMatch.Groups[1].Value);
                DateTime reminderDate = DateTime.Now.AddDays(days);
                LogAction($"NLP: Reminder request for {days} days from now ({reminderDate:d}).");
                OpenTaskForm();
                return $"Got it! I'll remind you in {days} days (on {reminderDate:d}). Opening Task Assistant to save it.";
            }

            // --- REMINDER via chat ---
            if (lower.Contains("remind me") || lower.Contains("set a reminder") || lower.Contains("set reminder"))
            {
                LogAction("NLP: User requested a reminder via chat — Task Assistant opened.");
                OpenTaskForm();
                return "I'll open the Task Assistant so you can set a reminder!";
            }
            

                // --- OPEN QUIZ via chat ---
                if (lower.Contains("quiz") || lower.Contains("test me") || lower.Contains("start game") ||
                lower.Contains("play") || lower.Contains("mini game"))
            {
                LogAction("NLP: User started quiz via chat.");
                OpenQuizForm();
                return "Starting the Cybersecurity Quiz!";
            }

            // --- SENTIMENT ---
            if (lower.Contains("worried"))
                return "It's completely understandable to feel that way. Let me help you stay safe.";
            if (lower.Contains("curious"))
                return "That's great curiosity! Cybersecurity is very important.";
            if (lower.Contains("frustrated"))
                return "I understand. I'll simplify things for you.";

            // --- MEMORY ---
            if (lower.Contains("my name is"))
            {
                userName = lower.Replace("my name is", "").Trim();
                LogAction($"User introduced themselves as '{userName}'.");
                return $"Nice to meet you, {userName}!";
            }
            if (lower.Contains("i'm interested in"))
            {
                userInterest = lower.Replace("i'm interested in", "").Trim();
                return $"Great! I'll remember that you're interested in {userInterest}.";
            }

            // --- FOLLOW-UP ---
            if (lower.Contains("tell me more") || lower.Contains("explain more") ||
                lower.Contains("another tip") || lower.Contains("continue"))
            {
                if (currentTopic == "password") return "Another tip: enable two-factor authentication (2FA) wherever possible.";
                if (currentTopic == "scam") return "Never trust urgent messages asking for money or passwords.";
                if (currentTopic == "privacy") return "Regularly review your app permissions and revoke unused ones.";
                if (currentTopic == "phishing") return "Always hover over links before clicking to check the real URL.";
                return "What topic would you like more help with?";
            }

            // --- KEYWORDS ---
            if (lower.Contains("password"))
            {
                currentTopic = "password";
                return "Use strong, unique passwords for every account and consider a password manager.";
            }
            if (lower.Contains("2fa") || lower.Contains("two-factor") || lower.Contains("two factor"))
            {
                currentTopic = "password";
                return "Two-factor authentication adds an extra layer of security. Enable it on all important accounts!";
            }
            if (lower.Contains("scam"))
            {
                currentTopic = "scam";
                return "Be careful of scams — never share personal information with unverified contacts.";
            }
            if (lower.Contains("privacy"))
            {
                currentTopic = "privacy";
                return "Protect your privacy by reviewing your settings and limiting data sharing.";
            }
            if (lower.Contains("phishing"))
            {
                currentTopic = "phishing";
                var responses = new List<string>
                {
                    "Be careful of phishing emails asking for personal info.",
                    "Always check the sender address before clicking links.",
                    "Scammers often pretend to be trusted companies.",
                    "Never enter passwords on suspicious websites."
                };
                return responses[new Random().Next(responses.Count)];
            }
            if (lower.Contains("malware") || lower.Contains("virus"))
                return "Install reputable antivirus software and avoid downloading files from unknown sources.";
            if (lower.Contains("vpn"))
                return "A VPN encrypts your internet traffic. It's especially useful on public Wi-Fi.";
            if (lower.Contains("firewall"))
                return "A firewall monitors and controls incoming and outgoing network traffic to protect your system.";
            if (lower.Contains("social engineering"))
                return "Social engineering manipulates people into revealing confidential information. Always verify requests!";

            return "I'm not sure I understand. Try asking about passwords, phishing, scams, privacy, or type 'quiz' to test your knowledge!";
        }

        private void OpenTaskForm()
        {
            var taskForm = new TaskForm(activityLog);
            taskForm.Show();
            LogAction("Task Assistant opened.");
        }

        private void OpenQuizForm()
        {
            var quizForm = new QuizForm(activityLog);
            quizForm.Show();
            LogAction("Quiz started.");
        }

        public MainForm()
        {
            InitializeComponent();
            rtbChat.AppendText("CyberSecurity Bot: Welcome to the Cybersecurity Awareness Chatbot!\r\n");
            rtbChat.AppendText("CyberSecurity Bot: Ask me about passwords, phishing, scams, privacy, VPNs, or malware.\r\n");
            rtbChat.AppendText("CyberSecurity Bot: Type 'quiz' to test your knowledge or 'tasks' to manage your tasks.\r\n");
            rtbChat.AppendText("CyberSecurity Bot: Type 'show activity log' to see what I have done for you.\r\n\r\n");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string userMessage = txtInput.Text?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(userMessage)) return;

            rtbChat.AppendText("You: " + userMessage + "\r\n");
            string response = GetResponse(userMessage);
            rtbChat.AppendText("Bot: " + response + "\r\n\r\n");

            db.SaveChat(userName, userMessage, response);

            rtbChat.SelectionStart = rtbChat.Text.Length;
            rtbChat.ScrollToCaret();
            txtInput.Clear();
            txtInput.Focus();
        }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            LogAction("Task Assistant opened via button.");
            OpenTaskForm();
        }

        private void btnQuiz_Click(object sender, EventArgs e)
        {
            LogAction("Quiz started via button.");
            OpenQuizForm();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) { }
        private void txtInput_TextChanged(object sender, EventArgs e) { }
        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnSend.PerformClick(); e.SuppressKeyPress = true; }
        }
        private void txtInput_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnSend.PerformClick(); e.SuppressKeyPress = true; }
        }
    }
}
