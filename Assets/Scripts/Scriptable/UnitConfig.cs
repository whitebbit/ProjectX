using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Source/Units/UnitConfig", fileName = "UnitConfig", order = 0)]
public class UnitConfig : ScriptableObject
{
    [field: Header("Configs and Presets")]
    [field: SerializeField] public UnitDecalsPreset DecalsPreset { get; private set; }
    
    [Header("Common"), Space] 
    [SerializeField, Min(0)] private float health;
    [SerializeField, Min(0)] private float damage;
    [SerializeField, Min(0)] private float speed;
    [SerializeField, Min(0)] private float jumpForce;
    
    [Header("Prefab"), Space] 
    [SerializeField] private Unit prefab;
    
    public string Name => name;
    public float Health => health;
    public float Damage => damage;
    public float Speed => speed;
    public float JumpForce => jumpForce;

}
