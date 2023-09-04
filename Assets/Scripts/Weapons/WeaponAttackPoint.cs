using System;
using UnityEngine;

public class WeaponAttackPoint: MonoBehaviour
{
    private void OnDisable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
