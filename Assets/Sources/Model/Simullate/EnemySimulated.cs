namespace Game.Model
{
    public class EnemySimulated : Simulated<Enemy>
    {
        public void Simulated(Enemy enemy)
        {

        }

        public override void Update(float delta)
        {
            foreach (var entity in Entites)
                entity.Entity.Update(delta);
        }
    }
}
