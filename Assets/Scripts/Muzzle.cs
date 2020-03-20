using System;
using System.Collections.Generic;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Assertions;
using UniRx;

namespace HK.STG
{
    /// <summary>
    /// <see cref="Actor"/>を射出するクラス
    /// </summary>
    [Serializable]
    public sealed class Muzzle
    {
        [SerializeField]
        private ActorSpawner spawner = default;

        [SerializeField]
        private int coolTime = default;

        [SerializeField]
        private Vector3 offsetPosition = default;

        [SerializeField]
        private Vector3 offsetRotation = default;

        private int currentCoolTime;

        public void Update()
        {
            this.currentCoolTime--;
        }

        public void Fire(Actor actor)
        {
            if(this.currentCoolTime > 0)
            {
                return;
            }

            var position = actor.CachedTransform.position + this.offsetPosition;
            var rotation = actor.CachedTransform.rotation * Quaternion.Euler(this.offsetRotation);
            this.spawner.Spawn(position, rotation);
        }
    }
}
