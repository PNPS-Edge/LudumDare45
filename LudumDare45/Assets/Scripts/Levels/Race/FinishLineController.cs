using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineController : MonoBehaviour
{
    #region Properties
    public Animator animator;

    /// <summary>
    /// Gets or sets the GO to move after the finish line
    /// </summary>
    public GameObject Exit;
    #endregion

    #region Fields
    private bool exitrequired;

    /// <summary>
    /// Ges or sets the player
    /// </summary>
    private GameObject player;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.exitrequired)
        {
            Vector3 pos = this.player.transform.position;
            Vector3 newPos = Vector3.Lerp(pos, this.Exit.transform.position, Time.deltaTime * 5);

            this.player.transform.position = newPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Freeze the player 
            collision.GetComponent<PlayerRaceController>().enabled = false;

            animator.SetTrigger("FadeOut");
            exitrequired = true;

            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 2 && !animator.IsInTransition(0) && exitrequired)
            {
                StartCoroutine(ChangeScene());
            }
        }
        else if (collision.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
    public IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(1.8f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
