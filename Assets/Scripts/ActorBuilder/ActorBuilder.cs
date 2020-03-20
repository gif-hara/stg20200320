using System;

namespace HK.STG
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public abstract class ActorBuilder : IActorBuilder
    {
        protected Actor owner;

        public virtual void Entry(Actor actor)
        {
            this.owner = actor;
        }

        public virtual void Update()
        {
        }
    }
}
