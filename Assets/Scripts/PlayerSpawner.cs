using HK.Framework.EventSystems;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.STG
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class PlayerSpawner : MonoBehaviour
    {
        [SerializeField]
        private Actor prefab = default;

        [SerializeField]
        private Transform spawnPosition = default;

        void Start()
        {
            var instance = Instantiate(this.prefab, this.spawnPosition.position, Quaternion.identity);
            instance.gameObject.tag = Tags.Player;
            Broker.Global.Publish(GameEvents.SpawnedActor.Get(instance));
        }
    }
}
