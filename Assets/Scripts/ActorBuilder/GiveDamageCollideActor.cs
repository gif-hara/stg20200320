using UnityEngine;
using UnityEngine.Assertions;

namespace HK.STG.ActorBuilder
{
    /// <summary>
    /// 衝突した<see cref="Actor"/>に対してダメージを与える<see cref="IActorBuilder"/>
    /// </summary>
    public sealed class GiveDamageCollideActor : IActorBuilder, IActorBuilderOnTriggerEnter2D
    {
        [SerializeField]
        private int power = default;

        public void Entry(Actor actor)
        {
        }

        public void Update()
        {
        }

        public void OnTriggerEnter2D(Actor collideActor)
        {
            collideActor.Parameter.TakeDamage(this.power);
        }
    }
}
