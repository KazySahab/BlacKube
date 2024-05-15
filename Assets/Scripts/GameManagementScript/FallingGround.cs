using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingGround : MonoBehaviour
{
    public Transform targetPos;
    Vector2 startPos;
    public float speed;
    private bool isFalling;
    private PlayerDeathCheck playerDeathCheck;
    private void Awake()
    {
        playerDeathCheck = FindObjectOfType<PlayerDeathCheck>();
        startPos = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           isFalling = true;
            
            collision.transform.SetParent(this.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
    private void Update()
    {
        if(isFalling)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos.position, speed * Time.deltaTime);
        }
        if(playerDeathCheck.isdead)
        {
            this.transform.position = startPos;
            isFalling = false;
        }
    }
}
