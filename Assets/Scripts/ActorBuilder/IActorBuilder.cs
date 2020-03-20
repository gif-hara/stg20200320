using UnityEngine;
using UnityEngine.Assertions;

namespace HK.STG
{
    /// <summary>
    /// 
    /// </summary>
    public interface IActorBuilder
    {
        void Entry(Actor actor);

        void Update();
    }
}
