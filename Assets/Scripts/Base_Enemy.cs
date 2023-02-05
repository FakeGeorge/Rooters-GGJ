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
    float timeDif;

    Animator Anim;

    public GameObject blood;
    public GameObject bloodInstantiated;
    public GameObject player;

    [SerializeField] Settings settings;
    [SerializeField] AudioClip Golpear;

    private void Start()
    {
        health = maxHealth;

        timer = Time.time;

        Anim = enemigo.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        Anim.SetBool("IsAttacking", false);

        settings = GameObject.Find("Settings").GetComponent<Settings>();

    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(enemigo.position.x, enemigo.position.y, 0f);
        timeDif = Time.time - timer;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player.gameObject.transform.position.x - gameObject.transform.position.x >= 0)
            {
                Debug.Log(player.gameObject.transform.position.x - gameObject.transform.position.x);
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
        if (collision.gameObject.CompareTag("Player"))
        {
            Anim.SetBool("IsAttacking", false);
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
        if (player.gameObject.transform.position.x - gameObject.transform.position.x >= 0)
        {
            Debug.Log(player.gameObject.transform.position.x - gameObject.transform.position.x);
            Debug.Log("lloro");
            Anim.SetBool("IsRightAttack", true);

        }
        else
        {
            Debug.Log("QUEEEE");
            Anim.SetBool("IsAttacking", true);

        }
        player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        Debug.Log("timer despues " + timer);
    }
}
