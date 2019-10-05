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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") )
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("EnemyCac"))
        {
            collision.GetComponent<EnemyControlCac>().SetHealth(10);
            Destroy(gameObject);
        }
        if (collision.CompareTag("EnemyDistance"))
        {
            collision.GetComponent<EnemyControlDistance>().SetHealth(10);
            Destroy(gameObject);
        }
    }
}
