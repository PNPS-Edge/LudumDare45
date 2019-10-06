using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlDistance : MonoBehaviour
{
    int health =100;
    public Transform target;
    public float timer=2f;
    private Vector2 movement;
    private float timeLeft;
    private float maxSpeed = 5f;
    Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {

        rb = gameObject.GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //CheckDistance();
        
        timeLeft -= Time.deltaTime;
        if(timeLeft <=0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeLeft += timer;
        }
        
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * maxSpeed);
    }


    //Vie de l'ennemie
    public void SetHealth(int nb)
    {
        health = health - nb;
        if (health <= 0)
        {
            target.GetComponent<PlayerMovement>().SetScore(25);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
        {
            //Retire une vie au joueur
            if (collision.CompareTag("Player"))
            {
            collision.GetComponent<PlayerMovement>().SetDamage();
            Destroy(gameObject);
            }
            
        }
    
}

