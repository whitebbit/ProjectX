using Interfaces;
using UnityEngine;

public class UnitRagdollDying: IDying
{
    private readonly Ragdoll _ragdoll;
    private readonly UnitAnimations _animations;
    public UnitRagdollDying(Ragdoll ragdoll, UnitAnimations animations)
    {
        _ragdoll = ragdoll;
        _animations = animations;
    }

    public void Dead()
    {
        _ragdoll.RigidbodiesState(true);
        _animations.AnimatorState(false);
    }
    
}
