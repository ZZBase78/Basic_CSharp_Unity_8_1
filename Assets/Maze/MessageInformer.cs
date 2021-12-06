using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZZBase.Maze
{
    internal class MessageInformer : MonoBehaviour
    {
        [SerializeField]
        private Text text;
        private float timeToDestroy;

        internal void SetText(string value)
        {
            text.text = value;
            timeToDestroy = 3f;
        }

        private void Update()
        {
            timeToDestroy = timeToDestroy - Time.deltaTime;
            if (timeToDestroy <= 0) Destroy(gameObject);
        }

    }
}
