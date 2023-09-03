
using UnityEngine;

public static class CameraService
{
    public static Camera ActiveCamera => Camera.main;
    
    public static void ShakeCamera(ShakeAnimationPreset rotationPreset, ShakeAnimationPreset positionPreset)
    {
        if (rotationPreset.isOn)
            ActiveCamera.transform.ShakeRotationAnimation(rotationPreset);
        if (positionPreset.isOn)
            ActiveCamera.transform.ShakePositionAnimation(positionPreset);
    }
}
