using HK.Framework.EventSystems;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.STG
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SpawnActorOnStart : MonoBehaviour
    {
        [SerializeField]
        private ActorSpawner spawner = default;

        [SerializeField]
        private Transform spawnPosition = default;

        void Start()
        {
            this.spawner.Spawn(this.spawnPosition.position, this.spawnPosition.rotation);
        }
    }
}
