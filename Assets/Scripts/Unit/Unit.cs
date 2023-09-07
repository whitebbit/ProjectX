using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected UnitConfig config;
    
    protected UnitAnimations _animations;
    private IDamageable _damageable;
    protected UnitHealth _health;
    public UnitConfig Config => config;
    public UnitAnimations Animations => _animations;
    public IDamageable Damageable => _damageable;
    private void Awake()
    {
        var anim = GetComponent<Animator>();
        _animations = new UnitAnimations(anim);
        
        InitializeHealth();
       
        _damageable = new UnitDamageable(_health);
    }


    protected abstract void InitializeHealth();
}
