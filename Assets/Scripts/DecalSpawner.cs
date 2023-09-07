using UnityEngine;

public static class DecalSpawner
{
    public static Transform Spawn(ParticleSystem decal, Vector3 position, Quaternion rotation, Transform parent = null)
    {
        Transform spawnedObject = Object.Instantiate(decal).transform;
        spawnedObject.position = position;
        spawnedObject.rotation = rotation;
        spawnedObject.parent = parent;
        return spawnedObject;
    }
}
