using System;

namespace Game.Model
{
    public abstract class Health
    {
        private readonly int _maxHelth;

        public float CurentHealth { get; private set; }

        public int MaxHealth => _maxHelth;

        public event Action IsDead;

        public Health(int health)
        {
            CurentHealth = health;
            _maxHelth = health;
        }

        public bool CanHeal() => CurentHealth < _maxHelth;

        public void TakeDamage(float damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            if (CurentHealth > 0)
            {
                CurentHealth -= damage;
                if (CurentHealth <= 0)
                    IsDead?.Invoke();
            }

            OnTakeDamage();
        }

        protected void Heal(float heal)
        {
            if (CanHeal() == false)
                throw new InvalidOperationException();

            if (heal < 0)
                throw new InvalidOperationException(nameof(heal));

            if (CurentHealth + heal > _maxHelth)
            {
                CurentHealth = _maxHelth;
                return;
            }

            CurentHealth += heal;
        }

        protected void Heal()
        {
            if (CanHeal() == false)
                throw new InvalidOperationException();

            CurentHealth = _maxHelth;
        }

        protected virtual void OnTakeDamage() { }
    }
}