using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] private UnitConfig config;
    public UnitConfig Config => config;
    
}
