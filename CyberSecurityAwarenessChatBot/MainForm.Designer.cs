namespace CyberSecurityAwarenessChatBot
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            rtbChat = new System.Windows.Forms.RichTextBox();
            txtInput = new System.Windows.Forms.TextBox();
            btnSend = new System.Windows.Forms.Button();
            btnTasks = new System.Windows.Forms.Button();
            btnQuiz = new System.Windows.Forms.Button();
            SuspendLayout();

            // rtbChat
            rtbChat.Location = new System.Drawing.Point(0, 0);
            rtbChat.Size = new System.Drawing.Size(800, 355);
            rtbChat.Name = "rtbChat";
            rtbChat.ReadOnly = true;
            rtbChat.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            rtbChat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            rtbChat.TextChanged += richTextBox1_TextChanged;

            // txtInput
            txtInput.Location = new System.Drawing.Point(12, 368);
            txtInput.Size = new System.Drawing.Size(570, 25);
            txtInput.Name = "txtInput";
            txtInput.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            txtInput.TextChanged += txtInput_TextChanged;
            txtInput.KeyDown += txtInput_KeyDown_1;

            // btnSend
            btnSend.Location = new System.Drawing.Point(594, 366);
            btnSend.Size = new System.Drawing.Size(75, 28);
            btnSend.Name = "btnSend";
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;

            // btnTasks
            btnTasks.Location = new System.Drawing.Point(594, 405);
            btnTasks.Size = new System.Drawing.Size(90, 28);
            btnTasks.Name = "btnTasks";
            btnTasks.Text = "📋 Tasks";
            btnTasks.UseVisualStyleBackColor = true;
            btnTasks.Click += btnTasks_Click;

            // btnQuiz
            btnQuiz.Location = new System.Drawing.Point(694, 405);
            btnQuiz.Size = new System.Drawing.Size(90, 28);
            btnQuiz.Name = "btnQuiz";
            btnQuiz.Text = "🎯 Quiz";
            btnQuiz.UseVisualStyleBackColor = true;
            btnQuiz.Click += btnQuiz_Click;

            // MainForm
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(rtbChat);
            Controls.Add(txtInput);
            Controls.Add(btnSend);
            Controls.Add(btnTasks);
            Controls.Add(btnQuiz);
            Name = "MainForm";
            Text = "CyberSecurity Awareness Chatbot";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnTasks;
        private System.Windows.Forms.Button btnQuiz;
    }
}