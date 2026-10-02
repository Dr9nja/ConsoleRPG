//---------------------made by Dr9nja 30.09.2026-----------------------------
//---------------------------------------------------------------------------
//some essectial files that the game should know about, 
// like the player, the game state, etc..
namespace ConsoleRpg02
{
    public class Functions
    {
        public static string ReadSaveLine(string _filePath, int _lineNumber)
        {
            // read a specific line from a file
            using (StreamReader reader = new StreamReader(_filePath))
            {
                for (int i = 0; i < _lineNumber - 1; i++)
                {
                    reader.ReadLine();
                }
                var line = reader.ReadLine();
                if (!string.IsNullOrEmpty(line))
                {
                    return line;
                }else return "undefined";
            }
        }
        //and the virse versa func!
        public static void WriteSaveLine(string _filePath, int _lineNum, string _newValue)
        {
            var lines = File.ReadAllLines(_filePath);

            //Console.WriteLine($"{lines[_lineNum - 1]}"); // it was a test if the lines are readed

            for (int line = 0; line < lines.Length; line++)
            {
                if (line == _lineNum - 1)
                {
                    lines[line] = _newValue;
                    File.WriteAllLines(_filePath, lines);
                    //Console.WriteLine($"Saved new value: {lines[line]}");
                    break;
                }
            }
        }
    }
    public class GameState
    {
        //some properties that the game should have, like state, current location, etc
        public string State {get; set;}
        public string CurrentLocation {get; set;}
    }
    public class Player
    {
        //some properties that the player should have, like name, experience, level
        public string Name {get; set;}
        public int Exp {get; set;}
        public int Level {get; set;}
        public int HP {get; set;}
        public int DEF {get; set;}
        public int ATK {get; set;}
        public int Gold {get; set;}
        public int MP {get; set;}
        public int Speed {get; set;}
        public DateTime LastLogin {get; set;}

    }
    
}

