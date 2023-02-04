using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Enemy : MonoBehaviour
{
    public float attackDamage;
    TreeOfLife TreeOfLife_Script;

    public Transform enemigo;

    public float timer;

    private void Start()
    {
        //TreeOfLife_Script = FindObjectOfType<TreeOfLife>();
    }

    private void Update()
    {
        transform.position = new Vector3(enemigo.position.x, enemigo.position.y, 0f);
        timer += Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Dentro tree");
        if (collision.gameObject.CompareTag("Tree") && timer > 2f)
        {
            timer = 0;
            collision.gameObject.GetComponent<TreeOfLife>().GetDamage(attackDamage);
            Debug.Log("Estoy entrando Tree");
        }
    }

}
