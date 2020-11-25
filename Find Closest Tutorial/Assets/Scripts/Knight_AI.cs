using UnityEngine;
using UnityEngine.AI;


public class Knight_AI : MonoBehaviour
{

    // Knights with same color looks for nearest opponent knight,
    // moves towards, attacks, kill and moves to the next one


    public string EnemyTag;

    private GameObject target;
    public GameObject currentClosest;

    Rigidbody rb;

    private NavMeshAgent agent;
    private Animator animator;

    public float hitDistance = 1f;
    public int damage = 10;

    GameObject[] knights;
    float elapsed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;
        knights = GameObject.FindGameObjectsWithTag(EnemyTag);
    }

    void Update()
    {

        currentClosest = FindClosest(target);

        if (currentClosest != null) // check if there is any opponents left
        {
            //knight moves always towards enemy knight until hitting distance is close enough
            float distanceToClosest = (currentClosest.transform.position - transform.position).sqrMagnitude; 

            if (distanceToClosest < hitDistance)
            {
                Attack();
            }
            else
            {
                Move();
            }

        }
        else
        {
            Idle(); // if no enemies are left, we se knight to idle state
        }

    }
  
    GameObject FindClosest(GameObject closestKnight)
    {
        Vector3 currentPos = transform.position;
        float distanceToClosestTarget = Mathf.Infinity;
        closestKnight = null; //variable where closest enemy knight will be stored

        foreach (GameObject knight in knights) // goes through every knight in knights array tagged with enemytag
        {

            if (knight.GetComponent<KnightDamage>().isDead == false) // this can be also set "knight != null" and enemies will be destroyed instead of lying down when dead
            {
                float distance = (knight.transform.position - currentPos).sqrMagnitude; //searches for the distance of an individual knight relative to "this.gameObject"
                
                if (distance < distanceToClosestTarget)
                {
                    distanceToClosestTarget = distance;
                    closestKnight = knight;

                }

            }
        }
        return closestKnight;
    }


    void Attack()
    {
        agent.speed = 0;
        animator.SetInteger("SetState", 1);
        rb.isKinematic = true;
        if (gameObject.GetComponent<KnightDamage>().isDead == false) // knight can deal damage only when alive
        {
            DealDamage();
        }
    }

    void Move()
    {
        rb.isKinematic = false;
        float randomMovementSpeed = Random.Range(1.3f, 1.8f);
        agent.speed = randomMovementSpeed;
        transform.LookAt(currentClosest.transform);

        if (agent.enabled)
        {
            agent.destination = currentClosest.transform.position;
        }
        animator.SetInteger("SetState", 2);

    }

    void Idle()
    {
        rb.isKinematic = true;
        agent.speed = 0;
        animator.SetInteger("SetState", 3);
    }

    void DealDamage()
    {
        float elapsedIsRandomized = Random.Range(2, 4);
        elapsed += Time.deltaTime;

        if (elapsed >= elapsedIsRandomized) // avoid giving damage constantly
        {
            elapsed = elapsed % elapsedIsRandomized;
            if (currentClosest != null)
            {
                KnightDamage damageSC = currentClosest.GetComponent<KnightDamage>();
                damageSC.TakeDamage(damage);
            }
        }

    }
}
