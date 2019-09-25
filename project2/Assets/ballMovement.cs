using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour
{
    private float power = 75;
    private float offset = 0.0f;
    private float timer = 10f;
    // Start is called before the first frame update
    void Start()
    {
        transform.forward = Vector3.up*offset +transform.forward;
        
        GetComponent<Rigidbody>().AddForce(transform.forward*power);

    }

    private void Update()
    {
        timer -= Time.deltaTime*10;
        if (transform.position.y <= -5 || timer < 0)
        {
            Debug.Log("Tried to destroy");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            other.GetComponent<Rigidbody>().AddForce(transform.forward*500);
            //Destroy(gameObject);
        }
    }

}
