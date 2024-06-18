using Game.Model;
using UnityEngine;

namespace Game.CompositRoot
{
    public class EnemyCompostRoot : CompositRoot
    {
        [SerializeField] private EnemyViewFactory _enemyFactory;

        private EnemySimulated _simulated;
        private EnemySpawner _spawner;

        public override void Compose()
        {
            _simulated = new EnemySimulated();
            _spawner = new EnemySpawner();
        }

        private void OnEnable()
        {
            _simulated.OnStart += _enemyFactory.Creater;
            _simulated.OnEnd += _enemyFactory.Destroy;
        }

        private void OnDisable()
        {
            _simulated.OnStart -= _enemyFactory.Creater;
            _simulated.OnEnd -= _enemyFactory.Destroy;
        }
    }
}
