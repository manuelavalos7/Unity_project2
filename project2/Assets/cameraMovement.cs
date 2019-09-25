using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform lookAt;
    public Transform camTransform;

    private Camera cam;

    private float distance = 7f;
    private float currentX = 0f;
    private float currentY = 0f;
    private float sensitivityX = 4f;
    private float sensitivityY = 3f;
    private Quaternion projectileRotation;
    private float coolDown = 6.5f;
    private float charge = 6f;
    private bool animationTriggered=false;
    private bool fire = false;

    private const float Y_ANGLE_MIN = 0f;
    private const float Y_ANGLE_MAX = 75f;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        camTransform = transform;
        cam = Camera.main;

    }

    private void Update()
    {
        coolDown -= Time.deltaTime*10;
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");
        currentY = Mathf.Clamp(currentY,Y_ANGLE_MIN, Y_ANGLE_MAX);

        if (Input.GetKeyDown(KeyCode.Mouse0) && coolDown<0)
        {
            fire = true;
        }
        if (fire == true) {
            if (!animationTriggered) {
                lookAt.GetComponentInChildren<Animator>().SetTrigger("Magic");
                animationTriggered = true;
            }
            charge -= Time.deltaTime*10;
            if (charge < 0) {
                GameObject ball = Resources.Load("ball") as GameObject;
                Instantiate(ball, lookAt.position + Vector3.up * 2, projectileRotation);
                fire = false;
                charge = 6f;
                coolDown = 6.5f;
                animationTriggered = false;
            }
            
        }
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position + Vector3.up*2);
        projectileRotation = Quaternion.Euler(currentY-15, currentX, 0);
        lookAt.rotation = Quaternion.Euler(0, currentX, 0);
        
    }

}
