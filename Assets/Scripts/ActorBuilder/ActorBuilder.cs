using System;

namespace HK.STG.ActorBuilder
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public abstract class ActorBuilder : IActorBuilder
    {
        protected Actor owner;

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public virtual void Entry(Actor actor)
        {
            this.owner = actor;
        }

        public virtual void Update()
        {
        }
    }
}
