using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class GoodBonusPoints : MonoBehaviour
    {
        private List<GameObject> objList = new List<GameObject>();

        public List<GameObject> Init(GameObject GoodBonusPrefab, Transform[] GoodBonusListPoints)
        {
            for (int i = 0; i < GoodBonusListPoints.Length; i++)
            {
                GameObject goodBonus = Instantiate(GoodBonusPrefab, GoodBonusListPoints[i].transform.position, GoodBonusListPoints[i].transform.rotation);
                goodBonus.SetActive(true);
                objList.Add(goodBonus);
            }

            return objList;
        }
    }
}
