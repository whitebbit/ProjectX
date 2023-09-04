using System.Collections.Generic;
using UnityEngine;


public interface IInputService
{
    public Vector2 GetMovementAxis();
    public Vector2 GetCameraRotationAxis();
    public Dictionary<Binds, bool> GetBoolBinds();
    public Dictionary<Binds, float> GetFloatBinds();
}
