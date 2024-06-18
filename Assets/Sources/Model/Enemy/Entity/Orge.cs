using System;
using UnityEngine;

namespace Game.Model
{
    public class Orge : Enemy
    {
        private const float Speed = 10f;
        private const float TimeLookAt = 3;
        private readonly EnemyHealth _health;
        private readonly EnemyMovemen _movemet;
        private readonly EnemyAttack _attack;

        public Orge(IPosition target, Vector3 StartPosition, Vector2 StartRotation,int money) : base(StartPosition, StartRotation,money)
        {
            _health = new EnemyHealth(Conffig.MaxHealthEnemy);
            _movemet = new EnemyMovemen(Speed,TimeLookAt,target);
            _attack = new EnemyAttack();
        }

        public override void InitPhysics(PhysicRouter router, PhysicsEventBroadcaster Broadcaster) => Broadcaster.Init(router, _health);

        public override void Update(float delta)
        {
            if (delta < 0)
                throw new InvalidOperationException(nameof(delta));

            if (IsActive)
            {
                _movemet.Move(delta);
                _movemet.LookAt();
            }

            _health.Update(IsActive);
        }
    }
}