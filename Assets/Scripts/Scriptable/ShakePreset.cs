using UnityEngine;

[CreateAssetMenu(menuName = "Source/Camera/ShakePreset", fileName = "ShakePreset", order = 0)]
public class ShakePreset: ScriptableObject
{
    [SerializeField] private ShakeAnimationPreset rotationShake;
    [SerializeField] private ShakeAnimationPreset positionShake;

    public ShakeAnimationPreset RotationShake => rotationShake;
    public ShakeAnimationPreset PositionShake => positionShake;
}
