using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class for end screen controller
/// </summary>
public class EndScreenController : MonoBehaviour
{
    #region Fields

    /// <summary>
    /// Field for if trasition is required
    /// </summary>
    private bool exitrequired;

    #endregion Fields

    #region Properties

    /// <summary>
    /// Gets or sets the animator
    /// </summary>
    public Animator animator;

    #endregion Properties

    #region Functions

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            FadeOut();
        }
    }

    /// <summary>
    /// Starts the fade out and the scene transition
    /// </summary>
    private void FadeOut()
    {
        animator.SetTrigger("FadeOut");
        exitrequired = true;

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 2 && !animator.IsInTransition(0) && exitrequired)
        {
            StartCoroutine(ChangeScene());
        }
    }

    /// <summary>
    /// Return to Main menu
    /// </summary>
    /// <returns></returns>
    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(1.8f);

        SceneManager.LoadScene(0);
    }

    #endregion Functions
}
