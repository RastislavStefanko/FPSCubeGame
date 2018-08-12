using UnityEngine;

public class AddingEnemies : MonoBehaviour {

    [SerializeField] private ObjectsEnums prefabTag;
    [SerializeField] private Vector3 spawnPosition;
    private ObjectPooler pooler => ObjectPooler.Instance;

    Subject subject = new Subject();

    /// <summary>
    /// add observer for callback of adding button
    /// </summary>
    void Start()
    {
        SpawnObserver observer = new SpawnObserver(prefabTag, spawnPosition, Quaternion.identity, pooler);
        subject.AddObserver(observer);
    }

    /// <summary>
    /// click of button will notify all observers
    /// </summary>
    public void AddEnemy()
    {
        subject.Notify();
    }


}
