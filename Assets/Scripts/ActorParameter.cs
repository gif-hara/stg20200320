using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.STG
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ActorParameter
    {
        private Actor owner;

        public IReadOnlyReactiveProperty<int> HitPoint => this.hitPoint;
        private ReactiveProperty<int> hitPoint = new ReactiveProperty<int>();

        public ActorParameter(Actor owner)
        {
            this.owner = owner;
        }

        public void TakeDamage(int damage)
        {
            this.hitPoint.Value -= damage;
            if(this.hitPoint.Value <= 0)
            {
                this.owner.Dead();
            }
        }
    }
}
