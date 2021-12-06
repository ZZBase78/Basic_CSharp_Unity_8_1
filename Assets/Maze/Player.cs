using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Maze
{
    internal class Player : MonoBehaviour
    {
        private Rigidbody rb;
        private float speed;
        private bool changeMainController;
        private int score;

        internal void AddScore(int value)
        {
            score += value;
            Global.CheckVictory();
        }
        internal int GetScore()
        {
            return score;
        }

        private void Awake()
        {
            Global.player = gameObject;
            Global.player_script = this;
            rb = GetComponent<Rigidbody>();
            speed = 5f;
            score = 0;
        }

        void Move()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            Vector3 force = new Vector3(x, 0f, y);
            rb.AddForce(force * speed);
        }

        void MouseMove()
        {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");
            Vector3 force = new Vector3(x, 0f, y);
            rb.AddForce(force * speed);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab)) changeMainController = true;
        }

        private void LateUpdate()
        {
            if (changeMainController)
            {
                Global.ChangeMainController(!Global.mainController);
                changeMainController = false;
            }
        }

        private void FixedUpdate()
        {
            //Основное управление
            if (Global.mainController)
            {
                Move();
            }
            else
            {
                MouseMove();
            }
            
        }
    }
}
