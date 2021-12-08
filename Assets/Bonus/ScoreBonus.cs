using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZZBase.Maze;

namespace ZZBase.Bonus
{
    internal class ScoreBonus : InteractiveObject
    {

        private int bonusScore;

        private void Awake()
        {
            bonusScore = Random.Range(1, 30);
        }

        protected override void Interaction()
        {
            Global.player_script.AddScore(bonusScore);
        }

        public override bool IsGoodBonus()
        {
            return true;
        }
    }
}
