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
            Console.WriteLine("4. A confession to write somewhere in order to feel better\n");
            Console.WriteLine("5. Return to main menu\n");
            Console.WriteLine("6. Close app\n");
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
                        string deed;
                        Console.WriteLine("\nWrite what good have you done today");
                        deed= Console.ReadLine();
                        Text Deed = new Text(deed);
                        
                        using (StreamWriter writer = File.AppendText(filePathDeed)) 
                        {
                            writer.WriteLine("------------------------------");
                            writer.WriteLine(Deed.text);
                            writer.WriteLine();
                            writer.WriteLine(Deed.time.ToString());
                        }
                        break;
                    case "2":
                        string learned;
                        Console.WriteLine("\nWrite what useful have you learned today");
                        learned = Console.ReadLine();
                        Text LearnedThing = new Text(learned);
                        
                        using (StreamWriter writer = File.AppendText(filePathLearned))
                        {
                            writer.WriteLine("------------------------------");
                            writer.WriteLine(LearnedThing.text);
                            writer.WriteLine();
                            writer.WriteLine(LearnedThing.time.ToString());
                        }
                        break;
                    case "3":
                        string idea;
                        Console.WriteLine("\nWrite what useful have you learned today");
                        idea = Console.ReadLine();
                        Text GotAnIdea = new Text(idea);

                        using (StreamWriter writer = File.AppendText(filePathIdea))
                        {
                            writer.WriteLine("------------------------------");
                            writer.WriteLine(GotAnIdea.text);
                            writer.WriteLine();
                            writer.WriteLine(GotAnIdea.time.ToString());
                        }
                        break;
                    case "4":
                        string confession;
                        Console.WriteLine("\nWrite what useful have you learned today");
                        confession = Console.ReadLine();
                        Text ConfessionThing = new Text(confession);

                        using (StreamWriter writer = File.AppendText(filePathConfession))
                        {
                            writer.WriteLine("------------------------------");
                            writer.WriteLine(ConfessionThing.text);
                            writer.WriteLine();
                            writer.WriteLine(ConfessionThing.time.ToString());
                        }
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
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("Things that you learned so far:\n");
                        using (StreamReader reader = new StreamReader(filePathDeed))
                        {
                            string text = reader.ReadToEnd();
                            Console.WriteLine(text);
                        }
                        break;
                    case "2":
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("Things that you learned so far:\n");
                        using (StreamReader reader = new StreamReader(filePathLearned))
                        {
                            string text = reader.ReadToEnd();
                            Console.WriteLine(text);
                        }
                        break;
                    case "3":
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("Good Things that you did so far:\n");
                        using (StreamReader reader = new StreamReader(filePathIdea))
                        {
                            string text = reader.ReadToEnd();
                            Console.WriteLine(text);
                        }
                        break;
                    case "4":
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("Things that you learned so far:\n");
                        
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
