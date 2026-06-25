using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace CyberSecurityAwarenessChatBot
{
    public partial class QuizForm : Form
    {
        private List<string> activityLog;

        private struct Question
        {
            public string Text;
            public string[] Options;
            public int CorrectIndex;
            public string Explanation;
        }

        private List<Question> questions = new List<Question>
        {
            new Question { Text = "What should you do if you receive an email asking for your password?",
                Options = new[] { "Reply with your password", "Delete the email", "Report it as phishing", "Ignore it" },
                CorrectIndex = 2, Explanation = "Always report phishing emails to help prevent scams." },

            new Question { Text = "True or False: Using the same password for all accounts is safe.",
                Options = new[] { "True", "False" },
                CorrectIndex = 1, Explanation = "Reusing passwords means one breach compromises all your accounts." },

            new Question { Text = "What does 2FA stand for?",
                Options = new[] { "Two-Factor Authentication", "Two-File Access", "Transfer File Authorization", "Trusted Firewall Access" },
                CorrectIndex = 0, Explanation = "2FA adds an extra verification step beyond just a password." },

            new Question { Text = "Which of these is the strongest password?",
                Options = new[] { "password123", "MyDog2010", "Xk#9mP!2qL", "abc123" },
                CorrectIndex = 2, Explanation = "Strong passwords use a mix of letters, numbers, and special characters." },

            new Question { Text = "True or False: Public Wi-Fi is always safe to use for banking.",
                Options = new[] { "True", "False" },
                CorrectIndex = 1, Explanation = "Public Wi-Fi is unencrypted and can be intercepted by attackers." },

            new Question { Text = "What is phishing?",
                Options = new[] { "A type of antivirus", "A trick to steal personal info via fake messages", "A network security tool", "A way to speed up your internet" },
                CorrectIndex = 1, Explanation = "Phishing tricks users into revealing sensitive information." },

            new Question { Text = "What should you do before clicking a link in an email?",
                Options = new[] { "Click it immediately", "Hover over it to check the real URL", "Forward it to friends", "Reply to the sender" },
                CorrectIndex = 1, Explanation = "Hovering reveals the real destination and helps spot malicious links." },

            new Question { Text = "True or False: A VPN helps protect your privacy online.",
                Options = new[] { "True", "False" },
                CorrectIndex = 0, Explanation = "A VPN encrypts your traffic, especially important on public networks." },

            new Question { Text = "What is social engineering?",
                Options = new[] { "Building social media apps", "Manipulating people to reveal confidential info", "Engineering social networks", "A type of firewall" },
                CorrectIndex = 1, Explanation = "Social engineering exploits human psychology rather than technical vulnerabilities." },

            new Question { Text = "True or False: You should update your software regularly.",
                Options = new[] { "True", "False" },
                CorrectIndex = 0, Explanation = "Updates patch security vulnerabilities that attackers could exploit." },

            new Question { Text = "Which of these is a sign of a phishing website?",
                Options = new[] { "HTTPS in the URL", "A padlock icon", "Misspelled domain name", "A privacy policy" },
                CorrectIndex = 2, Explanation = "Attackers often use slightly misspelled domains to trick users." },

            new Question { Text = "What does a firewall do?",
                Options = new[] { "Speeds up your internet", "Monitors and controls network traffic", "Removes viruses", "Backs up your data" },
                CorrectIndex = 1, Explanation = "Firewalls filter incoming and outgoing traffic based on security rules." },
        };

        private int currentIndex = 0;
        private int score = 0;

        public QuizForm(List<string> log)
        {
            InitializeComponent();
            activityLog = log;
            ShowQuestion();
        }

        private void ShowQuestion()
        {
            if (currentIndex >= questions.Count)
            {
                ShowResult();
                return;
            }

            var q = questions[currentIndex];
            lblQuestion.Text = $"Question {currentIndex + 1} of {questions.Count}:\n\n{q.Text}";
            lblFeedback.Text = "";

            // Clear and rebuild option buttons
            pnlOptions.Controls.Clear();
            for (int i = 0; i < q.Options.Length; i++)
            {
                var btn = new Button();
                btn.Text = q.Options[i];
                btn.Width = 420;
                btn.Height = 35;
                btn.Left = 10;
                btn.Top = i * 45;
                btn.Tag = i;
                btn.Click += OptionButton_Click;
                pnlOptions.Controls.Add(btn);
            }
        }

        private void OptionButton_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            int chosen = (int)btn.Tag;
            var q = questions[currentIndex];

            // Disable all buttons after answer
            foreach (Control c in pnlOptions.Controls)
                c.Enabled = false;

            if (chosen == q.CorrectIndex)
            {
                score++;
                lblFeedback.ForeColor = System.Drawing.Color.Green;
                lblFeedback.Text = "✔ Correct! " + q.Explanation;
            }
            else
            {
                lblFeedback.ForeColor = System.Drawing.Color.Red;
                lblFeedback.Text = $"✘ Incorrect. The answer was: {q.Options[q.CorrectIndex]}\n{q.Explanation}";
            }

            btnNext.Visible = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentIndex++;
            btnNext.Visible = false;
            ShowQuestion();
        }

        private void ShowResult()
        {
            pnlOptions.Controls.Clear();
            btnNext.Visible = false;

            string feedback;
            if (score >= 10) feedback = "🏆 Outstanding! You're a cybersecurity pro!";
            else if (score >= 7) feedback = "👍 Great job! You know your stuff.";
            else if (score >= 5) feedback = "📚 Not bad, but keep learning to stay safe online!";
            else feedback = "⚠️ You need more practice. Stay alert online!";

            lblQuestion.Text = $"Quiz Complete!\n\nYour Score: {score} / {questions.Count}\n\n{feedback}";
            lblFeedback.Text = "";

            activityLog.Add($"[{DateTime.Now:HH:mm:ss}] Quiz completed — Score: {score}/{questions.Count}");
        }
    }
}