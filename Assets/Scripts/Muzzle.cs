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
    public sealed class Muzzle : MonoBehaviour
    {
        [SerializeField]
        private ActorSpawner spawner = default;

        [SerializeField]
        private int coolTime = default;

        private int currentCoolTime;

        public void Initialize(Actor owner)
        {
            owner.UpdateAsObservable()
                .SubscribeWithState(this, (_, _this) =>
                {
                    _this.currentCoolTime--;
                });

            owner.Broker.Receive<ActorEvents.Fire>()
                .Where(_ => this.currentCoolTime <= 0)
                .SubscribeWithState(this, (_, _this) =>
                {
                    _this.spawner.Spawn(_this.transform.position, _this.transform.rotation);
                })
                .AddTo(owner);
        }
    }
}
