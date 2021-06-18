using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollScript : MonoBehaviour
{
    public Rigidbody[] ragdollRB;
    private Animator anim;
    private CapsuleCollider capColl;
    private Rigidbody rb;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        capColl = gameObject.GetComponent<CapsuleCollider>();
        Screen.fullScreen = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Break();
            Destroy(collision.gameObject);
        }
    }

    private void Break()
    {
        capColl.enabled = false;
        this.GetComponent<Animator>().runtimeAnimatorController = null as RuntimeAnimatorController;

        for (int i = 0; i < ragdollRB.Length; i++)
        {
            ragdollRB[i].isKinematic = false;
        }
    }
}
