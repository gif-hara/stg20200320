using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.STG
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Actor : MonoBehaviour
    {
        public Transform CachedTransform { get; private set; }

        public IMessageBroker Broker { get; private set; } = new MessageBroker();

        void Awake()
        {
            this.CachedTransform = this.transform;
        }

        public Actor Clone(Vector3 position, Quaternion rotation, List<IActorBuilder> builders)
        {
            var instance = Instantiate(this, position, rotation);

            if(builders != null)
            {
                foreach (var b in builders)
                {
                    b.Entry(instance);
                }
            }

            HK.Framework.EventSystems.Broker.Global.Publish(GameEvents.SpawnedActor.Get(instance));

            return instance;
        }
    }
}
