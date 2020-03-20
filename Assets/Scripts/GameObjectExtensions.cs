using UnityEngine;
using UnityEngine.Assertions;

namespace HK.STG
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Extensions
    {
        public static void SetLayerRecursive(this GameObject self, int layer)
        {
            self.layer = layer;
            for (var i = 0; i < self.transform.childCount; i++)
            {
                SetLayerRecursive(self.transform.GetChild(i).gameObject, layer);
            }
        }
    }
}
