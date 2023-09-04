using System;
using UnityEngine;
using UnityEngine.Serialization;

public class UnitHitbox: MonoBehaviour, IWeaponVisitor
{
    [SerializeField] protected Unit unit;
    protected Collider hitbox;

    private void Awake()
    {
        hitbox = GetComponent<Collider>();
    }

    public void Visit(WeaponRaycastAttack weapon, RaycastHit hit)
    {
        DefaultRaycastVisit(weapon, unit.Config.DecalsPreset.DefaultDecal, hit);
    }
    
    protected void DefaultRaycastVisit(WeaponAttackBehaviour weapon, ParticleSystem decal, RaycastHit hit)
    {
        unit.Damageable.ApplyDamage(weapon.Damage);
        SpawnDecal(decal, hit);
    }

    private void SpawnDecal(ParticleSystem decal, RaycastHit hit)
    {
        DecalSpawner.Spawn(decal, hit.point, Quaternion.LookRotation(hit.normal), transform);
    }
    
}
