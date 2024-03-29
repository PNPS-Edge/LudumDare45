﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlCac : MonoBehaviour
{
    #region Properties

    public int health = 150;
    public float speed;
    public Transform target;
    public float chaseRadius;

    /// <summary>
    /// Gets orr sets the death animation
    /// </summary>
    public GameObject Explosion;
    #endregion

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
            target.GetComponent<PlayerMovement>().SetScore(25);
            GameObject expl = GameObject.Instantiate(Explosion, this.transform.position, Quaternion.identity);
            Destroy(expl, 1);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().SetDamage();
            Destroy(gameObject);
        }
    }

    void CheckDistance()
    {
        //Enemy will chase the player
        if (Vector2.Distance(target.position, transform.position) <= chaseRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

    }
}
