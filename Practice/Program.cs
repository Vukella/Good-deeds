using System.Linq;
using System.IO;
using System.Reflection.PortableExecutable;

namespace Program
{
    internal class Text
    {
        internal string text;
        internal DateTime time;
        internal Text(string text)
        {
            this.text = text;
            time = DateTime.Now;
        }
    }
    
    class Program
    {
        private static void ExitApp()
        {
            Console.WriteLine("Continue on making progress!");
            Console.ReadLine();
            Environment.Exit(0);
        }
        private static void Writting(Text Entered, string filePath) 
        {
            
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine("------------------------------");
                writer.WriteLine(Entered.text);
                writer.WriteLine();
                writer.WriteLine(Entered.time.ToString());
            }
        }

        private static void Reading(string filePath) 
        {
            using (StreamReader reader = new StreamReader(filePath)) 
            {
                string text = reader.ReadToEnd();
                Console.WriteLine(text);
            }
        }

        private static void ShowFirstMenu()
        {
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("Welcome to Good deed!");
            Console.WriteLine("\nWhat do you want:");
            Console.WriteLine("1. Enter something");
            Console.WriteLine("2. Get a report");
            Console.WriteLine("0. Exit menu\n");
            Console.Write("Enter your choice: ");
        }
        
        private static void ShowMenuWrite() 
        {
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("You picked first option");
            Console.WriteLine("\nWhat do you want to enter:");
            Console.WriteLine("1. A good deed you did today?");
            Console.WriteLine("2. Something you learned today?");
            Console.WriteLine("3. An idea that needs to be saved somewhere?");
            Console.WriteLine("4. A confession to write somewhere in order to feel better?\n");
            Console.WriteLine("5. Return to main menu");
            Console.WriteLine("6. Close app");
            Console.Write("Enter your choice: ");
        }
        private static void ShowMenuReport()
        {
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("You picked second option");
            Console.WriteLine("\nWhat report you want:");
            Console.WriteLine("1. Report of all your good deeds?");
            Console.WriteLine("2. Report of all things that you learned in a while?");
            Console.WriteLine("3. Report of all ideas that you came up with?");
            Console.WriteLine("4. Report of all confessions that you need to write somewhere?\n");
            Console.WriteLine("5. Return to main menu");
            Console.WriteLine("6. Close app");
            Console.Write("Enter your choice: ");
        }
        private static void MainMenu()
        {
            string choice;
            do
            {
                ShowFirstMenu();
                choice = Console.ReadLine();
                switch (choice) 
                {
                    case "1":
                        MenuWrite();
                        break;
                    case "2":
                        MenuReport();
                        break;
                    case "0":
                        ExitApp();
                        break;
                    default:
                        Console.WriteLine("There is some error. Please try again");
                        Console.Read();
                        break;

                }
            } while (choice != "0");
        }
        private static void MenuWrite()
        {
            string filePathDeed = @"E:\Radovi i materijali\Bitno\C#\Good deed\deeds.txt";
            string filePathLearned = @"E:\Radovi i materijali\Bitno\C#\Good deed\learned.txt";
            string filePathIdea = @"E:\Radovi i materijali\Bitno\C#\Good deed\idea.txt";
            string filePathConfession = @"E:\Radovi i materijali\Bitno\C#\Good deed\confession.txt";

            string choice;
            do 
            {
                ShowMenuWrite();
                choice = Console.ReadLine();
                switch (choice) 
                {
                    case "1":
                        Console.Clear();
                        string deed;
                        Console.WriteLine("\nWrite what good have you done today\n");
                        deed= Console.ReadLine();
                        Text Deed = new Text(deed);
                        Program.Writting(Deed, filePathDeed);
                        break;
                    case "2":
                        Console.Clear();
                        string learned;
                        Console.WriteLine("\nWrite what useful thing have you learned today\n");
                        learned = Console.ReadLine();
                        Text LearnedThing = new Text(learned);

                        Program.Writting(LearnedThing, filePathLearned);
                        break;
                    case "3":
                        Console.Clear();
                        string idea;
                        Console.WriteLine("\nAn idea that you want to make in reality some day\n");
                        idea = Console.ReadLine();
                        Text GotAnIdea = new Text(idea);

                        Program.Writting(GotAnIdea, filePathIdea);
                        break;
                    case "4":
                        Console.Clear();
                        string confession;
                        Console.WriteLine("\nLet it all out\n");
                        confession = Console.ReadLine();
                        Text ConfessionThing = new Text(confession);

                        Program.Writting(ConfessionThing, filePathConfession);
                        break;
                    case "5":
                        Console.Clear();
                        MainMenu();
                        break;
                    case "6":
                        ExitApp();
                        break;
                    default:
                        Console.WriteLine("There is some error. Please try again");
                        Console.Read();
                        break;
                }
            } while (choice != "0");
        }
        private static void MenuReport()
        {
            string filePathDeed = @"E:\Radovi i materijali\Bitno\C#\Good deed\deeds.txt";
            string filePathLearned = @"E:\Radovi i materijali\Bitno\C#\Good deed\learned.txt";
            string filePathIdea = @"E:\Radovi i materijali\Bitno\C#\Good deed\idea.txt";
            string filePathConfession = @"E:\Radovi i materijali\Bitno\C#\Good deed\confession.txt";

            string choice;
            do
            {
                ShowMenuReport();
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("Good Things that you did so far:\n");
                        Program.Reading(filePathDeed);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("Things that you learned so far:\n");
                        Program.Reading(filePathLearned);
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("Amazing ideas that you wrote here:\n");
                        Program.Reading(filePathIdea);
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("Confessions written in order to feel better:\n");
                        Program.Reading(filePathConfession);
                        break;
                    case "5":
                        Console.Clear();
                        MainMenu();
                        break;
                    case "6":
                        ExitApp();
                        break;
                    default:
                        Console.WriteLine("There is some error. Please try again");
                        Console.Read();
                        break;
                }
            } while (choice != "0");
        }
        static void Main(string[] args) 
        {
            MainMenu();
            
        }
    }

}
