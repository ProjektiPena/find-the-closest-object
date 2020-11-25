using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KnightDamage : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool isDead;
    public LayerMask layer; 

    void Start()
    {
        isDead = false;
        currentHealth = maxHealth;
        setCollidersState(false);
        setRigidbodyState(true);
    }


    void setRigidbodyState(bool state)
    {

        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = state;

        }

        GetComponent<Rigidbody>().isKinematic = !state;
    }

    void setCollidersState(bool state)
    {

        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider collider in colliders)
        {
            collider.enabled = state;

        }
        GetComponent<Collider>().enabled = !state;
    }
    public void TakeDamage(int damage)
    {

        currentHealth -= damage;


        if (currentHealth <= 0F)
        {
            currentHealth = 0;
            setCollidersState(true);
            setRigidbodyState(false);
            if (gameObject.GetComponent<NavMeshAgent>() != null)
            {
                gameObject.GetComponent<NavMeshAgent>().enabled = false;
            }
            if (gameObject.GetComponent<Knight_AI>() != null)
            {
                gameObject.GetComponent<Knight_AI>().enabled = false;
            }

            gameObject.GetComponent<Animator>().enabled = false;
            isDead = true;

        }

    }

}
