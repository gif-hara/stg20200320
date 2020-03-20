using System.Collections.Generic;
using HK.STG.ActorBuilder;
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

        private List<IActorBuilder> builders = null;

        void Awake()
        {
            this.CachedTransform = this.transform;
        }

        void Update()
        {
            if(this.builders != null)
            {
                foreach(var b in this.builders)
                {
                    b.Update();
                }
            }
        }

        public Actor Clone(Vector3 position, Quaternion rotation, List<IActorBuilder> builders)
        {
            var instance = Instantiate(this, position, rotation);
            instance.builders = builders;

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
