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

        private List<GameObject> activeBonuses;

        private int activeBonusesCount;

        private void Awake()
        {
            activeBonusesCount = 10;
            Global.bonusSpawner = this;
            activeBonuses = new List<GameObject>();
        }

        private bool IsBonusInXY(float x, float z)
        {
            foreach(GameObject go in activeBonuses)
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
            go.GetComponent<InteractiveObject>().Action();

            activeBonuses.Add(go);
        }

        private void Update()
        {
            if (activeBonuses.Count < activeBonusesCount) SpawnNewBonus();
        }

        public void DestroyBonus(GameObject _go)
        {
            activeBonuses.Remove(_go);
            Destroy(_go);
        }
    }
}
