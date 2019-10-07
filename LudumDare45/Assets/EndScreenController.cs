using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenController : MonoBehaviour
{
    private bool exitrequired;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            FadeOut();
        }
    }

    public void FadeOut()
    {
        animator.SetTrigger("FadeOut");
        exitrequired = true;

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 2 && !animator.IsInTransition(0) && exitrequired)
        {
            StartCoroutine(ChangeScene());
        }
    }

    public IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(1.8f);

        SceneManager.LoadScene(0);
    }
}
