using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Maze
{
    internal class Maze
    {
        int sizeX;
        int sizeY;
        MazePoint[,] map;
        internal GameObject mazeCenter;
        internal GameObject mazeZero;

        internal Maze()
        {
            sizeX = Settings.maze_width * 2 + 1;
            sizeY = Settings.maze_height * 2 + 1;
            map = new MazePoint[sizeX, sizeY];
        }

        private void NewMaze()
        {
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    if (Global.IsEven(x))
                    {
                        if (Global.IsEven(y))
                        {
                            //MazeWallCross
                            map[x, y] = new MazeWallCross(x, y);
                        }
                        else
                        {
                            //MazeWall, vertical
                            map[x, y] = new MazeWall(x, y, true);
                        }
                    }
                    else
                    {
                        if (Global.IsEven(y))
                        {
                            //MazeWall, horizontal
                            map[x, y] = new MazeWall(x, y, false);
                        }
                        else
                        {
                            //MazeCell
                            map[x, y] = new MazeCell(x, y);
                        }
                    }
                }
            }
        }

        private MazeCell GetMazeCell(int x, int y)
        {
            if ((x < 1) || (x > sizeX - 2)) return null;
            if ((y < 1) || (y > sizeY - 2)) return null;
            return map[x, y] as MazeCell;
        }

        private void AddReachableCell(List<MazeCell> reachableCells, int x, int y)
        {
            MazeCell Cell = GetMazeCell(x, y);
            if (Cell != null && Cell.isReachable)
            {
                reachableCells.Add(Cell);
            }
        }

        internal void Generate()
        {
            NewMaze();

            //«аполним список клеток лабиринта которые на данном этапе €вл€ютс€ недостижимыми
            List<MazeCell> nonReachableCells = new List<MazeCell>();

            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    if (map[x, y] is MazeCell)
                    {
                        nonReachableCells.Add(map[x, y] as MazeCell);
                    }
                }
            }

            //Ћевую нижнюю клетку будет достижимой, т.к. это точка старта
            MazeCell startCell = GetMazeCell(1, 1);
            startCell.isReachable = true;
            nonReachableCells.Remove(startCell);

            //ѕеребираем недостижимые €чейки, чтобы сделать проходы в лабиринтах
            while (nonReachableCells.Count > 0)
            {
                //ѕолучаем следующую недостижимую €чейку лабиринта
                MazeCell nextCell = nonReachableCells[Random.Range(0, nonReachableCells.Count)];

                //—писок соседних достижимых €чеек лабиринта
                List<MazeCell> reachableCells = new List<MazeCell>();
                AddReachableCell(reachableCells, nextCell.x - 2, nextCell.y);
                AddReachableCell(reachableCells, nextCell.x + 2, nextCell.y);
                AddReachableCell(reachableCells, nextCell.x, nextCell.y - 2);
                AddReachableCell(reachableCells, nextCell.x, nextCell.y + 2);

                if (reachableCells.Count > 0)
                {
                    //≈сли есть соседние достижимые точки, выберем случайную, дл€ генерации прохода
                    MazeCell nearCell = reachableCells[Random.Range(0, reachableCells.Count)];

                    //√енерируем проход, помечаем стену открытой
                    int wallX = (nextCell.x + nearCell.x) / 2;
                    int wallY = (nextCell.y + nearCell.y) / 2;
                    (map[wallX, wallY] as MazeWall).isOpen = true;

                    //ѕомечаем €чейку достижимой
                    nextCell.isReachable = true;

                    //убераем €чейку из списка недостижимых
                    nonReachableCells.Remove(nextCell);

                }
            }
            Debug.Log("Generate comlete");
        }

        internal void ShowMazeCenterAndZero()
        {
            if (mazeCenter == null)
            {
                mazeCenter = new GameObject();
                mazeCenter.name = "MazeCenter";
                mazeCenter.transform.position = new Vector3(Global.GetWorldXFromMazeX(Settings.maze_width), 0f, Global.GetWorldYFromMazeY(Settings.maze_height));

                mazeZero = new GameObject();
                mazeZero.name = "MazeZero";
                mazeZero.transform.position = new Vector3(0f, 0f, 0f);
                mazeZero.transform.parent = mazeCenter.transform;

            }
        }

        internal void Show()
        {
            
            ShowMazeCenterAndZero();

            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    map[x, y].Show();
                }
            }
            Debug.Log("Show comlete");
        }
    }

}
