using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float speed = 5f;
    private Animator animate;
    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.W)) {
            transform.position += transform.forward * Time.deltaTime*speed;
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
            transform.position += -transform.right * Time.deltaTime* speed;
            animate.speed = 1;
        }
        else
        {
            animate.SetBool("walkLeft", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            animate.SetBool("walkBack", true);
            transform.position += Time.deltaTime * -transform.forward * speed;
            animate.speed = 1;
        }
        else {
            animate.SetBool("walkBack", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            animate.SetBool("walkRight", true);
            transform.position += Time.deltaTime * transform.right * speed;
            GetComponentInChildren<Animator>().speed = 1;
        }
        else {
            animate.SetBool("walkRight", false);
        }
    }
}
