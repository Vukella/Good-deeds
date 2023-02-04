using System.Linq;
using System.IO;

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

        private static void ShowMenu() 
        {
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("Welcome to Good deed!");
            Console.WriteLine("\nWhat do you want:");
            Console.WriteLine("1. Write a good deed you did today?");
            Console.WriteLine("2. Write something you learned today?");
            Console.WriteLine("3. Get a report about all good deeds you written here?");
            Console.WriteLine("4. Get a report about all things you learned and written here?");
            Console.WriteLine("0. Exit menu\n");
            Console.Write("Enter your choice: ");
        }
        private static void Menu()
        {
            string filePath1 = @"E:\Radovi i materijali\Bitno\C#\Good deed\deeds.txt";
            string filePath2 = @"E:\Radovi i materijali\Bitno\C#\Good deed\learned.txt";

            string choice;
            do 
            {
                ShowMenu();
                choice = Console.ReadLine();
                switch (choice) 
                {
                    case "1":
                        string deed;
                        Console.WriteLine("\nWrite what good have you done today");
                        deed= Console.ReadLine();
                        Text deed1 = new Text(deed);
                        
                        using (StreamWriter writer = File.AppendText(filePath1)) 
                        {
                            writer.WriteLine("------------------------------");
                            writer.WriteLine(deed1.text);
                            writer.WriteLine();
                            writer.WriteLine(deed1.time.ToString());
                        }
                        break;
                    case "2":
                        string learned;
                        Console.WriteLine("\nWrite what useful have you learned today");
                        learned = Console.ReadLine();
                        Text learnedThing = new Text(learned);
                        
                        using (StreamWriter writer = File.AppendText(filePath2))
                        {
                            writer.WriteLine("------------------------------");
                            writer.WriteLine(learnedThing.text);
                            writer.WriteLine();
                            writer.WriteLine(learnedThing.time.ToString());
                        }
                        break;
                    case "3":
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("Good Things that you did so far:\n");
                        using (StreamReader reader = new StreamReader(filePath1))
                        {
                            string text = reader.ReadToEnd();
                            Console.WriteLine(text);
                        }

                        break;
                    case "4":
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("Things that you learned so far:\n");
                        using (StreamReader reader = new StreamReader(filePath2))
                        {
                            string text = reader.ReadToEnd();
                            Console.WriteLine(text);
                        }

                        break;
                    case "0":
                        Console.WriteLine("Continue on making progress!");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("There is some error. Please try again");
                        break;
                }
            } while (choice != "0");
            
            

        }
        static void Main(string[] args) 
        {
            Menu();
        }
    }

}
