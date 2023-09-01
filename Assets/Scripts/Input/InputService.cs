using UnityEngine;

public static class InputService
{
    private static readonly IInputService RotateService = new MouseInput();
    private static readonly IInputService MoveService = new KeyboardInput();
    public static Vector2 GetMoveAxis() => MoveService.GetAxis();
    public static Vector2 GetRotateAxis() => RotateService.GetAxis();
}
