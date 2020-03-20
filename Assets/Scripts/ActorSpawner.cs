using System.Collections.Generic;
using HK.STG.ActorBuilder;
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

        [SerializeReference, SubclassSelector]
        private List<IActorBuilder> builders;

        private static List<IActorBuilder> compositeBuilders = new List<IActorBuilder>();

        public Actor Spawn(Vector3 position, Quaternion rotation)
        {
            return this.prefab.Clone(position, rotation, this.builders);
        }

        public Actor Spawn(Vector3 position, Quaternion rotation, IEnumerable<IActorBuilder> additionalBuilders)
        {
            compositeBuilders.Clear();
            compositeBuilders.AddRange(this.builders);
            compositeBuilders.AddRange(additionalBuilders);

            return this.prefab.Clone(position, rotation, compositeBuilders);
        }
    }
}
