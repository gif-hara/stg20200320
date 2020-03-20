using HK.Framework.EventSystems;
using UnityEngine;
using UnityEngine.Assertions;
using UniRx;
using UniRx.Triggers;

namespace HK.STG
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ActorInputController : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed = default;

        private Actor controlledActor;

        void Awake()
        {
            Broker.Global.Receive<GameEvents.SpawnedActor>()
                .Where(x => x.Actor.CompareTag(Tags.Name.ActorPlayer))
                .SubscribeWithState(this, (x, _this) =>
                {
                    _this.controlledActor = x.Actor;
                })
                .AddTo(this);

            this.UpdateAsObservable()
                .Where(_ => this.controlledActor != null)
                .SubscribeWithState(this, (_, _this) =>
                {
                    var velocity = Vector3.zero;
                    velocity.x = Input.GetKey(KeyCode.LeftArrow) ? -1.0f : Input.GetKey(KeyCode.RightArrow) ? 1.0f : 0.0f;
                    velocity.y = Input.GetKey(KeyCode.UpArrow) ? 1.0f : Input.GetKey(KeyCode.DownArrow) ? -1.0f : 0.0f;
                    _this.controlledActor.CachedTransform.localPosition += velocity.normalized * _this.moveSpeed;
                });
        }
    }
}
