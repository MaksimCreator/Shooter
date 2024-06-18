namespace Game.Model
{
    public abstract class Item
    {
        private readonly float _weight;

        public float Weight => _weight;

        public Item(float Weight)
        {
            _weight = Weight;
        }
    }
}
