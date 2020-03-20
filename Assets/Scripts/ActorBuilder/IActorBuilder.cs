using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.STG.ActorBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public interface IActorBuilder : ICloneable
    {
        void Entry(Actor actor);

        void Update();
    }
}
