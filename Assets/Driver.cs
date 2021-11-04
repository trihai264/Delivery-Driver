using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.5f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slow = 10f;
    [SerializeField] float boost = 30f;
   

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    //boost
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Boost")
        {
            moveSpeed = boost;
        }
    }

    //slow down when bump at anything
    void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slow;
    }
}
