using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float RotationSpeed = 1;
    public Transform Target;
    public GameObject player;
    Transform pTransform;
    MovementScript pScript;

    float mouseX, mouseY;

    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    float zoomSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        pTransform = player.GetComponent<Transform>();
        pScript = player.GetComponent<MovementScript>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = Target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        CamControl();
    }

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(Target);

        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);


        if(pScript.posing)
        {

        }
        else
            pTransform.rotation = Quaternion.Euler(0, mouseX, 0);


        if (Input.GetMouseButton(1))
        {
            //Light.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
        else
        {
            //Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            //Light.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }

    }
}
