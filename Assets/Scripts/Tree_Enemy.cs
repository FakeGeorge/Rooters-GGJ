using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Enemy : MonoBehaviour
{
    public float attackDamage;
    public float maxHealth;
    public float health;

    public Transform enemigo;

    float timer;
    float timeDif;

    Animator Anim;

    public GameObject blood;
    public GameObject bloodInstantiated;
    public GameObject tree;

    [SerializeField] Settings settings;
    [SerializeField] AudioClip Golpear;

    private void Start()
    {
        health = maxHealth;

        timer = Time.time;

        Anim = enemigo.GetComponent<Animator>();
        tree = GameObject.FindGameObjectWithTag("Tree");
        Anim.SetBool("IsAttacking", false);

        settings = GameObject.Find("Settings").GetComponent<Settings>();
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(enemigo.position.x, enemigo.position.y, 0f);
        timeDif = Time.time - timer;


    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tree") && timeDif > 2f)
        {
            Anim.SetBool("IsAttacking", true);
            collision.gameObject.GetComponent<TreeOfLife>().GetDamage(attackDamage);
            Debug.Log("timer despues " + timer);

            timer = Time.time;
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tree"))
        {
            if (tree.gameObject.transform.position.x-gameObject.transform.position.x >= 0)
            {
                Debug.Log(tree.gameObject.transform.position.x - gameObject.transform.position.x);
                Debug.Log("lloro");
                Anim.SetBool("IsRightAttack", true);
                
            }
            else
            {
                Debug.Log("QUEEEE");
                Anim.SetBool("IsAttacking", true);

            }
            InvokeRepeating("RepeatAttack", 0, 2);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tree"))
        {
            Anim.SetBool("IsAttacking", false);
            Anim.SetBool("IsRightAttack", false);
            CancelInvoke();
        }
    }

    public void TakeDamage(float damageValue)
    {
        if (health > 0)
        {
            health -= damageValue;
        }
        else if (health <= 0)
        {
            DestroyEnemy();
        }
    }

    public void DestroyEnemy()
    {
        bloodInstantiated = Instantiate(blood, transform.position, Quaternion.identity);
        enemigo.gameObject.SetActive(false);
        gameObject.SetActive(false);

        settings.PlaySFX(Golpear);

        Invoke("DestroyBlood", 1f);
    }

    void DestroyBlood()
    {
        Destroy(bloodInstantiated);
        Destroy(enemigo.gameObject);
        Destroy(gameObject);
    }

    void RepeatAttack()
    {
        if (tree.gameObject.transform.position.x - gameObject.transform.position.x >= 0)
        {
            Debug.Log(tree.gameObject.transform.position.x - gameObject.transform.position.x);
            Debug.Log("lloro");
            Anim.SetBool("IsRightAttack", true);

        }
        else
        {
            Debug.Log("QUEEEE");
            Anim.SetBool("IsAttacking", true);

        }
        tree.GetComponent<TreeOfLife>().GetDamage(attackDamage);
    }
}
