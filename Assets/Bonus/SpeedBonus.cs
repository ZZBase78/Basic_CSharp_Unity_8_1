using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZZBase.Maze;

namespace ZZBase.Bonus
{
    internal class SpeedBonus : InteractiveObject
    {
        public override bool IsGoodBonus()
        {
            return true;
        }

        protected override void Interaction()
        {
            Global.player_script.SpeedUp(10f);
        }
    }
}

