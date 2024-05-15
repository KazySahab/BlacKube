using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingGround : MonoBehaviour
{
    public float speed;
    private float speedMultiplier=1;
    public float waitduration=4;
    Vector3 targetPos;
    public Transform posA, posB;
    public bool isTargetReached;
    //public Transform originalParent;

    void Awake()
    {
        targetPos = posB.position;
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speedMultiplier*speed * Time.deltaTime);
        Nextpoint(); 
    }
    void Nextpoint()
    {
        if (Vector2.Distance(transform.position, posA.position) < 0.1f)
        {
            targetPos = posB.position;
            StartCoroutine(WaitSomeTime(waitduration));
            
        }
       

       if(Vector2.Distance(transform.position, posB.position) < 0.1f)
        {
            targetPos = posA.position;
            StartCoroutine(WaitSomeTime(waitduration));
            
        }
        
        
    }
    IEnumerator WaitSomeTime(float duration)
    {
        speedMultiplier=0;
        yield return new WaitForSeconds(duration);
        speedMultiplier = 1;
        Debug.Log(duration);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
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
    
}
