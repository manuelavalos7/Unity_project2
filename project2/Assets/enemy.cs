using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemy : MonoBehaviour
{
    private NavMeshAgent myAgent;
    private bool enemyAgrro;
    private bool move;
    private GameObject Player;
    public int aggroRange = 8;
    private int health=100;


    // Start is called before the first frame update
    void Start()
    {
        enemyAgrro = false;
        move = false;
        myAgent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) < aggroRange) {
            enemyAgrro = true; 
        }

        if (Vector3.Distance(transform.position, Player.transform.position) <= 2 && enemyAgrro)
        {
            myAgent.destination = transform.position;

        }
        else if (enemyAgrro) {
            myAgent.destination = Player.transform.position;
        }
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    void takeDamage() {
        health -= 10;
    }
}
