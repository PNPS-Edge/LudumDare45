using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class for the movement area parameters
/// </summary>
[System.Serializable]
public class PlayerRaceMovementArea
{
    #region Properties

    /// <summary>
    /// Gets or sets the minimum and maximum on the X-Axis
    /// </summary>
    public MinimumMaximum X;

    /// <summary>
    /// Gets or sets the minimum and maximum on the Y-Axis
    /// </summary>
    public MinimumMaximum Y;

    #endregion Properties
}
