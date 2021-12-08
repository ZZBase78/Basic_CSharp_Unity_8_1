using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZZBase.Maze;
using static UnityEngine.Debug;
using System;

namespace ZZBase.Bonus
{
    internal abstract class InteractiveObject : MonoBehaviour, IInteractable, ICloneable, IDisposable
    {
        public bool IsInteractable { get; } = true;

        public abstract bool IsGoodBonus();
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
                renderer.material.color = UnityEngine.Random.ColorHSV();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Log(this.GetType());
            Interaction();
            Global.bonusSpawner.DestroyBonus(gameObject);
        }

        public object Clone()
        {
            return Instantiate(gameObject, gameObject.transform.position, gameObject.transform.rotation);
        }

        public void Dispose()
        {
            Log("Dispose " + this.GetType());
            Global.bonusSpawner.DestroyBonus(gameObject);
        }
    }
}

