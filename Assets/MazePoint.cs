using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Maze
{
    internal abstract class MazePoint
    {
        internal int x;
        internal int y;
        protected GameObject go;

        internal MazePoint(int new_x, int new_y)
        {
            x = new_x;
            y = new_y;
            go = null;
        }

        internal virtual void SetParent()
        {
            if (go != null)
            {
                go.transform.parent = Global.maze.mazeZero.transform;
            }
        }

        internal abstract void Show();
        internal virtual void Hide()
        {
            if (go != null)
            {
                GameObject.Destroy(go);
            }
        }
    }

}
