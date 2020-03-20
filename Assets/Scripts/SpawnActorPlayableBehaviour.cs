using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace HK.STG
{
    // A behaviour that is attached to a playable
    public class SpawnActorPlayableBehaviour : PlayableBehaviour
    {
        private List<SpawnActorPlayableAsset.Element> elements;

        public void Initialize(List<SpawnActorPlayableAsset.Element> elements)
        {
            this.elements = elements;
        }

        // Called when the state of the playable is set to Play
        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            foreach(var e in this.elements)
            {
                e.Spawn();
            }
        }
    }
}
