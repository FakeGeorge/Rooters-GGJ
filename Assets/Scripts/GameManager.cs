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

    public GameObject enemyTreeCollider;
    public GameObject enemyCollider;

    [SerializeField] List<GameObject> instancedEnemies = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        miEpoca = Epocas.futuro;
        //StartCoroutine("SpawnEnemigos");
        InvokeRepeating(nameof(SpawnEnemigos), 2, 0.5f);
    }

    void SpawnEnemigos ()
    {
        enemyType = Random.Range(0, 2);

        xRandomSpawn = Random.Range(-24, 31);
        yRandomSpawn = Random.Range(-19, 25);

        
        if (xRandomSpawn > -xminimumDistance && xRandomSpawn < 0)
        {
            xRandomSpawn = -Random.Range(24, 11);
        }

        if (xRandomSpawn >= 0 && xRandomSpawn < xminimumDistance)
        {
            xRandomSpawn = Random.Range(10, 32);
        }

        if (yRandomSpawn >= 0 && yRandomSpawn < yminimumDistance)
        {
            yRandomSpawn = Random.Range(10, 26);
        }

        if (yRandomSpawn > -yminimumDistance && yRandomSpawn < 0)
        {
            yRandomSpawn = -Random.Range(19, 10);
        }

        if (enemyType == 0)
        {
            GameObject myEnemy = Instantiate(enemy.gameObject, new Vector2(enemy.position.x + xRandomSpawn, enemy.position.y + yRandomSpawn), Quaternion.identity);
            myEnemy.SetActive(true);
            GameObject myCollider = Instantiate(enemyCollider, new Vector2(xRandomSpawn, yRandomSpawn), Quaternion.identity);
            myCollider.SetActive(true);
            myCollider.GetComponent<Base_Enemy>().enemigo = myEnemy.transform;

            instancedEnemies.Add(myEnemy);
            instancedEnemies.Add(myCollider);
        }
        else if (enemyType == 1)
        {
            GameObject myEnemy = Instantiate(enemyTree.gameObject, new Vector2(xRandomSpawn, yRandomSpawn), Quaternion.identity);
            myEnemy.SetActive(true);
            GameObject myCollider = Instantiate(enemyTreeCollider, new Vector2(xRandomSpawn, yRandomSpawn), Quaternion.identity);
            myCollider.SetActive(true);
            myCollider.GetComponent<Tree_Enemy>().enemigo = myEnemy.transform;

            instancedEnemies.Add(myEnemy);
            instancedEnemies.Add(myCollider);
        }
        //yield return new WaitForSeconds(2);
        //yield return StartCoroutine("SpawnEnemigos");
    }
    public void KillAllInstancedEnemies()
    {

        for (int i = 0; i <= instancedEnemies.Count-1; i++)
        {
            Destroy(instancedEnemies[i]);
        }

        instancedEnemies.Clear();

    }
}
