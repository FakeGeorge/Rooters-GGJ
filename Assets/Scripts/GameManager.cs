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
    float xRandomSpawn;
    float yRandomSpawn;

    public float xminimumDistance;
    public float yminimumDistance;

    float enemyType;

    // Start is called before the first frame update
    void Start()
    {
        miEpoca = Epocas.prehistoria;
        StartCoroutine("SpawnEnemigos");
        //InvokeRepeating(nameof(SpawnEnemigos), 2, 2);
    }

    IEnumerator SpawnEnemigos ()
    {
        enemyType = Random.Range(0, 2);

        xRandomSpawn = Random.Range(-20, 20);
        yRandomSpawn = Random.Range(-20, 20);


        //Debug.Log("x " + xRandomSpawn);
        //Debug.Log("y " + yRandomSpawn);
        
        if (xRandomSpawn >= - xminimumDistance && xRandomSpawn <= 0)
        {
            xRandomSpawn = Random.Range(-20, -6);
            Debug.Log("me la pela");
        }

        if (yRandomSpawn >= 0 && yRandomSpawn <= yminimumDistance)
        {
            yRandomSpawn = Random.Range(5, 21);
            Debug.Log("me la pela x2");
        }

        if (enemyType == 0)
        {
            Instantiate(enemy.gameObject, new Vector2(enemy.position.x + xRandomSpawn, enemy.position.y + yRandomSpawn), Quaternion.identity);
        }
        else if (enemyType == 1)
        {
            Instantiate(enemyTree.gameObject, new Vector2(xRandomSpawn, yRandomSpawn), Quaternion.identity);
            Debug.Log("x " + xRandomSpawn);
            Debug.Log("y " + yRandomSpawn);
        }
        yield return new WaitForSeconds(2);
        yield return StartCoroutine("SpawnEnemigos");
    }
}
