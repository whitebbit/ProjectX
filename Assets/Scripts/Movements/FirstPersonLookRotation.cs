using UnityEngine;

public class FirstPersonLookRotation: IRotatable
{
    private readonly Transform _unit;
    private Transform _camera;
    private float _rotationX;
    public FirstPersonLookRotation(Transform unit, Transform camera)
    {
        _unit = unit;
        _camera = camera;
    }
    
    public void Rotate(Vector3 direction, float speed)
    {
        _unit.rotation *= Quaternion.Euler(0, direction.x * speed, 0);
        
        _rotationX -= direction.y * speed;
        _rotationX = Mathf.Clamp(_rotationX, -90, 90);
        _camera.localRotation = Quaternion.Euler(_rotationX, 0, 0);
    }
}
