using Game.Model;
using UnityEngine;

public abstract class TransformableViewFactory<T> : MonoBehaviour
{
    public void Creater(Simulated<T>.PlacedEntity entity)
    {

    }

    public void Destroy(Simulated<T>.PlacedEntity entity)
    {

    }

    protected abstract TransformableView GetTempley(T entity);
}