using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Camera cam;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 mousePos;
    public int compteurVie;
    public int score = 0;
    private Animator animator;
    private int timeEvolve = 30;

    // Start is called before the first frame update
    void Start()
    {
        compteurVie = 1;
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
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //Temps avant que le spermaplayer evolue
        if(compteurVie == 1)
        {
            timeEvolve -= 1;
            if (timeEvolve <= 0)
            {
                compteurVie += 1;
                timeEvolve = 60;
                ChangeAnimation();
            }
        }

    }
    /// <summary>
    /// Met à jour la vie du joueur
    /// </summary>
    public void SetDamage()
    {
        compteurVie = compteurVie - 1;
        if (compteurVie <= 0)
        {
            SceneManager.LoadScene("YouLoose");
            
        }
        ChangeAnimation();
    }

 
    /// <summary>
    /// Score du joueur permet également d'évoluer
    /// </summary>
    /// <param name="nb"></param>
    public void SetScore(int nb)
    {
        score += nb;
        
        if (score == 200 )
        {
            compteurVie += 1;
            ChangeAnimation();
        }
        if (score == 300)
        {
            compteurVie += 1;
            ChangeAnimation();
        }
        if(score == 500)
        {
            SceneManager.LoadScene("YouWin");
        }
    }

    public void ChangeAnimation()
    {
        switch(compteurVie)
        {
            case 1:
                {
                    //animation spermaplayer
                    animator.SetInteger("Vie", 1);
                    break;
                }
            case 2:
                {
                    //animation ambryon
                    animator.SetInteger("Vie", 2);
                    break;
                }
            case 3:
                {
                    //animation coeur
                    //animator.enabled = true;
                    animator.SetInteger("Vie", 3);
                    break;
                }
            case 4:
                {
                    //animation foetus
                    animator.SetInteger("Vie", 4);

                    break;
                }
        }
       
    }

}
