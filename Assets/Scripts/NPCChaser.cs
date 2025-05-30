using UnityEngine;
using UnityEngine.AI;

public class NPCChaser : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    public GameManager gameManager;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameManager != null)
                gameManager.ShowGameOver();

            agent.isStopped = true;
        }
    }
}
