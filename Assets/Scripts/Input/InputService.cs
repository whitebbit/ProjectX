using System.Collections.Generic;
using UnityEngine;

public static class InputService
{
    private static IInputService _service = new DesktopInput();
    public static Vector2 GetMovementAxis() => _service.GetMovementAxis();
    public static Vector2 GetCameraRotationAxis() => _service.GetCameraRotationAxis();
    public static Dictionary<Binds, bool> GetBinds() => _service.GetBinds();
}
