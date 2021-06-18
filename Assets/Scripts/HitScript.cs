using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    float health;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }


    public void TakeDamage(float amount)
    {
        Debug.Log("ENEMY SHOT" + health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Ouch");

        if(collision.gameObject.tag == "Projectile")
        {
            rb.constraints = RigidbodyConstraints.None;
            
        }
    }
}
