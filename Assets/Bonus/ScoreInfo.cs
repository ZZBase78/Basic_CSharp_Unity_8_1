using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZZBase.Maze;

namespace ZZBase.Bonus
{
    public class ScoreInfo : MonoBehaviour
    {
        [SerializeField] private Text text;

        void Update()
        {
            if (Global.player == null)
            {
                text.text = "";
            }
            else
            {
                text.text = "Набрано очков: " + Global.player_script.GetScore();
            }
        }
    }
}
