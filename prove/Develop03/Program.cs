using System;

class Program
{
    static void Main()
    {
        ScriptureLibrary library = new ScriptureLibrary();
        
        while (true)
        {
            Console.Clear();
            library.DisplayMenu();
            Console.Write("Enter the number of the scripture to memorize (or type 'quit' to exit): ");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit") break;
            
            if (int.TryParse(input, out int selection) && selection > 0 && selection <= library.scriptures.Count)
            {
                Scripture scripture = library.GetScripture(selection - 1);
                
                while (!scripture.AllWordsHidden())
                {
                    Console.Clear();
                    scripture.Display();
                    
                    Console.WriteLine("\nPress Enter to hide words or type 'quit' to return to menu.");
                    input = Console.ReadLine();
                    if (input.ToLower() == "quit") break;
                    
                    scripture.HideRandomWords();
                }
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
                Console.ReadKey();
            }
        }
    }
}