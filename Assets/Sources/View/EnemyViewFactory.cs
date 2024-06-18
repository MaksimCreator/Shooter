using Game.Model;
using UnityEngine;

public class EnemyViewFactory : TransformableViewFactory<Enemy> 
{
    [SerializeField] private TransformableView _orge;

    private EnemyVisiter _enemyVisiter;

    private void Awake() => _enemyVisiter = new EnemyVisiter(_orge);

    protected override TransformableView GetTempley(Enemy entity)
    {
        _enemyVisiter.Visit((dynamic)entity);
        return _enemyVisiter.Templay;
    }

    private class EnemyVisiter : IEnemyVisiter
    {
        public TransformableView Templay { get; private set; }

        private readonly TransformableView _orge;

        public EnemyVisiter(TransformableView orge)
        {
            _orge = orge;
        }

        public void Visit(Orge orge) => Templay = _orge;
    }
}
