using System;
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

        public ActorParameter Parameter { get; private set; }

        private bool isDead = false;

        void Awake()
        {
            this.CachedTransform = this.transform;
            this.Parameter = new ActorParameter(this);
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

        void OnTriggerEnter2D(Collider2D other)
        {
            var collideActor = GetParentActor(other.transform);
            if(collideActor == null)
            {
                return;
            }

            this.InvokeEvent<IActorBuilderOnTriggerEnter2D>(x => x.OnTriggerEnter2D(collideActor));
        }

        public void Dead()
        {
            if(this.isDead)
            {
                return;
            }

            this.isDead = true;
        }

        private void InvokeEvent<T>(Action<T> action) where T : IActorBuilder
        {
            foreach(var b in this.builders)
            {
                if(b is T)
                {
                    action((T)b);
                }
            }
        }

        public Actor Clone(Vector3 position, Quaternion rotation, List<IActorBuilder> builders)
        {
            var instance = Instantiate(this, position, rotation);
            instance.builders = new List<IActorBuilder>();
            if (builders != null)
            {
                foreach(var b in builders)
                {
                    var cloneBuilder = (IActorBuilder)b.Clone();
                    instance.builders.Add(cloneBuilder);
                    cloneBuilder.Entry(instance);
                }
            }

            HK.Framework.EventSystems.Broker.Global.Publish(GameEvents.SpawnedActor.Get(instance));

            return instance;
        }

        private static Actor GetParentActor(Transform transform)
        {
            var actor = transform.GetComponent<Actor>();
            if(actor != null)
            {
                return actor;
            }
            else
            {
                var parent = transform.parent;
                if(parent == null)
                {
                    return null;
                }

                return GetParentActor(parent);
            }
        }
    }
}
