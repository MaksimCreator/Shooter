using System;
using UnityEngine;

namespace Game.Model
{
    public abstract class Enemy : Transformable
    {
        protected bool IsActive;

        public event Action<float> IsDead;

        public Enemy(Vector3 StartPosition, Vector2 StartRotation, int money) : base(StartPosition, StartRotation) { }

        public abstract void InitPhysics(PhysicRouter router, PhysicsEventBroadcaster Broadcaster);

        public abstract void Update(float delta);
    }
}
