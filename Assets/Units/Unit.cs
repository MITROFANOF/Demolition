using UnityEngine;
using UnityEngine.EventSystems;

namespace Units
{
    [RequireComponent(typeof(Renderer))]
    public class Unit : MonoBehaviour, ISelectable
    {
        [SerializeField] private Material selectionMaterial, defaultMaterial;
        private Renderer _renderer;
        public bool isSelected;
        private void Start()
        {
            _renderer = GetComponent<Renderer>();
        }


        public void Select()
        {
            isSelected = true;
            _renderer.material = selectionMaterial;
        }

        public void Deselect()
        {
            isSelected = false;
            _renderer.material = defaultMaterial;
        }
    }
}