using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Enemy : MonoBehaviour
{
    public float attackDamage;
    TreeOfLife TreeOfLife_Script;

    private void Start()
    {
        //TreeOfLife_Script = FindObjectOfType<TreeOfLife>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Dentro");
        if (collision.gameObject.CompareTag("Tree"))
        {
            collision.gameObject.GetComponent<TreeOfLife>().GetDamage(attackDamage);
            Debug.Log("Estoy entrando Tree");
        }

    }
}
