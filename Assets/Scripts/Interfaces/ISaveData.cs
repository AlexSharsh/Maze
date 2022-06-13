using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public interface ISaveData
    {
        void SaveData(PlayerData _player);
        PlayerData Load();
    }
}
