using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace Maze
{
    public class JSONData : ISaveData
    {
        string SavePath = Path.Combine(Application.dataPath, "JSONData.json");

        public void SaveData(PlayerData player)
        {
            string FileJSON = JsonUtility.ToJson(player);
            File.WriteAllText(SavePath, FileJSON);
        }

        public PlayerData Load()
        {
            PlayerData result = new PlayerData();

            if (!File.Exists(SavePath))
            {
                Debug.Log("File not exist!");
                return result;
            }

            string tempJson = File.ReadAllText(SavePath);
            result = JsonUtility.FromJson<PlayerData>(tempJson);

            return result;
        }
    }
}
