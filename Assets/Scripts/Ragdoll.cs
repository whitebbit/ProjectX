using System.Collections.Generic;
using UnityEngine;

public class Ragdoll
{
    private List<Collider> _colliders;
    private List<Rigidbody> _rigidbodies;

    public Ragdoll(Transform body)
    {
        Initialize(body);
        CollidersState(true);
        RigidbodiesState(false);
    }
    
    public void CollidersState(bool state)
    {
        foreach (var collider in _colliders)
        {
            collider.enabled = state;
        }
    }
    public void RigidbodiesState(bool state)
    {
        foreach (var rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = !state;
        }
    }

    private void Initialize(Transform body)
    {
        _colliders = new List<Collider>(body.GetComponentsInChildren<Collider>());
        _rigidbodies = new List<Rigidbody>(body.GetComponentsInChildren<Rigidbody>());
    }
}
