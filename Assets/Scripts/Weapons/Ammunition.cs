using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

public class Ammunition
{
    public List<WeaponAttackBehaviour> Weapons { get; private set; }
    public WeaponAttackBehaviour CurrentWeapon { get; private set; }
    private int _currentWeaponIndex;
    public Ammunition(List<WeaponConfig> weapons, Transform spawnPoint)
    {
        InitializeWeapons(weapons, spawnPoint);
        SetupWeapon(0);
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

    public void SwitchWeapon(float scrollDirection)
    {
        if(scrollDirection > 0f)
            SetupNextWeapon();
        else if(scrollDirection < 0f)
            SetupPreviousWeapon();
    }
    
    private void SetupNextWeapon()
    {
        var nextWeaponIndex = _currentWeaponIndex + 1;
        if (nextWeaponIndex >= Weapons.Count)
            nextWeaponIndex = 0;
        
        SetupWeapon(nextWeaponIndex);
    }

    private void SetupPreviousWeapon()
    {
        var previousWeaponIndex = _currentWeaponIndex - 1;
        if (previousWeaponIndex < 0)
            previousWeaponIndex = Weapons.Count - 1;
        
        SetupWeapon(previousWeaponIndex);
    }
    
    private void SetupWeapon(int id)
    {
        WeaponVisible(false);
        _currentWeaponIndex = id;
        CurrentWeapon = Weapons[_currentWeaponIndex];
        WeaponVisible(true);
    }
    
    private void WeaponVisible(bool active)
    {
        if(CurrentWeapon == null)
            return;
        
        CurrentWeapon.Body.gameObject.SetActive(active);
    }
}
