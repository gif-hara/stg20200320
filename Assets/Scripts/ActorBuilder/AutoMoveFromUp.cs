using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.STG.ActorBuilder
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed class AutoMoveFromUp : ActorBuilder
    {
        [SerializeField]
        private float speed = default;

        public override void Update()
        {
            this.owner.CachedTransform.localPosition += this.owner.CachedTransform.up * this.speed;
        }
    }
}
