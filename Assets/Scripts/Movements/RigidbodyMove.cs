using UnityEngine;

public class RigidbodyMove: IMoveble
{
    private readonly Rigidbody _rigidbody;
    
    public RigidbodyMove(Rigidbody rigidbody)
    {
        _rigidbody = rigidbody;
    }
    
    public void Move(Vector3 direction, float speed)
    {
        direction *= speed;
        direction.y = _rigidbody.velocity.y;
        _rigidbody.velocity = direction;
    }
}
