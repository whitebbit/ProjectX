using UnityEngine;
using UnityEngine.Serialization;

public class UnitHitbox: MonoBehaviour, IWeaponVisitor
{
    [SerializeField] protected Unit unit;
    [SerializeField] protected Collider hitbox;
    public void Visit(WeaponRaycastAttack weapon, RaycastHit hit)
    {
        DefaultRaycastVisit(weapon, null, hit);
    }
    
    protected void DefaultRaycastVisit(WeaponAttackBehaviour weapon, GameObject decal, RaycastHit hit)
    {
        var damage = weapon.Damage;
        //Unit damage
        //Spawn decal
        Debug.Log("Take damage");
    }
}
