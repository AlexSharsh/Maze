using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Maze
{

    public class WindowSaveWaypoint : EditorWindow
    {
        private static XmlSerializer serialiser;
        public List<SVect3> SavingNodes = new List<SVect3>();


        [MenuItem("Интструменты /Окна/ SaveWaypoint ")]
        public static void ShowMyWindow()
        {
            GetWindow(typeof(WindowSaveWaypoint), false, "SaveWaypoint");
        }

        void OnGUI()
        {

        }
    }
}
