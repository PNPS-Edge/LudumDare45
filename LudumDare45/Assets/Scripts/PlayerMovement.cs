using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera cam;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 mousePos;
    private int compteurVie = 1;
    public int score = 0;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("movement : " + movement.x);
        movement.x = Input.GetAxisRaw("Horizontal");
        Debug.Log("movement 2  : " + movement.x);
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") || collision.CompareTag("EnemyCac") || collision.CompareTag("EnemyDistance"))
        {
            compteurVie -= 1;
            ChangeAnimation();
            if(compteurVie <=0)
            { 
            Destroy(gameObject);
            }
        }
        
    }

    public void SetScore(int nb)
    {
        score += nb;
        if (score >= 50 && score <= 100)
        {
            compteurVie += 1;
            ChangeAnimation();
        }
        if (score == 100)
        {
            compteurVie += 1;
            ChangeAnimation();
        }
        if (score == 150)
        {
            compteurVie += 1;
        }
    }

    public void ChangeAnimation()
    {
        switch(compteurVie)
        {
            case 1:
                {
                    //animation spermatozoide
                    animator.SetInteger("Vie", 2);
                    break;
                }
            case 2:
                {
                    //animation coeur
                    animator.SetInteger("Vie", 3);
                    break;
                }
            case 3:
                {
                    //animation foetus
                    animator.SetInteger("Vie", 4);
                    break;
                }
        }
       
    }

}
