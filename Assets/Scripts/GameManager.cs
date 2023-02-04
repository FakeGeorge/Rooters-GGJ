using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform enemy;

    public enum Epocas { prehistoria, medievo, actual, futuro};
    public static Epocas miEpoca;

    float randomSpawn;

    // Start is called before the first frame update
    void Start()
    {
        miEpoca = Epocas.prehistoria;
        InvokeRepeating(nameof(InstanciarEnemigo), 2, 2);
    }

    void InstanciarEnemigo()
    {
        randomSpawn = Random.Range(-9, 9);
        Instantiate(enemy.gameObject, new Vector2(randomSpawn, randomSpawn), Quaternion.identity);
    }
}
