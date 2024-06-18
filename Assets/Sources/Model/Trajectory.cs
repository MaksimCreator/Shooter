using System;
using UnityEngine;

namespace Game.Model
{
    public class Trajectory : Transformable
    {
        private readonly Vector3 _startPosition;
        private readonly Vector3 _direction;
        private readonly Func<Trajectory,float> _accamulatedTime;
        private readonly float _speed;

        public override Vector3 Position => _startPosition + (_direction * _speed * _accamulatedTime.Invoke(this));

        public Trajectory(Vector3 Position,Vector3 direction, float speed, Func<Trajectory,float> accamulatedTime) : base(Position,Vector2.zero) 
        {
            _startPosition = Position;
            _direction = direction;
            _speed = speed;
            _accamulatedTime = accamulatedTime;
        }
    }
}
