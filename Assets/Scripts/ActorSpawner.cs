using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.STG
{
    /// <summary>
    /// <see cref="Actor"/>を生成する<see cref="ScriptableObject"/>
    /// </summary>
    [CreateAssetMenu(menuName = "STG/ActorSpawner")]
    public sealed class ActorSpawner : ScriptableObject
    {
        [SerializeField]
        private Actor prefab = default;

        private List<IActorBuilder> builders;

        public void Spawn(Vector3 position, Quaternion rotation)
        {
            var instance = this.prefab.Clone(position, rotation, this.builders);
        }
    }
}
