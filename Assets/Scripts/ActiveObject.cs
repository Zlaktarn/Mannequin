using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObject : MonoBehaviour
{
    public MovementScript mannequin;
    public CopMovement cop;

    bool isActive;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            mannequin.Active = true;
            cop.Active = false;
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            mannequin.Active = false;
            cop.Active = true;

        }
    }
}
