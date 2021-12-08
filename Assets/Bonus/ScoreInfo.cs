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
        [SerializeField] private Text textDoubleSpeed;
        [SerializeField] private Text textCameraBonus;

        void Update()
        {
            if (Global.player == null)
            {
                text.text = "";
            }
            else
            {
                text.text = "������� �����: " + Global.player_script.GetScore();

                float speedUpTime = Global.player_script.GetSpeedUpTime();
                if (speedUpTime > 0)
                {
                    textDoubleSpeed.text = $"������� ��������: {speedUpTime:F0}";
                }
                else
                {
                    textDoubleSpeed.text = "";
                }

            }

            if (Global.CameraBonusTime > 0)
            {
                textCameraBonus.text = $"����� �� ������: {Global.CameraBonusTime:F0}";
            }
            else
            {
                textCameraBonus.text = "";
            }
        }
    }
}
