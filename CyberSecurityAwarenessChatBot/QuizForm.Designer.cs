namespace CyberSecurityAwarenessChatBot
{
    partial class QuizForm
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
            lblQuestion = new System.Windows.Forms.Label();
            pnlOptions = new System.Windows.Forms.Panel();
            lblFeedback = new System.Windows.Forms.Label();
            btnNext = new System.Windows.Forms.Button();
            SuspendLayout();

            // lblQuestion
            lblQuestion.Location = new System.Drawing.Point(12, 15);
            lblQuestion.Size = new System.Drawing.Size(760, 100);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);

            // pnlOptions
            pnlOptions.Location = new System.Drawing.Point(12, 125);
            pnlOptions.Size = new System.Drawing.Size(460, 200);
            pnlOptions.Name = "pnlOptions";

            // lblFeedback
            lblFeedback.Location = new System.Drawing.Point(12, 340);
            lblFeedback.Size = new System.Drawing.Size(760, 60);
            lblFeedback.Name = "lblFeedback";
            lblFeedback.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            // btnNext
            btnNext.Location = new System.Drawing.Point(12, 415);
            btnNext.Size = new System.Drawing.Size(100, 28);
            btnNext.Name = "btnNext";
            btnNext.Text = "Next ➜";
            btnNext.Visible = false;
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;

            // QuizForm
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 460);
            Controls.Add(lblQuestion);
            Controls.Add(pnlOptions);
            Controls.Add(lblFeedback);
            Controls.Add(btnNext);
            Name = "QuizForm";
            Text = "Cybersecurity Quiz";
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Label lblFeedback;
        private System.Windows.Forms.Button btnNext;
    }
}