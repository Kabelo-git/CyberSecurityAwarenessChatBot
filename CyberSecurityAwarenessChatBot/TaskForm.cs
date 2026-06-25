using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CyberSecurityAwarenessChatBot
{
    public partial class TaskForm : Form
    {
        private DatabaseHelper db = new DatabaseHelper();
        private List<string> activityLog;
        public TaskForm(List<string> log)
        {
            InitializeComponent();
            activityLog = log;
            LoadTasks();
        }

        private void LoadTasks()
        {
            lvTasks.Items.Clear();
            lvTasks.Columns.Clear();
            lvTasks.Columns.Add("ID", 40);
            lvTasks.Columns.Add("Title", 150);
            lvTasks.Columns.Add("Description", 200);
            lvTasks.Columns.Add("Reminder", 120);
            lvTasks.Columns.Add("Completed", 80);
            lvTasks.View = View.Details;
            lvTasks.FullRowSelect = true;

            var tasks = db.GetTasks();
            foreach (var task in tasks)
            {
                var item = new ListViewItem(task.Id.ToString());
                item.SubItems.Add(task.Title);
                item.SubItems.Add(task.Description);
                item.SubItems.Add(task.ReminderDate.HasValue ? task.ReminderDate.Value.ToShortDateString() : "None");
                item.SubItems.Add(task.IsCompleted ? "Yes" : "No");
                lvTasks.Items.Add(item);
            }
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter a task title.");
                return;
            }

            DateTime? reminder = dtpReminder.Checked ? dtpReminder.Value : (DateTime?)null;
            db.AddTask(txtTitle.Text, txtDescription.Text, reminder);
            MessageBox.Show("Task added successfully!");
            activityLog.Add($"[{DateTime.Now:HH:mm:ss}] Task added: '{txtTitle.Text}'");
            txtTitle.Clear();
            txtDescription.Clear();
            LoadTasks();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (lvTasks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a task first.");
                return;
            }

            int id = int.Parse(lvTasks.SelectedItems[0].Text);
            db.CompleteTask(id);
            MessageBox.Show("Task marked as completed!");
            activityLog.Add($"[{DateTime.Now:HH:mm:ss}] Task {id} marked as completed.");
            LoadTasks();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvTasks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a task first.");
                return;
            }

            int id = int.Parse(lvTasks.SelectedItems[0].Text);
            db.DeleteTask(id);
            MessageBox.Show("Task deleted!");
            activityLog.Add($"[{DateTime.Now:HH:mm:ss}] Task {id} deleted.");
            LoadTasks();
        }

        private void dtpReminder_ValueChanged(object sender, EventArgs e) { }
    }
}