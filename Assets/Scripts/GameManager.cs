using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform enemy;
    public Transform enemyTree;

    public enum Epocas { prehistoria, medievo, actual, futuro};
    public static Epocas miEpoca;

    float randomSpawn;
    float enemyType;

    // Start is called before the first frame update
    void Start()
    {
        miEpoca = Epocas.prehistoria;
        //StartCoroutine("SpawnEnemigos");
        InvokeRepeating(nameof(SpawnEnemigos), 2, 2);
    }

    void SpawnEnemigos ()
    {
        enemyType = Random.Range(0, 2);
        randomSpawn = Random.Range(-9, 9);
       
        if (enemyType == 0)
        {
            Instantiate(enemy.gameObject, new Vector2(randomSpawn, randomSpawn), Quaternion.identity);
        }
        else
        {
            Instantiate(enemyTree.gameObject, new Vector2(randomSpawn, randomSpawn), Quaternion.identity);
        }
    }
}
