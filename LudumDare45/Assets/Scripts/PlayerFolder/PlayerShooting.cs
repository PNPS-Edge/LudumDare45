using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    /// <summary>
    /// point de tire
    /// </summary>
    public Transform firePoint;
    public Transform firePointTwo;
    public Transform firePointThree;
    public Transform firePointFour;
    /// <summary>
    /// tire de l'ambryon, pour l'avoir au milieu
    /// </summary>
    public Transform firePointCell;
    public GameObject bullet;
    public float bulletForce = 5f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        int playerLife = gameObject.GetComponent<PlayerMovement>().compteurVie;
        switch(playerLife)
        {
            case 1:
                {
                    //Do nothing
                    
                    break;
                }
            case 2: //Player embryon
                {
                    ShooterCell();
                    break;
                }
            case 3: //Player Heart
                {
                    ShooterTwo();
                    break;
                }
            case 4: //Player foetus
                {
                    ShooterTwo();
                    ShooterThree();
                    ShooterFour();
                    break;
                }
            default:
                {
                    
                    break;
                }
        }
        
    }
    void ShooterCell()
    {
        GameObject bullets = Instantiate(bullet, firePointCell.position, firePointCell.rotation);
        Rigidbody2D rb = bullets.GetComponent<Rigidbody2D>();
        rb.AddForce(firePointCell.up * bulletForce, ForceMode2D.Impulse);
    }
   
    void ShooterTwo()
    {
        
        GameObject bullets = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullets.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        GameObject bullets2 = Instantiate(bullet, firePointTwo.position, firePointTwo.rotation);
        Rigidbody2D rb2 = bullets2.GetComponent<Rigidbody2D>();
        rb2.AddForce(firePointTwo.up * bulletForce, ForceMode2D.Impulse);
    }
    void ShooterThree()
    {
        GameObject bullets2 = Instantiate(bullet, firePointThree.position, firePointThree.rotation);
        Rigidbody2D rb3 = bullets2.GetComponent<Rigidbody2D>();
        rb3.AddForce(firePointThree.up * bulletForce, ForceMode2D.Impulse);

    }
    void ShooterFour()
    {
        GameObject bullets = Instantiate(bullet, firePointFour.position, firePointFour.rotation);
        Rigidbody2D rb4 = bullets.GetComponent<Rigidbody2D>();
        rb4.AddForce(firePointFour.up * bulletForce, ForceMode2D.Impulse);
    }
}
