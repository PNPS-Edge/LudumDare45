using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyRacerController : MonoBehaviour
{
    #region Properties

    /// <summary>
    /// Gets or sets the speed
    /// </summary>
    public float Speed;

    #endregion Properties

    #region Functions

    /// <summary>
    /// Fires when object is istanciated
    /// </summary>
    private void Start()
    {
        Rigidbody2D objectRigidbody = gameObject.GetComponent<Rigidbody2D>();


        if (objectRigidbody != null)
        {
            objectRigidbody.velocity = new Vector2(0f, 1.0f) * Speed;
            Debug.Log(objectRigidbody.velocity);
        }
    }

    #endregion Functions
}
