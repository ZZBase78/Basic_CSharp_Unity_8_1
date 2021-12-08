using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UnityEngine.Debug;

namespace ZZBase.Maze
{
    internal class Player : MonoBehaviour, IDisposable
    {
        private Rigidbody rb;
        private float speed;
        private bool changeMainController;
        private int score;
        private float speedUpTime;
        private float speedDownTime;
        private float ControlBrokeTime;
        private float normalSpeed;

        internal void AddBrokeControl(float value)
        {
            ControlBrokeTime += value;
        }

        internal float GetSpeedUpTime()
        {
            return speedUpTime;
        }
        internal void SpeedUp(float value)
        {
            speedUpTime += value;
        }
        internal void SpeedDown(float value)
        {
            speedDownTime += value;
        }

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
            normalSpeed = 5f;
            score = 0;
            speedUpTime = 0f;
            speedDownTime = 0f;
            ControlBrokeTime = 0f;
        }

        void Move()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            if (ControlBrokeTime > 0)
            {
                x = x * -1;
                y = y * -1;
            }
            Vector3 force = new Vector3(x, 0f, y);
            rb.AddForce(force * speed);
        }

        void MouseMove()
        {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");
            if (ControlBrokeTime > 0)
            {
                x = x * -1;
                y = y * -1;
            }
            Vector3 force = new Vector3(x, 0f, y);
            rb.AddForce(force * speed);
        }

        private void SpeedUpControl()
        {
            float speedUpValue = 1f;
            float speedDownValue = 1f;
            if (speedUpTime > 0)
            {
                speedUpTime -= Time.deltaTime;
                speedUpValue = 2f;
            }
            if (speedDownTime > 0)
            {
                speedDownTime -= Time.deltaTime;
                speedDownValue = 2f;
            }
            speed = normalSpeed * speedUpValue / speedDownValue;
        }

        private void Update()
        {
            if (ControlBrokeTime > 0) ControlBrokeTime -= Time.deltaTime;
            SpeedUpControl();
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

        public void Dispose()
        {
            Log("Dispose Player");
            Destroy(gameObject);
        }
    }
}
