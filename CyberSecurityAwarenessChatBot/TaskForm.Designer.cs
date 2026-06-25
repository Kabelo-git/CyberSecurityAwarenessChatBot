namespace CyberSecurityAwarenessChatBot
{
    partial class TaskForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dtpReminder = new System.Windows.Forms.DateTimePicker();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.lvTasks = new System.Windows.Forms.ListView();
            this.btnComplete = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblReminder = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.chkReminder = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();

            // lblHeader
            this.lblHeader.Text = "🛡 Cybersecurity Task Assistant";
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblHeader.Location = new System.Drawing.Point(12, 10);
            this.lblHeader.Size = new System.Drawing.Size(400, 30);

            // lblTitle
            this.lblTitle.Text = "Task Title:";
            this.lblTitle.Location = new System.Drawing.Point(12, 55);
            this.lblTitle.Size = new System.Drawing.Size(80, 20);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 9F);

            // txtTitle
            this.txtTitle.Location = new System.Drawing.Point(100, 52);
            this.txtTitle.Size = new System.Drawing.Size(350, 23);
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTitle.PlaceholderText = "e.g. Enable two-factor authentication";

            // lblDesc
            this.lblDesc.Text = "Description:";
            this.lblDesc.Location = new System.Drawing.Point(12, 90);
            this.lblDesc.Size = new System.Drawing.Size(80, 20);
            this.lblDesc.Font = new System.Drawing.Font("Segoe UI", 9F);

            // txtDescription
            this.txtDescription.Location = new System.Drawing.Point(100, 87);
            this.txtDescription.Size = new System.Drawing.Size(350, 23);
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtDescription.PlaceholderText = "Brief description of the task";

            // lblReminder
            this.lblReminder.Text = "Reminder:";
            this.lblReminder.Location = new System.Drawing.Point(12, 125);
            this.lblReminder.Size = new System.Drawing.Size(80, 20);
            this.lblReminder.Font = new System.Drawing.Font("Segoe UI", 9F);

            // chkReminder
            this.chkReminder.Text = "Set reminder date";
            this.chkReminder.Location = new System.Drawing.Point(100, 123);
            this.chkReminder.Size = new System.Drawing.Size(130, 23);
            

            // dtpReminder
            this.dtpReminder.Location = new System.Drawing.Point(240, 122);
            this.dtpReminder.Size = new System.Drawing.Size(210, 23);
            this.dtpReminder.Enabled = false;
            this.dtpReminder.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // btnAddTask
            this.btnAddTask.Text = "➕ Add Task";
            this.btnAddTask.Location = new System.Drawing.Point(100, 163);
            this.btnAddTask.Size = new System.Drawing.Size(110, 30);
            this.btnAddTask.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAddTask.ForeColor = System.Drawing.Color.White;
            this.btnAddTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTask.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);

            // btnComplete
            this.btnComplete.Text = "✔ Mark Complete";
            this.btnComplete.Location = new System.Drawing.Point(225, 163);
            this.btnComplete.Size = new System.Drawing.Size(130, 30);
            this.btnComplete.BackColor = System.Drawing.Color.SeaGreen;
            this.btnComplete.ForeColor = System.Drawing.Color.White;
            this.btnComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComplete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);

            // btnDelete
            this.btnDelete.Text = "🗑 Delete Task";
            this.btnDelete.Location = new System.Drawing.Point(370, 163);
            this.btnDelete.Size = new System.Drawing.Size(115, 30);
            this.btnDelete.BackColor = System.Drawing.Color.Crimson;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // lvTasks
            this.lvTasks.Location = new System.Drawing.Point(12, 210);
            this.lvTasks.Size = new System.Drawing.Size(760, 200);
            this.lvTasks.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lvTasks.UseCompatibleStateImageBehavior = false;
            this.lvTasks.FullRowSelect = true;
            this.lvTasks.GridLines = true;

            // TaskForm
            this.ClientSize = new System.Drawing.Size(800, 430);
            this.Text = "Task Assistant - Cybersecurity Tasks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblReminder);
            this.Controls.Add(this.chkReminder);
            this.Controls.Add(this.dtpReminder);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lvTasks);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.DateTimePicker dtpReminder;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.ListView lvTasks;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblReminder;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.CheckBox chkReminder;
    }
}