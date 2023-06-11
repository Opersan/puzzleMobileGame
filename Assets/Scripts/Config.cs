using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Text.RegularExpressions;

public class Config : MonoBehaviour
{
    #if UNITY_ANDROID && !UNITY_EDITOR
    private static string dir = Application.persistentDataPath;
    #else
    private static string dir = Directory.GetCurrentDirectory();
#endif

    private static string file = @"\board._data.ini";
    private static string path = dir + file;

    public static void DeleteDataFile()
    {
        File.Delete(path);
    }

    public static Dictionary<int, List<int>> GetGridNotes()
    {
        Dictionary<int, List<int>> grid_notes = new Dictionary<int, List<int>>();
        string line;
        StreamReader reader = new StreamReader(path);

        while((line = reader.ReadLine()) != null)
        {
            string[] word = line.Split(':');
            if (word[0] == "#square_note")
            {
                int square_index = -1;
                List<int> notes = new List<int>();
                int.TryParse(word[1], out square_index);

                string[] substring = Regex.Split(word[2], ",");
                foreach(var note in substring)
                {
                    int note_number = -1;
                    int.TryParse(note, out note_number);
                    if(note_number > 0)
                    {
                        notes.Add(note_number);
                    }
                }
                grid_notes.Add(square_index, notes);
            }
        }
        reader.Close();
        return grid_notes;
    }

    public static string ReadboardLevel()
    {
        string line;
        string level = "";
        StreamReader reader = new StreamReader (path);

        while ((line = reader.ReadLine()) != null)
        {
            string[] word = line.Split(':');
            if (word[0] == "#level")
            {
                level = word[1];
            }
        }
        reader.Close ();
        return level;
    }

    public static int ReadGameBoardLevel()
    {
        string line;
        int level = -1;
        StreamReader reader = new StreamReader(path);

        while ((line = reader.ReadLine()) != null)
        {
            string[] word = line.Split(':');
            if (word[0] == "#board_index")
            {
                int.TryParse(word[1], out level);
            }
        }
        reader.Close();
        return level;
    }

    public static float ReadGameTime()
    {
        float time = -1.0f;
        string line;
        StreamReader reader = new StreamReader(path);

        while ((line = reader.ReadLine()) != null)
        {
            string[] word = line.Split(':');
            if (word[0] == "#time")
            {
                float.TryParse(word[1], out time);
            }
        }
        reader.Close();
        return time;
    }
    public static int ReadErrorNumber()
    {
        int errors = 0;
        string line;
        StreamReader reader = new StreamReader(path);

        while ((line = reader.ReadLine()) != null)
        {
            string[] word = line.Split(':');
            if (word[0] == "#errors")
            {
                int.TryParse(word[1], out errors);
            }
        }
        reader.Close();
        return errors;
    }

    public static bool GameDataFileExist()
    {
        return File.Exists(path);
    }
}
