using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Maze
{
    internal class World : MonoBehaviour
    {
        [SerializeField]
        internal GameObject[] prefabs;

        private void Awake()
        {
            Global.SetCursorVisible(false);
            Global.world = this;
            Global.Awake();
        }

        private void Start()
        {
            Global.Start();
        }

        private void OnDestroy()
        {
            Global.SetCursorVisible(true);
        }
    }

}
