using UnityEngine;

[CreateAssetMenu(menuName = "Source/AttackConfig/RaycastAttackConfig", fileName = "RaycastAttackConfig", order = 0)]
public class RaycastAttackConfig: ScriptableObject
{
    [SerializeField, Min(1)] private int shotCount;
    [SerializeField] private LayerMask mask;

    [Header("Spread")]
    [SerializeField] private bool useSpread;
    [SerializeField, Min(0)] private float spreadFactor;

    public LayerMask Mask => mask;
    public int ShoutCount => shotCount;
    public bool UseSpread => useSpread;
    public float SpreadFactor => spreadFactor;
}
