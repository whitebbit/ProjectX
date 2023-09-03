using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

public class Ammunition
{
    public List<WeaponAttackBehaviour> Weapons { get; private set; }
    public WeaponAttackBehaviour CurrentWeapon { get; private set; }
    public Ammunition(List<WeaponConfig> weapons, Transform spawnPoint)
    {
        InitializeWeapons(weapons, spawnPoint);
        SetupWeapon(1);
    }
    
    private void InitializeWeapons(List<WeaponConfig> weapons, Transform spawnPoint)
    {
        Weapons = new List<WeaponAttackBehaviour>();
        foreach (var weapon in weapons)
        {
            Transform body = Object.Instantiate(weapon.Prefab, spawnPoint.position, 
                Quaternion.identity, spawnPoint);
            var attackPoint = body.GetComponentInChildren<WeaponAttackPoint>().transform;
            body.gameObject.SetActive(false);
            switch (weapon.Type)
            {
                case WeaponType.Raycast:
                    Weapons.Add(
                        new WeaponRaycastAttack(body, attackPoint, weapon, weapon.RaycastConfig));
                    break;;
            }
        }
    }

    public void SetupWeapon(int id)
    {
        if (id >= Weapons.Count)
            throw new ArgumentException(nameof(Weapons));

        WeaponVisible(false);
        CurrentWeapon = Weapons[id];
        WeaponVisible(true);
    }

    private void WeaponVisible(bool active)
    {
        if(CurrentWeapon == null)
            return;
        
        CurrentWeapon.Body.gameObject.SetActive(active);
    }
}
