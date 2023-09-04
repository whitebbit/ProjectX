using System;
using System.Text.RegularExpressions;
using Interfaces;
using UnityEngine;

public class UnitHealth
{
    private readonly float _maxHealth;
    private float _currentHealth;
    private IDying _death;
    public float Health
    {
        get => _currentHealth;
        set => SetHealth(value);
    }

    public UnitHealth(IDying death, float maxHealth)
    {
        _death = death;
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
    }

    public void SetHealth(float value)
    {
        if(_currentHealth <= 0)
            return;
        
        if(value == 0)
            return;
        
        _currentHealth = Math.Clamp(value, 0, _maxHealth);
        if (_currentHealth == 0)
            _death.Dead();
    }
}
