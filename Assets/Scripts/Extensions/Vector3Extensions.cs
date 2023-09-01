using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3Extensions
{
    public static bool IsGrounded(this Vector3 position, Vector3 direction, float maxDistance = 0.1f)
    {
        return Physics.Raycast(position, direction, maxDistance);
    }
    
}
