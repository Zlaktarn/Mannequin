using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject projectile;
    public Transform spawnPoint;


    public float shootForce;
    private float nextTimeToFire;
    private float fireRate = 1f;
    public Animator anim;
    public Camera cam;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;

            anim.SetBool("Shoot", true);
            GameObject gameObject = Instantiate(projectile, spawnPoint.position, Quaternion.identity);
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.velocity = this.transform.forward * shootForce;
        }
    }
}
