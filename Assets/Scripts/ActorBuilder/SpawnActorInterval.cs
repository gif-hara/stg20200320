using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.STG.ActorBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SpawnActorInterval : IActorBuilder
    {
        [SerializeField]
        private List<ActorSpawner> spawners = default;

        [SerializeField]
        private int interval = default;

        [SerializeField]
        private int initial = default;

        [SerializeField]
        private Vector3 offsetPosition = default;

        [SerializeField]
        private Vector3 offsetRotation = default;

        private int currentFrame = 0;

        private Actor owner;

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void Entry(Actor actor)
        {
            this.owner = actor;
            this.currentFrame = this.initial;
        }

        public void Update()
        {
            if(this.currentFrame <= 0)
            {
                this.currentFrame = this.interval;
                foreach(var s in this.spawners)
                {
                    var position = this.owner.CachedTransform.position + this.offsetPosition;
                    var rotation = this.owner.CachedTransform.rotation * Quaternion.Euler(this.offsetRotation);
                    s.Spawn(position, rotation);
                }
            }
            else
            {
                this.currentFrame--;
            }
        }
    }
}
