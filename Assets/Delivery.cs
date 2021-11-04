using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    SpriteRenderer spriteren;

    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage;

    void Start()
    {
        spriteren = GetComponent<SpriteRenderer>();
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("picked up");
            hasPackage = true;

            spriteren.color = hasPackageColor;

            Destroy(other.gameObject, destroyDelay);

        }
        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("delivered");
            hasPackage = false;

            spriteren.color = noPackageColor;
        }
    }
}
