using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 100)
        {
            xPos = Random.Range(1,10);
            zPos = Random.Range(1,10);
            Instantiate(theEnemy, new Vector3(xPos, -0.2f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(1f);
            enemyCount += 1;


        }

    }
}
