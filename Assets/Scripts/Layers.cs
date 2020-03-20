using UnityEngine;
using UnityEngine.Assertions;

namespace HK.STG
{
    /// <summary>
    /// レイヤーに関するクラス
    /// </summary>
    public static class Layers
    {
        public enum Enum
        {
            ActorPlayer       = 8,
            ActorEnemy        = 9,
            ActorPlayerBullet = 10,
            ActorEnemyBullet  = 11,
        }

        public static class Mask
        {
            public const int ActorPlayer = 1 << 8;
            public const int ActorEnemy = 1 << 9;
            public const int ActorPlayerBullet = 1 << 10;
            public const int ActorEnemyBullet = 1 << 11;
        }

        public static int AsLayerMask(Enum type)
        {
            switch(type)
            {
                case Enum.ActorPlayer:
                    return Mask.ActorPlayer;
                case Enum.ActorEnemy:
                    return Mask.ActorEnemy;
                case Enum.ActorPlayerBullet:
                    return Mask.ActorPlayerBullet;
                case Enum.ActorEnemyBullet:
                    return Mask.ActorEnemyBullet;
                default:
                    Assert.IsTrue(false, $"{type}は未対応です");
                    return 0;
            }
        }
    }
}
