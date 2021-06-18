using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MovementScript : MonoBehaviour
{
    Animator anim;
    float speed = 2;
    public bool posing = false;

    public bool Active;

    public GameObject camera;

    public float poseInterval = 5f;
    public float poseTimer = 0f;
    bool outOfTime = false;


    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float forward = Input.GetAxis("Vertical")/* * 2.0f * Time.deltaTime*/;
        float strafe = Input.GetAxis("Horizontal")/* * 1.0f * Time.deltaTime*/;



        if(Active)
        {
            camera.SetActive(true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 4;
                anim.SetBool("Running", true);
            }
            else if (Input.GetKey(KeyCode.LeftControl))
            {
                speed = 1;
                anim.SetBool("Sneaking", true);
            }
            else
            {
                speed = 2;
                anim.SetBool("Running", false);
                anim.SetBool("Sneaking", false);
            }


            transform.Translate(strafe * Time.deltaTime, 0, forward * Time.deltaTime * speed);

            Move(strafe, forward);

            if (Input.GetKeyDown(KeyCode.Q) && forward == 0)
            {
                RandomPose();
                posing = true;
            }

            PoseTimer();

            if (posing && (forward > 0 || forward < 0) || outOfTime)
            {
                anim.SetBool("Exit Pose", true);
                posing = false;
                outOfTime = false;
            }

            if(posing)
            {
                poseTimer += Time.deltaTime;
            }

        }
        else
            camera.SetActive(false);
    }

    void PoseTimer()
    {
        if(posing)
        {
            poseTimer += Time.deltaTime;

            if (poseTimer >= poseInterval)
            {
                outOfTime = true;
                poseTimer = 0;
            }
        }
    }

    void RandomPose()
    {

        if(posing)
            anim.SetBool("Exit Pose", true);

        int i = Random.Range(0, 7);

        anim.SetBool("" + i, true);
    }


    private void Move(float x, float y)
    {
        anim.SetFloat("Strafe", x);
        anim.SetFloat("Forward", y);
    }
}

