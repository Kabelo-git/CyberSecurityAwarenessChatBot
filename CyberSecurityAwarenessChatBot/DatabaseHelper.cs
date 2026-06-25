using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace CyberSecurityAwarenessChatBot
{
    public class DatabaseHelper
    {
        private string connectionString =
            "Server=localhost;Database=chatbotdb;Uid=root;Pwd=Kabel0:);";

        public void SaveChat(string userName, string userMessage, string botResponse)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO ChatHistory (UserName, UserMessage, BotResponse) " +
                                   "VALUES (@user, @msg, @resp)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", userName);
                        cmd.Parameters.AddWithValue("@msg", userMessage);
                        cmd.Parameters.AddWithValue("@resp", botResponse);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine("DB Error: " + ex.Message); }
        }

        public void AddTask(string title, string description, DateTime? reminderDate)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Tasks (Title, Description, ReminderDate) VALUES (@title, @desc, @reminder)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@desc", description);
                        cmd.Parameters.AddWithValue("@reminder", (object)reminderDate ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine("DB Error: " + ex.Message); }
        }

        public List<(int Id, string Title, string Description, DateTime? ReminderDate, bool IsCompleted)> GetTasks()
        {
            var tasks = new List<(int, string, string, DateTime?, bool)>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Id, Title, Description, ReminderDate, IsCompleted FROM Tasks";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tasks.Add((
                                reader.GetInt32(0),
                                reader.IsDBNull(1) ? "" : reader.GetString(1),
                                reader.IsDBNull(2) ? "" : reader.GetString(2),
                                reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                                reader.GetBoolean(4)
                            ));
                        }
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine("DB Error: " + ex.Message); }
            return tasks;
        }

        public void CompleteTask(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Tasks SET IsCompleted = TRUE WHERE Id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine("DB Error: " + ex.Message); }
        }

        public void DeleteTask(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Tasks WHERE Id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine("DB Error: " + ex.Message); }
        }
    }
}