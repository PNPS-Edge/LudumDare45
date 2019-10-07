using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelArenaController : MonoBehaviour
{
    #region Fields

    /// <summary>
    /// Field for instance of the game controller
    /// </summary>
    private static LevelArenaController instance;

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
        this.PlayerScore += score;
        this.CheckEvolution();
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

    #endregion Functions
}
