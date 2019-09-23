using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float movement_speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            //GetComponent<Animator>().SetTrigger("Walk");
            transform.position += Time.deltaTime * transform.forward *movement_speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //GetComponent<Animator>().SetTrigger("Walk");
            transform.position += Time.deltaTime * -transform.right * movement_speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //GetComponent<Animator>().SetTrigger("Walk");
            transform.position += Time.deltaTime * -transform.forward * movement_speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //GetComponent<Animator>().SetTrigger("Walk");
            transform.position += Time.deltaTime * transform.right * movement_speed;
        }
    }
}
