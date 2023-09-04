using System;
using Interfaces;
using UnityEngine;

public class UnitDamageable: IDamageable
{
    private readonly UnitHealth _unit;

    public event Action<float> OnDamageApplied; 
    public UnitDamageable(UnitHealth unit)
    {
        _unit = unit;
    }

    public void ApplyDamage(float damage)
    {
        if(!DamageNotNull(damage))
            return;
        
        _unit.Health -= damage;
        OnDamageAppliedEvent(damage);
    }

    protected bool DamageNotNull(float damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        return true;
    }

    protected void OnDamageAppliedEvent(float damage)
    {
        OnDamageApplied?.Invoke(damage);
    }
}
