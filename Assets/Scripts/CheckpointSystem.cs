using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    public Vector2 playerRestartPosition;

    void Awake()
    {
        playerRestartPosition = this.transform.position;
    }

    public void SetRestartPosition(Vector2 vector2)
    {
        playerRestartPosition = vector2;
    }

    public Vector2 RestartPlayerPosition()
    {
        return playerRestartPosition;
    }
}
