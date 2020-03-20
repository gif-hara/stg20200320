using UnityEngine;
using UnityEngine.Assertions;

namespace HK.STG.ActorBuilder
{
    /// <summary>
    /// レイヤーを設定する<see cref="ActorBuilder"/>
    /// </summary>
    public sealed class SetLayer : ActorBuilder
    {
        [SerializeField]
        private Layers.Enum layerType = default;

        public override void Entry(Actor actor)
        {
            base.Entry(actor);
            actor.gameObject.SetLayerRecursive((int)this.layerType);
        }
    }
}
