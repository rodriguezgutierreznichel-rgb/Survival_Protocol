using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent agent;
    [SerializeField]
    Transform targetPosition;
    [SerializeField]
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("No tienes un animator en " + gameObject.name, gameObject);
        }

        agent.SetDestination(targetPosition.position);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Walking", agent.velocity.magnitude);

    }

    public void Caminar()
    {

    }
}
