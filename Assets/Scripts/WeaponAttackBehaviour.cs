using System;
using UnityEngine;

public abstract class WeaponAttackBehaviour
{
    private readonly float _damage;
    
    public Transform Body { get; private set; }
    public Transform StartPoint { get; private set; }
    public float AttackRange { get; private set; }
    public float Damage => ProcessDamage(_damage);


    protected WeaponAttackBehaviour(Transform body, Transform startPoint, float damage, float attackRange)
    {
        _damage = damage;
        Body = body;
        StartPoint = startPoint;
        AttackRange = attackRange;
    }
    
    public abstract void PerformAttack();
    protected virtual float ProcessDamage(float damage) => damage;
    public virtual void OnSetup(){}
}
