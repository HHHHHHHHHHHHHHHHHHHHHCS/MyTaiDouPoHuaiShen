using UnityEngine;
using System.Collections;

public class EnemyTrigger : MonoBehaviour 
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPosArray;
    public float time = 0;//多少秒后开始生成
    public float repeatRate = 0;//生成下一波怪的时间
    private bool isSpawned = false;
    void OnTriggerEnter(Collider col)
    {
        if (!isSpawned && col.tag == "Player")
        {
            isSpawned = true;
            StartCoroutine(SpawnEnemy());
        }
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(time);

        foreach(GameObject go in enemyPrefabs)
        {
            foreach(Transform ts  in spawnPosArray)
            {
                GameObject.Instantiate(go, ts.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(repeatRate);
        }
    }
}
