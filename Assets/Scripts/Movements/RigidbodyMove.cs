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
        _rigidbody.velocity = direction * speed;
    }
}
