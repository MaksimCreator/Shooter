using System.Collections.Generic;
using System;

namespace Game.Model
{
    public class Timers<T>
    {
        private List<Timer> _timers = new List<Timer>();

        public void Start(float Time,T Context, Action<T> OnEnd) => _timers.Add(new Timer(Time,Context, OnEnd));

        public void AllStop(T model)
        {
            foreach (var timer in _timers) 
            {
                if(timer.Context.Equals(model))
                    _timers.Remove(timer);
            }
        }

        public void Tick(float Time)
        {
            foreach (var timer in _timers)
            {
                timer.AccamulatedTime += Time;

                if (timer.IsEnd)
                {
                    timer.AccamulatedTime = 0;
                    timer.OnEnd?.Invoke(timer.Context);
                }
            }
        }

        public float GetAccamulatedTime(T Context)
        {
            foreach (var item in _timers)
            {
                if(item.Context.Equals(Context))
                    return item.AccamulatedTime;
            }
            return 0;
        }

        private class Timer
        {
            private readonly float Time;

            public readonly T Context;
            public readonly Action<T> OnEnd;
            public float AccamulatedTime;

            public bool IsEnd => AccamulatedTime >= Time;

            public Timer(float time,T context, Action<T> onEnd)
            {
                Context = context;
                Time = time;
                OnEnd = onEnd;
            }
        }
    }
}
