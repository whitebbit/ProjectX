using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
[CreateAssetMenu(menuName = "Source/Weapon/WeaponTimings", fileName = "WeaponTimings", order = 0)]
public class WeaponTimings : ScriptableObject
{
    [field: SerializeField] public float DelayUntilNextAttack { get; private set; }
}
