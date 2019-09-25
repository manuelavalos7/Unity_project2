using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    private float speed = 5f;
    private Animator animate;
    [SerializeField] Camera cam;
    public Quaternion projectileRotattion;
    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.W)) {
            transform.position += new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z) * Time.deltaTime*speed;
            animate.speed = 1;
            animate.SetBool("walkForward", true);
        }
        else
        {
            animate.SetBool("walkForward", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            animate.SetBool("walkLeft", true);
            transform.position += - new Vector3(cam.transform.right.x,0,cam.transform.right.z) * Time.deltaTime* speed;
            animate.speed = 1;
        }
        else
        {
            animate.SetBool("walkLeft", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            animate.SetBool("walkBack", true);
            transform.position += Time.deltaTime * -new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z) * speed;
            animate.speed = 1;
        }
        else {
            animate.SetBool("walkBack", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            animate.SetBool("walkRight", true);
            transform.position += Time.deltaTime * new Vector3(cam.transform.right.x, 0, cam.transform.right.z) * speed;
            GetComponentInChildren<Animator>().speed = 1;
        }
        else {
            animate.SetBool("walkRight", false);
        }
        if (transform.position.y <= -5){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


    }
}
