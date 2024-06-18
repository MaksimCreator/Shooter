using UnityEngine;

namespace Game.Model
{
    public abstract class GunInfo : ScriptableObject
    {
        public readonly string Description;
        public readonly int Damadg;
        public readonly int TimeAttack;
        public readonly Animator Animator;
    }
}
