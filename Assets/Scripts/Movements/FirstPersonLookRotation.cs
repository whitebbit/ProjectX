using UnityEngine;

public class FirstPersonLookRotation: IRotatable
{
    private readonly Transform _body;
    private Transform _head;
    private float _rotationX;
    public FirstPersonLookRotation(Transform body, Transform head)
    {
        _body = body;
        _head = head;
    }
    
    public void Rotate(Vector3 direction, float speed)
    {
        _body.rotation *= Quaternion.Euler(0, direction.x * speed, 0);
        
        _rotationX -= direction.y * speed;
        _rotationX = Mathf.Clamp(_rotationX, -90, 90);
        _head.localRotation = Quaternion.Euler(_rotationX, 0, 0);
    }
}
