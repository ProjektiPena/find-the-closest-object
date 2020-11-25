using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KnightDamage : MonoBehaviour
{

    //knights dies with ragdoll effect

    public int maxHealth = 100;
    public int currentHealth;
    public bool isDead; // stores dying info to bool

    void Start()
    {
        isDead = false;
        currentHealth = maxHealth;
        state_colliders(false); 
        state_rb(true);
    }

    // setting up ragdoll
    void state_rb(bool _state)
    {
        
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = _state;

        }

        GetComponent<Rigidbody>().isKinematic = !_state;
    }

    void state_colliders(bool _state)
    {

        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider collider in colliders)
        {
            collider.enabled = _state;

        }
        GetComponent<Collider>().enabled = !_state;
    }
    public void TakeDamage(int damage)
    {

        currentHealth -= damage;


        if (currentHealth <= 0F)
        {
            // activate ragdoll effect when knight is dead
            // set off navmeshagents, ai-script and animator to avoid any unnecessary movements
            currentHealth = 0;
            state_colliders(true); 
            state_rb(false);
            gameObject.GetComponent<NavMeshAgent>().enabled = false; 
            gameObject.GetComponent<Knight_AI>().enabled = false;

            gameObject.GetComponent<Animator>().enabled = false;
            isDead = true;

        }

    }

}
