﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject EnemyBullet;

    //Sound effect
    public AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        float rend = Random.Range(1F, 3F);
        InvokeRepeating("FireEnemyBullet", 1, rend);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    /// <summary>
    /// L'ennemi tirera en direction de la position du joueur 
    /// </summary>
    void FireEnemyBullet()
    {
        GameObject playerShip = GameObject.Find("Player");

        if(playerShip != null)
        {
            GameObject bullet = (GameObject)Instantiate(EnemyBullet);

            bullet.transform.position = transform.position;

            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            bullet.GetComponent<EnemyBullets>().setDirection(direction);
        }
        AudioSource.Play();
    }
}
