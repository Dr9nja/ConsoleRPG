//---------------------made by Dr9nja 30.09.2026-----------------------------
//---------------------------------------------------------------------------
//some acts that then the Program.cs will call to make the game going!! :3
using System.IO;

namespace ConsoleRpg02
{
    public class DebugAct
    {
        // this class only used in debugging purposes!!

    }
    public class Actions
    {
        //battle acts that used in battle state of the game only.
        
    }
    public class Interactions
    {
        //interactions acts are used when player is in state of world. when it's a fight, class Actions used instead

        public static string StartGame(string _name, bool _isNewGame)
        {
            var globalFilePath = ""; // this variable used to store the file path for both
            // new game and existing game, so we can remeber the file we need to changeeee
            if (_isNewGame)
            {
                var player = new Player();

                player.Name = _name;

                player.Exp = 0;
                player.Level = 1;
                
                player.HP = 80;
                player.MP = 40;
                player.DEF = 0;
                player.ATK = 5;
                player.Gold = 0;
                player.Speed = 8;

                //last time player looged in, so we can treat different game save slots
                player.LastLogin = DateTime.Now; 

                // create a new file to store player data
                // Todo make be able to make multiple save slots, so player can have different
                // saves and choose which one to load...
                if (!Path.Exists("saves")) {Directory.CreateDirectory("saves");}//create the new saves dir
                var saveID = Directory.GetFiles("saves").Length + 1; // it's like, to make them unique??

                string filePath = Path.GetFullPath($"saves/SafeFile_{saveID}.txt"); //path to file?
                globalFilePath = filePath;
                // write player data to the file
                // had a problem that it kept searching the file in bin/Debug/net :P that's also why
                // i gave up and gave it to create folder itself
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(player.Name);
                    writer.WriteLine(player.Exp);
                    writer.WriteLine(player.Level);
                    writer.WriteLine(player.HP);
                    writer.WriteLine(player.DEF);
                    writer.WriteLine(player.ATK);
                    writer.WriteLine(player.LastLogin);
                    writer.WriteLine(player.Gold);
                    writer.WriteLine(player.MP);
                    writer.WriteLine(player.Speed);

                    writer.Flush(); //update the info 
                }
                //Console.WriteLine($"New game started for player: {player.Name}, login time: {player.LastLogin}");
                Console.WriteLine($"ConsoleRPG: Welcome to the game, {player.Name}! Your adventure begins now!");
                return globalFilePath;
            }else
            {
                Console.WriteLine($"Loading game for player: {_name}");
                return globalFilePath;
            }
            // this one function checks the files when the game got openned
            
        }
    }
};

