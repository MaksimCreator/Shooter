using UnityEngine;
using UnityEngine.UI;

namespace Game.CompositRoot
{
    public class UIPlayerCompositRoot : CompositRoot
    {
        [SerializeField] private readonly PlayerCompositRoot _playerComposit;
        [SerializeField] private readonly Slider _playerHealth;

        public void Update()
        {
            _playerHealth.value = _playerComposit.Healse;
        }

        public override void Compose()
        {
            _playerHealth.maxValue = _playerComposit.MaxHealth;
            _playerHealth.minValue = 0;
        }
    }
}