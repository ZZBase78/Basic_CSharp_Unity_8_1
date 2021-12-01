using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Maze
{
    internal class MazeWall : MazePoint
    {
        private bool isVertical;
        internal bool isOpen;

        internal MazeWall(int new_x, int new_y, bool new_vertical) : base(new_x, new_y)
        {
            isVertical = new_vertical;
            isOpen = false;
        }

        internal override void Show()
        {
            if (!isOpen)
            {
                Vector3 position = new Vector3(Global.GetWorldXFromMazeX(x), 0, Global.GetWorldYFromMazeY(y));
                go = GameObject.Instantiate(Global.world.prefabs[1], position, Quaternion.identity);
                if (isVertical)
                {
                    go.transform.localScale = new Vector3(Settings.wall_thickness, 1f, Settings.cell_height);
                }
                else
                {
                    go.transform.localScale = new Vector3(Settings.cell_width, 1f, Settings.wall_thickness);
                }
                SetParent();
            }
        }
    }

}
