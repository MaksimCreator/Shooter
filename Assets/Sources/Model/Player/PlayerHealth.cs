using System;

namespace Game.Model
{
    public class PlayerHealth : Health
    {
        private readonly float _timeBeforeStartTreatment = Conffig.TimeBeforeStartTreatmentSecond;
        private readonly float _HealPerSecond = Conffig.PlayerHealPerSecond;

        private float _timer = 0;

        public PlayerHealth(int Health) : base(Health) { }

        public void Heal(int heal) => Heal((float)heal);

        public void Update(float delta)
        {
            if (delta < 0)
                throw new InvalidOperationException(nameof(delta));

            if (CanHeal())
            {
                if (_timer >= _timeBeforeStartTreatment)
                    Heal(_HealPerSecond * delta);
                else
                    _timer += delta;
            }
        }

        protected override void OnTakeDamage() => RestartTimer();

        private void RestartTimer() => _timer = 0;
    }
}
