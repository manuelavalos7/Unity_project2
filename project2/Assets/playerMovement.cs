using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{

    //This class controls player movement, anmiations, and health

    private float speed = 3f;//speed of the player
    private Animator animate;//animator to avoid calling getcomponent each time
    [SerializeField] Camera cam;//the main camera to change position based on camera rotation
    [SerializeField] Slider hpBar;//refrence of the slider for health
    private int health=100;//amount of health player has

    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponentInChildren<Animator>();//set refrence to animator 
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.value = health;//set slider to the amount of health player has
        if (health <= 0) {//if player health is below 0
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);//reset the scene
        }
        
        if (Input.GetKey(KeyCode.W)) {//if W key is pressed
            transform.position += new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z) * Time.deltaTime*speed;//move forward using the forward vector from camera and character speed
            animate.SetBool("walkForward", true);//set animation to walk forward
        }
        else
        {
            animate.SetBool("walkForward", false);//otherwise stop walking animation forward
        }
        if (Input.GetKey(KeyCode.A))//if A is pressed
        {
            animate.SetBool("walkLeft", true);//set walk left animation to play
            transform.position += - new Vector3(cam.transform.right.x,0,cam.transform.right.z) * Time.deltaTime* speed;//move left using the negative right vector from camera and character speed
        }
        else
        {
            animate.SetBool("walkLeft", false);//otherwise stop walk left animation
        }
        if (Input.GetKey(KeyCode.S))//if S key is pressed
        {
            animate.SetBool("walkBack", true);//set flag to start walking back animation
            transform.position += Time.deltaTime * -new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z) * speed;//move back using the negative forward vector from camera and character speed
        }
        else {
            animate.SetBool("walkBack", false);//otherwise unset walk back animation flag
        }
        if (Input.GetKey(KeyCode.D))//if D is pressed
        {
            animate.SetBool("walkRight", true);//set walk right animation to true
            transform.position += Time.deltaTime * new Vector3(cam.transform.right.x, 0, cam.transform.right.z) * speed;//walk right using right vector from camera and character speed
        }
        else {
            animate.SetBool("walkRight", false);//ohterwise unset walkright flag for animation
        }
        if (transform.position.y <= -5){//if player below a certain height on the map
            health = 0;//kill the chartacter
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Axe") {//if hit by axe (or sword)
            health -= 20;//reduce health by 20
        }
        if (other.tag == "Scratch")//if hit by enemy2 scratch
        {
            health -= 10;//reduce health by 10
        }
    }
}
