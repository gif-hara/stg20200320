using UnityEngine;
using UnityEngine.Assertions;

namespace HK.STG
{
    /// <summary>
    /// タグに関するクラス
    /// </summary>
    public static class Tags
    {
        public enum Enum
        {
            ActorPlayer,
        }

        public static class Name
        {
            public const string ActorPlayer = "Actor/Player";
        }

        public static Enum AsEnum(string tag)
        {
            switch(tag)
            {
                case Name.ActorPlayer:
                    return Enum.ActorPlayer;
                default:
                    Assert.IsTrue(false, $"{tag} は未対応です");
                    return 0;
            }
        }

        public static string AsName(Enum type)
        {
            switch(type)
            {
                case Enum.ActorPlayer:
                    return Name.ActorPlayer;
                default:
                    Assert.IsTrue(false, $"{type} は未対応です");
                    return "";
            }
        }
    }
}
