using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    //public GameObject hitEffect;
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f); //remove the effect particule or sprite after 5sec
        Destroy(gameObject);
    }*/

    private void Update()
    {
        
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        if ((transform.position.x < min.x) || (transform.position.x > max.x) ||
                (transform.position.y < min.y) || (transform.position.y > max.y))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") )
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("EnemyCac"))
        {
            collision.GetComponent<EnemyControlCac>().SetHealth(50);
            Destroy(gameObject);
        }
        if (collision.CompareTag("EnemyDistance"))
        {
            collision.GetComponent<EnemyControlDistance>().SetHealth(50);
            Destroy(gameObject);
        }
    }
}
