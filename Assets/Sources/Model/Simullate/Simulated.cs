using System;
using System.Collections.Generic;

namespace Game.Model
{
    public abstract class Simulated<T>
    {
        private readonly List<PlacedEntity> _entites = new List<PlacedEntity>();

        public IEnumerable<PlacedEntity> Entites => _entites;

        public event Action<PlacedEntity> OnStart;
        public event Action<PlacedEntity> OnEnd;

        public abstract void Update(float delta);

        protected void Start(PlacedEntity entity)
        {
            _entites.Add(entity);
            OnStart?.Invoke(entity);
        }

        public void Stop(PlacedEntity entity)
        {
            _entites.Remove(entity);
            OnStart?.Invoke(entity);
            OnStop(entity);
        }

        public void StopAll(T model)
        {
            foreach (var item in _entites)
            {
                if(item.Entity.Equals(model))
                    Stop(item);
            }
        }

        protected virtual void OnStop(PlacedEntity entity) { }

        public class PlacedEntity
        {
            public T Entity;
            public Transformable Transform;

            public PlacedEntity(T entity, Transformable transform)
            {
                Entity = entity;
                Transform = transform;
            }
        }
    }
}