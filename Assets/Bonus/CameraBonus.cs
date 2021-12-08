using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZZBase.Maze;

namespace ZZBase.Bonus
{
    internal class CameraBonus : InteractiveObject
    {
        public override bool IsGoodBonus()
        {
            return true;
        }

        protected override void Interaction()
        {
            Global.AddCameraBonusTime(10f);
        }
    }
}
