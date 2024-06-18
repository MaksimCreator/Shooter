using System;

namespace Game.Model
{
    public class Inventary
    {
        private readonly float _maxWeight;
        private readonly Cell[] _cells;

        private float _weight;

        public float SlowDownWeight => MathF.Abs(_weight / _maxWeight - 1);
            
        public Inventary(int LenghInventary,int MaxWeight)
        {
            if (MaxWeight < 0)
                throw new InvalidOperationException(nameof(MaxWeight));

            if (LenghInventary < 0)
                throw new InvalidOperationException(nameof(LenghInventary));

            _cells = new Cell[LenghInventary];
            _maxWeight = MaxWeight;
        }

        public Inventary(Cell[] cells)
        {
            _cells = cells;
        }

        public void AddItem(Item item,int index)
        {
            if(item == null)
                throw new InvalidOperationException(nameof(item));
            
            if (IsUpdateWieght(item, index))
            {
                _cells[index] = new Cell(item);
                _weight = 0;

                for (int i = 0; i < _cells.Length; i++)
                    if (_cells[i] != null)
                        _weight += _cells[i].Item.Weight;
            }
        }

        private bool IsUpdateWieght(Item item,int CellIndex)
        {
            if (CellIndex < 0 || CellIndex >= _cells.Length)
                throw new InvalidOperationException(nameof(CellIndex));

            float weight = 0;

            for (int i = 0; i < _cells.Length; i++)
            {
                if (i == CellIndex)
                    weight += item.Weight;

                else if (_cells[i] != null)
                    weight += _cells[i].Item.Weight;
            }

            if (weight <= _maxWeight)
                return true;
            return false;
        }
    }
}
