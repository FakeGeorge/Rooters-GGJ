using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Enemy : MonoBehaviour
{  
    public Transform target;

    public float minimumDistance;
    public float speed;
    public float attackDamage;

    // Update is called once per frame
    void Update()
    {

        FollowTarget();
    }

    public void FollowTarget()
    {
        if (Vector2.Distance(transform.position, target.position) > minimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("Attack");
        }
    }

    
}
