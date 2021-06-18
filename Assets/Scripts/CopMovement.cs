using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopMovement : MonoBehaviour
{
    float speed = 2;
    float sideSpeed = 2;
    Animator anim;

    public bool Active;

    public GameObject camera;

    float fireCD = 1f;
    float firerate;


    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        float forward = Input.GetAxis("Vertical")/* Time.deltaTime*/;
        float strafe = Input.GetAxis("Horizontal")/* * 1.0f * Time.deltaTime*/;

        if (Active)
        {
            camera.SetActive(true);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 4.0f;
                sideSpeed = 3.0f;
                anim.SetBool("Running", true);
            }
            else if (Input.GetKey(KeyCode.LeftControl))
            {
                speed = 1;
                anim.SetBool("Sneaking", true);
            }
            else
            {
                speed = 1f;
                sideSpeed = 1.5f;
                anim.SetBool("Running", false);
            }

            transform.Translate(strafe * sideSpeed * Time.deltaTime, 0, forward * Time.deltaTime * speed);

            Move(strafe, forward);
        }
        else
            camera.SetActive(false);
        
    }


    private void Move(float x, float y)
    {
        anim.SetFloat("Horizontal", x);
        anim.SetFloat("Vertical", y);
    }
}
