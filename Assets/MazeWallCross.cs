using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Maze
{
    internal class MazeWallCross : MazePoint
    {
        internal MazeWallCross(int new_x, int new_y) : base(new_x, new_y)
        {

        }

        internal override void Show()
        {
            Vector3 position = new Vector3(Global.GetWorldXFromMazeX(x), 0, Global.GetWorldYFromMazeY(y));
            go = GameObject.Instantiate(Global.world.prefabs[2], position, Quaternion.identity);
            go.transform.localScale = new Vector3(Settings.wall_thickness, 1f, Settings.wall_thickness);
            SetParent();
        }
    }

}
