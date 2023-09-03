using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimation
{
    private readonly Animator _animator;
    private static readonly int AttackTrigger = Animator.StringToHash("Attack");

    public WeaponAnimation(Animator animator)
    {
        _animator = animator;
    }

    public void Attack() => _animator.SetTrigger(AttackTrigger);
}
