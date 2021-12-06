using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZZBase.Bonus;
using UnityEngine.SceneManagement;

namespace ZZBase.Maze
{
    internal static class Global
    {
        internal static World world;
        internal static Maze maze;
        internal static GameObject player;
        internal static Player player_script;
        internal static bool mainController;
        internal static GameObject messageInformer_go;
        internal static BonusSpawner bonusSpawner;

        internal static void CheckVictory()
        {
            if (player_script.GetScore() >= Settings.max_score)
            {
                SceneManager.LoadScene(1);
            }
        }
        internal static void SetMessageInfo(string text)
        {
            if (messageInformer_go == null)
            {
                messageInformer_go = GameObject.Instantiate(world.prefabs[4], Vector3.zero, Quaternion.identity);
            }
            MessageInformer messageInformer = messageInformer_go.GetComponent<MessageInformer>();
            messageInformer.SetText(text);
        }
        internal static void Awake()
        {
            ChangeMainController(true);
        }

        internal static void ChangeMainController(bool value)
        {
            mainController = value;
            if (mainController == true)
            {
                SetMessageInfo("”правление с клавиатуры"); 
            }else
            {
                SetMessageInfo("”правление мышью");
            }

        }

        private static void InstantiatePlayer()
        {
            Vector3 playerPosition = new Vector3(GetWorldXFromMazeX(1), 1f, GetWorldYFromMazeY(1));
            GameObject.Instantiate(world.prefabs[3], playerPosition, Quaternion.identity);
        }

        internal static void Start()
        {
            maze = new Maze();
            maze.Generate();
            maze.Show();
            InstantiatePlayer();

            //ScoreInfo
            GameObject.Instantiate(world.prefabs[5], Vector3.zero, Quaternion.identity);

            //BonusSpawner
            GameObject.Instantiate(world.prefabs[6], Vector3.zero, Quaternion.identity);
        }

        internal static bool IsEven(int value)
        {
            return ((value % 2) == 0);
        }

        internal static float GetWorldXFromMazeX(int x)
        {
            return Settings.cell_width / 2f * (float)x;
        }
        internal static float GetWorldYFromMazeY(int y)
        {
            return Settings.cell_height / 2f * (float)y;
        }

        internal static void SetCursorVisible(bool value)
        {
            if (value)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

    }
}

