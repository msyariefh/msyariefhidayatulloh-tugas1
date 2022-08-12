using UnityEngine;
using System;

namespace HiDE.ZombieTap.Spawner
{
    [Serializable]
    public class CharacterObject
    {
        public enum CharacterType
        {
            Human,
            Zombie,
            SpecialZombie
        }

        [SerializeField] private CharacterType type;
        [SerializeField] private GameObject objectGame;
        private bool isInUse;

        public CharacterType Type
        {
            get { return type; }
            set { type = value; }
        }
        public GameObject ObjectGame
        {
            get { return objectGame; }
            set { objectGame = value; }
        }
        public bool IsInUse 
        {
            get { return isInUse; }
            set { isInUse = value; } 
        }

    }
}
