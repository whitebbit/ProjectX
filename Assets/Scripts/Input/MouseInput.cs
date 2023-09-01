using UnityEngine;
public class MouseInput: IInputService
{
    public Vector2 GetAxis()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        return new Vector2(x, y);
    }
}
