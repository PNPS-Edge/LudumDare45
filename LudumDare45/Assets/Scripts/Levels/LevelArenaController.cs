using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelArenaController : MonoBehaviour
{
    #region Fields

    /// <summary>
    /// Field for instance of the game controller
    /// </summary>
    private static LevelArenaController instance;

    private bool exitrequired;

    #endregion Fields

    #region Properties

    /// <summary>
    /// Gets or sets the game controller instance
    /// </summary>
    public static LevelArenaController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<LevelArenaController>();
            }

            return instance;
        }
    }

    public int PlayerScore;

    /// <summary>
    /// Gets or sets the value indicating wheter the game is over
    /// </summary>
    public bool IsGameOver = false;

    public Animator animator;

    #endregion Properties

    #region Methods

    public void GameStart()
    {
        this.IsGameOver = false;
    }


    public void GameIsOver()
    {
        this.IsGameOver = true;
    }

    public void PlayerScored(int score)
    {
    }

    #endregion Methods

    #region Functions

    #region Unity

    private void Awake()
    {
        #region Persistence

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);

        #endregion Persistence
    }

    private void Update()
    {

    }

    #endregion Unity

    private void CheckEvolution()
    {

    }

    public void ChangeLevel(string level)
    {
        animator.SetTrigger("FadeOut");
        exitrequired = true;

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 2 && !animator.IsInTransition(0) && exitrequired)
        {
            StartCoroutine(ChangeScene(level));
        }
    }

    private IEnumerator ChangeScene(string level)
    {
        yield return new WaitForSeconds(1.8f);

        SceneManager.LoadScene(level);
    }

    #endregion Functions
}
