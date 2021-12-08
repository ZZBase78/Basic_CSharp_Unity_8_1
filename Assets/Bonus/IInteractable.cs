using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Bonus
{
    internal interface IInteractable : IAction
    {
        bool IsInteractable { get; }
    }
}
