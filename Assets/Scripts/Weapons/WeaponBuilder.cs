
using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class WeaponBuilder
{
    private WeaponConfig _config;
    
    public WeaponBuilder WithConfig(WeaponConfig config)
    {
        _config = config;
        return this;
    }
    
    public WeaponBuilder Reset()
    {
        _config = null;
        return this;
    }
    
    public WeaponAttackBehaviour Build(Transform spawnPoint)
    {
        var body = Object.Instantiate(_config.Prefab, spawnPoint.position, 
            Quaternion.identity, spawnPoint);
        
        var attackPoint = body.GetComponentInChildren<WeaponAttackPoint>().transform;
        
        var createdWeapon = _config.Type switch
        {
            WeaponType.Melee => null,
            WeaponType.Raycast => new WeaponRaycastAttack(body, attackPoint, _config, _config.RaycastConfig),
            WeaponType.Projectile => null,
            _ => throw new ArgumentOutOfRangeException()
        };

        return createdWeapon;
    }
}
