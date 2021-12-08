using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZZBase.Maze;

namespace ZZBase.Bonus
{
    internal class BonusSpawner : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> bonusPrefabs;

        private List<GameObject> goodActiveBonuses;
        private List<GameObject> badActiveBonuses;

        private int activeBonusesCount;

        public InteractiveObject this [bool good, int index]
        {
            get 
            {
                if (good)
                {
                    if (index >= 0 && index < goodActiveBonuses.Count)
                    {
                        return goodActiveBonuses[index].GetComponent<InteractiveObject>();
                    }
                    else
                    {
                        return null;
                    }
                    
                }
                else 
                {
                    if (index >= 0 && index < badActiveBonuses.Count)
                    {
                        return badActiveBonuses[index].GetComponent<InteractiveObject>();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        private void Awake()
        {
            activeBonusesCount = 10;
            Global.bonusSpawner = this;
            goodActiveBonuses = new List<GameObject>();
            badActiveBonuses = new List<GameObject>();
        }

        private bool IsBonusInXY(float x, float z)
        {
            foreach(GameObject go in goodActiveBonuses)
            {
                Vector3 position = go.transform.position;
                if ((position.x == x) && (position.z == z))
                {
                    return true;
                }
            }
            foreach (GameObject go in badActiveBonuses)
            {
                Vector3 position = go.transform.position;
                if ((position.x == x) && (position.z == z))
                {
                    return true;
                }
            }
            return false;
        }

        private void SpawnNewBonus()
        {
            float xPosition;
            float yPosition;

            while (true)
            {
                int x = Random.Range(0, Settings.maze_width) * 2 + 1;
                int y = Random.Range(0, Settings.maze_height) * 2 + 1;
                xPosition = Global.GetWorldXFromMazeX(x);
                yPosition = Global.GetWorldYFromMazeY(y);
                if (!IsBonusInXY(xPosition, yPosition)) break;
            }

            GameObject prefab = bonusPrefabs[Random.Range(0, bonusPrefabs.Count)];

            Vector3 position = new Vector3(xPosition, 0, yPosition);
            GameObject go = Instantiate(prefab, position, Quaternion.identity);
            InteractiveObject io = go.GetComponent<InteractiveObject>();
            io.Action();
            if (io.IsGoodBonus())
            {
                goodActiveBonuses.Add(go);
            }
            else
            {
                badActiveBonuses.Add(go);
            }
            
        }

        private void Update()
        {
            if (goodActiveBonuses.Count + badActiveBonuses.Count < activeBonusesCount) SpawnNewBonus();
        }

        public void DestroyBonus(GameObject _go)
        {
            InteractiveObject io = _go.GetComponent<InteractiveObject>();
            if (io.IsGoodBonus())
            {
                goodActiveBonuses.Remove(_go);
            }
            else
            {
                badActiveBonuses.Remove(_go);
            }
            Destroy(_go);
        }
    }
}
