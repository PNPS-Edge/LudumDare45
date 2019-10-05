using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlCac : MonoBehaviour
{
    int health = 150;
    float speed;
    public Transform target;
    public float attackRadius;
    public float chaseRadius;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    public void SetHealth(int nb)
    {
            health = health - nb;
            if (health <= 0)
            {
            
            target.GetComponent<PlayerMovement>().SetScore(20);
                Destroy(gameObject);
            }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") )
        {
            Destroy(gameObject);
        }
    }

    void CheckDistance()
    {
        
        if (Vector2.Distance(target.position, transform.position) <= chaseRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        
    }
}
