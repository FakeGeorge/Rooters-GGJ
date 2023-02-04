using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTree_Enemy : MonoBehaviour
{
    public Transform target;

    public float minimumDistance;
    public float speed;
    public float attackDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowTargetTree();
    }

    public void FollowTargetTree()
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
