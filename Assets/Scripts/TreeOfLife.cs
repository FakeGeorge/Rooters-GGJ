using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeOfLife : MonoBehaviour
{

    public float hp;
    [SerializeField] List<Sprite> mySprites = new List<Sprite>();
    Sprite currentSprite;

    private void Start()
    {
        currentSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    public void GetDamage(float damage)
    {
        hp -= damage;

        //animación de ser golpeado/particulas/algo

        if (hp <= hp*.75f && GameManager.miEpoca == GameManager.Epocas.prehistoria)  //si está a 75% vida y en prehistoria, cambia a medievo
        {
            GameManager.miEpoca = GameManager.Epocas.medievo;
            currentSprite = mySprites[1];
        }
        if (hp <= hp*.5f && GameManager.miEpoca == GameManager.Epocas.medievo)
        {
            GameManager.miEpoca = GameManager.Epocas.actual;
            currentSprite = mySprites[2];
        }
        if (hp <= hp*.25f && GameManager.miEpoca == GameManager.Epocas.actual)
        {
            GameManager.miEpoca = GameManager.Epocas.futuro;
            currentSprite = mySprites[3];
        }
    }
}
