using System;

namespace CyberSecurityChatbot
{
    // Chatbot class manages the conversation with the user
    // Chatbots are used to educate users and simulate conversation through programmed responses (Pieterse, 2021)

    public class Chatbot
    {
        public string UserName { get; set; }

        // Constructor
        public Chatbot(string name)
        {
            UserName = name;
        }

        // Start conversation
        public void StartChat()
        {
            Console.WriteLine();
            Console.WriteLine("Hello " + UserName + "! I am your Cybersecurity Awareness Chatbot.");
            Console.WriteLine("Ask me about online safety, passwords, or phishing.");
            Console.WriteLine("Type 'exit' to end the chat.");

            while (true)
            {
                Console.Write("\nYou: ");
                string input = Console.ReadLine().ToLower();

                if (input == "exit")
                {
                    Console.WriteLine("Chatbot: Stay safe online. Goodbye!");
                    break;
                }

                Respond(input);
            }
        }

        // Chatbot responses
        private void Respond(string input)
        {
            if (input.Contains("password"))
            {
                Console.WriteLine("Chatbot: Use strong passwords with letters, numbers, and symbols.");
            }
            else if (input.Contains("phishing"))
            {
                Console.WriteLine("Chatbot: Phishing emails try to trick you into giving personal information.");
            }
            else if (input.Contains("virus"))
            {
                Console.WriteLine("Chatbot: Install antivirus software and avoid downloading unknown files.");
            }
            else
            {
                Console.WriteLine("Chatbot: I’m still learning. Try asking about passwords, phishing, or viruses.");
            }
        }
    }
}