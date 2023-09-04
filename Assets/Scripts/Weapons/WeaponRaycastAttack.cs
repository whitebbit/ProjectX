using Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;
using System;
using Cysharp.Threading.Tasks;


public class WeaponRaycastAttack: WeaponAttackBehaviour
{
    private readonly RaycastAttackConfig _raycastConfig;
    private readonly Camera _camera;
    public WeaponRaycastAttack(Transform body, Transform attackPoint, WeaponConfig config, RaycastAttackConfig raycastConfig) : 
        base(body, attackPoint, config)
    {
        _camera = Camera.main;
        _raycastConfig = raycastConfig;
    }
    
    public override async void PerformAttack()
    {   
        if(!AllowAttacking)
            return;
        
        PerformShot();
        //spend ammo
        await UniTask.Delay(TimeSpan.FromSeconds(Config.Timings.DelayUntilNextAttack));
        AllowAttacking = true;
    }

    public void PerformShot()
    {
        DecalSpawner.Spawn(Config.DecalsPreset.Attack, AttackPoint.position, 
            Quaternion.LookRotation(AttackPoint.forward), AttackPoint);
        Animation.Attack();
        CameraService.ShakeCamera(Config.Shake.RotationShake, Config.Shake.PositionShake);
        
        for (int i = 0; i < _raycastConfig.ShoutCount; i++)
        {
            PerformRaycast();
        }
        
        AllowAttacking = false;
    }
    
    private void PerformRaycast()
    {
        var direction = _raycastConfig.UseSpread ? 
            _camera.transform.forward + CalculateSpread() : _camera.transform.forward;
        var ray = new Ray(_camera.transform.position, direction);
        
        if (Physics.Raycast(ray, out RaycastHit hit, Config.AttackRange, _raycastConfig.Mask))
        {
            ScanHit(hit);
        }
    }

    private void ScanHit(RaycastHit hit)
    {
        var hitCollider = hit.collider;
        if (hitCollider.TryGetComponent(out IWeaponVisitor visitor))
        {
            Accept(visitor, hit);
        }
        else
        {
            WeaponVisitorIsNotFound(hit);
        }
    }

    protected Vector3 CalculateSpread()
    {
        return new Vector3(
            Random.Range(-_raycastConfig.SpreadFactor, _raycastConfig.SpreadFactor),
            Random.Range(-_raycastConfig.SpreadFactor, _raycastConfig.SpreadFactor),
            Random.Range(-_raycastConfig.SpreadFactor, _raycastConfig.SpreadFactor)
            );
    }

    protected void Accept(IWeaponVisitor visitor, RaycastHit hit)
    {
        visitor?.Visit(this, hit);
    }

    protected void WeaponVisitorIsNotFound(RaycastHit hit)
    {
        DecalSpawner.Spawn(Config.DecalsPreset.Miss, hit.point, Quaternion.LookRotation(hit.normal));
    }
}
