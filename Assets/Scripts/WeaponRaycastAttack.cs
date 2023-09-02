using Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class WeaponRaycastAttack: WeaponAttackBehaviour
{
    private readonly RaycastAttackConfig _config;
    public WeaponRaycastAttack(Transform body, Transform startPoint, float damage, float attackRange, RaycastAttackConfig config) : 
        base(body, startPoint, damage, attackRange)
    {
        _config = config;
    }
    
    public override void PerformAttack()
    {
        PerformShot();
    }

    public void PerformShot()
    {
        for (int i = 0; i < _config.ShoutCount; i++)
        {
            PerformRaycast();
        }
    }
    
    private void PerformRaycast()
    {
        var direction = _config.UseSpread ? StartPoint.forward + CalculateSpread() : StartPoint.forward;
        var ray = new Ray(StartPoint.position, direction);

        if (Physics.Raycast(ray, out RaycastHit hit, AttackRange, _config.Mask))
        {
            ScanHit(hit);
        }
        else
        {
            Debug.Log("Not hit");
        }
    }

    private void ScanHit(RaycastHit hit)
    {
        var hitCollider = hit.collider;
        if (hitCollider.TryGetComponent(out IWeaponVisitor visitor))
        {
            Accept(visitor, hit);
        }
        {
            Debug.Log("Not visitor");
        }
    }

    protected Vector3 CalculateSpread()
    {
        return new Vector3(
            Random.Range(-_config.SpreadFactor, _config.SpreadFactor),
            Random.Range(-_config.SpreadFactor, _config.SpreadFactor),
            Random.Range(-_config.SpreadFactor, _config.SpreadFactor)
            );
    }

    protected void Accept(IWeaponVisitor visitor, RaycastHit hit)
    {
        visitor?.Visit(this, hit);
    }
}
