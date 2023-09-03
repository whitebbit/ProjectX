using System;
using UnityEngine;

public abstract class WeaponAttackBehaviour
{

    public Transform Body { get; private set; }
    public Transform AttackPoint { get; private set; }
    public float Damage => ProcessDamage(Config.Damage);
    public WeaponConfig Config { get; private set; }
    public WeaponAnimation Animation { get; private set; }
    protected bool AllowAttacking;
    protected WeaponAttackBehaviour(Transform body, Transform attackPoint, WeaponConfig config)
    {
        Body = body;
        AttackPoint = attackPoint;
        Config = config;
        var anim = Body.GetComponent<Animator>();
        Animation = new WeaponAnimation(anim);
        AllowAttacking = true; 
    }
    
    public abstract void PerformAttack();
    protected virtual float ProcessDamage(float damage) => damage;
    public virtual void OnSetup(){}
}
