using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Source/Units/Config", fileName = "UnitConfig", order = 0)]
public class UnitConfig : ScriptableObject
{
    [Header("Name"), Space] [SerializeField] private string _name;
    
    [Header("Common"), Space] 
    [SerializeField, Min(0)] private float _health;
    [SerializeField, Min(0)] private float _damage;
    [SerializeField, Min(0)] private float _speed;
    
    [Header("Prefab"), Space] 
    [SerializeField] private Unit _prefab;

    public string Name => _name;
    public float Health => _health;
    public float Damage => _damage;
    public float Speed => _speed;

}
