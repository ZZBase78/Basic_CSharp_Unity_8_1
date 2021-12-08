using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZZBase.Maze;

namespace ZZBase.Bonus
{
    internal class ChangeControlBonus : InteractiveObject
    {
        public override bool IsGoodBonus()
        {
            return false;
        }

        protected override void Interaction()
        {
            Global.player_script.AddBrokeControl(10f);
        }
    }
}
