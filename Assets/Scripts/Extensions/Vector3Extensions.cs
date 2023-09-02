using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3Extensions
{
    public static bool IsGrounded(this Vector3 position, Vector3 direction, float maxDistance = 0.1f)
    {
        Ray ray = new Ray(position, direction);
        bool grounded = Physics.Raycast(ray, maxDistance);
        //Debug.DrawRay(position, direction, grounded ? Color.green : Color.red, maxDistance);
        return grounded;
    }
    
}
