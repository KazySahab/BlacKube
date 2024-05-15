using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObstaclePosition : MonoBehaviour
{
    Vector2 startPos;
    private PlayerDeathCheck playerDeathCheck;
    private void Awake()
    {
        playerDeathCheck = FindObjectOfType<PlayerDeathCheck>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerDeathCheck.isdead)
        {
            this.transform.position = startPos;
        }
    }
}
