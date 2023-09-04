using UnityEngine;

public class UnitAnimations
{
    private readonly Animator _animator;

    public UnitAnimations(Animator animator)
    {
        _animator = animator;
    }

    public void AnimatorState(bool state) => _animator.enabled = state;
}
