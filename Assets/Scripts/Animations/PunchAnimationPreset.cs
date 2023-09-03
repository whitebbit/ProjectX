using System;
using UnityEngine;


[Serializable]
public class PunchAnimationPreset : AnimationPreset
{
    public Vector3 direction;
    public int vibrato = 10;
    public float elasticity = 1f;
    public bool snapping;
}
