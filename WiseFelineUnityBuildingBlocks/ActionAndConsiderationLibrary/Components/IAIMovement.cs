using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// This interface is implemented by all AI movement types which allow an agent to choose a target and move toward it.
/// </summary>
public interface IAIMovement
{

    /// <summary>
    /// Should contain the movement destination
    /// </summary>
    Vector3 Destination { get; }

    /// <summary>
    /// Moves the character to a position specified by a Vector3 and calls a callback when arrived
    /// </summary>
    /// <param name="position"></param>
    /// <param name="callback"></param>
    /// <returns>Ture if the movement can happen, false otherwise. Path Finding failures and other issues can prevent the movement to happen.</returns>
    bool MoveToPosition(Vector3 position, Action callback = null);

    /// <summary>
    /// Moves the character to the position of a GameObject and calls a callback when arrived
    /// </summary>
    /// <param name="position"></param>
    /// <param name="callback"></param>
    /// <returns>Ture if the movement can happen, false otherwise<. Path Finding failures and other issues can prevent the movement to happen.</returns>
    bool MoveToPosition(GameObject position, Action callback = null);

    /// <summary>
    /// Stops the movement no matter if we arrived at the set destination or not
    /// </summary>
    void StopMoving();
}
