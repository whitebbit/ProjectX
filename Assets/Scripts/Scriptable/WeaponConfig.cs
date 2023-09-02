using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Source/Weapon/WeaponConfig", fileName = "WeaponConfig", order = 0)]
public class WeaponConfig: ScriptableObject
{
    [Header("Name")]
    [SerializeField] private string name;
    
    [Header("Common")]
    [SerializeField, Min(0)] private float damage;
    [SerializeField, Min(0)] private float attackRange;
    [SerializeField] private WeaponType type;
    [SerializeField] private RaycastAttackConfig raycastAttackConfig;
    [Header("Prefab")]
    [SerializeField] private Transform prefab;
    
    
    public string Name => name;
    public float Damage => damage;
    public float AttackRange => attackRange;
    public Transform Prefab => prefab;
    public WeaponType Type => type;
    public RaycastAttackConfig RaycastAttackConfig => raycastAttackConfig;
    public Transform SpawnWeapon(Transform parent, Vector3 position)
    {
        Transform body = Instantiate(prefab, parent);
        body.position = position;
        return body;
    }
}
