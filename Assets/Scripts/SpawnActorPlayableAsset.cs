using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace HK.STG
{
    [System.Serializable]
    public class SpawnActorPlayableAsset : PlayableAsset
    {
        public List<Element> elements = default;

        // Factory method that generates a playable based on this asset
        public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
        {
            var behaviour = new SpawnActorPlayableBehaviour();
            behaviour.Initialize(this.elements);

            return ScriptPlayable<SpawnActorPlayableBehaviour>.Create(graph, behaviour);
        }

        [Serializable]
        public class Element
        {
            [SerializeField]
            private Vector3 spawnPosition;

            [SerializeField]
            private ActorSpawner spawner;

            public void Spawn()
            {
                this.spawner.Spawn(this.spawnPosition, Quaternion.identity);
            }
        }
    }
}
