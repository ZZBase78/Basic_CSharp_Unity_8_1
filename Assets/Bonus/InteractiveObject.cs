using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZZBase.Maze;

namespace ZZBase.Bonus
{
    internal abstract class InteractiveObject : MonoBehaviour, IInteractable
    {
        public bool IsInteractable { get; } = true;
        protected abstract void Interaction();

        private void Start()
        {
            Action();
        }

        public void Action()
        {
            Renderer[] renderers = GetComponentsInChildren<Renderer>();
            foreach(Renderer renderer in renderers)
            {
                renderer.material.color = Random.ColorHSV();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Interaction();
            Global.bonusSpawner.DestroyBonus(gameObject);
        }

    }
}

