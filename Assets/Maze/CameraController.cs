using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Maze
{
    internal class CameraController : MonoBehaviour
    {
        private Vector3 offset;

        private void Awake()
        {
            offset = Vector3.up * 10f;
        }
        private void LateUpdate()
        {
            if (Global.player != null)
            {
                Vector3 targetPosition;
                if (Global.CameraBonusTime > 0)
                {
                    targetPosition = Global.player.transform.position + offset * 2f;
                }
                else
                {
                    targetPosition = Global.player.transform.position + offset;
                }
                transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
            }
        }
    }
}
