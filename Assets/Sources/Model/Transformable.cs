using UnityEngine;

namespace Game.Model
{
    public class Transformable
    {
        public virtual Vector3 Position { get; protected set; }
        public Vector2 Rotation { get; protected set; }

        public Transformable(Vector3 position, Vector2 rotation)
        {
            Position = position;
            Rotation = rotation;
        }
    }
}