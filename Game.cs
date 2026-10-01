//---------------------made by Dr9nja 30.09.2026-----------------------------
//---------------------------------------------------------------------------

// this file acts like the main loop file that keeps game alive
using System.ComponentModel;
using System.IO;

namespace ConsoleRpg02
{
    
    class Program
    {  
        static void Main(string[] args)
        {
            var IsNewGameLogin = Path.Exists("saves") && Directory.GetFiles("saves").Length > 0 ? false : true;
            // the line above checks if the saves exists and not empty, if one condition is false,
            // then it treats it as a new game login!!
            if (IsNewGameLogin)
            {
                Console.WriteLine("ConsoleRPG: Welcome to the game! Please enter your name:");
            }
            else
            {   
                var savesLenght = Directory.GetFiles("saves").Length;
                Console.WriteLine($"ConsoleRPG: Choose a save file to continue... [1-{savesLenght}, or name to start a new game!]");
                for (int i = 0; i < savesLenght; i++)
                {
                    var filePath = $"saves/SafeFile_{i + 1}.txt";
                    Console.WriteLine($"save {i + 1}: {Functions.ReadSaveLine(filePath, 1)}, last login: {Functions.ReadSaveLine(filePath, 7)}");
                }
            }
            while (true)
            {
                // userInput would always interact with Act.cs file as getting info
                // and also sending info, so SafeFile.txt (that will be created) can 
                // be used to store keys and values.
                var userInput = Console.ReadLine();

                //simple tester of file writing ---------------------
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Please enter a valid name:");
                    continue;
                }
                else {Interactions.StartGame(userInput, true);
                    break;
                }
                //----------------------------------------------------
            }
        }// should it return something?..
    }
}