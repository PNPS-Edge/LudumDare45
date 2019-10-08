using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlDistance : MonoBehaviour
{
    #region Properties

    public int health = 100;
    public Transform target;
    public float timer = 2f;
    private Vector2 movement;
    private float timeLeft;
    private float maxSpeed = 5f;
    Rigidbody2D rb;

    /// <summary>
    /// Gets or sets the death animation
    /// </summary>
    public GameObject Explosion;
    #endregion Properties


    // Start is called before the first frame update
    void Start()
    {

        rb = gameObject.GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Time before move again
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeLeft += timer;
        }

    }

    void FixedUpdate()
    {
        rb.AddForce(movement * maxSpeed);
    }


    /// <summary>
    /// Setter Enemy life
    /// </summary>
    /// <param name="nb"></param>
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
        //Retire une vie au joueur
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().SetDamage();

            Destroy(gameObject);
        }

    }

}

