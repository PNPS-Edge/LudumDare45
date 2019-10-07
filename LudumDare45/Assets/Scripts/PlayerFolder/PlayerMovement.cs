using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    #region Fields

    private Animator animator;
    Vector2 movement;
    Vector2 mousePos;

    #endregion Fields

    #region Properties

    public Camera cam;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public int EvolutionStep;
    public float timeEvolve;
    public int score;
    public int stepScore;
    public PlayerRaceMovementArea PlayerMovementArea;
    public int StepToEvolve = 100;
        
    #endregion Properties

    // Start is called before the first frame update
    private void Start()
    {
        EvolutionStep = 1;
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        // Player's Input within the player movement area
        movement.y = Input.GetAxisRaw("Vertical");
        movement.x = Input.GetAxisRaw("Horizontal");

        // Player's Input within the player movement area
        movement.y = Mathf.Clamp(movement.y, this.PlayerMovementArea.X.Minimum, this.PlayerMovementArea.X.Maximum);
        movement.x = Mathf.Clamp(movement.x, this.PlayerMovementArea.X.Minimum, this.PlayerMovementArea.X.Maximum);

        // Apply the movement 
        Vector2 tmp = this.transform.position;
        tmp += (movement * Time.deltaTime * moveSpeed);    
        this.transform.position = tmp;


        // Mouse position
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos - (Vector2)this.transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        this.rb.rotation = angle;


        // Management of the evolution of the player
        if(EvolutionStep == 1)
        {
            timeEvolve -= Time.deltaTime;

            if (timeEvolve <= 0)
            {
                EvolutionStep++;
                timeEvolve = 7;
                ChangeAnimation();
            }
        }

    }
    /// <summary>
    /// Met à jour la vie du joueur
    /// </summary>
    public void SetDamage()
    {
        EvolutionStep = EvolutionStep - 1;

        if (EvolutionStep <= 0)
        {
            this.enabled = false;
            LevelArenaController.Instance.ChangeLevel("Race"); 
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
        
        if (score >= stepScore + StepToEvolve && EvolutionStep == 2)
        {
            EvolutionStep++;
            stepScore = score;
            ChangeAnimation();
        }
        if (score >= stepScore + StepToEvolve && EvolutionStep == 3)
        {
            EvolutionStep++;
            stepScore = score;
            ChangeAnimation();
        }
        if(score >= stepScore + StepToEvolve && EvolutionStep == 4)
        {
            LevelArenaController.Instance.ChangeLevel("EndScreen");
        }
    }

    public void ChangeAnimation()
    {
        switch(EvolutionStep)
        {
            case 1:
                {
                    //animation spermaplayer
                    animator.SetInteger("EvolutionStep", 1);
                    break;
                }
            case 2:
                {
                    //animation ambryon
                    animator.SetInteger("EvolutionStep", 2);
                    break;
                }
            case 3:
                {
                    //animation coeur
                    animator.SetInteger("EvolutionStep", 3);
                    break;
                }
            case 4:
                {
                    //animation foetus
                    animator.SetInteger("EvolutionStep", 4);
                    break;
                }
        }
       
    }

}
