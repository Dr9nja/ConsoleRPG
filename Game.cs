//---------------------made by Dr9nja 30.09.2026-----------------------------
//---------------------------------------------------------------------------

// this file acts like the main loop file that keeps game alive
using System.ComponentModel;
using System.IO;

namespace ConsoleRpg02
{
    
    class Program
    {  
        public static GameState GameState = new GameState();
        static void Main(string[] args)
        {
            var IsNewGameLogin = Path.Exists("saves") && Directory.GetFiles("saves").Length > 0 ? false : true;
            // the line above checks if the saves exists and not empty, if one condition is false,
            // then it treats it as a new game login!!
            if (IsNewGameLogin)
            {
                GameState.State = "LoginNoSave";
                Console.WriteLine("ConsoleRPG: Welcome to the game! Please enter your name:");
            }
            else
            {   
                GameState.State = "LoginHasSave";
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
                if (GameState.State == "LoginNoSave")
                {
                    if (string.IsNullOrWhiteSpace(userInput))
                    {
                        Console.WriteLine("Please enter a valid name:");
                        continue;
                    }
                    else {
                        GameState.State = "";
                        Interactions.StartGame(userInput, true);
                        };
                }else if (GameState.State == "LoginHasSave")
                {
                    if (string.IsNullOrWhiteSpace(userInput))
                    {
                        Console.WriteLine("Please enter a valid name or save file number:");
                        continue;
                    }
                    else
                    {
                        if (int.TryParse(userInput, out int saveNumber))
                        {
                            var filePath = $"saves/SafeFile_{saveNumber}.txt";
                            if (File.Exists(filePath))
                            {
                                GameState.State = "";
                                Interactions.StartGame(Functions.ReadSaveLine(filePath, 1), false);
                            }
                            else
                            {
                                Console.WriteLine($"Save file {saveNumber} does not exist. Please enter a valid save file number or name to start a new game:");
                                continue;
                            }
                        }
                        else
                        {
                            GameState.State = "";
                            Interactions.StartGame(userInput, true);
                        }
                    }
                }
                        
                //----------------------------------------------------
            }
        }// should it return something?..
    }
}