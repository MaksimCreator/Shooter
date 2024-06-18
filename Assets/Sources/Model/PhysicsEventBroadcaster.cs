using UnityEngine;

public class PhysicsEventBroadcaster : MonoBehaviour
{
    private PhysicRouter _router;
    private object _model;

    public void Init(PhysicRouter router, object model)
    {
        _router = router;
        _model = model;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PhysicsEventBroadcaster physicsModel))
            _router.TryAddCollision(_model, physicsModel._model);
    }
}
