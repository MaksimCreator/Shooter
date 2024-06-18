using UnityEngine;

namespace Game.Model
{
    public abstract class Gun : Item
    {
        protected readonly Animator animator;
        protected readonly float timeAttack;
        protected float timerAttack;

        public Gun(float TimeAttack, int Weight, Animator Animator) : base(Weight)
        {
            timeAttack = TimeAttack;
            animator = Animator;
        }

        public abstract void Attack();

        public abstract void Update(float delta);
    }
}