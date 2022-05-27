using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class BadBonusPoints : MonoBehaviour
    {
        private List<GameObject> objList = new List<GameObject>();

        public List<GameObject> Init(GameObject BadBonusPrefab, Transform[] BadBonusListPoints)
        {
            for (int i = 0; i < BadBonusListPoints.Length; i++)
            {
                GameObject badBonus = Instantiate(BadBonusPrefab, BadBonusListPoints[i].transform.position, BadBonusListPoints[i].transform.rotation);
                badBonus.active = true;
                objList.Add(badBonus);
            }

            return objList;
        }
    }
}
