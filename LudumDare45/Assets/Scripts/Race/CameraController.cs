using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Field

    private Vector3 offset;

    #endregion Field

    #region Properties

    public GameObject Player;

    #endregion Properties

    #region Functions

    // Start is called before the first frame update
    private void Start()
    {
        offset = this.transform.position - Player.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(this.transform.position.x + this.offset.x, Player.transform.position.y + this.offset.y, this.transform.position.z);
    }

    #endregion Functions
}
