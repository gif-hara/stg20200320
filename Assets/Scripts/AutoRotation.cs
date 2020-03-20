using UnityEngine;
using UnityEngine.Assertions;

namespace HK.STG
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class AutoRotation : MonoBehaviour
    {
        [SerializeField]
        private float speed = default;

        private Vector3 vector = default;

        void Start()
        {
            this.vector = Random.insideUnitSphere;
        }

        void Update()
        {
            var angle = this.speed * Time.deltaTime;
            this.transform.localRotation *= Quaternion.AngleAxis(angle, this.vector);
        }
    }
}
