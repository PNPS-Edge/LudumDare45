using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleMenuController : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip audioClip;

    public Animator animator;

    private bool exitrequired;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            audioSource.Play();

            animator.SetTrigger("FadeOut");
            exitrequired = true;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 2 && !animator.IsInTransition(0) && exitrequired)
        {
            StartCoroutine(StartGame());
        }
    }

    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1.8f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
