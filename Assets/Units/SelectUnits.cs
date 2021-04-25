using System;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Units
{
    [RequireComponent(typeof(PhysicsRaycaster))]
    public class SelectUnits : MonoBehaviour
    {
        private static Camera _camera;
        private bool _isSelecting;
        private Vector2 _startPos;

        private static void TrySelect()
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out var raycastHit)) return;
            var selection = raycastHit.transform;
            if (selection.TryGetComponent<Unit>(out var unit))
                unit.Select();
            else
                unit.Deselect();
        }


        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            _isSelecting = Input.GetMouseButton(0);
            if (Input.GetMouseButtonDown(0))
            {
                _startPos = Input.mousePosition;
            }
        }

        private void OnGUI()
        {
            if (_isSelecting)
             
                GUI.Box(
                    new Rect(_startPos.x, Screen.height - _startPos.y, Input.mousePosition.x - _startPos.x,
                        _startPos.y - Input.mousePosition.y), "");
        }
    }
}