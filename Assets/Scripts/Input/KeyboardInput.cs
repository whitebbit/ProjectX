using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput: IInputService
{
    public Vector2 GetAxis()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        return new Vector3(x, y);
    }
}
