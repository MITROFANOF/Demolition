using System.Collections.Generic;
using UnityEngine;

namespace Units
{
    public class MoveToPoint : MonoBehaviour
    {
        [SerializeField] private List<Unit> units;
        private Vector3 _targenPosition;

        private void OnMouseDown()
        {
            _targenPosition = GetMousePosInWolrd();

        }


        private static Vector3 GetMousePosInWolrd()
        {
            var plane = new Plane(Vector3.up, 0);
            if (Camera.main is null) return default;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            return plane.Raycast(ray, out var distance) ? ray.GetPoint(distance) : default;
        }
    }
}