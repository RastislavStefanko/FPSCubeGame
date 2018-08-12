using System.Collections;
using UnityEngine;

public class GreenBehaviour : MonoBehaviour {

    private GameController gameController => GameController.Instance;
    private ObjectPooler objectPooler => ObjectPooler.Instance;

    void Start()
    {
        StartCoroutine(SpawnRedCoroutine());
    }

    /// <summary>
    /// coroutine for spawning red enemies every 10sec
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnRedCoroutine()
    {
        int spawnRedCount = gameController.spawningRedCount;

        while (spawnRedCount > 0)
        {
            yield return new WaitForSeconds(5f);
            objectPooler.SpawnFromPool(ObjectsEnums.EnemyRed, transform.position, Quaternion.identity);
            spawnRedCount--;
        }

        yield return null;
    }
}
