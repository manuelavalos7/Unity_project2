using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class enemy : MonoBehaviour
{
    //This controls enemy movement, heatlth, and animations

    private NavMeshAgent myAgent;//enemy navmesh agent
    private bool enemyAgrro;//enemy detected player flag
    private bool dead;//enemy is dead flah=g
    private GameObject Player;//player object so enemy can detect and find
    public int aggroRange = 8;//range that enemy detects player
    private float attackRange = 2f;//range of enemy melee attack
    private int health=100;//health of enemy
    private float deathTimer = 10f;//to destroy enemy after the die (after some time)
    public AudioSource[] audioSources;//audio clips played by enemies
    private Slider hpBar;//health bar displayed above character head


    // Start is called before the first frame update
    void Start()
    {

        hpBar = GetComponentInChildren<Slider>();//hpbar for each enemy to display health
        if (gameObject.tag == "Enemy2") {//enemy2 is the knight or scratchEnemy
            attackRange = 1.5f;//these chracters have shorter range that the brutes
        }
        enemyAgrro = false;//start off with enemy not detecting pl;ayer
        dead = false;//enemy is not dead to start off
        myAgent = GetComponent<NavMeshAgent>();//set the navmesh component to variable to avoid calling over and over
        Player = GameObject.FindGameObjectWithTag("Player");//to be able to find player
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.value = health;//set hp bar to display live health
        if (!dead)//if enemy not dead
        {
            if (Vector3.Distance(transform.position, Player.transform.position) < aggroRange)//if player in aggro range
            {
                enemyAgrro = true;//enemy has detected player
            }

            if (Vector3.Distance(transform.position, Player.transform.position) <= attackRange)//if player within attack range
            {
                myAgent.destination = transform.position;//stop mobving
                GetComponentInChildren<Animator>().SetBool("Attack", true);//start attack animation
                GetComponentInChildren<Animator>().SetBool("Walk", false);//stop walk animation

            }
            else if (enemyAgrro)//if enemy is aggro but not in attack range
            {
                GetComponentInChildren<Animator>().SetBool("Attack", false);//stop attacking
                GetComponentInChildren<Animator>().SetBool("Walk", true);//start walk animation
                myAgent.destination = Player.transform.position;//set navMesh agent to follow player

            }
        }
        else if (dead) {//if enemy dead
            deathTimer -= Time.deltaTime;//count down after the player dead flag is set
        }
        if (deathTimer <= 0){//enemy death timer done, been dead a while 
            Destroy(gameObject);//destroy enemy game object
        }

    }

    void takeDamage() {//enemy taking damage

        audioSources[0].Play();//taking damage sound
        health -= 20;//decrease health by 20
        if (health <= 0)//health is less than 0 
        {
            GetComponentInChildren<Animator>().SetBool("Dead", true);//play death animation
            myAgent.destination = transform.position;//stop moving if dead
            dead = true;//dead flag set to true
            audioSources[1].Play();//death sound

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Damage" && !dead) {//if magic ball hits enemy and the enemy is not already dead
            takeDamage();//call take damage fucntion
            enemyAgrro = true;
        }
    }
}
