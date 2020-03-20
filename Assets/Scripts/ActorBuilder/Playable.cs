using UnityEngine;
using UnityEngine.Assertions;

namespace HK.STG.ActorBuilder
{
    /// <summary>
    /// タグを設定する<see cref="ActorBuilder"/>
    /// </summary>
    public sealed class Playable : ActorBuilder
    {
        [SerializeField]
        private float moveSpeed = default;

        public override void Update()
        {
            var velocity = Vector3.zero;
            velocity.x = Input.GetKey(KeyCode.LeftArrow) ? -1.0f : Input.GetKey(KeyCode.RightArrow) ? 1.0f : 0.0f;
            velocity.y = Input.GetKey(KeyCode.UpArrow) ? 1.0f : Input.GetKey(KeyCode.DownArrow) ? -1.0f : 0.0f;
            this.owner.CachedTransform.localPosition += velocity.normalized * this.moveSpeed;
        }
    }
}
