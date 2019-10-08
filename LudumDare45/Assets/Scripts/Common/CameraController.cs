using UnityEngine;

/// <summary>
/// Class for camera controller
/// </summary>
public class CameraController : MonoBehaviour
{
    #region Field

    /// <summary>
    /// Field for offset between Game Object and Camera
    /// </summary>
    private Vector3 offset;

    #endregion Field

    #region Properties

    /// <summary>
    /// Gets or sets the game object to follow
    /// </summary>
    public Transform GameObjectToFollow;

    /// <summary>
    /// Gets or sets a value indicating whether X axis is locked
    /// </summary>
    public bool LockX;

    /// <summary>
    /// Gets or sets a value indicating whether Y axis is locked
    /// </summary>
    public bool LockY;

    /// <summary>
    /// Gets or sets a value indicating whether Z axis is locked
    /// </summary>
    public bool LockZ;

    #endregion Properties

    #region Functions

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        // Determine the offset between object to follow and the camera
        offset = new Vector3
            (
                LockX ? 0.0f : this.transform.position.x - this.GameObjectToFollow.position.x,
                LockY ? 0.0f : this.transform.position.y - this.GameObjectToFollow.position.y,
                LockZ ? 0.0f : this.transform.position.z - this.GameObjectToFollow.position.z
            );
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        // Determines the position of the camera
        transform.position = new Vector3
            (
                LockX ? this.transform.position.x + this.offset.x : this.GameObjectToFollow.position.x + this.offset.x,
                LockY ? this.transform.position.y + this.offset.x : this.GameObjectToFollow.position.y + this.offset.y,
                LockZ ? this.transform.position.z + this.offset.z : this.GameObjectToFollow.position.z + this.offset.z
            );
    }

    #endregion Functions
}
