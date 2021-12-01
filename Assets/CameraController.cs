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
                transform.position = Global.player.transform.position + offset;
            }
        }
    }
}
