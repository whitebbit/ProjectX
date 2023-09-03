using UnityEngine;

public static class DecalSpawner
{
    public static ParticleSystem Spawn(ParticleSystem decal, Vector3 position, Quaternion rotation, Transform parent = null)
    {
        ParticleSystem spawnedObject = Object.Instantiate(decal, position, rotation, parent);
        return spawnedObject;
    }
}
