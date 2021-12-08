using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Maze
{
    internal class MazeCell : MazePoint
    {
        internal bool isReachable;
        internal MazeCell(int new_x, int new_y) : base(new_x, new_y)
        {
            isReachable = false;
        }

        internal override void Show()
        {
            Vector3 position = new Vector3(Global.GetWorldXFromMazeX(x), 0, Global.GetWorldYFromMazeY(y));
            go = GameObject.Instantiate(Global.world.prefabs[0], position, Quaternion.identity);
            go.transform.localScale = new Vector3(Settings.cell_width, 1f, Settings.cell_height);
            SetParent();
        }
    }

}
