using System.Collections.Generic;
using UnityEngine;

namespace Game.CompositRoot
{
    public class CompositRootOrder : MonoBehaviour
    {
        [SerializeField] private List<CompositRoot> _composit = new List<CompositRoot>();

        private void Awake()
        {
            foreach (var item in _composit)
            {
                item.Compose();
                item.enabled = true;
            }
        }
    }
}
