using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] private UnitConfig config;
    
    private UnitAnimations _animations;
    private IDamageable _damageable;
    private UnitHealth _health;
    public UnitConfig Config => config;
    public UnitAnimations Animations => _animations;
    public IDamageable Damageable => _damageable;
    private void Awake()
    {
        var anim = GetComponent<Animator>();
        var ragdoll = new Ragdoll(transform);

        _animations = new UnitAnimations(anim);
        var dying = new UnitRagdollDying(ragdoll, _animations);
        _health = new UnitHealth(dying, config.Health);
        _damageable = new UnitDamageable(_health);
    }
}
