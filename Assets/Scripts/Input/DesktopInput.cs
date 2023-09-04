using System.Collections.Generic;
using UnityEngine;

public class DesktopInput: IInputService
{
    public Vector2 GetMovementAxis()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        return new Vector2(x, y);
    }

    public Vector2 GetCameraRotationAxis()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        return new Vector2(x, y);
    }

    public Dictionary<Binds, bool> GetBoolBinds()
    {
        return new Dictionary<Binds, bool>
        {
            {Binds.Jump, Input.GetButtonDown("Jump")},
            {Binds.Attack, Input.GetMouseButtonDown(0)},
            
        };
    }

    public Dictionary<Binds, float> GetFloatBinds()
    {
        return new Dictionary<Binds, float>
        {
            {Binds.SwitchWeapon, Input.GetAxis("Mouse ScrollWheel")},
        };
    }
}

