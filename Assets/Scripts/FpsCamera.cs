using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCamera : MonoBehaviour
{
    //public float RotationSpeed = 1;
    public Transform Target;
    public GameObject player;
    Transform pTransform;

    float mouseX, mouseY;

    public LayerMask mask;
    public bool invertMask;
    public float offset;

    float zoomSpeed = 2f;

    Camera camera;

    void Start()
    {
        pTransform = player.GetComponent<Transform>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        camera = gameObject.GetComponent<Camera>();
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = Target.position;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0);

        CamControl();
    }

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X")/* * RotationSpeed*/;
        mouseY -= Input.GetAxis("Mouse Y")/* * RotationSpeed*/;
        mouseY = Mathf.Clamp(mouseY, -35, 35);



        //transform.LookAt(Target);
        pTransform.rotation = Quaternion.Euler(0, mouseX, 0);
        //spine.rotation = Quaternion.Euler(0, mouseX, 0);
        Target.rotation = Quaternion.Euler(mouseY, mouseX + offset, 0);
        transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
    }


}
