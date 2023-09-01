using UnityEngine;

namespace Movements
{
    public class TransformRotation: IRotatable
    {
        private readonly Transform _transform;

        public TransformRotation(Transform transform)
        {
            _transform = transform;
        }

        public void Rotate(Vector3 direction, float speed)
        {
            _transform.rotation *= Quaternion.Euler(direction * speed);
        }
    }
}