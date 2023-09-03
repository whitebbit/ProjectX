using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Source/Weapon/WeaponConfig", fileName = "WeaponConfig", order = 0)]
public class WeaponConfig: ScriptableObject
{
    
    [Header("Configs and Presets")]
    [SerializeField] private RaycastAttackConfig raycastConfig;
    [field: SerializeField] public WeaponDecalsPreset DecalsPreset { get; private set; }
    [field: SerializeField] public WeaponTimings Timings { get; private set; }
    [field: SerializeField] public ShakePreset Shake { get; private set; }

    [Header("Common")]
    [SerializeField, Min(0)] private float damage;
    [SerializeField, Min(0)] private float attackRange;
    [SerializeField] private WeaponType type;
    
    [Header("Prefab")]
    [SerializeField] private Transform prefab;
    
    
    public string Name => name;
    public float Damage => damage;
    public float AttackRange => attackRange;
    public Transform Prefab => prefab;
    public WeaponType Type => type;
    public RaycastAttackConfig RaycastConfig => raycastConfig;
    
}
