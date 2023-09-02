using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ammunition
{
    public List<WeaponAttackBehaviour> Weapons { get; private set; }
    private readonly Transform _transform;
    public WeaponAttackBehaviour CurrentWeapon { get; private set; }
    public Ammunition(Transform main, List<WeaponConfig> weapons)
    {
        _transform = main;
        InitializeWeapons(weapons);
        CurrentWeapon = Weapons[0];
    }

    private void InitializeWeapons(List<WeaponConfig> weapons)
    {
        Weapons = new List<WeaponAttackBehaviour>();
        foreach (var weapon in weapons)
        {
            var body = weapon.SpawnWeapon(_transform, Vector3.zero);
            var startPoint = body.GetChild(1);
            switch (weapon.Type)
            {
                case WeaponType.Raycast:
                    Weapons.Add(
                        new WeaponRaycastAttack(
                            body, startPoint, weapon.Damage, weapon.AttackRange,  weapon.RaycastAttackConfig));
                    break;;
            }
        }
    }
}
