
using UnityEngine;

public interface IWeaponVisitor
{
    public void Visit(WeaponRaycastAttack weapon, RaycastHit hit);
}
