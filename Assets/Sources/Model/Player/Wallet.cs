using System;

namespace Game.Model
{
    public class Wallet
    {
        public int Coins { get; private set; }

        private readonly EnemyVisiter _enemyVisiter = new EnemyVisiter();

        public void OnDead(Enemy enemy)
        {
            _enemyVisiter.Visit((dynamic)enemy);
            Coins += _enemyVisiter.AccamulatedCoins;
        }

        public void Buy(int price)
        {
            if (Coins < price)
                throw new InvalidOperationException(nameof(price));

            Coins -= price;
        }

        
        private class EnemyVisiter : IEnemyVisiter
        {
            private int _accamulatedCoins;

            public int AccamulatedCoins
            {
                get 
                {
                    int value = _accamulatedCoins;
                    _accamulatedCoins = 0;
                    return value;
                }
            }

            public void Visit(Orge orge) => _accamulatedCoins += 10;
        }
    }
}