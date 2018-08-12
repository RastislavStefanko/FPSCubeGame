using UnityEngine;

public class SpawnObserver : Observer {

    private ObjectsEnums prefabTag;
    private Vector3 spawnPosition;
    private Quaternion spawnRotation;
    private ObjectPooler pooler;

    public SpawnObserver(ObjectsEnums tag, Vector3 pos, Quaternion rot, ObjectPooler pool)
    {
        prefabTag = tag;
        spawnPosition = pos;
        spawnRotation = rot;
        pooler = pool;
    }

    /// <summary>
    /// spawn object if subject notifying
    /// </summary>
    public override void OnNotify()
    {
        pooler.SpawnFromPool(prefabTag, spawnPosition, spawnRotation);
    }
}
