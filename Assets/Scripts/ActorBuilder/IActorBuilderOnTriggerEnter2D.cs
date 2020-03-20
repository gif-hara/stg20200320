using UnityEngine;
using UnityEngine.Assertions;

namespace HK.STG.ActorBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public interface IActorBuilderOnTriggerEnter2D : IActorBuilder
    {
        void OnTriggerEnter2D(Actor collideActor);
    }
}
