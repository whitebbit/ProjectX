
using UnityEngine;

public class RigidbodyJump: IJumpble
{
    private Rigidbody _rigidbody;
    
    public RigidbodyJump(Rigidbody rigidbody)
    {
        _rigidbody = rigidbody;
    }

    public void Jump(float force)
    {
        _rigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
    }
}
