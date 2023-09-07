using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void InitializeHealth()
    {
        var ragdoll = new Ragdoll(transform);
        var dying = new UnitRagdollDying(ragdoll, _animations);
        _health = new UnitHealth(dying, config.Health);
    }
}
