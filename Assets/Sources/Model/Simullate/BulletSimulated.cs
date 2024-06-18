using UnityEngine;

namespace Game.Model
{
    public class BulletSimulated : Simulated<Bullet>
    {
        private Timers<PlacedEntity> _timers = new Timers<PlacedEntity>();

        public void Sumulate(Bullet bullet, Vector3 StartPosition, Vector3 direction)
        {
            PlacedEntity entity = null;
            Trajectory trajectoryBullet = new Trajectory(StartPosition,direction,bullet.Speed,(_) => _timers.GetAccamulatedTime(entity));
            entity = new PlacedEntity(bullet, trajectoryBullet);

            _timers.Start(bullet.LifeTime,entity,Stop);
        }

        public override void Update(float delta)
        {
            _timers.Tick(delta);
        }

        protected override void OnStop(PlacedEntity entity)
        {
            _timers.AllStop(entity);
        }
    }
}
