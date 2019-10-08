using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace Assets.Scripts
{
    /// <summary>
    /// Class for game controller
    /// </summary>
    public class GameController : MonoBehaviour
    {
        #region Fields

        /// <summary>
        /// Field for instance of the game controller
        /// </summary>
        private static GameController instance;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the game controller instance
        /// </summary>
        public static GameController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<GameController>();
                }

                return instance;
            }
        }

        #endregion Properties

        #region Methods

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

        #endregion Unity

        #endregion Functions
    }
}
