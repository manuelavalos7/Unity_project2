using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour
{
    private float power = 75;//power that magic ball will be launched at
    private float timer = 15f;//timer fo lifetime of the fireball
    // Start is called before the first frame update
    void Start()
    {
  
        GetComponent<Rigidbody>().AddForce(transform.forward*power);//when an ball object is instantiated immediately send it flying

    }

    private void Update()
    {
        timer -= Time.deltaTime*10;//decrease timer to eventually destory ball
        if (timer < 0)//if timer is done
        {
            Destroy(gameObject);//destory the ball
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")//if collided with anytihng (excep the player)
        {
            Destroy(gameObject); //destroy the ball
        }
    }

}
