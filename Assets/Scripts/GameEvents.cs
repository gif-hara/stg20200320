using HK.Framework.EventSystems;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.STG
{
    /// <summary>
    /// ゲーム内に発生するイベント
    /// </summary>
    public static class GameEvents
    {
        /// <summary>
        /// <see cref="Actor"/>が生成された際のイベント
        /// </summary>
        public class SpawnedActor : Message<SpawnedActor, Actor>
        {
            public Actor Actor => this.param1;
        }
    }
}
