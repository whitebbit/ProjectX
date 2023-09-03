using UnityEngine;

[CreateAssetMenu(menuName = "Source/Weapon/WeaponDecals", fileName = "WeaponDecals", order = 0)]

public class WeaponDecalsPreset: ScriptableObject
{
    [field: SerializeField] public ParticleSystem  Attack { get; private set; }
    [field: SerializeField] public ParticleSystem Miss { get; private set; }
    
}
