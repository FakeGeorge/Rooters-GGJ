using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Enemy : MonoBehaviour
{  
    public float attackDamage;
    public float maxHealth;
    public float health;

    public Transform enemigo;

    float timer;

    Animator Anim;

    private void Start()
    {
        health = maxHealth;

        Anim = enemigo.GetComponent<Animator>();
        Anim.SetBool("IsAttacking", false);
    }
    private void Update()
    {
        transform.position = new Vector3(enemigo.position.x, enemigo.position.y, 0f);
        timer += Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Dentro player");
        Debug.Log("timer jeje " + timer);
        if (collision.gameObject.CompareTag("Player") && timer > 2f)
        {
            timer = 0;
            Anim.SetBool("IsAttacking", true);
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(attackDamage); 
            Debug.Log("Estoy entrando Player");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Me sali");
        Anim.SetBool("IsAttacking", false);
    }

    public void TakeDamage(float damageValue)
    {
        if (health > 0)
        {
            health -= damageValue;
        }
        else if (health <= 0)
        {
            //Activar boliches
            DestroyEnemy();
        }
    }

    public void DestroyEnemy()
    {
        Destroy(enemigo.gameObject);
        Destroy(gameObject);
    }
}
