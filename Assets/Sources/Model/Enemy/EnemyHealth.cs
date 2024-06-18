namespace Game.Model
{
    public class EnemyHealth : Health
    {

        public EnemyHealth(int health) : base(health) { }

        public void Update(bool IsActiveEnemy)
        {
            if (IsActiveEnemy == false && CanHeal())
                Heal();
        }
    }
}