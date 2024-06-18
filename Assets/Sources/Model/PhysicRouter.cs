using System;
using System.Collections.Generic;
using System.Linq;

public class PhysicRouter
{
    private Collision _collisions = new Collision();

    private readonly Func<IEnumerable<Record>> _recordProvader;

    public PhysicRouter(Func<IEnumerable<Record>> recordProvader)
    {
        _recordProvader = recordProvader;
    }

    public void TryAddCollision(object modelA, object modelB) => _collisions.TryBind(modelA, modelB);

    public void Setep()
    {
        foreach (var pair in _collisions.Pair)
            TryRoute(pair);

        _collisions = new Collision();
    }

    public void TryRoute((object, object) pair)
    {
        IEnumerable<Record> records = _recordProvader?.Invoke().Where(record => record.IsTarget(pair));

        foreach (var record in records)
            ((dynamic)record).Do((dynamic)pair.Item1, (dynamic)pair.Item2);
    }

    public abstract class Record
    {
        public abstract bool IsTarget((object, object) pair);
    }

    public sealed class Record<T1, T2> : Record
    {
        private Action<T1, T2> _action;

        public Record(Action<T1, T2> action)
        {
            _action = action;
        }

        public void Do(T1 A, T2 B) => _action(A, B);

        public void Do(T2 B, T1 A) => _action(A, B);

        public override bool IsTarget((object, object) pair)
        {
            if (pair.Item1 is T1 && pair.Item2 is T2)
                return true;

            if (pair.Item1 is T2 && pair.Item2 is T1)
                return true;
            return false;
        }
    }

    private class Collision
    {
        private List<(object, object)> _pair = new List<(object, object)>();

        public IEnumerable<(object, object)> Pair => _pair;

        public void TryBind(object A, object B)
        {
            foreach (var (left, right) in _pair)
            {
                if (A == left && B == right)
                    return;

                if (A == right && B == left)
                    return;
            }

            _pair.Add((A, B));
        }
    }
}