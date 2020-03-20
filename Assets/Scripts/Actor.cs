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

        void Awake()
        {
            this.CachedTransform = this.transform;
        }
    }
}
