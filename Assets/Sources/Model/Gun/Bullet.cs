namespace Game.Model
{
    public class Bullet
    {
        public readonly float Damage;
        public readonly float Speed;
        public readonly float LifeTime;

        public Bullet(float damage, float speed)
        {
            Damage = damage;
            Speed = speed;
        }
    }
}