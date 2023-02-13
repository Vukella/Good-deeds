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
        private static void Password(string solution)
        {
            Console.Clear(); //Delete previous console display
            string password;
            Console.WriteLine("You need to enter a password for this one");
            Console.WriteLine("Password: ");
            int chances = 3;
            while (chances > 0)
            {
                
                password = Console.ReadLine();
                
                if(password != null)
                {
                    if (password.Equals(solution))
                    {
                        break; //returns to case in switch, runs Porgram.Reading
                    }
                    else
                    {
                        //Displaying message in first and second try
                        if (chances == 2 || chances == 3)
                        {
                            Console.Clear();
                            Console.WriteLine("Looks like you missed a letter. Try again\n");
                            Console.WriteLine("Password: ");
                        }
                        chances--;
                    }
                }
                else
                {
                    Console.WriteLine("You can't leave question unanswered");
                    chances--;
                }
            }
            //If all chances are used the program terminates
            if (chances == 0)
            {
                Console.WriteLine("------------------------------\n");
                Console.WriteLine("You clearly aren't allowed to get this report. Stop sniffing into others private stuff\n");
                Environment.Exit(0);
            }
        }
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
            Console.WriteLine("\nWhat report do you want:");
            Console.WriteLine("1. All your good deeds?");
            Console.WriteLine("2. All things that you learned in a while?");
            Console.WriteLine("3. All ideas that you came up with?");
            Console.WriteLine("4. All confessions that you need to write somewhere?\n");
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
                        ExitApp(); //Closing the app
                        break;
                    default:
                        Console.WriteLine("There is some error. Please try again");
                        break;
                }
            } while (choice != "0");
        }
        private static void MenuWrite()
        {
            //Making strings with file paths to every text documents
            string filePathDeed = @"E:\Radovi i materijali\Bitno\C#\Good deed\deeds.txt";
            string filePathLearned = @"E:\Radovi i materijali\Bitno\C#\Good deed\learned.txt";
            string filePathIdea = @"E:\Radovi i materijali\Bitno\C#\Good deed\idea.txt";
            string filePathConfession = @"E:\Radovi i materijali\Bitno\C#\Good deed\confession.txt";
            //Making a switch
            string choice;
            do 
            {
                ShowMenuWrite();
                choice = Console.ReadLine();
                switch (choice) 
                {
                    case "1":
                        Console.Clear(); //Delete previous console display
                        string deed;
                        Console.WriteLine("\nWrite what good have you done today:\n");
                        deed= Console.ReadLine();
                        Text Deed = new Text(deed);
                        //Adding a function write everything into specific text document
                        Program.Writting(Deed, filePathDeed);
                        break;
                    case "2":
                        Console.Clear(); //Delete previous console display
                        string learned;
                        Console.WriteLine("\nWrite what useful thing have you learned today:\n");
                        learned = Console.ReadLine();
                        Text LearnedThing = new Text(learned);
                        //Adding a function write everything into specific text document
                        Program.Writting(LearnedThing, filePathLearned);
                        break;
                    case "3":
                        Console.Clear(); //Delete previous console display
                        string idea;
                        Console.WriteLine("\nAn idea that you want to make in reality some day:\n");
                        idea = Console.ReadLine();
                        Text GotAnIdea = new Text(idea);
                        //Adding a function write everything into specific text document
                        Program.Writting(GotAnIdea, filePathIdea);
                        break;
                    case "4":
                        Console.Clear(); //Delete previous console display
                        string confession;
                        Console.WriteLine("\nLet it all out:\n");
                        confession = Console.ReadLine();
                        Text ConfessionThing = new Text(confession);
                        //Adding a function write everything into specific text document
                        Program.Writting(ConfessionThing, filePathConfession);
                        break;
                    case "5":
                        Console.Clear(); //Delete previous console display
                        MainMenu(); //Return to main menu
                        break;
                    case "6":
                        ExitApp(); //Closing the app
                        break;
                    default:
                        Console.WriteLine("There is some error. Please try again");
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

            string solutionIdea = "A man with bright ideas";
            string solutionConfession = "Be a better man";

            string choice;
            do
            {
                ShowMenuReport();
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear(); //Delete previous console display
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("Good Things that you did so far:\n");
                        //Adding a function reads everything from specific text document
                        Program.Reading(filePathDeed);
                        break;
                    case "2":
                        Console.Clear(); //Delete previous console display
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("Things that you learned so far:\n");
                        //Adding a function reads everything from specific text document
                        Program.Reading(filePathLearned);
                        break;
                    case "3":
                        Program.Password(solutionIdea);
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("Amazing ideas that you wrote here:\n");
                        //Adding a function reads everything from specific text document
                        Program.Reading(filePathIdea);
                        break;
                    case "4":
                        Program.Password(solutionConfession);
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("Confessions written in order to feel better:\n");
                        //Adding a function reads everything from specific text document
                        Program.Reading(filePathConfession);
                        break;
                    case "5":
                        Console.Clear(); //Delete previous console display
                        MainMenu(); //Return to main menu
                        break;
                    case "6":
                        ExitApp(); //Closing the app
                        break;
                    default:
                        Console.WriteLine("There is some error. Please try again");
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
