
using UnityEngine;

[CreateAssetMenu(menuName = "Source/Units/UnitDecalsPreset", fileName = "UnitDecalsPreset", order = 0)]
public class UnitDecalsPreset: ScriptableObject
{
    [field: SerializeField] public ParticleSystem DefaultDecal { get; private set; }
    [field: SerializeField] public ParticleSystem HeadshotDecal { get; private set; }
}
