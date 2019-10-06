using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour
{
    float speed;
    Vector2 bulletDirection;
    bool isReady;

    void Awake()
    {
        speed = 3f;
        isReady = false;
  
    }
    
    public void setDirection(Vector2 direction)
    {
        bulletDirection = direction.normalized;
        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isReady)
        {
            Vector2 position = transform.position;

            position += bulletDirection * speed * Time.deltaTime;
            transform.position = position;

            //get the position of camera
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            //Si hors cadre destruction du tir
            if ((transform.position.x < min.x) || (transform.position.x > max.x) ||
                (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }
        }
    }
}
