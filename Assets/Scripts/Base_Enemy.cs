using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Enemy : MonoBehaviour
{  
    public float attackDamage;

    public Transform enemigo;

    public float timer;

    private void Update()
    {
        transform.position = new Vector3(enemigo.position.x, enemigo.position.y, 0f);
        timer += Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Dentro player");
        if (collision.gameObject.CompareTag("Player") && timer > 2f)
        {
            timer = 0;
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            Debug.Log("Estoy entrando Player");
        }
    }

}
