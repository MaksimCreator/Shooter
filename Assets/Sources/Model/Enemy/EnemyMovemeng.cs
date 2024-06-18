using UnityEngine;

namespace Game.Model
{
    public class EnemyMovemen
    {
        private readonly float _timeLookAt;
        private readonly float _speed;
        private readonly IPosition _target;
        private readonly Vector3 _position;

        public EnemyMovemen(float speed,float timeLookAt, IPosition target)
        {
            _timeLookAt = timeLookAt;
            _speed = speed;
            _target = target;
        }

        public Vector3 Move(float delta)
        {

            return _position;
        }

        public void LookAt()
        {

        }
    }
}