using Client.Library;
using System;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var items = await Api.GetStringArrayAsync(); 
            int selectedIndex = 0;

            while (true)
            {
                
                Console.Clear();

                
                for (int i = 0; i < items.Length; i++)
                {
                    var itemText = $"{i + 1}. {items[i]}";
                    if (i == selectedIndex)
                    {
                        
                        Screen.Print(itemText, 0, i, ConsoleColor.Black, ConsoleColor.Yellow);
                    }
                    else
                    {
                        
                        Screen.Print(itemText, 0, i);
                    }
                }

                
                var key = Screen.Listen(ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.Enter);

                if (key == ConsoleKey.UpArrow)
                {
                    
                    selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : items.Length - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {

                    selectedIndex = (selectedIndex < items.Length - 1) ? selectedIndex + 1 : 0;
                }
                else if (key == ConsoleKey.Enter)
                {
                    
                    Console.Clear();
                    Screen.SurroundWithBorder(new System.Drawing.Point(0, 0), new System.Drawing.Size(items[selectedIndex].Length + 2, 3));
                    Screen.Print(items[selectedIndex], 1, 1);
                    Console.SetCursorPosition(0, 5);
                    Console.WriteLine($"You selected: {items[selectedIndex]}");
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey(); 
                }
            }
        }
    }
}


